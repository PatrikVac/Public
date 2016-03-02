using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlochaPodFunkcemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static float funkce(int x)
        {
            return (float)Math.Sin(x * Math.PI / 180f);
        }

        public delegate void Vykresleni(Graphics g, int[] rozsah);
        public Vykresleni vykresli;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void vykresliCtverec(Graphics g, int[] rozsah)
        {
            float scaleX = 500 / (rozsah[1] - rozsah[0]);
            float scaleY = -1f * 100f;
            g.DrawLine(Pens.Black,rozsah[0] + 20f,200,rozsah[1] + 20f,200);
            List<PointF> points = new List<PointF>();
            for (int i = rozsah[0]; i < rozsah[1]; i++)
            {
                float y = funkce(i);
                points.Add(new PointF(scaleX * i + 20f,scaleY * y + 200));
            }
            g.DrawLines(Pens.Red, points.ToArray());
        }
        private void vzorky(Graphics g, int[] rozsah)
        {
            float scaleX = 500 / (rozsah[1] - rozsah[0]);
            float scaleY = -1f * 100f;
            g.DrawLine(Pens.Black, rozsah[0] + 20f, 200, rozsah[1] + 20f, 200);
            List<PointF> points = new List<PointF>();
            for (int i = rozsah[0]; i < rozsah[1]; i+=5)
            {
                float y = funkce(i);
                points.Add(new PointF(scaleX * i + 20f, scaleY * y + 200));
            }
            for (int i = 1; i < points.Count; i++)
            {
                    float vzdalenostY = 200f - points[i - 1].Y;
                    float rY = points[i - 1].Y;
                    if (vzdalenostY < 0)
                    {
                        vzdalenostY *= -1;
                        rY = 200f;
                    }
                    g.DrawRectangle(Pens.Black, points[i - 1].X, rY, points[i].X - points[i - 1].X, vzdalenostY);   
       
            }
            g.DrawLines(Pens.Blue, points.ToArray()); 
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (vykresli != null)
            {
                int[] i = { 0, 360 };
                vykresli(e.Graphics, i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vykresli += vykresliCtverec;
            vykresli += vzorky;
            Refresh();
        }
    }
}
