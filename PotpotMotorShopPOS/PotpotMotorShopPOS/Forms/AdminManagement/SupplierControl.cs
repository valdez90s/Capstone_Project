using PotpotMotorShopPOS.Forms.Modules;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class Supplier_Control : UserControl
    {
        public Supplier_Control()
        {
            InitializeComponent(); // ✅ IMPORTANT - DO NOT REMOVE!

            // Apply style first
            DataGridHelper.ApplyStyle(SupplierListDatagrid);
            // Custom headers
            var grid = SupplierListDatagrid;

            var editCol = (DataGridViewImageColumn)grid.Columns["EditColumn"];
            editCol.Width = 50;
            editCol.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
            editCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            SupplierListDatagrid.EnableHeadersVisualStyles = false;
            SupplierListDatagrid.AutoGenerateColumns = false;

            // Attach CellFormatting FIRST before setting default colors
            SupplierListDatagrid.CellFormatting += SupplierListDatagrid_CellFormatting;
            SupplierListDatagrid.CellContentClick += SupplierListDatagrid_CellContentClick;

            // Set default colors AFTER event attachment
            SupplierListDatagrid.DefaultCellStyle.ForeColor = Color.Black;
            SupplierListDatagrid.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            SupplierListDatagrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Black;

            // Load data last
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                string search = txtSearch.Text.Trim();

                // ✅ FIXED: Changed isactive = 1 to isactive = true
                string baseQuery = @"
                SELECT supplierid,
                       suppliername,
                       contactperson,
                       address,
                       contactnumber,
                       email,
                       productcategory,
                       CASE WHEN isactive = true THEN 'Active' ELSE 'Inactive' END AS supplierstatus
                FROM supplier";

                if (!string.IsNullOrEmpty(search))
                {
                    baseQuery += @" WHERE 
                    suppliername ILIKE @Search
                    OR contactperson ILIKE @Search
                    OR address ILIKE @Search
                    OR contactnumber ILIKE @Search
                    OR email ILIKE @Search
                    OR productcategory ILIKE @Search";
                }

                using (var cmd = new NpgsqlCommand(baseQuery, conn))
                {
                    if (!string.IsNullOrEmpty(search))
                        cmd.Parameters.AddWithValue("@Search", "%" + search + "%");

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        SupplierListDatagrid.AutoGenerateColumns = false;
                        SupplierListDatagrid.DataSource = dt;

                        // Bind Designer columns
                        SupplierListDatagrid.Columns["SupplierID"].DataPropertyName = "supplierid";
                        SupplierListDatagrid.Columns["SupplierName"].DataPropertyName = "suppliername";
                        SupplierListDatagrid.Columns["ContactPerson"].DataPropertyName = "contactperson";
                        SupplierListDatagrid.Columns["SupplierAddress"].DataPropertyName = "address";
                        SupplierListDatagrid.Columns["SupplierContactNumber"].DataPropertyName = "contactnumber";
                        SupplierListDatagrid.Columns["SupplierEmail"].DataPropertyName = "email";
                        SupplierListDatagrid.Columns["SupplierCategory"].DataPropertyName = "productcategory";
                        SupplierListDatagrid.Columns["SupplierStatus"].DataPropertyName = "supplierstatus";

                        // ✅ Force the status column to use CellFormatting colors even when selected
                        SupplierListDatagrid.Columns["SupplierStatus"].DefaultCellStyle.SelectionForeColor = Color.Empty;
                    }
                }
            }
        }

        private void SupplierListDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= SupplierListDatagrid.Rows.Count)
                return;

            var grid = SupplierListDatagrid;
            string colName = grid.Columns[e.ColumnIndex].Name;

            if (colName == "DeleteColumn" || colName == "EditColumn")
            {
                if (!(grid.Rows[e.RowIndex].DataBoundItem is DataRowView rowView)) return;
                if (!int.TryParse(rowView["supplierid"].ToString(), out int supplierId)) return;

                if (colName == "DeleteColumn")
                {
                    if (MessageBox.Show("Delete this supplier?", "Confirm",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
                            using (var cmd = new NpgsqlCommand("DELETE FROM supplier WHERE supplierid = @id", conn))
                            {
                                cmd.Parameters.AddWithValue("@id", supplierId);
                                cmd.ExecuteNonQuery();
                            }
                            LoadSuppliers();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting supplier: " + ex.Message,
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (colName == "EditColumn")
                {
                    using (SupplierManagementForm form = new SupplierManagementForm(supplierId))
                    {
                        form.OnSupplierAdded += LoadSuppliers;
                        form.ShowDialog();
                    }
                }
            }
        }

        private void BtnAddSupplier_Click(object sender, EventArgs e)
        {
            using (var addForm = new SupplierManagementForm())
            {
                addForm.OnSupplierAdded += LoadSuppliers;
                addForm.ShowDialog();
            }
        }

        private void SupplierListDatagrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (SupplierListDatagrid.Columns[e.ColumnIndex].Name == "SupplierStatus" && e.Value != null)
            {
                string status = e.Value.ToString().Trim();

                // Create a new style to avoid modifying the shared default style
                DataGridViewCellStyle style = new DataGridViewCellStyle(e.CellStyle);

                if (status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                {
                    style.ForeColor = Color.LimeGreen;
                    style.SelectionForeColor = Color.LimeGreen; // ✅ Override selection color
                    style.Font = new Font(SupplierListDatagrid.Font, FontStyle.Bold);
                }
                else if (status.Equals("Inactive", StringComparison.OrdinalIgnoreCase))
                {
                    style.ForeColor = Color.Red;
                    style.SelectionForeColor = Color.Red; // ✅ Override selection color
                    style.Font = new Font(SupplierListDatagrid.Font, FontStyle.Bold);
                }

                e.CellStyle = style; // ✅ Apply the new style
                e.FormattingApplied = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: leave empty or remove if not needed
        }

        private void SupplierListDatagrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: leave empty or remove if not needed
        }
    }
}