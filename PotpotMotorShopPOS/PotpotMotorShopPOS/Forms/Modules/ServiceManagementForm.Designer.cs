namespace PotpotMotorShopPOS.Forms.Modules
{
    partial class ServiceManagementForm
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
            this.ServiceModule = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.label13 = new System.Windows.Forms.Label();
            this.txtServiceName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.numPrice = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.BtnAddService = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // ServiceModule
            // 
            this.ServiceModule.AnimateWindow = true;
            this.ServiceModule.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_POSITIVE;
            this.ServiceModule.BorderRadius = 20;
            this.ServiceModule.ContainerControl = this;
            this.ServiceModule.ResizeForm = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(21, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 31);
            this.label6.TabIndex = 104;
            this.label6.Text = "ADD SERVICE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnClose.Location = new System.Drawing.Point(523, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(47, 43);
            this.btnClose.TabIndex = 129;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(21, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(158, 31);
            this.label13.TabIndex = 114;
            this.label13.Text = "Service Name";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtServiceName
            // 
            this.txtServiceName.Animated = true;
            this.txtServiceName.BackColor = System.Drawing.Color.Transparent;
            this.txtServiceName.BorderColor = System.Drawing.Color.Black;
            this.txtServiceName.BorderRadius = 10;
            this.txtServiceName.BorderThickness = 2;
            this.txtServiceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServiceName.DefaultText = "";
            this.txtServiceName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtServiceName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtServiceName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtServiceName.DisabledState.Parent = this.txtServiceName;
            this.txtServiceName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtServiceName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtServiceName.FocusedState.Parent = this.txtServiceName;
            this.txtServiceName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtServiceName.ForeColor = System.Drawing.Color.Black;
            this.txtServiceName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtServiceName.HoverState.Parent = this.txtServiceName;
            this.txtServiceName.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtServiceName.Location = new System.Drawing.Point(27, 131);
            this.txtServiceName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtServiceName.MaxLength = 50;
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.PasswordChar = '\0';
            this.txtServiceName.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtServiceName.PlaceholderText = "Enter service name";
            this.txtServiceName.SelectedText = "";
            this.txtServiceName.ShadowDecoration.BorderRadius = 15;
            this.txtServiceName.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtServiceName.ShadowDecoration.Enabled = true;
            this.txtServiceName.ShadowDecoration.Parent = this.txtServiceName;
            this.txtServiceName.Size = new System.Drawing.Size(367, 51);
            this.txtServiceName.TabIndex = 113;
            this.txtServiceName.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.btnClose);
            this.guna2GradientPanel1.Controls.Add(this.label6);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(590, 60);
            this.guna2GradientPanel1.TabIndex = 128;
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
            this.numPrice.Location = new System.Drawing.Point(418, 131);
            this.numPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numPrice.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.ShadowDecoration.BorderRadius = 15;
            this.numPrice.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.numPrice.ShadowDecoration.Parent = this.numPrice;
            this.numPrice.Size = new System.Drawing.Size(152, 51);
            this.numPrice.TabIndex = 132;
            this.numPrice.UpDownButtonFillColor = System.Drawing.Color.White;
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.Empty;
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
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(307, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.BorderRadius = 15;
            this.btnCancel.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.btnCancel.ShadowDecoration.Enabled = true;
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(170, 52);
            this.btnCancel.TabIndex = 131;
            this.btnCancel.Text = "Cancel";
            // 
            // BtnAddService
            // 
            this.BtnAddService.Animated = true;
            this.BtnAddService.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddService.BorderColor = System.Drawing.Color.Empty;
            this.BtnAddService.BorderRadius = 10;
            this.BtnAddService.BorderThickness = 1;
            this.BtnAddService.CheckedState.Parent = this.BtnAddService;
            this.BtnAddService.CustomImages.Parent = this.BtnAddService;
            this.BtnAddService.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.BtnAddService.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnAddService.ForeColor = System.Drawing.Color.White;
            this.BtnAddService.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnAddService.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnAddService.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddService.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.BtnAddService.HoverState.Parent = this.BtnAddService;
            this.BtnAddService.Location = new System.Drawing.Point(110, 231);
            this.BtnAddService.Name = "BtnAddService";
            this.BtnAddService.ShadowDecoration.BorderRadius = 15;
            this.BtnAddService.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.BtnAddService.ShadowDecoration.Enabled = true;
            this.BtnAddService.ShadowDecoration.Parent = this.BtnAddService;
            this.BtnAddService.Size = new System.Drawing.Size(170, 52);
            this.BtnAddService.TabIndex = 130;
            this.BtnAddService.Text = "Save";
            this.BtnAddService.Click += new System.EventHandler(this.BtnAddService_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(412, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 31);
            this.label2.TabIndex = 129;
            this.label2.Text = "Price";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ServiceManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(590, 316);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnAddService);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.txtServiceName);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServiceManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServiceManagementForm";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm ServiceModule;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private Guna.UI2.WinForms.Guna2TextBox txtServiceName;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPrice;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button BtnAddService;
        private System.Windows.Forms.Label label2;
    }
}