using System;
using System.Linq;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Repository
{
    public static class PosRepository
    {
        /// <summary>
        /// Saves a complete transaction with products and services aligned to schema.
        /// Duplicate items in the cart are merged before saving.
        /// </summary>
        public static long SaveTransaction(
            NpgsqlConnection conn,
            NpgsqlTransaction tran,
            string invoiceNo,
            string customerName,
            string paymentMethod,
            string referenceNo,
            decimal subtotal,
            decimal discountRate,
            decimal discountAmount,
            decimal netAmount,
            decimal vatableSales,
            decimal vatRate,
            decimal vatAmount,
            decimal totalAmount,
            decimal amountPaid,
            decimal change,
            string createdBy,
            DataGridView dgvCart)
        {
            // ===== MERGE DUPLICATE ITEMS =====
            var groupedItems = dgvCart.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .GroupBy(r => new
                {
                    ItemID = Convert.ToInt32(r.Cells["colProductId"].Value),
                    ItemType = r.Cells["colItemType"].Value?.ToString() ?? "Product"
                })
                .Select(g => new
                {
                    ItemID = g.Key.ItemID,
                    ItemType = g.Key.ItemType,
                    ItemName = g.First().Cells["colProductName"].Value.ToString(),
                    UnitPrice = Convert.ToDecimal(g.First().Cells["colUnitPrice"].Value),
                    Quantity = g.Sum(x => Convert.ToInt32(x.Cells["colQty"].Value)),
                    LineTotal = g.Sum(x => Convert.ToDecimal(x.Cells["colLineTotal"].Value))
                })
                .ToList();

            // ===== PRE-VALIDATION OF PRODUCTS STOCK =====
            foreach (var item in groupedItems)
            {
                if (item.ItemType == "Product")
                {
                    var cmdCheckStock = new NpgsqlCommand(
                        "SELECT Quantity FROM Products WHERE ProductID = @ProductID", conn, tran);
                    cmdCheckStock.Parameters.AddWithValue("@ProductID", item.ItemID);

                    object stockResult = cmdCheckStock.ExecuteScalar();
                    if (stockResult == null)
                        throw new InvalidOperationException(
                            $"Product '{item.ItemName}' (ID: {item.ItemID}) not found in inventory.");

                    int currentStock = Convert.ToInt32(stockResult);
                    if (item.Quantity > currentStock)
                        throw new InvalidOperationException(
                            $"Insufficient stock for '{item.ItemName}'. Requested: {item.Quantity}, Available: {currentStock}");
                }
            }

            // ===== 1️⃣ INSERT MAIN TRANSACTION =====
            // ✅ PostgreSQL uses RETURNING instead of last_insert_rowid()
            var cmdTxn = new NpgsqlCommand(@"
                INSERT INTO POS_Transactions (
                    InvoiceNo, CustomerName, Subtotal, 
                    DiscountRate, DiscountAmount, NetAmount,
                    VatableSales, VATRate, VATAmount, TotalAmount, 
                    PaymentMethod, AmountPaid, Change, ReferenceNo,
                    CreatedBy, CreatedAt
                ) VALUES (
                    @InvoiceNo, @CustomerName, @Subtotal,
                    @DiscountRate, @DiscountAmount, @NetAmount,
                    @VatableSales, @VATRate, @VATAmount, @TotalAmount,
                    @PaymentMethod, @AmountPaid, @Change, @ReferenceNo,
                    @CreatedBy, @CreatedAt
                )
                RETURNING TransactionID;", conn, tran);

            cmdTxn.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
            cmdTxn.Parameters.AddWithValue("@CustomerName", customerName ?? "");
            cmdTxn.Parameters.AddWithValue("@Subtotal", subtotal);
            cmdTxn.Parameters.AddWithValue("@DiscountRate", discountRate);
            cmdTxn.Parameters.AddWithValue("@DiscountAmount", discountAmount);
            cmdTxn.Parameters.AddWithValue("@NetAmount", netAmount);
            cmdTxn.Parameters.AddWithValue("@VatableSales", vatableSales);
            cmdTxn.Parameters.AddWithValue("@VATRate", vatRate);
            cmdTxn.Parameters.AddWithValue("@VATAmount", vatAmount);
            cmdTxn.Parameters.AddWithValue("@TotalAmount", totalAmount);
            cmdTxn.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
            cmdTxn.Parameters.AddWithValue("@AmountPaid", amountPaid);
            cmdTxn.Parameters.AddWithValue("@Change", change);
            cmdTxn.Parameters.AddWithValue("@ReferenceNo", referenceNo ?? "");
            cmdTxn.Parameters.AddWithValue("@CreatedBy", createdBy ?? "Unknown");
            cmdTxn.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

            long transactionId = Convert.ToInt64(cmdTxn.ExecuteScalar());

            // ===== 2️⃣ INSERT ITEMS INTO POS_TransactionItems, ProductDetails, ServiceDetails =====
            foreach (var item in groupedItems)
            {
                // -- Insert into POS_TransactionItems
                var cmdItem = new NpgsqlCommand(@"
                    INSERT INTO POS_TransactionItems (
                        TransactionID, ItemID, ItemName, ItemType, 
                        Quantity, UnitPrice, Subtotal, CreatedAt
                    ) VALUES (
                        @TransactionID, @ItemID, @ItemName, @ItemType,
                        @Quantity, @UnitPrice, @Subtotal, @CreatedAt
                    );", conn, tran);

                cmdItem.Parameters.AddWithValue("@TransactionID", transactionId);
                cmdItem.Parameters.AddWithValue("@ItemID", item.ItemID);
                cmdItem.Parameters.AddWithValue("@ItemName", item.ItemName);
                cmdItem.Parameters.AddWithValue("@ItemType", item.ItemType);
                cmdItem.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmdItem.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                cmdItem.Parameters.AddWithValue("@Subtotal", item.LineTotal);
                cmdItem.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                cmdItem.ExecuteNonQuery();

                if (item.ItemType == "Product")
                {
                    // -- Insert into POS_ProductDetails
                    var cmdProduct = new NpgsqlCommand(@"
                        INSERT INTO POS_ProductDetails (
                            TransactionID, ProductID, ProductName, 
                            UnitPrice, Quantity, LineTotal, CreatedAt
                        ) VALUES (
                            @TransactionID, @ProductID, @ProductName,
                            @UnitPrice, @Quantity, @LineTotal, @CreatedAt
                        );", conn, tran);

                    cmdProduct.Parameters.AddWithValue("@TransactionID", transactionId);
                    cmdProduct.Parameters.AddWithValue("@ProductID", item.ItemID);
                    cmdProduct.Parameters.AddWithValue("@ProductName", item.ItemName);
                    cmdProduct.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                    cmdProduct.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmdProduct.Parameters.AddWithValue("@LineTotal", item.LineTotal);
                    cmdProduct.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    cmdProduct.ExecuteNonQuery();

                    // -- Deduct stock safely
                    var cmdStock = new NpgsqlCommand(@"
                        UPDATE Products 
                        SET Quantity = Quantity - @Qty 
                        WHERE ProductID = @ProductID 
                        AND Quantity >= @Qty;", conn, tran);

                    cmdStock.Parameters.AddWithValue("@Qty", item.Quantity);
                    cmdStock.Parameters.AddWithValue("@ProductID", item.ItemID);

                    int rowsAffected = cmdStock.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new InvalidOperationException(
                            $"Failed to deduct stock for '{item.ItemName}'. Stock may have changed during transaction.");
                }
                else if (item.ItemType == "Service")
                {
                    // -- Insert into POS_ServiceDetails
                    var cmdService = new NpgsqlCommand(@"
                        INSERT INTO POS_ServiceDetails (
                            TransactionID, ServiceID, ServiceName, 
                            Price, Status, CreatedAt
                        ) VALUES (
                            @TransactionID, @ServiceID, @ServiceName,
                            @Price, 'Pending', @CreatedAt
                        );", conn, tran);

                    cmdService.Parameters.AddWithValue("@TransactionID", transactionId);
                    cmdService.Parameters.AddWithValue("@ServiceID", item.ItemID);
                    cmdService.Parameters.AddWithValue("@ServiceName", item.ItemName);
                    cmdService.Parameters.AddWithValue("@Price", item.UnitPrice);
                    cmdService.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    cmdService.ExecuteNonQuery();
                }
            }

            return transactionId;
        }

        /// <summary>
        /// Legacy method - redirects to new SaveTransaction
        /// Ensures parameter order is correct
        /// </summary>
        public static long SaveProductTransaction(
            NpgsqlConnection conn,
            NpgsqlTransaction tran,
            string invoiceNo,
            string customerName,
            string paymentMethod,
            string referenceNo,
            decimal subtotal,
            decimal discountRate,
            decimal discountAmount,
            decimal netAmount,
            decimal vatableSales,
            decimal vatRate,
            decimal vatAmount,
            decimal totalAmount,
            decimal amountPaid,
            decimal change,
            string createdBy,
            DataGridView dgvCart)
        {
            return SaveTransaction(
                conn, tran, invoiceNo, customerName, paymentMethod, referenceNo,
                subtotal, discountRate, discountAmount, netAmount,
                vatableSales, vatRate, vatAmount, totalAmount, amountPaid, change,
                createdBy, dgvCart
            );
        }
    }
}