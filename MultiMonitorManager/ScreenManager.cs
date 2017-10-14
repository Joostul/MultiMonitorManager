using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiMonitorManager
{
    public class ScreenManager
    {
        public Screen[] Screens;

        public ScreenManager()
        {
            Screens = Screen.AllScreens;
        }

        //public Point blabla

    }
}
