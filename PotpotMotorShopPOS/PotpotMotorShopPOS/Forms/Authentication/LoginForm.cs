using Guna.UI2.WinForms;
using Npgsql;
using PotpotMotorShopPOS.Forms.POS;
using PotpotMotorShopPOS.Helpers;
using PotpotMotorShopPOS.Views.Authentication;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Forms.Authentication
{
    public partial class LoginForm : Form
    {
        private bool isPasswordVisible = false;

        public LoginForm()
        {
            InitializeComponent();

            // Initial UI setup
            txtPassword.PasswordChar = '*';
            picTogglePassword.Image = Properties.Resources.icon_closed_eye;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = btnLogin;

            txtUsername.MaxLength = 10;
            txtPassword.MaxLength = 15;

            // ✅ Clear any existing session when returning to login
            if (SessionManager.IsLoggedIn)
            {
                // ✅ LOG LOGOUT before clearing session
                AuditLogger.LogLogout(SessionManager.CurrentUsername);
                SessionManager.ClearSession();
            }
        }

        // ✅ Overloaded constructor that accepts username
        public LoginForm(string prefillUsername)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (!string.IsNullOrEmpty(prefillUsername))
            {
                txtUsername.Text = prefillUsername;
                lblWelcome.Text = $"Hello {prefillUsername}, welcome back!";
                lblWelcome.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                txtPassword.Focus();
            }
            else
            {
                lblWelcome.Text = "Welcome! Please log in.";
                lblWelcome.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }

            // ✅ Clear session on return
            if (SessionManager.IsLoggedIn)
            {
                // ✅ LOG LOGOUT before clearing session
                AuditLogger.LogLogout(SessionManager.CurrentUsername);
                SessionManager.ClearSession();
            }
        }

        // ✅ AUTO-FOCUS: Set focus to username when form is shown
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Check if username is empty, focus on username; otherwise focus on password
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Focus();
            }
            else
            {
                txtPassword.Focus();
            }
        }

        private void ResetFieldStyles()
        {
            txtUsername.PlaceholderText = "Enter your username";
            txtPassword.PlaceholderText = "Enter your password";
        }

        private void ShowInlineError(Guna2TextBox txt, string message)
        {
            txt.Clear();
            txt.PlaceholderText = message;
            txt.PlaceholderForeColor = Color.IndianRed;
            txt.BorderColor = Color.IndianRed;
        }

        private void picTogglePassword_Click(object sender, EventArgs e) => TogglePasswordVisibility();

        private void TogglePasswordVisibility()
        {
            isPasswordVisible = !isPasswordVisible;
            txtPassword.PasswordChar = isPasswordVisible ? '\0' : '*';
            picTogglePassword.Image = isPasswordVisible
                ? Properties.Resources.icon_open_eye
                : Properties.Resources.icon_closed_eye;
        }

        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            ResetFieldStyles();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                ShowInlineError(txtUsername, "Username is required");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowInlineError(txtPassword, "Password is required");
                return;
            }

            await AuthenticateUserAsync(username, password);
        }

        private async Task AuthenticateUserAsync(string username, string password)
        {
            bool success = false;
            string userRole = "";
            int userId = 0;
            string fullname = "";
            bool connectionFailed = false;

            // ✅ CHECK CONNECTION FIRST (BEFORE LOADING)
            NpgsqlConnection testConn = null;
            try
            {
                testConn = ServerDatabase.GetConnection();
                if (testConn == null)
                {
                    connectionFailed = true;
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Cannot connect to server. Please check your network.";
                    return;
                }
            }
            catch (Exception ex)
            {
                connectionFailed = true;
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Database connection error.";
                System.Diagnostics.Debug.WriteLine($"[Login] Connection test failed: {ex.Message}");
                return;
            }
            finally
            {
                testConn?.Close();
                testConn?.Dispose();
            }

            if (connectionFailed)
                return;

            // ✅ NOW PROCEED WITH LOADING (Connection is OK)
            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        if (conn == null)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lblStatus.ForeColor = Color.Red;
                                lblStatus.Text = "Cannot connect to server. Please check your network.";
                            }));
                            return;
                        }

                        using (var cmd = new NpgsqlCommand(
                            "SELECT UserID, Username, Fullname, Role, Password, Salt, IsActive, FailedAttempts " +
                            "FROM Users WHERE Username=@Username", conn))
                        {
                            cmd.Parameters.AddWithValue("@Username", username);

                            using (var reader = cmd.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    AuditLogger.LogLogin(username, false);

                                    this.Invoke(new Action(() =>
                                    {
                                        ShowInlineError(txtUsername, "Username not found");
                                        lblStatus.ForeColor = Color.Red;
                                        lblStatus.Text = "Invalid username.";
                                    }));
                                    return;
                                }

                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                if (!isActive)
                                {
                                    AuditLogger.Log("LOGIN_FAILED", "Users", null,
                                        $"Login attempt on locked account: {username}");

                                    this.Invoke(new Action(() =>
                                    {
                                        lblStatus.ForeColor = Color.Red;
                                        lblStatus.Text = "Account is locked. Contact admin to unlock.";
                                        DisableLoginControls();
                                    }));
                                    return;
                                }

                                userId = Convert.ToInt32(reader["UserID"]);
                                fullname = reader["Fullname"].ToString();
                                userRole = reader["Role"].ToString();
                                string storedPassword = reader["Password"].ToString();
                                string storedSalt = reader["Salt"] == DBNull.Value ? null : reader["Salt"].ToString();

                                bool passwordMatch = !string.IsNullOrEmpty(storedSalt)
                                    ? HashPassword(password, storedSalt) == storedPassword
                                    : password == storedPassword;

                                reader.Close();

                                if (passwordMatch)
                                {
                                    ResetFailedAttempts(conn, username);
                                    SessionManager.SetCurrentUser(userId, username, fullname, userRole);

                                    AuditLogger.LogLogin(username, true);

                                    this.Invoke(new Action(() =>
                                    {
                                        lblStatus.ForeColor = Color.Green;
                                        lblStatus.Text = $"Welcome {fullname}!";
                                    }));

                                    success = true;
                                }
                                else
                                {
                                    AuditLogger.LogLogin(username, false);

                                    this.Invoke(new Action(() =>
                                    {
                                        HandleFailedLogin(conn, username, txtPassword, "Incorrect password");
                                    }));
                                }
                            }
                        }
                    }
                });
            },
            minimumDelayMs: 1500,
            loadingText: "User Authenticating Please Wait!...");

            if (success)
            {
                await Task.Delay(100);
                this.Hide();

                Form targetForm = (Form)(userRole.Equals("Admin", StringComparison.OrdinalIgnoreCase)
                    ? (Form)new MainForm()
                    : (Form)new POSForm());

                targetForm.FormClosed += (s, e) =>
                {
                    if (SessionManager.IsLoggedIn)
                    {
                        AuditLogger.LogLogout(SessionManager.CurrentUsername);
                    }

                    SessionManager.ClearSession();
                    this.Show();
                    ResetLoginForm();
                };

                targetForm.ShowDialog();
            }
        }

        private void ResetFailedAttempts(NpgsqlConnection conn, string username)
        {
            using (var resetCmd = new NpgsqlCommand(
                "UPDATE Users SET FailedAttempts = 0 WHERE Username = @Username", conn))
            {
                resetCmd.Parameters.AddWithValue("@Username", username);
                resetCmd.ExecuteNonQuery();
            }
        }

        private void HandleFailedLogin(NpgsqlConnection conn, string username, Guna2TextBox txt, string message)
        {
            int attempts = 0;

            using (var updateCmd = new NpgsqlCommand(
                "UPDATE Users SET FailedAttempts = FailedAttempts + 1 WHERE Username = @Username", conn))
            {
                updateCmd.Parameters.AddWithValue("@Username", username);
                updateCmd.ExecuteNonQuery();
            }

            using (var selectCmd = new NpgsqlCommand(
                "SELECT FailedAttempts FROM Users WHERE Username = @Username", conn))
            {
                selectCmd.Parameters.AddWithValue("@Username", username);
                using (var reader = selectCmd.ExecuteReader())
                {
                    if (reader.Read())
                        attempts = Convert.ToInt32(reader["FailedAttempts"]);
                }
            }

            ShowInlineError(txt, message);

            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = $"{message}. Attempt {attempts} of 3.";

            System.Diagnostics.Debug.WriteLine(
                $"[Login] FAILED: {username} - Attempt {attempts}/3");

            if (attempts >= 3)
            {
                using (var lockCmd = new NpgsqlCommand(
                    "UPDATE Users SET IsActive = false WHERE Username = @Username", conn))
                {
                    lockCmd.Parameters.AddWithValue("@Username", username);
                    lockCmd.ExecuteNonQuery();
                }

                // ✅ LOG ACCOUNT LOCK
                AuditLogger.Log("ACCOUNT_LOCKED", "Users", null,
                    $"Account '{username}' locked after 3 failed login attempts");

                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Account locked after 3 failed attempts.";
                DisableLoginControls();

                System.Diagnostics.Debug.WriteLine(
                    $"[Login] LOCKED: {username} - Account disabled");
            }
        }

        private void DisableLoginControls()
        {
            btnLogin.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void ResetLoginForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            lblStatus.Text = "";
            ResetFieldStyles();

            btnLogin.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;

            txtUsername.Focus();
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password + salt));
                return Convert.ToBase64String(bytes);
            }
        }

        private void ShowVerifyFormWithSlide()
        {
            this.Hide();

            var verifyForm = new VerifyForm();
            verifyForm.StartPosition = FormStartPosition.Manual;

            int startX = this.Right;
            int targetX = this.Left + (this.Width - verifyForm.Width) / 2;
            int y = this.Top + (this.Height - verifyForm.Height) / 2;

            verifyForm.Location = new Point(startX, y);
            verifyForm.Show();

            this.Enabled = false;

            Timer slideTimer = new Timer();
            slideTimer.Interval = 10;
            int step = 20;

            slideTimer.Tick += (s, e) =>
            {
                if (verifyForm.Left > targetX)
                {
                    verifyForm.Left -= step;
                }
                else
                {
                    verifyForm.Left = targetX;
                    slideTimer.Stop();
                    slideTimer.Dispose();
                }
            };
            slideTimer.Start();

            verifyForm.FormClosed += (s, e) =>
            {
                this.Enabled = true;
                this.Show();
            };
        }

        private async void LblCantSignIn_Click(object sender, EventArgs e)
        {
            LblCantSignIn.Enabled = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Delay(800);
            }, minimumDelayMs: 800, loadingText: "Loading...");

            LblCantSignIn.Enabled = true;
            ShowVerifyFormWithSlide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to exit the system?",
                               "Confirm Exit",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // ✅ LOG LOGOUT before exiting
                if (SessionManager.IsLoggedIn)
                {
                    AuditLogger.LogLogout(SessionManager.CurrentUsername);
                    SessionManager.ClearSession();
                }

                // ✅ Close all forms and exit the entire application
                Application.Exit();
            }
        }
    }
}