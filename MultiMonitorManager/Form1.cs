using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiMonitorManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Graphics graphics = CreateGraphics();

            // Get screens
            var screen1 = ScreenManager.GetScreenDimensions(0);
            var screen2 = ScreenManager.GetScreenDimensions(1);

            var screens = ScreenManager.GetScreens();

            var totalBounds = ScreenManager.GetDesktopDimensions();

            // Select images that can fit the screens together
            // Make images into big image
            // Set wallpaper

            Wallpaper.Set(@"C:\Users\joost\Pictures/wallpaper.png", Wallpaper.Style.Tiled);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(FormWindowState.Minimized == WindowState)
            {
                Hide();
            }

            else if(FormWindowState.Normal == WindowState)
            {
                
            }
        }
    }
}
