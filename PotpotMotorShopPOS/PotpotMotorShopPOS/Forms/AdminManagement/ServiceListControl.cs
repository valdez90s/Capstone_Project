using Guna.UI2.WinForms.Enums;
using PotpotMotorShopPOS.Forms.Modules;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class ServiceListControl : UserControl
    {
        public ServiceListControl()
        {
            InitializeComponent();
            LoadServices();

            // Custom headers
            var grid = ServicesListDatagrid;

            // General look
            grid.Theme = DataGridViewPresetThemes.Dark;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.BackgroundColor = Color.White;
            grid.GridColor = Color.FromArgb(41, 41, 66);

            // Header
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 41, 66);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            grid.ColumnHeadersHeight = 70;

            // Rows
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 41, 66);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            grid.RowTemplate.Height = 90;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var editCol = (DataGridViewImageColumn)grid.Columns["EditColumn"];
            editCol.Width = 50;
            editCol.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var delCol = (DataGridViewImageColumn)grid.Columns["DeleteColumn"];
            delCol.Width = 50;
            delCol.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            delCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void BtnAddServices_Click(object sender, EventArgs e)
        {
            using (var addForm = new ServiceManagementForm())
            {
                addForm.OnServiceSaved += LoadServices;
                addForm.ShowDialog();
            }
        }

        private void LoadServices()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                if (conn == null) return; 

                string baseQuery = @"
                SELECT ServiceID,
                       ServiceName,
                       Price
                FROM Service";

                using (var cmd = new NpgsqlCommand(baseQuery, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    ServicesListDatagrid.AutoGenerateColumns = false;
                    ServicesListDatagrid.DataSource = dt;

                    ServicesListDatagrid.Columns["ServiceID"].DataPropertyName = "ServiceID";
                    ServicesListDatagrid.Columns["ServiceName"].DataPropertyName = "ServiceName";
                    ServicesListDatagrid.Columns["ServicePrice"].DataPropertyName = "Price";
                }
            }
        }

        private void ServicesListDatagrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (ServicesListDatagrid.Columns[e.ColumnIndex].Name == "ServicePrice" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal price))
                {
                    e.Value = price.ToString("C2"); // format as currency
                    e.FormattingApplied = true;
                }
            }
        }

        private void ServicesListDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= ServicesListDatagrid.Rows.Count)
                return;

            var grid = ServicesListDatagrid;
            string colName = grid.Columns[e.ColumnIndex].Name;

            if (colName == "DeleteColumn" || colName == "EditColumn")
            {
                if (!(grid.Rows[e.RowIndex].DataBoundItem is DataRowView rowView)) return;
                if (!int.TryParse(rowView["ServiceID"].ToString(), out int serviceId)) return;

                if (colName == "DeleteColumn")
                {
                    if (MessageBox.Show("Delete this service?", "Confirm",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            using (var conn = ServerDatabase.GetConnection())
                            {
                                if (conn == null) return; // ✅ ADDED NULL CHECK

                                using (var cmd = new NpgsqlCommand("DELETE FROM Service WHERE ServiceID = @id", conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", serviceId);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Service deleted successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadServices();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting service: " + ex.Message,
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (colName == "EditColumn")
                {
                    using (ServiceManagementForm form = new ServiceManagementForm(serviceId))
                    {
                        form.OnServiceSaved += LoadServices;
                        form.ShowDialog();
                    }
                }
            }
        }

        private void PnlOne_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}