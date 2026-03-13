namespace PotpotMotorShopPOS.Forms.Modules
{
    partial class ProductListManagement
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
            this.AddPructForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnBrowseImage = new Guna.UI2.WinForms.Guna2Button();
            this.picProductImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numReOrderLevel = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.cmbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.numQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numPrice = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtBarcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSaveProduct = new Guna.UI2.WinForms.Guna2Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProductName = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReOrderLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // AddPructForm
            // 
            this.AddPructForm.AnimateWindow = true;
            this.AddPructForm.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_POSITIVE;
            this.AddPructForm.BorderRadius = 20;
            this.AddPructForm.ContainerControl = this;
            this.AddPructForm.ResizeForm = false;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Animated = true;
            this.btnBrowseImage.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowseImage.BorderRadius = 10;
            this.btnBrowseImage.BorderThickness = 1;
            this.btnBrowseImage.CheckedState.Parent = this.btnBrowseImage;
            this.btnBrowseImage.CustomImages.Parent = this.btnBrowseImage;
            this.btnBrowseImage.FillColor = System.Drawing.Color.White;
            this.btnBrowseImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBrowseImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.btnBrowseImage.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnBrowseImage.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnBrowseImage.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseImage.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnBrowseImage.HoverState.Parent = this.btnBrowseImage;
            this.btnBrowseImage.Location = new System.Drawing.Point(262, 268);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.ShadowDecoration.BorderRadius = 15;
            this.btnBrowseImage.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBrowseImage.ShadowDecoration.Enabled = true;
            this.btnBrowseImage.ShadowDecoration.Parent = this.btnBrowseImage;
            this.btnBrowseImage.Size = new System.Drawing.Size(272, 52);
            this.btnBrowseImage.TabIndex = 108;
            this.btnBrowseImage.Text = "Insert image";
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // picProductImage
            // 
            this.picProductImage.BackColor = System.Drawing.Color.White;
            this.picProductImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picProductImage.BorderRadius = 20;
            this.picProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProductImage.FillColor = System.Drawing.Color.White;
            this.picProductImage.Location = new System.Drawing.Point(262, 70);
            this.picProductImage.Name = "picProductImage";
            this.picProductImage.ShadowDecoration.BorderRadius = 0;
            this.picProductImage.ShadowDecoration.Parent = this.picProductImage;
            this.picProductImage.Size = new System.Drawing.Size(272, 173);
            this.picProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProductImage.TabIndex = 107;
            this.picProductImage.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(21, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 31);
            this.label7.TabIndex = 103;
            this.label7.Text = "ADD PRODUCT ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
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
            this.btnClose.Location = new System.Drawing.Point(709, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(47, 43);
            this.btnClose.TabIndex = 119;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.label7);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(776, 55);
            this.guna2Panel1.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(207, 567);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 31);
            this.label3.TabIndex = 134;
            this.label3.Text = "Re-Order Level";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numReOrderLevel
            // 
            this.numReOrderLevel.BackColor = System.Drawing.Color.Transparent;
            this.numReOrderLevel.BorderColor = System.Drawing.Color.Black;
            this.numReOrderLevel.BorderRadius = 10;
            this.numReOrderLevel.BorderThickness = 2;
            this.numReOrderLevel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numReOrderLevel.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numReOrderLevel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numReOrderLevel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numReOrderLevel.DisabledState.Parent = this.numReOrderLevel;
            this.numReOrderLevel.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.numReOrderLevel.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.numReOrderLevel.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numReOrderLevel.FocusedState.Parent = this.numReOrderLevel;
            this.numReOrderLevel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numReOrderLevel.ForeColor = System.Drawing.Color.Black;
            this.numReOrderLevel.Location = new System.Drawing.Point(212, 606);
            this.numReOrderLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numReOrderLevel.Name = "numReOrderLevel";
            this.numReOrderLevel.ShadowDecoration.BorderRadius = 15;
            this.numReOrderLevel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.numReOrderLevel.ShadowDecoration.Parent = this.numReOrderLevel;
            this.numReOrderLevel.Size = new System.Drawing.Size(159, 51);
            this.numReOrderLevel.TabIndex = 133;
            this.numReOrderLevel.UpDownButtonFillColor = System.Drawing.Color.White;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(404, 458);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 31);
            this.label6.TabIndex = 130;
            this.label6.Text = "Product Category";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(405, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 31);
            this.label5.TabIndex = 129;
            this.label5.Text = "Product Quantity";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(38, 568);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 31);
            this.label4.TabIndex = 128;
            this.label4.Text = "Product Price";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(36, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 31);
            this.label2.TabIndex = 127;
            this.label2.Text = "Product Barcode";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(589, 605);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.BorderRadius = 15;
            this.btnCancel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCancel.ShadowDecoration.Enabled = true;
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(150, 52);
            this.btnCancel.TabIndex = 126;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.cmbCategory.Location = new System.Drawing.Point(406, 496);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.ShadowDecoration.BorderRadius = 15;
            this.cmbCategory.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbCategory.ShadowDecoration.Enabled = true;
            this.cmbCategory.ShadowDecoration.Parent = this.cmbCategory;
            this.cmbCategory.Size = new System.Drawing.Size(333, 51);
            this.cmbCategory.TabIndex = 125;
            // 
            // numQuantity
            // 
            this.numQuantity.BackColor = System.Drawing.Color.Transparent;
            this.numQuantity.BorderColor = System.Drawing.Color.Black;
            this.numQuantity.BorderRadius = 10;
            this.numQuantity.BorderThickness = 2;
            this.numQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numQuantity.DisabledState.Parent = this.numQuantity;
            this.numQuantity.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.numQuantity.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.numQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numQuantity.FocusedState.Parent = this.numQuantity;
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantity.ForeColor = System.Drawing.Color.Black;
            this.numQuantity.Location = new System.Drawing.Point(406, 390);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.ShadowDecoration.BorderRadius = 15;
            this.numQuantity.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.numQuantity.ShadowDecoration.Parent = this.numQuantity;
            this.numQuantity.Size = new System.Drawing.Size(333, 51);
            this.numQuantity.TabIndex = 124;
            this.numQuantity.UpDownButtonFillColor = System.Drawing.Color.White;
            this.numQuantity.UpDownButtonForeColor = System.Drawing.Color.Black;
            // 
            // numPrice
            // 
            this.numPrice.BackColor = System.Drawing.Color.Transparent;
            this.numPrice.BorderColor = System.Drawing.Color.Black;
            this.numPrice.BorderRadius = 10;
            this.numPrice.BorderThickness = 2;
            this.numPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numPrice.DisabledState.Parent = this.numPrice;
            this.numPrice.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.numPrice.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.numPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numPrice.FocusedState.Parent = this.numPrice;
            this.numPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrice.ForeColor = System.Drawing.Color.Black;
            this.numPrice.Location = new System.Drawing.Point(38, 606);
            this.numPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.ShadowDecoration.BorderRadius = 15;
            this.numPrice.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.numPrice.ShadowDecoration.Parent = this.numPrice;
            this.numPrice.Size = new System.Drawing.Size(159, 51);
            this.numPrice.TabIndex = 123;
            this.numPrice.UpDownButtonFillColor = System.Drawing.Color.White;
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
            this.txtBarcode.Location = new System.Drawing.Point(38, 496);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBarcode.MaxLength = 20;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.PasswordChar = '\0';
            this.txtBarcode.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtBarcode.PlaceholderText = "Scan Product barcode";
            this.txtBarcode.SelectedText = "";
            this.txtBarcode.ShadowDecoration.BorderRadius = 15;
            this.txtBarcode.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtBarcode.ShadowDecoration.Enabled = true;
            this.txtBarcode.ShadowDecoration.Parent = this.txtBarcode;
            this.txtBarcode.Size = new System.Drawing.Size(333, 51);
            this.txtBarcode.TabIndex = 122;
            this.txtBarcode.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Animated = true;
            this.btnSaveProduct.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnSaveProduct.BorderRadius = 10;
            this.btnSaveProduct.BorderThickness = 1;
            this.btnSaveProduct.CheckedState.Parent = this.btnSaveProduct;
            this.btnSaveProduct.CustomImages.Parent = this.btnSaveProduct;
            this.btnSaveProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnSaveProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveProduct.ForeColor = System.Drawing.Color.White;
            this.btnSaveProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSaveProduct.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSaveProduct.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProduct.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.btnSaveProduct.HoverState.Parent = this.btnSaveProduct;
            this.btnSaveProduct.Location = new System.Drawing.Point(406, 605);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.ShadowDecoration.BorderRadius = 15;
            this.btnSaveProduct.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSaveProduct.ShadowDecoration.Enabled = true;
            this.btnSaveProduct.ShadowDecoration.Parent = this.btnSaveProduct;
            this.btnSaveProduct.Size = new System.Drawing.Size(150, 52);
            this.btnSaveProduct.TabIndex = 121;
            this.btnSaveProduct.Text = "Save";
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(36, 352);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(164, 31);
            this.label13.TabIndex = 120;
            this.label13.Text = "Product Name";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtProductName.Location = new System.Drawing.Point(38, 390);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.PasswordChar = '\0';
            this.txtProductName.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtProductName.PlaceholderText = "Enter Product name";
            this.txtProductName.SelectedText = "";
            this.txtProductName.ShadowDecoration.BorderRadius = 15;
            this.txtProductName.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtProductName.ShadowDecoration.Enabled = true;
            this.txtProductName.ShadowDecoration.Parent = this.txtProductName;
            this.txtProductName.Size = new System.Drawing.Size(333, 51);
            this.txtProductName.TabIndex = 119;
            this.txtProductName.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // ProductListManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(776, 697);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numReOrderLevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.btnSaveProduct);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.picProductImage);
            this.Controls.Add(this.btnBrowseImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductListManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductListManagemnt";
            this.Load += new System.EventHandler(this.ProductListManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReOrderLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm AddPructForm;
        private Guna.UI2.WinForms.Guna2Button btnBrowseImage;
        private Guna.UI2.WinForms.Guna2PictureBox picProductImage;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2NumericUpDown numReOrderLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategory;
        private Guna.UI2.WinForms.Guna2NumericUpDown numQuantity;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtBarcode;
        private Guna.UI2.WinForms.Guna2Button btnSaveProduct;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox txtProductName;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}