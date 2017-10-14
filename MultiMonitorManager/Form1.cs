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

            // Todo: refactor this method when ScreenManager bug is fixed
            // Get screens
            Size[] screens = new Size[]
            {
                ScreenManager.GetScreenDimensions(0),
                ScreenManager.GetScreenDimensions(1)
            };

            // Select images that can fit the screens together
            // Make images into big image
            string imagePath = ImageEditor.CreateCombinationImage(new string[] { "", "" }, new Size(5600, 3840));

            // Set wallpaper


            Wallpaper.Set(imagePath, Wallpaper.Style.Tiled);
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
