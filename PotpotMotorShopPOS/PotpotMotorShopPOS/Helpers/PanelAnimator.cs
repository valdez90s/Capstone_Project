using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotpotMotorShopPOS.Helpers
{
    public static class PanelAnimator
    {
        public static async Task SlideUpAsync(Panel panel, int targetHeight, int step = 10, int delay = 15)
        {
            panel.Visible = true;
            panel.Height = 0;

            while (panel.Height < targetHeight)
            {
                panel.Height += step;
                await Task.Delay(delay);
            }
            panel.Height = targetHeight;
        }

        public static async Task SlideDownAsync(Panel panel, int step = 10, int delay = 15)
        {
            while (panel.Height > 0)
            {
                panel.Height -= step;
                await Task.Delay(delay);
            }
            panel.Visible = false;
        }
    }
}