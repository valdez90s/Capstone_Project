using Guna.UI2.WinForms.Enums;
using PotpotMotorShopPOS.Forms.Modules;
using PotpotMotorShopPOS.Helpers;
using PotpotMotorShopPOS.Models;
using PotpotMotorShopPOS.Views.Authentication;
using Npgsql; // ✅ PostgreSQL provider
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class StockEntryControl : UserControl
    {
        public event Action StockEntrySaved;

        public StockEntryControl()
        {
            InitializeComponent();
            // Apply style first
            DataGridHelper.ApplyStyle(StockEntryListDatagrid);

            var grid = StockEntryListDatagrid;
            grid.RowTemplate.Height = 90;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            btnBrowseProducts.Enabled = false;

            // Hook validation
            txtReferenceNo.TextChanged += ValidateForm;
            txtStockInBy.TextChanged += ValidateForm;
            cmbSupplier.SelectedIndexChanged += cmbSupplier_SelectedIndexChanged;
            txtContactPerson.TextChanged += ValidateForm;
            txtAddress.TextChanged += ValidateForm;

            // ✅ Barcode scanner textbox event
            txtBarcodeScanner.KeyDown += TxtBarcodeScanner_KeyDown;

            // Auto-fetch current user
            txtStockInBy.Text = SessionManager.CurrentFullName;

            StockEntryListDatagrid.CellValueChanged += StockEntryListDatagrid_CellValueChanged;
            StockEntryListDatagrid.CurrentCellDirtyStateChanged += StockEntryListDatagrid_CurrentCellDirtyStateChanged;

            // Format for Price column
            StockEntryListDatagrid.Columns["ProductPrice"].DefaultCellStyle.Format = "C2";
            StockEntryListDatagrid.Columns["ProductPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Format for Total column
            StockEntryListDatagrid.Columns["ProductTotalCost"].DefaultCellStyle.Format = "C2";
            StockEntryListDatagrid.Columns["ProductTotalCost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        // ✅ Barcode Scanner Handler
        private void TxtBarcodeScanner_KeyDown(object sender, KeyEventArgs e)
        {
            // Trigger when Enter is pressed (barcode scanner auto-sends Enter)
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent beep sound

                string barcode = txtBarcodeScanner.Text.Trim();

                if (string.IsNullOrEmpty(barcode))
                    return;

                // Check if form is valid first
                if (!btnBrowseProducts.Enabled)
                {
                    MessageBox.Show("Please complete the form before scanning products.",
                        "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBarcodeScanner.Clear();
                    return;
                }

                // Process barcode
                ProcessBarcode(barcode);

                // Clear textbox for next scan
                txtBarcodeScanner.Clear();
            }
        }

        // ✅ Process Scanned Barcode
        private void ProcessBarcode(string barcode)
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
                using (var cmd = new NpgsqlCommand(@"
                    SELECT ProductID, Barcode, ProductName, Price 
                    FROM Products 
                    WHERE Barcode = @Barcode", conn))
                {
                    cmd.Parameters.AddWithValue("@Barcode", barcode);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var product = new
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                Barcode = reader["Barcode"].ToString(),
                                ProductName = reader["ProductName"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"])
                            };

                            AddOrUpdateProductInGrid(product.ProductID, product.Barcode,
                                product.ProductName, product.Price);
                        }
                        else
                        {
                            MessageBox.Show($"Product with barcode '{barcode}' not found.",
                                "Product Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error scanning barcode: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Add or Update Product in DataGridView (UPDATED - using Barcode)
        private void AddOrUpdateProductInGrid(int productId, string barcode,
            string productName, decimal price)
        {
            // Check if product already exists in grid (by Barcode)
            foreach (DataGridViewRow row in StockEntryListDatagrid.Rows)
            {
                if (row.IsNewRow) continue;

                // ✅ Check by Barcode instead of ProductCode
                if (row.Cells["ProductBarcode"].Value?.ToString() == barcode)
                {
                    // Product exists - increment quantity
                    int currentQty = Convert.ToInt32(row.Cells["ProductQuantity"].Value ?? 0);
                    int newQty = currentQty + 1;

                    // Check if exceeds max
                    if (newQty > 100)
                    {
                        MessageBox.Show("Quantity cannot exceed 100 for this product.",
                            "Max Quantity Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    row.Cells["ProductQuantity"].Value = newQty;
                    row.Cells["ProductTotalCost"].Value = newQty * price;

                    // Highlight row briefly
                    HighlightRow(row);

                    UpdateGrandTotal();
                    return;
                }
            }

            // Product doesn't exist - add new row
            int rowIndex = StockEntryListDatagrid.Rows.Count + 1;
            string refNo = txtReferenceNo.Text;

            int addedRowIndex = StockEntryListDatagrid.Rows.Add(
                rowIndex,           // #
                refNo,              // REF #
                barcode,            // ✅ BARCODE (instead of ProductCode)
                productId,          // ProductID (hidden)
                productName,        // PRODUCT NAME
                1,                  // QUANTITY = 1 (scanned once)
                price,              // PRICE
                price               // TOTAL = price * 1
            );

            // Highlight new row
            HighlightRow(StockEntryListDatagrid.Rows[addedRowIndex]);

            UpdateGrandTotal();
        }

        // ✅ Highlight Row Animation (visual feedback)
        private async void HighlightRow(DataGridViewRow row)
        {
            Color originalBackColor = row.DefaultCellStyle.BackColor;
            Color originalForeColor = row.DefaultCellStyle.ForeColor;

            // Highlight with green
            row.DefaultCellStyle.BackColor = Color.LightGreen;
            row.DefaultCellStyle.ForeColor = Color.DarkGreen;

            await System.Threading.Tasks.Task.Delay(500); // 0.5 seconds

            // Restore original colors
            row.DefaultCellStyle.BackColor = originalBackColor;
            row.DefaultCellStyle.ForeColor = originalForeColor;
        }

        private void lblGenereteReference_Click(object sender, EventArgs e)
        {
            txtReferenceNo.Text = GenerateReferenceNo();
            ValidateForm(null, null);
        }

        private string GenerateReferenceNo()
        {
            string prefix = "SE-" + DateTime.Now.Year + "-";
            int seq = 1;

            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
            using (var cmd = new NpgsqlCommand(
                "SELECT COALESCE(MAX(StockEntryID), 0) + 1 FROM StockEntries", conn))
            {
                object result = cmd.ExecuteScalar();
                seq = Convert.ToInt32(result);
            }

            return prefix + seq.ToString("D3");
        }

        // 🔹 Validate required fields before enabling Browse
        private void ValidateForm(object sender, EventArgs e)
        {
            btnBrowseProducts.Enabled =
                !string.IsNullOrWhiteSpace(txtReferenceNo.Text) &&
                !string.IsNullOrWhiteSpace(txtStockInBy.Text) &&
                !string.IsNullOrWhiteSpace(cmbSupplier.Text) &&
                !string.IsNullOrWhiteSpace(txtContactPerson.Text) &&
                !string.IsNullOrWhiteSpace(txtAddress.Text);
        }

        private void btnBrowseProducts_Click(object sender, EventArgs e)
        {
            var selector = new ProductSelectionForm();

            // 🔹 Subscribe sa ProductAdded event (UPDATED - using Barcode)
            selector.ProductAdded += (p) =>
            {
                AddOrUpdateProductInGrid(p.ProductID, p.Barcode, p.ProductName, p.Price);
            };

            selector.ShowDialog();
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedItem is SupplierModel supplier)
            {
                txtContactPerson.Text = supplier.ContactPerson;
                txtAddress.Text = supplier.Address;
                ValidateForm(null, null);
            }
        }

        //addproduct 
        private void btnSaveEntry_Click(object sender, EventArgs e)
        {
            if (StockEntryListDatagrid.Rows.Count == 0)
            {
                MessageBox.Show("No products to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
            using (var tran = conn.BeginTransaction())
            {
                try
                {
                    // ✅ Get SupplierID from selected ComboBox
                    int supplierId = 0;
                    if (cmbSupplier.SelectedItem is SupplierModel supplier)
                    {
                        supplierId = supplier.SupplierID;
                    }

                    foreach (DataGridViewRow row in StockEntryListDatagrid.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                        int qty = Convert.ToInt32(row.Cells["ProductQuantity"].Value ?? 0);
                        decimal price = Convert.ToDecimal(row.Cells["ProductPrice"].Value ?? 0);
                        string barcode = row.Cells["ProductBarcode"].Value?.ToString(); // ✅ Get Barcode

                        // ✅ Insert into StockEntries (UPDATED - using Barcode & PostgreSQL)
                        using (var cmd = new NpgsqlCommand(@"
                        INSERT INTO StockEntries
                        (ReferenceNo, SupplierID, SupplierName, Contact, Address,  
                         ProductID, ProductCode, ProductName, Quantity, Price, CreatedBy)
                        VALUES 
                        (@ReferenceNo, @SupplierID, @SupplierName, @Contact, @Address,  
                         @ProductID, @Barcode, @ProductName, @Quantity, @Price, @CreatedBy)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@ReferenceNo", txtReferenceNo.Text.Trim());
                            cmd.Parameters.AddWithValue("@SupplierID", supplierId > 0 ? (object)supplierId : DBNull.Value);
                            cmd.Parameters.AddWithValue("@SupplierName", cmbSupplier.Text.Trim());
                            cmd.Parameters.AddWithValue("@Contact", txtContactPerson.Text.Trim());
                            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                            cmd.Parameters.AddWithValue("@ProductID", productId);
                            cmd.Parameters.AddWithValue("@Barcode", barcode); // ✅ Use Barcode
                            cmd.Parameters.AddWithValue("@ProductName", row.Cells["NameProduct"].Value);
                            cmd.Parameters.AddWithValue("@Quantity", qty);
                            cmd.Parameters.AddWithValue("@Price", price);

                            cmd.Parameters.AddWithValue("@CreatedBy", txtStockInBy.Text.Trim());

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Commit transaction
                    tran.Commit();
                    MessageBox.Show("Stock entry saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form
                    StockEntryListDatagrid.Rows.Clear();
                    txtReferenceNo.Clear();
                    cmbSupplier.SelectedIndex = -1;
                    txtContactPerson.Clear();
                    txtAddress.Clear();
                    txtBarcodeScanner.Clear(); // ✅ Clear barcode scanner

                    // Trigger event para i-refresh ProductListControl
                    StockEntrySaved?.Invoke();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error saving stock entry: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StockEntryControl_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
                using (var cmd = new NpgsqlCommand(
                    @"SELECT SupplierID, SupplierName, ContactPerson, Address 
                      FROM Supplier 
                      WHERE IsActive = true 
                      ORDER BY SupplierName", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var suppliers = new List<SupplierModel>();
                    while (reader.Read())
                    {
                        suppliers.Add(new SupplierModel
                        {
                            SupplierID = Convert.ToInt32(reader["SupplierID"]),
                            SupplierName = reader["SupplierName"].ToString(),
                            ContactPerson = reader["ContactPerson"].ToString(),
                            Address = reader["Address"].ToString()
                        });
                    }

                    // Bind to ComboBox
                    cmbSupplier.DataSource = suppliers;
                    cmbSupplier.DisplayMember = "SupplierName";
                    cmbSupplier.ValueMember = "SupplierID";
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSupplier.DataSource = null;
            }
        }

        private void StockEntryListDatagrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == StockEntryListDatagrid.Columns["ProductQuantity"].Index && e.RowIndex >= 0)
            {
                var cell = StockEntryListDatagrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                int qty;

                // Parse input
                if (!int.TryParse(cell.Value?.ToString(), out qty) || qty < 0)
                {
                    qty = 0;
                }

                // Check kung sobra sa 100
                if (qty > 100)
                {
                    MessageBox.Show("Quantity cannot exceed 100.", "Invalid Quantity",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cell.Value = string.Empty;
                    return;
                }

                // Apply back to cell
                cell.Value = qty;

                // Recompute total
                var price = Convert.ToDecimal(StockEntryListDatagrid.Rows[e.RowIndex].Cells["ProductPrice"].Value ?? 0);
                StockEntryListDatagrid.Rows[e.RowIndex].Cells["ProductTotalCost"].Value = qty * price;

                UpdateGrandTotal();
            }
        }

        private void StockEntryListDatagrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (StockEntryListDatagrid.IsCurrentCellDirty)
            {
                StockEntryListDatagrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void StockEntryListDatagrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                (e.ColumnIndex == StockEntryListDatagrid.Columns["ProductQuantity"].Index ||
                 e.ColumnIndex == StockEntryListDatagrid.Columns["ProductPrice"].Index))
            {
                var row = StockEntryListDatagrid.Rows[e.RowIndex];

                int qty = 0;
                decimal price = 0;

                int.TryParse(row.Cells["ProductQuantity"].Value?.ToString(), out qty);
                decimal.TryParse(row.Cells["ProductPrice"].Value?.ToString(), out price);

                row.Cells["ProductTotalCost"].Value = qty * price;
            }

            UpdateGrandTotal();
        }

        private void UpdateGrandTotal()
        {
            decimal grandTotal = 0;

            foreach (DataGridViewRow row in StockEntryListDatagrid.Rows)
            {
                if (row.IsNewRow) continue;

                decimal total = 0;
                decimal.TryParse(row.Cells["ProductTotalCost"].Value?.ToString(), out total);
                grandTotal += total;
            }

            lblGrandTotal.Text = $"Grand Total: {grandTotal:C}";
        }

        private void StockEntryListDatagrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == StockEntryListDatagrid.Columns["btnremoved"].Index)
            {
                var result = MessageBox.Show("Remove this product?", "Confirm",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    StockEntryListDatagrid.Rows.RemoveAt(e.RowIndex);

                    // Update row numbering
                    for (int i = 0; i < StockEntryListDatagrid.Rows.Count; i++)
                    {
                        StockEntryListDatagrid.Rows[i].Cells["RowIndex"].Value = i + 1;
                    }

                    UpdateGrandTotal();
                }
            }
        }

        private void StockEntryListDatagrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (StockEntryListDatagrid.CurrentCell.ColumnIndex == StockEntryListDatagrid.Columns["ProductQuantity"].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= QuantityColumn_KeyPress;
                    tb.KeyPress += QuantityColumn_KeyPress;
                }
            }
        }

        private void QuantityColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void StockEntryListDatagrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == StockEntryListDatagrid.Columns["ProductQuantity"].Index && e.RowIndex >= 0)
            {
                if (int.TryParse(e.FormattedValue.ToString(), out int qty))
                {
                    if (qty < 0 || qty > 100)
                    {
                        MessageBox.Show("Quantity must be between 0 and 100.");
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.");
                    e.Cancel = true;
                }
            }
        }

        private void lblGenereteReference_CursorChanged(object sender, EventArgs e)
        {
            lblGenereteReference.Cursor = Cursors.Hand;
        }

        private void btnBrowseProducts_CursorChanged(object sender, EventArgs e)
        {
            btnBrowseProducts.Cursor = Cursors.Hand;
        }

        private void guna2GradientPanel5_Paint(object sender, PaintEventArgs e)
        {
            // Optional: leave empty or remove if not needed
        }
    }
}