namespace PotpotMotorShopPOS.Views.Management
{
    partial class BackupRestoreControl
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                // Cleanup timer
                if (backupTimer != null)
                {
                    backupTimer.Stop();
                    backupTimer.Dispose();
                }
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel6 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel4 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnBackupPostgreSQL = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel5 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnRestorePostgreSQL = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2GradientPanel6.SuspendLayout();
            this.guna2GradientPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            this.guna2GradientPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.guna2GradientPanel6);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel2);
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
            // guna2GradientPanel6
            // 
            this.guna2GradientPanel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2GradientPanel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel6.BorderRadius = 20;
            this.guna2GradientPanel6.Controls.Add(this.guna2HtmlLabel3);
            this.guna2GradientPanel6.Controls.Add(this.guna2GradientPanel4);
            this.guna2GradientPanel6.Controls.Add(this.guna2GradientPanel5);
            this.guna2GradientPanel6.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel6.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel6.Location = new System.Drawing.Point(493, 190);
            this.guna2GradientPanel6.Name = "guna2GradientPanel6";
            this.guna2GradientPanel6.ShadowDecoration.BorderRadius = 25;
            this.guna2GradientPanel6.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel6.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel6.ShadowDecoration.Parent = this.guna2GradientPanel6;
            this.guna2GradientPanel6.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.guna2GradientPanel6.Size = new System.Drawing.Size(664, 478);
            this.guna2GradientPanel6.TabIndex = 143;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(17, 32);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(625, 31);
            this.guna2HtmlLabel3.TabIndex = 146;
            this.guna2HtmlLabel3.Text = "BACK UP AND RESTORE FOR POSTGRESQL DATABASE";
            // 
            // guna2GradientPanel4
            // 
            this.guna2GradientPanel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel4.BorderRadius = 20;
            this.guna2GradientPanel4.Controls.Add(this.guna2PictureBox3);
            this.guna2GradientPanel4.Controls.Add(this.btnBackupPostgreSQL);
            this.guna2GradientPanel4.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel4.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel4.Location = new System.Drawing.Point(340, 103);
            this.guna2GradientPanel4.Name = "guna2GradientPanel4";
            this.guna2GradientPanel4.ShadowDecoration.BorderRadius = 25;
            this.guna2GradientPanel4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel4.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel4.ShadowDecoration.Parent = this.guna2GradientPanel4;
            this.guna2GradientPanel4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.guna2GradientPanel4.Size = new System.Drawing.Size(302, 352);
            this.guna2GradientPanel4.TabIndex = 142;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.Image = global::PotpotMotorShopPOS.Properties.Resources.icons_data_backup_100;
            this.guna2PictureBox3.Location = new System.Drawing.Point(17, 3);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
            this.guna2PictureBox3.Size = new System.Drawing.Size(266, 240);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 2;
            this.guna2PictureBox3.TabStop = false;
            this.guna2PictureBox3.UseTransparentBackground = true;
            // 
            // btnBackupPostgreSQL
            // 
            this.btnBackupPostgreSQL.Animated = true;
            this.btnBackupPostgreSQL.BackColor = System.Drawing.Color.Transparent;
            this.btnBackupPostgreSQL.BorderRadius = 10;
            this.btnBackupPostgreSQL.CheckedState.Parent = this.btnBackupPostgreSQL;
            this.btnBackupPostgreSQL.CustomImages.Parent = this.btnBackupPostgreSQL;
            this.btnBackupPostgreSQL.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnBackupPostgreSQL.Font = new System.Drawing.Font("Segoe UI Black", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupPostgreSQL.ForeColor = System.Drawing.Color.White;
            this.btnBackupPostgreSQL.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnBackupPostgreSQL.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnBackupPostgreSQL.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupPostgreSQL.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnBackupPostgreSQL.HoverState.Parent = this.btnBackupPostgreSQL;
            this.btnBackupPostgreSQL.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBackupPostgreSQL.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnBackupPostgreSQL.ImageSize = new System.Drawing.Size(100, 100);
            this.btnBackupPostgreSQL.Location = new System.Drawing.Point(17, 263);
            this.btnBackupPostgreSQL.Name = "btnBackupPostgreSQL";
            this.btnBackupPostgreSQL.ShadowDecoration.BorderRadius = 15;
            this.btnBackupPostgreSQL.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnBackupPostgreSQL.ShadowDecoration.Enabled = true;
            this.btnBackupPostgreSQL.ShadowDecoration.Parent = this.btnBackupPostgreSQL;
            this.btnBackupPostgreSQL.Size = new System.Drawing.Size(266, 72);
            this.btnBackupPostgreSQL.TabIndex = 138;
            this.btnBackupPostgreSQL.Text = "BACKUP";
            this.btnBackupPostgreSQL.TextOffset = new System.Drawing.Point(7, 0);
            this.btnBackupPostgreSQL.Click += new System.EventHandler(this.btnBackupPostgreSQL_Click);
            // 
            // guna2GradientPanel5
            // 
            this.guna2GradientPanel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel5.BorderRadius = 20;
            this.guna2GradientPanel5.Controls.Add(this.guna2PictureBox4);
            this.guna2GradientPanel5.Controls.Add(this.btnRestorePostgreSQL);
            this.guna2GradientPanel5.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel5.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel5.Location = new System.Drawing.Point(18, 103);
            this.guna2GradientPanel5.Name = "guna2GradientPanel5";
            this.guna2GradientPanel5.ShadowDecoration.BorderRadius = 25;
            this.guna2GradientPanel5.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel5.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel5.ShadowDecoration.Parent = this.guna2GradientPanel5;
            this.guna2GradientPanel5.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.guna2GradientPanel5.Size = new System.Drawing.Size(302, 352);
            this.guna2GradientPanel5.TabIndex = 141;
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.Image = global::PotpotMotorShopPOS.Properties.Resources.icons_database_restore_100;
            this.guna2PictureBox4.Location = new System.Drawing.Point(20, 3);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.ShadowDecoration.Parent = this.guna2PictureBox4;
            this.guna2PictureBox4.Size = new System.Drawing.Size(266, 240);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox4.TabIndex = 2;
            this.guna2PictureBox4.TabStop = false;
            this.guna2PictureBox4.UseTransparentBackground = true;
            this.guna2PictureBox4.Click += new System.EventHandler(this.guna2PictureBox4_Click);
            // 
            // btnRestorePostgreSQL
            // 
            this.btnRestorePostgreSQL.Animated = true;
            this.btnRestorePostgreSQL.BackColor = System.Drawing.Color.Transparent;
            this.btnRestorePostgreSQL.BorderRadius = 10;
            this.btnRestorePostgreSQL.CheckedState.Parent = this.btnRestorePostgreSQL;
            this.btnRestorePostgreSQL.CustomImages.Parent = this.btnRestorePostgreSQL;
            this.btnRestorePostgreSQL.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.btnRestorePostgreSQL.Font = new System.Drawing.Font("Segoe UI Black", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestorePostgreSQL.ForeColor = System.Drawing.Color.White;
            this.btnRestorePostgreSQL.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnRestorePostgreSQL.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnRestorePostgreSQL.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestorePostgreSQL.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnRestorePostgreSQL.HoverState.Parent = this.btnRestorePostgreSQL;
            this.btnRestorePostgreSQL.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRestorePostgreSQL.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnRestorePostgreSQL.ImageSize = new System.Drawing.Size(100, 100);
            this.btnRestorePostgreSQL.Location = new System.Drawing.Point(20, 263);
            this.btnRestorePostgreSQL.Name = "btnRestorePostgreSQL";
            this.btnRestorePostgreSQL.ShadowDecoration.BorderRadius = 15;
            this.btnRestorePostgreSQL.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRestorePostgreSQL.ShadowDecoration.Enabled = true;
            this.btnRestorePostgreSQL.ShadowDecoration.Parent = this.btnRestorePostgreSQL;
            this.btnRestorePostgreSQL.Size = new System.Drawing.Size(266, 72);
            this.btnRestorePostgreSQL.TabIndex = 137;
            this.btnRestorePostgreSQL.Text = "RESTORE";
            this.btnRestorePostgreSQL.TextOffset = new System.Drawing.Point(7, 0);
            this.btnRestorePostgreSQL.Click += new System.EventHandler(this.btnRestorePostgreSQL_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(66)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(280, 24);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(850, 63);
            this.guna2HtmlLabel2.TabIndex = 141;
            this.guna2HtmlLabel2.Text = "BACK UP AND RESTORE OF SYSTEM DATA";
            // 
            // BackupRestoreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "BackupRestoreControl";
            this.Size = new System.Drawing.Size(1682, 884);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel6.ResumeLayout(false);
            this.guna2GradientPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            this.guna2GradientPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel4;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2Button btnBackupPostgreSQL;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel5;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private Guna.UI2.WinForms.Guna2Button btnRestorePostgreSQL;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}