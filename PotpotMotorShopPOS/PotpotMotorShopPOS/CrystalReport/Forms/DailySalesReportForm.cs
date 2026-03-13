using CrystalDecisions.CrystalReports.Engine;
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
using PotpotMotorShopPOS.Helpers;

namespace PotpotMotorShopPOS.CrystalReport.Forms
{
    public partial class DailySalesReportForm : Form
    {
        public DailySalesReportForm()
        {
            InitializeComponent();
        }

        private void DailySalesReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                string reportPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "CrystalReport",
                    "DailySalesReport.rpt"
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
                ReportDocument rpt = new ReportDocument();
                rpt.Load(reportPath);

                // Get data
                DataSet ds = GetDailySalesDataSet();
                if (ds == null || ds.Tables["SalesTransaction"].Rows.Count == 0)
                {
                    MessageBox.Show("No sales data to display in the report.",
                                    "No Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Bind dataset
                rpt.SetDataSource(ds);

                // Assign to viewer
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Daily Sales report: " + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private DataSet GetDailySalesDataSet()
        {
            DataSet ds = new DataSet("DailySalesDataSet");

            // Create SalesTransaction table
            DataTable dtSales = new DataTable("SalesTransaction");
            dtSales.Columns.Add("InvoiceNo", typeof(string));
            dtSales.Columns.Add("Time", typeof(string));
            dtSales.Columns.Add("CustomerName", typeof(string));
            dtSales.Columns.Add("Items", typeof(string));
            dtSales.Columns.Add("Quantity", typeof(int));
            dtSales.Columns.Add("Subtotal", typeof(decimal));
            dtSales.Columns.Add("Discount", typeof(decimal));
            dtSales.Columns.Add("PaymentMethod", typeof(string));
            dtSales.Columns.Add("Cashier", typeof(string));

            // Create Summary table
            DataTable dtSummary = new DataTable("Summary");
            dtSummary.Columns.Add("ReportDate", typeof(string));
            dtSummary.Columns.Add("TotalSales", typeof(decimal));
            dtSummary.Columns.Add("TotalTransactions", typeof(int));
            dtSummary.Columns.Add("TotalItemsSold", typeof(int));

            decimal totalSales = 0m;
            int totalTransactions = 0;
            int totalItemsSold = 0;

            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
            {
                // ✅ PostgreSQL syntax: STRING_AGG instead of GROUP_CONCAT
                string query = @"
                    SELECT 
                        t.InvoiceNo,
                        t.CreatedAt,
                        t.CustomerName,
                        t.Subtotal,
                        t.DiscountAmount,
                        t.PaymentMethod,
                        t.CreatedBy,
                        (SELECT STRING_AGG(ti.ItemName, ', ') 
                         FROM POS_TransactionItems ti 
                         WHERE ti.TransactionID = t.TransactionID) as Items,
                        (SELECT SUM(ti.Quantity) 
                         FROM POS_TransactionItems ti 
                         WHERE ti.TransactionID = t.TransactionID) as TotalQty
                    FROM POS_Transactions t
                    WHERE t.CreatedAt::date = CURRENT_DATE
                    ORDER BY t.CreatedAt DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DataRow row = dtSales.NewRow();
                        row["InvoiceNo"] = reader["InvoiceNo"].ToString();

                        DateTime createdAt = Convert.ToDateTime(reader["CreatedAt"]);
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

                        row["PaymentMethod"] = reader["PaymentMethod"].ToString();
                        row["Cashier"] = reader["CreatedBy"].ToString();

                        dtSales.Rows.Add(row);

                        // Accumulate totals
                        totalSales += subtotal;
                        totalTransactions++;
                        totalItemsSold += qty;
                    }
                }
            }

            // Add summary
            DataRow summaryRow = dtSummary.NewRow();
            summaryRow["ReportDate"] = DateTime.Today.ToString("MMMM dd, yyyy (dddd)");
            summaryRow["TotalSales"] = totalSales;
            summaryRow["TotalTransactions"] = totalTransactions;
            summaryRow["TotalItemsSold"] = totalItemsSold;
            dtSummary.Rows.Add(summaryRow);

            ds.Tables.Add(dtSales);
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

        // ✅ Memory management
        private void DailySalesReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose report properly to prevent memory leaks
            if (crystalReportViewer1.ReportSource != null)
            {
                ReportDocument report = (ReportDocument)crystalReportViewer1.ReportSource;
                report.Close();
                report.Dispose();
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}