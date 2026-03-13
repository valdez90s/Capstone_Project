using CrystalDecisions.CrystalReports.Engine;
using Npgsql; // ✅ PostgreSQL provider
using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.CrystalReport.Forms
{
    public partial class DamageProductReportForm : Form
    {
        private ReportDocument _currentReport; // ✅ Para sa proper disposal

        public DamageProductReportForm()
        {
            InitializeComponent();
        }

        private DataTable GetDamagedProductDataSet()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                string query = @"
                    SELECT 
                        sa.ProductID,
                        sa.Barcode,
                        sa.ProductName,
                        c.CategoryName,
                        SUM(sa.QuantityAdjusted) AS TotalDamaged
                    FROM StockAdjustments sa
                    LEFT JOIN Products p ON sa.ProductID = p.ProductID
                    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                    WHERE sa.AdjustmentType = 'DAMAGED'
                    GROUP BY sa.ProductID, sa.Barcode, sa.ProductName, c.CategoryName
                    HAVING SUM(sa.QuantityAdjusted) > 0
                    ORDER BY sa.ProductName ASC;";

                using (var cmd = new NpgsqlCommand(query, conn)) // ✅ NpgsqlCommand
                using (var adapter = new NpgsqlDataAdapter(cmd)) // ✅ NpgsqlDataAdapter
                {
                    DataTable dt = new DataTable("DamagedProducts");
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        private void DamageProductReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                // ✅ Get data first
                DataTable dt = GetDamagedProductDataSet();

                // ✅ Check if data exists
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No damaged products data found.",
                                    "No Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                // ✅ Build report path
                string reportPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "CrystalReport",
                    "DamageProductsReport.rpt"
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
                MessageBox.Show("Error loading Damage Product report: " + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
        private void DamageProductReportForm_FormClosing(object sender, FormClosingEventArgs e)
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