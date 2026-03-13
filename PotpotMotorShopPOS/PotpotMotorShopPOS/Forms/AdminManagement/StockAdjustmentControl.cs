using PotpotMotorShopPOS.Forms.Modules;
using PotpotMotorShopPOS.Helpers;
using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class StockAdjustmentControl : UserControl
    {
        public StockAdjustmentControl()
        {
            InitializeComponent();
            DataGridHelper.ApplyStyle(dgvProducts);
        }

        private void StockAdjustmentControl_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return;
                string query = @"SELECT CategoryID, CategoryName 
                                 FROM Categories 
                                 WHERE IsDeleted = false 
                                 ORDER BY CategoryName";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    cmbCategory.Items.Clear();

                    // Add "All" option
                    cmbCategory.Items.Add(new CategoryItem { CategoryID = 0, CategoryName = "All" });

                    while (reader.Read())
                    {
                        cmbCategory.Items.Add(new CategoryItem
                        {
                            CategoryID = Convert.ToInt32(reader["CategoryID"]),
                            CategoryName = reader["CategoryName"].ToString()
                        });
                    }
                }
            }

            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.SelectedIndex = 0;
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvProducts.Columns[e.ColumnIndex].Name == "btnUpdate")
            {
                var row = dgvProducts.Rows[e.RowIndex];

                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                string barcode = row.Cells["Barcode"].Value?.ToString();
                string productName = row.Cells["ProductName"].Value?.ToString();
                int stockOnHand = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);

                using (var form = new StockAdjustmentForm(productId, barcode, productName, stockOnHand))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts(); // ✅ Refresh products lang, walang history
                    }
                }
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return;
                    string search = txtSearch.Text.Trim();
                    var selectedCategory = cmbCategory.SelectedItem as CategoryItem;

                    string baseQuery = @"SELECT p.ProductID, p.Barcode, p.ProductName, 
                                                c.CategoryName, p.Price, p.Quantity
                                         FROM Products p
                                         LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                                         WHERE 1=1";

                    if (selectedCategory != null && selectedCategory.CategoryID != 0)
                    {
                        baseQuery += " AND p.CategoryID = @CategoryID";
                    }

                    if (!string.IsNullOrEmpty(search))
                    {
                        baseQuery += " AND (p.Barcode ILIKE @Search OR p.ProductName ILIKE @Search)";
                    }

                    using (var cmd = new NpgsqlCommand(baseQuery, conn))
                    {
                        if (selectedCategory != null && selectedCategory.CategoryID != 0)
                            cmd.Parameters.AddWithValue("@CategoryID", selectedCategory.CategoryID);

                        if (!string.IsNullOrEmpty(search))
                            cmd.Parameters.AddWithValue("@Search", "%" + search + "%");

                        using (var da = new NpgsqlDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);

                            dgvProducts.AutoGenerateColumns = false;
                            dgvProducts.DataSource = dt;

                            dgvProducts.Columns["ProductID"].DataPropertyName = "ProductID";
                            dgvProducts.Columns["ProductID"].Visible = false;
                            dgvProducts.Columns["Barcode"].DataPropertyName = "Barcode";
                            dgvProducts.Columns["ProductName"].DataPropertyName = "ProductName";
                            dgvProducts.Columns["CategoryName"].DataPropertyName = "CategoryName";
                            dgvProducts.Columns["Price"].DataPropertyName = "Price";
                            dgvProducts.Columns["Quantity"].DataPropertyName = "Quantity";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: leave empty or remove if not needed
        }

        private class CategoryItem
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        }
    }
}