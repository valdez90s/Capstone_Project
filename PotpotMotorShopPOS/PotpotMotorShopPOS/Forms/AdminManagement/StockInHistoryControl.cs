using PotpotMotorShopPOS;
using PotpotMotorShopPOS.Helpers;
using PotpotMotorShopPOS.Repository;
using Npgsql; // ✅ PostgreSQL provider
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class StockInHistoryControl : UserControl
    {
        private readonly StockEntryRepository _repo;

        public StockInHistoryControl()
        {
            InitializeComponent();

            // ✅ Prevent Designer crash
            if (!DesignMode)
            {
                _repo = new StockEntryRepository();
            }
        }

        private void StockInHistoryControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return; // ✅ Skip DB calls in Designer

            LoadSuppliers();
            LoadStockInHistory();
            // Custom headers
            DataGridHelper.ApplyStyle(stockInHistoryDataGridView);
        }

        private void LoadSuppliers()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
            {
                string query = "SELECT DISTINCT SupplierName FROM StockEntries ORDER BY SupplierName";

                using (var cmd = new NpgsqlCommand(query, conn)) // ✅ NpgsqlCommand
                using (var reader = cmd.ExecuteReader())
                {
                    cboSupplierFilter.Items.Clear();
                    cboSupplierFilter.Items.Add("All");
                    while (reader.Read())
                    {
                        cboSupplierFilter.Items.Add(reader["SupplierName"].ToString());
                    }
                }
            }

            cboSupplierFilter.SelectedIndex = 0;
        }

        private void LoadStockInHistory()
        {
            DateTime fromDate = dtpFrom.Value;
            DateTime toDate = dtpTo.Value;
            string supplier = cboSupplierFilter.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(supplier) || supplier == "All")
            {
                supplier = "";
            }

            // Bind data to grid
            var dt = _repo.GetStockInHistory(fromDate, toDate, supplier);
            stockInHistoryDataGridView.DataSource = dt;

            // Compute grand total
            decimal grandTotal = _repo.GetStockInHistoryTotal(fromDate, toDate, supplier);

            // ✅ Show both row count and total
            lblGrandTotal.Text = $"Records: {dt.Rows.Count} | Grand Total: {grandTotal:N2}";
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadStockInHistory();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadStockInHistory();
        }

        private void cboSupplierFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStockInHistory();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadStockInHistory();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value;
            DateTime toDate = dtpTo.Value;
            string supplier = cboSupplierFilter.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(supplier) || supplier == "All")
            {
                supplier = "";
            }

            // Kunin data galing repo
            var dt = _repo.GetStockInHistory(fromDate, toDate, supplier);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No data to print for the selected criteria.",
                                "No Data",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            // Open Crystal Report form
            var reportForm = new CrystalReport.Forms.frmStockHistoryReport(dt, fromDate, toDate, supplier);
            reportForm.ShowDialog();
        }

        private void stockInHistoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Add cell click logic here
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: leave empty or remove if not needed
        }

        private void stockInHistoryDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Add cell click logic here
        }
    }
}