using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ObrazekCopyright
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Obrázek|*.jpg; *.jpeg; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(ofd.FileName);
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                Font f = new Font("Arial", 40f);
                string text = "© Patrik Václavek";
                while ((g.MeasureString(text, f).Width + 10) > ((pictureBox1.Image.Width / 100) * 40) && f.Size > 0.1f)
                    f = new Font("Arial", f.Size-0.1f);
                g.DrawString(text, f, Brushes.Black, pictureBox1.Image.Width - g.MeasureString(text, f).Width - 10, pictureBox1.Image.Height - g.MeasureString(text, f).Height - 10);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(sfd.FileName);
        }
    }
}
