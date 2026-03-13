using PotpotMotorShopPOS.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Npgsql; // ✅ PostgreSQL provider

namespace PotpotMotorShopPOS.Views.Management
{
    public partial class DashboardControl : UserControl
    {
        #region Fields
        private int lastHighlightedPoint = -1;
        #endregion

        #region Constructor & Initialization
        public DashboardControl()
        {
            InitializeComponent();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeSalesFilter();
                InitializeCharts();
                LoadDashboardData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Load Error: {ex.Message}\n\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeSalesFilter()
        {
            cmbSalesFilter.Items.AddRange(new string[] { "Weekly", "Monthly", "Yearly" });
            cmbSalesFilter.SelectedIndexChanged -= cmbSalesFilter_SelectedIndexChanged;
            cmbSalesFilter.SelectedIndexChanged += cmbSalesFilter_SelectedIndexChanged;
            cmbSalesFilter.SelectedIndex = 0;
        }

        private void InitializeCharts()
        {
            SetupChart();
            SetupCategoryChart();
            SetupServicesChart();
            CustomizeLegend();
        }

        private void LoadDashboardData()
        {
            LoadSalesData("Weekly");
            LoadTotalProducts();
            LoadDashboardTiles();
            LoadTopCategorySales();
            LoadTopServices();
        }
        #endregion

        #region Data Retrieval Methods
        private List<string> GetCriticalStockProducts()
        {
            var products = new List<string>();
            try
            {
                products = FetchProducts(@"
                    SELECT productname 
                    FROM products 
                    WHERE quantity <= reorderlevel AND quantity > 0
                    ORDER BY quantity ASC
                    LIMIT 10");

                if (products.Count == 0)
                {
                    products = FetchProducts(@"
                        SELECT productname 
                        FROM products 
                        WHERE quantity BETWEEN 1 AND 5
                        ORDER BY quantity ASC
                        LIMIT 10");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[GetCriticalStockProducts] Error: {ex.Message}");
            }
            return products;
        }

        private List<string> GetOutOfStockProducts()
        {
            var products = new HashSet<string>();
            try
            {
                var result = FetchProducts(@"
                    SELECT productname 
                    FROM products 
                    WHERE quantity = 0
                    ORDER BY productname ASC
                    LIMIT 10");

                foreach (var product in result)
                    products.Add(product);

                if (products.Count == 0)
                {
                    result = FetchProducts(@"
                        SELECT productname 
                        FROM products 
                        WHERE quantity IS NULL OR quantity <= 0
                        ORDER BY productname ASC
                        LIMIT 10");

                    foreach (var product in result)
                        products.Add(product);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[GetOutOfStockProducts] Error: {ex.Message}");
            }
            return products.ToList();
        }

        private List<string> GetDamagedProducts()
        {
            var products = new List<string>();
            try
            {
                products = FetchProducts(@"
                    SELECT DISTINCT p.productname 
                    FROM stockadjustments sa
                    JOIN products p ON sa.productid = p.productid
                    WHERE sa.adjustmenttype = 'DAMAGED'
                      AND DATE(sa.createdat) >= CURRENT_DATE - INTERVAL '7 days'
                    ORDER BY sa.createdat DESC
                    LIMIT 10");

                if (products.Count == 0)
                {
                    products = FetchProducts(@"
                        SELECT DISTINCT p.productname 
                        FROM stockadjustments sa
                        JOIN products p ON sa.productid = p.productid
                        WHERE sa.adjustmenttype = 'DAMAGED'
                        ORDER BY sa.createdat DESC
                        LIMIT 10");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[GetDamagedProducts] Error: {ex.Message}");
            }
            return products;
        }

        private List<string> FetchProducts(string query)
        {
            var products = new List<string>();
            using (var conn = ServerDatabase.GetConnection())
            using (var cmd = new NpgsqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(reader["productname"].ToString());
                }
            }
            return products;
        }

        #endregion

        #region Dashboard Tiles
        private void LoadTotalProducts()
        {
            int totalProducts = ExecuteScalar("SELECT COUNT(*) FROM products");
            lblTotalProductsValue.Text = totalProducts.ToString("N0");
        }

        private int GetOutOfStockCount()
        {
            return ExecuteScalar("SELECT COUNT(*) FROM products WHERE quantity = 0");
        }

        private int GetCriticalStockCount()
        {
            return ExecuteScalar(
                "SELECT COUNT(*) FROM products WHERE quantity <= reorderlevel AND quantity > 0");
        }

        private int GetTotalDamagedCount()
        {
            return ExecuteScalar(
                "SELECT COALESCE(SUM(quantityadjusted), 0) FROM stockadjustments WHERE adjustmenttype = 'DAMAGED'");
        }

        private void LoadDashboardTiles()
        {
            lblOutOfStockValue.Text = GetOutOfStockCount().ToString("N0");
            lblCriticalStockValue.Text = GetCriticalStockCount().ToString("N0");
            lblDamagedValue.Text = GetTotalDamagedCount().ToString("N0");
        }

        private int ExecuteScalar(string query)
        {
            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        #endregion

        #region Sales Chart Setup
        private void SetupChart()
        {
            chartSales.ChartAreas.Clear();
            chartSales.Series.Clear();
            chartSales.Legends.Clear();

            var area = CreateChartArea();
            ConfigureChartAxis(area);
            chartSales.ChartAreas.Add(area);

            var legend = CreateLegend();
            chartSales.Legends.Add(legend);

            ConfigureChartAppearance();
            AttachChartEvents();
        }

        private ChartArea CreateChartArea()
        {
            return new ChartArea("MainArea")
            {
                BackColor = Color.FromArgb(250, 251, 252),
                BorderColor = Color.FromArgb(220, 223, 230),
                BorderWidth = 2,
                BorderDashStyle = ChartDashStyle.Solid,
                InnerPlotPosition = new ElementPosition(12, 5, 83, 85)
            };
        }

        private void ConfigureChartAxis(ChartArea area)
        {
            var gridColor = Color.FromArgb(235, 237, 242);
            var labelColor = Color.FromArgb(52, 58, 64);
            var labelFont = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            var lineColor = Color.FromArgb(200, 203, 210);

            // X-Axis
            area.AxisX.MajorGrid.LineColor = gridColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisX.LabelStyle.ForeColor = labelColor;
            area.AxisX.LabelStyle.Font = labelFont;
            area.AxisX.LineColor = lineColor;
            area.AxisX.LineWidth = 2;
            area.AxisX.MajorTickMark.Enabled = false;

            // Y-Axis
            area.AxisY.MajorGrid.LineColor = gridColor;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisY.LabelStyle.ForeColor = labelColor;
            area.AxisY.LabelStyle.Font = labelFont;
            area.AxisY.LineColor = lineColor;
            area.AxisY.LineWidth = 2;
            area.AxisY.MajorTickMark.Enabled = false;
        }

        private Legend CreateLegend()
        {
            return new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                ForeColor = Color.FromArgb(52, 58, 64),
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                BackColor = Color.Transparent,
                BorderColor = Color.Transparent,
                Enabled = false
            };
        }

        private void ConfigureChartAppearance()
        {
            chartSales.BackColor = Color.White;
            chartSales.BorderlineColor = Color.FromArgb(220, 223, 230);
            chartSales.BorderlineWidth = 2;
            chartSales.BorderlineDashStyle = ChartDashStyle.Solid;
            chartSales.AntiAliasing = AntiAliasingStyles.All;
            chartSales.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
        }

        private void AttachChartEvents()
        {
            chartSales.MouseMove += ChartSales_MouseMove;
            chartSales.MouseLeave += ChartSales_MouseLeave;
        }
        #endregion

        #region Chart Interaction Events
        private void ChartSales_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var result = chartSales.HitTest(e.X, e.Y);

                if (result.ChartElementType == ChartElementType.DataPoint && chartSales.Series.Count > 0)
                {
                    int pointIndex = result.PointIndex;
                    var series = chartSales.Series[0];

                    if (lastHighlightedPoint != -1 && lastHighlightedPoint != pointIndex)
                    {
                        ResetPointStyle(series, lastHighlightedPoint);
                    }

                    if (pointIndex >= 0 && pointIndex < series.Points.Count)
                    {
                        HighlightPoint(series, pointIndex);
                        lastHighlightedPoint = pointIndex;
                        chartSales.Cursor = Cursors.Hand;
                    }
                }
                else
                {
                    if (lastHighlightedPoint != -1)
                    {
                        ResetPointStyle(chartSales.Series[0], lastHighlightedPoint);
                        lastHighlightedPoint = -1;
                    }
                    chartSales.Cursor = Cursors.Default;
                }
            }
            catch { }
        }

        private void ChartSales_MouseLeave(object sender, EventArgs e)
        {
            if (lastHighlightedPoint != -1 && chartSales.Series.Count > 0)
            {
                ResetPointStyle(chartSales.Series[0], lastHighlightedPoint);
                lastHighlightedPoint = -1;
            }
        }

        private void HighlightPoint(Series series, int index)
        {
            if (series.ChartType == SeriesChartType.Column)
            {
                series.Points[index]["PixelPointWidth"] = "50";
                var currentColor = series.Points[index].Color;
                series.Points[index].Color = ControlPaint.Light(currentColor, 0.3f);
                series.Points[index].BorderWidth = 3;
                series.Points[index].BorderColor = Color.FromArgb(255, 255, 255);
            }
            else if (series.ChartType == SeriesChartType.SplineArea)
            {
                series.Points[index].MarkerSize = 14;
                series.Points[index].MarkerBorderWidth = 3;
            }
        }

        private void ResetPointStyle(Series series, int index)
        {
            if (index < 0 || index >= series.Points.Count) return;

            if (series.ChartType == SeriesChartType.Column)
            {
                series.Points[index]["PixelPointWidth"] = "40";
                series.Points[index].BorderWidth = 0;
            }
            else if (series.ChartType == SeriesChartType.SplineArea)
            {
                series.Points[index].MarkerSize = 8;
                series.Points[index].MarkerBorderWidth = 2;
            }
        }
        #endregion

        #region Sales Data Loading
        private void LoadSalesData(string filter)
        {
            chartSales.Series.Clear();
            lastHighlightedPoint = -1;

            Series series = new Series("Sales")
            {
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                LabelForeColor = Color.FromArgb(52, 58, 64)
            };

            switch (filter)
            {
                case "Weekly":
                    LoadWeeklySales(series);
                    break;
                case "Monthly":
                    LoadMonthlySales(series);
                    break;
                case "Yearly":
                    LoadYearlySales(series);
                    break;
            }

            chartSales.Series.Add(series);
        }

        private void LoadWeeklySales(Series series)
        {
            ConfigureColumnSeries(series);

            // ✅ Mas flexible na query
            var salesData = FetchSalesData(@"
            SELECT 
                TO_CHAR(createdat, 'YYYY-MM-DD') as saledate,
                SUM(totalamount) as dailysales
            FROM pos_transactions
            WHERE createdat >= CURRENT_TIMESTAMP - INTERVAL '6 days'
            GROUP BY TO_CHAR(createdat, 'YYYY-MM-DD')
            ORDER BY TO_CHAR(createdat, 'YYYY-MM-DD') ASC");

            var values = PopulateWeeklyData(series, salesData);

            // ✅ Kung walang data, show message
            if (values.Count == 0 || values.All(v => v == 0))
            {
                MessageBox.Show("Walang sales data sa nakaraang 7 days.",
                    "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            HighlightMaxValue(series, values);
            SetChartAxisRange(values, 1000, 1.2);

            chartSales.Legends[0].Enabled = false;
        }

        private void ConfigureColumnSeries(Series series)
        {
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(79, 134, 247);
            series.BackSecondaryColor = Color.FromArgb(99, 154, 255);
            series.BackGradientStyle = GradientStyle.TopBottom;
            series.BorderWidth = 0;
            series["PixelPointWidth"] = "40";
            series["PointWidth"] = "0.8";
            series.ShadowOffset = 3;
            series.ShadowColor = Color.FromArgb(80, 0, 0, 0);
        }

        private Dictionary<string, decimal> FetchSalesData(string query)
        {
            var salesData = new Dictionary<string, decimal>();

            using (var conn = ServerDatabase.GetConnection())   
            {
              
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string key = reader.FieldCount > 1 ? reader[0].ToString() : reader["saledate"].ToString();
                        decimal sales = Convert.ToDecimal(reader[reader.FieldCount - 1]);
                        salesData[key] = sales;
                    }
                }

            }

            return salesData;
        }

        private List<double> PopulateWeeklyData(Series series, Dictionary<string, decimal> salesData)
        {
            var values = new List<double>();

            for (int i = 6; i >= 0; i--)
            {
                DateTime date = DateTime.Today.AddDays(-i);
                string dateKey = date.ToString("yyyy-MM-dd");
                string dayName = date.ToString("ddd");
                decimal sales = salesData.ContainsKey(dateKey) ? salesData[dateKey] : 0m;

                int pointIndex = series.Points.AddXY(dayName, (double)sales);
                values.Add((double)sales);

                series.Points[pointIndex].ToolTip = FormatWeeklyTooltip(date, dayName, sales);
            }

            return values;
        }

        private string FormatWeeklyTooltip(DateTime date, string dayName, decimal sales)
        {
            return $"━━━━━━━━━━━━━━\n{date:MMM dd, yyyy} ({dayName})\n" +
                   $"━━━━━━━━━━━━━━\nSales: ₱{sales:N2}\n━━━━━━━━━━━━━━";
        }

        private void HighlightMaxValue(Series series, List<double> values)
        {
            if (values.Count > 0 && values.Max() > 0)
            {
                int maxIndex = values.IndexOf(values.Max());
                series.Points[maxIndex].Color = Color.FromArgb(255, 107, 107);
                series.Points[maxIndex].BackSecondaryColor = Color.FromArgb(255, 142, 142);
                series.Points[maxIndex].BackGradientStyle = GradientStyle.TopBottom;
                series.Points[maxIndex].BorderColor = Color.FromArgb(255, 255, 255);
                series.Points[maxIndex].BorderWidth = 2;
            }
        }

        private void SetChartAxisRange(List<double> values, double roundFactor, double multiplier)
        {
            if (values.Count > 0 && values.Max() > 0)
            {
                double maxVal = values.Max();
                double roundedMax = Math.Ceiling(maxVal / roundFactor) * roundFactor;
                chartSales.ChartAreas[0].AxisY.Minimum = 0;
                chartSales.ChartAreas[0].AxisY.Maximum = roundedMax * multiplier;
                chartSales.ChartAreas[0].AxisY.LabelStyle.Format = "₱#,##0";
            }
        }

        private void LoadMonthlySales(Series series)
        {
            ConfigureSplineAreaSeries(series);

            var salesData = FetchSalesData(@"
                SELECT 
                    TO_CHAR(createdat, 'YYYY-MM') as yearmonth,
                    SUM(totalamount) as monthlysales
                FROM pos_transactions
                WHERE DATE(createdat) >= DATE_TRUNC('month', CURRENT_DATE) - INTERVAL '5 months'
                GROUP BY TO_CHAR(createdat, 'YYYY-MM')
                ORDER BY yearmonth ASC");

            var values = PopulateMonthlyData(series, salesData);
            SetChartAxisRange(values, 5000, 1.2);

            chartSales.Legends[0].Enabled = false;
        }

        private void ConfigureSplineAreaSeries(Series series)
        {
            series.ChartType = SeriesChartType.SplineArea;
            series.Color = Color.FromArgb(120, 94, 240, 148);
            series.BorderColor = Color.FromArgb(94, 240, 148);
            series.BorderWidth = 4;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 10;
            series.MarkerColor = Color.FromArgb(46, 213, 115);
            series.MarkerBorderColor = Color.White;
            series.MarkerBorderWidth = 3;
            series.ShadowOffset = 3;
            series.ShadowColor = Color.FromArgb(80, 0, 0, 0);
        }

        private List<double> PopulateMonthlyData(Series series, Dictionary<string, decimal> salesData)
        {
            var values = new List<double>();

            for (int i = 5; i >= 0; i--)
            {
                DateTime date = DateTime.Today.AddMonths(-i);
                string yearMonth = date.ToString("yyyy-MM");
                string monthName = date.ToString("MMM");
                decimal sales = salesData.ContainsKey(yearMonth) ? salesData[yearMonth] : 0m;

                int pointIndex = series.Points.AddXY(monthName, (double)sales);
                values.Add((double)sales);

                series.Points[pointIndex].ToolTip = FormatMonthlyTooltip(date, sales);
            }

            return values;
        }

        private string FormatMonthlyTooltip(DateTime date, decimal sales)
        {
            return $"━━━━━━━━━━━━━━\n{date:MMMM yyyy}\n" +
                   $"━━━━━━━━━━━━━━\nTotal Sales: ₱{sales:N2}\n━━━━━━━━━━━━━━";
        }

        private void LoadYearlySales(Series series)
        {
            ConfigureDoughnutSeries(series);

            var modernColors = new Color[]
            {
                Color.FromArgb(108, 92, 231),
                Color.FromArgb(255, 107, 129),
                Color.FromArgb(94, 240, 148)
            };

            var salesData = FetchYearlySalesData();
            PopulateYearlyData(series, salesData, modernColors);

            chartSales.ChartAreas[0].Area3DStyle.Enable3D = false;
            chartSales.Legends[0].Enabled = true;
            chartSales.Legends[0].Font = new Font("Segoe UI Semibold", 11, FontStyle.Regular);
            chartSales.Legends[0].BackColor = Color.Transparent;
            chartSales.Legends[0].BorderColor = Color.Transparent;
            chartSales.Legends[0].LegendStyle = LegendStyle.Table;
        }

        private void ConfigureDoughnutSeries(Series series)
        {
            series.ChartType = SeriesChartType.Doughnut;
            series.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            series["DoughnutRadius"] = "45";
            series["PieLabelStyle"] = "Disabled";
        }

        private Dictionary<int, decimal> FetchYearlySalesData()
        {
            var salesData = new Dictionary<int, decimal>();

            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
            {
                string query = @"
                    SELECT 
                        EXTRACT(YEAR FROM createdat)::integer as year,
                        SUM(totalamount) as yearlysales
                    FROM pos_transactions
                    WHERE EXTRACT(YEAR FROM createdat) >= EXTRACT(YEAR FROM CURRENT_DATE) - 2
                    GROUP BY EXTRACT(YEAR FROM createdat)
                    ORDER BY year ASC";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int year = Convert.ToInt32(reader["year"]);
                        decimal sales = Convert.ToDecimal(reader["yearlysales"]);
                        salesData[year] = sales;
                    }
                }
            }

            return salesData;
        }

        private void PopulateYearlyData(Series series, Dictionary<int, decimal> salesData, Color[] colors)
        {
            int currentYear = DateTime.Now.Year;
            int colorIndex = 0;
            decimal totalSales = salesData.Values.Sum();

            for (int i = 2; i >= 0; i--)
            {
                int year = currentYear - i;
                decimal sales = salesData.ContainsKey(year) ? salesData[year] : 0m;

                if (sales > 0)
                {
                    decimal percentage = totalSales > 0 ? (sales / totalSales) * 100 : 0;
                    int pointIndex = AddYearlyDataPoint(series, year, sales, percentage, colors[colorIndex % colors.Length]);
                    colorIndex++;
                }
            }

            if (series.Points.Count == 0)
            {
                series.Points.AddXY(currentYear.ToString(), 0);
                series.Points[0].Color = Color.FromArgb(220, 221, 225);
                series.Points[0].LegendText = "No Data";
            }
        }

        private int AddYearlyDataPoint(Series series, int year, decimal sales, decimal percentage, Color color)
        {
            int pointIndex = series.Points.AddXY(year.ToString(), (double)sales);
            series.Points[pointIndex].Color = color;
            series.Points[pointIndex].BorderColor = Color.White;
            series.Points[pointIndex].BorderWidth = 4;
            series.Points[pointIndex].Label = string.Empty;
            series.Points[pointIndex].LegendText = $"{year}\n₱{sales:N0}\n{percentage:F1}%";
            series.Points[pointIndex].ToolTip = FormatYearlyTooltip(year, sales, percentage);
            return pointIndex;
        }

        private string FormatYearlyTooltip(int year, decimal sales, decimal percentage)
        {
            return $"━━━━━━━━━━━━━━\nYear {year}\n" +
                   $"━━━━━━━━━━━━━━\nSales: ₱{sales:N2}\nShare: {percentage:F1}%\n━━━━━━━━━━━━━━";
        }

        private void cmbSalesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbSalesFilter.SelectedItem.ToString();
            LoadSalesData(selected);
        }
        #endregion

        #region Category Chart
        private void SetupCategoryChart()
        {
            chartTopCategories.ChartAreas.Clear();
            chartTopCategories.Series.Clear();
            chartTopCategories.Legends.Clear();

            var area = CreateStandardChartArea("CategoryArea");
            ConfigureChartPosition(area, 5, 5, 50, 90);
            chartTopCategories.ChartAreas.Add(area);

            var legend = CreateTableLegend();
            ConfigureLegendPosition(legend, 58, 15, 40, 80);
            chartTopCategories.Legends.Add(legend);

            ConfigureChartBorder(chartTopCategories);
        }

        private ChartArea CreateStandardChartArea(string name)
        {
            return new ChartArea(name)
            {
                BackColor = Color.White,
                BorderColor = Color.FromArgb(230, 230, 230),
                BorderWidth = 1,
                BorderDashStyle = ChartDashStyle.Solid
            };
        }

        private void ConfigureChartPosition(ChartArea area, float x, float y, float width, float height)
        {
            area.Position.Auto = false;
            area.Position.X = x;
            area.Position.Y = y;
            area.Position.Width = width;
            area.Position.Height = height;
        }

        private Legend CreateTableLegend()
        {
            return new Legend
            {
                Docking = Docking.Right,
                Alignment = StringAlignment.Near,
                ForeColor = Color.FromArgb(50, 50, 50),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                BackColor = Color.Transparent,
                BorderColor = Color.Transparent,
                Enabled = true,
                LegendStyle = LegendStyle.Table,
                TableStyle = LegendTableStyle.Wide
            };
        }

        private void ConfigureLegendPosition(Legend legend, float x, float y, float width, float height)
        {
            legend.Position.Auto = false;
            legend.Position.X = x;
            legend.Position.Y = y;
            legend.Position.Width = width;
            legend.Position.Height = height;
        }

        private void ConfigureChartBorder(Chart chart)
        {
            chart.BackColor = Color.White;
            chart.BorderlineColor = Color.FromArgb(230, 230, 230);
            chart.BorderlineWidth = 1;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
        }

        private void LoadTopCategorySales()
        {
            chartTopCategories.Series.Clear();

            var series = CreateDoughnutSeries("Category Sales");
            var categoryColors = GetCategoryColors();
            var categoryData = FetchCategoryData();

            PopulateCategoryData(series, categoryData, categoryColors);
            ConfigureDoughnutAppearance(series);

            chartTopCategories.ChartAreas[0].Area3DStyle.Enable3D = false;
            chartTopCategories.Series.Add(series);
        }

        private Series CreateDoughnutSeries(string name)
        {
            return new Series(name)
            {
                ChartType = SeriesChartType.Doughnut,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                IsValueShownAsLabel = false,
                LegendText = "#VALX\n#PERCENT{P1}\n₱#VAL{N0}"
            };
        }

        private Color[] GetCategoryColors()
        {
            return new Color[]
            {
                Color.FromArgb(52, 152, 219),
                Color.FromArgb(46, 204, 113),
                Color.FromArgb(155, 89, 182),
                Color.FromArgb(241, 196, 15),
                Color.FromArgb(231, 76, 60)
            };
        }

        private List<(string Name, decimal Sales, int Qty)> FetchCategoryData()
        {
            var categoryData = new List<(string Name, decimal Sales, int Qty)>();

            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
            {
                string query = @"
                    SELECT 
                        c.categoryname,
                        SUM(ti.subtotal) as totalsales,
                        SUM(ti.quantity) as totalqty
                    FROM pos_transactionitems ti
                    INNER JOIN products p ON ti.itemid = p.productid
                    INNER JOIN categories c ON p.categoryid = c.categoryid
                    INNER JOIN pos_transactions t ON ti.transactionid = t.transactionid
                    WHERE ti.itemtype = 'Product'AND DATE(t.createdat) >= CURRENT_DATE - INTERVAL '30 days'
                    GROUP BY c.categoryid, c.categoryname
                    ORDER BY totalsales DESC
                    LIMIT 5";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string categoryName = reader["categoryname"].ToString();
                        decimal sales = Convert.ToDecimal(reader["totalsales"]);
                        int qty = Convert.ToInt32(reader["totalqty"]);
                        categoryData.Add((categoryName, sales, qty));
                    }
                }
            }

            return categoryData;
        }

        private void PopulateCategoryData(Series series, List<(string Name, decimal Sales, int Qty)> categoryData, Color[] colors)
        {
            if (categoryData.Count == 0)
            {
                AddNoDataPoint(series);
                return;
            }

            decimal totalSales = categoryData.Sum(c => c.Sales);
            int colorIndex = 0;

            foreach (var category in categoryData)
            {
                decimal percentage = totalSales > 0 ? (category.Sales / totalSales) * 100 : 0;
                int pointIndex = series.Points.AddXY(category.Name, (double)category.Sales);

                series.Points[pointIndex].Color = colors[colorIndex % colors.Length];
                series.Points[pointIndex].BorderColor = Color.White;
                series.Points[pointIndex].BorderWidth = 4;
                series.Points[pointIndex].ToolTip = FormatCategoryTooltip(category, percentage);
                series.Points[pointIndex].LegendText = $"{category.Name}\n{percentage:F1}%\n₱{category.Sales:N0}";

                colorIndex++;
            }
        }

        private void AddNoDataPoint(Series series)
        {
            series.Points.AddXY("No Data", 1);
            series.Points[0].Color = Color.FromArgb(200, 200, 200);
            series.Points[0].LegendText = "No Sales Data";
        }

        private string FormatCategoryTooltip((string Name, decimal Sales, int Qty) category, decimal percentage)
        {
            return $"━━━━━━━━━━━━━━━━\n{category.Name}\n━━━━━━━━━━━━━━━━\n" +
                   $"Sales: ₱{category.Sales:N2}\nQuantity: {category.Qty:N0} items\n" +
                   $"Share: {percentage:F1}% of total\n━━━━━━━━━━━━━━━━";
        }

        private void ConfigureDoughnutAppearance(Series series)
        {
            series["DoughnutRadius"] = "45";
            series["PieLabelStyle"] = "Disabled";
            series["DoughnutLabelStyle"] = "Disabled";
        }

        private void CustomizeLegend()
        {
            if (chartTopCategories.Legends.Count > 0)
            {
                var legend = chartTopCategories.Legends[0];
                legend.ItemColumnSpacing = 10;
                legend.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            }
        }
        #endregion

        // ==================== Highest Earning Services ====================
        private void SetupServicesChart()
        {
            chartTopServices.ChartAreas.Clear();
            chartTopServices.Series.Clear();
            chartTopServices.Legends.Clear();

            ChartArea area = new ChartArea("ServicesArea")
            {
                BackColor = Color.White,
                BorderColor = Color.FromArgb(230, 230, 230),
                BorderWidth = 1,
                BorderDashStyle = ChartDashStyle.Solid
            };

            area.Position.Auto = false;
            area.Position.X = 2;
            area.Position.Y = 5;
            area.Position.Width = 45;
            area.Position.Height = 90;

            chartTopServices.ChartAreas.Add(area);

            Legend legend = new Legend
            {
                Docking = Docking.Right,
                Alignment = StringAlignment.Near,
                ForeColor = Color.FromArgb(50, 50, 50),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                BackColor = Color.Transparent,
                BorderColor = Color.Transparent,
                Enabled = true,
                LegendStyle = LegendStyle.Table,
                TableStyle = LegendTableStyle.Wide
            };

            legend.Position.Auto = false;
            legend.Position.X = 50;
            legend.Position.Y = 10;
            legend.Position.Width = 48;
            legend.Position.Height = 85;

            legend.MaximumAutoSize = 100;
            legend.ItemColumnSpacing = 5;

            chartTopServices.Legends.Add(legend);

            chartTopServices.BackColor = Color.White;
            chartTopServices.BorderlineColor = Color.FromArgb(230, 230, 230);
            chartTopServices.BorderlineWidth = 1;
            chartTopServices.BorderlineDashStyle = ChartDashStyle.Solid;
            chartTopServices.AntiAliasing = AntiAliasingStyles.All;
            chartTopServices.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
        }

        private void LoadTopServices()
        {
            chartTopServices.Series.Clear();

            Series series = new Series("Service Revenue")
            {
                ChartType = SeriesChartType.Doughnut,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                IsValueShownAsLabel = false
            };

            Color[] serviceColors = new Color[]
            {
            Color.FromArgb(255, 107, 129),
            Color.FromArgb(108, 92, 231),
            Color.FromArgb(94, 240, 148),
            Color.FromArgb(255, 195, 113),
            Color.FromArgb(72, 219, 251)
            };

            using (var conn = ServerDatabase.GetConnection()) // ✅ PostgreSQL
            {
                if (conn == null) return;
                string query = @"
                SELECT 
                    s.servicename,
                    SUM(sd.price) AS totalrevenue,
                    COUNT(sd.detailid) AS timesavailed
                FROM pos_servicedetails sd
                INNER JOIN service s ON sd.serviceid = s.serviceid
                INNER JOIN pos_transactions t ON sd.transactionid = t.transactionid
                WHERE DATE(t.createdat) >= CURRENT_DATE - INTERVAL '30 days'
                GROUP BY s.serviceid, s.servicename
                ORDER BY totalrevenue DESC
                LIMIT 5";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    int colorIndex = 0;
                    decimal totalRevenue = 0m;

                    var serviceData = new List<(string Name, decimal Revenue, int Count)>();
                    while (reader.Read())
                    {
                        string serviceName = reader["servicename"].ToString();
                        decimal revenue = Convert.ToDecimal(reader["totalrevenue"]);
                        int count = Convert.ToInt32(reader["timesavailed"]);

                        serviceData.Add((serviceName, revenue, count));
                        totalRevenue += revenue;
                    }

                    foreach (var service in serviceData)
                    {
                        decimal percentage = totalRevenue > 0 ? (service.Revenue / totalRevenue) * 100 : 0;

                        int pointIndex = series.Points.AddXY(service.Name, (double)service.Revenue);

                        series.Points[pointIndex].Color = serviceColors[colorIndex % serviceColors.Length];
                        series.Points[pointIndex].BorderColor = Color.White;
                        series.Points[pointIndex].BorderWidth = 4;

                        series.Points[pointIndex].ToolTip =
                            $"{service.Name}\n" +
                            $"Revenue: ₱{service.Revenue:N2}\n" +
                            $"Availed: {service.Count:N0} times\n" +
                            $"Share: {percentage:F1}%";

                        series.Points[pointIndex].LegendText =
                            $"{service.Name}\n{percentage:F1}%\n₱{service.Revenue:N0}";

                        colorIndex++;
                    }

                    if (serviceData.Count == 0)
                    {
                        series.Points.AddXY("No Data", 1);
                        series.Points[0].Color = Color.FromArgb(200, 200, 200);
                        series.Points[0].LegendText = "No Service Data";
                    }
                }
            }

            series["DoughnutRadius"] = "45";
            series["PieLabelStyle"] = "Disabled";
            series["DoughnutLabelStyle"] = "Disabled";

            chartTopServices.ChartAreas[0].Area3DStyle.Enable3D = false;

            chartTopServices.Series.Add(series);
        }

        private void PnlSalesChart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartSales_Click(object sender, EventArgs e)
        {

        }
    }
}