using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            cVypnutiObrazovky vyp = new cVypnutiObrazovky();
            vyp.VypniMonitor();
        }
    }
    /// <summary>
    /// trida pro vypnuti obrazovky
    /// </summary>
    internal class cVypnutiObrazovky
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MONITORPOWER = 0xF170;
        const int HWND_BROADCAST = 0xFFFF;

        /// <summary>
        /// vypne monitor
        /// </summary>
        public void VypniMonitor()
        {
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
        }
    }
}
