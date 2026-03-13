using FontAwesome.Sharp;
using PotpotMotorShopPOS.Forms.AdminManagement;
using PotpotMotorShopPOS.Forms.Authentication;
using PotpotMotorShopPOS.Forms.POS;
using PotpotMotorShopPOS.Helpers;
using PotpotMotorShopPOS.Utilities;
using PotpotMotorShopPOS.Views.Management;
using PotpotMotorShopPOS.Views.Reports;
using System;
using PotpotMotorShopPOS.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Views.Authentication
{
    public partial class MainForm : Form
    {
        // ✅ USE ONE CONSISTENT VARIABLE NAME
        private FormController _controller;
        private SidebarController _sidebarController;
        private Label lblTitle;
        private Label lblDateTime;
        private Timer dateTimeTimer;
        private FontAwesome.Sharp.IconPictureBox iconCurrent;
        private NotificationPanel _notificationPanel;

        private IconButton btnClose;
        private IconButton btnMinimize;
        private Panel sidebarPanel;

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            // ✅ Initialize FormController ONCE
            _controller = new FormController(this);

            SetupCustomTitleBar();
            SetupSidebar();

            // ✅ IMPORTANT: Load Dashboard when MainForm opens
            this.Load += MainForm_Load;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        PnlOne.Controls.Clear();
                        DashboardControl uc = new DashboardControl();
                        uc.Dock = DockStyle.Fill;
                        PnlOne.Controls.Add(uc);
                        uc.BringToFront();
                        lblTitle.Text = "Statistical Dashboard";
                        iconCurrent.IconChar = FontAwesome.Sharp.IconChar.Tachometer;
                        iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
                    }));
                });
            }, minimumDelayMs: 1000, loadingText: "Loading Dashboard...");

            _controller.StyleIconButton(btnClose, "close");
            _controller.StyleIconButton(btnMinimize, "minimize");

            // Create notification panel
            _notificationPanel = new NotificationPanel
            {
                Visible = false,
                Location = new Point(this.Width - 360, 75)
            };

            _notificationPanel.NotificationCountChanged += (s, ev) =>
            {
                UpdateNotificationBadge();
            };

            this.Controls.Add(_notificationPanel);
            _notificationPanel.BringToFront();

            // ✅ Initial check on startup
            NotificationHelper.CheckAndGenerateNotifications();
            UpdateNotificationBadge();

        }

        private void UpdateNotificationBadge()
        {
            // Find the badge label that was created in SetupCustomTitleBar
            var badge = this.Controls.Find("lblNotificationBadge", true).FirstOrDefault() as Label;

            if (badge == null)
            {
                System.Diagnostics.Debug.WriteLine("❌ [Badge] Label not found!");
                return;
            }

            int count = NotificationHelper.GetUnreadCount();
            System.Diagnostics.Debug.WriteLine($"✅ [Badge] Updating badge. Count: {count}");

            if (count > 0)
            {
                badge.Text = count > 99 ? "99+" : count.ToString();
                badge.Visible = true;
            }
            else
            {
                badge.Visible = false;
            }
        }

        private void BtnNotification_Click(object sender, EventArgs e)
        {
            _notificationPanel.Visible = !_notificationPanel.Visible;

            if (_notificationPanel.Visible)
            {
                _notificationPanel.LoadNotifications();
                _notificationPanel.BringToFront();
            }
        }

        private void SetupCustomTitleBar()
        {
            // --- Top Panel ---
            var topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.White
            };

            var bottomBorder = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 1,
                BackColor = Color.LightGray,
            };

            topPanel.Controls.Add(bottomBorder);
            this.Controls.Add(topPanel);

            // --- Title Icon ---
            iconCurrent = new IconPictureBox
            {
                IconChar = IconChar.None,
                IconColor = Color.FromArgb(41, 41, 66),
                IconSize = 70,
                Size = new Size(50, 50),
                Location = new Point(5, 15),
                BackColor = Color.Transparent
            };
            topPanel.Controls.Add(iconCurrent);

            // --- Title Text ---
            lblTitle = new Label
            {
                Text = "",
                ForeColor = Color.FromArgb(41, 41, 66),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(iconCurrent.Right + 5, 18)
            };
            topPanel.Controls.Add(lblTitle);

            // --- DateTime (centered) ---
            lblDateTime = new Label
            {
                ForeColor = Color.FromArgb(41, 41, 66),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true
            };
            topPanel.Controls.Add(lblDateTime);

            // ✅ IMPORTANT: Add buttons in REVERSE order (last added = rightmost)

            // ✅ 1. NOTIFICATION BELL (add FIRST, will be leftmost of the three)
            var btnNotification = new IconButton
            {
                IconChar = IconChar.Bell,
                IconColor = Color.FromArgb(94, 148, 255),
                IconSize = 24,
                Size = new Size(45, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Right,
                Name = "btnNotification"
            };
            btnNotification.FlatAppearance.BorderSize = 0;
            btnNotification.Click += BtnNotification_Click;

            // Hover effects
            btnNotification.MouseEnter += (s, e) =>
            {
                btnNotification.IconColor = Color.FromArgb(70, 130, 230);
                btnNotification.BackColor = Color.FromArgb(240, 245, 255);
            };
            btnNotification.MouseLeave += (s, e) =>
            {
                btnNotification.IconColor = Color.FromArgb(94, 148, 255);
                btnNotification.BackColor = Color.Transparent;
            };

            topPanel.Controls.Add(btnNotification);

            // ✅ 2. MINIMIZE BUTTON (add SECOND, will be in the middle)
            btnMinimize = new IconButton();
            _controller.StyleIconButton(btnMinimize, "minimize");
            topPanel.Controls.Add(btnMinimize);

            // ✅ 3. CLOSE BUTTON (add LAST, will be rightmost)
            btnClose = new IconButton();
            _controller.StyleIconButton(btnClose, "close");
            topPanel.Controls.Add(btnClose);

            // ✅ CREATE NOTIFICATION BADGE (red circle)
            var lblNotificationBadge = new Label
            {
                Size = new Size(20, 20),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Text = "0",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Visible = false,
                Name = "lblNotificationBadge"
            };

            // Make badge circular
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, lblNotificationBadge.Width, lblNotificationBadge.Height);
            lblNotificationBadge.Region = new Region(path);

            topPanel.Controls.Add(lblNotificationBadge);
            lblNotificationBadge.BringToFront();

            // ✅ Position badge on bell button
            topPanel.Layout += (s, e) =>
            {
                lblNotificationBadge.Location = new Point(
                    btnNotification.Right - 10,
                    btnNotification.Top
                );
            };

            // --- Timer for Date/Time ---
            dateTimeTimer = new Timer { Interval = 1000 };
            dateTimeTimer.Tick += (s, e) =>
            {
                lblDateTime.Text = DateTime.Now.ToString("MMM dd, yyyy  hh:mm:ss tt");
                lblDateTime.Location = new Point(
                    (topPanel.Width - lblDateTime.Width) / 2,
                    (topPanel.Height - lblDateTime.Height) / 2
                );
            };
            dateTimeTimer.Start();

            // --- Make panel draggable ---
            _controller.EnableDrag(topPanel);

            // --- Add bottom border ---
            _controller.AddBottomBorder(topPanel, Color.LightGray, 1);
        }



        // ----------------- SIDEBAR -----------------
        private void SetupSidebar()
        {
            sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 380,
                BackColor = Color.White
            };
            this.Controls.Add(sidebarPanel);

            _sidebarController = new SidebarController(sidebarPanel);
            _sidebarController.AddLogoFromResources("2ND");

            // Main menu buttons
            _sidebarController.AddButton("Dashboard", IconChar.Tachometer, Dashboard_Click);

            var productsDropdown = new List<DropdownItem>
            {
                new DropdownItem("List", IconChar.List, ProductList_Click),
                new DropdownItem("Category", IconChar.Tags, ProductCategory_Click),
            };
            _sidebarController.AddDropdownButton("Products", IconChar.Boxes, productsDropdown);
            _sidebarController.AddButton("Services List", IconChar.Tools, ServiceList_Click);

            var stockDropdown = new List<DropdownItem>
            {
                new DropdownItem("Entry", IconChar.PlusCircle, StockEntry_Click),
                new DropdownItem("History", IconChar.History, StockInHistory_Click),
                new DropdownItem("Adjustment", IconChar.Edit, StockAdjustment_Click),
            };
            _sidebarController.AddDropdownButton("Stock", IconChar.Warehouse, stockDropdown);

            //_sidebarController.AddButton("Point of Sales", IconChar.ShoppingCart, Sales_Click);
            _sidebarController.AddButton("Supplier", IconChar.Truck, Supplier_Click);
            var reportsDropdown = new List<DropdownItem>
            {
                new DropdownItem("Sales", IconChar.ChartLine, SalesReport_Click),
                new DropdownItem("Critical", IconChar.ExclamationTriangle, CriticalStocksReportControl_Click),
                new DropdownItem("No Stocks", IconChar.TimesCircle, OutofStocksReport_Click),
                new DropdownItem("Damage", IconChar.Bug, DamageProductReport_Click),
                new DropdownItem("AuditLogs", IconChar.Edit, AuditLogs_Click),
            };
            _sidebarController.AddDropdownButton("Reports", IconChar.FileText, reportsDropdown);

            // 👉 Role-based POS button gamit ang SessionManager
            if (SessionManager.IsAdmin)
            {
                _sidebarController.AddButton("Point of Sales", IconChar.ShoppingCart, POSForm_Click);
            }

            var settingsDropdown = new List<DropdownItem>
            {
                new DropdownItem("User", IconChar.UserCog, UserManagement_Click),
                //new DropdownItem("System Settings", IconChar.Cogs, SystemSettings_Click),
                new DropdownItem("Backup", IconChar.Database, BackupRestore_Click),
                new DropdownItem("Logout", IconChar.SignOut, Logout_Click),

            };
            _sidebarController.AddDropdownButton("Settings", IconChar.Gear, settingsDropdown);

            
        }

        private void LoadContent(UserControl control, string title)
        {
            lblTitle.Text = $" {title}";

            PnlOne.SuspendLayout();
            PnlOne.Controls.Clear();

            control.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(control);
            control.BringToFront();

            PnlOne.ResumeLayout();
        }


        // ✅ Updated with LoadingHelper.RunWithLoading pattern

        private async void Dashboard_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;
            string errorMessage = "";

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    // ✅ Check connection first
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Dashboard Please Wait!...");

            // ✅ Show error AFTER loading is hidden
            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // ✅ Connection OK - load control
            PnlOne.Controls.Clear();
            DashboardControl uc = new DashboardControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Statistical Dashboard";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.Tachometer;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void ProductList_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Products Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            ProductListControl uc = new ProductListControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Product Management";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.List;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void ProductCategory_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Categories Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            ProductCategoryControl uc = new ProductCategoryControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Product Category Management";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.Tags;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void ServiceList_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Services Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            ServiceListControl uc = new ServiceListControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Service List";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.Tools;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void StockEntry_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Stock Entry Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            StockEntryControl uc = new StockEntryControl();
            uc.Dock = DockStyle.Fill;

            // 🔹 Subscribe sa event
            uc.StockEntrySaved += () =>
            {
                var plc = PnlOne.Controls.OfType<ProductListControl>().FirstOrDefault();
                plc?.LoadProducts();
            };

            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Stock List";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void StockInHistory_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading History Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            StockInHistoryControl uc = new StockInHistoryControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Stock In History";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.History;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void StockAdjustment_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Stock Adjustment Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            StockAdjustmentControl uc = new StockAdjustmentControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Stock Management";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.Edit;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void Supplier_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Suppliers Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            Supplier_Control uc = new Supplier_Control();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Supplier Management";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.Truck;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void SalesReport_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Sales Report Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            SalesReportControl uc = new SalesReportControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Sales Report";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void CriticalStocksReportControl_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Critical Stocks Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            CriticalStocksReportControl uc = new CriticalStocksReportControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Critical Stocks";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void OutofStocksReport_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Out of Stock Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            OutofStocksReportControl uc = new OutofStocksReportControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Out Of Stock";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void DamageProductReport_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Damage Report Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            DamageProductReportControl uc = new DamageProductReportControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Damage Product List";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.Bug;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void AuditLogs_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Audit logs Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            AuditLogsControl uc = new AuditLogsControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Audit Logs";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.Bug;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void UserManagement_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading User Management Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            UserManagementControl uc = new UserManagementControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "User Account Management";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.UserCog;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private async void POSForm_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            try
            {
                // ✅ Show loading overlay then check connection
                await LoadingHelper.RunWithLoading(this, async () =>
                {
                    await Task.Run(() =>
                    {
                        using (var conn = ServerDatabase.GetConnection())
                        {
                            connectionSuccess = (conn != null);
                        }
                    });
                }, minimumDelayMs: 1000, loadingText: "Loading POS Please Wait!...");

                if (!connectionSuccess)
                {
                    MessageBox.Show(
                        "Unable to connect to the database server.\n\n" +
                        "Please check your connection and try again.",
                        "Connection Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // 👉 Open POSForm only if connection is OK
                using (var posForm = new POSForm())
                {
                    posForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading POS: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BackupRestore_Click(object sender, EventArgs e)
        {
            bool connectionSuccess = false;

            await LoadingHelper.RunWithLoading(this, async () =>
            {
                await Task.Run(() =>
                {
                    using (var conn = ServerDatabase.GetConnection())
                    {
                        connectionSuccess = (conn != null);
                    }
                });
            }, minimumDelayMs: 1500, loadingText: "Loading Backup & Restore Please Wait!...");

            if (!connectionSuccess)
            {
                MessageBox.Show(
                    "Unable to connect to the database server.\n\n" +
                    "Please check your connection and try again.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            PnlOne.Controls.Clear();
            BackupRestoreControl uc = new BackupRestoreControl();
            uc.Dock = DockStyle.Fill;
            PnlOne.Controls.Add(uc);
            uc.BringToFront();
            lblTitle.Text = "Back_Up and Restore";
            iconCurrent.IconChar = FontAwesome.Sharp.IconChar.Database;
            iconCurrent.IconColor = Color.FromArgb(41, 41, 66);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide(); // hide current form

                // open login form again
                var loginForm = new LoginForm();
                loginForm.Show();
                SessionManager.ClearSession();
            }
        }

        // 🔹 Placeholder UserControl (temporary para wala error)
        public class PlaceholderControl : UserControl
        {
            public PlaceholderControl(string text)
            {
                this.Dock = DockStyle.Fill;
                Label lbl = new Label
                {
                    Text = text,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                this.Controls.Add(lbl);
            }
        }

        private void PnlOne_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
