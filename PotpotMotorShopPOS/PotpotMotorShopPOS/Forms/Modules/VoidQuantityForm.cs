using System;
using System.Drawing;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Forms.Modules
{
    public partial class VoidQuantityForm : Form
    {
        public int QuantityToVoid { get; private set; }
        public bool IsFullVoid { get; private set; }

        private int _maxQuantity;
        private string _itemName;
        private decimal _unitPrice;
        private decimal _lineTotal;

        public VoidQuantityForm(string itemName, int currentQuantity, decimal unitPrice, decimal lineTotal)
        {
            InitializeComponent();

            _itemName = itemName;
            _maxQuantity = currentQuantity;
            _unitPrice = unitPrice;
            _lineTotal = lineTotal;

            // Setup form
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Set labels
            lblItemInfo.Text = $"Item: {itemName}\n" +
                               $"Current Quantity: {currentQuantity}\n" +
                               $"Unit Price: ₱{unitPrice:N2}\n" +
                               $"Line Total: ₱{lineTotal:N2}";

            lblPrompt.Text = $"Enter quantity to void (1 to {currentQuantity}):";

            // Setup numeric control
            numQuantity.Minimum = 1;
            numQuantity.Maximum = currentQuantity;
            numQuantity.Value = 1;

            // Update void all button text
            btnVoidAll.Text = $"Void All ({currentQuantity})";

            // Wire up events
            numQuantity.ValueChanged += NumQuantity_ValueChanged;
            UpdatePreview();
        }

        private void NumQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            int qty = (int)numQuantity.Value;
            decimal amount = qty * _unitPrice;

            lblPreview.Text = $"Will void: {qty} × ₱{_unitPrice:N2} = ₱{amount:N2}";
            lblPreview.ForeColor = Color.FromArgb(192, 0, 0);
        }

        private void btnVoidPartial_Click(object sender, EventArgs e)
        {
            QuantityToVoid = (int)numQuantity.Value;
            IsFullVoid = (QuantityToVoid == _maxQuantity);

            var confirmMsg = IsFullVoid
                ? $"Void all {QuantityToVoid} units of {_itemName}?\n\nAmount: ₱{(_unitPrice * QuantityToVoid):N2}"
                : $"Void {QuantityToVoid} of {_maxQuantity} units of {_itemName}?\n\nAmount: ₱{(_unitPrice * QuantityToVoid):N2}\nRemaining: {_maxQuantity - QuantityToVoid} units";

            var result = MessageBox.Show(
                confirmMsg,
                "Confirm Void",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnVoidAll_Click(object sender, EventArgs e)
        {
            QuantityToVoid = _maxQuantity;
            IsFullVoid = true;

            var result = MessageBox.Show(
                $"Void all {_maxQuantity} units of {_itemName}?\n\n" +
                $"Amount: ₱{_lineTotal:N2}\n\n" +
                $"This will remove the entire item from cart.",
                "Confirm Full Void",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}