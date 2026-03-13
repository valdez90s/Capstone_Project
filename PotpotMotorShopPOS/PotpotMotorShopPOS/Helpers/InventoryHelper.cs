using Npgsql; // ✅ PostgreSQL provider
using System;

namespace PotpotMotorShopPOS.Helpers
{
    public static class InventoryHelper
    {
        /// <summary>
        /// Get current stock of a product.
        /// </summary>
        public static int GetProductStock(int productId)
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
            using (var cmd = new NpgsqlCommand("SELECT Quantity FROM Products WHERE ProductID = @ProductID;", conn))
            {
                cmd.Parameters.AddWithValue("@ProductID", productId);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        /// <summary>
        /// Update stock by adding or subtracting quantity.
        /// Pass negative qtyDelta to decrement, positive to increment.
        /// </summary>
        public static void UpdateProductStock(NpgsqlConnection conn, NpgsqlTransaction tran, int productId, int qtyDelta, string updatedBy)
        {
            // ✅ PostgreSQL uses CURRENT_TIMESTAMP or NOW() for timestamps
            using (var cmd = new NpgsqlCommand(@"
                UPDATE Products
                SET Quantity = Quantity + @QtyDelta,
                    UpdatedAt = CURRENT_TIMESTAMP,
                    UpdatedBy = @User
                WHERE ProductID = @ProductID;", conn, tran))
            {
                cmd.Parameters.AddWithValue("@QtyDelta", qtyDelta);
                cmd.Parameters.AddWithValue("@User", updatedBy ?? "System");
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Update stock with explicit quantity (overwrite instead of delta).
        /// Useful for stock adjustments and corrections.
        /// </summary>
        public static void SetProductStock(NpgsqlConnection conn, NpgsqlTransaction tran, int productId, int newQuantity, string updatedBy)
        {
            using (var cmd = new NpgsqlCommand(@"
                UPDATE Products
                SET Quantity = @NewQuantity,
                    UpdatedAt = CURRENT_TIMESTAMP,
                    UpdatedBy = @User
                WHERE ProductID = @ProductID;", conn, tran))
            {
                cmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                cmd.Parameters.AddWithValue("@User", updatedBy ?? "System");
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Check if product has sufficient stock for a transaction.
        /// Returns true if stock is available, false otherwise.
        /// </summary>
        public static bool HasSufficientStock(int productId, int requiredQuantity)
        {
            int currentStock = GetProductStock(productId);
            return currentStock >= requiredQuantity;
        }

        /// <summary>
        /// Get product stock with product details (name, barcode, etc.).
        /// Returns null if product not found.
        /// </summary>
        public static ProductStockInfo GetProductStockInfo(int productId)
        {
            using (var conn = ServerDatabase.GetConnection())
            using (var cmd = new NpgsqlCommand(@"
                SELECT ProductID, ProductName, Barcode, Quantity, ReOrderLevel
                FROM Products 
                WHERE ProductID = @ProductID;", conn))
            {
                cmd.Parameters.AddWithValue("@ProductID", productId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ProductStockInfo
                        {
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            ProductName = reader["ProductName"].ToString(),
                            Barcode = reader["Barcode"]?.ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            ReOrderLevel = reader["ReOrderLevel"] != DBNull.Value
                                ? Convert.ToInt32(reader["ReOrderLevel"])
                                : 0
                        };
                    }
                }
            }

            return null;
        }
    }

    /// <summary>
    /// Helper class for product stock information.
    /// </summary>
    public class ProductStockInfo
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public int ReOrderLevel { get; set; }

        public bool IsCriticalStock => Quantity <= ReOrderLevel;
        public bool IsOutOfStock => Quantity <= 0;
    }
}