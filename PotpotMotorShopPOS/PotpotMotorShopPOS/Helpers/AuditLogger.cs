using Npgsql;
using System;
using System.Management;
using System.Net;
using System.Net.Sockets;

namespace PotpotMotorShopPOS.Helpers
{
    /// <summary>
    /// ✅ AuditLogger - Centralized audit logging helper
    /// </summary>
    public static class AuditLogger
    {
        /// <summary>
        /// ✅ Log any action to AuditLogs table
        /// </summary>
        /// <param name="action">Action type (INSERT, UPDATE, DELETE, LOGIN, LOGOUT, etc.)</param>
        /// <param name="tableName">Target table name</param>
        /// <param name="recordId">Affected record ID (optional)</param>
        /// <param name="description">Description of the action</param>
        public static void Log(string action, string tableName, int? recordId = null, string description = "")
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    string query = @"
                        INSERT INTO AuditLogs 
                        (UserID, Action, TableName, RecordID, Description, Timestamp, IPAddress, DeviceInfo)
                        VALUES 
                        (@UserID, @Action, @TableName, @RecordID, @Description, @Timestamp, @IPAddress, @DeviceInfo)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // ✅ Get current user from SessionManager
                        cmd.Parameters.AddWithValue("@UserID",
                            SessionManager.IsLoggedIn ? (object)SessionManager.CurrentUserID : DBNull.Value);

                        cmd.Parameters.AddWithValue("@Action", action ?? "UNKNOWN");
                        cmd.Parameters.AddWithValue("@TableName", tableName ?? "UNKNOWN");
                        cmd.Parameters.AddWithValue("@RecordID",
                            recordId.HasValue ? (object)recordId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Description", description ?? "");
                        cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                        cmd.Parameters.AddWithValue("@IPAddress", GetLocalIPAddress());
                        cmd.Parameters.AddWithValue("@DeviceInfo", GetDeviceInfo());

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // ✅ Silent fail - don't interrupt user operations
                System.Diagnostics.Debug.WriteLine($"[AuditLogger Error] {ex.Message}");
            }
        }

        /// <summary>
        /// ✅ Log INSERT action
        /// </summary>
        public static void LogInsert(string tableName, int recordId, string description)
        {
            Log("INSERT", tableName, recordId, description);
        }

        /// <summary>
        /// ✅ Log UPDATE action
        /// </summary>
        public static void LogUpdate(string tableName, int recordId, string description)
        {
            Log("UPDATE", tableName, recordId, description);
        }

        /// <summary>
        /// ✅ Log DELETE action
        /// </summary>
        public static void LogDelete(string tableName, int recordId, string description)
        {
            Log("DELETE", tableName, recordId, description);
        }

        /// <summary>
        /// ✅ Log LOGIN action
        /// </summary>
        public static void LogLogin(string username, bool success)
        {
            string description = success
                ? $"User '{username}' logged in successfully"
                : $"Failed login attempt for user '{username}'";

            Log(success ? "LOGIN" : "LOGIN_FAILED", "Users", null, description);
        }

        /// <summary>
        /// ✅ Log LOGOUT action
        /// </summary>
        public static void LogLogout(string username)
        {
            Log("LOGOUT", "Users", null, $"User '{username}' logged out");
        }

        /// <summary>
        /// ✅ Log STOCK ADJUSTMENT action
        /// </summary>
        public static void LogStockAdjustment(int productId, string productName,
            int quantityBefore, int quantityAfter, string adjustmentType, string remark)
        {
            string description = $"Product: {productName} | " +
                                $"Before: {quantityBefore} | " +
                                $"After: {quantityAfter} | " +
                                $"Type: {adjustmentType} | " +
                                $"Remark: {remark}";

            Log("STOCK_ADJUSTMENT", "Products", productId, description);
        }

        /// <summary>
        /// ✅ Log TRANSACTION/SALE action
        /// </summary>
        public static void LogTransaction(int transactionId, decimal totalAmount, string paymentMethod)
        {
            string description = $"Transaction completed | " +
                                $"Amount: ₱{totalAmount:N2} | " +
                                $"Payment: {paymentMethod}";

            Log("SALE", "Transactions", transactionId, description);
        }

        /// <summary>
        /// ✅ Get local IP address
        /// </summary>
        private static string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return "Unknown";
            }
            catch
            {
                return "Unknown";
            }
        }

        /// <summary>
        /// ✅ Log DISCOUNT action
        /// </summary>
        public static void LogDiscount(decimal discountAmount, decimal subtotal,
            string discountType, string authorizedBy, string reason = "")
        {
            string description = $"Discount Applied | " +
                                $"Amount: ₱{discountAmount:N2} | " +
                                $"Subtotal: ₱{subtotal:N2} | " +
                                $"Type: {discountType} | " +
                                $"Authorized by: {authorizedBy}";

            if (!string.IsNullOrEmpty(reason))
                description += $" | Reason: {reason}";

            Log("DISCOUNT_APPLIED", "Transactions", null, description);
        }

        /// <summary>
        /// ✅ Get device info (Computer Name + OS)
        /// </summary>
        private static string GetDeviceInfo()
        {
            try
            {
                string computerName = Environment.MachineName;
                string osVersion = Environment.OSVersion.ToString();
                return $"{computerName} | {osVersion}";
            }
            catch
            {
                return "Unknown Device";
            }
        }
    }
}