using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MultiMonitorManager
{
    public static class ScreenManager
    {
        public static int GetMonitorAmount()
        {
            return Screen.AllScreens.Length;
        }

        public static Size GetScreenDimensions(int screenNumber)
        {
            var scalingfactor = getScalingFactor();

            // Hardcoding the scaling factor for my own desktop for now
            if(Screen.AllScreens[screenNumber].Primary != true)
            {
                scalingfactor = 1.5F;
            }

            var size = new Size()
            {
                Height = (int)Math.Round(Screen.AllScreens[screenNumber].Bounds.Height * scalingfactor),
                Width = (int)Math.Round(Screen.AllScreens[screenNumber].Bounds.Width * scalingfactor)
            };

            return size;
        }

        public static Screen[] GetScreens()
        {
            return Screen.AllScreens;
        }

        public static Size GetDesktopDimensions()
        {
            return Screen.AllScreens.Select(screen => screen.Bounds).Aggregate(Rectangle.Union).Size;
        }

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117
        }

        private static float getScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

            return ScreenScalingFactor; // 1.25 = 125%
        }

    }
}
