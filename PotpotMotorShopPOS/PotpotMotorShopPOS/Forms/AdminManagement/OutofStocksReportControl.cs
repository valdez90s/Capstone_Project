using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class OutofStocksReportControl : UserControl
    {
        public OutofStocksReportControl()
        {
            InitializeComponent();
            DataGridHelper.ApplyStyle(OutOfStockDatagrid);
            OutOfStockDatagrid.CellFormatting += OutOfStockDatagrid_CellFormatting;
        }

        private void OutofStocksReportControl_Load(object sender, EventArgs e)
        {
            LoadOutOfStock();
            LoadCategories();
        }

        private void LoadCategories()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                if (conn == null) return;
                string query = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName ASC";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Insert "All Categories"
                    DataRow all = dt.NewRow();
                    all["CategoryID"] = 0;
                    all["CategoryName"] = "All Categories";
                    dt.Rows.InsertAt(all, 0);

                    cmbCategoryFilter.DataSource = dt;
                    cmbCategoryFilter.DisplayMember = "CategoryName";
                    cmbCategoryFilter.ValueMember = "CategoryID";
                }
            }
        }

        private void LoadOutOfStock()
        {
            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return;
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
                WHERE p.Quantity = 0";

                int selectedCatId = 0;
                if (cmbCategoryFilter.SelectedValue != null && !(cmbCategoryFilter.SelectedValue is DataRowView))
                {
                    selectedCatId = Convert.ToInt32(cmbCategoryFilter.SelectedValue);
                }

                if (selectedCatId != 0)
                {
                    query += " AND p.CategoryID = @catId";
                }

                query += " ORDER BY p.ProductName ASC;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (selectedCatId != 0)
                        cmd.Parameters.AddWithValue("@catId", selectedCatId);

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable("OutOfStock");
                        adapter.Fill(dt);

                        OutOfStockDatagrid.AutoGenerateColumns = false;
                        OutOfStockDatagrid.DataSource = dt;

                        OutOfStockDatagrid.Columns["ProductID"].DataPropertyName = "ProductID";
                        OutOfStockDatagrid.Columns["ProductName"].DataPropertyName = "ProductName";
                        OutOfStockDatagrid.Columns["Barcode"].DataPropertyName = "Barcode";
                        OutOfStockDatagrid.Columns["Price"].DataPropertyName = "Price";
                        OutOfStockDatagrid.Columns["Quantity"].DataPropertyName = "Quantity";
                        OutOfStockDatagrid.Columns["ReOrderLevel"].DataPropertyName = "ReOrderLevel";
                        OutOfStockDatagrid.Columns["CategoryName"].DataPropertyName = "CategoryName";
                    }
                }
            }
        }

        private void OutOfStockDatagrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (OutOfStockDatagrid.Columns[e.ColumnIndex].Name == "Quantity" && e.Value != null)
            {
                int qty = Convert.ToInt32(e.Value);
                if (qty == 0)
                {
                    e.CellStyle.BackColor = Color.DarkRed;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.Font = new Font(OutOfStockDatagrid.Font, FontStyle.Bold);
                }
            }
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOutOfStock();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (var rptForm = new PotpotMotorShopPOS.CrystalReport.Forms.OutOfStockReportForm())
            {
                rptForm.ShowDialog();
            }
        }

        private void OutOfStockDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}