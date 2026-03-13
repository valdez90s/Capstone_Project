using Npgsql;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class BackupRestoreControl : UserControl
    {
        #region Properties

        // Get connection details from ServerDatabase class
        private string connectionString = "Host=192.168.10.201;Port=5432;Database=POS_INVENTORY_DB;Username=POS_ADMIN;Password=123456789;Timeout=5;";
        public string BackupFolder { get; set; } = @"C:\POS_Backups";

        private System.Timers.Timer backupTimer;
        private bool isOperationRunning = false;

        #endregion

        public BackupRestoreControl()
        {
            InitializeComponent();
            LoadSettings();
            SetupScheduledBackup();
        }

        private void LoadSettings()
        {
            // Load from config if needed
            Directory.CreateDirectory(BackupFolder);
        }

        #region SQL Backup/Restore (Pure Npgsql - No pg_dump needed!)

        private void btnBackupPostgreSQL_Click(object sender, EventArgs e)
        {
            if (isOperationRunning)
            {
                MessageBox.Show("Another operation is in progress. Please wait.",
                    "Operation in Progress", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                isOperationRunning = true;
                UpdateUIState(false);
                UpdateProgress("Starting backup...");

                string backupFile = Path.Combine(
                    BackupFolder,
                    $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql");

                // Test connection first
                using (var testConn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        testConn.Open();
                        UpdateProgress("Connected to database successfully");
                    }
                    catch (NpgsqlException ex)
                    {
                        // ✅ ADDED: Better connection error handling
                        throw new Exception(
                            $"Cannot connect to database server.\n\n" +
                            $"Please check:\n" +
                            $"• Server is reachable (192.168.100.115)\n" +
                            $"• Network/Internet connection is active\n" +
                            $"• Database credentials are correct\n\n" +
                            $"Technical error: {ex.Message}", ex);
                    }
                }

                // Perform backup
                PerformSQLBackup(backupFile);

                MessageBox.Show(
                    $" Backup Completed Successfully!\n\n" +
                    $"File: {Path.GetFileName(backupFile)}\n" +
                    $"Location: {Path.GetDirectoryName(backupFile)}\n" +
                    $"Size: {new FileInfo(backupFile).Length / 1024:N0} KB\n" +
                    $"Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                    "Backup Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LogOperation("Backup", backupFile, true, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $" Backup Failed!\n\n{ex.Message}",
                    "Backup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                LogOperation("Backup", "", false, ex.Message);
            }
            finally
            {
                isOperationRunning = false;
                UpdateUIState(true);
                UpdateProgress("Ready");
            }
        }

        private void PerformSQLBackup(string backupFile)
        {
            // ✅ ADDED: Use try-with-resources pattern with explicit null check
            NpgsqlConnection conn = null;
            try
            {
                conn = new NpgsqlConnection(connectionString);
                conn.Open();

                UpdateProgress("Retrieving database schema...");

                StringBuilder sqlBackup = new StringBuilder();

                // Header
                sqlBackup.AppendLine("-- PostgreSQL Database Backup");
                sqlBackup.AppendLine($"-- Created: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                sqlBackup.AppendLine($"-- Database: POS_INVENTORY_DB");
                sqlBackup.AppendLine($"-- Server: 192.168.100.115:5432");
                sqlBackup.AppendLine();
                sqlBackup.AppendLine("-- Disable triggers during restore");
                sqlBackup.AppendLine("SET session_replication_role = 'replica';");
                sqlBackup.AppendLine();

                // Get all table names
                var tables = GetAllTables(conn);
                UpdateProgress($"Found {tables.Count} tables to backup");

                if (tables.Count == 0)
                {
                    throw new Exception("No tables found in database. Backup aborted.");
                }

                int tableCount = 0;
                foreach (string table in tables)
                {
                    tableCount++;
                    UpdateProgress($"Backing up table {tableCount}/{tables.Count}: {table}");

                    // Get CREATE TABLE statement
                    string createTableSQL = GetCreateTableSQL(conn, table);
                    sqlBackup.AppendLine($"-- Table: {table}");
                    sqlBackup.AppendLine($"DROP TABLE IF EXISTS {table} CASCADE;");
                    sqlBackup.AppendLine(createTableSQL);
                    sqlBackup.AppendLine();

                    // Get table data
                    string insertStatements = GetTableData(conn, table);
                    if (!string.IsNullOrEmpty(insertStatements))
                    {
                        sqlBackup.AppendLine($"-- Data for {table}");
                        sqlBackup.AppendLine(insertStatements);
                        sqlBackup.AppendLine();
                    }
                }

                // Reset sequences (only for tables with data)
                sqlBackup.AppendLine("-- Reset sequences");
                sqlBackup.AppendLine("DO $");
                sqlBackup.AppendLine("BEGIN");
                foreach (string table in tables)
                {
                    string seqReset = GetSequenceResetSQL(conn, table);
                    if (!string.IsNullOrEmpty(seqReset))
                    {
                        sqlBackup.AppendLine($"    {seqReset}");
                    }
                }
                sqlBackup.AppendLine("EXCEPTION WHEN OTHERS THEN");
                sqlBackup.AppendLine("    NULL; -- Ignore errors if sequence doesn't exist");
                sqlBackup.AppendLine("END $;");

                // Re-enable triggers
                sqlBackup.AppendLine();
                sqlBackup.AppendLine("-- Re-enable triggers");
                sqlBackup.AppendLine("SET session_replication_role = 'origin';");

                UpdateProgress("Writing backup file...");
                File.WriteAllText(backupFile, sqlBackup.ToString(), Encoding.UTF8);
                UpdateProgress("Backup complete!");
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
            }
        }

        private System.Collections.Generic.List<string> GetAllTables(NpgsqlConnection conn)
        {
            var tables = new System.Collections.Generic.List<string>();

            string sql = @"
                SELECT table_name 
                FROM information_schema.tables 
                WHERE table_schema = 'public' 
                AND table_type = 'BASE TABLE'
                ORDER BY table_name";

            using (var cmd = new NpgsqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    tables.Add(reader.GetString(0));
                }
            }

            return tables;
        }

        private string GetCreateTableSQL(NpgsqlConnection conn, string tableName)
        {
            StringBuilder createSQL = new StringBuilder();
            createSQL.AppendLine($"CREATE TABLE {tableName} (");

            // Get columns
            string columnSQL = @"
                SELECT column_name, data_type, character_maximum_length, 
                       is_nullable, column_default
                FROM information_schema.columns
                WHERE table_name = @table
                ORDER BY ordinal_position";

            var columns = new System.Collections.Generic.List<string>();
            using (var cmd = new NpgsqlCommand(columnSQL, conn))
            {
                cmd.Parameters.AddWithValue("table", tableName);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string colName = reader.GetString(0);
                        string dataType = reader.GetString(1);
                        bool isNullable = reader.GetString(3) == "YES";
                        string defaultVal = reader.IsDBNull(4) ? null : reader.GetString(4);

                        string colDef = $"    {colName} {dataType.ToUpper()}";

                        if (!reader.IsDBNull(2) && dataType == "character varying")
                            colDef += $"({reader.GetInt32(2)})";

                        if (defaultVal != null)
                            colDef += $" DEFAULT {defaultVal}";

                        if (!isNullable)
                            colDef += " NOT NULL";

                        columns.Add(colDef);
                    }
                }
            }

            createSQL.AppendLine(string.Join(",\n", columns));

            // Get primary key
            string pkSQL = @"
                SELECT a.attname
                FROM pg_index i
                JOIN pg_attribute a ON a.attrelid = i.indrelid AND a.attnum = ANY(i.indkey)
                WHERE i.indrelid = @table::regclass AND i.indisprimary";

            var pkColumns = new System.Collections.Generic.List<string>();
            using (var cmd = new NpgsqlCommand(pkSQL, conn))
            {
                cmd.Parameters.AddWithValue("table", tableName);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        pkColumns.Add(reader.GetString(0));
                }
            }

            if (pkColumns.Count > 0)
                createSQL.AppendLine($",\n    PRIMARY KEY ({string.Join(", ", pkColumns)})");

            createSQL.AppendLine(");");
            return createSQL.ToString();
        }

        private string GetTableData(NpgsqlConnection conn, string tableName)
        {
            StringBuilder insertSQL = new StringBuilder();

            using (var cmd = new NpgsqlCommand($"SELECT * FROM {tableName}", conn))
            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows) return "";

                var columnNames = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    columnNames[i] = reader.GetName(i);

                while (reader.Read())
                {
                    var values = new System.Collections.Generic.List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.IsDBNull(i))
                            values.Add("NULL");
                        else
                        {
                            object val = reader.GetValue(i);
                            if (val is string || val is DateTime)
                                values.Add($"'{val.ToString().Replace("'", "''")}'");
                            else if (val is bool)
                                values.Add((bool)val ? "TRUE" : "FALSE");
                            else
                                values.Add(val.ToString());
                        }
                    }

                    insertSQL.AppendLine($"INSERT INTO {tableName} ({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", values)});");
                }
            }

            return insertSQL.ToString();
        }

        private string GetSequenceResetSQL(NpgsqlConnection conn, string tableName)
        {
            string sql = @"
                SELECT pg_get_serial_sequence(@table, column_name) as seq_name,
                       column_name
                FROM information_schema.columns
                WHERE table_name = @table 
                AND column_default LIKE 'nextval%'";

            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("table", tableName);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && !reader.IsDBNull(0))
                    {
                        string seqName = reader.GetString(0);
                        string columnName = reader.GetString(1);
                        return $"SELECT setval('{seqName}', COALESCE((SELECT MAX({columnName}) FROM {tableName}), 1), false);";
                    }
                }
            }

            return "";
        }

        #endregion

        #region Restore

        private void btnRestorePostgreSQL_Click(object sender, EventArgs e)
        {
            if (isOperationRunning)
            {
                MessageBox.Show("Another operation is in progress. Please wait.",
                    "Operation in Progress", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "SQL Backup (*.sql)|*.sql|All Files (*.*)|*.*",
                Title = "Select Backup File",
                InitialDirectory = BackupFolder
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            var confirmResult = MessageBox.Show(
                "⚠️ CRITICAL WARNING ⚠️\n\n" +
                "This will COMPLETELY REPLACE the current database!\n" +
                "ALL existing data will be OVERWRITTEN.\n\n" +
                $"Backup File: {Path.GetFileName(dlg.FileName)}\n" +
                $"File Date: {File.GetLastWriteTime(dlg.FileName):yyyy-MM-dd HH:mm:ss}\n\n" +
                "Do you want to proceed?",
                "⚠️ CONFIRM RESTORE",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes) return;

            try
            {
                isOperationRunning = true;
                UpdateUIState(false);
                UpdateProgress("Starting restore...");

                string sqlContent = File.ReadAllText(dlg.FileName, Encoding.UTF8);

                // ✅ ADDED: Explicit connection handling with null check
                NpgsqlConnection conn = null;
                try
                {
                    conn = new NpgsqlConnection(connectionString);
                    conn.Open();
                    UpdateProgress("Connected to database. Executing SQL commands...");

                    // Split by semicolon and execute one by one to handle errors better
                    var commands = sqlContent.Split(new[] { ";\r\n", ";\n" }, StringSplitOptions.RemoveEmptyEntries);
                    int executed = 0;
                    int failed = 0;

                    foreach (var cmdText in commands)
                    {
                        string trimmed = cmdText.Trim();
                        if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith("--"))
                            continue;

                        try
                        {
                            using (var cmd = new NpgsqlCommand(trimmed + ";", conn))
                            {
                                cmd.CommandTimeout = 300;
                                cmd.ExecuteNonQuery();
                            }
                            executed++;

                            if (executed % 100 == 0)
                                UpdateProgress($"Executed {executed} commands...");
                        }
                        catch (Exception cmdEx)
                        {
                            failed++;
                            // Log but continue - some errors are expected
                            Debug.WriteLine($"SQL Command Error (continuing): {cmdEx.Message}");

                            // ✅ ADDED: If too many failures, abort
                            if (failed > 50)
                            {
                                throw new Exception(
                                    $"Too many command failures ({failed}). Restore aborted.\n" +
                                    $"Last error: {cmdEx.Message}");
                            }
                        }
                    }

                    UpdateProgress($"Restore complete! Executed {executed} commands ({failed} skipped).");
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception(
                        $"Database connection error during restore.\n\n" +
                        $"Please check:\n" +
                        $"• Server is reachable (192.168.100.115)\n" +
                        $"• Network/Internet connection is active\n\n" +
                        $"Technical error: {ex.Message}", ex);
                }
                finally
                {
                    conn?.Close();
                    conn?.Dispose();
                }

                MessageBox.Show(
                    "✅ Restore Completed Successfully!\n\n" +
                    "Database has been restored.\n" +
                    "Please restart the application.",
                    "Restore Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LogOperation("Restore", dlg.FileName, true, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Restore Failed!\n\n{ex.Message}",
                    "Restore Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                LogOperation("Restore", dlg.FileName, false, ex.Message);
            }
            finally
            {
                isOperationRunning = false;
                UpdateUIState(true);
                UpdateProgress("Ready");
            }
        }

        #endregion

        #region Helpers

        private void UpdateProgress(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateProgress(message)));
                return;
            }

            // TODO: Update your progress label here
            // lblProgress.Text = message;

            Debug.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }

        private void UpdateUIState(bool enabled)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUIState(enabled)));
                return;
            }

            // TODO: Enable/disable your buttons
            // btnBackupPostgreSQL.Enabled = enabled;
            // btnRestorePostgreSQL.Enabled = enabled;
        }

        private void LogOperation(string operation, string filePath, bool success, string error)
        {
            try
            {
                string logFile = Path.Combine(BackupFolder, "backup_log.txt");
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
                                $"{operation} - {(success ? "SUCCESS" : "FAILED")}";

                if (!string.IsNullOrEmpty(filePath))
                    logEntry += $" - File: {Path.GetFileName(filePath)}";

                if (!success && !string.IsNullOrEmpty(error))
                    logEntry += $"\nError: {error}";

                logEntry += "\n" + new string('-', 80) + "\n";

                File.AppendAllText(logFile, logEntry);
            }
            catch { }
        }

        #endregion

        #region Scheduled Backup

        private void SetupScheduledBackup()
        {
            DateTime now = DateTime.Now;
            DateTime nextRun = new DateTime(now.Year, now.Month, now.Day, 2, 0, 0);

            if (now > nextRun)
                nextRun = nextRun.AddDays(1);

            double interval = (nextRun - now).TotalMilliseconds;

            backupTimer = new System.Timers.Timer(interval);
            backupTimer.Elapsed += BackupTimer_Elapsed;
            backupTimer.AutoReset = false;
            backupTimer.Start();

            Debug.WriteLine($"[Scheduled Backup] Next backup: {nextRun:yyyy-MM-dd HH:mm:ss}");
        }

        private void BackupTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Debug.WriteLine($"[Scheduled Backup] Running at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                this.Invoke((MethodInvoker)delegate
                {
                    btnBackupPostgreSQL_Click(null, null);
                });

                backupTimer.Interval = 24 * 60 * 60 * 1000;
                backupTimer.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Scheduled Backup] Error: {ex.Message}");

                try
                {
                    string logFile = Path.Combine(BackupFolder, "scheduled_backup_errors.txt");
                    File.AppendAllText(logFile,
                        $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error: {ex.Message}\n");
                }
                catch { }
            }
        }

        public void EnableScheduledBackup()
        {
            backupTimer?.Start();
            Debug.WriteLine("[Scheduled Backup] Enabled");
        }

        public void DisableScheduledBackup()
        {
            backupTimer?.Stop();
            Debug.WriteLine("[Scheduled Backup] Disabled");
        }

        #endregion

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}