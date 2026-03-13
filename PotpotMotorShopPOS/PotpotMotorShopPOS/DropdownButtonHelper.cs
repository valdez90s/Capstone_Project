using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS_INVENTORY_SYSTEM.Utilities
{
    public static class DropdownHelper
    {
        private static Dictionary<Panel, Timer> timers = new Dictionary<Panel, Timer>();
        private static Dictionary<Panel, int> maxHeights = new Dictionary<Panel, int>();

        public static void Setup(Panel dropdownPanel, int expandedHeight)
        {
            dropdownPanel.Visible = false; 
            dropdownPanel.Height = 0;

            if (!maxHeights.ContainsKey(dropdownPanel))
                maxHeights[dropdownPanel] = expandedHeight;

            if (!timers.ContainsKey(dropdownPanel))
            {
                Timer t = new Timer();
                t.Interval = 15;
                t.Tick += (s, e) => Animate(dropdownPanel);
                timers[dropdownPanel] = t;
            }
        }

        public static void Toggle(Panel dropdownPanel)
        {
            if (!timers.ContainsKey(dropdownPanel)) return;

            dropdownPanel.Visible = true;
            timers[dropdownPanel].Tag = dropdownPanel.Height == 0 ? "expand" : "collapse";
            timers[dropdownPanel].Start();
        }

        private static void Animate(Panel dropdownPanel)
        {
            Timer t = timers[dropdownPanel];
            int maxHeight = maxHeights[dropdownPanel];

            if ((string)t.Tag == "expand")
            {
                dropdownPanel.Height += 15;
                if (dropdownPanel.Height >= maxHeight)
                {
                    dropdownPanel.Height = maxHeight;
                    t.Stop();
                }
            }
            else
            {
                dropdownPanel.Height -= 15;
                if (dropdownPanel.Height <= 0)
                {
                    dropdownPanel.Height = 0;
                    dropdownPanel.Visible = false;
                    t.Stop();
                }
            }
        }
    }
}
