namespace PotpotMotorShopPOS.Views.Management
{
    partial class ProductCategoryControl
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.PnlOne = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.BtnAddCategory = new Guna.UI2.WinForms.Guna2Button();
            this.CategoryDatagrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.PnlOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 60;
            this.guna2Elipse1.TargetControl = this;
            // 
            // PnlOne
            // 
            this.PnlOne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlOne.BackColor = System.Drawing.Color.Transparent;
            this.PnlOne.BorderRadius = 20;
            this.PnlOne.Controls.Add(this.BtnAddCategory);
            this.PnlOne.Controls.Add(this.CategoryDatagrid);
            this.PnlOne.FillColor = System.Drawing.Color.White;
            this.PnlOne.FillColor2 = System.Drawing.Color.White;
            this.PnlOne.Location = new System.Drawing.Point(20, 17);
            this.PnlOne.Name = "PnlOne";
            this.PnlOne.ShadowDecoration.BorderRadius = 25;
            this.PnlOne.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.PnlOne.ShadowDecoration.Enabled = true;
            this.PnlOne.ShadowDecoration.Parent = this.PnlOne;
            this.PnlOne.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.PnlOne.Size = new System.Drawing.Size(1645, 848);
            this.PnlOne.TabIndex = 26;
            this.PnlOne.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlOne_Paint);
            // 
            // BtnAddCategory
            // 
            this.BtnAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddCategory.Animated = true;
            this.BtnAddCategory.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddCategory.BorderRadius = 10;
            this.BtnAddCategory.CheckedState.Parent = this.BtnAddCategory;
            this.BtnAddCategory.CustomImages.Parent = this.BtnAddCategory;
            this.BtnAddCategory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.BtnAddCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnAddCategory.ForeColor = System.Drawing.Color.White;
            this.BtnAddCategory.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnAddCategory.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnAddCategory.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCategory.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnAddCategory.HoverState.Parent = this.BtnAddCategory;
            this.BtnAddCategory.Image = global::PotpotMotorShopPOS.Properties.Resources.Add70;
            this.BtnAddCategory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnAddCategory.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnAddCategory.ImageSize = new System.Drawing.Size(40, 40);
            this.BtnAddCategory.Location = new System.Drawing.Point(1380, 15);
            this.BtnAddCategory.Name = "BtnAddCategory";
            this.BtnAddCategory.ShadowDecoration.BorderRadius = 15;
            this.BtnAddCategory.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnAddCategory.ShadowDecoration.Enabled = true;
            this.BtnAddCategory.ShadowDecoration.Parent = this.BtnAddCategory;
            this.BtnAddCategory.Size = new System.Drawing.Size(240, 40);
            this.BtnAddCategory.TabIndex = 138;
            this.BtnAddCategory.Text = "Add Category";
            this.BtnAddCategory.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnAddCategory.Click += new System.EventHandler(this.BtnAddCategory_Click_1);
            // 
            // CategoryDatagrid
            // 
            this.CategoryDatagrid.AllowUserToAddRows = false;
            this.CategoryDatagrid.AllowUserToDeleteRows = false;
            this.CategoryDatagrid.AllowUserToResizeColumns = false;
            this.CategoryDatagrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.CategoryDatagrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.CategoryDatagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryDatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CategoryDatagrid.BackgroundColor = System.Drawing.Color.White;
            this.CategoryDatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CategoryDatagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.CategoryDatagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CategoryDatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CategoryDatagrid.ColumnHeadersHeight = 52;
            this.CategoryDatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryID,
            this.CategoryName,
            this.EditColumn,
            this.DeleteColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CategoryDatagrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.CategoryDatagrid.EnableHeadersVisualStyles = false;
            this.CategoryDatagrid.GridColor = System.Drawing.Color.White;
            this.CategoryDatagrid.Location = new System.Drawing.Point(20, 61);
            this.CategoryDatagrid.Name = "CategoryDatagrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CategoryDatagrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.CategoryDatagrid.RowHeadersVisible = false;
            this.CategoryDatagrid.RowHeadersWidth = 51;
            this.CategoryDatagrid.RowTemplate.Height = 24;
            this.CategoryDatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CategoryDatagrid.Size = new System.Drawing.Size(1600, 748);
            this.CategoryDatagrid.TabIndex = 122;
            this.CategoryDatagrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.CategoryDatagrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.CategoryDatagrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.CategoryDatagrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.CategoryDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.CategoryDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.CategoryDatagrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.CategoryDatagrid.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.CategoryDatagrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.CategoryDatagrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.CategoryDatagrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.CategoryDatagrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.CategoryDatagrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.CategoryDatagrid.ThemeStyle.HeaderStyle.Height = 52;
            this.CategoryDatagrid.ThemeStyle.ReadOnly = false;
            this.CategoryDatagrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.CategoryDatagrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.CategoryDatagrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.CategoryDatagrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.CategoryDatagrid.ThemeStyle.RowsStyle.Height = 24;
            this.CategoryDatagrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.CategoryDatagrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.CategoryDatagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CategoryDatagrid_CellContentClick_1);
            // 
            // CategoryID
            // 
            this.CategoryID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CategoryID.HeaderText = "ID";
            this.CategoryID.MinimumWidth = 6;
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.ReadOnly = true;
            this.CategoryID.Width = 57;
            // 
            // CategoryName
            // 
            this.CategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CategoryName.HeaderText = "CATEGORY NAME";
            this.CategoryName.MinimumWidth = 6;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
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
            // DeleteColumn
            // 
            this.DeleteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeleteColumn.DividerWidth = 2;
            this.DeleteColumn.HeaderText = "";
            this.DeleteColumn.Image = global::PotpotMotorShopPOS.Properties.Resources.delete40;
            this.DeleteColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DeleteColumn.MinimumWidth = 6;
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.ReadOnly = true;
            this.DeleteColumn.Width = 6;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
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
            this.dataGridViewImageColumn2.DividerWidth = 2;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::PotpotMotorShopPOS.Properties.Resources.icon_delete;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 125;
            // 
            // ProductCategoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlOne);
            this.Name = "ProductCategoryControl";
            this.Size = new System.Drawing.Size(1682, 884);
            this.PnlOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDatagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel PnlOne;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Guna.UI2.WinForms.Guna2DataGridView CategoryDatagrid;
        private Guna.UI2.WinForms.Guna2Button BtnAddCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewImageColumn DeleteColumn;
    }
}
