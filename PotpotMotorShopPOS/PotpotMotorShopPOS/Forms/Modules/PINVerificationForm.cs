using PotpotMotorShopPOS.Helpers;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Forms.Modules
{
    public partial class PINVerificationForm : Form
    {
        private int _attemptCount = 0;
        private const int MAX_ATTEMPTS = 3;

        public bool IsVerified { get; private set; } = false;
        public string VerifiedAdminName { get; private set; } = "";

        public PINVerificationForm()
        {
            InitializeComponent();

            txtPIN.MaxLength = 4; // ✅ 4 digits only
            txtPIN.PasswordChar = '•';
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.DialogResult = DialogResult.Cancel;

            // Auto-focus on PIN textbox
            this.Shown += (s, e) => txtPIN.Focus();
        }


        private void btnVerify_Click(object sender, EventArgs e)
        {
            string pin = txtPIN.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(pin))
            {
                ShowError("Please enter a PIN.");
                return;
            }

            // ✅ Must be exactly 4 digits
            if (pin.Length != 4)
            {
                ShowError("PIN must be exactly 4 digits.");
                txtPIN.Clear();
                txtPIN.Focus();
                return;
            }

            // Must be numbers only
            if (!int.TryParse(pin, out _))
            {
                ShowError("PIN must contain only numbers.");
                txtPIN.Clear();
                txtPIN.Focus();
                return;
            }

            // Verify PIN against database
            if (VerifyAdminPIN(pin))
            {
                IsVerified = true;
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = $"✓ Verified as {VerifiedAdminName}";

                System.Diagnostics.Debug.WriteLine(
                    $"[PIN] Discount authorized by {VerifiedAdminName} " +
                    $"(requested by {SessionManager.CurrentUsername})");

                this.DialogResult = DialogResult.OK; // ✅ This overrides the default Cancel
            }
            else
            {
                _attemptCount++;
                HandleFailedAttempt();
            }
        }

        private bool VerifyAdminPIN(string pin)
        {
            string pinHash = HashPIN(pin);

            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            using (var cmd = new NpgsqlCommand(
                "SELECT username, fullname FROM users " +
                "WHERE role='Admin' AND adminpinhash=@PINHash AND isactive=true", conn))
            {
                cmd.Parameters.AddWithValue("@PINHash", pinHash);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        VerifiedAdminName = reader["fullname"].ToString();
                        return true;
                    }
                }
            }

            return false;
        }

        private void HandleFailedAttempt()
        {
            int remaining = MAX_ATTEMPTS - _attemptCount;

            if (remaining > 0)
            {
                ShowError($"Incorrect PIN. {remaining} attempt(s) remaining.");
                txtPIN.Clear();
                txtPIN.Focus();
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "✗ Maximum attempts reached. Access denied.";

                System.Diagnostics.Debug.WriteLine(
                    $"[PIN] Failed verification attempts by {SessionManager.CurrentUsername}");

                txtPIN.Enabled = false;
                btnVerify.Enabled = false;
                btnCancel.Text = "Close";

                MessageBox.Show(
                    "Maximum PIN attempts exceeded.\nDiscount operation cancelled.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // DialogResult is already Cancel, just close
                this.Close();
            }
        }

        private void ShowError(string message)
        {
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = $"✗ {message}";
        }

        private string HashPIN(string pin)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pin));
                return Convert.ToBase64String(bytes);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnVerify.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                btnCancel.PerformClick();
            }
        }
    }
}