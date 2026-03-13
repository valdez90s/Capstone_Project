using Npgsql;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Views.Modules
{
    public partial class UserManagementForm : Form
    {
        public event Action OnUserAdded;
        public event Action OnUserUpdated;
        private bool isPasswordVisible = false;
        private bool isAnswerVisible = false;

        private string _userId;

        // Constructor for Add
        public UserManagementForm()
        {
            InitializeComponent();

            txtPassword.PasswordChar = '*';
            txtSecurityAnswer.PasswordChar = '*';
            txtPin.PasswordChar = '*';

            isPasswordVisible = false;
            isAnswerVisible = false;

            picTogglePassword.Image = Properties.Resources.icon_closed_eye;
            picToggleAnswer.Image = Properties.Resources.icon_closed_eye;

            txtUsername.MaxLength = 10;
            txtPassword.MaxLength = 12;
            txtPin.MaxLength = 4;

            lblPin.Visible = false;
            txtPin.Visible = false;

            cmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;
        }

        // Constructor for Edit
        public UserManagementForm(string userId) : this()
        {
            _userId = userId;
            LoadUserDetails();
        }

        private void LoadUserDetails()
        {
            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return; // ✅ ADD THIS LINE

                using (var cmd = new NpgsqlCommand("SELECT * FROM users WHERE userid=@UserId", conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", int.Parse(_userId));

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUsername.Text = reader["username"].ToString();
                            txtFullname.Text = reader["fullname"].ToString();

                            string role = reader["role"].ToString();
                            cmbRole.SelectedItem = role;

                            txtEmail.Text = reader["email"].ToString();

                            bool isActive = Convert.ToBoolean(reader["isactive"]);
                            CmbStatus.SelectedItem = isActive ? "Active" : "Inactive";

                            cmbSecurityQuestion.SelectedItem = reader["securityquestion"].ToString();

                            txtPassword.Text = "";
                            txtPassword.PlaceholderText = "Leave blank to keep current password";

                            txtSecurityAnswer.Text = "";
                            txtSecurityAnswer.PlaceholderText = "Leave blank to keep current answer";

                            txtPin.Text = "";
                            txtPin.PlaceholderText = "Leave blank to keep current PIN";

                            txtPassword.PasswordChar = '*';
                            txtSecurityAnswer.PasswordChar = '*';
                            txtPin.PasswordChar = '*';

                            isPasswordVisible = false;
                            isAnswerVisible = false;

                            picTogglePassword.Image = Properties.Resources.icon_closed_eye;
                            picToggleAnswer.Image = Properties.Resources.icon_closed_eye;

                            BtnSave.Text = "UPDATE";

                            CmbRole_SelectedIndexChanged(null, null);
                        }
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string pinPlain = string.IsNullOrWhiteSpace(txtPin.Text) ? null : txtPin.Text;
            bool isActive = CmbStatus.SelectedItem?.ToString() == "Active";
            string selectedRole = cmbRole.SelectedItem?.ToString();

            // ✅ Validation: Username
            if (txtUsername.Text.Trim().Length < 4 || txtUsername.Text.Trim().Length > 10)
            {
                MessageBox.Show("Username must be between 4 and 10 characters.", "Invalid Username",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Validation: Password
            if (!string.IsNullOrEmpty(password))
            {
                if (password.Length < 6 || password.Length > 12)
                {
                    MessageBox.Show("Password must be between 6 and 12 characters.", "Invalid Password",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool hasLetter = false, hasDigit = false, hasSymbol = false;
                foreach (char c in password)
                {
                    if (char.IsLetter(c)) hasLetter = true;
                    else if (char.IsDigit(c)) hasDigit = true;
                    else if (!char.IsWhiteSpace(c)) hasSymbol = true;
                }
                if (!(hasLetter && hasDigit && hasSymbol))
                {
                    MessageBox.Show("Password must contain at least one letter, one number, and one special character.",
                        "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (string.IsNullOrEmpty(_userId))
            {
                MessageBox.Show("Password is required for new users.", "Missing Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Validation: Email
            if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Please enter a valid Gmail address (user@gmail.com).", "Invalid Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Validation: PIN for Admin
            if (selectedRole == "Admin")
            {
                if (string.IsNullOrEmpty(_userId) && string.IsNullOrWhiteSpace(pinPlain))
                {
                    MessageBox.Show("Admin PIN is required for Admin accounts.", "Missing PIN",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPin.Focus();
                    return;
                }

                if (pinPlain != null && pinPlain.Length != 4)
                {
                    MessageBox.Show("PIN must be exactly 4 digits.", "Invalid PIN",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPin.Focus();
                    return;
                }

                if (pinPlain != null && !int.TryParse(pinPlain, out _))
                {
                    MessageBox.Show("PIN must contain only numbers.", "Invalid PIN",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPin.Focus();
                    return;
                }
            }

            string passwordPlain = string.IsNullOrWhiteSpace(password) ? null : password;
            string securityAnswerPlain = string.IsNullOrWhiteSpace(txtSecurityAnswer.Text) ? null : txtSecurityAnswer.Text;

            // ✅ Direct save to PostgreSQL
            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return; // ✅ ADD THIS LINE

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    try
                    {
                        if (string.IsNullOrEmpty(_userId))
                        {
                            // ✅ Insert new user
                            string salt = Guid.NewGuid().ToString();
                            string hashedPassword = HashPassword(passwordPlain, salt);
                            string pinHash = pinPlain != null ? HashPIN(pinPlain) : null;

                            cmd.CommandText = @"INSERT INTO users 
                            (username, fullname, role, email, password, salt, securityquestion, securityanswer, isactive, adminpinhash) 
                            VALUES (@Username, @Fullname, @Role, @Email, @Password, @Salt, @SecurityQuestion, @SecurityAnswer, @IsActive, @AdminPINHash)";

                            cmd.Parameters.AddWithValue("@Password", hashedPassword);
                            cmd.Parameters.AddWithValue("@Salt", salt);
                            cmd.Parameters.AddWithValue("@AdminPINHash", (object)pinHash ?? DBNull.Value);
                        }
                        else
                        {
                            // ✅ Update existing user
                            cmd.CommandText = @"UPDATE users SET
                            username=@Username,
                            fullname=@Fullname,
                            role=@Role,
                            email=@Email,
                            securityquestion=@SecurityQuestion,
                            isactive=@IsActive";

                            if (passwordPlain != null)
                            {
                                string salt = Guid.NewGuid().ToString();
                                string hashedPassword = HashPassword(passwordPlain, salt);
                                cmd.CommandText += ", password=@Password, salt=@Salt";
                                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                                cmd.Parameters.AddWithValue("@Salt", salt);
                            }

                            if (securityAnswerPlain != null)
                            {
                                cmd.CommandText += ", securityanswer=@SecurityAnswer";
                            }

                            if (pinPlain != null)
                            {
                                string pinHash = HashPIN(pinPlain);
                                cmd.CommandText += ", adminpinhash=@AdminPINHash";
                                cmd.Parameters.AddWithValue("@AdminPINHash", pinHash);
                            }

                            cmd.CommandText += " WHERE userid=@UserId";
                            cmd.Parameters.AddWithValue("@UserId", int.Parse(_userId));
                        }

                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fullname", txtFullname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Role", selectedRole);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@IsActive", isActive);
                        cmd.Parameters.AddWithValue("@SecurityQuestion", cmbSecurityQuestion.SelectedItem?.ToString());
                        if (securityAnswerPlain != null)
                            cmd.Parameters.AddWithValue("@SecurityAnswer", securityAnswerPlain);

                        cmd.ExecuteNonQuery();
                    }
                    catch (PostgresException ex) when (ex.SqlState == "23505") // ✅ Unique violation
                    {
                        MessageBox.Show("Username or email already exists. Please choose another.",
                                        "Duplicate Entry",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving user:\n\n{ex.Message}",
                                        "Database Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (string.IsNullOrEmpty(_userId))
            {
                OnUserAdded?.Invoke();
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OnUserUpdated?.Invoke();
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                return Convert.ToBase64String(bytes);
            }
        }

        private string HashPIN(string pin)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pin));
                return Convert.ToBase64String(bytes);
            }
        }

        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = cmbRole.SelectedItem?.ToString();

            if (selectedRole == "Admin")
            {
                lblPin.Visible = true;
                txtPin.Visible = true;

                if (string.IsNullOrEmpty(_userId))
                {
                    txtPin.Focus();
                }
            }
            else
            {
                lblPin.Visible = false;
                txtPin.Visible = false;
                txtPin.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to cancel? Any unsaved changes will be lost.",
                "Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void picTogglePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txtPassword.PasswordChar = isPasswordVisible ? '\0' : '*';
            picTogglePassword.Image = isPasswordVisible
                ? Properties.Resources.icon_open_eye
                : Properties.Resources.icon_closed_eye;
        }

        private void picToggleAnswer_Click(object sender, EventArgs e)
        {
            isAnswerVisible = !isAnswerVisible;
            txtSecurityAnswer.PasswordChar = isAnswerVisible ? '\0' : '*';
            picToggleAnswer.Image = isAnswerVisible
                ? Properties.Resources.icon_open_eye
                : Properties.Resources.icon_closed_eye;
        }
    }
} 