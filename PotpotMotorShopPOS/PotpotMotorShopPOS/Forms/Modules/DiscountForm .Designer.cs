namespace PotpotMotorShopPOS.Forms.Modules
{
    partial class DiscountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblValueHeader = new System.Windows.Forms.Label();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.btnApply = new Guna.UI2.WinForms.Guna2Button();
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.pnlHead = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSubtotal = new Guna.UI2.WinForms.Guna2Panel();
            this.txtDiscountValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.rbPercentage = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbFixedAmount = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblTypeHeader = new System.Windows.Forms.Label();
            this.pnlPreview = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPreviewLabel = new System.Windows.Forms.Label();
            this.lblPreviewValue = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlHead.SuspendLayout();
            this.pnlSubtotal.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_HOR_POSITIVE;
            this.guna2BorderlessForm1.BorderRadius = 10;
            this.guna2BorderlessForm1.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Animated = true;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.HoverState.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = global::PotpotMotorShopPOS.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(559, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(47, 43);
            this.btnClose.TabIndex = 132;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(16, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(241, 31);
            this.label6.TabIndex = 133;
            this.label6.Text = "DISCOUNT MODULE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.BorderColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.label6);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.White;
            this.pnlHeader.ForeColor = System.Drawing.Color.White;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.ShadowDecoration.BorderRadius = 30;
            this.pnlHeader.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlHeader.ShadowDecoration.Enabled = true;
            this.pnlHeader.ShadowDecoration.Parent = this.pnlHeader;
            this.pnlHeader.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.pnlHeader.Size = new System.Drawing.Size(618, 51);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblValueHeader
            // 
            this.lblValueHeader.AutoSize = true;
            this.lblValueHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblValueHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblValueHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValueHeader.Location = new System.Drawing.Point(47, 165);
            this.lblValueHeader.Name = "lblValueHeader";
            this.lblValueHeader.Size = new System.Drawing.Size(278, 31);
            this.lblValueHeader.TabIndex = 106;
            this.lblValueHeader.Text = "ENTER DISCOUNT VALUE";
            this.lblValueHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotalValue.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblSubtotalValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSubtotalValue.Location = new System.Drawing.Point(348, 17);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.Size = new System.Drawing.Size(142, 53);
            this.lblSubtotalValue.TabIndex = 104;
            this.lblSubtotalValue.Text = "₱0.00";
            this.lblSubtotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnApply
            // 
            this.btnApply.Animated = true;
            this.btnApply.BackColor = System.Drawing.Color.Transparent;
            this.btnApply.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnApply.BorderRadius = 10;
            this.btnApply.BorderThickness = 1;
            this.btnApply.CheckedState.Parent = this.btnApply;
            this.btnApply.CustomImages.Parent = this.btnApply;
            this.btnApply.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnApply.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnApply.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.btnApply.HoverState.Parent = this.btnApply;
            this.btnApply.Location = new System.Drawing.Point(172, 391);
            this.btnApply.Name = "btnApply";
            this.btnApply.ShadowDecoration.BorderRadius = 15;
            this.btnApply.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnApply.ShadowDecoration.Enabled = true;
            this.btnApply.ShadowDecoration.Parent = this.btnApply;
            this.btnApply.Size = new System.Drawing.Size(223, 52);
            this.btnApply.TabIndex = 102;
            this.btnApply.Text = "APPLY DISCOUNT";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblSubtotalLabel
            // 
            this.lblSubtotalLabel.AutoSize = true;
            this.lblSubtotalLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotalLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblSubtotalLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSubtotalLabel.Location = new System.Drawing.Point(47, 30);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";
            this.lblSubtotalLabel.Size = new System.Drawing.Size(186, 31);
            this.lblSubtotalLabel.TabIndex = 96;
            this.lblSubtotalLabel.Text = "Current Subtotal";
            this.lblSubtotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.pnlSubtotal);
            this.pnlHead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHead.Location = new System.Drawing.Point(0, 51);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.ShadowDecoration.Parent = this.pnlHead;
            this.pnlHead.Size = new System.Drawing.Size(618, 551);
            this.pnlHead.TabIndex = 1;
            // 
            // pnlSubtotal
            // 
            this.pnlSubtotal.BackColor = System.Drawing.Color.Transparent;
            this.pnlSubtotal.BorderRadius = 10;
            this.pnlSubtotal.Controls.Add(this.pnlPreview);
            this.pnlSubtotal.Controls.Add(this.btnApply);
            this.pnlSubtotal.Controls.Add(this.txtDiscountValue);
            this.pnlSubtotal.Controls.Add(this.rbPercentage);
            this.pnlSubtotal.Controls.Add(this.rbFixedAmount);
            this.pnlSubtotal.Controls.Add(this.lblTypeHeader);
            this.pnlSubtotal.Controls.Add(this.lblValueHeader);
            this.pnlSubtotal.Controls.Add(this.lblSubtotalValue);
            this.pnlSubtotal.Controls.Add(this.lblSubtotalLabel);
            this.pnlSubtotal.FillColor = System.Drawing.Color.White;
            this.pnlSubtotal.Location = new System.Drawing.Point(30, 22);
            this.pnlSubtotal.Name = "pnlSubtotal";
            this.pnlSubtotal.ShadowDecoration.BorderRadius = 15;
            this.pnlSubtotal.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlSubtotal.ShadowDecoration.Enabled = true;
            this.pnlSubtotal.ShadowDecoration.Parent = this.pnlSubtotal;
            this.pnlSubtotal.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.pnlSubtotal.Size = new System.Drawing.Size(558, 488);
            this.pnlSubtotal.TabIndex = 107;
            // 
            // txtDiscountValue
            // 
            this.txtDiscountValue.Animated = true;
            this.txtDiscountValue.AutoRoundedCorners = true;
            this.txtDiscountValue.BackColor = System.Drawing.Color.Transparent;
            this.txtDiscountValue.BorderColor = System.Drawing.Color.Black;
            this.txtDiscountValue.BorderRadius = 20;
            this.txtDiscountValue.BorderThickness = 2;
            this.txtDiscountValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiscountValue.DefaultText = "";
            this.txtDiscountValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiscountValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiscountValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscountValue.DisabledState.Parent = this.txtDiscountValue;
            this.txtDiscountValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscountValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscountValue.FocusedState.Parent = this.txtDiscountValue;
            this.txtDiscountValue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiscountValue.ForeColor = System.Drawing.Color.Black;
            this.txtDiscountValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscountValue.HoverState.Parent = this.txtDiscountValue;
            this.txtDiscountValue.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtDiscountValue.Location = new System.Drawing.Point(53, 200);
            this.txtDiscountValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiscountValue.MaxLength = 50;
            this.txtDiscountValue.Name = "txtDiscountValue";
            this.txtDiscountValue.PasswordChar = '\0';
            this.txtDiscountValue.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtDiscountValue.PlaceholderText = "Enter discount%";
            this.txtDiscountValue.SelectedText = "";
            this.txtDiscountValue.ShadowDecoration.BorderRadius = 30;
            this.txtDiscountValue.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtDiscountValue.ShadowDecoration.Enabled = true;
            this.txtDiscountValue.ShadowDecoration.Parent = this.txtDiscountValue;
            this.txtDiscountValue.Size = new System.Drawing.Size(465, 51);
            this.txtDiscountValue.TabIndex = 110;
            this.txtDiscountValue.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // rbPercentage
            // 
            this.rbPercentage.AutoSize = true;
            this.rbPercentage.Checked = true;
            this.rbPercentage.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rbPercentage.CheckedState.BorderThickness = 0;
            this.rbPercentage.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rbPercentage.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbPercentage.CheckedState.InnerOffset = -4;
            this.rbPercentage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.rbPercentage.Location = new System.Drawing.Point(332, 113);
            this.rbPercentage.Name = "rbPercentage";
            this.rbPercentage.Size = new System.Drawing.Size(175, 32);
            this.rbPercentage.TabIndex = 109;
            this.rbPercentage.TabStop = true;
            this.rbPercentage.Text = "Percentage (%)";
            this.rbPercentage.UncheckedState.BorderColor = System.Drawing.Color.White;
            this.rbPercentage.UncheckedState.BorderThickness = 2;
            this.rbPercentage.UncheckedState.FillColor = System.Drawing.Color.Silver;
            this.rbPercentage.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbFixedAmount
            // 
            this.rbFixedAmount.AutoSize = true;
            this.rbFixedAmount.Checked = true;
            this.rbFixedAmount.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rbFixedAmount.CheckedState.BorderThickness = 0;
            this.rbFixedAmount.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rbFixedAmount.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbFixedAmount.CheckedState.InnerOffset = -4;
            this.rbFixedAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.rbFixedAmount.Location = new System.Drawing.Point(53, 113);
            this.rbFixedAmount.Name = "rbFixedAmount";
            this.rbFixedAmount.Size = new System.Drawing.Size(198, 32);
            this.rbFixedAmount.TabIndex = 108;
            this.rbFixedAmount.TabStop = true;
            this.rbFixedAmount.Text = "Fixed Amount (₱)";
            this.rbFixedAmount.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbFixedAmount.UncheckedState.BorderThickness = 2;
            this.rbFixedAmount.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbFixedAmount.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // lblTypeHeader
            // 
            this.lblTypeHeader.AutoSize = true;
            this.lblTypeHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblTypeHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTypeHeader.Location = new System.Drawing.Point(47, 79);
            this.lblTypeHeader.Name = "lblTypeHeader";
            this.lblTypeHeader.Size = new System.Drawing.Size(267, 31);
            this.lblTypeHeader.TabIndex = 107;
            this.lblTypeHeader.Text = "SELECT DISCOUNT TYPE";
            this.lblTypeHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlPreview
            // 
            this.pnlPreview.Controls.Add(this.lblPreviewValue);
            this.pnlPreview.Controls.Add(this.lblPreviewLabel);
            this.pnlPreview.Location = new System.Drawing.Point(53, 274);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.ShadowDecoration.Parent = this.pnlPreview;
            this.pnlPreview.Size = new System.Drawing.Size(465, 78);
            this.pnlPreview.TabIndex = 111;
            // 
            // lblPreviewLabel
            // 
            this.lblPreviewLabel.AutoSize = true;
            this.lblPreviewLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviewLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviewLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblPreviewLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPreviewLabel.Location = new System.Drawing.Point(12, 22);
            this.lblPreviewLabel.Name = "lblPreviewLabel";
            this.lblPreviewLabel.Size = new System.Drawing.Size(201, 31);
            this.lblPreviewLabel.TabIndex = 112;
            this.lblPreviewLabel.Text = "Discount Amount:";
            this.lblPreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPreviewValue
            // 
            this.lblPreviewValue.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviewValue.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviewValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblPreviewValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPreviewValue.Location = new System.Drawing.Point(253, 20);
            this.lblPreviewValue.Name = "lblPreviewValue";
            this.lblPreviewValue.Size = new System.Drawing.Size(201, 31);
            this.lblPreviewValue.TabIndex = 113;
            this.lblPreviewValue.Text = "₱0.00";
            this.lblPreviewValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(618, 602);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiscountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiscountForm";
            this.Load += new System.EventHandler(this.DiscountForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlHead.ResumeLayout(false);
            this.pnlSubtotal.ResumeLayout(false);
            this.pnlSubtotal.PerformLayout();
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblValueHeader;
        private System.Windows.Forms.Label lblSubtotalValue;
        private Guna.UI2.WinForms.Guna2Button btnApply;
        private System.Windows.Forms.Label lblSubtotalLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlHead;
        private Guna.UI2.WinForms.Guna2Panel pnlSubtotal;
        private Guna.UI2.WinForms.Guna2RadioButton rbPercentage;
        private Guna.UI2.WinForms.Guna2RadioButton rbFixedAmount;
        private System.Windows.Forms.Label lblTypeHeader;
        private Guna.UI2.WinForms.Guna2TextBox txtDiscountValue;
        private Guna.UI2.WinForms.Guna2Panel pnlPreview;
        private System.Windows.Forms.Label lblPreviewValue;
        private System.Windows.Forms.Label lblPreviewLabel;
    }
}