using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PotpotMotorShopPOS.Controls;
using FontAwesome.Sharp;
using PotpotMotorShopPOS.Helpers;

namespace PotpotMotorShopPOS.Utilities
{
    public class FormController
    {
        private readonly Form _form;
        private IconButton _notificationBell;
        private Label _notificationBadge;
        private Timer _notificationTimer;

        public FormController(Form form)
        {
            _form = form;
        }

        // --- Window Control Functions ---
        public void Close() => _form.Close();
        public void Minimize() => _form.WindowState = FormWindowState.Minimized;

        // --- Style Icon Buttons (FontAwesome) ---
        public void StyleIconButton(IconButton btn, string type)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.IconColor = Color.FromArgb(41, 41, 66);
            btn.IconSize = 20;
            btn.Dock = DockStyle.Right;
            btn.Cursor = Cursors.Hand;

            switch (type.ToLower())
            {
                case "close":
                    btn.IconChar = IconChar.Xmark;
                    btn.Size = new Size(45, 40);
                    btn.Click += (s, e) => Close();
                    break;
                case "minimize":
                    btn.IconChar = IconChar.WindowMinimize;
                    btn.Size = new Size(45, 40);
                    btn.Click += (s, e) => Minimize();
                    break;
            }

            // Hover effects
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = type == "close"
                    ? Color.Red
                    : Color.FromArgb(64, 64, 64);
            };
            btn.MouseLeave += (s, e) => btn.BackColor = Color.Transparent;
        }

        // ✅ NEW: Create and Setup Notification Bell
        public IconButton CreateNotificationBell(EventHandler clickHandler = null, Point? location = null)
        {
            _notificationBell = new IconButton
            {
                IconChar = IconChar.Bell,
                IconColor = Color.FromArgb(94, 148, 255),
                IconSize = 24,
                Size = new Size(45, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Location = location ?? new Point(_form.Width - 150, 10)
            };

            _notificationBell.FlatAppearance.BorderSize = 0;

            // ✅ Notification Badge (Red Circle with Count)
            _notificationBadge = new Label
            {
                Size = new Size(20, 20),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Text = "0",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Visible = false
            };

            // Make badge circular
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, _notificationBadge.Width, _notificationBadge.Height);
            _notificationBadge.Region = new Region(path);

            // ✅ Position badge on top-right of bell
            _notificationBell.LocationChanged += (s, e) =>
            {
                _notificationBadge.Location = new Point(
                    _notificationBell.Right - 10,
                    _notificationBell.Top
                );
            };

            // Set initial badge position
            _notificationBadge.Location = new Point(
                _notificationBell.Right - 10,
                _notificationBell.Top
            );

            // ✅ Click event
            if (clickHandler != null)
                _notificationBell.Click += clickHandler;

            // ✅ Hover effects
            _notificationBell.MouseEnter += (s, e) =>
            {
                _notificationBell.IconColor = Color.FromArgb(70, 130, 230);
                _notificationBell.BackColor = Color.FromArgb(240, 245, 255);
            };

            _notificationBell.MouseLeave += (s, e) =>
            {
                _notificationBell.IconColor = Color.FromArgb(94, 148, 255);
                _notificationBell.BackColor = Color.Transparent;
            };

            // ✅ Add to form
            _form.Controls.Add(_notificationBell);
            _form.Controls.Add(_notificationBadge);
            _notificationBadge.BringToFront();

            // ✅ Start auto-refresh timer
            StartNotificationTimer();

            // ✅ Initial notification check
            UpdateNotificationBadge();

            return _notificationBell;
        }

        // ✅ Start Auto-Refresh Timer (Check every 30 seconds)
        private void StartNotificationTimer()
        {
            _notificationTimer = new Timer { Interval = 30000 }; // 30 seconds

            _notificationTimer.Tick += (s, e) =>
            {
                NotificationHelper.CheckAndGenerateNotifications();
                UpdateNotificationBadge();
            };

            _notificationTimer.Start();

            // ✅ Cleanup on form close
            _form.FormClosed += (s, e) =>
            {
                _notificationTimer?.Stop();
                _notificationTimer?.Dispose();
            };
        }

        // ✅ Update Notification Badge Count
        public void UpdateNotificationBadge()
        {
            if (_notificationBadge == null) return;

            int count = NotificationHelper.GetUnreadCount();

            if (count > 0)
            {
                _notificationBadge.Text = count > 99 ? "99+" : count.ToString();
                _notificationBadge.Visible = true;

                // ✅ Animate bell icon (shake effect)
                AnimateBellIcon();
            }
            else
            {
                _notificationBadge.Visible = false;
            }
        }

        // ✅ Animate Bell Icon (Shake Effect)
        private void AnimateBellIcon()
        {
            if (_notificationBell == null) return;

            // Simple shake animation
            var originalColor = _notificationBell.IconColor;
            _notificationBell.IconColor = Color.FromArgb(255, 100, 100); // Red flash

            Timer animTimer = new Timer { Interval = 300 };
            animTimer.Tick += (s, e) =>
            {
                _notificationBell.IconColor = originalColor;
                animTimer.Stop();
                animTimer.Dispose();
            };
            animTimer.Start();
        }

        // ✅ Get Notification Bell (for external access)
        public IconButton GetNotificationBell() => _notificationBell;

        // ✅ Get Notification Badge (for external access)
        public Label GetNotificationBadge() => _notificationBadge;

        // --- Enable Form Dragging on a Control (like panel or label) ---
        public void EnableDrag(Control control)
        {
            control.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(_form.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }

        // --- Add Bottom Border to Any Control ---
        public void AddBottomBorder(Control control, Color color, int thickness = 2)
        {
            control.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(color, thickness))
                {
                    e.Graphics.DrawLine(
                        pen,
                        0, control.Height - 1,
                        control.Width, control.Height - 1
                    );
                }
            };
            control.Resize += (s, e) => control.Invalidate();
        }

        // --- Native WinAPI for dragging ---
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}