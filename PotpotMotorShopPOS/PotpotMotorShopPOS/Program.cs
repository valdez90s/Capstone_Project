using PotpotMotorShopPOS.Forms.Authentication;
using System;
using System.Windows.Forms;

namespace PotpotMotorShopPOS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 👉 Start with LoadingForm instead of LoginForm
            Application.Run(new LoadingForm());
        }
    }
}