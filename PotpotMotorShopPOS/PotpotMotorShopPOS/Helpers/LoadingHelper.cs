using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PotpotMotorShopPOS.Helpers
{
    public static class LoadingHelper
    {
        private static Form overlayForm;
        private static PictureBox loader;
        private static Label loadingLabel;
        private static bool isAnimating = false;

        public static void ShowLoading(Form parentForm, Image gifImage = null, string loadingText = "Loading...")
        {
            if (overlayForm != null) return; // already showing

            overlayForm = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                Bounds = parentForm.Bounds,
                BackColor = Color.Black,
                Opacity = 0.0,
                TopMost = true,
                ShowInTaskbar = false
            };

            loader = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.CenterImage,
                BackColor = Color.Transparent,
                TabStop = false
            };

            loadingLabel = new Label
            {
                Text = loadingText,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                TabStop = false
            };

            // Load GIF
            if (gifImage != null)
            {
                loader.Image = gifImage;
            }
            else
            {
                try
                {
                    loader.Image = LoadGifFromResources();
                }
                catch
                {
                    CreateFallbackLoader();
                }
            }

            if (loader.Image != null)
            {
                SetupGifAnimation();
                loader.Size = loader.Image.Size;
            }

            PositionControls();
            overlayForm.Resize += (s, e) => PositionControls();

            overlayForm.Controls.Add(loader);
            overlayForm.Controls.Add(loadingLabel);

            overlayForm.Location = parentForm.Location;
            overlayForm.Size = parentForm.Size;

            overlayForm.Show(parentForm); // show relative to parent
            FadeIn();
        }

        private static void FadeIn()
        {
            var fadeTimer = new Timer { Interval = 20 };
            double opacity = 0;

            fadeTimer.Tick += (s, e) =>
            {
                opacity += 0.05;
                if (opacity >= 0.7)
                {
                    opacity = 0.7;
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                }

                if (overlayForm != null && !overlayForm.IsDisposed)
                {
                    overlayForm.Opacity = opacity;
                }
            };

            fadeTimer.Start();
        }

        // ✅ FIXED: Now returns Task to properly await fade out completion
        public static async Task HideLoadingAsync(Form parentForm)
        {
            if (overlayForm == null) return;

            var tcs = new TaskCompletionSource<bool>();
            var fadeTimer = new Timer { Interval = 20 };
            double opacity = overlayForm.Opacity;

            fadeTimer.Tick += (s, e) =>
            {
                opacity -= 0.1;
                if (opacity <= 0)
                {
                    opacity = 0;
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                    CleanupLoading();
                    tcs.TrySetResult(true); // ✅ Signal completion
                }

                if (overlayForm != null && !overlayForm.IsDisposed)
                {
                    overlayForm.Opacity = opacity;
                }
            };

            fadeTimer.Start();
            await tcs.Task; // ✅ Wait for fade out to complete
        }

        // ✅ Keep old synchronous method for backward compatibility
        public static void HideLoading(Form parentForm)
        {
            if (overlayForm == null) return;

            var fadeTimer = new Timer { Interval = 20 };
            double opacity = overlayForm.Opacity;

            fadeTimer.Tick += (s, e) =>
            {
                opacity -= 0.1;
                if (opacity <= 0)
                {
                    opacity = 0;
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                    CleanupLoading();
                }

                if (overlayForm != null && !overlayForm.IsDisposed)
                {
                    overlayForm.Opacity = opacity;
                }
            };

            fadeTimer.Start();
        }

        private static void CleanupLoading()
        {
            try
            {
                if (overlayForm != null)
                {
                    if (loader?.Image != null && isAnimating)
                    {
                        ImageAnimator.StopAnimate(loader.Image, OnFrameChanged);
                        isAnimating = false;
                    }

                    if (loader?.Tag is Timer timer)
                    {
                        timer.Stop();
                        timer.Dispose();
                    }

                    overlayForm.Close();
                    overlayForm.Dispose();
                    overlayForm = null;
                    loader = null;
                    loadingLabel = null;
                }
            }
            catch { }
        }

        private static Image LoadGifFromResources()
        {
            string resourcePath = Path.Combine(Application.StartupPath, "Resources", "loading.gif");
            if (File.Exists(resourcePath))
            {
                using (var fs = new FileStream(resourcePath, FileMode.Open, FileAccess.Read))
                {
                    return Image.FromStream(fs);
                }
            }

            string[] gifFiles = Directory.GetFiles(
                Path.Combine(Application.StartupPath, "Resources"),
                "*.gif", SearchOption.TopDirectoryOnly);

            if (gifFiles.Length > 0)
            {
                using (var fs = new FileStream(gifFiles[0], FileMode.Open, FileAccess.Read))
                {
                    return Image.FromStream(fs);
                }
            }

            throw new FileNotFoundException("No GIF found");
        }

        private static void SetupGifAnimation()
        {
            if (loader.Image != null && !isAnimating)
            {
                isAnimating = true;
                ImageAnimator.Animate(loader.Image, OnFrameChanged);
            }
        }

        private static void OnFrameChanged(object sender, EventArgs e)
        {
            try
            {
                if (loader != null && !loader.IsDisposed)
                {
                    loader.Invalidate();
                }
            }
            catch { }
        }

        private static void CreateFallbackLoader()
        {
            loader.Size = new Size(50, 50);
            loader.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (var pen = new Pen(Color.White, 3))
                {
                    var angle = (DateTime.Now.Millisecond / 10) % 360;
                    g.DrawArc(pen, 10, 10, 30, 30, angle, 90);
                }
            };

            var timer = new Timer { Interval = 50 };
            timer.Tick += (s, e) => loader?.Invalidate();
            timer.Start();
            loader.Tag = timer;
        }

        private static void PositionControls()
        {
            if (overlayForm == null || loader == null || loadingLabel == null) return;

            loader.Location = new Point(
                (overlayForm.Width - loader.Width) / 2,
                (overlayForm.Height - loader.Height) / 2 - 20
            );

            loadingLabel.Location = new Point(
                (overlayForm.Width - loadingLabel.Width) / 2,
                loader.Bottom + 20
            );
        }

        // ✅ FIXED: Now properly awaits fade out completion
        public static async Task RunWithLoading(Form parentForm, Func<Task> action,
                                        int minimumDelayMs = 3000,
                                        string loadingText = "Loading...")
        {
            ShowLoading(parentForm, null, loadingText);

            // 🔹 Important: give UI a chance to render the overlay first
            await Task.Yield();

            try
            {
                var actionTask = action();
                var delayTask = Task.Delay(minimumDelayMs);

                // ensure both the action and minimum delay complete
                await Task.WhenAll(actionTask, delayTask);
            }
            finally
            {
                // ✅ CRITICAL: Await fade out completion before continuing
                await HideLoadingAsync(parentForm);
            }
        }

        public static void UpdateLoadingText(string newText)
        {
            if (loadingLabel != null && !loadingLabel.IsDisposed)
            {
                if (loadingLabel.InvokeRequired)
                {
                    loadingLabel.Invoke(new Action(() =>
                    {
                        loadingLabel.Text = newText;
                        PositionControls();
                    }));
                }
                else
                {
                    loadingLabel.Text = newText;
                    PositionControls();
                }
            }
        }

        public static bool IsLoading => overlayForm != null;
    }
}