using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql;

namespace PotpotMotorShopPOS.Forms.Modules
{
    public partial class ProductListManagement : Form
    {
        private int? productId = null; // null = Add, not null = Edit
        private string selectedImagePath = null;

        // Add mode
        public ProductListManagement()
        {
            InitializeComponent();
        }

        // Edit mode
        public ProductListManagement(int productId)
        {
            InitializeComponent();
            this.productId = productId;
        }

        private void ProductListManagement_Load(object sender, EventArgs e)
        {
            LoadCategories();

            if (productId.HasValue)
            {
                LoadProductDetails(productId.Value);
                this.Text = "Edit Product";
                btnSaveProduct.Text = "Update";
            }
            else
            {
                this.Text = "Add Product";
                btnSaveProduct.Text = "Save";
            }
        }

        private void LoadCategories()
        {
            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return;

                string query = "SELECT categoryid, categoryname FROM categories ORDER BY categoryname ASC";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "categoryname";
                    cmbCategory.ValueMember = "categoryid";
                }
            }
        }

        private void LoadProductDetails(int id)
        {
            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return; // ✅ ADDED

                using (var cmd = new NpgsqlCommand(@"SELECT productname, barcode, price, quantity, 
                                             reorderlevel, categoryid, imagepath
                                             FROM products
                                             WHERE productid=@ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtProductName.Text = reader["productname"].ToString();
                            txtBarcode.Text = reader["barcode"].ToString();
                            numPrice.Value = Convert.ToDecimal(reader["price"]);
                            numQuantity.Value = Convert.ToDecimal(reader["quantity"]);
                            numReOrderLevel.Value = Convert.ToDecimal(reader["reorderlevel"]);

                            int categoryId = Convert.ToInt32(reader["categoryid"]);
                            cmbCategory.SelectedValue = categoryId;

                            string path = reader["imagepath"]?.ToString();
                            if (!string.IsNullOrEmpty(path) && File.Exists(path))
                            {
                                selectedImagePath = path;
                                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                                {
                                    picProductImage.Image = Image.FromStream(fs);
                                }
                                picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                            else
                            {
                                picProductImage.Image = null;
                            }
                        }
                    }
                }
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    picProductImage.Image = Image.FromFile(selectedImagePath);
                    picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            // ✅ Validation
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please fill in Product Name.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a Category.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Auto-generate barcode if empty
            string barcode = string.IsNullOrWhiteSpace(txtBarcode.Text)
                ? "AUTO-" + Guid.NewGuid().ToString("N").Substring(0, 8)
                : txtBarcode.Text.Trim();

            string productName = txtProductName.Text.Trim();
            decimal price = numPrice.Value;
            int quantity = (int)numQuantity.Value;
            int reorderLevel = (int)numReOrderLevel.Value;
            string categoryName = cmbCategory.Text;

            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return;

                // 🔎 Check for duplicate barcode
                string checkQuery = productId == null
                    ? "SELECT COUNT(*) FROM products WHERE barcode=@Barcode"
                    : "SELECT COUNT(*) FROM products WHERE barcode=@Barcode AND productid<>@ID";

                using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Barcode", barcode);
                    if (productId != null)
                        checkCmd.Parameters.AddWithValue("@ID", productId.Value);

                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Duplicate barcode detected. Please enter or scan another valid barcode.",
                                        "Duplicate Barcode",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);

                        txtBarcode.Focus();
                        txtBarcode.SelectAll();
                        return;
                    }
                }

                // ✅ Proceed with insert/update
                string query;
                int affectedRecordId = 0;

                // ✅ Get current user info from SessionManager
                string currentUser = SessionManager.IsLoggedIn
                    ? $"{SessionManager.CurrentUsername} ({SessionManager.CurrentRole})"
                    : "Unknown User";

                if (productId == null) // ADD
                {
                    query = @"INSERT INTO products
                        (productname, barcode, price, quantity, reorderlevel, categoryid, imagepath, createdby, createdat)
                        VALUES (@Name, @Barcode, @Price, @Qty, @ReOrder, @CategoryID, @ImagePath, @User, CURRENT_TIMESTAMP)
                        RETURNING productid";
                }
                else // EDIT
                {
                    query = @"UPDATE products SET
                    productname=@Name,
                    barcode=@Barcode,
                    price=@Price,
                    quantity=@Qty,
                    reorderlevel=@ReOrder,
                    categoryid=@CategoryID,
                    imagepath=@ImagePath,
                    updatedby=@User,
                    updatedat=CURRENT_TIMESTAMP
                    WHERE productid=@ID
                    RETURNING productid";
                }

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", productName);
                    cmd.Parameters.AddWithValue("@Barcode", barcode);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Qty", quantity);
                    cmd.Parameters.AddWithValue("@ReOrder", reorderLevel);
                    cmd.Parameters.AddWithValue("@CategoryID", cmbCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@ImagePath", selectedImagePath ?? "");
                    cmd.Parameters.AddWithValue("@User", currentUser);

                    if (productId != null)
                        cmd.Parameters.AddWithValue("@ID", productId.Value);

                    // ✅ Get the affected product ID
                    affectedRecordId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // ✅ LOG THE ACTION TO AUDIT LOGS
                // ✅ LOG THE ACTION TO AUDIT LOGS + CHECK NOTIFICATIONS
                if (productId == null) // ADD
                {
                    string description = $"Added product: {productName} | " +
                                       $"Barcode: {barcode} | " +
                                       $"Category: {categoryName} | " +
                                       $"Price: ₱{price:N2} | " +
                                       $"Quantity: {quantity} | " +
                                       $"Reorder Level: {reorderLevel}";

                    AuditLogger.LogInsert("Products", affectedRecordId, description);

                    // ✅ CHECK IF NEW PRODUCT HAS LOW STOCK
                    NotificationHelper.CheckAndGenerateNotifications();

                    MessageBox.Show("Product added successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // EDIT
                {
                    string description = $"Updated product: {productName} | " +
                                       $"Barcode: {barcode} | " +
                                       $"Category: {categoryName} | " +
                                       $"Price: ₱{price:N2} | " +
                                       $"Quantity: {quantity} | " +
                                       $"Reorder Level: {reorderLevel}";

                    AuditLogger.LogUpdate("Products", productId.Value, description);

                    // ✅ CHECK IF UPDATED PRODUCT HAS LOW STOCK
                    NotificationHelper.CheckAndGenerateNotifications();

                    MessageBox.Show("Product updated successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            string barcode = txtBarcode.Text.Trim();
            if (string.IsNullOrEmpty(barcode)) return;

            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return;

                string query = productId == null
                    ? "SELECT productid FROM products WHERE barcode=@Barcode"
                    : "SELECT productid FROM products WHERE barcode=@Barcode AND productid<>@ID";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Barcode", barcode);
                    if (productId != null)
                        cmd.Parameters.AddWithValue("@ID", productId.Value);

                    var existingId = cmd.ExecuteScalar();

                    if (existingId != null && productId == null) // Only warn in ADD mode
                    {
                        MessageBox.Show("Duplicate barcode detected. Please enter or scan another valid barcode.",
                                        "Duplicate Barcode",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        txtBarcode.SelectAll();
                    }
                }
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

        private void btnCancel_Click(object sender, EventArgs e)
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