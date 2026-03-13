namespace PotpotMotorShopPOS.Views.Authentication
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainF = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.PnlOne = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.PnlBottom = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainF
            // 
            this.MainF.AnimateWindow = true;
            this.MainF.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.MainF.BorderRadius = 60;
            this.MainF.ContainerControl = this;
            // 
            // PnlOne
            // 
            this.PnlOne.BackColor = System.Drawing.Color.White;
            this.PnlOne.BorderColor = System.Drawing.Color.White;
            this.PnlOne.CustomBorderColor = System.Drawing.Color.White;
            this.PnlOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlOne.Location = new System.Drawing.Point(0, 0);
            this.PnlOne.Name = "PnlOne";
            this.PnlOne.ShadowDecoration.BorderRadius = 0;
            this.PnlOne.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.PnlOne.ShadowDecoration.Enabled = true;
            this.PnlOne.ShadowDecoration.Parent = this.PnlOne;
            this.PnlOne.Size = new System.Drawing.Size(1826, 950);
            this.PnlOne.TabIndex = 2;
            this.PnlOne.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlOne_Paint);
            // 
            // PnlBottom
            // 
            this.PnlBottom.BackColor = System.Drawing.Color.White;
            this.PnlBottom.BorderColor = System.Drawing.Color.White;
            this.PnlBottom.Controls.Add(this.label1);
            this.PnlBottom.CustomBorderColor = System.Drawing.Color.Silver;
            this.PnlBottom.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 950);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.ShadowDecoration.BorderRadius = 0;
            this.PnlBottom.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.PnlBottom.ShadowDecoration.Enabled = true;
            this.PnlBottom.ShadowDecoration.Parent = this.PnlBottom;
            this.PnlBottom.Size = new System.Drawing.Size(1826, 46);
            this.PnlBottom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1826, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "© 2025-2026 POTPOT AND FRIEND\'S MOTORSHOP. ALL RIGHTS RESERVED.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1826, 996);
            this.Controls.Add(this.PnlOne);
            this.Controls.Add(this.PnlBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Potpot Motor Shop - POS System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm MainF;
        private Guna.UI2.WinForms.Guna2GradientPanel PnlOne;
        private Guna.UI2.WinForms.Guna2GradientPanel PnlBottom;
        private System.Windows.Forms.Label label1;
    }
}