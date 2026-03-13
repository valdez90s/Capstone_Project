using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace PotpotMotorShopPOS.Utilities
{
    public class SidebarController
    {
        private readonly Panel _sidebarPanel;
        private readonly List<SidebarButton> _buttons;
        private SidebarButton _activeButton;
        private Panel _logoPanel;

        public SidebarController(Panel sidebarPanel)
        {
            _sidebarPanel = sidebarPanel;
            _buttons = new List<SidebarButton>();
            InitializeSidebar();
        }

        private void InitializeSidebar()
        {
            _sidebarPanel.BackColor = Color.White;
            _sidebarPanel.AutoScroll = true;

            // Add right border
            _sidebarPanel.BorderStyle = BorderStyle.None;
            _sidebarPanel.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.LightGray, 1))
                {
                    e.Graphics.DrawLine(pen, _sidebarPanel.Width - 1.5f, 0, _sidebarPanel.Width - 1, _sidebarPanel.Height);
                }
            };

            // Add shadow effect (optional small panel)
            var shadowPanel = new Panel
            {
                Dock = DockStyle.Right,
                Width = 5,
                BackColor = Color.FromArgb(230, 230, 230)
            };
        }

        // --- Add Company Logo ---
        public void AddLogo(Image logoImage, string companyName = "")
        {
            _logoPanel = new Panel
            {
                Height = 200,
                Dock = DockStyle.Top,
                BackColor = Color.White,
                Width = 200
            };

            _logoPanel.Left = (_sidebarPanel.Width - _logoPanel.Width) / 2;

            _sidebarPanel.Resize += (s, e) =>
            {
                _logoPanel.Left = (_sidebarPanel.Width - _logoPanel.Width) / 2;
            };

            var pictureBox = new PictureBox
            {
                Image = logoImage,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            pictureBox.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.DrawLine(pen, pictureBox.Width - 1, 0, pictureBox.Width - 1, pictureBox.Height);
                }
            };

            _logoPanel.Controls.Add(pictureBox);
            _sidebarPanel.Controls.Add(_logoPanel);
            _logoPanel.BringToFront();
        }

        // --- Add Logo from Resources ---
        public void AddLogoFromResources(string resourceName, string companyName = "")
        {
            try
            {
                var assembly = System.Reflection.Assembly.GetCallingAssembly();
                var resourceManager = new System.Resources.ResourceManager($"{assembly.GetName().Name}.Properties.Resources", assembly);
                var logoImage = (Image)resourceManager.GetObject(resourceName);

                if (logoImage != null)
                {
                    AddLogo(logoImage, companyName);
                }
                else
                {
                    CreateTextLogo(companyName);
                }
            }
            catch
            {
                CreateTextLogo(companyName);
            }
        }

        private void CreateTextLogo(string companyName)
        {
            _logoPanel = new Panel
            {
                Height = 80,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(41, 41, 66)
            };

            var label = new Label
            {
                Text = !string.IsNullOrEmpty(companyName) ? companyName : "LOGO",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            label.Location = new Point((_logoPanel.Width - label.Width) / 2, (_logoPanel.Height - label.Height) / 2);

            _logoPanel.Resize += (s, e) =>
            {
                label.Location = new Point((_logoPanel.Width - label.Width) / 2, (_logoPanel.Height - label.Height) / 2);
            };

            _logoPanel.Controls.Add(label);
            _sidebarPanel.Controls.Add(_logoPanel);
        }

        // --- Add Main Button ---
        public SidebarButton AddButton(string text, IconChar icon, EventHandler clickHandler = null, bool isBottomButton = false)
        {
            var button = new SidebarButton(text, icon, false);
            StyleButton(button);

            if (clickHandler != null)
                button.Click += clickHandler;

            button.Click += (s, e) => SetActiveButton(button);

            if (isBottomButton)
            {
                button.Dock = DockStyle.Bottom;
            }
            else
            {
                button.Location = GetNextButtonPosition();
            }

            _sidebarPanel.Controls.Add(button);
            _buttons.Add(button);

            return button;
        }

        private Point GetNextButtonPosition()
        {
            int startY = _logoPanel != null ? _logoPanel.Bottom : 0;

            var buttons = _sidebarPanel.Controls.Cast<Control>()
                         .Where(c => c is SidebarButton && c.Dock != DockStyle.Bottom)
                         .Cast<SidebarButton>()
                         .ToList();

            if (!buttons.Any())
                return new Point(0, startY);

            var lastButton = buttons.OrderBy(b => b.Top).LastOrDefault();
            if (lastButton != null)
            {
                if (lastButton.DropdownPanel != null && lastButton.DropdownPanel.Visible)
                {
                    return new Point(0, lastButton.DropdownPanel.Bottom);
                }
                else
                {
                    return new Point(0, lastButton.Bottom);
                }
            }

            return new Point(0, startY);
        }

        public SidebarButton AddDropdownButton(string text, IconChar icon, List<DropdownItem> dropdownItems, bool isBottomButton = false)
        {
            var button = new SidebarButton(text, icon, true);
            StyleButton(button);

            var dropdownPanel = CreateDropdownPanel(dropdownItems, button);
            button.DropdownPanel = dropdownPanel;

            button.Click += (s, e) => ToggleDropdown(button);

            if (isBottomButton)
            {
                button.Dock = DockStyle.Bottom;
                _sidebarPanel.Controls.Add(button);
                _sidebarPanel.Controls.Add(dropdownPanel);
            }
            else
            {
                button.Location = GetNextButtonPosition();
                _sidebarPanel.Controls.Add(button);
                _sidebarPanel.Controls.Add(dropdownPanel);
                dropdownPanel.Location = new Point(0, button.Bottom);
            }

            _buttons.Add(button);
            dropdownPanel.Visible = false;

            return button;
        }

        private Panel CreateDropdownPanel(List<DropdownItem> items, SidebarButton parentButton)
        {
            int buttonHeight = 50;

            var panel = new Panel
            {
                Width = _sidebarPanel.Width,
                Height = items.Count * buttonHeight,
                BackColor = Color.FromArgb(224, 224, 224),
                Visible = false
            };

            int yPosition = 0;
            foreach (var item in items)
            {
                var subButton = new SidebarSubButton(item.Text, item.Icon);
                subButton.Location = new Point(0, yPosition);
                subButton.Width = panel.Width;
                subButton.Height = buttonHeight;

                if (item.ClickHandler != null)
                    subButton.Click += item.ClickHandler;

                subButton.Click += (s, e) =>
                {
                    // ✅ FIXED: Update active sub-item WITHOUT closing the dropdown
                    parentButton.ActiveSubItem = item.Text;
                    UpdateButtonText(parentButton);

                    // Keep the parent button as active but don't trigger SetActiveButton
                    // (which would close the dropdown)
                    if (_activeButton != parentButton)
                    {
                        SetActiveButton(parentButton);
                    }
                };

                StyleSubButton(subButton);
                panel.Controls.Add(subButton);
                yPosition += buttonHeight;
            }

            return panel;
        }

        private void StyleButton(SidebarButton button)
        {
            button.Width = _sidebarPanel.Width;
            button.Height = 70;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.FromArgb(41, 41, 66);
            button.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            button.TextAlign = ContentAlignment.MiddleLeft;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.IconColor = Color.FromArgb(41, 41, 66);
            button.IconSize = 50;
            button.Padding = new Padding(15, 0, 45, 0);

            button.FlatAppearance.MouseOverBackColor = Color.LightGray;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 41, 66);

            button.Cursor = Cursors.Hand;
        }

        private void StyleSubButton(SidebarSubButton button)
        {
            button.Width = _sidebarPanel.Width;
            button.Height = 50;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.FromArgb(41, 41, 66);
            button.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            button.TextAlign = ContentAlignment.MiddleLeft;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.IconColor = Color.FromArgb(41, 41, 66);
            button.IconSize = 30;
            button.Padding = new Padding(40, 0, 45, 0);

            button.FlatAppearance.MouseOverBackColor = Color.LightGray;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 41, 66);

            button.Cursor = Cursors.Hand;
        }

        private void ToggleDropdown(SidebarButton button)
        {
            if (button.DropdownPanel == null) return;

            foreach (var btn in _buttons.Where(b => b != button && b.HasDropdown))
            {
                if (btn.DropdownPanel != null && btn.DropdownPanel.Visible)
                {
                    CollapseDropdown(btn);
                }
            }

            if (button.DropdownPanel.Visible)
            {
                CollapseDropdown(button);
            }
            else
            {
                ExpandDropdown(button);
            }
        }

        private void ExpandDropdown(SidebarButton button)
        {
            if (button.DropdownPanel == null) return;

            var buttonsBelow = _buttons
                .Where(b => b.Top > button.Top && b.Dock != DockStyle.Bottom)
                .OrderBy(b => b.Top)
                .ToList();

            foreach (var btnBelow in buttonsBelow)
            {
                btnBelow.Top += button.DropdownPanel.Height;
            }

            button.DropdownPanel.Location = new Point(0, button.Bottom);
            button.DropdownPanel.Visible = true;

            if (button.ArrowIcon != null)
                button.ArrowIcon.IconChar = IconChar.ChevronDown;
        }

        private void CollapseDropdown(SidebarButton button)
        {
            if (button.DropdownPanel == null || !button.DropdownPanel.Visible) return;

            int panelHeight = button.DropdownPanel.Height;
            button.DropdownPanel.Visible = false;

            if (button.ArrowIcon != null)
                button.ArrowIcon.IconChar = IconChar.ChevronRight;

            var buttonsBelow = _buttons
                .Where(b => b.Top > button.Top && b.Dock != DockStyle.Bottom)
                .OrderBy(b => b.Top)
                .ToList();

            foreach (var btnBelow in buttonsBelow)
            {
                btnBelow.Top -= panelHeight;
            }
        }

        private void SetActiveButton(SidebarButton button)
        {
            // ✅ FIXED: Close all OTHER dropdowns (not the clicked button's dropdown)
            foreach (var btn in _buttons.Where(b => b != button && b.HasDropdown))
            {
                if (btn.DropdownPanel != null && btn.DropdownPanel.Visible)
                {
                    CollapseDropdown(btn);
                }
            }

            // ✅ FIXED: Reset previous button text and colors
            if (_activeButton != null && _activeButton != button)
            {
                // Reset to original text
                _activeButton.Text = _activeButton.OriginalText;
                _activeButton.ActiveSubItem = null;

                // Reset colors
                _activeButton.BackColor = Color.Transparent;
                _activeButton.ForeColor = Color.FromArgb(41, 41, 66);
                _activeButton.IconColor = Color.FromArgb(41, 41, 66);

                // Reset arrow color if it's a dropdown button
                if (_activeButton.ArrowIcon != null)
                {
                    _activeButton.ArrowIcon.IconColor = Color.FromArgb(41, 41, 66);
                }
            }

            // Set new active button
            _activeButton = button;
            _activeButton.BackColor = Color.FromArgb(41, 41, 66);
            _activeButton.ForeColor = Color.White;
            _activeButton.IconColor = Color.White;

            // Change arrow color to white if it's a dropdown button
            if (_activeButton.ArrowIcon != null)
            {
                _activeButton.ArrowIcon.IconColor = Color.White;
            }
        }

        private void UpdateButtonText(SidebarButton button)
        {
            if (!string.IsNullOrEmpty(button.ActiveSubItem))
            {
                button.Text = $"{button.OriginalText} - {button.ActiveSubItem}";
            }
            else
            {
                button.Text = button.OriginalText;
            }
        }

        public SidebarButton GetActiveButton() => _activeButton;

        public void SetDefaultActive(int buttonIndex)
        {
            if (buttonIndex >= 0 && buttonIndex < _buttons.Count)
            {
                SetActiveButton(_buttons[buttonIndex]);
            }
        }
    }

    public class SidebarButton : IconButton
    {
        public bool HasDropdown { get; }
        public Panel DropdownPanel { get; set; }
        public string OriginalText { get; }
        public IconChar OriginalIcon { get; }
        public string ActiveSubItem { get; set; }
        public IconPictureBox ArrowIcon { get; set; }

        public SidebarButton(string text, IconChar icon, bool hasDropdown)
        {
            Text = text;
            IconChar = icon;
            HasDropdown = hasDropdown;
            OriginalText = text;
            OriginalIcon = icon;

            if (hasDropdown)
            {
                ArrowIcon = new IconPictureBox
                {
                    IconChar = IconChar.ChevronRight,
                    IconColor = Color.FromArgb(41, 41, 66),
                    Size = new Size(16, 16),
                    BackColor = Color.Transparent
                };

                this.Resize += (s, e) => PositionArrow();

                Controls.Add(ArrowIcon);
                PositionArrow();
            }
        }

        private void PositionArrow()
        {
            if (ArrowIcon != null)
            {
                ArrowIcon.Location = new Point(Width - 25, (Height - ArrowIcon.Height) / 2);
            }
        }
    }

    public class SidebarSubButton : IconButton
    {
        public SidebarSubButton(string text, IconChar icon)
        {
            Text = text;
            IconChar = icon;
        }
    }

    public class DropdownItem
    {
        public string Text { get; set; }
        public IconChar Icon { get; set; }
        public EventHandler ClickHandler { get; set; }

        public DropdownItem(string text, IconChar icon, EventHandler clickHandler = null)
        {
            Text = text;
            Icon = icon;
            ClickHandler = clickHandler;
        }
    }
}