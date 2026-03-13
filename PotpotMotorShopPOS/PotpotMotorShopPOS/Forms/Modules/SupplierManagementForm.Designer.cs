namespace PotpotMotorShopPOS.Forms.Modules
{
    partial class SupplierManagementForm
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
            this.SupplierManagement = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.cmbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.txtSupplierName = new Guna.UI2.WinForms.Guna2TextBox();
            this.BtnAddSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtContactPerson = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContactNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbSupplierStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SupplierManagement
            // 
            this.SupplierManagement.AnimateWindow = true;
            this.SupplierManagement.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_POSITIVE;
            this.SupplierManagement.BorderRadius = 20;
            this.SupplierManagement.ContainerControl = this;
            this.SupplierManagement.ResizeForm = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 31);
            this.label6.TabIndex = 103;
            this.label6.Text = "SUPPLIER MODULE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel2.Controls.Add(this.btnClose);
            this.guna2Panel2.Controls.Add(this.label6);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(662, 62);
            this.guna2Panel2.TabIndex = 128;
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.HoverState.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = global::PotpotMotorShopPOS.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(603, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(47, 43);
            this.btnClose.TabIndex = 145;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Animated = true;
            this.cmbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cmbCategory.BorderColor = System.Drawing.Color.Black;
            this.cmbCategory.BorderRadius = 10;
            this.cmbCategory.BorderThickness = 2;
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCategory.FocusedState.Parent = this.cmbCategory;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbCategory.ForeColor = System.Drawing.Color.Black;
            this.cmbCategory.HoverState.Parent = this.cmbCategory;
            this.cmbCategory.ItemHeight = 45;
            this.cmbCategory.ItemsAppearance.Parent = this.cmbCategory;
            this.cmbCategory.Location = new System.Drawing.Point(350, 232);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.ShadowDecoration.BorderRadius = 15;
            this.cmbCategory.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbCategory.ShadowDecoration.Enabled = true;
            this.cmbCategory.ShadowDecoration.Parent = this.cmbCategory;
            this.cmbCategory.Size = new System.Drawing.Size(280, 51);
            this.cmbCategory.TabIndex = 142;
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.btnCancel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(499, 448);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.BorderRadius = 15;
            this.btnCancel.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.btnCancel.ShadowDecoration.Enabled = true;
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(131, 52);
            this.btnCancel.TabIndex = 141;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Animated = true;
            this.txtSupplierName.BackColor = System.Drawing.Color.Transparent;
            this.txtSupplierName.BorderColor = System.Drawing.Color.Black;
            this.txtSupplierName.BorderRadius = 10;
            this.txtSupplierName.BorderThickness = 2;
            this.txtSupplierName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSupplierName.DefaultText = "";
            this.txtSupplierName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSupplierName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSupplierName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSupplierName.DisabledState.Parent = this.txtSupplierName;
            this.txtSupplierName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSupplierName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSupplierName.FocusedState.Parent = this.txtSupplierName;
            this.txtSupplierName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSupplierName.ForeColor = System.Drawing.Color.Black;
            this.txtSupplierName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSupplierName.HoverState.Parent = this.txtSupplierName;
            this.txtSupplierName.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtSupplierName.Location = new System.Drawing.Point(35, 120);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSupplierName.MaxLength = 50;
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.PasswordChar = '\0';
            this.txtSupplierName.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtSupplierName.PlaceholderText = "Enter supplier name";
            this.txtSupplierName.SelectedText = "";
            this.txtSupplierName.ShadowDecoration.BorderRadius = 15;
            this.txtSupplierName.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtSupplierName.ShadowDecoration.Enabled = true;
            this.txtSupplierName.ShadowDecoration.Parent = this.txtSupplierName;
            this.txtSupplierName.Size = new System.Drawing.Size(280, 51);
            this.txtSupplierName.TabIndex = 129;
            this.txtSupplierName.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // BtnAddSupplier
            // 
            this.BtnAddSupplier.Animated = true;
            this.BtnAddSupplier.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddSupplier.BorderRadius = 10;
            this.BtnAddSupplier.BorderThickness = 2;
            this.BtnAddSupplier.CheckedState.Parent = this.BtnAddSupplier;
            this.BtnAddSupplier.CustomImages.Parent = this.BtnAddSupplier;
            this.BtnAddSupplier.FillColor = System.Drawing.Color.White;
            this.BtnAddSupplier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnAddSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.BtnAddSupplier.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnAddSupplier.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnAddSupplier.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddSupplier.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.BtnAddSupplier.HoverState.Parent = this.BtnAddSupplier;
            this.BtnAddSupplier.Location = new System.Drawing.Point(350, 448);
            this.BtnAddSupplier.Name = "BtnAddSupplier";
            this.BtnAddSupplier.ShadowDecoration.BorderRadius = 15;
            this.BtnAddSupplier.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.BtnAddSupplier.ShadowDecoration.Enabled = true;
            this.BtnAddSupplier.ShadowDecoration.Parent = this.BtnAddSupplier;
            this.BtnAddSupplier.Size = new System.Drawing.Size(131, 52);
            this.BtnAddSupplier.TabIndex = 140;
            this.BtnAddSupplier.Text = "Save";
            this.BtnAddSupplier.Click += new System.EventHandler(this.BtnAddSupplier_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(29, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 31);
            this.label13.TabIndex = 130;
            this.label13.Text = "Supplier Name";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtContactPerson.Location = new System.Drawing.Point(35, 232);
            this.txtContactPerson.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContactPerson.MaxLength = 20;
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.PasswordChar = '\0';
            this.txtContactPerson.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtContactPerson.PlaceholderText = "Enter contact person name";
            this.txtContactPerson.SelectedText = "";
            this.txtContactPerson.ShadowDecoration.BorderRadius = 15;
            this.txtContactPerson.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtContactPerson.ShadowDecoration.Enabled = true;
            this.txtContactPerson.ShadowDecoration.Parent = this.txtContactPerson;
            this.txtContactPerson.Size = new System.Drawing.Size(280, 51);
            this.txtContactPerson.TabIndex = 131;
            this.txtContactPerson.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(351, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 31);
            this.label7.TabIndex = 139;
            this.label7.Text = "Product Supply";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(29, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 31);
            this.label1.TabIndex = 132;
            this.label1.Text = "Contact Person Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(344, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 31);
            this.label4.TabIndex = 138;
            this.label4.Text = "Gmail";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Animated = true;
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
            this.txtAddress.Location = new System.Drawing.Point(35, 340);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtAddress.PlaceholderText = "Enter Address";
            this.txtAddress.SelectedText = "";
            this.txtAddress.ShadowDecoration.BorderRadius = 15;
            this.txtAddress.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtAddress.ShadowDecoration.Enabled = true;
            this.txtAddress.ShadowDecoration.Parent = this.txtAddress;
            this.txtAddress.Size = new System.Drawing.Size(280, 51);
            this.txtAddress.TabIndex = 133;
            this.txtAddress.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // txtEmail
            // 
            this.txtEmail.Animated = true;
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BorderColor = System.Drawing.Color.Black;
            this.txtEmail.BorderRadius = 10;
            this.txtEmail.BorderThickness = 2;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.Parent = this.txtEmail;
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.FocusedState.Parent = this.txtEmail;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.HoverState.Parent = this.txtEmail;
            this.txtEmail.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtEmail.Location = new System.Drawing.Point(350, 120);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.MaxLength = 30;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtEmail.PlaceholderText = "Enter gmail account";
            this.txtEmail.SelectedText = "";
            this.txtEmail.ShadowDecoration.BorderRadius = 15;
            this.txtEmail.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtEmail.ShadowDecoration.Enabled = true;
            this.txtEmail.ShadowDecoration.Parent = this.txtEmail;
            this.txtEmail.Size = new System.Drawing.Size(280, 51);
            this.txtEmail.TabIndex = 137;
            this.txtEmail.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(29, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 31);
            this.label2.TabIndex = 134;
            this.label2.Text = "Address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(29, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 31);
            this.label3.TabIndex = 136;
            this.label3.Text = "Contact Number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Animated = true;
            this.txtContactNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtContactNumber.BorderColor = System.Drawing.Color.Black;
            this.txtContactNumber.BorderRadius = 10;
            this.txtContactNumber.BorderThickness = 2;
            this.txtContactNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContactNumber.DefaultText = "";
            this.txtContactNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContactNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContactNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContactNumber.DisabledState.Parent = this.txtContactNumber;
            this.txtContactNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContactNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContactNumber.FocusedState.Parent = this.txtContactNumber;
            this.txtContactNumber.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtContactNumber.ForeColor = System.Drawing.Color.Black;
            this.txtContactNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContactNumber.HoverState.Parent = this.txtContactNumber;
            this.txtContactNumber.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtContactNumber.Location = new System.Drawing.Point(35, 449);
            this.txtContactNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContactNumber.MaxLength = 12;
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.PasswordChar = '\0';
            this.txtContactNumber.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtContactNumber.PlaceholderText = "Enter Contact Number";
            this.txtContactNumber.SelectedText = "";
            this.txtContactNumber.ShadowDecoration.BorderRadius = 15;
            this.txtContactNumber.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtContactNumber.ShadowDecoration.Enabled = true;
            this.txtContactNumber.ShadowDecoration.Parent = this.txtContactNumber;
            this.txtContactNumber.Size = new System.Drawing.Size(280, 51);
            this.txtContactNumber.TabIndex = 135;
            this.txtContactNumber.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // cmbSupplierStatus
            // 
            this.cmbSupplierStatus.Animated = true;
            this.cmbSupplierStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbSupplierStatus.BorderColor = System.Drawing.Color.Black;
            this.cmbSupplierStatus.BorderRadius = 10;
            this.cmbSupplierStatus.BorderThickness = 2;
            this.cmbSupplierStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSupplierStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplierStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSupplierStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSupplierStatus.FocusedState.Parent = this.cmbSupplierStatus;
            this.cmbSupplierStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbSupplierStatus.ForeColor = System.Drawing.Color.Black;
            this.cmbSupplierStatus.HoverState.Parent = this.cmbSupplierStatus;
            this.cmbSupplierStatus.ItemHeight = 45;
            this.cmbSupplierStatus.ItemsAppearance.Parent = this.cmbSupplierStatus;
            this.cmbSupplierStatus.Location = new System.Drawing.Point(350, 340);
            this.cmbSupplierStatus.Name = "cmbSupplierStatus";
            this.cmbSupplierStatus.ShadowDecoration.BorderRadius = 15;
            this.cmbSupplierStatus.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbSupplierStatus.ShadowDecoration.Enabled = true;
            this.cmbSupplierStatus.ShadowDecoration.Parent = this.cmbSupplierStatus;
            this.cmbSupplierStatus.Size = new System.Drawing.Size(280, 51);
            this.cmbSupplierStatus.TabIndex = 144;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(351, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 31);
            this.label5.TabIndex = 143;
            this.label5.Text = "Status";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SupplierManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 537);
            this.Controls.Add(this.cmbSupplierStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.BtnAddSupplier);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SupplierManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SupplierManagementForm";
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm SupplierManagement;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSupplierStatus;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategory;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2TextBox txtSupplierName;
        private Guna.UI2.WinForms.Guna2Button BtnAddSupplier;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox txtContactPerson;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtContactNumber;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
    }
}