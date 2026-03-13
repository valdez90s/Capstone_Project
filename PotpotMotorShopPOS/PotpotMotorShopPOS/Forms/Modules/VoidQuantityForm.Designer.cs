namespace PotpotMotorShopPOS.Forms.Modules
{
    partial class VoidQuantityForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnVoidAll = new Guna.UI2.WinForms.Guna2Button();
            this.lblItemInfo = new System.Windows.Forms.Label();
            this.numQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnVoidPartial = new Guna.UI2.WinForms.Guna2Button();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lblPreview = new System.Windows.Forms.Label();
            this.pnlSubtotal = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.pnlSubtotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_NEGATIVE;
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(12, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 31);
            this.lblTitle.TabIndex = 134;
            this.lblTitle.Text = "VOID OPTION";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVoidAll
            // 
            this.btnVoidAll.Animated = true;
            this.btnVoidAll.BackColor = System.Drawing.Color.Transparent;
            this.btnVoidAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnVoidAll.BorderRadius = 10;
            this.btnVoidAll.BorderThickness = 1;
            this.btnVoidAll.CheckedState.Parent = this.btnVoidAll;
            this.btnVoidAll.CustomImages.Parent = this.btnVoidAll;
            this.btnVoidAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnVoidAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVoidAll.ForeColor = System.Drawing.Color.White;
            this.btnVoidAll.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnVoidAll.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnVoidAll.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoidAll.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.btnVoidAll.HoverState.Parent = this.btnVoidAll;
            this.btnVoidAll.Location = new System.Drawing.Point(57, 344);
            this.btnVoidAll.Name = "btnVoidAll";
            this.btnVoidAll.ShadowDecoration.BorderRadius = 15;
            this.btnVoidAll.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnVoidAll.ShadowDecoration.Enabled = true;
            this.btnVoidAll.ShadowDecoration.Parent = this.btnVoidAll;
            this.btnVoidAll.Size = new System.Drawing.Size(163, 52);
            this.btnVoidAll.TabIndex = 102;
            this.btnVoidAll.Text = "Void All";
            this.btnVoidAll.Click += new System.EventHandler(this.btnVoidAll_Click);
            // 
            // lblItemInfo
            // 
            this.lblItemInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblItemInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblItemInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItemInfo.Location = new System.Drawing.Point(66, 19);
            this.lblItemInfo.Name = "lblItemInfo";
            this.lblItemInfo.Size = new System.Drawing.Size(348, 127);
            this.lblItemInfo.TabIndex = 104;
            this.lblItemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numQuantity
            // 
            this.numQuantity.BackColor = System.Drawing.Color.Transparent;
            this.numQuantity.BorderColor = System.Drawing.Color.Black;
            this.numQuantity.BorderRadius = 10;
            this.numQuantity.BorderThickness = 2;
            this.numQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numQuantity.DisabledState.Parent = this.numQuantity;
            this.numQuantity.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.numQuantity.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.numQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numQuantity.FocusedState.Parent = this.numQuantity;
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantity.ForeColor = System.Drawing.Color.Black;
            this.numQuantity.Location = new System.Drawing.Point(63, 189);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.ShadowDecoration.BorderRadius = 15;
            this.numQuantity.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.numQuantity.ShadowDecoration.Parent = this.numQuantity;
            this.numQuantity.Size = new System.Drawing.Size(348, 51);
            this.numQuantity.TabIndex = 135;
            this.numQuantity.UpDownButtonFillColor = System.Drawing.Color.White;
            // 
            // btnVoidPartial
            // 
            this.btnVoidPartial.Animated = true;
            this.btnVoidPartial.BackColor = System.Drawing.Color.Transparent;
            this.btnVoidPartial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnVoidPartial.BorderRadius = 10;
            this.btnVoidPartial.BorderThickness = 1;
            this.btnVoidPartial.CheckedState.Parent = this.btnVoidPartial;
            this.btnVoidPartial.CustomImages.Parent = this.btnVoidPartial;
            this.btnVoidPartial.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnVoidPartial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVoidPartial.ForeColor = System.Drawing.Color.White;
            this.btnVoidPartial.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnVoidPartial.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnVoidPartial.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoidPartial.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.btnVoidPartial.HoverState.Parent = this.btnVoidPartial;
            this.btnVoidPartial.Location = new System.Drawing.Point(262, 344);
            this.btnVoidPartial.Name = "btnVoidPartial";
            this.btnVoidPartial.ShadowDecoration.BorderRadius = 15;
            this.btnVoidPartial.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnVoidPartial.ShadowDecoration.Enabled = true;
            this.btnVoidPartial.ShadowDecoration.Parent = this.btnVoidPartial;
            this.btnVoidPartial.Size = new System.Drawing.Size(163, 52);
            this.btnVoidPartial.TabIndex = 112;
            this.btnVoidPartial.Text = "Void Selected ";
            this.btnVoidPartial.Click += new System.EventHandler(this.btnVoidPartial_Click);
            // 
            // lblPrompt
            // 
            this.lblPrompt.BackColor = System.Drawing.Color.Transparent;
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblPrompt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrompt.Location = new System.Drawing.Point(63, 154);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(348, 28);
            this.lblPrompt.TabIndex = 137;
            this.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPreview
            // 
            this.lblPreview.BackColor = System.Drawing.Color.Transparent;
            this.lblPreview.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPreview.Location = new System.Drawing.Point(13, 252);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(451, 43);
            this.lblPreview.TabIndex = 138;
            this.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSubtotal
            // 
            this.pnlSubtotal.BackColor = System.Drawing.Color.Transparent;
            this.pnlSubtotal.BorderRadius = 10;
            this.pnlSubtotal.Controls.Add(this.lblPreview);
            this.pnlSubtotal.Controls.Add(this.btnVoidPartial);
            this.pnlSubtotal.Controls.Add(this.lblItemInfo);
            this.pnlSubtotal.Controls.Add(this.btnVoidAll);
            this.pnlSubtotal.Controls.Add(this.lblPrompt);
            this.pnlSubtotal.Controls.Add(this.numQuantity);
            this.pnlSubtotal.FillColor = System.Drawing.Color.White;
            this.pnlSubtotal.Location = new System.Drawing.Point(18, 71);
            this.pnlSubtotal.Name = "pnlSubtotal";
            this.pnlSubtotal.ShadowDecoration.BorderRadius = 15;
            this.pnlSubtotal.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlSubtotal.ShadowDecoration.Enabled = true;
            this.pnlSubtotal.ShadowDecoration.Parent = this.pnlSubtotal;
            this.pnlSubtotal.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.pnlSubtotal.Size = new System.Drawing.Size(481, 457);
            this.pnlSubtotal.TabIndex = 107;
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.HoverState.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Image = global::PotpotMotorShopPOS.Properties.Resources.close;
            this.btnCancel.Location = new System.Drawing.Point(452, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(47, 43);
            this.btnCancel.TabIndex = 137;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // VoidQuantityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 555);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlSubtotal);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VoidQuantityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoidQuantityForm";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.pnlSubtotal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnVoidAll;
        private System.Windows.Forms.Label lblItemInfo;
        private Guna.UI2.WinForms.Guna2Button btnVoidPartial;
        private Guna.UI2.WinForms.Guna2NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblPrompt;
        private Guna.UI2.WinForms.Guna2Panel pnlSubtotal;
        private System.Windows.Forms.Label lblPreview;
        private Guna.UI2.WinForms.Guna2CircleButton btnCancel;
    }
}