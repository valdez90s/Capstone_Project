using System;
using System.Drawing;
using PotpotMotorShopPOS.Helpers;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Forms.Modules
{
    public partial class DiscountForm : Form
    {
        public decimal DiscountAmount { get; private set; }
        private decimal _currentSubtotal;

        public DiscountForm(decimal currentSubtotal)
        {
            InitializeComponent();
            _currentSubtotal = currentSubtotal;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
           
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtDiscountValue.Text, out decimal value) || value <= 0)
            {
                MessageBox.Show("Please enter a valid discount value.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscountValue.Focus();
                return;
            }

            decimal discountAmount;
            if (rbFixedAmount.Checked)
            {
                discountAmount = value;
            }
            else
            {
                if (value > 100)
                {
                    MessageBox.Show("Percentage cannot exceed 100%.", "Invalid Percentage",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscountValue.Focus();
                    return;
                }
                discountAmount = _currentSubtotal * (value / 100);
            }

            if (discountAmount > _currentSubtotal)
            {
                MessageBox.Show("Discount cannot exceed subtotal amount.", "Invalid Discount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscountValue.Focus();
                return;
            }

            DiscountAmount = discountAmount;
            DialogResult = DialogResult.OK;
        }

        private void DiscountForm_Load(object sender, EventArgs e)
        {
            // Display current subtotal
            lblSubtotalValue.Text = $"₱{_currentSubtotal:N2}";

            // Set default values
            rbFixedAmount.Checked = true;
            txtDiscountValue.Clear();
            UpdatePreview();

            // Wire up events
            txtDiscountValue.TextChanged += (s, ev) => UpdatePreview();
            rbFixedAmount.CheckedChanged += (s, ev) => UpdatePreview();
            rbPercentage.CheckedChanged += (s, ev) => UpdatePreview();
        }

        private void UpdatePreview()
        {
            if (decimal.TryParse(txtDiscountValue.Text, out decimal value) && value > 0)
            {
                decimal discountAmount = rbFixedAmount.Checked
                    ? value
                    : (_currentSubtotal * value / 100);

                if (discountAmount > _currentSubtotal)
                {
                    pnlPreview.BackColor = Color.FromArgb(250, 219, 216);
                    lblPreviewValue.ForeColor = Color.FromArgb(231, 76, 60);
                    lblPreviewValue.Text = "⚠️ Exceeds subtotal!";
                }
                else
                {
                    pnlPreview.BackColor = Color.FromArgb(232, 248, 245);
                    lblPreviewValue.ForeColor = Color.FromArgb(46, 204, 113);
                    lblPreviewValue.Text = $"₱{discountAmount:N2}";
                }
            }
            else
            {
                pnlPreview.BackColor = Color.FromArgb(232, 248, 245);
                lblPreviewValue.ForeColor = Color.FromArgb(46, 204, 113);
                lblPreviewValue.Text = "₱0.00";
            }
        }

        private void txtDiscountValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && txtDiscountValue.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtDiscountValue_KeyDown(object sender, KeyEventArgs e)
        {
            // Apply discount on Enter key
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnApply.PerformClick();
            }

            // Cancel on Escape key
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                btnClose.PerformClick();
            }
        }
    }
}