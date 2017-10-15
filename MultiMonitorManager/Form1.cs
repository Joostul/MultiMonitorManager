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

        private void AutoSetBackgrounds_Click(object sender, EventArgs e)
        {
            AutoSetBackgrounds.Enabled = false;
            AutoSetBackgrounds.Text = "Setting Background...";

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
            string tempFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");

            string image1 = GetRandomImageWithSize(files, screens[1]);
            string image2 = @"C:\Users\joost\Pictures\4k wallpaper.jpg";

            // Make images into big image
            string imagePath = ImageEditor.CreateCombinationImage(
                new Dictionary<string, Point>()
                    {
                        { image1, new Point(0, 1238) },
                        { image2, new Point(3440, 0) }
                    },
                new Size(5600, 3840),
                tempFolder);

            // Set wallpaper
            if (imagePath != null)
            {
                Wallpaper.Set(imagePath, Wallpaper.Style.Tiled);
                DeleteFilesFromFolderExcept(tempFolder, imagePath);

                AutoSetBackgrounds.Text = "Auto Set Backgrounds";
                AutoSetBackgrounds.Enabled = true;
            } else
            {
                AutoSetBackgrounds.Text = "An Error Occured, try again.";
                AutoSetBackgrounds.Enabled = true;
            }
        }

        private void DeleteFilesFromFolderExcept(string tempFolder, string imagePath)
        {
            var files = Directory.GetFiles(tempFolder);
            var dontDelete = new FileInfo(imagePath).Name;

            foreach (var file in files)
            {
                var fileName = new FileInfo(file).Name;
                if(fileName != dontDelete)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception ignore)
                    {
                        // Todo: figure out why it won't delete the temp files after three times
                        // For now it works, only sometimes it takes a couple tries to delete the temp files
                    }
                }
            }
        }

        private string GetRandomImageWithSize(string[] files, Size screenSize)
        {
            string image = null;
            GraphicsUnit unit = GraphicsUnit.Pixel;
            RectangleF imageBounds = new RectangleF();

            do
            {
                image = GetRandomFile(files);
                imageBounds = Image.FromFile(image).GetBounds(ref unit);
            } while (imageBounds.Height != screenSize.Height && imageBounds.Width != screenSize.Width);

            return image;
        }

        private string GetRandomFile(string[] files)
        {
            // Todo: better randomizer?
            Random random = new Random();
            int i = random.Next(files.Length);
            return files[i];
        }
    }
}
