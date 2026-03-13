namespace PotpotMotorShopPOS.Views.Management
{
    partial class ProductListControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlOne = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.ProductListDatagrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReOrderLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPagedisplay = new System.Windows.Forms.Label();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Page = new System.Windows.Forms.Label();
            this.cmbItem_per_Page = new Guna.UI2.WinForms.Guna2ComboBox();
            this.BtnExportImport = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.BtnAddProduct = new Guna.UI2.WinForms.Guna2Button();
            this.Import_Export = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.Export = new System.Windows.Forms.ToolStripMenuItem();
            this.Import_PDF = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelSlipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.PnlOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductListDatagrid)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.Import_Export.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlOne
            // 
            this.PnlOne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlOne.BackColor = System.Drawing.Color.Transparent;
            this.PnlOne.BorderRadius = 20;
            this.PnlOne.Controls.Add(this.ProductListDatagrid);
            this.PnlOne.Controls.Add(this.guna2Panel2);
            this.PnlOne.Controls.Add(this.btnNext);
            this.PnlOne.Controls.Add(this.btnPrevious);
            this.PnlOne.Controls.Add(this.guna2Panel1);
            this.PnlOne.Controls.Add(this.BtnExportImport);
            this.PnlOne.Controls.Add(this.txtSearch);
            this.PnlOne.Controls.Add(this.BtnAddProduct);
            this.PnlOne.FillColor = System.Drawing.Color.White;
            this.PnlOne.FillColor2 = System.Drawing.Color.White;
            this.PnlOne.Location = new System.Drawing.Point(16, 18);
            this.PnlOne.Name = "PnlOne";
            this.PnlOne.ShadowDecoration.BorderRadius = 25;
            this.PnlOne.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.PnlOne.ShadowDecoration.Enabled = true;
            this.PnlOne.ShadowDecoration.Parent = this.PnlOne;
            this.PnlOne.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.PnlOne.Size = new System.Drawing.Size(1650, 846);
            this.PnlOne.TabIndex = 27;
            // 
            // ProductListDatagrid
            // 
            this.ProductListDatagrid.AllowUserToAddRows = false;
            this.ProductListDatagrid.AllowUserToDeleteRows = false;
            this.ProductListDatagrid.AllowUserToResizeColumns = false;
            this.ProductListDatagrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.ProductListDatagrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ProductListDatagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductListDatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductListDatagrid.BackgroundColor = System.Drawing.Color.White;
            this.ProductListDatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductListDatagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ProductListDatagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductListDatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ProductListDatagrid.ColumnHeadersHeight = 52;
            this.ProductListDatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductBarcode,
            this.ProductName,
            this.Price,
            this.Quantity,
            this.ReOrderLevel,
            this.CategoryName,
            this.ProductImageColumn,
            this.EditColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductListDatagrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.ProductListDatagrid.EnableHeadersVisualStyles = false;
            this.ProductListDatagrid.GridColor = System.Drawing.Color.White;
            this.ProductListDatagrid.Location = new System.Drawing.Point(19, 62);
            this.ProductListDatagrid.Name = "ProductListDatagrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductListDatagrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ProductListDatagrid.RowHeadersVisible = false;
            this.ProductListDatagrid.RowHeadersWidth = 51;
            this.ProductListDatagrid.RowTemplate.Height = 24;
            this.ProductListDatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductListDatagrid.Size = new System.Drawing.Size(1605, 695);
            this.ProductListDatagrid.TabIndex = 121;
            this.ProductListDatagrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.ProductListDatagrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.ProductListDatagrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.ProductListDatagrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.ProductListDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.ProductListDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.ProductListDatagrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.ProductListDatagrid.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.ProductListDatagrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.ProductListDatagrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ProductListDatagrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.ProductListDatagrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.ProductListDatagrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ProductListDatagrid.ThemeStyle.HeaderStyle.Height = 52;
            this.ProductListDatagrid.ThemeStyle.ReadOnly = false;
            this.ProductListDatagrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.ProductListDatagrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ProductListDatagrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.ProductListDatagrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ProductListDatagrid.ThemeStyle.RowsStyle.Height = 24;
            this.ProductListDatagrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ProductListDatagrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ProductListDatagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductListDatagrid_CellContentClick_1);
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductID.HeaderText = "ID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Width = 57;
            // 
            // ProductBarcode
            // 
            this.ProductBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductBarcode.HeaderText = "Barcode";
            this.ProductBarcode.MinimumWidth = 6;
            this.ProductBarcode.Name = "ProductBarcode";
            this.ProductBarcode.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 76;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 107;
            // 
            // ReOrderLevel
            // 
            this.ReOrderLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ReOrderLevel.HeaderText = "Re-Order";
            this.ReOrderLevel.MinimumWidth = 6;
            this.ReOrderLevel.Name = "ReOrderLevel";
            this.ReOrderLevel.ReadOnly = true;
            this.ReOrderLevel.Width = 111;
            // 
            // CategoryName
            // 
            this.CategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CategoryName.HeaderText = "Category";
            this.CategoryName.MinimumWidth = 6;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // ProductImageColumn
            // 
            this.ProductImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductImageColumn.HeaderText = "Image";
            this.ProductImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ProductImageColumn.MinimumWidth = 6;
            this.ProductImageColumn.Name = "ProductImageColumn";
            this.ProductImageColumn.ReadOnly = true;
            // 
            // EditColumn
            // 
            this.EditColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EditColumn.DividerWidth = 2;
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::PotpotMotorShopPOS.Properties.Resources.icons8_edit_40;
            this.EditColumn.MinimumWidth = 6;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            this.EditColumn.Width = 6;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel2.BorderRadius = 5;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.lblPagedisplay);
            this.guna2Panel2.Location = new System.Drawing.Point(1306, 796);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 10;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(169, 34);
            this.guna2Panel2.TabIndex = 49;
            // 
            // lblPagedisplay
            // 
            this.lblPagedisplay.BackColor = System.Drawing.Color.White;
            this.lblPagedisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagedisplay.Location = new System.Drawing.Point(3, 6);
            this.lblPagedisplay.Name = "lblPagedisplay";
            this.lblPagedisplay.Size = new System.Drawing.Size(163, 25);
            this.lblPagedisplay.TabIndex = 48;
            this.lblPagedisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Animated = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnNext.BorderRadius = 5;
            this.btnNext.BorderThickness = 1;
            this.btnNext.CheckedState.Parent = this.btnNext;
            this.btnNext.CustomImages.Parent = this.btnNext;
            this.btnNext.FillColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnNext.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnNext.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnNext.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnNext.HoverState.Parent = this.btnNext;
            this.btnNext.Image = global::PotpotMotorShopPOS.Properties.Resources.greater70;
            this.btnNext.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnNext.ImageOffset = new System.Drawing.Point(8, 0);
            this.btnNext.Location = new System.Drawing.Point(1482, 796);
            this.btnNext.Name = "btnNext";
            this.btnNext.ShadowDecoration.BorderRadius = 10;
            this.btnNext.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnNext.ShadowDecoration.Enabled = true;
            this.btnNext.ShadowDecoration.Parent = this.btnNext;
            this.btnNext.Size = new System.Drawing.Size(142, 34);
            this.btnNext.TabIndex = 47;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Animated = true;
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnPrevious.BorderRadius = 5;
            this.btnPrevious.BorderThickness = 1;
            this.btnPrevious.CheckedState.Parent = this.btnPrevious;
            this.btnPrevious.CustomImages.Parent = this.btnPrevious;
            this.btnPrevious.FillColor = System.Drawing.Color.White;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnPrevious.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnPrevious.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnPrevious.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnPrevious.HoverState.Parent = this.btnPrevious;
            this.btnPrevious.Image = global::PotpotMotorShopPOS.Properties.Resources.less70;
            this.btnPrevious.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPrevious.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnPrevious.Location = new System.Drawing.Point(1155, 796);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.ShadowDecoration.BorderRadius = 10;
            this.btnPrevious.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPrevious.ShadowDecoration.Enabled = true;
            this.btnPrevious.ShadowDecoration.Parent = this.btnPrevious;
            this.btnPrevious.Size = new System.Drawing.Size(145, 34);
            this.btnPrevious.TabIndex = 46;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.TextOffset = new System.Drawing.Point(10, 0);
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.Page);
            this.guna2Panel1.Controls.Add(this.cmbItem_per_Page);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(19, 18);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(258, 38);
            this.guna2Panel1.TabIndex = 45;
            // 
            // Page
            // 
            this.Page.Dock = System.Windows.Forms.DockStyle.Left;
            this.Page.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Page.Location = new System.Drawing.Point(0, 0);
            this.Page.Name = "Page";
            this.Page.Size = new System.Drawing.Size(134, 38);
            this.Page.TabIndex = 0;
            this.Page.Text = "Item per page";
            this.Page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbItem_per_Page
            // 
            this.cmbItem_per_Page.Animated = true;
            this.cmbItem_per_Page.BackColor = System.Drawing.Color.White;
            this.cmbItem_per_Page.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.cmbItem_per_Page.BorderThickness = 0;
            this.cmbItem_per_Page.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbItem_per_Page.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbItem_per_Page.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem_per_Page.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.cmbItem_per_Page.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbItem_per_Page.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbItem_per_Page.FocusedState.Parent = this.cmbItem_per_Page;
            this.cmbItem_per_Page.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbItem_per_Page.ForeColor = System.Drawing.Color.White;
            this.cmbItem_per_Page.HoverState.Parent = this.cmbItem_per_Page;
            this.cmbItem_per_Page.ItemHeight = 42;
            this.cmbItem_per_Page.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "80",
            "100"});
            this.cmbItem_per_Page.ItemsAppearance.Parent = this.cmbItem_per_Page;
            this.cmbItem_per_Page.Location = new System.Drawing.Point(139, 0);
            this.cmbItem_per_Page.Name = "cmbItem_per_Page";
            this.cmbItem_per_Page.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.cmbItem_per_Page.ShadowDecoration.Enabled = true;
            this.cmbItem_per_Page.ShadowDecoration.Parent = this.cmbItem_per_Page;
            this.cmbItem_per_Page.Size = new System.Drawing.Size(119, 48);
            this.cmbItem_per_Page.StartIndex = 0;
            this.cmbItem_per_Page.TabIndex = 44;
            this.cmbItem_per_Page.SelectedIndexChanged += new System.EventHandler(this.cmbItem_per_Page_SelectedIndexChanged_1);
            // 
            // BtnExportImport
            // 
            this.BtnExportImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExportImport.Animated = true;
            this.BtnExportImport.BackColor = System.Drawing.Color.Transparent;
            this.BtnExportImport.BorderRadius = 10;
            this.BtnExportImport.CheckedState.Parent = this.BtnExportImport;
            this.BtnExportImport.CustomImages.Parent = this.BtnExportImport;
            this.BtnExportImport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.BtnExportImport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnExportImport.ForeColor = System.Drawing.Color.White;
            this.BtnExportImport.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnExportImport.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnExportImport.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportImport.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnExportImport.HoverState.Parent = this.BtnExportImport;
            this.BtnExportImport.Image = global::PotpotMotorShopPOS.Properties.Resources.export70;
            this.BtnExportImport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnExportImport.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnExportImport.ImageSize = new System.Drawing.Size(40, 40);
            this.BtnExportImport.Location = new System.Drawing.Point(1217, 15);
            this.BtnExportImport.Name = "BtnExportImport";
            this.BtnExportImport.ShadowDecoration.BorderRadius = 15;
            this.BtnExportImport.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnExportImport.ShadowDecoration.Enabled = true;
            this.BtnExportImport.ShadowDecoration.Parent = this.BtnExportImport;
            this.BtnExportImport.Size = new System.Drawing.Size(174, 40);
            this.BtnExportImport.TabIndex = 42;
            this.BtnExportImport.Text = "Export";
            this.BtnExportImport.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnExportImport.Click += new System.EventHandler(this.BtnExportImport_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Animated = true;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.IconLeft = global::PotpotMotorShopPOS.Properties.Resources.icon_search;
            this.txtSearch.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtSearch.Location = new System.Drawing.Point(284, 17);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtSearch.PlaceholderText = "Search";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 20;
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(915, 38);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // BtnAddProduct
            // 
            this.BtnAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddProduct.Animated = true;
            this.BtnAddProduct.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddProduct.BorderRadius = 10;
            this.BtnAddProduct.CheckedState.Parent = this.BtnAddProduct;
            this.BtnAddProduct.CustomImages.Parent = this.BtnAddProduct;
            this.BtnAddProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.BtnAddProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnAddProduct.ForeColor = System.Drawing.Color.White;
            this.BtnAddProduct.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnAddProduct.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnAddProduct.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddProduct.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnAddProduct.HoverState.Parent = this.BtnAddProduct;
            this.BtnAddProduct.Image = global::PotpotMotorShopPOS.Properties.Resources.Add70;
            this.BtnAddProduct.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnAddProduct.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnAddProduct.ImageSize = new System.Drawing.Size(40, 40);
            this.BtnAddProduct.Location = new System.Drawing.Point(1397, 15);
            this.BtnAddProduct.Name = "BtnAddProduct";
            this.BtnAddProduct.ShadowDecoration.BorderRadius = 15;
            this.BtnAddProduct.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnAddProduct.ShadowDecoration.Enabled = true;
            this.BtnAddProduct.ShadowDecoration.Parent = this.BtnAddProduct;
            this.BtnAddProduct.Size = new System.Drawing.Size(227, 40);
            this.BtnAddProduct.TabIndex = 41;
            this.BtnAddProduct.Text = "Add Product";
            this.BtnAddProduct.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click);
            // 
            // Import_Export
            // 
            this.Import_Export.BackColor = System.Drawing.Color.White;
            this.Import_Export.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Import_Export.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Import_Export.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Export,
            this.Import_PDF});
            this.Import_Export.Name = "Import";
            this.Import_Export.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.Import_Export.RenderStyle.BorderColor = System.Drawing.Color.White;
            this.Import_Export.RenderStyle.ColorTable = null;
            this.Import_Export.RenderStyle.RoundedEdges = true;
            this.Import_Export.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.Import_Export.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.Import_Export.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Import_Export.RenderStyle.SeparatorColor = System.Drawing.Color.White;
            this.Import_Export.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.Import_Export.Size = new System.Drawing.Size(190, 68);
            // 
            // Export
            // 
            this.Export.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(189, 32);
            this.Export.Text = "Export List";
            // 
            // Import_PDF
            // 
            this.Import_PDF.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Import_PDF.Name = "Import_PDF";
            this.Import_PDF.Size = new System.Drawing.Size(189, 32);
            this.Import_PDF.Text = "Import PDF";
            // 
            // LabelSlipse
            // 
            this.LabelSlipse.BorderRadius = 5;
            this.LabelSlipse.TargetControl = this.lblPagedisplay;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.DividerWidth = 2;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::PotpotMotorShopPOS.Properties.Resources.icon_edit;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 125;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::PotpotMotorShopPOS.Properties.Resources.icon_delete;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 125;
            // 
            // ProductListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlOne);
            this.Name = "ProductListControl";
            this.Size = new System.Drawing.Size(1682, 884);
            this.PnlOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductListDatagrid)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.Import_Export.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientPanel PnlOne;
        private Guna.UI2.WinForms.Guna2Button BtnAddProduct;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Guna.UI2.WinForms.Guna2Button BtnExportImport;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip Import_Export;
        private System.Windows.Forms.ToolStripMenuItem Export;
        private System.Windows.Forms.ToolStripMenuItem Import_PDF;
        private Guna.UI2.WinForms.Guna2ComboBox cmbItem_per_Page;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label Page;
        private System.Windows.Forms.Label lblPagedisplay;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnPrevious;
        private Guna.UI2.WinForms.Guna2Elipse LabelSlipse;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DataGridView ProductListDatagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReOrderLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewImageColumn ProductImageColumn;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
    }
}
