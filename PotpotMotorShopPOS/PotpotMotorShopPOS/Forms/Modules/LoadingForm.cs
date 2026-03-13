using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Forms.Modules
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            // ✅ Fully transparent - only loading elements visible
            //this.BackColor = Color.Magenta;
            //this.TransparencyKey = Color.Magenta;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;

            // ✅ Optional: Prevent resizing
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
