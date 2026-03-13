using Guna.UI2.WinForms.Enums;
using PotpotMotorShopPOS.Helpers;
using PotpotMotorShopPOS.Models;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Forms.Modules
{
    public partial class ProductSelectionForm : Form
    {
        // 🔹 Event para ipasa ang napiling product sa parent form
        public event Action<ProductModel> ProductAdded;

        public ProductSelectionForm()
        {
            InitializeComponent();
            LoadCategories();
            LoadProducts();
            AddSelectButtonColumn();
            // Custom headers
            DataGridHelper.ApplyStyle(dgvProductList);
        }

        private void LoadCategories()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                if (conn == null) return;
                // ✅ Load both CategoryID and CategoryName from Categories table
                string query = @"SELECT categoryid, categoryname 
                                FROM categories 
                                WHERE isdeleted = false 
                                ORDER BY categoryname";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    cmbCategoryFilter.Items.Clear();

                    // Add "All Categories" option
                    cmbCategoryFilter.Items.Add(new CategoryItem { CategoryID = 0, CategoryName = "All Categories" });

                    while (reader.Read())
                    {
                        cmbCategoryFilter.Items.Add(new CategoryItem
                        {
                            CategoryID = Convert.ToInt32(reader["categoryid"]),
                            CategoryName = reader["categoryname"].ToString()
                        });
                    }
                }
            }

            cmbCategoryFilter.DisplayMember = "CategoryName";
            cmbCategoryFilter.ValueMember = "CategoryID";
            cmbCategoryFilter.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {

                if (conn == null) return;

                // ✅ Join with Categories to get CategoryName for display
                string query = @"SELECT 
                    p.productid, 
                    p.barcode, 
                    p.productname, 
                    p.price, 
                    c.categoryname, 
                    p.reorderlevel   
                FROM products p
                LEFT JOIN categories c ON p.categoryid = c.categoryid";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvProductList.DataSource = dt;

                    dgvProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvProductList.RowTemplate.Height = 40;
                    dgvProductList.AllowUserToAddRows = false;

                    // 🔹 Override header text
                    dgvProductList.Columns["categoryname"].HeaderText = "Category";
                }
            }
        }

        private void AddSelectButtonColumn()
        {
            if (!dgvProductList.Columns.Contains("btnAddToEntry"))
            {
                DataGridViewImageColumn btnAdd = new DataGridViewImageColumn();
                btnAdd.Name = "btnAddToEntry";
                btnAdd.Image = Properties.Resources.add; // Replace with your actual icon
                btnAdd.HeaderText = "";
                btnAdd.Width = 40;
                dgvProductList.Columns.Add(btnAdd);
            }
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            ApplyProductFilter();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyProductFilter();
        }

        private void ApplyProductFilter()
        {
            var dt = dgvProductList.DataSource as DataTable;
            if (dt == null) return;

            string keyword = txtSearchProduct.Text.Trim().Replace("'", "''");
            var selectedCategory = cmbCategoryFilter.SelectedItem as CategoryItem;

            string filter = "";

            if (!string.IsNullOrEmpty(keyword))
                filter += $"(barcode LIKE '%{keyword}%' OR productname LIKE '%{keyword}%')";

            // ✅ Filter by CategoryName (from joined table)
            if (selectedCategory != null && selectedCategory.CategoryID != 0)
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"categoryname = '{selectedCategory.CategoryName.Replace("'", "''")}'";
            }

            dt.DefaultView.RowFilter = filter;
        }

        private void dgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProductList.Columns["btnAddToEntry"].Index && e.RowIndex >= 0)
            {
                var row = dgvProductList.Rows[e.RowIndex];
                string productName = row.Cells["productname"].Value.ToString();

                var confirm = MessageBox.Show($"Add this item?\n{productName}", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var product = new ProductModel
                    {
                        ProductID = Convert.ToInt32(row.Cells["productid"].Value),
                        Barcode = row.Cells["barcode"].Value?.ToString() ?? "",
                        ProductName = productName,
                        Price = Convert.ToDecimal(row.Cells["price"].Value ?? 0m),
                        CategoryName = row.Cells["categoryname"].Value?.ToString() ?? "",
                        ReOrderLevel = Convert.ToInt32(row.Cells["reorderlevel"].Value ?? 0),
                        Quantity = 1
                    };

                    // 🔹 Trigger event
                    ProductAdded?.Invoke(product);
                }
            }
        }

        // 🔹 Optional: Add a Done button para manual close
        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
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

        // ✅ Helper class for ComboBox items
        private class CategoryItem
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        }
    }
}