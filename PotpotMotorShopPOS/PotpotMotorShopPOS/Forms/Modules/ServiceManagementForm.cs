using PotpotMotorShopPOS.Helpers;
using System;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Forms.Modules
{
    public partial class ServiceManagementForm : Form
    {
        private readonly int? serviceId; // null = add, not null = edit
        public event Action OnServiceSaved;

        public ServiceManagementForm(int? serviceId = null)
        {
            InitializeComponent();
            this.serviceId = serviceId;

            if (serviceId.HasValue)
            {
                LoadServiceData(serviceId.Value);
                this.Text = "Edit Service";
                BtnAddService.Text = "Update";
            }
            else
            {
                this.Text = "Add Service";
                BtnAddService.Text = "Save";
            }
        }

        private void LoadServiceData(int id)
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                if (conn == null) return;
                using (var cmd = new NpgsqlCommand("SELECT ServiceName, Price FROM Service WHERE ServiceID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtServiceName.Text = reader["ServiceName"].ToString();
                            numPrice.Value = Convert.ToDecimal(reader["Price"]);
                        }
                    }
                }
            }
        }

        private void BtnAddService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Service Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = ServerDatabase.GetConnection())
            {
                if (conn == null) return;
                NpgsqlCommand cmd;
                if (serviceId.HasValue)
                {
                    cmd = new NpgsqlCommand(@"
                        UPDATE Service
                        SET ServiceName = @name,
                            Price = @price,
                            UpdatedDate = CURRENT_TIMESTAMP
                        WHERE ServiceID = @id", conn);

                    cmd.Parameters.AddWithValue("@id", serviceId.Value);
                }
                else
                {
                    cmd = new NpgsqlCommand(@"
                        INSERT INTO Service (ServiceName, Price, CreatedDate)
                        VALUES (@name, @price, CURRENT_TIMESTAMP)", conn);
                }

                cmd.Parameters.AddWithValue("@name", txtServiceName.Text.Trim());
                cmd.Parameters.AddWithValue("@price", numPrice.Value);

                cmd.ExecuteNonQuery();
            }

            OnServiceSaved?.Invoke();

            if (serviceId.HasValue)
                this.Close();
            else
                ClearForm();
        }

        private void ClearForm()
        {
            txtServiceName.Clear();
            numPrice.Value = 0;
            txtServiceName.Focus();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
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