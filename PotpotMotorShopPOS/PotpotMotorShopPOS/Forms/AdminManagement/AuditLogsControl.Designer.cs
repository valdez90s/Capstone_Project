namespace PotpotMotorShopPOS.Forms.AdminManagement
{
    partial class AuditLogsControl
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
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.cmbTable = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cmbAction = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.cmbUser = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAuditLogs = new Guna.UI2.WinForms.Guna2DataGridView();
            this.LOGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GradientPanel5.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel5
            // 
            this.guna2GradientPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel5.BorderRadius = 20;
            this.guna2GradientPanel5.Controls.Add(this.lblRecordCount);
            this.guna2GradientPanel5.Controls.Add(this.btnReset);
            this.guna2GradientPanel5.Controls.Add(this.btnFilter);
            this.guna2GradientPanel5.Controls.Add(this.btnExport);
            this.guna2GradientPanel5.Controls.Add(this.txtSearch);
            this.guna2GradientPanel5.Controls.Add(this.label4);
            this.guna2GradientPanel5.Controls.Add(this.dtpFrom);
            this.guna2GradientPanel5.Controls.Add(this.dtpTo);
            this.guna2GradientPanel5.Controls.Add(this.guna2Panel3);
            this.guna2GradientPanel5.Controls.Add(this.guna2Panel1);
            this.guna2GradientPanel5.Controls.Add(this.guna2Panel2);
            this.guna2GradientPanel5.Controls.Add(this.dgvAuditLogs);
            this.guna2GradientPanel5.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel5.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel5.Location = new System.Drawing.Point(18, 18);
            this.guna2GradientPanel5.Name = "guna2GradientPanel5";
            this.guna2GradientPanel5.ShadowDecoration.BorderRadius = 25;
            this.guna2GradientPanel5.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel5.ShadowDecoration.Depth = 35;
            this.guna2GradientPanel5.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel5.ShadowDecoration.Parent = this.guna2GradientPanel5;
            this.guna2GradientPanel5.Size = new System.Drawing.Size(1394, 867);
            this.guna2GradientPanel5.TabIndex = 11;
            this.guna2GradientPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel5_Paint);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRecordCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(27, 140);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(460, 38);
            this.lblRecordCount.TabIndex = 154;
            this.lblRecordCount.Text = "TOTAL RECORD:";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Animated = true;
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.BorderRadius = 10;
            this.btnReset.CheckedState.Parent = this.btnReset;
            this.btnReset.CustomImages.Parent = this.btnReset;
            this.btnReset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnReset.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnReset.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnReset.HoverState.Parent = this.btnReset;
            this.btnReset.Image = global::PotpotMotorShopPOS.Properties.Resources.reload;
            this.btnReset.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReset.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnReset.ImageSize = new System.Drawing.Size(30, 30);
            this.btnReset.Location = new System.Drawing.Point(1000, 80);
            this.btnReset.Name = "btnReset";
            this.btnReset.ShadowDecoration.BorderRadius = 15;
            this.btnReset.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnReset.ShadowDecoration.Enabled = true;
            this.btnReset.ShadowDecoration.Parent = this.btnReset;
            this.btnReset.Size = new System.Drawing.Size(175, 40);
            this.btnReset.TabIndex = 153;
            this.btnReset.Text = "Reset";
            this.btnReset.TextOffset = new System.Drawing.Point(7, 0);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Animated = true;
            this.btnFilter.BackColor = System.Drawing.Color.Transparent;
            this.btnFilter.BorderRadius = 10;
            this.btnFilter.CheckedState.Parent = this.btnFilter;
            this.btnFilter.CustomImages.Parent = this.btnFilter;
            this.btnFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnFilter.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnFilter.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnFilter.HoverState.Parent = this.btnFilter;
            this.btnFilter.Image = global::PotpotMotorShopPOS.Properties.Resources.Filtered;
            this.btnFilter.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFilter.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnFilter.ImageSize = new System.Drawing.Size(30, 30);
            this.btnFilter.Location = new System.Drawing.Point(1000, 32);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.ShadowDecoration.BorderRadius = 15;
            this.btnFilter.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFilter.ShadowDecoration.Enabled = true;
            this.btnFilter.ShadowDecoration.Parent = this.btnFilter;
            this.btnFilter.Size = new System.Drawing.Size(175, 40);
            this.btnFilter.TabIndex = 152;
            this.btnFilter.Text = "Filter";
            this.btnFilter.TextOffset = new System.Drawing.Point(7, 0);
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Animated = true;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BorderRadius = 10;
            this.btnExport.CheckedState.Parent = this.btnExport;
            this.btnExport.CustomImages.Parent = this.btnExport;
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnExport.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnExport.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnExport.HoverState.Parent = this.btnExport;
            this.btnExport.Image = global::PotpotMotorShopPOS.Properties.Resources.export70;
            this.btnExport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExport.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnExport.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExport.Location = new System.Drawing.Point(1198, 32);
            this.btnExport.Name = "btnExport";
            this.btnExport.ShadowDecoration.BorderRadius = 15;
            this.btnExport.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnExport.ShadowDecoration.Enabled = true;
            this.btnExport.ShadowDecoration.Parent = this.btnExport;
            this.btnExport.Size = new System.Drawing.Size(174, 40);
            this.btnExport.TabIndex = 150;
            this.btnExport.Text = "Export";
            this.btnExport.TextOffset = new System.Drawing.Point(10, 0);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.txtSearch.Location = new System.Drawing.Point(494, 140);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtSearch.PlaceholderText = "Search";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 20;
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(878, 38);
            this.txtSearch.TabIndex = 149;
            this.txtSearch.TextOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(384, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 38);
            this.label4.TabIndex = 148;
            this.label4.Text = "Filter By:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Animated = true;
            this.dtpFrom.BorderRadius = 10;
            this.dtpFrom.CheckedState.Parent = this.dtpFrom;
            this.dtpFrom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.dtpFrom.ForeColor = System.Drawing.Color.White;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.HoverState.Parent = this.dtpFrom;
            this.dtpFrom.Location = new System.Drawing.Point(494, 23);
            this.dtpFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShadowDecoration.Parent = this.dtpFrom;
            this.dtpFrom.Size = new System.Drawing.Size(200, 39);
            this.dtpFrom.TabIndex = 146;
            this.dtpFrom.Value = new System.DateTime(2025, 10, 23, 0, 0, 0, 0);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Animated = true;
            this.dtpTo.BorderRadius = 10;
            this.dtpTo.CheckedState.Parent = this.dtpTo;
            this.dtpTo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.dtpTo.ForeColor = System.Drawing.Color.White;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.HoverState.Parent = this.dtpTo;
            this.dtpTo.Location = new System.Drawing.Point(710, 24);
            this.dtpTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShadowDecoration.Parent = this.dtpTo;
            this.dtpTo.Size = new System.Drawing.Size(200, 39);
            this.dtpTo.TabIndex = 147;
            this.dtpTo.Value = new System.DateTime(2025, 10, 23, 18, 47, 32, 0);
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel3.BorderRadius = 10;
            this.guna2Panel3.BorderThickness = 1;
            this.guna2Panel3.Controls.Add(this.cmbTable);
            this.guna2Panel3.Controls.Add(this.label3);
            this.guna2Panel3.FillColor = System.Drawing.Color.White;
            this.guna2Panel3.Location = new System.Drawing.Point(27, 77);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(307, 38);
            this.guna2Panel3.TabIndex = 144;
            // 
            // cmbTable
            // 
            this.cmbTable.Animated = true;
            this.cmbTable.BackColor = System.Drawing.Color.White;
            this.cmbTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.cmbTable.BorderThickness = 0;
            this.cmbTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbTable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.cmbTable.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTable.FocusedState.Parent = this.cmbTable;
            this.cmbTable.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbTable.ForeColor = System.Drawing.Color.White;
            this.cmbTable.HoverState.Parent = this.cmbTable;
            this.cmbTable.ItemHeight = 42;
            this.cmbTable.ItemsAppearance.Parent = this.cmbTable;
            this.cmbTable.Location = new System.Drawing.Point(104, 0);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.cmbTable.ShadowDecoration.Enabled = true;
            this.cmbTable.ShadowDecoration.Parent = this.cmbTable;
            this.cmbTable.Size = new System.Drawing.Size(203, 48);
            this.cmbTable.TabIndex = 44;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 38);
            this.label3.TabIndex = 0;
            this.label3.Text = "Filter By:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.cmbAction);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(389, 80);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(521, 38);
            this.guna2Panel1.TabIndex = 143;
            // 
            // cmbAction
            // 
            this.cmbAction.Animated = true;
            this.cmbAction.BackColor = System.Drawing.Color.White;
            this.cmbAction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.cmbAction.BorderThickness = 0;
            this.cmbAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.cmbAction.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAction.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAction.FocusedState.Parent = this.cmbAction;
            this.cmbAction.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbAction.ForeColor = System.Drawing.Color.White;
            this.cmbAction.HoverState.Parent = this.cmbAction;
            this.cmbAction.ItemHeight = 42;
            this.cmbAction.ItemsAppearance.Parent = this.cmbAction;
            this.cmbAction.Location = new System.Drawing.Point(105, 0);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.cmbAction.ShadowDecoration.Enabled = true;
            this.cmbAction.ShadowDecoration.Parent = this.cmbAction;
            this.cmbAction.Size = new System.Drawing.Size(416, 48);
            this.cmbAction.TabIndex = 44;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filter By:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.cmbUser);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(27, 23);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(307, 38);
            this.guna2Panel2.TabIndex = 142;
            // 
            // cmbUser
            // 
            this.cmbUser.Animated = true;
            this.cmbUser.BackColor = System.Drawing.Color.White;
            this.cmbUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.cmbUser.BorderThickness = 0;
            this.cmbUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.cmbUser.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbUser.FocusedState.Parent = this.cmbUser;
            this.cmbUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbUser.ForeColor = System.Drawing.Color.White;
            this.cmbUser.HoverState.Parent = this.cmbUser;
            this.cmbUser.ItemHeight = 42;
            this.cmbUser.ItemsAppearance.Parent = this.cmbUser;
            this.cmbUser.Location = new System.Drawing.Point(104, 0);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.cmbUser.ShadowDecoration.Enabled = true;
            this.cmbUser.ShadowDecoration.Parent = this.cmbUser;
            this.cmbUser.Size = new System.Drawing.Size(203, 48);
            this.cmbUser.TabIndex = 44;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
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
            // dgvAuditLogs
            // 
            this.dgvAuditLogs.AllowUserToAddRows = false;
            this.dgvAuditLogs.AllowUserToDeleteRows = false;
            this.dgvAuditLogs.AllowUserToResizeColumns = false;
            this.dgvAuditLogs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvAuditLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAuditLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuditLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuditLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvAuditLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAuditLogs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAuditLogs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAuditLogs.ColumnHeadersHeight = 52;
            this.dgvAuditLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LOGID,
            this.UserID,
            this.Username,
            this.Action,
            this.TableName,
            this.RecordID,
            this.Description,
            this.Timestamp,
            this.IPAddress,
            this.DeviceInfo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAuditLogs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAuditLogs.EnableHeadersVisualStyles = false;
            this.dgvAuditLogs.GridColor = System.Drawing.Color.White;
            this.dgvAuditLogs.Location = new System.Drawing.Point(27, 185);
            this.dgvAuditLogs.Name = "dgvAuditLogs";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditLogs.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAuditLogs.RowHeadersVisible = false;
            this.dgvAuditLogs.RowHeadersWidth = 51;
            this.dgvAuditLogs.RowTemplate.Height = 24;
            this.dgvAuditLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditLogs.Size = new System.Drawing.Size(1345, 616);
            this.dgvAuditLogs.TabIndex = 141;
            this.dgvAuditLogs.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvAuditLogs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAuditLogs.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvAuditLogs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvAuditLogs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvAuditLogs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvAuditLogs.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvAuditLogs.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dgvAuditLogs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvAuditLogs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAuditLogs.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvAuditLogs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAuditLogs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvAuditLogs.ThemeStyle.HeaderStyle.Height = 52;
            this.dgvAuditLogs.ThemeStyle.ReadOnly = false;
            this.dgvAuditLogs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAuditLogs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAuditLogs.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvAuditLogs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvAuditLogs.ThemeStyle.RowsStyle.Height = 24;
            this.dgvAuditLogs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAuditLogs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvAuditLogs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuditLogs_CellDoubleClick);
            // 
            // LOGID
            // 
            this.LOGID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LOGID.HeaderText = "Log_ID";
            this.LOGID.MinimumWidth = 6;
            this.LOGID.Name = "LOGID";
            this.LOGID.ReadOnly = true;
            this.LOGID.Width = 94;
            // 
            // UserID
            // 
            this.UserID.HeaderText = "User_ID";
            this.UserID.MinimumWidth = 6;
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Username.HeaderText = "Username";
            this.Username.MinimumWidth = 6;
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Width = 118;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // TableName
            // 
            this.TableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TableName.HeaderText = "TableName";
            this.TableName.MinimumWidth = 6;
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            // 
            // RecordID
            // 
            this.RecordID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RecordID.HeaderText = "RecordID";
            this.RecordID.MinimumWidth = 6;
            this.RecordID.Name = "RecordID";
            this.RecordID.ReadOnly = true;
            this.RecordID.Width = 112;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Timestamp
            // 
            this.Timestamp.HeaderText = "Timestamp";
            this.Timestamp.MinimumWidth = 6;
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.ReadOnly = true;
            // 
            // IPAddress
            // 
            this.IPAddress.HeaderText = "IPAddress";
            this.IPAddress.MinimumWidth = 6;
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.ReadOnly = true;
            // 
            // DeviceInfo
            // 
            this.DeviceInfo.HeaderText = "DeviceInfo";
            this.DeviceInfo.MinimumWidth = 6;
            this.DeviceInfo.Name = "DeviceInfo";
            this.DeviceInfo.ReadOnly = true;
            // 
            // AuditLogsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2GradientPanel5);
            this.Name = "AuditLogsControl";
            this.Size = new System.Drawing.Size(1430, 903);
            this.Load += new System.EventHandler(this.AuditLogsControl_Load);
            this.guna2GradientPanel5.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel5;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAuditLogs;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTable;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAction;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceInfo;
    }
}
