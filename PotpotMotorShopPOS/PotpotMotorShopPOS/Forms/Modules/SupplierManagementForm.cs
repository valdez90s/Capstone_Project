using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Forms.Modules
{
    public partial class SupplierManagementForm : Form
    {
        private readonly int? supplierId; // null = add, not null = edit
        public event Action OnSupplierAdded;

        // ✅ Single constructor handles both Add and Edit
        public SupplierManagementForm(int? supplierId = null)
        {
            InitializeComponent();
            this.supplierId = supplierId;

            LoadCategories();       // always load categories first
            LoadStatusOptions();    // load Active/Inactive options

            if (supplierId.HasValue)
            {
                LoadSupplierData(supplierId.Value); // then load supplier details
                this.Text = "Edit Supplier";
                BtnAddSupplier.Text = "Update";
            }
            else
            {
                this.Text = "Add Supplier";
                BtnAddSupplier.Text = "Save";
            }
        }

        // 🔹 Load categories into ComboBox
        private void LoadCategories()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                if (conn == null) return;

                string query = "SELECT categoryname FROM categories ORDER BY categoryname ASC";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "categoryname";
                    cmbCategory.ValueMember = "categoryname";
                }
            }
        }

        // 🔹 Load Active/Inactive options
        private void LoadStatusOptions()
        {
            cmbSupplierStatus.Items.Clear();
            cmbSupplierStatus.Items.Add("Active");
            cmbSupplierStatus.Items.Add("Inactive");
            cmbSupplierStatus.SelectedIndex = 0; // default Active
        }

        // 🔹 Load supplier data and auto-select category + status
        private void LoadSupplierData(int id)
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                if (conn == null) return;

                using (var cmd = new NpgsqlCommand("SELECT * FROM supplier WHERE supplierid = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtSupplierName.Text = reader["suppliername"].ToString();
                        txtContactPerson.Text = reader["contactperson"].ToString();
                        txtAddress.Text = reader["address"].ToString();
                        txtContactNumber.Text = reader["contactnumber"].ToString();
                        txtEmail.Text = reader["email"].ToString();

                        // 🔹 auto-select category
                        string category = reader["productcategory"].ToString().Trim();
                        if (!string.IsNullOrEmpty(category))
                        {
                            cmbCategory.SelectedValue = category;
                            if (cmbCategory.SelectedIndex == -1)
                            {
                                int index = cmbCategory.FindStringExact(category);
                                if (index >= 0)
                                    cmbCategory.SelectedIndex = index;
                                else
                                    cmbCategory.Text = category;
                            }
                        }

                        // 🔹 set status
                        int isActive = Convert.ToInt32(reader["isactive"]);
                        cmbSupplierStatus.SelectedItem = (isActive == 1 ? "Active" : "Inactive");
                    }
                }
            }
        }
     }


        // 🔹 Save or Update Supplier
        private void BtnAddSupplier_Click(object sender, EventArgs e)
        {
            // === VALIDATIONS ===
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Supplier Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategory.SelectedValue == null || string.IsNullOrWhiteSpace(cmbCategory.SelectedValue.ToString()))
            {
                MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                !txtEmail.Text.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Please enter a valid Gmail address (must end with @gmail.com).",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show("Contact Number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // === SAVE TO DB ===
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {

                if (conn == null) return;

                NpgsqlCommand cmd;
                if (supplierId.HasValue)
                {
                    // Update
                    cmd = new NpgsqlCommand(@"
                        UPDATE supplier
                        SET suppliername = @name,
                            contactperson = @person,
                            address = @address,
                            contactnumber = @contact,
                            email = @email,
                            productcategory = @category,
                            isactive = @status,
                            updateddate = CURRENT_TIMESTAMP
                        WHERE supplierid = @id", conn);

                    cmd.Parameters.AddWithValue("@id", supplierId.Value);
                }
                else
                {
                    // Insert
                    cmd = new NpgsqlCommand(@"
                        INSERT INTO supplier 
                        (suppliername, contactperson, address, contactnumber, email, productcategory, isactive, createddate)
                        VALUES (@name, @person, @address, @contact, @email, @category, @status, CURRENT_TIMESTAMP)", conn);
                }

                cmd.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim());
                cmd.Parameters.AddWithValue("@person", txtContactPerson.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", txtContactNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@category", cmbCategory.SelectedValue?.ToString());
                cmd.Parameters.AddWithValue("@status", cmbSupplierStatus.SelectedItem?.ToString() == "Active");

                cmd.ExecuteNonQuery();
            }

            OnSupplierAdded?.Invoke();

            if (supplierId.HasValue)
            {
                // Edit mode → close after update
                this.Close();
            }
            else
            {
                // Add mode → clear fields for next entry
                ClearForm();
                MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearForm()
        {
            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            txtEmail.Clear();

            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;

            if (cmbSupplierStatus.Items.Count > 0)
                cmbSupplierStatus.SelectedIndex = 0; // default Active
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block input
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnCancel_Click_1(object sender, EventArgs e)
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
    }
}