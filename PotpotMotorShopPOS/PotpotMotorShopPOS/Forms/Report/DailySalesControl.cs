using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using PotpotMotorShopPOS.CrystalReport.Forms;
using PotpotMotorShopPOS.Forms.POS;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Forms.Report
{
    public partial class DailySalesControl : UserControl
    {
        private Timer refreshTimer;
        private DateTime currentDate;

        public DailySalesControl()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
        }

        private void DailySalesControl_Load(object sender, EventArgs e)
        {
            InitializeDataGridColumns();
            LoadTodaySales();

            // Setup auto-refresh timer (every 30 seconds)
            refreshTimer = new Timer();
            refreshTimer.Interval = 30000; // 30 seconds
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();

            // Apply DataGridView styling
            DataGridHelper.ApplyStyle(dgvSalesToday);
        }

        private void InitializeDataGridColumns()
        {
            if (dgvSalesToday.Columns.Count > 0)
                return;

            dgvSalesToday.Columns.Add("colInvoiceNo", "Invoice No");
            dgvSalesToday.Columns.Add("colTime", "Time");
            dgvSalesToday.Columns.Add("colCustomer", "Customer");
            dgvSalesToday.Columns.Add("colItems", "Items");
            dgvSalesToday.Columns.Add("colQty", "Qty");
            dgvSalesToday.Columns.Add("colSubtotal", "Subtotal");
            dgvSalesToday.Columns.Add("colDiscount", "Discount");
            dgvSalesToday.Columns.Add("colPayment", "Payment");
            dgvSalesToday.Columns.Add("colCashier", "Cashier");

            // Set column widths
            dgvSalesToday.Columns["colInvoiceNo"].Width = 100;
            dgvSalesToday.Columns["colTime"].Width = 80;
            dgvSalesToday.Columns["colCustomer"].Width = 150;
            dgvSalesToday.Columns["colItems"].Width = 200;
            dgvSalesToday.Columns["colQty"].Width = 50;
            dgvSalesToday.Columns["colSubtotal"].Width = 100;
            dgvSalesToday.Columns["colDiscount"].Width = 80;
            dgvSalesToday.Columns["colPayment"].Width = 80;
            dgvSalesToday.Columns["colCashier"].Width = 100;

            // Set alignment
            dgvSalesToday.Columns["colQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalesToday.Columns["colSubtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSalesToday.Columns["colDiscount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Check if date has changed (past midnight)
            if (DateTime.Today != currentDate)
            {
                currentDate = DateTime.Today;
                System.Diagnostics.Debug.WriteLine("[SalesToday] Date changed - Refreshing data");
            }

            LoadTodaySales();
        }

        private void LoadTodaySales()
        {
            try
            {
                if (dgvSalesToday.Columns.Count == 0)
                {
                    InitializeDataGridColumns();
                }

                dgvSalesToday.Rows.Clear();

                // Update header with current date
                lblDateHeader.Text = $"Sales for {DateTime.Today:MMMM dd, yyyy (dddd)}";

                decimal totalSales = 0m;
                int totalTransactions = 0;
                int totalItemsSold = 0;

                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) // ✅ ADD THIS CHECK
                    {
                        // ✅ Show error state in UI
                        lblTotalSales.Text = "Total Sales: No Connection";
                        lblTotalSales.ForeColor = Color.Red;
                        lblTotalTransactions.Text = "Total Transactions: 0";
                        lblTotalItems.Text = "Total Items Sold: 0";
                        return;
                    }

                    // ✅ PostgreSQL syntax: STRING_AGG instead of GROUP_CONCAT
                    string query = @"
            SELECT 
                t.TransactionID,
                t.InvoiceNo,
                t.CustomerName,
                t.PaymentMethod,
                t.Subtotal,
                t.DiscountAmount,
                t.CreatedBy,
                t.CreatedAt,
                (SELECT STRING_AGG(ti.ItemName, ', ') 
                 FROM POS_TransactionItems ti 
                 WHERE ti.TransactionID = t.TransactionID) as ItemNames,
                (SELECT SUM(ti.Quantity) 
                 FROM POS_TransactionItems ti 
                 WHERE ti.TransactionID = t.TransactionID) as TotalQty
            FROM POS_Transactions t
            WHERE t.CreatedAt::date = CURRENT_DATE
            ORDER BY t.CreatedAt DESC;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string invoiceNo = reader["InvoiceNo"].ToString();
                            string customerName = reader["CustomerName"].ToString();
                            string paymentMethod = reader["PaymentMethod"].ToString();
                            decimal subtotal = Convert.ToDecimal(reader["Subtotal"]);
                            decimal discountAmount = Convert.ToDecimal(reader["DiscountAmount"]);
                            string createdBy = reader["CreatedBy"].ToString();
                            DateTime createdAt = Convert.ToDateTime(reader["CreatedAt"]);
                            string itemNames = reader["ItemNames"]?.ToString() ?? "";
                            int itemCount = reader["TotalQty"] != DBNull.Value ?
                                Convert.ToInt32(reader["TotalQty"]) : 0;

                            dgvSalesToday.Rows.Add(
                                invoiceNo,
                                createdAt.ToString("hh:mm tt"),
                                customerName,
                                itemNames,
                                itemCount,
                                subtotal.ToString("N2"),
                                discountAmount > 0 ? discountAmount.ToString("N2") : "0.00",
                                paymentMethod,
                                createdBy
                            );

                            totalSales += subtotal;
                            totalTransactions++;
                            totalItemsSold += itemCount;
                        }
                    }
                }

                // Update summary labels
                lblTotalSales.Text = $"Total Sales: ₱{totalSales:N2}";
                lblTotalTransactions.Text = $"Total Transactions: {totalTransactions}";
                lblTotalItems.Text = $"Total Items Sold: {totalItemsSold}";

                // Update label colors
                lblTotalSales.ForeColor = Color.Green;
                lblTotalTransactions.ForeColor = Color.Blue;
                lblTotalItems.ForeColor = Color.DarkOrange;

                System.Diagnostics.Debug.WriteLine(
                    $"[SalesToday] Loaded {totalTransactions} transactions, Total: ₱{totalSales:N2}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading today's sales:\n\n{ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                System.Diagnostics.Debug.WriteLine($"[SalesToday] Error: {ex.Message}");

                if (lblTotalSales != null)
                {
                    lblTotalSales.Text = "Total Sales: Error";
                    lblTotalSales.ForeColor = Color.Red;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTodaySales();
            MessageBox.Show("Sales data refreshed!", "Refresh",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DailySalesControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadTodaySales();
            }
        }

        private void lblTotalTransactions_Click(object sender, EventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }

            var parentForm = this.FindForm() as POSForm;
            if (parentForm != null)
            {
                parentForm.EnablePOSControls();
            }

            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void btnPrintDailysales_Click(object sender, EventArgs e)
        {
            try
            {
                DailySalesReportForm reportForm = new DailySalesReportForm();
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening report:\n\n{ex.Message}",
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSalesToday_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}