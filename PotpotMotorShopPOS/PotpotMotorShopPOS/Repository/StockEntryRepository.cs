using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Repository
{
    internal class StockEntryRepository
    {
        public DataTable GetStockInHistory(DateTime fromDate, DateTime toDate, string supplierFilter = "")
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                // ✅ PostgreSQL syntax: CAST(EntryDate AS DATE) or EntryDate::date
                string query = @"
                    SELECT 
                        StockEntryID,
                        ReferenceNo,
                        SupplierName,
                        ProductCode,
                        ProductName,
                        Quantity,
                        Price AS UnitCost,
                        Total,
                        EntryDate,
                        CreatedBy
                    FROM StockEntries
                    WHERE EntryDate::date BETWEEN @fromDate AND @toDate";

                if (!string.IsNullOrEmpty(supplierFilter))
                {
                    query += " AND UPPER(SupplierName) LIKE UPPER(@supplier)";
                }

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@toDate", toDate.Date);

                    if (!string.IsNullOrEmpty(supplierFilter))
                        cmd.Parameters.AddWithValue("@supplier", "%" + supplierFilter.Trim() + "%");

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public decimal GetStockInHistoryTotal(DateTime fromDate, DateTime toDate, string supplierFilter = "")
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                // ✅ PostgreSQL syntax
                string query = @"
                    SELECT COALESCE(SUM(Total), 0) 
                    FROM StockEntries
                    WHERE EntryDate::date BETWEEN @fromDate AND @toDate";

                if (!string.IsNullOrEmpty(supplierFilter))
                {
                    query += " AND UPPER(SupplierName) LIKE UPPER(@supplier)";
                }

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@toDate", toDate.Date);

                    if (!string.IsNullOrEmpty(supplierFilter))
                        cmd.Parameters.AddWithValue("@supplier", "%" + supplierFilter.Trim() + "%");

                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }
    }
}