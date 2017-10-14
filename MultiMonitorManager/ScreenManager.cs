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

            return new Size((int)Math.Round(Screen.AllScreens[screenNumber].Bounds.Height * scalingfactor),
                (int)Math.Round(Screen.AllScreens[screenNumber].Bounds.Width * scalingfactor));
        }

        public static Screen[] GetScreens()
        {
            return Screen.AllScreens;
        }

        public static Rectangle GetDesktopDimensions()
        {
            Rectangle rect = new Rectangle();

            foreach (var s in Screen.AllScreens)
            {
                rect = Rectangle.Union(rect, s.Bounds);
            }

            return rect;

            //return Screen.AllScreens.Select(screen => screen.Bounds).Aggregate(Rectangle.Union).Size;
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
