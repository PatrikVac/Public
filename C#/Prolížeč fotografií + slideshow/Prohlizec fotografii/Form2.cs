using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prohlizec_fotografii
{
    public partial class Form2 : Form
    {
        public Form2(List<PictureBox> pbs, int index)
        {
            InitializeComponent();
            pictureBox1.Image = pbs[index].Image;
            this.pbs = pbs;
            this.index = index;
        }
        List<PictureBox> pbs;
        int index = 0;
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (index > 0) index--;
            pictureBox1.Image = pbs[index].Image;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (index < pbs.Count - 1) index++;
            pictureBox1.Image = pbs[index].Image;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            index = 0;
            pictureBox1.Image = pbs[index].Image;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            index = pbs.Count - 1;
            pictureBox1.Image = pbs[index].Image;
        }
        bool slideshow = false;
        int oldW = 0;
        int oldH = 0;
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (slideshow)
            {
                this.Width = oldW;
                this.Height = oldH;
                timer1.Stop();
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                slideshow = this.TopMost = false;
                toolStripButton5.Text = "Zapnout slideShow";
            }
            else
            {
                oldW = this.Width;
                oldH = this.Height;
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
                slideshow = this.TopMost = true;
                WinApi.SetWinFullScreen(this.Handle);
                timer1.Start();
                toolStripButton5.Text = "Vypnout slideShow";
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            index++;
            if(index == pbs.Count) index = 0;
            pictureBox1.Image = pbs[index].Image;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (index > 0) index--;
                pictureBox1.Image = pbs[index].Image;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (index < pbs.Count - 1) index++;
                pictureBox1.Image = pbs[index].Image;
            }
        }
    }
    public class WinApi
    {
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int which);

        [DllImport("user32.dll")]
        public static extern void
            SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                         int X, int Y, int width, int height, uint flags);

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private static IntPtr HWND_TOP = IntPtr.Zero;
        private const int SWP_SHOWWINDOW = 64; // 0x0040

        public static int ScreenX
        {
            get { return GetSystemMetrics(SM_CXSCREEN); }
        }

        public static int ScreenY
        {
            get { return GetSystemMetrics(SM_CYSCREEN); }
        }

        public static void SetWinFullScreen(IntPtr hwnd)
        {
            SetWindowPos(hwnd, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW);
        }
    }
}
