using Guna.UI2.WinForms.Enums;
using PotpotMotorShopPOS.Forms.Modules;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class ProductCategoryControl : UserControl
    {
        public ProductCategoryControl()
        {
            InitializeComponent();

            // Custom headers
            DataGridHelper.ApplyStyle(CategoryDatagrid);
            var grid = CategoryDatagrid;

            var editCol = (DataGridViewImageColumn)grid.Columns["EditColumn"];
            editCol.Width = 50;
            editCol.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var delCol = (DataGridViewImageColumn)grid.Columns["DeleteColumn"];
            delCol.Width = 50;
            delCol.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            delCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Load += ProductCategoryControl_Load;
            CategoryDatagrid.CellContentClick += CategoryDatagrid_CellContentClick;
        }

        private void ProductCategoryControl_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void BtnAddCategory_Click_1(object sender, EventArgs e)
        {
            var form = new CategoryManagementForm();
            form.OnCategoryAdded += LoadCategories;
            form.ShowDialog();
        }

        private void CategoryDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // EDIT clicked
            if (CategoryDatagrid.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                string categoryId = CategoryDatagrid.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();

                var editForm = new CategoryManagementForm(categoryId);
                editForm.OnCategoryUpdated += LoadCategories;
                editForm.ShowDialog();
            }
            // DELETE clicked
            else if (CategoryDatagrid.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                string categoryId = CategoryDatagrid.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();
                string categoryName = CategoryDatagrid.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();

                var confirm = MessageBox.Show(
                    $"Are you sure you want to delete category '{categoryName}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
                    using (var cmd = new NpgsqlCommand("DELETE FROM Categories WHERE CategoryID=@CategoryID", conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", int.Parse(categoryId));
                        cmd.ExecuteNonQuery();
                    }
                    LoadCategories();
                }
            }
        }

        private void LoadCategories()
        {
            try
            {
                CategoryDatagrid.Rows.Clear();

                using (var conn = ServerDatabase.GetConnection())
                using (var cmd = new NpgsqlCommand("SELECT CategoryID, CategoryName, CreatedDate FROM Categories", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int rowIndex = CategoryDatagrid.Rows.Add(
                            reader["CategoryID"].ToString(),   // CATEGORY ID
                            reader["CategoryName"].ToString()  // CATEGORY NAME
                        );

                        // Tooltip shows CreatedDate
                        CategoryDatagrid.Rows[rowIndex].Cells["CategoryName"].ToolTipText =
                            $"Created on {reader["CreatedDate"]}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        private void CategoryDatagrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Reserved for future use
        }

        private void PnlOne_Paint(object sender, PaintEventArgs e)
        {
            // Reserved for custom painting
        }
    }
}