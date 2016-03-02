using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Mic
{
    public partial class Form1 : Form
    {
        RectangleF mic;
        float deltaX, deltaY, posuv = 20.0f;
        int beta = 49;

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Red;
            mic = new Rectangle(170, 70, 100, 100);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(new LinearGradientBrush(mic, Color.Red, Color.Blue, LinearGradientMode.ForwardDiagonal), mic);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            deltaX = (float)Math.Cos(-beta * Math.PI / 180.0) * posuv;
            deltaY = (float)Math.Sin(-beta * Math.PI / 180.0) * posuv;
            mic.X += deltaX;
            mic.Y += deltaY;

            if ((mic.X + mic.Width) >= ClientSize.Width)
            {
                mic.X = ClientSize.Width - mic.Width;
                if (beta > 270) beta = 540 - beta;
                else beta = 180 - beta;
            }
            else if ((mic.X) <= 0)
            {
                mic.X = 0;
                if (beta > 180) beta = 540 - beta;
                else beta = 180 - beta;
            }
            else if ((mic.Y + mic.Width) >= ClientSize.Height)
            {
                mic.Y = ClientSize.Height - mic.Width;
                beta = 360 - beta;
            }
            else if (mic.Y <= 0)
            {
                beta = 360 - beta;
                mic.Y = 0;
            }
            this.Text = deltaX + ", " + deltaY + " - "+ beta + "°";
            Invalidate();
        }
    }
}
