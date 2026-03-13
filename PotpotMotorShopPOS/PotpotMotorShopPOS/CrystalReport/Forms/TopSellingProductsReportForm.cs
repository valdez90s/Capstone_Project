using CrystalDecisions.CrystalReports.Engine;
using Npgsql; // ✅ PostgreSQL provider
using PotpotMotorShopPOS.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.CrystalReport.Forms
{
    public partial class TopSellingProductsReportForm : Form
    {
        private DateTime dateFrom;
        private DateTime dateTo;
        private string filterType;
        private ReportDocument _currentReport; // ✅ Para sa proper disposal

        public TopSellingProductsReportForm()
        {
            InitializeComponent();
        }

        public TopSellingProductsReportForm(DateTime from, DateTime to, string filter)
        {
            InitializeComponent();
            this.dateFrom = from;
            this.dateTo = to;
            this.filterType = filter;
        }

        private void TopSellingProductsReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                string reportPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "CrystalReport",
                    "TopSellingProductsReport.rpt"
                );

                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show($"Missing report file:\n{reportPath}",
                                    "Report Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                _currentReport = new ReportDocument();
                _currentReport.Load(reportPath);

                DataSet ds = GetTopSellingProductsDataSet();
                if (ds == null || ds.Tables["TopSellingProduct"].Rows.Count == 0)
                {
                    MessageBox.Show("No data to display in the report.",
                                    "No Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                _currentReport.SetDataSource(ds);

                crystalReportViewer1.ReportSource = _currentReport;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Top Selling Products report: " + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private DataSet GetTopSellingProductsDataSet()
        {
            DataSet ds = new DataSet("TopSellingProductsDataSet");

            DataTable dtProducts = new DataTable("TopSellingProduct");
            dtProducts.Columns.Add("Rank", typeof(int));
            dtProducts.Columns.Add("ProductName", typeof(string));
            dtProducts.Columns.Add("Barcode", typeof(string));
            dtProducts.Columns.Add("Category", typeof(string));
            dtProducts.Columns.Add("QuantitySold", typeof(int));
            dtProducts.Columns.Add("UnitPrice", typeof(decimal));
            dtProducts.Columns.Add("TotalRevenue", typeof(decimal));
            dtProducts.Columns.Add("Transactions", typeof(int));

            DataTable dtSummary = new DataTable("Summary");
            dtSummary.Columns.Add("DateFrom", typeof(string));
            dtSummary.Columns.Add("DateTo", typeof(string));
            dtSummary.Columns.Add("FilterType", typeof(string));
            dtSummary.Columns.Add("TotalRevenue", typeof(decimal));
            dtSummary.Columns.Add("TotalQuantity", typeof(int));

            decimal totalRevenue = 0m;
            int totalQty = 0;

            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL connection
            {
                string orderBy = filterType == "By Quantity Sold"
                    ? "TotalQuantity DESC"
                    : "TotalRevenue DESC";

                // ✅ PostgreSQL syntax: ::date for casting, LIMIT stays the same
                string query = $@"
                    SELECT 
                        p.ProductID,
                        p.ProductName,
                        p.Barcode,
                        c.CategoryName,
                        SUM(ti.Quantity) as TotalQuantity,
                        AVG(ti.UnitPrice) as AvgUnitPrice,
                        SUM(ti.Subtotal) as TotalRevenue,
                        COUNT(DISTINCT ti.TransactionID) as TransactionCount
                    FROM POS_TransactionItems ti
                    INNER JOIN Products p ON ti.ItemID = p.ProductID
                    INNER JOIN Categories c ON p.CategoryID = c.CategoryID
                    INNER JOIN POS_Transactions t ON ti.TransactionID = t.TransactionID
                    WHERE ti.ItemType = 'Product'
                      AND t.CreatedAt::date BETWEEN @DateFrom AND @DateTo
                    GROUP BY p.ProductID, p.ProductName, p.Barcode, c.CategoryName
                    ORDER BY {orderBy}
                    LIMIT 50";

                using (var cmd = new NpgsqlCommand(query, conn)) // ✅ NpgsqlCommand
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom.Date);
                    cmd.Parameters.AddWithValue("@DateTo", dateTo.Date);

                    using (var reader = cmd.ExecuteReader())
                    {
                        int rank = 1;

                        while (reader.Read())
                        {
                            DataRow row = dtProducts.NewRow();
                            row["Rank"] = rank++;
                            row["ProductName"] = reader["ProductName"].ToString();
                            row["Barcode"] = reader["Barcode"]?.ToString() ?? "N/A";
                            row["Category"] = reader["CategoryName"].ToString();

                            int qtySold = Convert.ToInt32(reader["TotalQuantity"]);
                            row["QuantitySold"] = qtySold;

                            decimal avgPrice = Convert.ToDecimal(reader["AvgUnitPrice"]);
                            row["UnitPrice"] = avgPrice;

                            decimal revenue = Convert.ToDecimal(reader["TotalRevenue"]);
                            row["TotalRevenue"] = revenue;

                            row["Transactions"] = Convert.ToInt32(reader["TransactionCount"]);

                            dtProducts.Rows.Add(row);

                            totalRevenue += revenue;
                            totalQty += qtySold;
                        }
                    }
                }
            }

            DataRow summaryRow = dtSummary.NewRow();
            summaryRow["DateFrom"] = dateFrom.ToString("MMMM dd, yyyy");
            summaryRow["DateTo"] = dateTo.ToString("MMMM dd, yyyy");
            summaryRow["FilterType"] = filterType;
            summaryRow["TotalRevenue"] = totalRevenue;
            summaryRow["TotalQuantity"] = totalQty;
            dtSummary.Rows.Add(summaryRow);

            ds.Tables.Add(dtProducts);
            ds.Tables.Add(dtSummary);

            return ds;
        }

        private void TopSellingProductsReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ✅ Improved disposal
            if (_currentReport != null)
            {
                _currentReport.Close();
                _currentReport.Dispose();
                _currentReport = null;
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
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

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            // Optional: leave empty or add custom logic
        }
    }
}