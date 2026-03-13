using CrystalDecisions.CrystalReports.Engine;
using Npgsql; // ✅ PostgreSQL provider
using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.CrystalReport.Forms
{
    public partial class SalesHistoryReportForm : Form
    {
        private DateTime dateFrom;
        private DateTime dateTo;
        private string filterUser;
        private ReportDocument _currentReport; // ✅ Para sa proper disposal

        public SalesHistoryReportForm()
        {
            InitializeComponent();
        }

        public SalesHistoryReportForm(DateTime from, DateTime to, string user)
        {
            InitializeComponent();
            this.dateFrom = from;
            this.dateTo = to;
            this.filterUser = user;
        }

        private void SalesHistoryReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Build the path dynamically
                string reportPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "CrystalReport",
                    "SalesHistoryReport.rpt"
                );

                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show($"Missing report file:\n{reportPath}",
                                    "Report Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // Load report
                _currentReport = new ReportDocument();
                _currentReport.Load(reportPath);

                // Get data
                DataSet ds = GetSalesHistoryDataSet();
                if (ds == null || ds.Tables["SalesHistory"].Rows.Count == 0)
                {
                    MessageBox.Show("No sales data to display in the report.",
                                    "No Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Bind dataset
                _currentReport.SetDataSource(ds);

                // Assign to viewer
                crystalReportViewer1.ReportSource = _currentReport;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Sales History report: " + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private DataSet GetSalesHistoryDataSet()
        {
            DataSet ds = new DataSet("SalesHistoryDataSet");

            // Create SalesHistory table
            DataTable dtHistory = new DataTable("SalesHistory");
            dtHistory.Columns.Add("InvoiceNo", typeof(string));
            dtHistory.Columns.Add("Date", typeof(string));
            dtHistory.Columns.Add("Time", typeof(string));
            dtHistory.Columns.Add("CustomerName", typeof(string));
            dtHistory.Columns.Add("Items", typeof(string));
            dtHistory.Columns.Add("Quantity", typeof(int));
            dtHistory.Columns.Add("Subtotal", typeof(decimal));
            dtHistory.Columns.Add("Discount", typeof(decimal));
            dtHistory.Columns.Add("Total", typeof(decimal));
            dtHistory.Columns.Add("PaymentMethod", typeof(string));
            dtHistory.Columns.Add("Cashier", typeof(string));

            // Create Summary table
            DataTable dtSummary = new DataTable("Summary");
            dtSummary.Columns.Add("DateFrom", typeof(string));
            dtSummary.Columns.Add("DateTo", typeof(string));
            dtSummary.Columns.Add("FilteredBy", typeof(string));
            dtSummary.Columns.Add("TotalSales", typeof(decimal));
            dtSummary.Columns.Add("TotalTransactions", typeof(int));
            dtSummary.Columns.Add("TotalItemsSold", typeof(int));

            decimal totalSales = 0m;
            int totalTransactions = 0;
            int totalItemsSold = 0;

            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                // ✅ PostgreSQL syntax: STRING_AGG instead of GROUP_CONCAT, DATE() casting
                string query = @"
                    SELECT 
                        t.InvoiceNo,
                        t.CreatedAt,
                        t.CustomerName,
                        t.Subtotal,
                        t.DiscountAmount,
                        t.TotalAmount,
                        t.PaymentMethod,
                        t.CreatedBy,
                        (SELECT STRING_AGG(ti.ItemName, ', ') 
                         FROM POS_TransactionItems ti 
                         WHERE ti.TransactionID = t.TransactionID) as Items,
                        (SELECT SUM(ti.Quantity) 
                         FROM POS_TransactionItems ti 
                         WHERE ti.TransactionID = t.TransactionID) as TotalQty
                    FROM POS_Transactions t
                    WHERE t.CreatedAt::date BETWEEN @DateFrom AND @DateTo";

                if (filterUser != "All Users")
                {
                    query += " AND t.CreatedBy = @CreatedBy";
                }

                query += " ORDER BY t.CreatedAt DESC";

                using (var cmd = new NpgsqlCommand(query, conn)) // ✅ NpgsqlCommand
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom.Date);
                    cmd.Parameters.AddWithValue("@DateTo", dateTo.Date);

                    if (filterUser != "All Users")
                    {
                        cmd.Parameters.AddWithValue("@CreatedBy", filterUser);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow row = dtHistory.NewRow();
                            row["InvoiceNo"] = reader["InvoiceNo"].ToString();

                            DateTime createdAt = Convert.ToDateTime(reader["CreatedAt"]);
                            row["Date"] = createdAt.ToString("MMM dd, yyyy");
                            row["Time"] = createdAt.ToString("hh:mm tt");

                            row["CustomerName"] = reader["CustomerName"].ToString();
                            row["Items"] = reader["Items"]?.ToString() ?? "";

                            int qty = reader["TotalQty"] != DBNull.Value ?
                                Convert.ToInt32(reader["TotalQty"]) : 0;
                            row["Quantity"] = qty;

                            decimal subtotal = Convert.ToDecimal(reader["Subtotal"]);
                            row["Subtotal"] = subtotal;

                            decimal discount = Convert.ToDecimal(reader["DiscountAmount"]);
                            row["Discount"] = discount;

                            decimal total = Convert.ToDecimal(reader["TotalAmount"]);
                            row["Total"] = total;

                            row["PaymentMethod"] = reader["PaymentMethod"].ToString();
                            row["Cashier"] = reader["CreatedBy"].ToString();

                            dtHistory.Rows.Add(row);

                            // Accumulate totals
                            totalSales += total;
                            totalTransactions++;
                            totalItemsSold += qty;
                        }
                    }
                }
            }

            // Add summary
            DataRow summaryRow = dtSummary.NewRow();
            summaryRow["DateFrom"] = dateFrom.ToString("MMMM dd, yyyy");
            summaryRow["DateTo"] = dateTo.ToString("MMMM dd, yyyy");
            summaryRow["FilteredBy"] = filterUser;
            summaryRow["TotalSales"] = totalSales;
            summaryRow["TotalTransactions"] = totalTransactions;
            summaryRow["TotalItemsSold"] = totalItemsSold;
            dtSummary.Rows.Add(summaryRow);

            ds.Tables.Add(dtHistory);
            ds.Tables.Add(dtSummary);

            return ds;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to close?",
                                "Confirm",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void SalesHistoryReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ✅ Improved disposal
            if (_currentReport != null)
            {
                _currentReport.Close();
                _currentReport.Dispose();
                _currentReport = null;
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            // Optional: leave empty or add custom logic
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}