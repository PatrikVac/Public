using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CursorInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int odpocet;
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            odpocet = Convert.ToInt32(textBox3.Text);
            button1.Text = textBox3.Text;
            timer1.Start();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clipboard.SetText(e.KeyChar.ToString());
            if (e.KeyChar.ToString() != "")
            {
                int isNumber = 0;
                e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            odpocet--;
            button1.Text = odpocet.ToString();
            if (odpocet == 0)
            {
                Bitmap bm = CaptureScreen();
                Color px = bm.GetPixel(Cursor.Position.X, Cursor.Position.Y);
                panel1.BackColor = px;
                textBox4.Text = px.R + ", " + px.G + ", " + px.B;
                textBox1.Text = Cursor.Position.X.ToString();
                textBox2.Text = Cursor.Position.Y.ToString();
                button1.Text = "Start";
                timer1.Stop();
            }
        }
        public static Bitmap CaptureScreen()
        {
            Bitmap BMP = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,
            System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height,
            System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            try
            {
                System.Drawing.Graphics GFX = System.Drawing.Graphics.FromImage(BMP);
                GFX.CopyFromScreen(System.Windows.Forms.Screen.PrimaryScreen.Bounds.X,
                System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y,
                0, 0,
                System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size,
                System.Drawing.CopyPixelOperation.SourceCopy);
            }
            catch
            {
                return BMP;
            }
            return BMP;

        }
        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.SelectAll();
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.SelectAll();
        }
    }
}
