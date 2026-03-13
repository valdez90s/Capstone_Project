using PotpotMotorShopPOS.Forms.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotpotMotorShopPOS
{
    public partial class LoadingForm : Form
    {
        int remainingSeconds = 10; // total countdown time

        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            Timer timer = new Timer();
            timer.Interval = 100; // ⏱️ 1 second per tick
            timer.Tick += (s, ev) =>
            {
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    progressBar1.Value += 1; // count up slowly
                    lblStatus.Text = $"Loading... {progressBar1.Value}%";
                }
                else
                {
                    timer.Stop();
                    lblStatus.Text = "Done!";

                    // 👉 Open LoginForm
                    LoginForm login = new LoginForm();
                    login.Show();

                    this.Hide();
                }
            };
            timer.Start();

        }
    }
}
