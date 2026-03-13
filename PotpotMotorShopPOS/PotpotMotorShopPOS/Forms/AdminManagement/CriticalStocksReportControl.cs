using PotpotMotorShopPOS.CrystalReport.Forms;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Views.Reports
{
    public partial class CriticalStocksReportControl : UserControl
    {
        public CriticalStocksReportControl()
        {
            InitializeComponent();
            DataGridHelper.ApplyStyle(dgvCriticalStock);

            dgvCriticalStock.CellFormatting += CriticalStockDatagrid_CellFormatting;

            LoadCriticalStocks();
            LoadCategories();
        }

        private void LoadCategories()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                if (conn == null) return;
                string query = "SELECT categoryid, categoryname FROM categories ORDER BY categoryname ASC";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    // Force column types to avoid InvalidCastException
                    DataTable dt = new DataTable();
                    dt.Columns.Add("categoryid", typeof(int));
                    dt.Columns.Add("categoryname", typeof(string));
                    adapter.Fill(dt);

                    // Insert "All Categories"
                    DataRow all = dt.NewRow();
                    all["categoryid"] = 0;
                    all["categoryname"] = "All Categories";
                    dt.Rows.InsertAt(all, 0);

                    cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbCategoryFilter.DataSource = dt;
                    cmbCategoryFilter.DisplayMember = "categoryname";
                    cmbCategoryFilter.ValueMember = "categoryid";
                    cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
                }
            }
        }

        private void LoadCriticalStocks()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                if (conn == null) return;
                string query = @"
                SELECT 
                    p.productid,
                    p.productname,
                    p.barcode,
                    p.price,
                    p.quantity,
                    p.reorderlevel,
                    c.categoryname
                FROM products p
                INNER JOIN categories c ON p.categoryid = c.categoryid
                WHERE p.quantity <= p.reorderlevel";

                // Safely get selected CategoryID
                int selectedCatId = 0;
                if (cmbCategoryFilter.SelectedValue != null && !(cmbCategoryFilter.SelectedValue is DataRowView))
                {
                    selectedCatId = Convert.ToInt32(cmbCategoryFilter.SelectedValue);
                }

                if (selectedCatId != 0)
                {
                    query += " AND p.categoryid = @catId";
                }

                query += " ORDER BY p.quantity ASC;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {

                    if (selectedCatId != 0)
                        cmd.Parameters.AddWithValue("@catId", selectedCatId);

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvCriticalStock.AutoGenerateColumns = false;
                        dgvCriticalStock.DataSource = dt;

                        dgvCriticalStock.Columns["ProductID"].DataPropertyName = "productid";
                        dgvCriticalStock.Columns["Barcode"].DataPropertyName = "barcode";
                        dgvCriticalStock.Columns["Price"].DataPropertyName = "price";
                        dgvCriticalStock.Columns["Quantity"].DataPropertyName = "quantity";
                        dgvCriticalStock.Columns["ReOrderLevel"].DataPropertyName = "reorderlevel";
                        dgvCriticalStock.Columns["CategoryName"].DataPropertyName = "categoryname";
                    }
                }
            }
        }

        private void CriticalStockDatagrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCriticalStock.Columns[e.ColumnIndex].Name == "Quantity" && e.Value != null)
            {
                int qty = Convert.ToInt32(e.Value);
                int reorder = Convert.ToInt32(dgvCriticalStock.Rows[e.RowIndex].Cells["ReOrderLevel"].Value);

                if (qty <= reorder)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.Font = new Font(dgvCriticalStock.Font, FontStyle.Bold);
                }
            }
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCriticalStocks();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (var rptForm = new CriticalStocksReportForm())
            {
                rptForm.ShowDialog();
            }
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CriticalStocksReportControl_Load(object sender, EventArgs e)
        {

        }
    }
}