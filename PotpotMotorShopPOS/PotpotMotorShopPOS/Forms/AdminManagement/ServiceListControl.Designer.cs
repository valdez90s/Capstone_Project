namespace PotpotMotorShopPOS.Views.Management
{
    partial class ServiceListControl
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
            this.PnlOne = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.ServicesListDatagrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.BtnAddServices = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.PnlOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesListDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlOne
            // 
            this.PnlOne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlOne.BackColor = System.Drawing.Color.Transparent;
            this.PnlOne.BorderRadius = 20;
            this.PnlOne.BorderThickness = 2;
            this.PnlOne.Controls.Add(this.ServicesListDatagrid);
            this.PnlOne.Controls.Add(this.BtnAddServices);
            this.PnlOne.FillColor = System.Drawing.Color.White;
            this.PnlOne.FillColor2 = System.Drawing.Color.White;
            this.PnlOne.Location = new System.Drawing.Point(14, 20);
            this.PnlOne.Name = "PnlOne";
            this.PnlOne.ShadowDecoration.BorderRadius = 25;
            this.PnlOne.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.PnlOne.ShadowDecoration.Enabled = true;
            this.PnlOne.ShadowDecoration.Parent = this.PnlOne;
            this.PnlOne.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.PnlOne.Size = new System.Drawing.Size(1652, 848);
            this.PnlOne.TabIndex = 30;
            this.PnlOne.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlOne_Paint);
            // 
            // ServicesListDatagrid
            // 
            this.ServicesListDatagrid.AllowUserToAddRows = false;
            this.ServicesListDatagrid.AllowUserToDeleteRows = false;
            this.ServicesListDatagrid.AllowUserToResizeColumns = false;
            this.ServicesListDatagrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.ServicesListDatagrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ServicesListDatagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServicesListDatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ServicesListDatagrid.BackgroundColor = System.Drawing.Color.White;
            this.ServicesListDatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServicesListDatagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ServicesListDatagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ServicesListDatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ServicesListDatagrid.ColumnHeadersHeight = 52;
            this.ServicesListDatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceID,
            this.ServiceName,
            this.ServicePrice,
            this.EditColumn,
            this.DeleteColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ServicesListDatagrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.ServicesListDatagrid.EnableHeadersVisualStyles = false;
            this.ServicesListDatagrid.GridColor = System.Drawing.Color.White;
            this.ServicesListDatagrid.Location = new System.Drawing.Point(21, 61);
            this.ServicesListDatagrid.Name = "ServicesListDatagrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ServicesListDatagrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ServicesListDatagrid.RowHeadersVisible = false;
            this.ServicesListDatagrid.RowHeadersWidth = 51;
            this.ServicesListDatagrid.RowTemplate.Height = 24;
            this.ServicesListDatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServicesListDatagrid.Size = new System.Drawing.Size(1605, 752);
            this.ServicesListDatagrid.TabIndex = 123;
            this.ServicesListDatagrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.ServicesListDatagrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.ServicesListDatagrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.ServicesListDatagrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.ServicesListDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.ServicesListDatagrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.ServicesListDatagrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.ServicesListDatagrid.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.ServicesListDatagrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.ServicesListDatagrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ServicesListDatagrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.ServicesListDatagrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.ServicesListDatagrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ServicesListDatagrid.ThemeStyle.HeaderStyle.Height = 52;
            this.ServicesListDatagrid.ThemeStyle.ReadOnly = false;
            this.ServicesListDatagrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.ServicesListDatagrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ServicesListDatagrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.ServicesListDatagrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ServicesListDatagrid.ThemeStyle.RowsStyle.Height = 24;
            this.ServicesListDatagrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ServicesListDatagrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ServicesListDatagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServicesListDatagrid_CellContentClick);
            // 
            // ServiceID
            // 
            this.ServiceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ServiceID.HeaderText = "ID";
            this.ServiceID.MinimumWidth = 6;
            this.ServiceID.Name = "ServiceID";
            this.ServiceID.ReadOnly = true;
            this.ServiceID.Width = 57;
            // 
            // ServiceName
            // 
            this.ServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServiceName.HeaderText = "SERVICE NAME";
            this.ServiceName.MinimumWidth = 6;
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.ReadOnly = true;
            // 
            // ServicePrice
            // 
            this.ServicePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServicePrice.HeaderText = "PRICE";
            this.ServicePrice.MinimumWidth = 6;
            this.ServicePrice.Name = "ServicePrice";
            this.ServicePrice.ReadOnly = true;
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
            // BtnAddServices
            // 
            this.BtnAddServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddServices.Animated = true;
            this.BtnAddServices.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddServices.BorderRadius = 10;
            this.BtnAddServices.CheckedState.Parent = this.BtnAddServices;
            this.BtnAddServices.CustomImages.Parent = this.BtnAddServices;
            this.BtnAddServices.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.BtnAddServices.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnAddServices.ForeColor = System.Drawing.Color.White;
            this.BtnAddServices.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnAddServices.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnAddServices.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddServices.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnAddServices.HoverState.Parent = this.BtnAddServices;
            this.BtnAddServices.Image = global::PotpotMotorShopPOS.Properties.Resources.Add70;
            this.BtnAddServices.ImageSize = new System.Drawing.Size(40, 40);
            this.BtnAddServices.Location = new System.Drawing.Point(1420, 15);
            this.BtnAddServices.Name = "BtnAddServices";
            this.BtnAddServices.ShadowDecoration.BorderRadius = 15;
            this.BtnAddServices.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnAddServices.ShadowDecoration.Enabled = true;
            this.BtnAddServices.ShadowDecoration.Parent = this.BtnAddServices;
            this.BtnAddServices.Size = new System.Drawing.Size(206, 40);
            this.BtnAddServices.TabIndex = 41;
            this.BtnAddServices.Text = "Add Services";
            this.BtnAddServices.Click += new System.EventHandler(this.BtnAddServices_Click);
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
            // ServiceListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlOne);
            this.Name = "ServiceListControl";
            this.Size = new System.Drawing.Size(1682, 884);
            this.PnlOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServicesListDatagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientPanel PnlOne;
        private Guna.UI2.WinForms.Guna2Button BtnAddServices;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Guna.UI2.WinForms.Guna2DataGridView ServicesListDatagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicePrice;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewImageColumn DeleteColumn;
    }
}
