using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SikmyVrh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            textBoxAngle.Text = angle.ToString();
            textBoxSpeed.Text = speed.ToString();
            Maluj();
            mic = new PointF(-3, ClientSize.Height - 3);
            a = CreateGraphics();
        }
        int angle = 40;
        double speed = 67;
        Graphics g;
        private void Maluj()
        {
            g = CreateGraphics();
            g.Clear(Color.White);
            float x = (float)Math.Cos(angle * Math.PI / 180) * 100; // width
            float y = (float)Math.Sin(angle * Math.PI / 180) * 100; // heights
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawLine(Pens.Black, new Point(0, ClientSize.Height), new Point((int)x, ClientSize.Height - (int)y));
            g.FillEllipse(Brushes.Black, -3, ClientSize.Height - 3, 6, 6);
            mic = new PointF(x, y);
            this.Invalidate();
        }
        Graphics a;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillEllipse(Brushes.Red, mic.X - 4.5f, mic.Y - 4.5f, 10, 10);
            a = e.Graphics;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Maluj();
        }

        private void textBoxAngle_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                angle = Convert.ToInt32(textBoxAngle.Text);
                textBoxAngle.BackColor = Color.White;
                Maluj();
            }
            catch
            {
                textBoxAngle.BackColor = Color.Red;
            }
        }

        private void textBoxSpeed_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                speed = Convert.ToSingle(textBoxSpeed.Text);
                textBoxSpeed.BackColor = Color.White;
                Maluj();
            }
            catch
            {
                textBoxSpeed.BackColor = Color.Red;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Maluj();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != FormBorderStyle.FixedSingle)
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            else
            {
                timer1.Start();
            }
        }
        float t = 0;
        PointF mic;
        private void timer1_Tick(object sender, EventArgs e)
        {
            t += (float)timer1.Interval / 1000;
            float x0 = -1.5f;
            float y0 = ClientSize.Height - 1.5f;
            float v = (float)speed;
            float time = t;
            float x = x0 + v * time * (float)Math.Cos(angle * Math.PI / 180); // width
            float y = y0 - v * time * (float)Math.Sin(angle * Math.PI / 180) - 0.5f * -9.81f * (float)Math.Pow(time,2); // heights
            g.FillEllipse(Brushes.Black, x,y, 3.0f, 3.0f);
            mic = new PointF(x, y);
            Invalidate();
        }
    }
}
