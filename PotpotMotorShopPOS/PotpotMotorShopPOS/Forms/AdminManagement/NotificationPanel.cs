using Guna.UI2.WinForms;
using PotpotMotorShopPOS.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Controls
{
    public partial class NotificationPanel : UserControl
    {
        private FlowLayoutPanel flowNotifications;
        private Label lblNoNotifications;

        public NotificationPanel()
        {
            InitializeUI();
            LoadNotifications();
        }

        private void InitializeUI()
        {
            this.SuspendLayout();

            this.Size = new Size(350, 400);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;

            // Header
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(94, 148, 255)
            };

            var lblHeader = new Label
            {
                Text = "Stock Notifications",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0)
            };

            var btnMarkAll = new Guna2Button
            {
                Text = "Mark All Read",
                Size = new Size(110, 30),
                Location = new Point(220, 10),
                FillColor = Color.Transparent,
                ForeColor = Color.White,
                BorderColor = Color.White,
                BorderThickness = 1,
                Font = new Font("Segoe UI", 8),
                Cursor = Cursors.Hand
            };
            btnMarkAll.Click += BtnMarkAll_Click;

            header.Controls.Add(lblHeader);
            header.Controls.Add(btnMarkAll);

            // Notifications flow panel
            flowNotifications = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(5)
            };

            // No notifications label
            lblNoNotifications = new Label
            {
                Text = "No new notifications",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Visible = false
            };

            this.Controls.Add(flowNotifications);
            this.Controls.Add(header);
            this.Controls.Add(lblNoNotifications);

            this.ResumeLayout(false);
        }

        public void LoadNotifications()
        {
            flowNotifications.Controls.Clear();

            var notifications = NotificationHelper.GetUnreadNotifications();

            if (notifications.Count == 0)
            {
                lblNoNotifications.Visible = true;
                lblNoNotifications.BringToFront();
                return;
            }

            lblNoNotifications.Visible = false;

            foreach (var notif in notifications)
            {
                var panel = CreateNotificationItem(notif);
                flowNotifications.Controls.Add(panel);
            }
        }

        private Panel CreateNotificationItem(StockNotification notif)
        {
            var panel = new Panel
            {
                Width = flowNotifications.Width - 25,
                Height = 80,
                BackColor = notif.NotificationType == "OUT_OF_STOCK"
                    ? Color.FromArgb(255, 230, 230)
                    : Color.FromArgb(255, 250, 200),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3),
                Cursor = Cursors.Hand
            };

            // ✅ Icon - fixed size and centered
            var lblIcon = new Label
            {
                Text = notif.NotificationType == "OUT_OF_STOCK" ? "⚠️" : "⚡",
                Font = new Font("Segoe UI", 24),
                Location = new Point(10, 25),
                Size = new Size(40, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ✅ Product name - moved further right to avoid overlap
            var lblProduct = new Label
            {
                Text = notif.ProductName,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(60, 10),
                AutoSize = true,
                MaximumSize = new Size(260, 0)
            };

            // ✅ Details - moved further right
            var lblDetails = new Label
            {
                Text = notif.NotificationType == "OUT_OF_STOCK"
                    ? "Out of Stock!"
                    : $"Critical Stock: {notif.CurrentStock} left",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DarkRed,
                Location = new Point(60, 32),
                AutoSize = true
            };

            // ✅ Time - moved further right
            var lblTime = new Label
            {
                Text = GetTimeAgo(notif.CreatedAt),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(60, 52),
                AutoSize = true
            };

            panel.Controls.AddRange(new Control[] { lblIcon, lblProduct, lblDetails, lblTime });

            // ✅ Click event to mark as read
            panel.Click += (s, e) =>
            {
                NotificationHelper.MarkAsRead(notif.NotificationID);
                LoadNotifications();
                OnNotificationCountChanged();
            };

            return panel;
        }

        private void BtnMarkAll_Click(object sender, EventArgs e)
        {
            NotificationHelper.MarkAllAsRead();
            LoadNotifications();
            OnNotificationCountChanged();
        }

        private string GetTimeAgo(DateTime dateTime)
        {
            var span = DateTime.Now - dateTime;

            if (span.TotalMinutes < 1) return "Just now";
            if (span.TotalHours < 1) return $"{(int)span.TotalMinutes}m ago";
            if (span.TotalDays < 1) return $"{(int)span.TotalHours}h ago";
            return $"{(int)span.TotalDays}d ago";
        }

        public event EventHandler NotificationCountChanged;

        protected virtual void OnNotificationCountChanged()
        {
            NotificationCountChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}