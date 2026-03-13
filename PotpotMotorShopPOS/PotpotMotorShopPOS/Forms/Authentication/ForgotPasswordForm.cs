using PotpotMotorShopPOS.Helpers;
using System;
using Npgsql;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Forms.Authentication
{
    public partial class ForgotPasswordForm : Form
    {
        private readonly string verifiedUsername;
        private bool isNewPasswordVisible = false;
        private bool isConfirmPasswordVisible = false;
        private string currentPasswordHash;
        private string currentSalt;

        public ForgotPasswordForm(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            verifiedUsername = username;

            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';

            isNewPasswordVisible = false;
            isConfirmPasswordVisible = false;

            picToggleNewPassword.Image = Properties.Resources.icon_closed_eye;
            picToggleConfirmPassword.Image = Properties.Resources.icon_closed_eye;

            txtNewPassword.PlaceholderText = "Enter new password";
            txtConfirmPassword.PlaceholderText = "Re-enter new password";

            successPanel.Visible = false;
            lblRules.Visible = false;

            LoadCurrentPassword();
            txtNewPassword.TextChanged += TxtNewPassword_TextChanged;
        }

        private void LoadCurrentPassword()
        {
            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return; // ✅ ADD THIS LINE

                using (var cmd = new NpgsqlCommand(
                    "SELECT password, salt FROM users WHERE username=@Username", conn))
                {
                    cmd.Parameters.AddWithValue("@Username", verifiedUsername);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentPasswordHash = reader["password"].ToString();
                            currentSalt = reader["salt"] == DBNull.Value ? null : reader["salt"].ToString();
                        }
                    }
                }
            }
        }

        private bool IsSameAsOldPassword(string newPassword)
        {
            if (string.IsNullOrEmpty(currentSalt) || string.IsNullOrEmpty(currentPasswordHash))
                return false;

            string newHash = HashPassword(newPassword, currentSalt);
            return newHash == currentPasswordHash;
        }

        private void TxtNewPassword_TextChanged(object sender, EventArgs e)
        {
            string pwd = txtNewPassword.Text;

            if (!string.IsNullOrEmpty(pwd) && txtNewPassword.PlaceholderForeColor == Color.Red)
            {
                txtNewPassword.PlaceholderText = "Enter new password";
                txtNewPassword.PlaceholderForeColor = Color.Gray;
            }

            if (string.IsNullOrEmpty(pwd))
            {
                lblRules.Visible = false;
                return;
            }

            lblRules.Visible = true;

            if (IsSameAsOldPassword(pwd))
            {
                lblRules.ForeColor = Color.Red;
                lblRules.Text = "• Cannot use your previous password";
                return;
            }

            bool lengthOk = pwd.Length >= 6 && pwd.Length <= 15;
            bool upperOk = Regex.IsMatch(pwd, "[A-Z]");
            bool numberOk = Regex.IsMatch(pwd, "[0-9]");
            bool noSpaceOk = !pwd.Contains(" ");
            bool symbolOk = Regex.IsMatch(pwd, @"[!@#$%^&*(),.?""':{}|<>]");

            if (!lengthOk)
            {
                lblRules.ForeColor = Color.Red;
                lblRules.Text = "• Password must be 6–15 characters";
            }
            else if (!upperOk)
            {
                lblRules.ForeColor = Color.Red;
                lblRules.Text = "• Must contain at least 1 uppercase";
            }
            else if (!numberOk)
            {
                lblRules.ForeColor = Color.Red;
                lblRules.Text = "• Must contain at least 1 number";
            }
            else if (!noSpaceOk)
            {
                lblRules.ForeColor = Color.Red;
                lblRules.Text = "• No spaces allowed";
            }
            else if (!symbolOk)
            {
                lblRules.ForeColor = Color.Red;
                lblRules.Text = "• Must contain at least 1 symbol (!@#$ etc.)";
            }
            else
            {
                lblRules.ForeColor = Color.Green;
                lblRules.Text = "✔ All rules satisfied";
            }
        }

        private async void btnResetPassword_Click_1(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsSameAsOldPassword(newPassword))
            {
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
                txtNewPassword.PlaceholderText = "Don't use old password";
                txtNewPassword.PlaceholderForeColor = Color.Red;
                txtNewPassword.Focus();

                Timer resetTimer = new Timer();
                resetTimer.Interval = 3000;
                resetTimer.Tick += (s, ev) =>
                {
                    txtNewPassword.PlaceholderText = "Enter new password";
                    txtNewPassword.PlaceholderForeColor = Color.Gray;
                    resetTimer.Stop();
                    resetTimer.Dispose();
                };
                resetTimer.Start();
                return;
            }

            if (!(newPassword.Length >= 6 && newPassword.Length <= 15) ||
                !Regex.IsMatch(newPassword, "[A-Z]") ||
                !Regex.IsMatch(newPassword, "[0-9]") ||
                newPassword.Contains(" ") ||
                !Regex.IsMatch(newPassword, @"[!@#$%^&*(),.?""':{}|<>]"))
            {
                MessageBox.Show("Password does not meet the rules.", "Invalid Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Mismatch",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string salt = Guid.NewGuid().ToString("N");
            string hashedPassword = HashPassword(newPassword, salt);
            bool success = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        if (conn == null) // ✅ ADD THIS CHECK
                        {
                            success = false;
                            return;
                        }

                        using (var cmd = new NpgsqlCommand(
                            "UPDATE users SET password=@Password, salt=@Salt, failedattempts=0, isactive=TRUE " +
                            "WHERE username=@Username", conn))
                        {
                            cmd.Parameters.AddWithValue("@Password", hashedPassword);
                            cmd.Parameters.AddWithValue("@Salt", salt);
                            cmd.Parameters.AddWithValue("@Username", verifiedUsername);

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                success = true;
                            }
                        }
                    }
                });
            },
            minimumDelayMs: 2000,
            loadingText: "Resetting password Please Wait!...");

            if (success)
            {
                successPanel.Visible = true;
                successPanel.BringToFront();
            }
            else
            {
                MessageBox.Show("Error resetting password. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                return Convert.ToBase64String(bytes);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            var loginForm = new LoginForm(verifiedUsername);
            loginForm.StartPosition = FormStartPosition.Manual;

            int startX = this.Right;
            int targetX = this.Left + (this.Width - loginForm.Width) / 2;
            int y = this.Top + (this.Height - loginForm.Height) / 2;

            loginForm.Location = new Point(startX, y);
            loginForm.Show();
            this.Enabled = false;

            Timer slideTimer = new Timer();
            slideTimer.Interval = 10;
            int step = 20;

            slideTimer.Tick += (s, ev) =>
            {
                if (loginForm.Left > targetX)
                {
                    loginForm.Left -= step;
                }
                else
                {
                    loginForm.Left = targetX;
                    slideTimer.Stop();
                    slideTimer.Dispose();
                }
            };
            slideTimer.Start();

            loginForm.FormClosed += (s, ev) =>
            {
                this.Enabled = true;
                this.Close();
            };
        }

        private void picToggleConfirmPassword_Click(object sender, EventArgs e)
        {
            isConfirmPasswordVisible = !isConfirmPasswordVisible;
            txtConfirmPassword.PasswordChar = isConfirmPasswordVisible ? '\0' : '*';
            picToggleConfirmPassword.Image = isConfirmPasswordVisible
                ? Properties.Resources.icon_open_eye
                : Properties.Resources.icon_closed_eye;
        }

        private void picToggleNewPassword_Click(object sender, EventArgs e)
        {
            isNewPasswordVisible = !isNewPasswordVisible;
            txtNewPassword.PasswordChar = isNewPasswordVisible ? '\0' : '*';
            picToggleNewPassword.Image = isNewPasswordVisible
                ? Properties.Resources.icon_open_eye
                : Properties.Resources.icon_closed_eye;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to go back? Any unsaved changes will be lost.",
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