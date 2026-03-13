using System.Drawing;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Helpers
{
    public static class DataGridHelper
    {
        /// <summary>
        /// Apply a consistent style to any DataGridView or Guna2DataGridView.
        /// </summary>
        /// <param name="grid">The DataGridView to style</param>
        /// <param name="addSelectButton">Whether to add a select button column</param>
        public static void ApplyStyle(DataGridView grid, bool addSelectButton = false)
        {
            // General look
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.BackgroundColor = Color.White;
            grid.GridColor = Color.FromArgb(41, 41, 66);

            // Header
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 41, 66);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersHeight = 70;

            // Rows
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 41, 66);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            grid.RowTemplate.Height = 90;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Optional: add select button column
            if (addSelectButton && !grid.Columns.Contains("btnSelect"))
            {
                DataGridViewImageColumn btnSelect = new DataGridViewImageColumn
                {
                    Name = "btnSelect",
                    HeaderText = "",
                    Image = Properties.Resources.circle_right50, // arrow icon in Resources
                    Width = 40
                };
                grid.Columns.Add(btnSelect);
            }
        }
    }
}