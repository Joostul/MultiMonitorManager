using System;
using System.Windows.Forms;

namespace MultiMonitorManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Get screens

            // Select images that can fit the screens together
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
