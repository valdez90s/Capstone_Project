namespace PotpotMotorShopPOS.Forms.Modules
{
    partial class StockAdjustmentForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.closed = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCurrentStock = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtReason = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProductID = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReferenceNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbAction = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numQuantityAdjusted = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtProductName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAdjustmentType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityAdjusted)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_POSITIVE;
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(14, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(312, 38);
            this.label6.TabIndex = 105;
            this.label6.Text = "STOCK ADJUSTMENT";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // closed
            // 
            this.closed.Animated = true;
            this.closed.AutoRoundedCorners = true;
            this.closed.BackColor = System.Drawing.Color.Transparent;
            this.closed.BorderRadius = 19;
            this.closed.CheckedState.Parent = this.closed;
            this.closed.CustomImages.Parent = this.closed;
            this.closed.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.closed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closed.ForeColor = System.Drawing.Color.White;
            this.closed.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closed.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closed.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closed.HoverState.ForeColor = System.Drawing.Color.White;
            this.closed.HoverState.Parent = this.closed;
            this.closed.Image = global::PotpotMotorShopPOS.Properties.Resources.close;
            this.closed.Location = new System.Drawing.Point(667, 9);
            this.closed.Name = "closed";
            this.closed.ShadowDecoration.Parent = this.closed;
            this.closed.Size = new System.Drawing.Size(41, 41);
            this.closed.TabIndex = 157;
            this.closed.Click += new System.EventHandler(this.closed_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.label6);
            this.guna2Panel1.Controls.Add(this.closed);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(729, 61);
            this.guna2Panel1.TabIndex = 158;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(46, 547);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 31);
            this.label9.TabIndex = 177;
            this.label9.Text = "Stock On Hand";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCurrentStock
            // 
            this.txtCurrentStock.Animated = true;
            this.txtCurrentStock.BackColor = System.Drawing.Color.Transparent;
            this.txtCurrentStock.BorderColor = System.Drawing.Color.Black;
            this.txtCurrentStock.BorderRadius = 10;
            this.txtCurrentStock.BorderThickness = 2;
            this.txtCurrentStock.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurrentStock.DefaultText = "";
            this.txtCurrentStock.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCurrentStock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCurrentStock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentStock.DisabledState.Parent = this.txtCurrentStock;
            this.txtCurrentStock.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentStock.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCurrentStock.FocusedState.Parent = this.txtCurrentStock;
            this.txtCurrentStock.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCurrentStock.ForeColor = System.Drawing.Color.Black;
            this.txtCurrentStock.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCurrentStock.HoverState.Parent = this.txtCurrentStock;
            this.txtCurrentStock.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtCurrentStock.Location = new System.Drawing.Point(52, 582);
            this.txtCurrentStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCurrentStock.MaxLength = 50;
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.PasswordChar = '\0';
            this.txtCurrentStock.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtCurrentStock.PlaceholderText = "";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.SelectedText = "";
            this.txtCurrentStock.ShadowDecoration.BorderRadius = 15;
            this.txtCurrentStock.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtCurrentStock.ShadowDecoration.Enabled = true;
            this.txtCurrentStock.ShadowDecoration.Parent = this.txtCurrentStock;
            this.txtCurrentStock.Size = new System.Drawing.Size(293, 45);
            this.txtCurrentStock.TabIndex = 176;
            this.txtCurrentStock.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // txtReason
            // 
            this.txtReason.Animated = true;
            this.txtReason.AutoScroll = true;
            this.txtReason.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtReason.BackColor = System.Drawing.Color.Transparent;
            this.txtReason.BorderColor = System.Drawing.Color.Black;
            this.txtReason.BorderRadius = 10;
            this.txtReason.BorderThickness = 2;
            this.txtReason.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReason.DefaultText = "";
            this.txtReason.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtReason.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtReason.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReason.DisabledState.Parent = this.txtReason;
            this.txtReason.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReason.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReason.FocusedState.Parent = this.txtReason;
            this.txtReason.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtReason.ForeColor = System.Drawing.Color.Black;
            this.txtReason.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReason.HoverState.Parent = this.txtReason;
            this.txtReason.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtReason.Location = new System.Drawing.Point(394, 426);
            this.txtReason.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtReason.MaxLength = 100;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.PasswordChar = '\0';
            this.txtReason.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtReason.PlaceholderText = "";
            this.txtReason.SelectedText = "";
            this.txtReason.ShadowDecoration.BorderRadius = 15;
            this.txtReason.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtReason.ShadowDecoration.Enabled = true;
            this.txtReason.ShadowDecoration.Parent = this.txtReason;
            this.txtReason.Size = new System.Drawing.Size(293, 138);
            this.txtReason.TabIndex = 171;
            this.txtReason.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Animated = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 10;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnSave.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(446, 582);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.BorderRadius = 15;
            this.btnSave.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSave.ShadowDecoration.Enabled = true;
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(183, 50);
            this.btnSave.TabIndex = 175;
            this.btnSave.Text = "Save";
            this.btnSave.TextOffset = new System.Drawing.Point(7, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(46, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 31);
            this.label8.TabIndex = 174;
            this.label8.Text = "User";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProductID
            // 
            this.txtProductID.Animated = true;
            this.txtProductID.BackColor = System.Drawing.Color.Transparent;
            this.txtProductID.BorderColor = System.Drawing.Color.Black;
            this.txtProductID.BorderRadius = 10;
            this.txtProductID.BorderThickness = 2;
            this.txtProductID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductID.DefaultText = "";
            this.txtProductID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductID.DisabledState.Parent = this.txtProductID;
            this.txtProductID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductID.FocusedState.Parent = this.txtProductID;
            this.txtProductID.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtProductID.ForeColor = System.Drawing.Color.Black;
            this.txtProductID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductID.HoverState.Parent = this.txtProductID;
            this.txtProductID.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtProductID.Location = new System.Drawing.Point(50, 312);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProductID.MaxLength = 50;
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.PasswordChar = '\0';
            this.txtProductID.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtProductID.PlaceholderText = "";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.SelectedText = "";
            this.txtProductID.ShadowDecoration.BorderRadius = 15;
            this.txtProductID.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtProductID.ShadowDecoration.Enabled = true;
            this.txtProductID.ShadowDecoration.Parent = this.txtProductID;
            this.txtProductID.Size = new System.Drawing.Size(299, 45);
            this.txtProductID.TabIndex = 161;
            this.txtProductID.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // txtUser
            // 
            this.txtUser.Animated = true;
            this.txtUser.BackColor = System.Drawing.Color.Transparent;
            this.txtUser.BorderColor = System.Drawing.Color.Black;
            this.txtUser.BorderRadius = 10;
            this.txtUser.BorderThickness = 2;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.DefaultText = "";
            this.txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.DisabledState.Parent = this.txtUser;
            this.txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUser.FocusedState.Parent = this.txtUser;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUser.ForeColor = System.Drawing.Color.Black;
            this.txtUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUser.HoverState.Parent = this.txtUser;
            this.txtUser.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtUser.Location = new System.Drawing.Point(50, 214);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUser.MaxLength = 50;
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtUser.PlaceholderText = "";
            this.txtUser.ReadOnly = true;
            this.txtUser.SelectedText = "";
            this.txtUser.ShadowDecoration.BorderRadius = 15;
            this.txtUser.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtUser.ShadowDecoration.Enabled = true;
            this.txtUser.ShadowDecoration.Parent = this.txtUser;
            this.txtUser.Size = new System.Drawing.Size(299, 45);
            this.txtUser.TabIndex = 173;
            this.txtUser.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(46, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(160, 31);
            this.label13.TabIndex = 160;
            this.label13.Text = "Reference No.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(392, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 31);
            this.label7.TabIndex = 172;
            this.label7.Text = "Reason";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Animated = true;
            this.txtReferenceNo.BackColor = System.Drawing.Color.Transparent;
            this.txtReferenceNo.BorderColor = System.Drawing.Color.Black;
            this.txtReferenceNo.BorderRadius = 10;
            this.txtReferenceNo.BorderThickness = 2;
            this.txtReferenceNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReferenceNo.DefaultText = "";
            this.txtReferenceNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtReferenceNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtReferenceNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReferenceNo.DisabledState.Parent = this.txtReferenceNo;
            this.txtReferenceNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReferenceNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReferenceNo.FocusedState.Parent = this.txtReferenceNo;
            this.txtReferenceNo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtReferenceNo.ForeColor = System.Drawing.Color.Black;
            this.txtReferenceNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReferenceNo.HoverState.Parent = this.txtReferenceNo;
            this.txtReferenceNo.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtReferenceNo.Location = new System.Drawing.Point(50, 118);
            this.txtReferenceNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtReferenceNo.MaxLength = 50;
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.PasswordChar = '\0';
            this.txtReferenceNo.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtReferenceNo.PlaceholderText = "Click genarate reference no";
            this.txtReferenceNo.ReadOnly = true;
            this.txtReferenceNo.SelectedText = "";
            this.txtReferenceNo.ShadowDecoration.BorderRadius = 15;
            this.txtReferenceNo.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtReferenceNo.ShadowDecoration.Enabled = true;
            this.txtReferenceNo.ShadowDecoration.Parent = this.txtReferenceNo;
            this.txtReferenceNo.Size = new System.Drawing.Size(299, 45);
            this.txtReferenceNo.TabIndex = 159;
            this.txtReferenceNo.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // cmbAction
            // 
            this.cmbAction.Animated = true;
            this.cmbAction.BackColor = System.Drawing.Color.Transparent;
            this.cmbAction.BorderColor = System.Drawing.Color.Black;
            this.cmbAction.BorderRadius = 10;
            this.cmbAction.BorderThickness = 2;
            this.cmbAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAction.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAction.FocusedState.Parent = this.cmbAction;
            this.cmbAction.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbAction.ForeColor = System.Drawing.Color.Black;
            this.cmbAction.HoverState.Parent = this.cmbAction;
            this.cmbAction.ItemHeight = 45;
            this.cmbAction.Items.AddRange(new object[] {
            "Add to Inventory",
            "Removed from Inventory"});
            this.cmbAction.ItemsAppearance.Parent = this.cmbAction;
            this.cmbAction.Location = new System.Drawing.Point(394, 214);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.ShadowDecoration.BorderRadius = 15;
            this.cmbAction.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbAction.ShadowDecoration.Enabled = true;
            this.cmbAction.ShadowDecoration.Parent = this.cmbAction;
            this.cmbAction.Size = new System.Drawing.Size(293, 51);
            this.cmbAction.StartIndex = 0;
            this.cmbAction.TabIndex = 162;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(392, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 31);
            this.label1.TabIndex = 170;
            this.label1.Text = "Action";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Animated = true;
            this.txtBarcode.BackColor = System.Drawing.Color.Transparent;
            this.txtBarcode.BorderColor = System.Drawing.Color.Black;
            this.txtBarcode.BorderRadius = 10;
            this.txtBarcode.BorderThickness = 2;
            this.txtBarcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBarcode.DefaultText = "";
            this.txtBarcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBarcode.DisabledState.Parent = this.txtBarcode;
            this.txtBarcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBarcode.FocusedState.Parent = this.txtBarcode;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBarcode.ForeColor = System.Drawing.Color.Black;
            this.txtBarcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBarcode.HoverState.Parent = this.txtBarcode;
            this.txtBarcode.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtBarcode.Location = new System.Drawing.Point(50, 400);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBarcode.MaxLength = 50;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.PasswordChar = '\0';
            this.txtBarcode.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtBarcode.PlaceholderText = "";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.SelectedText = "";
            this.txtBarcode.ShadowDecoration.BorderRadius = 15;
            this.txtBarcode.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtBarcode.ShadowDecoration.Enabled = true;
            this.txtBarcode.ShadowDecoration.Parent = this.txtBarcode;
            this.txtBarcode.Size = new System.Drawing.Size(299, 45);
            this.txtBarcode.TabIndex = 163;
            this.txtBarcode.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(46, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 31);
            this.label5.TabIndex = 169;
            this.label5.Text = "Product Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numQuantityAdjusted
            // 
            this.numQuantityAdjusted.BackColor = System.Drawing.Color.Transparent;
            this.numQuantityAdjusted.BorderColor = System.Drawing.Color.Black;
            this.numQuantityAdjusted.BorderRadius = 10;
            this.numQuantityAdjusted.BorderThickness = 2;
            this.numQuantityAdjusted.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numQuantityAdjusted.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numQuantityAdjusted.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numQuantityAdjusted.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numQuantityAdjusted.DisabledState.Parent = this.numQuantityAdjusted;
            this.numQuantityAdjusted.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.numQuantityAdjusted.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.numQuantityAdjusted.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numQuantityAdjusted.FocusedState.Parent = this.numQuantityAdjusted;
            this.numQuantityAdjusted.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantityAdjusted.ForeColor = System.Drawing.Color.Black;
            this.numQuantityAdjusted.Location = new System.Drawing.Point(394, 118);
            this.numQuantityAdjusted.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numQuantityAdjusted.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantityAdjusted.Name = "numQuantityAdjusted";
            this.numQuantityAdjusted.ShadowDecoration.BorderRadius = 15;
            this.numQuantityAdjusted.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.numQuantityAdjusted.ShadowDecoration.Parent = this.numQuantityAdjusted;
            this.numQuantityAdjusted.Size = new System.Drawing.Size(293, 45);
            this.numQuantityAdjusted.TabIndex = 164;
            this.numQuantityAdjusted.UpDownButtonFillColor = System.Drawing.Color.White;
            // 
            // txtProductName
            // 
            this.txtProductName.Animated = true;
            this.txtProductName.BackColor = System.Drawing.Color.Transparent;
            this.txtProductName.BorderColor = System.Drawing.Color.Black;
            this.txtProductName.BorderRadius = 10;
            this.txtProductName.BorderThickness = 2;
            this.txtProductName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductName.DefaultText = "";
            this.txtProductName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductName.DisabledState.Parent = this.txtProductName;
            this.txtProductName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductName.FocusedState.Parent = this.txtProductName;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtProductName.ForeColor = System.Drawing.Color.Black;
            this.txtProductName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductName.HoverState.Parent = this.txtProductName;
            this.txtProductName.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtProductName.Location = new System.Drawing.Point(50, 493);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.PasswordChar = '\0';
            this.txtProductName.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtProductName.PlaceholderText = "";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.SelectedText = "";
            this.txtProductName.ShadowDecoration.BorderRadius = 15;
            this.txtProductName.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtProductName.ShadowDecoration.Enabled = true;
            this.txtProductName.ShadowDecoration.Parent = this.txtProductName;
            this.txtProductName.Size = new System.Drawing.Size(299, 45);
            this.txtProductName.TabIndex = 168;
            this.txtProductName.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(392, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 31);
            this.label4.TabIndex = 165;
            this.label4.Text = "Quantity Adjusted";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(46, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 31);
            this.label3.TabIndex = 167;
            this.label3.Text = "Barcode";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(46, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 31);
            this.label2.TabIndex = 166;
            this.label2.Text = "Product Id";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAdjustmentType
            // 
            this.cmbAdjustmentType.Animated = true;
            this.cmbAdjustmentType.BackColor = System.Drawing.Color.Transparent;
            this.cmbAdjustmentType.BorderColor = System.Drawing.Color.Black;
            this.cmbAdjustmentType.BorderRadius = 10;
            this.cmbAdjustmentType.BorderThickness = 2;
            this.cmbAdjustmentType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAdjustmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdjustmentType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAdjustmentType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAdjustmentType.FocusedState.Parent = this.cmbAdjustmentType;
            this.cmbAdjustmentType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbAdjustmentType.ForeColor = System.Drawing.Color.Black;
            this.cmbAdjustmentType.HoverState.Parent = this.cmbAdjustmentType;
            this.cmbAdjustmentType.ItemHeight = 45;
            this.cmbAdjustmentType.Items.AddRange(new object[] {
            "Add to Inventory",
            "Removed from Inventory"});
            this.cmbAdjustmentType.ItemsAppearance.Parent = this.cmbAdjustmentType;
            this.cmbAdjustmentType.Location = new System.Drawing.Point(394, 323);
            this.cmbAdjustmentType.Name = "cmbAdjustmentType";
            this.cmbAdjustmentType.ShadowDecoration.BorderRadius = 15;
            this.cmbAdjustmentType.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbAdjustmentType.ShadowDecoration.Enabled = true;
            this.cmbAdjustmentType.ShadowDecoration.Parent = this.cmbAdjustmentType;
            this.cmbAdjustmentType.Size = new System.Drawing.Size(293, 51);
            this.cmbAdjustmentType.StartIndex = 0;
            this.cmbAdjustmentType.TabIndex = 178;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(392, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(217, 31);
            this.label10.TabIndex = 179;
            this.label10.Text = "Type of Adjustment";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StockAdjustmentForm
            // 
            this.AcceptButton = this.closed;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(729, 654);
            this.Controls.Add(this.cmbAdjustmentType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCurrentStock);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtReferenceNo);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numQuantityAdjusted);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StockAdjustmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockAdjustmentForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockAdjustmentForm_FormClosing);
            this.Load += new System.EventHandler(this.StockAdjustmentForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityAdjusted)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button closed;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtCurrentStock;
        private Guna.UI2.WinForms.Guna2TextBox txtReason;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtProductID;
        private Guna.UI2.WinForms.Guna2TextBox txtUser;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtReferenceNo;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAction;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtBarcode;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2NumericUpDown numQuantityAdjusted;
        private Guna.UI2.WinForms.Guna2TextBox txtProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAdjustmentType;
        private System.Windows.Forms.Label label10;
    }
}