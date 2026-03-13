using PotpotMotorShopPOS.Helpers;
using PotpotMotorShopPOS.Views.Modules;
using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class UserManagementControl : UserControl
    {
        public UserManagementControl()
        {
            InitializeComponent();
            DataGridHelper.ApplyStyle(UserAccoutnDatagrid);
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                UserAccoutnDatagrid.Rows.Clear();

                using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
                using (var cmd = new NpgsqlCommand("SELECT UserID, Fullname, Email, Role, Username, IsActive FROM Users", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ✅ PostgreSQL uses BOOLEAN for IsActive
                        bool isActive = Convert.ToBoolean(reader["IsActive"]);

                        string statusText = isActive ? "Active" : "Inactive";

                        int rowIndex = UserAccoutnDatagrid.Rows.Add(
                            reader["UserID"].ToString(),    
                            reader["Fullname"].ToString(),   
                            reader["Email"].ToString(),     
                            reader["Role"].ToString(),     
                            reader["Username"].ToString(),   
                            statusText                      
                        );

                        // ✅ Apply color to status cell
                        var statusCell = UserAccoutnDatagrid.Rows[rowIndex].Cells["StatusColumn"];
                        if (isActive)
                        {
                            statusCell.Style.ForeColor = Color.FromArgb(0, 192, 0);  // Green
                            statusCell.Style.Font = new Font(UserAccoutnDatagrid.Font, FontStyle.Bold);
                        }
                        else
                        {
                            statusCell.Style.ForeColor = Color.FromArgb(220, 53, 69); // Red
                            statusCell.Style.Font = new Font(UserAccoutnDatagrid.Font, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }

        private void UserAccoutnDatagrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (UserAccoutnDatagrid.Columns[e.ColumnIndex].Name == "Password" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
                e.FormattingApplied = true;
            }
            else if (UserAccoutnDatagrid.Columns[e.ColumnIndex].Name == "SecurityAnswer" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
                e.FormattingApplied = true;
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            var addForm = new UserManagementForm();
            addForm.OnUserAdded += LoadUsers; // refresh DataGridView after save
            addForm.ShowDialog(); // modal popup
        }

        private void UserAccoutnDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // EDIT clicked
            if (UserAccoutnDatagrid.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                string userId = UserAccoutnDatagrid.Rows[e.RowIndex].Cells["UserId"].Value.ToString();
                var editForm = new UserManagementForm(userId);
                editForm.OnUserUpdated += LoadUsers;
                editForm.ShowDialog();
            }
        }
    }
}