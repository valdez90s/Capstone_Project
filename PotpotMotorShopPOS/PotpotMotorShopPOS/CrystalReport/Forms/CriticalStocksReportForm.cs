using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Npgsql; // ✅ PostgreSQL provider
using PotpotMotorShopPOS.Helpers;

namespace PotpotMotorShopPOS.CrystalReport.Forms
{
    public partial class CriticalStocksReportForm : Form
    {
        private ReportDocument _currentReport; // ✅ Para sa proper disposal

        public CriticalStocksReportForm()
        {
            InitializeComponent();
        }

        private void CriticalStocksReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                // ✅ Build the path dynamically
                string reportPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "CrystalReport",
                    "CriticalStocksReport.rpt"
                );

                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show($"Missing report file:\n{reportPath}",
                                    "Report Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // Get data first
                DataTable dt = GetCriticalStocksData();
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No critical stocks data found.",
                                    "No Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                // Load report
                _currentReport = new ReportDocument();
                _currentReport.Load(reportPath);

                // Bind dataset
                _currentReport.SetDataSource(dt);

                // Assign to viewer
                crystalReportViewer1.ReportSource = _currentReport;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Critical Stocks report: " + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private DataTable GetCriticalStocksData()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
            {
                string query = @"
                SELECT 
                    p.ProductID,
                    p.ProductName,
                    p.Barcode,
                    p.Price,
                    p.Quantity,
                    p.ReOrderLevel,
                    c.CategoryName
                FROM Products p
                INNER JOIN Categories c ON p.CategoryID = c.CategoryID
                WHERE p.Quantity <= p.ReOrderLevel
                ORDER BY p.Quantity ASC;";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    // ✅ Table name must match the one inside CriticalStockDataSet.xsd
                    DataTable dt = new DataTable("CriticalStocks");
                    adapter.Fill(dt);
                    return dt;
                }
            }
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

        // ✅ Proper cleanup on form closing
        private void CriticalStocksReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: leave empty or remove if not needed
        }
    }
}