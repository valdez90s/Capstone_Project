namespace PotpotMotorShopPOS.Forms.Report
{
    partial class DailySalesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBack = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2Panel11 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalSales = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalItems = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalTransactions = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.lblDateHeader = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPrintDailysales = new Guna.UI2.WinForms.Guna2Button();
            this.dgvSalesToday = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel6.SuspendLayout();
            this.guna2Panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesToday)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel6.BorderRadius = 20;
            this.guna2Panel6.Controls.Add(this.btnBack);
            this.guna2Panel6.Controls.Add(this.guna2Panel11);
            this.guna2Panel6.Controls.Add(this.btnRefresh);
            this.guna2Panel6.Controls.Add(this.lblDateHeader);
            this.guna2Panel6.Controls.Add(this.btnPrintDailysales);
            this.guna2Panel6.Controls.Add(this.dgvSalesToday);
            this.guna2Panel6.FillColor = System.Drawing.Color.White;
            this.guna2Panel6.Location = new System.Drawing.Point(15, 19);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.ShadowDecoration.BorderRadius = 25;
            this.guna2Panel6.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2Panel6.ShadowDecoration.Enabled = true;
            this.guna2Panel6.ShadowDecoration.Parent = this.guna2Panel6;
            this.guna2Panel6.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.guna2Panel6.Size = new System.Drawing.Size(1355, 776);
            this.guna2Panel6.TabIndex = 12;
            // 
            // btnBack
            // 
            this.btnBack.Animated = true;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.CheckedState.Parent = this.btnBack;
            this.btnBack.CustomImages.Parent = this.btnBack;
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBack.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBack.HoverState.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.HoverState.Parent = this.btnBack;
            this.btnBack.Image = global::PotpotMotorShopPOS.Properties.Resources.BackIcon;
            this.btnBack.Location = new System.Drawing.Point(21, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnBack.ShadowDecoration.Parent = this.btnBack;
            this.btnBack.Size = new System.Drawing.Size(47, 43);
            this.btnBack.TabIndex = 135;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // guna2Panel11
            // 
            this.guna2Panel11.Controls.Add(this.lblTotalSales);
            this.guna2Panel11.Controls.Add(this.lblTotalItems);
            this.guna2Panel11.Controls.Add(this.lblTotalTransactions);
            this.guna2Panel11.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2Panel11.CustomBorderThickness = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.guna2Panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel11.Location = new System.Drawing.Point(0, 715);
            this.guna2Panel11.Name = "guna2Panel11";
            this.guna2Panel11.ShadowDecoration.Parent = this.guna2Panel11;
            this.guna2Panel11.Size = new System.Drawing.Size(1355, 61);
            this.guna2Panel11.TabIndex = 134;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSales.AutoSize = false;
            this.lblTotalSales.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblTotalSales.Location = new System.Drawing.Point(1061, 13);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(273, 36);
            this.lblTotalSales.TabIndex = 130;
            this.lblTotalSales.Text = null;
            this.lblTotalSales.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalItems.AutoSize = false;
            this.lblTotalItems.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblTotalItems.Location = new System.Drawing.Point(749, 13);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(292, 36);
            this.lblTotalItems.TabIndex = 132;
            this.lblTotalItems.Text = null;
            this.lblTotalItems.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalTransactions
            // 
            this.lblTotalTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTransactions.AutoSize = false;
            this.lblTotalTransactions.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalTransactions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblTotalTransactions.Location = new System.Drawing.Point(425, 13);
            this.lblTotalTransactions.Name = "lblTotalTransactions";
            this.lblTotalTransactions.Size = new System.Drawing.Size(303, 36);
            this.lblTotalTransactions.TabIndex = 131;
            this.lblTotalTransactions.Text = null;
            this.lblTotalTransactions.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalTransactions.Click += new System.EventHandler(this.lblTotalTransactions_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Animated = true;
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.CheckedState.Parent = this.btnRefresh;
            this.btnRefresh.CustomImages.Parent = this.btnRefresh;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRefresh.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRefresh.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.HoverState.Parent = this.btnRefresh;
            this.btnRefresh.Image = global::PotpotMotorShopPOS.Properties.Resources.print;
            this.btnRefresh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRefresh.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnRefresh.ImageSize = new System.Drawing.Size(30, 30);
            this.btnRefresh.Location = new System.Drawing.Point(1012, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShadowDecoration.BorderRadius = 15;
            this.btnRefresh.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRefresh.ShadowDecoration.Enabled = true;
            this.btnRefresh.ShadowDecoration.Parent = this.btnRefresh;
            this.btnRefresh.Size = new System.Drawing.Size(165, 46);
            this.btnRefresh.TabIndex = 133;
            this.btnRefresh.Text = "     REFRESH";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblDateHeader
            // 
            this.lblDateHeader.AutoSize = false;
            this.lblDateHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblDateHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.lblDateHeader.Location = new System.Drawing.Point(84, 18);
            this.lblDateHeader.Name = "lblDateHeader";
            this.lblDateHeader.Size = new System.Drawing.Size(400, 36);
            this.lblDateHeader.TabIndex = 128;
            this.lblDateHeader.Text = null;
            this.lblDateHeader.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrintDailysales
            // 
            this.btnPrintDailysales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintDailysales.Animated = true;
            this.btnPrintDailysales.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintDailysales.BorderRadius = 10;
            this.btnPrintDailysales.CheckedState.Parent = this.btnPrintDailysales;
            this.btnPrintDailysales.CustomImages.Parent = this.btnPrintDailysales;
            this.btnPrintDailysales.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnPrintDailysales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrintDailysales.ForeColor = System.Drawing.Color.White;
            this.btnPrintDailysales.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPrintDailysales.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPrintDailysales.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintDailysales.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnPrintDailysales.HoverState.Parent = this.btnPrintDailysales;
            this.btnPrintDailysales.Image = global::PotpotMotorShopPOS.Properties.Resources.print;
            this.btnPrintDailysales.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPrintDailysales.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnPrintDailysales.ImageSize = new System.Drawing.Size(30, 30);
            this.btnPrintDailysales.Location = new System.Drawing.Point(1183, 12);
            this.btnPrintDailysales.Name = "btnPrintDailysales";
            this.btnPrintDailysales.ShadowDecoration.BorderRadius = 15;
            this.btnPrintDailysales.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPrintDailysales.ShadowDecoration.Enabled = true;
            this.btnPrintDailysales.ShadowDecoration.Parent = this.btnPrintDailysales;
            this.btnPrintDailysales.Size = new System.Drawing.Size(151, 46);
            this.btnPrintDailysales.TabIndex = 127;
            this.btnPrintDailysales.Text = "     PRINT";
            this.btnPrintDailysales.Click += new System.EventHandler(this.btnPrintDailysales_Click);
            // 
            // dgvSalesToday
            // 
            this.dgvSalesToday.AllowUserToAddRows = false;
            this.dgvSalesToday.AllowUserToDeleteRows = false;
            this.dgvSalesToday.AllowUserToResizeColumns = false;
            this.dgvSalesToday.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSalesToday.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesToday.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesToday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesToday.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalesToday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalesToday.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSalesToday.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesToday.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesToday.ColumnHeadersHeight = 52;
            this.dgvSalesToday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoiceNo,
            this.colTime,
            this.colCustomer,
            this.colItemNames,
            this.colQty,
            this.colTotal,
            this.colDiscount,
            this.colPayment,
            this.colCashier});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesToday.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalesToday.EnableHeadersVisualStyles = false;
            this.dgvSalesToday.GridColor = System.Drawing.Color.White;
            this.dgvSalesToday.Location = new System.Drawing.Point(21, 70);
            this.dgvSalesToday.Name = "dgvSalesToday";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesToday.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSalesToday.RowHeadersVisible = false;
            this.dgvSalesToday.RowHeadersWidth = 51;
            this.dgvSalesToday.RowTemplate.Height = 24;
            this.dgvSalesToday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesToday.Size = new System.Drawing.Size(1313, 625);
            this.dgvSalesToday.TabIndex = 126;
            this.dgvSalesToday.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvSalesToday.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalesToday.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSalesToday.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSalesToday.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSalesToday.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSalesToday.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalesToday.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dgvSalesToday.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSalesToday.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSalesToday.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSalesToday.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSalesToday.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSalesToday.ThemeStyle.HeaderStyle.Height = 52;
            this.dgvSalesToday.ThemeStyle.ReadOnly = false;
            this.dgvSalesToday.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalesToday.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSalesToday.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSalesToday.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSalesToday.ThemeStyle.RowsStyle.Height = 24;
            this.dgvSalesToday.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalesToday.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSalesToday.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesToday_CellContentClick);
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.HeaderText = "InvoiceNo";
            this.colInvoiceNo.MinimumWidth = 6;
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.MinimumWidth = 6;
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "Customer";
            this.colCustomer.MinimumWidth = 6;
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colItemNames
            // 
            this.colItemNames.HeaderText = "Item";
            this.colItemNames.MinimumWidth = 6;
            this.colItemNames.Name = "colItemNames";
            // 
            // colQty
            // 
            this.colQty.HeaderText = "Qty";
            this.colQty.MinimumWidth = 6;
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colDiscount
            // 
            this.colDiscount.HeaderText = "Discount";
            this.colDiscount.MinimumWidth = 6;
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.ReadOnly = true;
            // 
            // colPayment
            // 
            this.colPayment.HeaderText = "Payment";
            this.colPayment.MinimumWidth = 6;
            this.colPayment.Name = "colPayment";
            this.colPayment.ReadOnly = true;
            // 
            // colCashier
            // 
            this.colCashier.HeaderText = "CreatedBy";
            this.colCashier.MinimumWidth = 6;
            this.colCashier.Name = "colCashier";
            this.colCashier.ReadOnly = true;
            // 
            // DailySalesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Panel6);
            this.Name = "DailySalesControl";
            this.Size = new System.Drawing.Size(1384, 814);
            this.Load += new System.EventHandler(this.DailySalesControl_Load);
            this.VisibleChanged += new System.EventHandler(this.DailySalesControl_VisibleChanged);
            this.guna2Panel6.ResumeLayout(false);
            this.guna2Panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesToday)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSalesToday;
        private Guna.UI2.WinForms.Guna2Button btnPrintDailysales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCashier;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalSales;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDateHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalItems;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalTransactions;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel11;
        private Guna.UI2.WinForms.Guna2CircleButton btnBack;
    }
}
