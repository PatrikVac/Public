using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hodiny
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            timer1.Start();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private float sx = 200f, sy = 200f, r = 100f;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(Pens.Black, sx - r, sy - r, 2 * r, 2 * r);
            e.Graphics.DrawLine(Pens.Black, sx - 5, sy, sx + 5, sy);
            e.Graphics.DrawLine(Pens.Black, sx, sy - 5, sx, sy + 5);
            e.Graphics.DrawString(DateTime.Now.ToLongTimeString(), new Font("Arial", 15), Brushes.Black, new PointF(10f, 10f));

            /* Vteriny */
            int vteriny = DateTime.Now.Second;
            float uhel = (float)(Math.PI*2/60*vteriny - Math.PI / 2);

            float posuvY = (float)(Math.Sin(uhel) * r);
            float posuvX = (float)(Math.Cos(uhel) * r);

            e.Graphics.DrawLine(Pens.Blue, sx, sy, sx + posuvX, sy + posuvY);

            /* Minuty */
            int minuty = DateTime.Now.Minute;
            uhel = (float)(Math.PI * 2 / 60 * minuty - Math.PI / 2);

            posuvY = (float)(Math.Sin(uhel) * (r - 5));
            posuvX = (float)(Math.Cos(uhel) * (r - 5));

            e.Graphics.DrawLine(new Pen(Color.Red, 2.5f), sx, sy, sx + posuvX, sy + posuvY);
            /* Hodiny */
            int hodiny = DateTime.Now.Hour;
            uhel = (float)(Math.PI * 2 / 12 * hodiny - Math.PI / 2);

            posuvY = (float)(Math.Sin(uhel) * (r - 20));
            posuvX = (float)(Math.Cos(uhel) * (r - 20));

            e.Graphics.DrawLine(new Pen(Color.Green, 5f), sx, sy, sx + posuvX, sy + posuvY);

            for (int i = 0; i < 60; i++)
            {
                uhel = (float)(Math.PI * 2 / 60 * i - Math.PI / 2);

                float konecY = (float)(Math.Sin(uhel) * (r + 2));
                float konecX = (float)(Math.Cos(uhel) * (r + 2));
                float zacatekY = (float)(Math.Sin(uhel) * (r - 2));
                float zacatekX = (float)(Math.Cos(uhel) * (r - 2));
                Pen p = new Pen(Color.Black, 1f);
                if (i % 5 == 0) p = new Pen(Color.Black, 2f); 
                e.Graphics.DrawLine(p, sx + zacatekX, sy + zacatekY, sx + konecX, sy + konecY);
            }

            for (int i = 0; i < 12; i++)
            {
                uhel = (float)(Math.PI * 2 / 12 * (i + 1) - Math.PI / 2);

                posuvY = (float)(Math.Sin(uhel) * (r + 20));
                posuvX = (float)(Math.Cos(uhel) * (r + 20));

                e.Graphics.DrawString((i + 1).ToString(), new Font("Arial", 15), Brushes.Black, new PointF((sx + posuvX) - 12, (sy + posuvY) - 12));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate(new Rectangle(0,0,100,30));
            Invalidate(new Rectangle((int)(sx - r), (int)(sy - r), (int)(2 * r), (int)(2 * r)));
        }
    }
}
