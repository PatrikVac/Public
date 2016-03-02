using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Malovani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
        }
        private void novýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novy novy = new Novy(this,trackBar1.Value, colorButton.BackColor);
            novy.ShowDialog();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if((inForm)ActiveMdiChild != null)
                ((inForm)ActiveMdiChild).size = trackBar1.Value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cd.FullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                if ((inForm)ActiveMdiChild != null)
                    ((inForm)ActiveMdiChild).color = cd.Color;
                colorButton.BackColor = cd.Color;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if ((inForm)ActiveMdiChild != null)
            ((inForm)ActiveMdiChild).PaintType = 1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if ((inForm)ActiveMdiChild != null)
            ((inForm)ActiveMdiChild).PaintType = 0;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if ((inForm)ActiveMdiChild != null)
            ((inForm)ActiveMdiChild).PaintType = 2;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if ((inForm)ActiveMdiChild != null)
            ((inForm)ActiveMdiChild).PaintType = 3;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if ((inForm)ActiveMdiChild != null)
            ((inForm)ActiveMdiChild).PaintType = 4;
        }
        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                inForm open = new inForm(opf.FileName, trackBar1.Value, colorButton.BackColor);
                open.MdiParent = this;
                open.Show();
            }
        }
        private void bRed_Click(object sender, EventArgs e)
        {
            if ((inForm)ActiveMdiChild != null)
            try
            {
                int color = Convert.ToInt32(rtext.Text);
                if (color > 255) color = 255;
                if (color < 0) color = 0;
                ((inForm)ActiveMdiChild).ChangeC(color, "R");
            }
            catch (FormatException)
            {
                MessageBox.Show("Vkládejte pouze čísla v rozmezí 0 - 255");
            }
        }
        private void bGreen_Click(object sender, EventArgs e)
        {
            if ((inForm)ActiveMdiChild != null)
            try
            {
            int color = Convert.ToInt32(gtext.Text);
            if (color > 255) color = 255;
            if (color < 0) color = 0;
            ((inForm)ActiveMdiChild).ChangeC(color, "G");
            }
            catch (FormatException)
            {
                MessageBox.Show("Vkládejte pouze čísla v rozmezí 0 - 255");
            }
        }
        private void bBlue_Click(object sender, EventArgs e)
        {
            if ((inForm)ActiveMdiChild != null)
            try
            {
                int color = Convert.ToInt32(btext.Text);
                if (color > 255) color = 255;
                if (color < 0) color = 0;
                ((inForm)ActiveMdiChild).ChangeC(color, "B");
            }
            catch (FormatException)
            {
                MessageBox.Show("Vkládejte pouze čísla v rozmezí 0 - 255");
            }
        }
        private void uložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((inForm)ActiveMdiChild != null)
            {
                if (((inForm)ActiveMdiChild).ulozeno == null)
                {
                    SaveDialog();
                }
                else
                {
                    ((inForm)ActiveMdiChild).bmp.Save(((inForm)ActiveMdiChild).ulozeno);
                    ((inForm)ActiveMdiChild).zmena = false;
                }
            }
        }
        private void SaveDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Jpeg|*.jpeg|Jpg|*.jpg|PNG|*.png|Bitmap|*.bmp|Gif|*.gif";
            sfd.FileName = "Nový obrázek";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ((inForm)ActiveMdiChild).bmp.Save(sfd.FileName);
                ((inForm)ActiveMdiChild).ulozeno = sfd.FileName;
                ((inForm)ActiveMdiChild).zmena = false;
            }
        }
        private void uložitJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((inForm)ActiveMdiChild != null)
            SaveDialog();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if ((inForm)ActiveMdiChild != null)
                    ((inForm)ActiveMdiChild).inText.Font = fd.Font;
            }
        }
        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
