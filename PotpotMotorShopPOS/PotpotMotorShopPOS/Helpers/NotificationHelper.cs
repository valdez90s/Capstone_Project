using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Helpers
{
    public class StockNotification
    {
        public int NotificationID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public int CurrentStock { get; set; }
        public string NotificationType { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public static class NotificationHelper
    {
        private const int CRITICAL_STOCK_THRESHOLD = 10;

        /// <summary>
        /// ✅ Check and generate stock notifications
        /// </summary>
        public static void CheckAndGenerateNotifications()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("=== [NOTIFICATION] Starting Check ===");

                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null)
                    {
                        System.Diagnostics.Debug.WriteLine("❌ [NOTIFICATION] Connection is NULL!");
                        MessageBox.Show("Database connection failed!", "Notification Debug");
                        return;
                    }

                    System.Diagnostics.Debug.WriteLine("✅ [NOTIFICATION] Connection OK");

                    // ✅ FIXED - Removed IsDeleted condition
                    string query = @"
                        SELECT ProductID, ProductName, Barcode, Quantity 
                        FROM Products 
                        WHERE Quantity <= @Threshold";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Threshold", CRITICAL_STOCK_THRESHOLD);

                        System.Diagnostics.Debug.WriteLine($"✅ [NOTIFICATION] Searching products with stock <= {CRITICAL_STOCK_THRESHOLD}");

                        using (var reader = cmd.ExecuteReader())
                        {
                            var products = new List<(int id, string name, string barcode, int qty)>();

                            while (reader.Read())
                            {
                                products.Add((
                                    Convert.ToInt32(reader["ProductID"]),
                                    reader["ProductName"].ToString(),
                                    reader["Barcode"]?.ToString() ?? "",
                                    Convert.ToInt32(reader["Quantity"])
                                ));
                            }

                            System.Diagnostics.Debug.WriteLine($"✅ [NOTIFICATION] Found {products.Count} products with low stock");

                            if (products.Count == 0)
                            {
                                System.Diagnostics.Debug.WriteLine("ℹ️ [NOTIFICATION] No products need notification");
                            }

                            reader.Close();

                            // ✅ Create notifications for each product
                            foreach (var product in products)
                            {
                                System.Diagnostics.Debug.WriteLine($"   → Processing: {product.name} (Stock: {product.qty})");
                                CreateNotification(conn, product.id, product.name, product.barcode, product.qty);
                            }
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine("=== [NOTIFICATION] Check Complete ===\n");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ [NOTIFICATION] Error: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"   Stack: {ex.StackTrace}");
                MessageBox.Show($"Notification error: {ex.Message}", "Debug Error");
            }
        }

        /// <summary>
        /// ✅ Create notification if not already exists
        /// </summary>
        private static void CreateNotification(NpgsqlConnection conn, int productId,
            string productName, string barcode, int currentStock)
        {
            try
            {
                // Check if notification already exists (unread)
                string checkQuery = @"
                    SELECT COUNT(*) 
                    FROM StockNotifications 
                    WHERE ProductID = @ProductID 
                    AND IsRead = false";

                using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@ProductID", productId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"   ⚠️ Notification already exists for: {productName}");
                        return;
                    }
                }

                // Create new notification
                string notifType = currentStock == 0 ? "OUT_OF_STOCK" : "CRITICAL_STOCK";

                string insertQuery = @"
                    INSERT INTO StockNotifications 
                    (ProductID, ProductName, Barcode, CurrentStock, NotificationType, IsRead, CreatedAt)
                    VALUES (@ProductID, @ProductName, @Barcode, @Stock, @Type, false, NOW())";

                using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@ProductID", productId);
                    insertCmd.Parameters.AddWithValue("@ProductName", productName);
                    insertCmd.Parameters.AddWithValue("@Barcode", barcode ?? "");
                    insertCmd.Parameters.AddWithValue("@Stock", currentStock);
                    insertCmd.Parameters.AddWithValue("@Type", notifType);

                    insertCmd.ExecuteNonQuery();
                    System.Diagnostics.Debug.WriteLine($"   ✅ Created {notifType} notification for: {productName}");

                    // ✅ LOG NOTIFICATION CREATION
                    AuditLogger.Log(
                        "CREATE_NOTIFICATION",
                        "StockNotifications",
                        productId,
                        $"Stock alert created: {productName} | Type: {notifType} | Stock: {currentStock}"
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"   ❌ Create error for {productName}: {ex.Message}");
            }
        }

        /// <summary>
        /// ✅ Get unread notification count
        /// </summary>
        public static int GetUnreadCount()
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null)
                    {
                        System.Diagnostics.Debug.WriteLine("❌ [NOTIF COUNT] Connection is NULL!");
                        return 0;
                    }

                    string query = "SELECT COUNT(*) FROM StockNotifications WHERE IsRead = false";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        System.Diagnostics.Debug.WriteLine($"✅ [NOTIF COUNT] Unread: {count}");
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ [NOTIF COUNT] Error: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// ✅ Get all unread notifications
        /// </summary>
        public static List<StockNotification> GetUnreadNotifications()
        {
            var notifications = new List<StockNotification>();

            try
            {
                System.Diagnostics.Debug.WriteLine("=== [GET NOTIFICATIONS] Starting ===");

                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null)
                    {
                        System.Diagnostics.Debug.WriteLine("❌ [GET NOTIFICATIONS] Connection is NULL!");
                        return notifications;
                    }

                    string query = @"
                        SELECT NotificationID, ProductID, ProductName, Barcode, 
                               CurrentStock, NotificationType, IsRead, CreatedAt
                        FROM StockNotifications 
                        WHERE IsRead = false
                        ORDER BY CreatedAt DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notifications.Add(new StockNotification
                            {
                                NotificationID = Convert.ToInt32(reader["NotificationID"]),
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                ProductName = reader["ProductName"].ToString(),
                                Barcode = reader["Barcode"]?.ToString() ?? "",
                                CurrentStock = Convert.ToInt32(reader["CurrentStock"]),
                                NotificationType = reader["NotificationType"].ToString(),
                                IsRead = Convert.ToBoolean(reader["IsRead"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            });
                        }
                    }

                    System.Diagnostics.Debug.WriteLine($"✅ [GET NOTIFICATIONS] Found: {notifications.Count}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ [GET NOTIFICATIONS] Error: {ex.Message}");
            }

            return notifications;
        }

        /// <summary>
        /// ✅ Mark notification as read
        /// </summary>
        public static void MarkAsRead(int notificationId)
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return;

                    string query = "UPDATE StockNotifications SET IsRead = true WHERE NotificationID = @ID";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", notificationId);
                        cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"✅ [MARK READ] Notification {notificationId} marked as read");

                        // ✅ LOG NOTIFICATION READ
                        AuditLogger.Log(
                            "READ_NOTIFICATION",
                            "StockNotifications",
                            notificationId,
                            $"User viewed notification #{notificationId}"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ [MARK READ] Error: {ex.Message}");
            }
        }

        /// <summary>
        /// ✅ Mark all notifications as read
        /// </summary>
        public static void MarkAllAsRead()
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return;

                    string query = "UPDATE StockNotifications SET IsRead = true WHERE IsRead = false";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        int affected = cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"✅ [MARK ALL READ] {affected} notifications marked as read");

                        // ✅ LOG MARK ALL READ
                        AuditLogger.Log(
                            "MARK_ALL_READ",
                            "StockNotifications",
                            null,
                            $"User marked {affected} notifications as read"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ [MARK ALL READ] Error: {ex.Message}");
            }
        }

        /// <summary>
        /// ✅ Clear old read notifications (older than 30 days)
        /// </summary>
        public static void ClearOldNotifications()
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return;

                    string query = @"
                        DELETE FROM StockNotifications 
                        WHERE IsRead = true 
                        AND CreatedAt < NOW() - INTERVAL '30 days'";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        int deleted = cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"✅ [CLEAR OLD] {deleted} old notifications deleted");

                        // ✅ LOG CLEANUP
                        if (deleted > 0)
                        {
                            AuditLogger.Log(
                                "DELETE_OLD_NOTIFICATIONS",
                                "StockNotifications",
                                null,
                                $"System cleaned up {deleted} old notifications (>30 days)"
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ [CLEAR OLD] Error: {ex.Message}");
            }
        }
    }
}