namespace PotpotMotorShopPOS.Views.Management
{
    partial class Supplier_Control
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
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.SupplierListDatagrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.BtnAddSupplier = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierListDatagrid)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::PotpotMotorShopPOS.Properties.Resources.icon_edit;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
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
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txtSearch.Location = new System.Drawing.Point(609, 15);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtSearch.PlaceholderText = "Search";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 20;
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(523, 38);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // SupplierListDatagrid
            // 
            this.SupplierListDatagrid.AllowUserToAddRows = false;
            this.SupplierListDatagrid.AllowUserToDeleteRows = false;
            this.SupplierListDatagrid.AllowUserToResizeColumns = false;
            this.SupplierListDatagrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.SupplierListDatagrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.SupplierListDatagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierListDatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierListDatagrid.BackgroundColor = System.Drawing.Color.White;
            this.SupplierListDatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SupplierListDatagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.SupplierListDatagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SupplierListDatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SupplierListDatagrid.ColumnHeadersHeight = 52;
            this.SupplierListDatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupplierID,
            this.SupplierName,
            this.ContactPerson,
            this.SupplierAddress,
            this.SupplierContactNumber,
            this.SupplierEmail,
            this.SupplierCategory,
            this.SupplierStatus,
            this.EditColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SupplierListDatagrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.SupplierListDatagrid.EnableHeadersVisualStyles = false;
            this.SupplierListDatagrid.GridColor = System.Drawing.Color.White;
            this.SupplierListDatagrid.Location = new System.Drawing.Point(26, 61);
            this.SupplierListDatagrid.Name = "SupplierListDatagrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SupplierListDatagrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.SupplierListDatagrid.RowHeadersVisible = false;
            this.SupplierListDatagrid.RowHeadersWidth = 51;
            this.SupplierListDatagrid.RowTemplate.Height = 24;
            this.SupplierListDatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SupplierListDatagrid.Size = new System.Drawing.Size(1340, 751);
            this.SupplierListDatagrid.TabIndex = 142;
            this.SupplierListDatagrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.SupplierListDatagrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.SupplierListDatagrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.SupplierListDatagrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.SupplierListDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.SupplierListDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.SupplierListDatagrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.SupplierListDatagrid.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.SupplierListDatagrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.SupplierListDatagrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SupplierListDatagrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.SupplierListDatagrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.SupplierListDatagrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.SupplierListDatagrid.ThemeStyle.HeaderStyle.Height = 52;
            this.SupplierListDatagrid.ThemeStyle.ReadOnly = false;
            this.SupplierListDatagrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.SupplierListDatagrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.SupplierListDatagrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.SupplierListDatagrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.SupplierListDatagrid.ThemeStyle.RowsStyle.Height = 24;
            this.SupplierListDatagrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.SupplierListDatagrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.SupplierListDatagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplierListDatagrid_CellContentClick_1);
            this.SupplierListDatagrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.SupplierListDatagrid_CellFormatting);
            // 
            // SupplierID
            // 
            this.SupplierID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SupplierID.HeaderText = "ID";
            this.SupplierID.MinimumWidth = 6;
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.ReadOnly = true;
            this.SupplierID.Width = 57;
            // 
            // SupplierName
            // 
            this.SupplierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SupplierName.HeaderText = "Name";
            this.SupplierName.MinimumWidth = 6;
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            // 
            // ContactPerson
            // 
            this.ContactPerson.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ContactPerson.HeaderText = "ContactPerson";
            this.ContactPerson.MinimumWidth = 6;
            this.ContactPerson.Name = "ContactPerson";
            this.ContactPerson.ReadOnly = true;
            // 
            // SupplierAddress
            // 
            this.SupplierAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SupplierAddress.HeaderText = "Address";
            this.SupplierAddress.MinimumWidth = 6;
            this.SupplierAddress.Name = "SupplierAddress";
            this.SupplierAddress.ReadOnly = true;
            // 
            // SupplierContactNumber
            // 
            this.SupplierContactNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SupplierContactNumber.HeaderText = "ContactNo.";
            this.SupplierContactNumber.MinimumWidth = 6;
            this.SupplierContactNumber.Name = "SupplierContactNumber";
            this.SupplierContactNumber.ReadOnly = true;
            // 
            // SupplierEmail
            // 
            this.SupplierEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SupplierEmail.HeaderText = "Email";
            this.SupplierEmail.MinimumWidth = 6;
            this.SupplierEmail.Name = "SupplierEmail";
            this.SupplierEmail.ReadOnly = true;
            // 
            // SupplierCategory
            // 
            this.SupplierCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SupplierCategory.HeaderText = "Products";
            this.SupplierCategory.MinimumWidth = 6;
            this.SupplierCategory.Name = "SupplierCategory";
            this.SupplierCategory.ReadOnly = true;
            // 
            // SupplierStatus
            // 
            this.SupplierStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SupplierStatus.DataPropertyName = "SupplierStatus";
            this.SupplierStatus.HeaderText = "Status";
            this.SupplierStatus.MinimumWidth = 6;
            this.SupplierStatus.Name = "SupplierStatus";
            this.SupplierStatus.ReadOnly = true;
            this.SupplierStatus.Width = 87;
            // 
            // EditColumn
            // 
            this.EditColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::PotpotMotorShopPOS.Properties.Resources.icons8_edit_40;
            this.EditColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EditColumn.MinimumWidth = 6;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            this.EditColumn.Width = 6;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.BtnAddSupplier);
            this.guna2GradientPanel1.Controls.Add(this.SupplierListDatagrid);
            this.guna2GradientPanel1.Controls.Add(this.txtSearch);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(21, 14);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.BorderRadius = 25;
            this.guna2GradientPanel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1391, 871);
            this.guna2GradientPanel1.TabIndex = 30;
            this.guna2GradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel1_Paint);
            // 
            // BtnAddSupplier
            // 
            this.BtnAddSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddSupplier.Animated = true;
            this.BtnAddSupplier.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddSupplier.BorderRadius = 10;
            this.BtnAddSupplier.CheckedState.Parent = this.BtnAddSupplier;
            this.BtnAddSupplier.CustomImages.Parent = this.BtnAddSupplier;
            this.BtnAddSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.BtnAddSupplier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnAddSupplier.ForeColor = System.Drawing.Color.White;
            this.BtnAddSupplier.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnAddSupplier.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnAddSupplier.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddSupplier.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnAddSupplier.HoverState.Parent = this.BtnAddSupplier;
            this.BtnAddSupplier.Location = new System.Drawing.Point(1139, 15);
            this.BtnAddSupplier.Name = "BtnAddSupplier";
            this.BtnAddSupplier.ShadowDecoration.BorderRadius = 15;
            this.BtnAddSupplier.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnAddSupplier.ShadowDecoration.Enabled = true;
            this.BtnAddSupplier.ShadowDecoration.Parent = this.BtnAddSupplier;
            this.BtnAddSupplier.Size = new System.Drawing.Size(227, 40);
            this.BtnAddSupplier.TabIndex = 41;
            this.BtnAddSupplier.Text = "Add Supplier";
            this.BtnAddSupplier.Click += new System.EventHandler(this.BtnAddSupplier_Click);
            // 
            // Supplier_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "Supplier_Control";
            this.Size = new System.Drawing.Size(1430, 903);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierListDatagrid)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView SupplierListDatagrid;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button BtnAddSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierStatus;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
    }
}
