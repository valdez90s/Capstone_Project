using PotpotMotorShopPOS.CrystalReport.Forms;
using PotpotMotorShopPOS.DataSetFile;
using PotpotMotorShopPOS.Forms.Modules;
using PotpotMotorShopPOS.Forms.Report;
using PotpotMotorShopPOS.Helpers;
using PotpotMotorShopPOS.Models;
using PotpotMotorShopPOS.Repository;
using PotpotMotorShopPOS.Views.Authentication;
using System;
using System.Linq;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Forms.POS
{
    public partial class POSForm : Form
    {
        private Timer dateTimeTimer;
        private decimal _transactionDiscount = 0m;
        private const decimal VAT_RATE = 0.12m;
        private ContextMenuStrip dgvCartContextMenu;
        private int _previousQty = 0;
        private bool _transactionSaved = false;

        public POSForm()
        {
            InitializeComponent();
            DataGridHelper.ApplyStyle(dgvCart);
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            if (SessionManager.IsAdmin)
            {
                btnBack.Visible = true;
                btnLogout.Visible = false;
            }
            else
            {
                btnBack.Visible = false;
                btnLogout.Visible = true;
            }

            btnPrintReceipt.Enabled = false;

            // Timer for datetime display
            dateTimeTimer = new Timer();
            dateTimeTimer.Interval = 1000;
            dateTimeTimer.Tick += DateTimeTimer_Tick;
            dateTimeTimer.Start();

            // Wire up events
            txtAmountPaid.TextChanged += (s, ev) => UpdateTotals();
            txtBarcode.KeyDown += TxtBarcode_KeyDown;
            cmbPaymentMethod.SelectedIndexChanged += CmbPaymentMethod_SelectedIndexChanged;
            BtnAddService.Click += BtnAddService_Click;

            // DataGridView events
            dgvCart.CellValueChanged += dgvCart_CellValueChanged;
            dgvCart.CellValidating += dgvCart_CellValidating;
            dgvCart.CellBeginEdit += dgvCart_CellBeginEdit;
            dgvCart.CellEndEdit += dgvCart_CellEndEdit;
            dgvCart.RowsRemoved += (s, ev) => UpdateTotals();
            dgvCart.EditingControlShowing += dgvCart_EditingControlShowing;
            dgvCart.CurrentCellDirtyStateChanged += dgvCart_CurrentCellDirtyStateChanged;

            // Column setup
            colProductName.ReadOnly = true;
            colUnitPrice.ReadOnly = true;
            colLineTotal.ReadOnly = true;
            colQty.ReadOnly = false;

            dgvCart.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvCart.AllowUserToAddRows = false;

            // Setup payment method combo
            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.Add("Cash");
            cmbPaymentMethod.Items.Add("GCash");
            cmbPaymentMethod.SelectedIndex = 0;

            // Initially disable reference field
            txtReference.Enabled = false;
            txtReference.Clear();
            txtAmountPaid.Enabled = true;
            txtInvoiceNo.Text = "---";
            txtInvoiceNo.ReadOnly = true;

            // Load services into combo
            LoadServices();

            // Display current user info
            if (SessionManager.IsLoggedIn)
            {
                lblCurrentUser.Text = $"{SessionManager.CurrentFullName} ({SessionManager.CurrentRole})";

                lblCurrentUser.ForeColor = SessionManager.IsAdmin ? System.Drawing.Color.Green :
                                           SessionManager.IsCashier ? System.Drawing.Color.Blue :
                                           System.Drawing.Color.Green;

                System.Diagnostics.Debug.WriteLine($"[POS] Opened by: {SessionManager.GetCreatedByString()}");
            }
            else
            {
                MessageBox.Show("No active session. Please login.", "Session Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Void button state management
            btnVoidItem.Enabled = false;
            dgvCart.SelectionChanged += (s, ev) => { btnVoidItem.Enabled = dgvCart.SelectedRows.Count > 0; };

            // Wire up void button click event
            btnVoidItem.Click += VoidMenuItem_Click;

            // Setup context menu for right-click void
            SetupCartContextMenu();
        }

        private void DateTimeTimer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("MMM dd, yyyy  hh:mm:ss tt");
        }

        #region Service Management

        private void LoadServices()
        {
            try
            {
                cmbService.Items.Clear();
                cmbService.Items.Add("-- Select Service --");

                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return; // ✅ ADD THIS LINE

                    using (var cmd = new NpgsqlCommand(
                        "SELECT ServiceID, ServiceName, Price FROM Service ORDER BY ServiceName;", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbService.Items.Add(new ServiceItem
                            {
                                ServiceID = Convert.ToInt32(reader["ServiceID"]),
                                ServiceName = reader["ServiceName"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"])
                            });
                        }
                    }
                }

                cmbService.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[LoadServices] Error: {ex.Message}");
            }
        }

        private class ServiceItem
        {
            public int ServiceID { get; set; }
            public string ServiceName { get; set; }
            public decimal Price { get; set; }
            public override string ToString() => ServiceName;
        }

        private void BtnAddService_Click(object sender, EventArgs e)
        {
            var selectedService = cmbService.SelectedItem as ServiceItem;

            if (selectedService == null)
            {
                cmbService.Focus();
                return;
            }

            // Check if service already in cart using LINQ
            bool isDuplicate = dgvCart.Rows.Cast<DataGridViewRow>()
                .Any(r => r.Cells["colItemType"].Value?.ToString() == "Service" &&
                         Convert.ToInt32(r.Cells["colProductId"].Value) == selectedService.ServiceID);

            if (isDuplicate)
            {
                MessageBox.Show("This service is already in the cart.", "Duplicate Service",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbService.SelectedIndex = 0;
                cmbService.Focus();
                return;
            }

            // Add service to cart
            int rowIndex = dgvCart.Rows.Add(
                selectedService.ServiceID,
                selectedService.ServiceName,
                selectedService.Price,
                1,
                selectedService.Price
            );

            dgvCart.Rows[rowIndex].Cells["colItemType"].Value = "Service";
            dgvCart.Rows[rowIndex].Cells["colQty"].ReadOnly = true;
            dgvCart.Rows[rowIndex].Cells["colQty"].Style.BackColor = System.Drawing.Color.LightGray;

            UpdateTotals();

            MessageBox.Show($"{selectedService.ServiceName} added successfully!", "Service Added",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            cmbService.SelectedIndex = 0;
            cmbService.Focus();
        }

        #endregion

        #region Discount Management

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Please add items to cart first.", "Empty Cart",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SessionManager.IsAdmin)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"[Discount] Admin {SessionManager.CurrentUsername} accessing discount (no PIN required)");
                ShowDiscountForm();
            }
            else
            {
                using (var pinForm = new PINVerificationForm())
                {
                    if (pinForm.ShowDialog(this) == DialogResult.OK && pinForm.IsVerified)
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"[Discount] Authorized by {pinForm.VerifiedAdminName} for {SessionManager.CurrentUsername}");
                        ShowDiscountForm();
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"[Discount] Authorization cancelled by {SessionManager.CurrentUsername}");
                    }
                }
            }
        }

        private void ShowDiscountForm()
        {
            decimal currentSubtotal = Convert.ToDecimal(lblSubtotal.Text);

            using (var discountForm = new DiscountForm(currentSubtotal))
            {
                if (discountForm.ShowDialog(this) == DialogResult.OK)
                {
                    _transactionDiscount = discountForm.DiscountAmount;
                    UpdateTotals();

                    // ✅ AUDIT LOG: Determine who authorized the discount
                    string authorizedBy = SessionManager.IsAdmin ?
                        SessionManager.CurrentFullName :
                        "Admin (PIN verified)";

                    // ✅ AUDIT LOG: Log discount application
                    AuditLogger.LogDiscount(
                        discountForm.DiscountAmount,
                        currentSubtotal,
                        "Manual Discount", // or discountForm.DiscountType if available
                        authorizedBy,
                        "" // or discountForm.Reason if available
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"[Discount] Applied: {discountForm.DiscountAmount:C} by {SessionManager.GetCreatedByString()}, authorized by {authorizedBy}");
                }
            }
        }

        #endregion

        #region Item Void Management

        private void SetupCartContextMenu()
        {
            dgvCartContextMenu = new ContextMenuStrip();

            var voidMenuItem = new ToolStripMenuItem
            {
                Text = "Void Item / Reduce Quantity",
                ShortcutKeys = Keys.Delete
            };
            voidMenuItem.Click += VoidMenuItem_Click;

            dgvCartContextMenu.Items.Add(voidMenuItem);
            dgvCart.ContextMenuStrip = dgvCartContextMenu;

            dgvCart.CellMouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                {
                    dgvCart.ClearSelection();
                    dgvCart.Rows[e.RowIndex].Selected = true;
                    dgvCart.CurrentCell = dgvCart.Rows[e.RowIndex].Cells[0];
                }
            };
        }

        private void VoidMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to void.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvCart.SelectedRows[0];
            string itemName = selectedRow.Cells["colProductName"].Value?.ToString() ?? "Unknown";
            string itemType = selectedRow.Cells["colItemType"].Value?.ToString() ?? "Product";
            int currentQty = Convert.ToInt32(selectedRow.Cells["colQty"].Value ?? 1);
            decimal unitPrice = Convert.ToDecimal(selectedRow.Cells["colUnitPrice"].Value ?? 0m);
            decimal lineTotal = Convert.ToDecimal(selectedRow.Cells["colLineTotal"].Value ?? 0m);

            if (SessionManager.IsAdmin)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"[Void] Admin {SessionManager.CurrentUsername} accessing void (no PIN required)");
                ShowVoidOptions(selectedRow, itemName, itemType, currentQty, unitPrice, lineTotal, SessionManager.CurrentFullName);
            }
            else
            {
                using (var pinForm = new PINVerificationForm())
                {
                    if (pinForm.ShowDialog(this) == DialogResult.OK && pinForm.IsVerified)
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"[Void] Authorized by {pinForm.VerifiedAdminName} for {SessionManager.CurrentUsername}");
                        ShowVoidOptions(selectedRow, itemName, itemType, currentQty, unitPrice, lineTotal, pinForm.VerifiedAdminName);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"[Void] Authorization cancelled by {SessionManager.CurrentUsername}");
                    }
                }
            }
        }

        private void ShowVoidOptions(DataGridViewRow row, string itemName, string itemType,
            int currentQty, decimal unitPrice, decimal lineTotal, string authorizedBy)
        {
            if (itemType == "Service" || currentQty == 1)
            {
                ConfirmAndVoidItem(row, itemName, itemType, currentQty, unitPrice, lineTotal, authorizedBy, true);
                return;
            }

            using (var voidForm = new VoidQuantityForm(itemName, currentQty, unitPrice, lineTotal))
            {
                if (voidForm.ShowDialog(this) == DialogResult.OK)
                {
                    int qtyToVoid = voidForm.QuantityToVoid;
                    bool isFullVoid = voidForm.IsFullVoid;
                    decimal amountToVoid = qtyToVoid * unitPrice;

                    ConfirmAndVoidItem(row, itemName, itemType, qtyToVoid, unitPrice,
                        amountToVoid, authorizedBy, isFullVoid);
                }
            }
        }

        private void ConfirmAndVoidItem(DataGridViewRow row, string itemName, string itemType,
            int qtyToVoid, decimal unitPrice, decimal amountToVoid, string authorizedBy, bool isFullVoid)
        {
            int currentQty = Convert.ToInt32(row.Cells["colQty"].Value);

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to void?\n\n" +
                $"Item: {itemName}\n" +
                $"Quantity to void: {qtyToVoid} of {currentQty}\n" +
                $"Amount: ₱{amountToVoid:N2}\n\n" +
                $"This action will be logged.",
                isFullVoid ? "Confirm Full Item Void" : "Confirm Partial Void",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
            {
                System.Diagnostics.Debug.WriteLine($"[Void] User cancelled void confirmation for: {itemName}");
                return;
            }

            int productId = Convert.ToInt32(row.Cells["colProductId"].Value);

            if (isFullVoid)
            {
                dgvCart.Rows.Remove(row);
            }
            else
            {
                int newQty = currentQty - qtyToVoid;
                row.Cells["colQty"].Value = newQty;
                row.Cells["colLineTotal"].Value = newQty * unitPrice;
            }

            UpdateTotals();
            LogVoidAction(productId, itemName, itemType, qtyToVoid, unitPrice, amountToVoid, authorizedBy);

            string voidType = isFullVoid ? "fully voided" : $"reduced by {qtyToVoid}";
            MessageBox.Show(
                $"Item {voidType} successfully.\n\n" +
                $"Item: {itemName}\n" +
                $"Quantity voided: {qtyToVoid}\n" +
                $"Amount: ₱{amountToVoid:N2}\n" +
                $"Authorized by: {authorizedBy}",
                "Void Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            System.Diagnostics.Debug.WriteLine(
                $"[Void] {voidType}: {itemName} x{qtyToVoid} (₱{amountToVoid:N2}) " +
                $"by {SessionManager.CurrentUsername}, authorized by {authorizedBy}");
        }

        private void LogVoidAction(int productId, string itemName, string itemType,
           int quantity, decimal unitPrice, decimal lineTotal, string authorizedBy)
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return; // ✅ ADD THIS LINE

                    using (var cmd = new NpgsqlCommand(@"
                INSERT INTO VoidedItems (
                    ProductID, ItemName, ItemType, Quantity, UnitPrice, LineTotal, 
                    VoidedBy, AuthorizedBy, VoidReason, VoidedAt
                ) VALUES (
                    @ProductID, @ItemName, @ItemType, @Quantity, @UnitPrice, @LineTotal, 
                    @VoidedBy, @AuthorizedBy, @VoidReason, @VoidedAt
                );", conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@ItemName", itemName);
                        cmd.Parameters.AddWithValue("@ItemType", itemType);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                        cmd.Parameters.AddWithValue("@LineTotal", lineTotal);
                        cmd.Parameters.AddWithValue("@VoidedBy", SessionManager.CurrentFullName);
                        cmd.Parameters.AddWithValue("@AuthorizedBy", authorizedBy);
                        cmd.Parameters.AddWithValue("@VoidReason", "Pre-transaction void");
                        cmd.Parameters.AddWithValue("@VoidedAt", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }

                System.Diagnostics.Debug.WriteLine($"[Void] Logged to VoidedItems table: {itemName} x{quantity}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Void] Error logging void action: {ex.Message}");
            }
        }
        private void POSForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvCart.Focused && dgvCart.SelectedRows.Count > 0)
            {
                e.Handled = true;
                VoidMenuItem_Click(sender, e);
            }
        }

        #endregion

        #region Payment Method Management

        private void CmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isGCash = cmbPaymentMethod.SelectedItem?.ToString() == "GCash";

            txtReference.Enabled = isGCash;
            txtAmountPaid.Enabled = !isGCash;

            if (isGCash)
            {
                txtReference.Focus();
                decimal grandTotal = Convert.ToDecimal(lblGrandTotal.Text);
                txtAmountPaid.Text = grandTotal.ToString("N2");
            }
            else
            {
                txtReference.Clear();
                txtAmountPaid.Clear();
            }

            UpdateTotals();
        }

        #endregion

        #region Product Search and Add

        private string GenerateInvoiceNo()
        {

            try
            {
                string today = DateTime.Now.ToString("yyyyMMdd");
                int sequence = 1;

                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) // ✅ ADD THIS CHECK
                    {
                        // Fallback to timestamp-based invoice if no connection
                        return $"INV-{DateTime.Now:yyyyMMddHHmmss}";
                    }

                    using (var cmd = new NpgsqlCommand(@"
                SELECT COUNT(*) 
                FROM POS_Transactions
                WHERE TO_CHAR(CreatedAt, 'YYYYMMDD') = @Today;", conn))
                    {
                        cmd.Parameters.AddWithValue("@Today", today);
                        sequence += Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }
                }

                return $"INV-{today}-{sequence:D3}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[GenerateInvoiceNo] Error: {ex.Message}");
                return $"INV-{DateTime.Now:yyyyMMddHHmmss}";
            }
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string code = txtBarcode.Text.Trim();
                if (string.IsNullOrEmpty(code)) return;

                SearchAndAddProduct(code);

                txtBarcode.Clear();
                txtBarcode.Focus();
            }
        }

        private void SearchAndAddProduct(string barcode)
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return; // ✅ ADD THIS LINE

                    using (var cmd = new NpgsqlCommand(
                        "SELECT ProductID, ProductName, Price, Quantity " +
                        "FROM Products WHERE Barcode = @Barcode", conn))
                    {
                        cmd.Parameters.AddWithValue("@Barcode", barcode);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int productId = Convert.ToInt32(reader["ProductID"]);
                                string productName = reader["ProductName"].ToString();
                                decimal unitPrice = Convert.ToDecimal(reader["Price"]);
                                int stock = Convert.ToInt32(reader["Quantity"]);

                                // Check if product already in cart (LINQ)
                                var existingRow = dgvCart.Rows.Cast<DataGridViewRow>()
                                    .FirstOrDefault(r => r.Cells["colItemType"].Value?.ToString() == "Product" &&
                                                        Convert.ToInt32(r.Cells["colProductId"].Value) == productId);

                                if (existingRow != null)
                                {
                                    int currentQty = Convert.ToInt32(existingRow.Cells["colQty"].Value);
                                    if (currentQty + 1 > stock)
                                    {
                                        MessageBox.Show($"Only {stock} pcs available in stock.", "Stock Limit",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }

                                    existingRow.Cells["colQty"].Value = currentQty + 1;
                                    existingRow.Cells["colLineTotal"].Value = (currentQty + 1) * unitPrice;
                                    UpdateTotals();
                                    return;
                                }

                                if (stock < 1)
                                {
                                    MessageBox.Show("Product is out of stock.", "Stock Limit",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                int rowIndex = dgvCart.Rows.Add(productId, productName, unitPrice, 1, unitPrice);
                                dgvCart.Rows[rowIndex].Cells["colItemType"].Value = "Product";

                                UpdateTotals();
                            }
                            else
                            {
                                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching product: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[SearchAndAddProduct] Error: {ex.Message}");
            }
        }

        #endregion

        #region DataGridView Editing

        private void dgvCart_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCart.CurrentCell?.OwningColumn.Name == "colQty")
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress -= QtyColumn_KeyPress;
                    tb.KeyPress += QtyColumn_KeyPress;
                }
            }
        }

        private void dgvCart_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCart.IsCurrentCellDirty)
            {
                dgvCart.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void QtyColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvCart_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvCart.Columns[e.ColumnIndex].Name == "colQty" && e.RowIndex >= 0)
            {
                var row = dgvCart.Rows[e.RowIndex];
                if (int.TryParse(row.Cells["colQty"].Value?.ToString(), out int currentQty))
                {
                    _previousQty = currentQty;
                }
            }
        }

        private void dgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCart.Columns[e.ColumnIndex].Name == "colQty" && e.RowIndex >= 0)
            {
                var row = dgvCart.Rows[e.RowIndex];

                if (int.TryParse(row.Cells["colQty"].Value?.ToString(), out int currentQty))
                {
                    if (currentQty < _previousQty)
                    {
                        row.Cells["colQty"].Value = _previousQty;
                        decimal unitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);
                        row.Cells["colLineTotal"].Value = _previousQty * unitPrice;
                        UpdateTotals();

                        System.Diagnostics.Debug.WriteLine(
                            $"[QtyEdit] Reverted quantity from {currentQty} back to {_previousQty}");
                    }
                }
            }
        }

        private void dgvCart_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvCart.Columns[e.ColumnIndex].Name == "colQty" && e.RowIndex >= 0)
            {
                if (int.TryParse(e.FormattedValue.ToString(), out int newQty))
                {
                    if (newQty < 1)
                    {
                        MessageBox.Show(
                            "Quantity must be at least 1.\n\nTo remove items, use the Void Item button.",
                            "Invalid Quantity",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }

                    if (newQty < _previousQty)
                    {
                        MessageBox.Show(
                            "Manual quantity decrease is not allowed.\n\n" +
                            "To reduce or remove items, please use the Void Item button.\n" +
                            "This ensures proper authorization and audit logging.",
                            "Quantity Decrease Blocked",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }

                    var row = dgvCart.Rows[e.RowIndex];
                    string itemType = row.Cells["colItemType"].Value?.ToString();

                    if (itemType == "Product")
                    {
                        int productId = Convert.ToInt32(row.Cells["colProductId"].Value);
                        int stock = GetProductStock(productId);

                        if (newQty > stock)
                        {
                            MessageBox.Show(
                                $"Only {stock} pcs available in stock.\n\n" +
                                $"Current quantity: {_previousQty}\n" +
                                $"Maximum allowed: {stock}",
                                "Stock Limit Exceeded",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCart.Columns[e.ColumnIndex].Name == "colQty")
            {
                var row = dgvCart.Rows[e.RowIndex];
                string itemType = row.Cells["colItemType"].Value?.ToString();

                if (int.TryParse(row.Cells["colQty"].Value?.ToString(), out int qty) &&
                    decimal.TryParse(row.Cells["colUnitPrice"].Value?.ToString(), out decimal price))
                {
                    row.Cells["colLineTotal"].Value = qty * price;
                }
                else
                {
                    row.Cells["colQty"].Value = _previousQty;
                    decimal unitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);
                    row.Cells["colLineTotal"].Value = _previousQty * unitPrice;
                }

                UpdateTotals();
            }
        }

        private int GetProductStock(int productId)
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return 0; 

                    using (var cmd = new NpgsqlCommand("SELECT Quantity FROM Products WHERE ProductID = @ProductID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        var result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[GetProductStock] Error: {ex.Message}");
                return 0;
            }
        }

        #endregion

        #region Totals Computation

        private void UpdateTotals()
        {
            // Calculate subtotal from all items
            decimal subtotal = 0m;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.IsNewRow) continue;
                subtotal += Convert.ToDecimal(row.Cells["colLineTotal"].Value ?? 0m);
            }

            // Apply discount
            decimal discount = _transactionDiscount;
            decimal netAmount = subtotal - discount;

            // Calculate VATable Sales and VAT
            decimal vatableSales = netAmount / (1 + VAT_RATE);
            decimal vatAmount = vatableSales * VAT_RATE;
            decimal total = vatableSales + vatAmount; // Same as netAmount

            // Calculate payment and change
            decimal.TryParse(txtAmountPaid.Text, out decimal amountPaid);
            decimal change = Math.Max(0, amountPaid - total);

            // Update all labels
            lblSubtotal.Text = subtotal.ToString("N2");
            lblDiscount.Text = discount.ToString("N2");
            lblNetAmount.Text = netAmount.ToString("N2");
            lblVatableSales.Text = vatableSales.ToString("N2");
            lblVAT.Text = vatAmount.ToString("N2");
            lblGrandTotal.Text = total.ToString("N2");
            lblChange.Text = change.ToString("N2");

            // Auto-update GCash amount when total changes
            if (cmbPaymentMethod.SelectedItem?.ToString() == "GCash")
            {
                txtAmountPaid.Text = total.ToString("N2");
            }
        }

        #endregion

        #region Transaction Management

        private void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Session expired. Please login again.", "Authentication Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("No items in cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string customerName = txtCustomerName.Text.Trim();
            if (string.IsNullOrWhiteSpace(customerName))
            {
                MessageBox.Show(
                    "Customer name is required.\n\nPlease enter customer name before saving transaction.",
                    "Customer Name Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            decimal subtotal = Convert.ToDecimal(lblSubtotal.Text);
            decimal discountAmount = Convert.ToDecimal(lblDiscount.Text);
            decimal discountRate = subtotal > 0 ? (discountAmount / subtotal) * 100 : 0m;
            decimal netAmount = subtotal - discountAmount;

            // VAT Computation
            decimal vatableSales = netAmount / (1 + VAT_RATE);
            decimal vatAmount = vatableSales * VAT_RATE;
            decimal totalAmount = vatableSales + vatAmount;

            string paymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash";
            string referenceNo = paymentMethod == "GCash" ? txtReference.Text.Trim() : "";

            if (paymentMethod == "GCash" && string.IsNullOrEmpty(referenceNo))
            {
                MessageBox.Show("Please enter GCash reference number.", "Missing Reference",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReference.Focus();
                return;
            }

            decimal amountPaid;
            decimal change;

            if (paymentMethod == "GCash")
            {
                amountPaid = totalAmount;
                change = 0m;
            }
            else
            {
                amountPaid = string.IsNullOrEmpty(txtAmountPaid.Text) ? 0m : Convert.ToDecimal(txtAmountPaid.Text);
                change = amountPaid - totalAmount;

                if (amountPaid < totalAmount)
                {
                    MessageBox.Show("Insufficient payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string invoiceNo = GenerateInvoiceNo();
            string createdBy = SessionManager.GetCreatedByString();

            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return; // ✅ Connection check

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        long txnId = PosRepository.SaveProductTransaction(
                            conn, tran, invoiceNo, customerName, paymentMethod, referenceNo,
                            subtotal, discountRate, discountAmount, netAmount,
                            vatableSales, VAT_RATE, vatAmount, totalAmount, amountPaid, change,
                            createdBy, dgvCart
                        );

                        tran.Commit();

                        // ✅ AUDIT LOG: Log completed transaction
                        AuditLogger.LogTransaction(
                            (int)txnId,
                            totalAmount,
                            paymentMethod
                        );

                        // ✅ CHECK FOR LOW STOCK NOTIFICATIONS AFTER SALE
                        NotificationHelper.CheckAndGenerateNotifications();

                        // Success prompt
                        _transactionSaved = true;
                        btnPrintReceipt.Enabled = true;

                        var result = MessageBox.Show(
                            $"Transaction saved successfully!\n\n" +
                            $"Invoice: {invoiceNo}\n" +
                            $"Customer: {customerName}\n" +
                            $"Total: {totalAmount:C}\n" +
                            $"Payment: {paymentMethod}\n" +
                            $"Items: {dgvCart.Rows.Count}\n" +
                            $"Processed by: {createdBy}\n\n" +
                            $"Would you like to print the receipt now?",
                            "Transaction Saved",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        // ✅ If Yes → auto print
                        if (result == DialogResult.Yes)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                btnPrintReceipt.PerformClick();
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();

                        MessageBox.Show(
                            $"Error saving transaction:\n\n{ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        } 

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            dgvCart.Rows.Clear();

            txtBarcode.Clear();
            txtAmountPaid.Clear();
            txtReference.Clear();
            txtCustomerName.Clear();

            lblSubtotal.Text = "0.00";
            lblDiscount.Text = "0.00";
            lblNetAmount.Text = "0.00";
            lblVatableSales.Text = "0.00";
            lblVAT.Text = "0.00";
            lblGrandTotal.Text = "0.00";
            lblChange.Text = "0.00";

            _transactionDiscount = 0m;

            cmbPaymentMethod.SelectedIndex = 0; // Default to CASH
            txtReference.Enabled = false;
            txtAmountPaid.Enabled = true;

            cmbService.SelectedIndex = 0;

            txtInvoiceNo.Text = GenerateInvoiceNo();
            txtBarcode.Focus();
        }

        #endregion

        #region Form Events

        private void POSForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvCart.Rows.Count > 0)
            {
                var result = MessageBox.Show(
                    "You have items in the cart. Are you sure you want to close?",
                    "Unsaved Transaction",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (SessionManager.IsLoggedIn)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"[POS] Closed by: {SessionManager.GetCreatedByString()} " +
                    $"Session duration: {SessionManager.GetSessionDuration()}");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Check if there are unsaved items in cart
            if (dgvCart.Rows.Count > 0)
            {
                var result = MessageBox.Show(
                    "You have unsaved items in the cart.\n\n" +
                    "Are you sure you want to logout? All unsaved items will be lost.",
                    "Unsaved Transaction",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return; // Cancel logout
                }
            }

            // Confirm logout
            var confirmResult = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                SessionManager.ClearSession();
                this.Close();
            }
        }

        #endregion

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Reserved for future use
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCart.Rows.Count == 0)
                {
                    MessageBox.Show("No items to print. Please add items to cart first.",
                        "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ds = new SalesReceiptDataSet();
                var dt = ds.Receipt;

                // Compute Summary Values
                decimal subtotal = Convert.ToDecimal(lblSubtotal.Text);
                decimal discount = Convert.ToDecimal(lblDiscount.Text);
                decimal netAmount = subtotal - discount;
                decimal vatableSales = netAmount / (1 + VAT_RATE);
                decimal vatAmount = vatableSales * VAT_RATE;
                decimal totalAmount = Convert.ToDecimal(lblGrandTotal.Text);

                // ✅ Determine Amount Paid and Change Based on Payment Method
                decimal amountPaid;
                decimal change;

                if (cmbPaymentMethod.Text == "GCash")
                {
                    amountPaid = totalAmount; // Customer pays exact amount
                    change = 0m;
                }
                else
                {
                    amountPaid = string.IsNullOrEmpty(txtAmountPaid.Text) ? 0m : Convert.ToDecimal(txtAmountPaid.Text);
                    change = Convert.ToDecimal(lblChange.Text);
                }

                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.IsNewRow) continue;

                    dt.Rows.Add(
                        txtInvoiceNo.Text,
                        txtCustomerName.Text,
                        cmbPaymentMethod.Text,
                        DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"),
                        SessionManager.CurrentUsername,
                        row.Cells["colProductName"].Value?.ToString() ?? "",
                        row.Cells["colItemType"].Value?.ToString() ?? "",
                        Convert.ToInt32(row.Cells["colQty"].Value ?? 0),
                        Convert.ToDecimal(row.Cells["colUnitPrice"].Value ?? 0),
                        Convert.ToDecimal(row.Cells["colLineTotal"].Value ?? 0),
                        subtotal,
                        discount,
                        netAmount,
                        vatableSales,
                        vatAmount,
                        totalAmount,
                        amountPaid,
                        change
                    );
                }

                var viewer = new ReceiptViewerForm();
                viewer.ReceiptData = ds;
                viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error generating receipt:\n\n{ex.Message}",
                    "Print Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            btnNewTransaction.PerformClick();
        }

        private void btnDailysales_Click(object sender, EventArgs e)
        {
            // Check if there are unsaved items in cart
            if (dgvCart.Rows.Count > 0)
            {
                MessageBox.Show(
                    "You have unsaved items in the cart.\n\n" +
                    "Please complete or clear the current transaction before viewing Daily Sales.",
                    "Active Transaction",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return; // Block access to Daily Sales
            }

            // Proceed to show Daily Sales
            DailySalesControl dailySales = pnlCart.Controls.OfType<DailySalesControl>().FirstOrDefault();
            if (dailySales == null)
            {
                dailySales = new DailySalesControl();
                dailySales.Dock = DockStyle.Fill;
                pnlCart.Controls.Add(dailySales);
            }
            dailySales.BringToFront();

            // Disable specific controls
            pnlShowpayment.Enabled = false;
            pnlCustomerInfo.Enabled = false;
            btnNewTransaction.Enabled = false;
            btnAddDiscount.Enabled = false;
            btnVoidItem.Enabled = false;

            // Important: btnDailysales stays enabled
            btnDailysales.Enabled = true;
        }

        public void EnablePOSControls()
        {
            pnlShowpayment.Enabled = true;
            pnlCustomerInfo.Enabled = true;
            btnNewTransaction.Enabled = true;
            btnAddDiscount.Enabled = true;
            btnVoidItem.Enabled = true;
        }

        private void txtReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (Backspace, Delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlCustomerInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
