using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace POS_INVENTORY_SYSTEM.Utilities
{
    public static class UIHelper
    {
        // 🔁 Reusable method for rounded path
        private static GraphicsPath GetRoundedPath(int width, int height, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(width - radius, 0, radius, radius, 270, 90);
            path.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            path.AddArc(0, height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        // 🔵 Round a Form with optional shadow and border
        public static void RoundForm(Form form, int radius, Color? borderColor = null, int borderWidth = 1, int shadowSize = 5, Color? shadowColor = null)
        {
            if (shadowColor == null)
                shadowColor = Color.FromArgb(60, 0, 0, 0); // Default semi-transparent shadow

            form.FormBorderStyle = FormBorderStyle.None;
            form.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


                // Rounded region
                GraphicsPath mainPath = GetRoundedPath(form.Width - 1, form.Height - 1, radius);
                form.Region = new Region(mainPath);

                // Optional border
                if (borderColor.HasValue)
                {
                    using (Pen borderPen = new Pen(borderColor.Value, borderWidth))
                    {
                        e.Graphics.DrawPath(borderPen, mainPath);
                    }
                }
            };

            form.Invalidate();
        }

        // 🟣 Round a Panel with optional border
        public static void RoundPanel(Panel panel, int radius, Color? borderColor = null, int borderWidth = 1)
        {
            void ApplyRegion()
            {
                panel.Region = new Region(GetRoundedPath(panel.Width, panel.Height, radius));
                panel.Invalidate(); // Redraw for paint
            }

            // Initial apply
            ApplyRegion();

            // Apply again when resized
            panel.Resize += (s, e) => ApplyRegion();

            // Optional border drawing
            if (borderColor.HasValue)
            {
                panel.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(borderColor.Value, borderWidth))
                    {
                        e.Graphics.DrawPath(pen, GetRoundedPath(panel.Width - 1, panel.Height - 1, radius));
                    }
                };
            }
        }


        // 🟣 Apply Shadow to Rounded Control (e.g., Panel)
        public static void ApplyShadow(Control control, int radius, int shadowSize = 5, Color? shadowColor = null)
        {
            if (shadowColor == null)
                shadowColor = Color.FromArgb(60, 0, 0, 0);

            control.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle shadowRect = new Rectangle(shadowSize, shadowSize, control.Width - shadowSize, control.Height - shadowSize);

                using (GraphicsPath shadowPath = GetRoundedPath(shadowRect.Width, shadowRect.Height, radius))
                using (SolidBrush shadowBrush = new SolidBrush(shadowColor.Value))
                {
                    e.Graphics.FillPath(shadowBrush, shadowPath);
                }

                using (GraphicsPath mainPath = GetRoundedPath(control.Width - 1, control.Height - 1, radius))
                {
                    control.Region = new Region(mainPath);
                }
            };

            control.Invalidate();
        }

        // 🔵 Round a Button
        public static void RoundButton(Button button, int radius)
        {
            button.Region = new Region(GetRoundedPath(button.Width, button.Height, radius));
        }

        // 🔵 Round a TextBox (wrapper approach, optional border)
        public static void RoundTextBox(TextBox textBox, int radius, Color? borderColor = null, int borderWidth = 1)
        {
            textBox.BorderStyle = BorderStyle.None;

            Panel wrapper = new Panel();
            wrapper.Size = new Size(textBox.Width + 10, textBox.Height + 10);
            wrapper.BackColor = textBox.BackColor;
            wrapper.Location = new Point(textBox.Left - 5, textBox.Top - 5);
            textBox.Parent.Controls.Add(wrapper);
            wrapper.Controls.Add(textBox);
            textBox.Location = new Point(5, 5);

            wrapper.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                GraphicsPath path = GetRoundedPath(wrapper.Width - 1, wrapper.Height - 1, radius);
                wrapper.Region = new Region(path);

                if (borderColor.HasValue)
                {
                    using (Pen pen = new Pen(borderColor.Value, borderWidth))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            wrapper.BringToFront();
        }

        // 🔵 Round a ComboBox with optional border
        public static void RoundComboBox(ComboBox comboBox, int radius, Color? borderColor = null, int borderWidth = 1)
        {
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Region = new Region(GetRoundedPath(comboBox.Width, comboBox.Height, radius));

            if (borderColor.HasValue)
            {
                comboBox.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(borderColor.Value, borderWidth))
                    {
                        e.Graphics.DrawPath(pen, GetRoundedPath(comboBox.Width - 1, comboBox.Height - 1, radius));
                    }
                };
                comboBox.Invalidate();
            }
        }

        // 🔵 Round a PictureBox
        public static void RoundPictureBox(PictureBox pictureBox, int radius)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Region = new Region(GetRoundedPath(pictureBox.Width, pictureBox.Height, radius));
        }

        // 🔵 Round a GroupBox with optional border
        public static void RoundGroupBox(GroupBox groupBox, int radius, Color? borderColor = null, int borderWidth = 1)
        {
            groupBox.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                GraphicsPath path = GetRoundedPath(groupBox.Width - 1, groupBox.Height - 1, radius);

                if (borderColor.HasValue)
                {
                    using (Pen pen = new Pen(borderColor.Value, borderWidth))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                groupBox.Region = new Region(path);
            };


        }

        // 🔵 Round a Label with optional border
        public static void RoundLabel(Label label, int radius, Color? borderColor = null, int borderWidth = 1)
        {
            label.Region = new Region(GetRoundedPath(label.Width, label.Height, radius));

            if (borderColor.HasValue)
            {
                label.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(borderColor.Value, borderWidth))
                    {
                        e.Graphics.DrawPath(pen, GetRoundedPath(label.Width - 1, label.Height - 1, radius));
                    }
                };
                label.Invalidate();
            }
        }

        // 🔵 Round a UserControl with optional border
        public static void RoundUserControl(UserControl userControl, int radius, Color? borderColor = null, int borderWidth = 1)
        {
            void ApplyRegion()
            {
                userControl.Region = new Region(GetRoundedPath(userControl.Width, userControl.Height, radius));
                userControl.Invalidate();
            }

            // Initial apply
            ApplyRegion();

            // Apply again when resized
            userControl.Resize += (s, e) => ApplyRegion();

            // Optional border
            if (borderColor.HasValue)
            {
                userControl.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(borderColor.Value, borderWidth))
                    {
                        e.Graphics.DrawPath(pen, GetRoundedPath(userControl.Width - 1, userControl.Height - 1, radius));
                    }
                };
            }
        }

        // ----- Draggable Form -----
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public static void MakeFormDraggable(Control control, Form targetForm)
        {
            control.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(targetForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }
    }
}
