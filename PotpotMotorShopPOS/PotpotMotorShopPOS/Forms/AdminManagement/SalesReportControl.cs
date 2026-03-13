using PotpotMotorShopPOS.CrystalReport.Forms;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class SalesReportControl : UserControl
    {
        public SalesReportControl()
        {
            InitializeComponent();
        }

        private void SalesReportControl_Load(object sender, EventArgs e)
        {
            InitializeSalesHistoryTab();
            InitializeTopSellingProductsTab();
        }

        private void InitializeSalesHistoryTab()
        {
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;
            LoadUsers();
            InitializeSalesHistoryColumns();
            DataGridHelper.ApplyStyle(dgvSalesHistory);
            LoadSalesHistory();
        }

        private void InitializeSalesHistoryColumns()
        {
            if (dgvSalesHistory.Columns.Count > 0)
                return;

            dgvSalesHistory.Columns.Add("colInvoiceNo", "Invoice No");
            dgvSalesHistory.Columns.Add("colDate", "Date");
            dgvSalesHistory.Columns.Add("colTime", "Time");
            dgvSalesHistory.Columns.Add("colCustomer", "Customer");
            dgvSalesHistory.Columns.Add("colItems", "Items");
            dgvSalesHistory.Columns.Add("colQty", "Qty");
            dgvSalesHistory.Columns.Add("colSubtotal", "Subtotal");
            dgvSalesHistory.Columns.Add("colDiscount", "Discount");
            dgvSalesHistory.Columns.Add("colTotal", "Total");
            dgvSalesHistory.Columns.Add("colPayment", "Payment");
            dgvSalesHistory.Columns.Add("colCashier", "Cashier");

            dgvSalesHistory.ReadOnly = true;
            dgvSalesHistory.AllowUserToAddRows = false;
            dgvSalesHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadUsers()
        {
            try
            {
                cmbUser.Items.Clear();
                cmbUser.Items.Add("All Users");

                using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
                {
                    if (conn == null) return;
                    string query = "SELECT DISTINCT CreatedBy FROM POS_Transactions ORDER BY CreatedBy";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string user = reader["CreatedBy"].ToString();
                            if (!string.IsNullOrEmpty(user))
                            {
                                cmbUser.Items.Add(user);
                            }
                        }
                    }
                }

                cmbUser.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSalesHistory()
        {
            try
            {
                if (dgvSalesHistory.Columns.Count == 0)
                {
                    InitializeSalesHistoryColumns();
                }

                dgvSalesHistory.Rows.Clear();

                DateTime dateFrom = dtpFrom.Value.Date;
                DateTime dateTo = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);
                string selectedUser = cmbUser.SelectedItem?.ToString() ?? "All Users";

                decimal totalSales = 0m;
                int totalTransactions = 0;
                int totalItemsSold = 0;

                using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
                {
                    if (conn == null) return;
                    // ✅ PostgreSQL syntax - using STRING_AGG instead of GROUP_CONCAT
                    string query = @"
                        SELECT 
                            t.TransactionID,
                            t.InvoiceNo,
                            t.CustomerName,
                            t.PaymentMethod,
                            t.Subtotal,
                            t.DiscountAmount,
                            t.TotalAmount,
                            t.CreatedBy,
                            t.CreatedAt,
                            (SELECT STRING_AGG(ti.ItemName, ', ') 
                             FROM POS_TransactionItems ti 
                             WHERE ti.TransactionID = t.TransactionID) as ItemNames,
                            (SELECT SUM(ti.Quantity) 
                             FROM POS_TransactionItems ti 
                             WHERE ti.TransactionID = t.TransactionID) as TotalQty
                        FROM POS_Transactions t
                        WHERE t.CreatedAt::date BETWEEN @DateFrom AND @DateTo";

                    if (selectedUser != "All Users")
                    {
                        query += " AND t.CreatedBy = @CreatedBy";
                    }

                    query += " ORDER BY t.CreatedAt DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", dateTo);

                        if (selectedUser != "All Users")
                        {
                            cmd.Parameters.AddWithValue("@CreatedBy", selectedUser);
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string invoiceNo = reader["InvoiceNo"].ToString();
                                string customerName = reader["CustomerName"].ToString();
                                string paymentMethod = reader["PaymentMethod"].ToString();
                                decimal subtotal = Convert.ToDecimal(reader["Subtotal"]);
                                decimal discountAmount = Convert.ToDecimal(reader["DiscountAmount"]);
                                decimal totalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                                string createdBy = reader["CreatedBy"].ToString();
                                DateTime createdAt = Convert.ToDateTime(reader["CreatedAt"]);
                                string itemNames = reader["ItemNames"]?.ToString() ?? "";
                                int itemCount = reader["TotalQty"] != DBNull.Value ?
                                    Convert.ToInt32(reader["TotalQty"]) : 0;

                                dgvSalesHistory.Rows.Add(
                                    invoiceNo,
                                    createdAt.ToString("MMM dd, yyyy"),
                                    createdAt.ToString("hh:mm tt"),
                                    customerName,
                                    itemNames,
                                    itemCount,
                                    subtotal.ToString("N2"),
                                    discountAmount > 0 ? discountAmount.ToString("N2") : "0.00",
                                    totalAmount.ToString("N2"),
                                    paymentMethod,
                                    createdBy
                                );

                                totalSales += totalAmount;
                                totalTransactions++;
                                totalItemsSold += itemCount;
                            }
                        }
                    }
                }

                lblTotalSales.Text = $"Total Sales: ₱{totalSales:N2}";
                lblTotalTransactions.Text = $"Total Transactions: {totalTransactions}";
                lblTotalItems.Text = $"Total Items Sold: {totalItemsSold}";
                lblDateRange.Text = $"Period: {dateFrom:MMM dd, yyyy} - {dateTo:MMM dd, yyyy}";

                lblTotalSales.ForeColor = Color.Green;
                lblTotalTransactions.ForeColor = Color.Blue;
                lblTotalItems.ForeColor = Color.DarkOrange;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales history:\n\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (lblTotalSales != null)
                {
                    lblTotalSales.Text = "Total Sales: Error";
                    lblTotalSales.ForeColor = Color.Red;
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("'Date From' cannot be later than 'Date To'.",
                    "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadSalesHistory();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;
            cmbUser.SelectedIndex = 0;

            LoadSalesHistory();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalesHistory.Rows.Count == 0)
                {
                    MessageBox.Show("No data to print.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SalesHistoryReportForm reportForm = new SalesHistoryReportForm(
                    dtpFrom.Value,
                    dtpTo.Value,
                    cmbUser.SelectedItem?.ToString() ?? "All Users"
                );
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report:\n\n{ex.Message}",
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeTopSellingProductsTab()
        {
            dtpTopFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTopTo.Value = DateTime.Today;

            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("By Quantity Sold");
            cmbFilter.Items.Add("By Total Revenue");
            cmbFilter.SelectedIndex = 0;

            InitializeTopSellingColumns();
            DataGridHelper.ApplyStyle(dgvTopSellingProduct);
            LoadTopSellingProducts();
        }

        private void InitializeTopSellingColumns()
        {
            if (dgvTopSellingProduct.Columns.Count > 0)
                return;

            dgvTopSellingProduct.Columns.Add("colRank", "Rank");
            dgvTopSellingProduct.Columns.Add("colProductName", "Product Name");
            dgvTopSellingProduct.Columns.Add("colBarcode", "Barcode");
            dgvTopSellingProduct.Columns.Add("colCategory", "Category");
            dgvTopSellingProduct.Columns.Add("colQuantitySold", "Qty Sold");
            dgvTopSellingProduct.Columns.Add("colUnitPrice", "Unit Price");
            dgvTopSellingProduct.Columns.Add("colTotalRevenue", "Total Revenue");
            dgvTopSellingProduct.Columns.Add("colTransactions", "Transactions");

            dgvTopSellingProduct.ReadOnly = true;
            dgvTopSellingProduct.AllowUserToAddRows = false;
            dgvTopSellingProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadTopSellingProducts()
        {
            try
            {
                if (dgvTopSellingProduct.Columns.Count == 0)
                {
                    InitializeTopSellingColumns();
                }

                dgvTopSellingProduct.Rows.Clear();

                DateTime dateFrom = dtpTopFrom.Value.Date;
                DateTime dateTo = dtpTopTo.Value.Date.AddDays(1).AddSeconds(-1);
                string filterType = cmbFilter.SelectedItem?.ToString() ?? "By Quantity Sold";

                using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
                {
                    if (conn == null) return;
                    string orderBy = filterType == "By Quantity Sold"
                        ? "TotalQuantity DESC"
                        : "TotalRevenue DESC";

                    // ✅ PostgreSQL syntax - using ::date cast
                    string query = $@"
                    SELECT 
                        p.ProductID,
                        p.ProductName,
                        p.Barcode,
                        c.CategoryName,
                        SUM(ti.Quantity) as TotalQuantity,
                        AVG(ti.UnitPrice) as AvgUnitPrice,
                        SUM(ti.Subtotal) as TotalRevenue,
                        COUNT(DISTINCT ti.TransactionID) as TransactionCount
                    FROM POS_TransactionItems ti
                    INNER JOIN Products p ON ti.ItemID = p.ProductID
                    INNER JOIN Categories c ON p.CategoryID = c.CategoryID
                    INNER JOIN POS_Transactions t ON ti.TransactionID = t.TransactionID
                    WHERE ti.ItemType = 'Product'
                      AND t.CreatedAt::date BETWEEN @DateFrom AND @DateTo
                    GROUP BY p.ProductID, p.ProductName, p.Barcode, c.CategoryName
                    ORDER BY {orderBy}
                    LIMIT 50";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", dateTo);

                        using (var reader = cmd.ExecuteReader())
                        {
                            int rank = 1;
                            decimal grandTotalRevenue = 0m;
                            int grandTotalQty = 0;

                            while (reader.Read())
                            {
                                string productName = reader["ProductName"].ToString();
                                string barcode = reader["Barcode"]?.ToString() ?? "N/A";
                                string category = reader["CategoryName"].ToString();
                                int qtySold = Convert.ToInt32(reader["TotalQuantity"]);
                                decimal avgPrice = Convert.ToDecimal(reader["AvgUnitPrice"]);
                                decimal totalRevenue = Convert.ToDecimal(reader["TotalRevenue"]);
                                int txnCount = Convert.ToInt32(reader["TransactionCount"]);

                                dgvTopSellingProduct.Rows.Add(
                                    rank++,
                                    productName,
                                    barcode,
                                    category,
                                    qtySold,
                                    avgPrice.ToString("N2"),
                                    totalRevenue.ToString("N2"),
                                    txnCount
                                );

                                grandTotalRevenue += totalRevenue;
                                grandTotalQty += qtySold;
                            }

                            lblTopTotalRevenue.Text = $"Total Revenue: ₱{grandTotalRevenue:N2}";
                            lblTopTotalQty.Text = $"Total Quantity Sold: {grandTotalQty}";
                            lblTopDateRange.Text = $"Period: {dateFrom:MMM dd, yyyy} - {dateTo:MMM dd, yyyy}";
                            lblTopFilterType.Text = $"Sorted by: {filterType}";

                            lblTopTotalRevenue.ForeColor = Color.Green;
                            lblTopTotalQty.ForeColor = Color.Blue;

                            System.Diagnostics.Debug.WriteLine(
                                $"[TopSelling] Loaded {rank - 1} products, Total Revenue: ₱{grandTotalRevenue:N2}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading top selling products:\n\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                System.Diagnostics.Debug.WriteLine($"[TopSelling] Error: {ex.Message}");

                if (lblTopTotalRevenue != null)
                {
                    lblTopTotalRevenue.Text = "Total Revenue: Error";
                    lblTopTotalRevenue.ForeColor = Color.Red;
                }
            }
        }

        private void btnPrintTopSellingProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTopSellingProduct.Rows.Count == 0)
                {
                    MessageBox.Show("No data to print.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                TopSellingProductsReportForm reportForm = new TopSellingProductsReportForm(
                    dtpTopFrom.Value,
                    dtpTopTo.Value,
                    cmbFilter.SelectedItem?.ToString() ?? "By Quantity Sold"
                );
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report:\n\n{ex.Message}",
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            dtpTopFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTopTo.Value = DateTime.Today;
            cmbFilter.SelectedIndex = 0;

            LoadTopSellingProducts();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (dtpTopFrom.Value.Date > dtpTopTo.Value.Date)
            {
                MessageBox.Show("'Date From' cannot be later than 'Date To'.",
                    "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadTopSellingProducts();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTopSellingProducts();
        }

        private void dgvSalesHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}