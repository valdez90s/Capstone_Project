using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using PotpotMotorShopPOS.Helpers;

namespace PotpotMotorShopPOS
{
    internal static class ServerDatabase
    {
        private static readonly string connectionString =
            "Host=192.168.10.201;Port=5432;Database=POS_INVENTORY_DB;Username=POS_ADMIN;Password=123456789;Timeout=5;";

        /// <summary>
        /// Returns an open PostgreSQL connection to the central server.
        /// Shows user-friendly error message if connection fails.
        /// </summary>
        public static NpgsqlConnection GetConnection()
        {
            try
            {
                var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                // ✅ Just log the error, don't show MessageBox
                // Let the caller handle the UI message display
                System.Diagnostics.Debug.WriteLine($"[ServerDatabase] Connection Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Quick check if the server is reachable.
        /// </summary>
        public static bool TestConnection(out string message)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    message = "✅ Connected successfully to PostgreSQL server.";
                    return true;
                }
            }
            catch (NpgsqlException ex)
            {
                if (ex.Message.Contains("Connection refused") ||
                    ex.Message.Contains("No connection could be made"))
                {
                    message = "Server is not responding. Check if the server is running.";
                }
                else if (ex.Message.Contains("timeout"))
                {
                    message = "Connection timeout. Check your network connection.";
                }
                else if (ex.Message.Contains("password authentication failed"))
                {
                    message = "Authentication failed. Invalid credentials.";
                }
                else
                {
                    message = $"Connection failed: {ex.Message}";
                }
                return false;
            }
            catch (Exception ex)
            {
                message = $"Connection error: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// 🆕 NEW: Test connection with loading overlay using LoadingHelper
        /// Shows beautiful loading animation while checking connection
        /// </summary>
        public static async Task<(bool success, string message)> TestConnectionWithLoadingAsync(Form parentForm)
        {
            string resultMessage = "";
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(
                parentForm,
                async () =>
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            using (var conn = new NpgsqlConnection(connectionString))
                            {
                                conn.Open();
                                resultMessage = "✅ Connected successfully to PostgreSQL server.";
                                connectionSuccess = true;
                            }
                        }
                        catch (NpgsqlException ex)
                        {
                            if (ex.Message.Contains("Connection refused") ||
                                ex.Message.Contains("No connection could be made"))
                            {
                                resultMessage = "⚠️ Server is not responding.\n\nCheck if the server is running.";
                            }
                            else if (ex.Message.Contains("timeout"))
                            {
                                resultMessage = "⚠️ Connection timeout.\n\nCheck your network connection.";
                            }
                            else if (ex.Message.Contains("password authentication failed"))
                            {
                                resultMessage = "⚠️ Authentication failed.\n\nInvalid credentials.";
                            }
                            else
                            {
                                resultMessage = $"⚠️ Connection failed:\n\n{ex.Message}";
                            }
                            connectionSuccess = false;
                        }
                        catch (Exception ex)
                        {
                            resultMessage = $"⚠️ Connection error:\n\n{ex.Message}";
                            connectionSuccess = false;
                        }
                    });
                },
                minimumDelayMs: 1000, // Minimum 1 second para makita yung loading
                loadingText: "Connecting to server..."
            );

            return (connectionSuccess, resultMessage);
        }

        /// <summary>
        /// 🆕 Get connection with loading overlay
        /// Returns connection if successful, null if failed (with error message shown)
        /// </summary>
        public static async Task<NpgsqlConnection> GetConnectionWithLoadingAsync(Form parentForm)
        {
            NpgsqlConnection resultConnection = null;

            await LoadingHelper.RunWithLoading(
                parentForm,
                async () =>
                {
                    await Task.Run(() =>
                    {
                        resultConnection = GetConnection();
                    });
                },
                minimumDelayMs: 800,
                loadingText: "Connecting to database..."
            );

            return resultConnection;
        }
    }
}