using PotpotMotorShopPOS.CrystalReport.Forms;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class DamageProductReportControl : UserControl
    {
        public DamageProductReportControl()
        {
            InitializeComponent();
            DataGridHelper.ApplyStyle(dgvDamagedProducts);
        }

        private void DamageProductReportControl_Load(object sender, EventArgs e)
        {
            InitializeFilters();
            LoadDamagedProducts();
        }

        /// <summary>
        /// ✅ Initialize filters (Category dropdown and Date pickers)
        /// </summary>
        private void InitializeFilters()
        {
            // ✅ Set default date range (last 30 days)
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;

            LoadCategories();
        }

        /// <summary>
        /// ✅ Load categories for filter dropdown
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return;
                    string query = @"
                        SELECT CategoryID, CategoryName 
                        FROM Categories 
                        WHERE IsDeleted = false 
                        ORDER BY CategoryName";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbCategory.Items.Clear();

                        // ✅ Add "All Categories" option
                        cmbCategory.Items.Add(new CategoryItem
                        {
                            CategoryID = 0,
                            CategoryName = "All Categories"
                        });

                        while (reader.Read())
                        {
                            cmbCategory.Items.Add(new CategoryItem
                            {
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                CategoryName = reader["CategoryName"].ToString()
                            });
                        }
                    }
                }

                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
                cmbCategory.SelectedIndex = 0; // Default to "All Categories"
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ✅ Load damaged products with filters (Category + Date Range)
        /// </summary>
        private void LoadDamagedProducts()
        {
            try
            {
                using (var conn = ServerDatabase.GetConnection())
                {
                    if (conn == null) return;
                    var selectedCategory = cmbCategory.SelectedItem as CategoryItem;
                    DateTime dateFrom = dtpFrom.Value.Date;
                    DateTime dateTo = dtpTo.Value.Date.AddDays(1).AddSeconds(-1); // Include entire day

                    string query = @"
                        SELECT 
                            sa.productid,
                            sa.barcode,
                            sa.productname,
                            c.categoryname,
                            SUM(sa.quantityadjusted) AS totaldamaged
                        FROM stockadjustments sa
                        LEFT JOIN products p ON sa.productid = p.productid
                        LEFT JOIN categories c ON p.categoryid = c.categoryid
                        WHERE sa.adjustmenttype = 'DAMAGED'
                        AND sa.adjustmentdate >= @DateFrom
                        AND sa.adjustmentdate <= @DateTo";

                    // ✅ Add category filter if not "All Categories"
                    if (selectedCategory != null && selectedCategory.CategoryID != 0)
                    {
                        query += " AND p.categoryid = @CategoryID";
                    }

                    query += @"
                        GROUP BY sa.productid, sa.barcode, sa.productname, c.categoryname
                        HAVING SUM(sa.quantityadjusted) > 0
                        ORDER BY sa.productname ASC;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", dateTo);

                        if (selectedCategory != null && selectedCategory.CategoryID != 0)
                        {
                            cmd.Parameters.AddWithValue("@CategoryID", selectedCategory.CategoryID);
                        }

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable("DamagedProducts");
                            adapter.Fill(dt);

                            dgvDamagedProducts.AutoGenerateColumns = false;
                            dgvDamagedProducts.DataSource = dt;

                            dgvDamagedProducts.Columns["ProductID"].DataPropertyName = "productid";
                            dgvDamagedProducts.Columns["ProductID"].Visible = false;
                            dgvDamagedProducts.Columns["Barcode"].DataPropertyName = "barcode";
                            dgvDamagedProducts.Columns["ProductName"].DataPropertyName = "productname";
                            dgvDamagedProducts.Columns["CategoryName"].DataPropertyName = "categoryname";
                            dgvDamagedProducts.Columns["TotalDamaged"].DataPropertyName = "totaldamaged";

                            // ✅ Show count in status or label (optional)
                            lblRecordCount.Text = $"Records: {dt.Rows.Count}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading damaged products: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (var rptForm = new DamageProductReportForm())
            {
                rptForm.ShowDialog();
            }
        }

       
        private class CategoryItem
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        }

        private void dtpFrom_ValueChanged_1(object sender, EventArgs e)
        {
            if (dtpFrom.Value <= dtpTo.Value)
            {
                LoadDamagedProducts();
            }
        }

        private void dtpTo_ValueChanged_1(object sender, EventArgs e)
        {
            if (dtpFrom.Value <= dtpTo.Value)
            {
                LoadDamagedProducts();
            }
        }

        private void cmbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadDamagedProducts();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // ✅ Validate date range
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("'From Date' cannot be later than 'To Date'.",
                                "Invalid Date Range",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            LoadDamagedProducts();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;
            cmbCategory.SelectedIndex = 0; // All Categories
            LoadDamagedProducts();
        }

        private void dgvDamagedProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}