using CrystalDecisions.CrystalReports.Engine;
using PotpotMotorShopPOS.DataSetFile;
using System;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.CrystalReport.Forms
{
    public partial class ReceiptViewerForm : Form
    {
        private ReportDocument _currentReport; // ✅ Para sa proper disposal

        // 🔹 This property must match your .xsd dataset
        public SalesReceiptDataSet ReceiptData { get; set; }

        public ReceiptViewerForm()
        {
            InitializeComponent();
        }

        private void ReceiptViewerForm_Load(object sender, EventArgs e)
        {
            try
            {
                // ✅ Validate data first
                if (ReceiptData == null || ReceiptData.Tables.Count == 0)
                {
                    MessageBox.Show("No data to display in the receipt.",
                                    "No Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Build report path
                string reportPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "CrystalReport",
                    "SalesReceipt.rpt"
                );

                if (!System.IO.File.Exists(reportPath))
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

                // 🔹 Bind the dataset
                _currentReport.SetDataSource(ReceiptData);

                // ✅ Display report
                crystalReportViewer1.ReportSource = _currentReport;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading receipt report: " + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // ✅ Proper cleanup on form closing
        private void ReceiptViewerForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}