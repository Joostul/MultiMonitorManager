using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            var files = Directory.GetFiles(@"\\freenas\Data\Images\wallpapers 1440p");

            // Todo: Sort by resolution of the screens
            // Todo: better randomizer?
            Random random = new Random();
            int i = 0;

            // Check if image is same size as screen
            GraphicsUnit unit = GraphicsUnit.Pixel;
            string image1 = null;
            string image2 = @"C:\Users\joost\Pictures\4k wallpaper.jpg";

            RectangleF imageBounds = new RectangleF();

            while (imageBounds.Height != screens[1].Height && imageBounds.Width != screens[1].Width)
            {
                i = random.Next(files.Length);
                imageBounds = Image.FromFile(files[i]).GetBounds(ref unit);
            } 

            image1 = files[i];
            
            // Make images into big image
            string imagePath = ImageEditor.CreateCombinationImage(
                new Dictionary<string, Point>()
                    {
                        { image1, new Point(0, 1238) },
                        { image2, new Point(3440, 0) }
                    },
                new Size(5600, 3840));

            // Set wallpaper
            Wallpaper.Set(imagePath, Wallpaper.Style.Tiled);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }

            else if (FormWindowState.Normal == WindowState)
            {

            }
        }
    }
}
