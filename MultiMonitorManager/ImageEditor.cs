using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiMonitorManager
{
    public static class ImageEditor
    {
        public static string CreateCombinationImage(string[] images, Size size)
        {
            string fileLocation = @"C:\Users\joost\Pictures\wallpaper.png";

            Brush b = new SolidBrush(Color.Blue);

            using(Bitmap bmp = new Bitmap(size.Width, size.Height))
            {
                using(Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRegion(b, new Region(new Rectangle(new Point(0, 0), size)));
                }

                bmp.Save(@"C:\Users\joost\Pictures\wallpaper.png", System.Drawing.Imaging.ImageFormat.Png);
            }

            return fileLocation;
        }
    }
}
