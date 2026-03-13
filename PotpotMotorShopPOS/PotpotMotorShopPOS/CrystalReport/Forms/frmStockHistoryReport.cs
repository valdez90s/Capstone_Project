using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Data;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.CrystalReport.Forms
{
   
    public partial class frmStockHistoryReport : Form
    {
        private readonly DataTable _data;
        private readonly DateTime _fromDate;
        private readonly DateTime _toDate;
        private readonly string _supplier;

        public frmStockHistoryReport()
        {
            InitializeComponent();
        }

        public frmStockHistoryReport(DataTable data, DateTime fromDate, DateTime toDate, string supplier)
        {
            InitializeComponent();
            _data = data;
            _fromDate = fromDate;
            _toDate = toDate;
            _supplier = supplier;
        }

        private void frmStockHistoryReport_Load(object sender, EventArgs e)
        {
           string reportPath = System.IO.Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "CrystalReport",   // 👈 idagdag ang folder name
            "StockInHistoryReport.rpt");

            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show($"Missing report at:\n{reportPath}");
                return;
            }

            var rpt = new ReportDocument();
            rpt.Load(reportPath);

            rpt.DataSourceConnections.Clear();

            if (_data == null || _data.Rows.Count == 0)
            {
                MessageBox.Show("No data to display in report.");
                return;
            }

            rpt.SetDataSource(_data);

            rpt.SetParameterValue("dtpFrom", _fromDate);
            rpt.SetParameterValue("dtpTo", _toDate);
            //rpt.SetParameterValue("Supplier", string.IsNullOrEmpty(_supplier) ? "All" : _supplier);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

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
    }
}
