using System;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Forms.Modules
{
    public partial class CategoryManagementForm : Form
    {
        public event Action OnCategoryAdded;
        public event Action OnCategoryUpdated;

        private string _categoryId;

        // Constructor for Add
        public CategoryManagementForm()
        {
            InitializeComponent();
            BtnSaveCategory.Text = "SAVE";
        }

        // Constructor for Edit
        public CategoryManagementForm(string categoryId) : this()
        {
            _categoryId = categoryId;
            BtnSaveCategory.Text = "UPDATE";
            LoadCategoryDetails();
        }

        private void LoadCategoryDetails()
        {
            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return; // ✅ ADD THIS LINE

                using (var cmd = new NpgsqlCommand("SELECT CategoryName FROM Categories WHERE CategoryID=@CategoryID", conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", int.Parse(_categoryId));
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtCategory.Text = reader["CategoryName"].ToString();
                        }
                    }
                }
            }
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

        private void BtnSaveCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategory.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return; // ✅ ADD THIS LINE

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    if (string.IsNullOrEmpty(_categoryId))
                    {
                        // New category
                        cmd.CommandText = @"INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    }
                    else
                    {
                        // Update existing category
                        cmd.CommandText = @"UPDATE Categories 
                                    SET CategoryName=@CategoryName 
                                    WHERE CategoryID=@CategoryID";
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                        cmd.Parameters.AddWithValue("@CategoryID", int.Parse(_categoryId));
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (PostgresException ex) when (ex.SqlState == "23505") // ✅ Unique violation
                    {
                        MessageBox.Show("Category name already exists. Please choose another.",
                                        "Duplicate Category",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }
                    catch (Exception ex)
                    {
                        // ✅ BONUS: Handle other errors
                        MessageBox.Show($"Error saving category:\n\n{ex.Message}",
                                        "Database Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (string.IsNullOrEmpty(_categoryId))
            {
                OnCategoryAdded?.Invoke();
                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OnCategoryUpdated?.Invoke();
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
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
    }
}