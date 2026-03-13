using Npgsql;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Forms.AdminManagement
{
    public partial class AuditLogsControl : UserControl
    {
        public AuditLogsControl()
        {
            InitializeComponent();
            DataGridHelper.ApplyStyle(dgvAuditLogs);
        }

        private void AuditLogsControl_Load(object sender, EventArgs e)
        {
            InitializeFilters();
            LoadAuditLogs();
        }

        /// <summary>
        /// ✅ Initialize filters
        /// </summary>
        private void InitializeFilters()
        {
            // ✅ Set default date range (last 30 days)
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;

            LoadUsers();
            LoadActionTypes();
            LoadTableNames();
        }

        /// <summary>
        /// ✅ Load users for filter dropdown
        /// </summary>
        private void LoadUsers()
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    string query = @"
                        SELECT DISTINCT u.UserID, u.Username 
                        FROM Users u
                        INNER JOIN AuditLogs al ON u.UserID = al.UserID
                        WHERE u.Username IS NOT NULL
                        ORDER BY u.Username";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbUser.Items.Clear();
                        cmbUser.Items.Add(new FilterItem { ID = 0, Name = "All Users" });

                        while (reader.Read())
                        {
                            cmbUser.Items.Add(new FilterItem
                            {
                                ID = Convert.ToInt32(reader["UserID"]),
                                Name = reader["Username"].ToString()
                            });
                        }
                    }
                }

                cmbUser.DisplayMember = "Name";
                cmbUser.ValueMember = "ID";

                if (cmbUser.Items.Count > 0)
                    cmbUser.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ✅ Load action types for filter dropdown
        /// </summary>
        private void LoadActionTypes()
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    string query = @"
                        SELECT DISTINCT Action 
                        FROM AuditLogs 
                        WHERE Action IS NOT NULL
                        ORDER BY Action";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbAction.Items.Clear();
                        cmbAction.Items.Add("All Actions");

                        while (reader.Read())
                        {
                            string action = reader["Action"].ToString();
                            if (!string.IsNullOrEmpty(action))
                                cmbAction.Items.Add(action);
                        }
                    }
                }

                if (cmbAction.Items.Count > 0)
                    cmbAction.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading action types: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ✅ Load table names for filter dropdown
        /// </summary>
        private void LoadTableNames()
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    string query = @"
                        SELECT DISTINCT TableName 
                        FROM AuditLogs 
                        WHERE TableName IS NOT NULL
                        ORDER BY TableName";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbTable.Items.Clear();
                        cmbTable.Items.Add("All Tables");

                        while (reader.Read())
                        {
                            string tableName = reader["TableName"].ToString();
                            if (!string.IsNullOrEmpty(tableName))
                                cmbTable.Items.Add(tableName);
                        }
                    }
                }

                if (cmbTable.Items.Count > 0)
                    cmbTable.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading table names: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ✅ Load audit logs with filters
        /// </summary>
        private void LoadAuditLogs()
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    var selectedUser = cmbUser.SelectedItem as FilterItem;
                    string selectedAction = cmbAction.SelectedItem?.ToString();
                    string selectedTable = cmbTable.SelectedItem?.ToString();
                    string searchText = txtSearch.Text.Trim();

                    DateTime dateFrom = dtpFrom.Value.Date;
                    DateTime dateTo = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                    string query = @"
                        SELECT 
                            al.LogID,
                            al.UserID,
                            COALESCE(u.Username, 'Unknown') AS Username,
                            al.Action,
                            al.TableName,
                            al.RecordID,
                            al.Description,
                            al.Timestamp,
                            al.IPAddress,
                            al.DeviceInfo
                        FROM AuditLogs al
                        LEFT JOIN Users u ON al.UserID = u.UserID
                        WHERE al.Timestamp >= @DateFrom
                        AND al.Timestamp <= @DateTo";

                    // ✅ User filter
                    if (selectedUser != null && selectedUser.ID != 0)
                    {
                        query += " AND al.UserID = @UserID";
                    }

                    // ✅ Action filter
                    if (!string.IsNullOrEmpty(selectedAction) && selectedAction != "All Actions")
                    {
                        query += " AND al.Action = @Action";
                    }

                    // ✅ Table filter
                    if (!string.IsNullOrEmpty(selectedTable) && selectedTable != "All Tables")
                    {
                        query += " AND al.TableName = @TableName";
                    }

                    // ✅ Search filter
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        query += @" AND (
                            al.Description ILIKE @Search OR 
                            u.Username ILIKE @Search OR 
                            al.IPAddress ILIKE @Search OR
                            al.Action ILIKE @Search OR
                            al.TableName ILIKE @Search
                        )";
                    }

                    query += " ORDER BY al.Timestamp DESC LIMIT 500;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", dateTo);

                        if (selectedUser != null && selectedUser.ID != 0)
                            cmd.Parameters.AddWithValue("@UserID", selectedUser.ID);

                        if (!string.IsNullOrEmpty(selectedAction) && selectedAction != "All Actions")
                            cmd.Parameters.AddWithValue("@Action", selectedAction);

                        if (!string.IsNullOrEmpty(selectedTable) && selectedTable != "All Tables")
                            cmd.Parameters.AddWithValue("@TableName", selectedTable);

                        if (!string.IsNullOrEmpty(searchText))
                            cmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable("AuditLogs");
                            adapter.Fill(dt);

                            dgvAuditLogs.AutoGenerateColumns = false;
                            dgvAuditLogs.DataSource = dt;

                            // ✅ Map columns (safe check if columns exist)
                            MapColumn("LogID", "LogID", false);
                            MapColumn("UserID", "UserID", false);
                            MapColumn("Username", "Username");
                            MapColumn("Action", "Action");
                            MapColumn("TableName", "TableName");
                            MapColumn("RecordID", "RecordID");
                            MapColumn("Description", "Description");
                            MapColumn("Timestamp", "Timestamp");
                            MapColumn("IPAddress", "IPAddress");
                            MapColumn("DeviceInfo", "DeviceInfo");

                            // ✅ Color-code rows
                            ColorCodeRows();

                            // ✅ Update record count
                            lblRecordCount.Text = $"Records: {dt.Rows.Count}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading audit logs: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ✅ Helper method to safely map columns
        /// </summary>
        private void MapColumn(string columnName, string dataPropertyName, bool visible = true)
        {
            if (dgvAuditLogs.Columns.Contains(columnName))
            {
                dgvAuditLogs.Columns[columnName].DataPropertyName = dataPropertyName;
                dgvAuditLogs.Columns[columnName].Visible = visible;
            }
        }

        /// <summary>
        /// ✅ Color-code rows based on action type
        /// </summary>
        private void ColorCodeRows()
        {
            foreach (DataGridViewRow row in dgvAuditLogs.Rows)
            {
                if (row.Cells["Action"].Value != null)
                {
                    string action = row.Cells["Action"].Value.ToString().ToUpper();

                    if (action.Contains("DELETE"))
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230); // Light red
                    else if (action.Contains("INSERT") || action.Contains("CREATE"))
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230); // Light green
                    else if (action.Contains("UPDATE") || action.Contains("EDIT"))
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 230); // Light yellow
                    else if (action.Contains("LOGIN"))
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255); // Light blue
                    else if (action.Contains("LOGOUT"))
                        row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Light gray
                }
            }
        }

        /// <summary>
        /// ✅ Filter button click
        /// </summary>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("'From Date' cannot be later than 'To Date'.",
                                "Invalid Date Range",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            LoadAuditLogs();
        }

        /// <summary>
        /// ✅ Reset filters
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;

            if (cmbUser.Items.Count > 0)
                cmbUser.SelectedIndex = 0;

            if (cmbAction.Items.Count > 0)
                cmbAction.SelectedIndex = 0;

            if (cmbTable.Items.Count > 0)
                cmbTable.SelectedIndex = 0;

            txtSearch.Clear();
            LoadAuditLogs();
        }

        /// <summary>
        /// ✅ Auto-reload on filter changes
        /// </summary>
        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAuditLogs();
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAuditLogs();
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAuditLogs();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value <= dtpTo.Value)
                LoadAuditLogs();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value <= dtpTo.Value)
                LoadAuditLogs();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadAuditLogs();
        }

        /// <summary>
        /// ✅ View full details on double-click
        /// </summary>
        private void dgvAuditLogs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvAuditLogs.Rows[e.RowIndex];
            string details = $"Log ID: {row.Cells["LogID"].Value}\n" +
                           $"User: {row.Cells["Username"].Value}\n" +
                           $"Action: {row.Cells["Action"].Value}\n" +
                           $"Table: {row.Cells["TableName"].Value}\n" +
                           $"Record ID: {row.Cells["RecordID"].Value}\n" +
                           $"Timestamp: {row.Cells["Timestamp"].Value}\n" +
                           $"IP Address: {row.Cells["IPAddress"].Value}\n" +
                           $"Device: {row.Cells["DeviceInfo"].Value}\n\n" +
                           $"Description:\n{row.Cells["Description"].Value}";

            MessageBox.Show(details, "Audit Log Details",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ✅ Export to CSV
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = dgvAuditLogs.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv";
                    sfd.FileName = $"AuditLogs_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();

                        // ✅ Headers
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sb.Append(dt.Columns[i].ColumnName);
                            if (i < dt.Columns.Count - 1)
                                sb.Append(",");
                        }
                        sb.AppendLine();

                        // ✅ Rows
                        foreach (DataRow row in dt.Rows)
                        {
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                string value = row[i].ToString()
                                    .Replace(",", ";")
                                    .Replace("\r\n", " ")
                                    .Replace("\n", " ");
                                sb.Append(value);

                                if (i < dt.Columns.Count - 1)
                                    sb.Append(",");
                            }
                            sb.AppendLine();
                        }

                        System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
                        MessageBox.Show("Audit logs exported successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GradientPanel5_Paint(object sender, PaintEventArgs e)
        {
            // Optional: leave empty
        }

        /// <summary>
        /// ✅ Filter item class
        /// </summary>
        private class FilterItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}