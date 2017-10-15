using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MultiMonitorManager
{
    public static class ImageEditor
    {
        public static string CreateCombinationImage(Dictionary<string, Point> images, Size size, string folder)
        {
            Directory.CreateDirectory(folder);

            try
            {
                string fileLocation = Path.Combine(folder, Guid.NewGuid().ToString() + ".png");

                Brush b = new SolidBrush(Color.Blue);

                using (Bitmap bmp = new Bitmap(size.Width, size.Height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {

                        g.FillRegion(b, new Region(new Rectangle(new Point(0, 0), size)));

                        foreach (var i in images)
                        {
                            g.DrawImage(Image.FromFile(i.Key), i.Value);
                        }
                    }

                    bmp.Save(fileLocation, System.Drawing.Imaging.ImageFormat.Png);
                }

                return fileLocation;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
