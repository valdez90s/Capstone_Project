namespace PotpotMotorShopPOS.Forms.Modules
{
    partial class CategoryManagementForm
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
            this.BtnSaveCategory = new Guna.UI2.WinForms.Guna2Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCategory = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.CategoryForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSaveCategory
            // 
            this.BtnSaveCategory.Animated = true;
            this.BtnSaveCategory.BackColor = System.Drawing.Color.Transparent;
            this.BtnSaveCategory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.BtnSaveCategory.BorderRadius = 10;
            this.BtnSaveCategory.BorderThickness = 1;
            this.BtnSaveCategory.CheckedState.Parent = this.BtnSaveCategory;
            this.BtnSaveCategory.CustomImages.Parent = this.BtnSaveCategory;
            this.BtnSaveCategory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.BtnSaveCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnSaveCategory.ForeColor = System.Drawing.Color.White;
            this.BtnSaveCategory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnSaveCategory.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnSaveCategory.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveCategory.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.BtnSaveCategory.HoverState.Parent = this.BtnSaveCategory;
            this.BtnSaveCategory.Location = new System.Drawing.Point(479, 120);
            this.BtnSaveCategory.Name = "BtnSaveCategory";
            this.BtnSaveCategory.ShadowDecoration.BorderRadius = 15;
            this.BtnSaveCategory.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnSaveCategory.ShadowDecoration.Enabled = true;
            this.BtnSaveCategory.ShadowDecoration.Parent = this.BtnSaveCategory;
            this.BtnSaveCategory.Size = new System.Drawing.Size(181, 52);
            this.BtnSaveCategory.TabIndex = 102;
            this.BtnSaveCategory.Text = "SAVE";
            this.BtnSaveCategory.Click += new System.EventHandler(this.BtnSaveCategory_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(23, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(173, 31);
            this.label13.TabIndex = 96;
            this.label13.Text = "Category name";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCategory
            // 
            this.txtCategory.Animated = true;
            this.txtCategory.BackColor = System.Drawing.Color.Transparent;
            this.txtCategory.BorderColor = System.Drawing.Color.Black;
            this.txtCategory.BorderRadius = 10;
            this.txtCategory.BorderThickness = 2;
            this.txtCategory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCategory.DefaultText = "";
            this.txtCategory.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCategory.DisabledState.Parent = this.txtCategory;
            this.txtCategory.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCategory.FocusedState.Parent = this.txtCategory;
            this.txtCategory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCategory.ForeColor = System.Drawing.Color.Black;
            this.txtCategory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCategory.HoverState.Parent = this.txtCategory;
            this.txtCategory.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtCategory.Location = new System.Drawing.Point(25, 120);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCategory.MaxLength = 20;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.PasswordChar = '\0';
            this.txtCategory.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtCategory.PlaceholderText = "Enter Category";
            this.txtCategory.SelectedText = "";
            this.txtCategory.ShadowDecoration.BorderRadius = 15;
            this.txtCategory.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtCategory.ShadowDecoration.Enabled = true;
            this.txtCategory.ShadowDecoration.Parent = this.txtCategory;
            this.txtCategory.Size = new System.Drawing.Size(431, 51);
            this.txtCategory.TabIndex = 85;
            this.txtCategory.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 31);
            this.label1.TabIndex = 102;
            this.label1.Text = "ADD CATEGORY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnClose.Location = new System.Drawing.Point(613, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(47, 43);
            this.btnClose.TabIndex = 120;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CategoryForm
            // 
            this.CategoryForm.AnimateWindow = true;
            this.CategoryForm.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_POSITIVE;
            this.CategoryForm.BorderRadius = 20;
            this.CategoryForm.ContainerControl = this;
            this.CategoryForm.ResizeForm = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(676, 55);
            this.guna2Panel1.TabIndex = 96;
            // 
            // CategoryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(676, 217);
            this.Controls.Add(this.BtnSaveCategory);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CategoryManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryManagementForm";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox txtCategory;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private Guna.UI2.WinForms.Guna2Button BtnSaveCategory;
        private Guna.UI2.WinForms.Guna2BorderlessForm CategoryForm;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}