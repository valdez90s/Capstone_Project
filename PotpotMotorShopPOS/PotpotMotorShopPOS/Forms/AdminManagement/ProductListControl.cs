using Guna.UI2.WinForms.Enums;
using PotpotMotorShopPOS.Forms.Authentication;
using PotpotMotorShopPOS.Forms.Modules;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class ProductListControl : UserControl
    {
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;

        public ProductListControl()
        {
            InitializeComponent();

            LoadItemsPerPage();
            LoadProducts();
            DataGridHelper.ApplyStyle(ProductListDatagrid);

            // Custom headers
            var grid = ProductListDatagrid;
            var editCol = (DataGridViewImageColumn)grid.Columns["EditColumn"];
            editCol.Width = 50;
            editCol.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // 🔹 Items per page dropdown
        private void LoadItemsPerPage()
        {
            cmbItem_per_Page.Items.Clear();
            cmbItem_per_Page.Items.AddRange(new object[] { 10, 20, 50, 100 });
            cmbItem_per_Page.SelectedIndex = 0;
            cmbItem_per_Page.SelectedIndexChanged += cmbItem_per_Page_SelectedIndexChanged;
        }

        // 🔹 Load products with pagination + search
        public void LoadProducts()
        {
            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null)
                {
                    // ✅ Connection failed - MessageBox already shown by GetConnection()
                    // Just exit gracefully
                    return;
                }

                try
                {
                    string search = txtSearch.Text.Trim();

                    string baseQuery = @"
                SELECT p.productid, p.barcode, p.productname, p.price, p.quantity, 
                       p.reorderlevel, p.imagepath, c.categoryname
                FROM products p
                LEFT JOIN categories c ON p.categoryid = c.categoryid";

                    if (!string.IsNullOrEmpty(search))
                    {
                        baseQuery += " WHERE (p.productname ILIKE @Search OR p.barcode ILIKE @Search OR c.categoryname ILIKE @Search)";
                    }

                    // Count total records
                    using (var countCmd = new NpgsqlCommand("SELECT COUNT(*) FROM (" + baseQuery + ") AS count_query", conn))
                    {
                        if (!string.IsNullOrEmpty(search))
                            countCmd.Parameters.AddWithValue("@Search", "%" + search + "%");

                        totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());
                    }

                    int offset = (currentPage - 1) * pageSize;
                    string pagedQuery = baseQuery + " ORDER BY p.productid DESC LIMIT @PageSize OFFSET @Offset";

                    using (var cmd = new NpgsqlCommand(pagedQuery, conn))
                    {
                        if (!string.IsNullOrEmpty(search))
                            cmd.Parameters.AddWithValue("@Search", "%" + search + "%");

                        cmd.Parameters.AddWithValue("@PageSize", pageSize);
                        cmd.Parameters.AddWithValue("@Offset", offset);

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Add Image column
                            if (!dt.Columns.Contains("Image"))
                                dt.Columns.Add("Image", typeof(Image));

                            foreach (DataRow row in dt.Rows)
                            {
                                string path = row["imagepath"]?.ToString();
                                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                                    row["Image"] = Image.FromFile(path);
                                else
                                    row["Image"] = null;
                            }

                            ProductListDatagrid.AutoGenerateColumns = false;
                            ProductListDatagrid.DataSource = dt;

                            // Bind Designer columns
                            ProductListDatagrid.Columns["ProductID"].DataPropertyName = "productid";
                            ProductListDatagrid.Columns["ProductBarcode"].DataPropertyName = "barcode";
                            ProductListDatagrid.Columns["ProductName"].DataPropertyName = "productname";
                            ProductListDatagrid.Columns["Price"].DataPropertyName = "price";
                            ProductListDatagrid.Columns["Quantity"].DataPropertyName = "quantity";
                            ProductListDatagrid.Columns["ReOrderLevel"].DataPropertyName = "reorderlevel";
                            ProductListDatagrid.Columns["CategoryName"].DataPropertyName = "categoryname";
                            ProductListDatagrid.Columns["ProductImageColumn"].DataPropertyName = "Image";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // ✅ Handle query errors (not connection errors)
                    MessageBox.Show(
                        $"Error loading products:\n\n{ex.Message}",
                        "Load Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            UpdatePageLabel();
        }

        // 🔹 Update page label
        private void UpdatePageLabel()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;

            lblPagedisplay.Text = $"Page {currentPage} of {totalPages}";

            // ✅ Enable/Disable Previous button
            btnPrevious.Enabled = currentPage > 1;

            // ✅ Enable/Disable Next button
            btnNext.Enabled = currentPage < totalPages;
        }

        private void ProductListDatagrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (ProductListDatagrid.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                int productId = Convert.ToInt32(ProductListDatagrid.Rows[e.RowIndex].Cells["ProductID"].Value);

                using (var editForm = new ProductListManagement(productId))
                {
                    editForm.ShowDialog();
                    LoadProducts();
                }
            }
        }

        // 🔹 Export with CategoryName from JOIN
        private void BtnExportImport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = "ProductsExport.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        if (conn == null) return; // ✅ Exit if no connection

                        try
                        {
                            using (var cmd = new NpgsqlCommand(@"
                        SELECT p.productname, p.barcode, p.price, p.quantity, p.reorderlevel, c.categoryname 
                        FROM products p
                        LEFT JOIN categories c ON p.categoryid = c.categoryid", conn))
                            using (var reader = cmd.ExecuteReader())
                            using (var writer = new StreamWriter(sfd.FileName))
                            {
                                writer.WriteLine("ProductName,Barcode,Price,Quantity,ReOrderLevel,CategoryName");

                                while (reader.Read())
                                {
                                    writer.WriteLine($"{reader["productname"]},{reader["barcode"]},{reader["price"]},{reader["quantity"]},{reader["reorderlevel"]},{reader["categoryname"]}");
                                }
                            }

                            MessageBox.Show("Export successful!", "Export",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Export error: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            using (var addForm = new ProductListManagement())
            {
                addForm.ShowDialog();
                LoadProducts();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadProducts();
        }

        private void cmbItem_per_Page_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(cmbItem_per_Page.SelectedItem);
            currentPage = 1;
            LoadProducts();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadProducts();
            }
        }
          
        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadProducts();
            }
        }

        private void cmbItem_per_Page_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int newPageSize = Convert.ToInt32(cmbItem_per_Page.SelectedItem);

            // Skip if same value
            if (newPageSize == pageSize)
                return;

            pageSize = newPageSize;
            currentPage = 1;

            // Optional: Show loading indicator
            Cursor = Cursors.WaitCursor;

            try
            {
                LoadProducts();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}