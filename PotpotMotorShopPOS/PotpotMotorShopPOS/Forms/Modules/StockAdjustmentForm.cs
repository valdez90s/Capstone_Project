using System;
using System.Windows.Forms;
using PotpotMotorShopPOS.Helpers;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Forms.Modules
{
    public partial class StockAdjustmentForm : Form
    {
        private int _productId;
        private string _barcode;
        private string _productName;
        private int _stockOnHand;

        public StockAdjustmentForm()
        {
            InitializeComponent();
        }

        // ✅ Constructor with ProductID + Barcode
        public StockAdjustmentForm(int productId, string barcode, string productName, int stockOnHand)
        {
            InitializeComponent();

            _productId = productId;
            _barcode = barcode;
            _productName = productName;
            _stockOnHand = stockOnHand;

            // auto-fill UI fields
            txtProductID.Text = _productId.ToString();
            txtBarcode.Text = _barcode;
            txtProductName.Text = _productName;
            txtCurrentStock.Text = _stockOnHand.ToString();

            // show current logged-in user
            txtUser.Text = SessionManager.GetCreatedByString();
        }

        private void StockAdjustmentForm_Load(object sender, EventArgs e)
        {
            txtReferenceNo.Text = GenerateReferenceNo();
            cmbAction.SelectedIndex = 0; // default to "Add to Inventory"

            // ✅ Populate AdjustmentType dropdown
            cmbAdjustmentType.Items.Clear();
            cmbAdjustmentType.Items.AddRange(new string[]
            {
                "DAMAGED",
                "LOST",
                "MANUAL"
            });
            cmbAdjustmentType.SelectedIndex = 0;
        }

        private string GenerateReferenceNo()
        {
            string prefix = "ADJ-" + DateTime.Now.ToString("yyyyMMdd") + "-";
            int nextNumber = 1;

            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) // ✅ ADDED NULL CHECK
                {
                    // ✅ Fallback to timestamp-based reference if no connection
                    return prefix + DateTime.Now.ToString("HHmmss");
                }

                try
                {
                    string query = @"SELECT referenceno  
                             FROM stockadjustments  
                             WHERE referenceno LIKE @Prefix || '%'  
                             ORDER BY adjustmentid DESC LIMIT 1";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Prefix", prefix);
                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            string lastRef = result.ToString();
                            string[] parts = lastRef.Split('-');
                            if (parts.Length == 3 && int.TryParse(parts[2], out int lastNumber))
                            {
                                nextNumber = lastNumber + 1;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // ✅ Log error and use fallback
                    System.Diagnostics.Debug.WriteLine($"[GenerateReferenceNo] Error: {ex.Message}");
                    return prefix + DateTime.Now.ToString("HHmmss");
                }
            }

            return prefix + nextNumber.ToString("D4");
        }

        // ✅ Save button click event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int adjustment = (int)numQuantityAdjusted.Value;

                if (adjustment == 0)
                {
                    MessageBox.Show("Please enter a valid adjustment quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbAction.Text))
                {
                    MessageBox.Show("Please select an action.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbAdjustmentType.Text))
                {
                    MessageBox.Show("Please select an adjustment type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtReason.Text))
                {
                    MessageBox.Show("Please provide a reason for the adjustment.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Compute new stock
                int newStock = _stockOnHand;
                string command = "";

                if (cmbAction.Text == "Add to Inventory")
                {
                    newStock += adjustment;
                    command = "ADD";
                }
                else if (cmbAction.Text == "Removed from Inventory")
                {
                    newStock -= adjustment;
                    command = "REMOVE";
                }

                if (newStock < 0)
                {
                    MessageBox.Show("Stock cannot go below zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return; // ✅ Connection check

                    using (var tran = conn.BeginTransaction())
                    {
                        // 1. Insert into StockAdjustments log
                        string insertLog = @"INSERT INTO stockadjustments  
                    (referenceno, productid, barcode, productname, quantitybefore, quantityadjusted, quantityafter, command, adjustmenttype, remark, adjustmentdate, username)  
                    VALUES (@RefNo, @ProductID, @Barcode, @ProductName, @QtyBefore, @QtyAdjusted, @QtyAfter, @Command, @AdjustmentType, @Remark, @Date, @UserName)";

                        using (var cmd = new NpgsqlCommand(insertLog, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@RefNo", txtReferenceNo.Text);
                            cmd.Parameters.AddWithValue("@ProductID", _productId);
                            cmd.Parameters.AddWithValue("@Barcode", _barcode);
                            cmd.Parameters.AddWithValue("@ProductName", _productName);
                            cmd.Parameters.AddWithValue("@QtyBefore", _stockOnHand);
                            cmd.Parameters.AddWithValue("@QtyAdjusted", adjustment);
                            cmd.Parameters.AddWithValue("@QtyAfter", newStock);
                            cmd.Parameters.AddWithValue("@Command", command);
                            cmd.Parameters.AddWithValue("@AdjustmentType", cmbAdjustmentType.Text);
                            cmd.Parameters.AddWithValue("@Remark", txtReason.Text.Trim());
                            cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@UserName", SessionManager.GetCreatedByString());

                            cmd.ExecuteNonQuery();
                        }

                        // 2. Update Products table
                        string updateProduct = @"UPDATE products  
                                         SET quantity = @NewStock, updatedby = @UserName, updatedat = @Date  
                                         WHERE productid = @ProductID";

                        using (var cmd = new NpgsqlCommand(updateProduct, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@NewStock", newStock);
                            cmd.Parameters.AddWithValue("@UserName", SessionManager.GetCreatedByString());
                            cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@ProductID", _productId);

                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                }

                // ✅ LOG STOCK ADJUSTMENT TO AUDIT LOGS
                AuditLogger.LogStockAdjustment(
                    _productId,
                    _productName,
                    _stockOnHand,
                    newStock,
                    cmbAdjustmentType.Text,
                    txtReason.Text.Trim()
                );

                // ✅ CHECK FOR NOTIFICATIONS AFTER ADJUSTMENT
                NotificationHelper.CheckAndGenerateNotifications();

                MessageBox.Show("Stock adjustment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving adjustment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StockAdjustmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK) return;

            var confirm = MessageBox.Show(
                "Are you sure you want to close without saving?",
                "Confirm Close",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // optional
        }
    }
}