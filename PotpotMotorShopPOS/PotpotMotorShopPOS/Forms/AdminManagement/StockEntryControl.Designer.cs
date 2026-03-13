namespace PotpotMotorShopPOS.Views.Management
{
    partial class StockEntryControl
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
            this.guna2GradientPanel5 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txtBarcodeScanner = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblGrandTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.StockEntryListDatagrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.RowIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnremoved = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnSaveEntry = new Guna.UI2.WinForms.Guna2Button();
            this.btnBrowseProducts = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel6 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txtContactPerson = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSupplier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStockInBy = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGenereteReference = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtReferenceNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.guna2GradientPanel5.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockEntryListDatagrid)).BeginInit();
            this.guna2GradientPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel5
            // 
            this.guna2GradientPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel5.BorderRadius = 20;
            this.guna2GradientPanel5.Controls.Add(this.guna2GradientPanel1);
            this.guna2GradientPanel5.Controls.Add(this.guna2GradientPanel6);
            this.guna2GradientPanel5.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel5.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel5.Location = new System.Drawing.Point(18, 16);
            this.guna2GradientPanel5.Name = "guna2GradientPanel5";
            this.guna2GradientPanel5.ShadowDecoration.BorderRadius = 25;
            this.guna2GradientPanel5.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel5.ShadowDecoration.Depth = 35;
            this.guna2GradientPanel5.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel5.ShadowDecoration.Parent = this.guna2GradientPanel5;
            this.guna2GradientPanel5.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.guna2GradientPanel5.Size = new System.Drawing.Size(1394, 870);
            this.guna2GradientPanel5.TabIndex = 11;
            this.guna2GradientPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel5_Paint);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.txtBarcodeScanner);
            this.guna2GradientPanel1.Controls.Add(this.lblGrandTotal);
            this.guna2GradientPanel1.Controls.Add(this.StockEntryListDatagrid);
            this.guna2GradientPanel1.Controls.Add(this.btnSaveEntry);
            this.guna2GradientPanel1.Controls.Add(this.btnBrowseProducts);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(458, 21);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.BorderRadius = 25;
            this.guna2GradientPanel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.guna2GradientPanel1.Size = new System.Drawing.Size(919, 606);
            this.guna2GradientPanel1.TabIndex = 7;
            // 
            // txtBarcodeScanner
            // 
            this.txtBarcodeScanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcodeScanner.Animated = true;
            this.txtBarcodeScanner.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtBarcodeScanner.BorderRadius = 10;
            this.txtBarcodeScanner.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBarcodeScanner.DefaultText = "";
            this.txtBarcodeScanner.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBarcodeScanner.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBarcodeScanner.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBarcodeScanner.DisabledState.Parent = this.txtBarcodeScanner;
            this.txtBarcodeScanner.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBarcodeScanner.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBarcodeScanner.FocusedState.Parent = this.txtBarcodeScanner;
            this.txtBarcodeScanner.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBarcodeScanner.ForeColor = System.Drawing.Color.Black;
            this.txtBarcodeScanner.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtBarcodeScanner.HoverState.Parent = this.txtBarcodeScanner;
            this.txtBarcodeScanner.IconLeft = global::PotpotMotorShopPOS.Properties.Resources.icon_search;
            this.txtBarcodeScanner.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.txtBarcodeScanner.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtBarcodeScanner.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtBarcodeScanner.Location = new System.Drawing.Point(17, 15);
            this.txtBarcodeScanner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBarcodeScanner.Name = "txtBarcodeScanner";
            this.txtBarcodeScanner.PasswordChar = '\0';
            this.txtBarcodeScanner.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtBarcodeScanner.PlaceholderText = "Scan Barcode";
            this.txtBarcodeScanner.SelectedText = "";
            this.txtBarcodeScanner.ShadowDecoration.BorderRadius = 20;
            this.txtBarcodeScanner.ShadowDecoration.Parent = this.txtBarcodeScanner;
            this.txtBarcodeScanner.Size = new System.Drawing.Size(884, 38);
            this.txtBarcodeScanner.TabIndex = 138;
            this.txtBarcodeScanner.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = false;
            this.lblGrandTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(430, 560);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(321, 36);
            this.lblGrandTotal.TabIndex = 137;
            this.lblGrandTotal.Text = null;
            this.lblGrandTotal.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StockEntryListDatagrid
            // 
            this.StockEntryListDatagrid.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.StockEntryListDatagrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.StockEntryListDatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StockEntryListDatagrid.BackgroundColor = System.Drawing.Color.White;
            this.StockEntryListDatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StockEntryListDatagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.StockEntryListDatagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StockEntryListDatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.StockEntryListDatagrid.ColumnHeadersHeight = 52;
            this.StockEntryListDatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIndex,
            this.ReferenceNo,
            this.ProductBarcode,
            this.ProductID,
            this.NameProduct,
            this.ProductQuantity,
            this.ProductPrice,
            this.ProductTotalCost,
            this.btnremoved});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StockEntryListDatagrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.StockEntryListDatagrid.EnableHeadersVisualStyles = false;
            this.StockEntryListDatagrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.StockEntryListDatagrid.Location = new System.Drawing.Point(17, 60);
            this.StockEntryListDatagrid.Name = "StockEntryListDatagrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StockEntryListDatagrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.StockEntryListDatagrid.RowHeadersVisible = false;
            this.StockEntryListDatagrid.RowHeadersWidth = 51;
            this.StockEntryListDatagrid.RowTemplate.Height = 24;
            this.StockEntryListDatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StockEntryListDatagrid.Size = new System.Drawing.Size(884, 490);
            this.StockEntryListDatagrid.TabIndex = 136;
            this.StockEntryListDatagrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.StockEntryListDatagrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.StockEntryListDatagrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.StockEntryListDatagrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.StockEntryListDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.StockEntryListDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.StockEntryListDatagrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.StockEntryListDatagrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.StockEntryListDatagrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.StockEntryListDatagrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.StockEntryListDatagrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.StockEntryListDatagrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.StockEntryListDatagrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.StockEntryListDatagrid.ThemeStyle.HeaderStyle.Height = 52;
            this.StockEntryListDatagrid.ThemeStyle.ReadOnly = false;
            this.StockEntryListDatagrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.StockEntryListDatagrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.StockEntryListDatagrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.StockEntryListDatagrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.StockEntryListDatagrid.ThemeStyle.RowsStyle.Height = 24;
            this.StockEntryListDatagrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.StockEntryListDatagrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.StockEntryListDatagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StockEntryListDatagrid_CellContentClick_1);
            this.StockEntryListDatagrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.StockEntryListDatagrid_CellValidating);
            this.StockEntryListDatagrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.StockEntryListDatagrid_CellValueChanged);
            this.StockEntryListDatagrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.StockEntryListDatagrid_CurrentCellDirtyStateChanged);
            this.StockEntryListDatagrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.StockEntryListDatagrid_EditingControlShowing);
            // 
            // RowIndex
            // 
            this.RowIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RowIndex.HeaderText = "#";
            this.RowIndex.MinimumWidth = 6;
            this.RowIndex.Name = "RowIndex";
            this.RowIndex.ReadOnly = true;
            this.RowIndex.Width = 50;
            // 
            // ReferenceNo
            // 
            this.ReferenceNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReferenceNo.HeaderText = "REF #";
            this.ReferenceNo.MinimumWidth = 6;
            this.ReferenceNo.Name = "ReferenceNo";
            this.ReferenceNo.ReadOnly = true;
            // 
            // ProductBarcode
            // 
            this.ProductBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductBarcode.HeaderText = "BARCODE";
            this.ProductBarcode.MinimumWidth = 6;
            this.ProductBarcode.Name = "ProductBarcode";
            this.ProductBarcode.ReadOnly = true;
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductID.HeaderText = "P-ID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Width = 74;
            // 
            // NameProduct
            // 
            this.NameProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameProduct.HeaderText = "PRODUCT NAME";
            this.NameProduct.MinimumWidth = 6;
            this.NameProduct.Name = "NameProduct";
            this.NameProduct.ReadOnly = true;
            // 
            // ProductQuantity
            // 
            this.ProductQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductQuantity.HeaderText = "QUANTITY";
            this.ProductQuantity.MinimumWidth = 6;
            this.ProductQuantity.Name = "ProductQuantity";
            // 
            // ProductPrice
            // 
            this.ProductPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductPrice.HeaderText = "PRICE";
            this.ProductPrice.MinimumWidth = 6;
            this.ProductPrice.Name = "ProductPrice";
            this.ProductPrice.ReadOnly = true;
            this.ProductPrice.Width = 85;
            // 
            // ProductTotalCost
            // 
            this.ProductTotalCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductTotalCost.HeaderText = "TOTAL";
            this.ProductTotalCost.MinimumWidth = 6;
            this.ProductTotalCost.Name = "ProductTotalCost";
            this.ProductTotalCost.ReadOnly = true;
            this.ProductTotalCost.Width = 88;
            // 
            // btnremoved
            // 
            this.btnremoved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnremoved.HeaderText = "";
            this.btnremoved.Image = global::PotpotMotorShopPOS.Properties.Resources.minus;
            this.btnremoved.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.btnremoved.MinimumWidth = 6;
            this.btnremoved.Name = "btnremoved";
            this.btnremoved.ReadOnly = true;
            this.btnremoved.Width = 6;
            // 
            // btnSaveEntry
            // 
            this.btnSaveEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveEntry.Animated = true;
            this.btnSaveEntry.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveEntry.BorderRadius = 10;
            this.btnSaveEntry.CheckedState.Parent = this.btnSaveEntry;
            this.btnSaveEntry.CustomImages.Parent = this.btnSaveEntry;
            this.btnSaveEntry.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnSaveEntry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveEntry.ForeColor = System.Drawing.Color.White;
            this.btnSaveEntry.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnSaveEntry.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnSaveEntry.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEntry.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnSaveEntry.HoverState.Parent = this.btnSaveEntry;
            this.btnSaveEntry.Location = new System.Drawing.Point(757, 556);
            this.btnSaveEntry.Name = "btnSaveEntry";
            this.btnSaveEntry.ShadowDecoration.BorderRadius = 15;
            this.btnSaveEntry.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSaveEntry.ShadowDecoration.Enabled = true;
            this.btnSaveEntry.ShadowDecoration.Parent = this.btnSaveEntry;
            this.btnSaveEntry.Size = new System.Drawing.Size(144, 40);
            this.btnSaveEntry.TabIndex = 135;
            this.btnSaveEntry.Text = "Save";
            this.btnSaveEntry.Click += new System.EventHandler(this.btnSaveEntry_Click);
            // 
            // btnBrowseProducts
            // 
            this.btnBrowseProducts.AutoSize = false;
            this.btnBrowseProducts.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowseProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseProducts.ForeColor = System.Drawing.Color.Blue;
            this.btnBrowseProducts.Location = new System.Drawing.Point(17, 560);
            this.btnBrowseProducts.Name = "btnBrowseProducts";
            this.btnBrowseProducts.Size = new System.Drawing.Size(229, 27);
            this.btnBrowseProducts.TabIndex = 134;
            this.btnBrowseProducts.Text = "Browse Products";
            this.btnBrowseProducts.UseSystemCursors = true;
            this.btnBrowseProducts.CursorChanged += new System.EventHandler(this.btnBrowseProducts_CursorChanged);
            this.btnBrowseProducts.Click += new System.EventHandler(this.btnBrowseProducts_Click);
            // 
            // guna2GradientPanel6
            // 
            this.guna2GradientPanel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel6.BorderRadius = 20;
            this.guna2GradientPanel6.Controls.Add(this.txtContactPerson);
            this.guna2GradientPanel6.Controls.Add(this.label4);
            this.guna2GradientPanel6.Controls.Add(this.txtAddress);
            this.guna2GradientPanel6.Controls.Add(this.label2);
            this.guna2GradientPanel6.Controls.Add(this.cmbSupplier);
            this.guna2GradientPanel6.Controls.Add(this.label7);
            this.guna2GradientPanel6.Controls.Add(this.txtStockInBy);
            this.guna2GradientPanel6.Controls.Add(this.label1);
            this.guna2GradientPanel6.Controls.Add(this.lblGenereteReference);
            this.guna2GradientPanel6.Controls.Add(this.txtReferenceNo);
            this.guna2GradientPanel6.Controls.Add(this.label13);
            this.guna2GradientPanel6.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel6.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel6.Location = new System.Drawing.Point(31, 21);
            this.guna2GradientPanel6.Name = "guna2GradientPanel6";
            this.guna2GradientPanel6.ShadowDecoration.BorderRadius = 25;
            this.guna2GradientPanel6.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel6.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel6.ShadowDecoration.Parent = this.guna2GradientPanel6;
            this.guna2GradientPanel6.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.guna2GradientPanel6.Size = new System.Drawing.Size(406, 606);
            this.guna2GradientPanel6.TabIndex = 6;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Animated = true;
            this.txtContactPerson.BackColor = System.Drawing.Color.Transparent;
            this.txtContactPerson.BorderColor = System.Drawing.Color.Black;
            this.txtContactPerson.BorderRadius = 10;
            this.txtContactPerson.BorderThickness = 2;
            this.txtContactPerson.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContactPerson.DefaultText = "";
            this.txtContactPerson.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContactPerson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContactPerson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContactPerson.DisabledState.Parent = this.txtContactPerson;
            this.txtContactPerson.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContactPerson.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContactPerson.FocusedState.Parent = this.txtContactPerson;
            this.txtContactPerson.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtContactPerson.ForeColor = System.Drawing.Color.Black;
            this.txtContactPerson.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContactPerson.HoverState.Parent = this.txtContactPerson;
            this.txtContactPerson.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtContactPerson.Location = new System.Drawing.Point(18, 375);
            this.txtContactPerson.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContactPerson.MaxLength = 50;
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.PasswordChar = '\0';
            this.txtContactPerson.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtContactPerson.PlaceholderText = "";
            this.txtContactPerson.ReadOnly = true;
            this.txtContactPerson.SelectedText = "";
            this.txtContactPerson.ShadowDecoration.BorderRadius = 15;
            this.txtContactPerson.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtContactPerson.ShadowDecoration.Enabled = true;
            this.txtContactPerson.ShadowDecoration.Parent = this.txtContactPerson;
            this.txtContactPerson.Size = new System.Drawing.Size(368, 51);
            this.txtContactPerson.TabIndex = 130;
            this.txtContactPerson.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(19, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 31);
            this.label4.TabIndex = 133;
            this.label4.Text = "Address";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Animated = true;
            this.txtAddress.AutoScroll = true;
            this.txtAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.BorderColor = System.Drawing.Color.Black;
            this.txtAddress.BorderRadius = 10;
            this.txtAddress.BorderThickness = 2;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.Parent = this.txtAddress;
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.FocusedState.Parent = this.txtAddress;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.HoverState.Parent = this.txtAddress;
            this.txtAddress.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtAddress.Location = new System.Drawing.Point(25, 481);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.ShadowDecoration.BorderRadius = 15;
            this.txtAddress.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtAddress.ShadowDecoration.Enabled = true;
            this.txtAddress.ShadowDecoration.Parent = this.txtAddress;
            this.txtAddress.Size = new System.Drawing.Size(361, 94);
            this.txtAddress.TabIndex = 132;
            this.txtAddress.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(12, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 31);
            this.label2.TabIndex = 131;
            this.label2.Text = "Contact Person";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Animated = true;
            this.cmbSupplier.BackColor = System.Drawing.Color.Transparent;
            this.cmbSupplier.BorderColor = System.Drawing.Color.Black;
            this.cmbSupplier.BorderRadius = 10;
            this.cmbSupplier.BorderThickness = 2;
            this.cmbSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSupplier.FocusedState.Parent = this.cmbSupplier;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbSupplier.ForeColor = System.Drawing.Color.Black;
            this.cmbSupplier.HoverState.Parent = this.cmbSupplier;
            this.cmbSupplier.ItemHeight = 45;
            this.cmbSupplier.ItemsAppearance.Parent = this.cmbSupplier;
            this.cmbSupplier.Location = new System.Drawing.Point(18, 264);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.ShadowDecoration.BorderRadius = 15;
            this.cmbSupplier.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbSupplier.ShadowDecoration.Enabled = true;
            this.cmbSupplier.ShadowDecoration.Parent = this.cmbSupplier;
            this.cmbSupplier.Size = new System.Drawing.Size(368, 51);
            this.cmbSupplier.TabIndex = 129;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(19, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 31);
            this.label7.TabIndex = 128;
            this.label7.Text = "Supplier";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStockInBy
            // 
            this.txtStockInBy.Animated = true;
            this.txtStockInBy.BackColor = System.Drawing.Color.Transparent;
            this.txtStockInBy.BorderColor = System.Drawing.Color.Black;
            this.txtStockInBy.BorderRadius = 10;
            this.txtStockInBy.BorderThickness = 2;
            this.txtStockInBy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStockInBy.DefaultText = "";
            this.txtStockInBy.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtStockInBy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtStockInBy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStockInBy.DisabledState.Parent = this.txtStockInBy;
            this.txtStockInBy.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStockInBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStockInBy.FocusedState.Parent = this.txtStockInBy;
            this.txtStockInBy.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtStockInBy.ForeColor = System.Drawing.Color.Black;
            this.txtStockInBy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStockInBy.HoverState.Parent = this.txtStockInBy;
            this.txtStockInBy.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtStockInBy.Location = new System.Drawing.Point(18, 154);
            this.txtStockInBy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStockInBy.MaxLength = 50;
            this.txtStockInBy.Name = "txtStockInBy";
            this.txtStockInBy.PasswordChar = '\0';
            this.txtStockInBy.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtStockInBy.PlaceholderText = "";
            this.txtStockInBy.ReadOnly = true;
            this.txtStockInBy.SelectedText = "";
            this.txtStockInBy.ShadowDecoration.BorderRadius = 15;
            this.txtStockInBy.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtStockInBy.ShadowDecoration.Enabled = true;
            this.txtStockInBy.ShadowDecoration.Parent = this.txtStockInBy;
            this.txtStockInBy.Size = new System.Drawing.Size(368, 51);
            this.txtStockInBy.TabIndex = 119;
            this.txtStockInBy.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 31);
            this.label1.TabIndex = 120;
            this.label1.Text = "Stock In by:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGenereteReference
            // 
            this.lblGenereteReference.AutoSize = false;
            this.lblGenereteReference.BackColor = System.Drawing.Color.Transparent;
            this.lblGenereteReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenereteReference.ForeColor = System.Drawing.Color.Blue;
            this.lblGenereteReference.Location = new System.Drawing.Point(265, 15);
            this.lblGenereteReference.Name = "lblGenereteReference";
            this.lblGenereteReference.Size = new System.Drawing.Size(121, 27);
            this.lblGenereteReference.TabIndex = 118;
            this.lblGenereteReference.Text = "Generate";
            this.lblGenereteReference.UseSystemCursors = true;
            this.lblGenereteReference.CursorChanged += new System.EventHandler(this.lblGenereteReference_CursorChanged);
            this.lblGenereteReference.Click += new System.EventHandler(this.lblGenereteReference_Click);
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
            this.txtReferenceNo.Location = new System.Drawing.Point(18, 50);
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
            this.txtReferenceNo.Size = new System.Drawing.Size(368, 51);
            this.txtReferenceNo.TabIndex = 115;
            this.txtReferenceNo.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(12, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(160, 31);
            this.label13.TabIndex = 116;
            this.label13.Text = "Reference No.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 125;
            // 
            // StockEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2GradientPanel5);
            this.Name = "StockEntryControl";
            this.Size = new System.Drawing.Size(1430, 903);
            this.Load += new System.EventHandler(this.StockEntryControl_Load);
            this.guna2GradientPanel5.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StockEntryListDatagrid)).EndInit();
            this.guna2GradientPanel6.ResumeLayout(false);
            this.guna2GradientPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel5;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel6;
        private Guna.UI2.WinForms.Guna2TextBox txtReferenceNo;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGenereteReference;
        private Guna.UI2.WinForms.Guna2TextBox txtStockInBy;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSupplier;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtContactPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2HtmlLabel btnBrowseProducts;
        private Guna.UI2.WinForms.Guna2Button btnSaveEntry;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Guna.UI2.WinForms.Guna2DataGridView StockEntryListDatagrid;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGrandTotal;
        private Guna.UI2.WinForms.Guna2TextBox txtBarcodeScanner;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTotalCost;
        private System.Windows.Forms.DataGridViewImageColumn btnremoved;
    }
}
