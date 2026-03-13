using PotpotMotorShopPOS.Helpers;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Forms.Authentication
{
    public partial class VerifyForm : Form
    {
        private string verifiedUsername;

        public VerifyForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            verifysuccessPanel.Visible = false; // hide success panel initially
        }

        // Reset styles to normal
        private void ResetFieldStyles()
        {
            txtFullName.PlaceholderText = "Enter your full name";
            txtFullName.PlaceholderForeColor = Color.Gray;
            txtFullName.BorderColor = Color.Silver;

            txtSecurityAnswer.PlaceholderText = "Enter your answer";
            txtSecurityAnswer.PlaceholderForeColor = Color.Gray;
            txtSecurityAnswer.BorderColor = Color.Silver;

            cmbSecurityQuestion.BorderColor = Color.Silver;

            lblStatus.ForeColor = Color.Gray;
            lblStatus.Text = "";
        }

        // Show inline error inside Guna2TextBox
        private void ShowInlineError(Guna2TextBox txt, string message)
        {
            txt.Clear();
            txt.PlaceholderText = message;
            txt.PlaceholderForeColor = Color.IndianRed;
            txt.BorderColor = Color.IndianRed;
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            ResetFieldStyles();

            string fullName = txtFullName.Text.Trim();
            string question = cmbSecurityQuestion.SelectedItem?.ToString();
            string answer = txtSecurityAnswer.Text.Trim();

            // Step 0: Basic empty checks (inline only)
            if (string.IsNullOrEmpty(fullName))
            {
                ShowInlineError(txtFullName, "Full name required");
                return;
            }
            if (string.IsNullOrEmpty(question))
            {
                cmbSecurityQuestion.BorderColor = Color.IndianRed;
                return;
            }
            if (string.IsNullOrEmpty(answer))
            {
                ShowInlineError(txtSecurityAnswer, "Answer required");
                return;
            }

            bool success = false;

            // 🔹 Show loading overlay while verifying
            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        if (conn == null) // ✅ ADD THIS CHECK
                        {
                            this.Invoke(new Action(() =>
                            {
                                lblStatus.ForeColor = Color.Red;
                                lblStatus.Text = "Connection error. Please try again.";
                                MessageBox.Show(
                                    "Unable to connect to the database.\n\n" +
                                    "Please check your internet connection and try again.",
                                    "Connection Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }));
                            return;
                        }

                        try
                        {
                            // Step 1: Check FullName
                            string dbQuestion = null;
                            using (var cmd = new NpgsqlCommand(
                                "SELECT Username, SecurityQuestion FROM Users WHERE Fullname=@Fullname", conn))
                            {
                                cmd.Parameters.AddWithValue("@Fullname", fullName);
                                using (var reader = cmd.ExecuteReader())
                                {
                                    if (!reader.Read())
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            ShowInlineError(txtFullName, "Invalid full name");
                                            lblStatus.ForeColor = Color.Red;
                                            lblStatus.Text = "Verification failed.";
                                        }));
                                        return;
                                    }
                                    verifiedUsername = reader["Username"].ToString();
                                    dbQuestion = reader["SecurityQuestion"].ToString();
                                }
                            }

                            // Step 2: Check Security Question
                            if (!string.Equals(dbQuestion, question, StringComparison.OrdinalIgnoreCase))
                            {
                                this.Invoke(new Action(() =>
                                {
                                    cmbSecurityQuestion.BorderColor = Color.IndianRed;
                                    lblStatus.ForeColor = Color.Red;
                                    lblStatus.Text = "Verification failed.";
                                }));
                                return;
                            }

                            // Step 3: Check Security Answer
                            using (var cmd = new NpgsqlCommand(
                                "SELECT COUNT(*) FROM Users WHERE Fullname=@Fullname AND SecurityQuestion=@Q AND SecurityAnswer=@A", conn))
                            {
                                cmd.Parameters.AddWithValue("@Fullname", fullName);
                                cmd.Parameters.AddWithValue("@Q", question);
                                cmd.Parameters.AddWithValue("@A", answer);

                                int count = Convert.ToInt32(cmd.ExecuteScalar());
                                if (count > 0)
                                {
                                    success = true;
                                }
                                else
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        ShowInlineError(txtSecurityAnswer, "Incorrect answer");
                                        lblStatus.ForeColor = Color.Red;
                                        lblStatus.Text = "Verification failed.";
                                    }));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lblStatus.ForeColor = Color.Red;
                                lblStatus.Text = "Error during verification.";
                                MessageBox.Show(
                                    $"An error occurred:\n\n{ex.Message}",
                                    "Verification Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }));
                        }
                    }
                });
            },
            minimumDelayMs: 1500,
            loadingText: "Verifying your details Please Wait!...");

            // 🔹 After loading, show success panel if verified
            if (success)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Verification successful!";
                verifysuccessPanel.Visible = true;
                verifysuccessPanel.BringToFront();
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            var forgotForm = new ForgotPasswordForm(verifiedUsername);
            forgotForm.StartPosition = FormStartPosition.Manual;

            // Position off-screen to the right
            int startX = this.Right;
            int targetX = this.Left + (this.Width - forgotForm.Width) / 2;
            int y = this.Top + (this.Height - forgotForm.Height) / 2;

            forgotForm.Location = new Point(startX, y);

            // Show modeless so we can animate
            forgotForm.Show();

            // Disable VerifyForm to simulate modal behavior
            this.Enabled = false;

            Timer slideTimer = new Timer();
            slideTimer.Interval = 10; // ms per tick
            int step = 20;            // pixels per tick

            slideTimer.Tick += (s, ev) =>
            {
                if (forgotForm.Left > targetX)
                {
                    forgotForm.Left -= step;
                }
                else
                {
                    forgotForm.Left = targetX;
                    slideTimer.Stop();
                    slideTimer.Dispose();
                }
            };
            slideTimer.Start();

            // When ForgotPasswordForm closes, re-enable parent and close VerifyForm
            forgotForm.FormClosed += (s, ev) =>
            {
                this.Enabled = true;
                this.Close();
            };
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to go back? Any unsaved changes will be lost.",
                                  "Confirm",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Close(); // ✅ Automatic babalik sa Login (because ShowDialog)
            }
        }
    }
}