using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestDelegatu
{
    public delegate void Objekty(int x, int y);
    public partial class Form1 : Form
    {
        Graphics g;
        Objekt o;
        List<Objekty> zasobnik;
        public Form1()
        {
            zasobnik = new List<Objekty>();
            InitializeComponent();
            g = this.CreateGraphics();
            g.Clear(Color.White);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Objekty obj in zasobnik)
            {
                obj(e.X, e.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            o = new Objekt(g);
            zasobnik.Add(new Objekty(o.Ctverec));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            o = new Objekt(g);
            zasobnik.Add(new Objekty(o.Kruh));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            o = new Objekt(g);
            zasobnik.Add(new Objekty(o.Kriz));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zasobnik = new List<Objekty>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }
    }
    class Objekt
    {
        int velikost;
        Graphics graphics;
        Pen p;
        public Objekt(Graphics gr)
        {
            graphics = gr;
            Random rnd = new Random();
            velikost = rnd.Next(10,100);
            p = new Pen(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), 1.0f + (float)(rnd.Next(0,200) / 100));
        }
        public void Ctverec(int x, int y)
        {
            graphics.DrawRectangle(p, x - (velikost / 2), y - (velikost / 2), velikost, velikost);
        }
        public void Kruh(int x, int y)
        {
            graphics.DrawEllipse(p, x - (velikost / 2), y - (velikost / 2), velikost, velikost);
        }
        public void Kriz(int x, int y)
        {
            graphics.DrawLine(p, x, y - (velikost / 2), x, y + velikost / 2);
            graphics.DrawLine(p, x - (velikost / 2), y, x + velikost / 2, y);
        }
    }
}
