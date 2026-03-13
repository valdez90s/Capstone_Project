namespace PotpotMotorShopPOS.Views.Management
{
    partial class OutofStocksReportControl
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.cmbCategoryFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OutOfStockDatagrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReOrderLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutOfStockDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.guna2Panel2);
            this.guna2GradientPanel1.Controls.Add(this.OutOfStockDatagrid);
            this.guna2GradientPanel1.Controls.Add(this.btnPrint);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(16, 13);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.BorderRadius = 25;
            this.guna2GradientPanel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.ShadowDecoration.Depth = 25;
            this.guna2GradientPanel1.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1651, 858);
            this.guna2GradientPanel1.TabIndex = 11;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.cmbCategoryFilter);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(11, 17);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(492, 38);
            this.guna2Panel2.TabIndex = 141;
            // 
            // cmbCategoryFilter
            // 
            this.cmbCategoryFilter.Animated = true;
            this.cmbCategoryFilter.BackColor = System.Drawing.Color.White;
            this.cmbCategoryFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.cmbCategoryFilter.BorderThickness = 0;
            this.cmbCategoryFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbCategoryFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.cmbCategoryFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCategoryFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCategoryFilter.FocusedState.Parent = this.cmbCategoryFilter;
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbCategoryFilter.ForeColor = System.Drawing.Color.White;
            this.cmbCategoryFilter.HoverState.Parent = this.cmbCategoryFilter;
            this.cmbCategoryFilter.ItemHeight = 42;
            this.cmbCategoryFilter.ItemsAppearance.Parent = this.cmbCategoryFilter;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(104, 0);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.cmbCategoryFilter.ShadowDecoration.Enabled = true;
            this.cmbCategoryFilter.ShadowDecoration.Parent = this.cmbCategoryFilter;
            this.cmbCategoryFilter.Size = new System.Drawing.Size(388, 48);
            this.cmbCategoryFilter.TabIndex = 44;
            this.cmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter By:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OutOfStockDatagrid
            // 
            this.OutOfStockDatagrid.AllowUserToAddRows = false;
            this.OutOfStockDatagrid.AllowUserToDeleteRows = false;
            this.OutOfStockDatagrid.AllowUserToResizeColumns = false;
            this.OutOfStockDatagrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.OutOfStockDatagrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.OutOfStockDatagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutOfStockDatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OutOfStockDatagrid.BackgroundColor = System.Drawing.Color.White;
            this.OutOfStockDatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutOfStockDatagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.OutOfStockDatagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OutOfStockDatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.OutOfStockDatagrid.ColumnHeadersHeight = 52;
            this.OutOfStockDatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.Barcode,
            this.Price,
            this.Quantity,
            this.ReOrderLevel,
            this.CategoryName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OutOfStockDatagrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.OutOfStockDatagrid.EnableHeadersVisualStyles = false;
            this.OutOfStockDatagrid.GridColor = System.Drawing.Color.White;
            this.OutOfStockDatagrid.Location = new System.Drawing.Point(11, 61);
            this.OutOfStockDatagrid.Name = "OutOfStockDatagrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OutOfStockDatagrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.OutOfStockDatagrid.RowHeadersVisible = false;
            this.OutOfStockDatagrid.RowHeadersWidth = 51;
            this.OutOfStockDatagrid.RowTemplate.Height = 24;
            this.OutOfStockDatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OutOfStockDatagrid.Size = new System.Drawing.Size(1622, 769);
            this.OutOfStockDatagrid.TabIndex = 140;
            this.OutOfStockDatagrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.OutOfStockDatagrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.OutOfStockDatagrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.OutOfStockDatagrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.OutOfStockDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.OutOfStockDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.OutOfStockDatagrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.OutOfStockDatagrid.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.OutOfStockDatagrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.OutOfStockDatagrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.OutOfStockDatagrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.OutOfStockDatagrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.OutOfStockDatagrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.OutOfStockDatagrid.ThemeStyle.HeaderStyle.Height = 52;
            this.OutOfStockDatagrid.ThemeStyle.ReadOnly = false;
            this.OutOfStockDatagrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.OutOfStockDatagrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.OutOfStockDatagrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.OutOfStockDatagrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.OutOfStockDatagrid.ThemeStyle.RowsStyle.Height = 24;
            this.OutOfStockDatagrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.OutOfStockDatagrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.OutOfStockDatagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OutOfStockDatagrid_CellContentClick);
            this.OutOfStockDatagrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OutOfStockDatagrid_CellFormatting);
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Name";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.MinimumWidth = 6;
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // ReOrderLevel
            // 
            this.ReOrderLevel.HeaderText = "Re-Order-Level";
            this.ReOrderLevel.MinimumWidth = 6;
            this.ReOrderLevel.Name = "ReOrderLevel";
            this.ReOrderLevel.ReadOnly = true;
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "Category";
            this.CategoryName.MinimumWidth = 6;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Animated = true;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BorderRadius = 10;
            this.btnPrint.CheckedState.Parent = this.btnPrint;
            this.btnPrint.CustomImages.Parent = this.btnPrint;
            this.btnPrint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnPrint.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnPrint.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.HoverState.Parent = this.btnPrint;
            this.btnPrint.Image = global::PotpotMotorShopPOS.Properties.Resources.print;
            this.btnPrint.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPrint.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnPrint.ImageSize = new System.Drawing.Size(30, 30);
            this.btnPrint.Location = new System.Drawing.Point(1458, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShadowDecoration.BorderRadius = 15;
            this.btnPrint.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPrint.ShadowDecoration.Enabled = true;
            this.btnPrint.ShadowDecoration.Parent = this.btnPrint;
            this.btnPrint.Size = new System.Drawing.Size(175, 40);
            this.btnPrint.TabIndex = 137;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextOffset = new System.Drawing.Point(7, 0);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // OutofStocksReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "OutofStocksReportControl";
            this.Size = new System.Drawing.Size(1682, 884);
            this.Load += new System.EventHandler(this.OutofStocksReportControl_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OutOfStockDatagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategoryFilter;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView OutOfStockDatagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReOrderLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
    }
}
