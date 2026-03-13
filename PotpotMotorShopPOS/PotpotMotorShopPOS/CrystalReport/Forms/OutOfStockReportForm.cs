using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Npgsql; // ✅ PostgreSQL provider
using PotpotMotorShopPOS.Helpers;

namespace PotpotMotorShopPOS.CrystalReport.Forms
{
    public partial class OutOfStockReportForm : Form
    {
        private ReportDocument _currentReport; // ✅ Para sa proper disposal

        public OutOfStockReportForm()
        {
            InitializeComponent();
        }

        private void OutOfStockReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                // ✅ Get data first
                DataTable dt = GetOutOfStockData();

                // ✅ Check if data exists
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No out of stock products found.",
                                    "No Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                // ✅ Build the path dynamically
                string reportPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "CrystalReport",
                    "OutOfStockReport.rpt"
                );

                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"Missing report file:\n{reportPath}",
                                    "Report Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // ✅ Load and configure report
                _currentReport = new ReportDocument();
                _currentReport.Load(reportPath);
                _currentReport.SetDataSource(dt);

                // ✅ Display report
                crystalReportViewer1.ReportSource = _currentReport;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Out of Stock report: " + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private DataTable GetOutOfStockData()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
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
                    WHERE p.Quantity = 0
                    ORDER BY p.ProductName ASC;";

                using (var cmd = new NpgsqlCommand(query, conn)) // ✅ NpgsqlCommand
                using (var adapter = new NpgsqlDataAdapter(cmd)) // ✅ NpgsqlDataAdapter
                {
                    // ✅ Table name must match the one inside OutOfStockDataSet.xsd
                    DataTable dt = new DataTable("OutOfStock");
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
        private void OutOfStockReportForm_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}