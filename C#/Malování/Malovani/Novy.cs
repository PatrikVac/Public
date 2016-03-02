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
    public partial class Novy : Form
    {
        public float outSize;
        public Color outColor;
        public Form outHandler;
        public Novy(Form inHandler,float inSize, Color inColor)
        {
            outHandler = inHandler;
            outSize = inSize;
            outColor = inColor;
            InitializeComponent();
            name.Text = "Nový obrázek " + (inHandler.MdiChildren.Length + 1);
        }

        private void OKb_Click(object sender, EventArgs e)
        {
            inForm newdoc = new inForm(name.Text,outSize, outColor, Convert.ToInt32(width.Text), Convert.ToInt32(height.Text), BgColor.BackColor);
            newdoc.MdiParent = outHandler;
            newdoc.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BgColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = Color.Transparent;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                if ((inForm)ActiveMdiChild != null)
                    ((inForm)ActiveMdiChild).color = cd.Color;
                BgColor.BackColor = cd.Color;
            }
        }
    }
}
