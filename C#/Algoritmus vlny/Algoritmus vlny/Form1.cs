using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
// Václavek Patrik - T2
namespace Algoritmus_vlny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            vytvorPlochu();
        }

        private Bunka[,] plocha = new Bunka[10, 10];
        private List<Bunka> prohlizeneBunky = new List<Bunka>();

        private void vytvorPlochu()
        {
            Point p = new Point(20, 20);

            for (int i = 0; i < plocha.GetLength(0); i++)
            {
                for (int j = 0; j < plocha.GetLength(1); j++)
                {
                    plocha[i, j] = new Bunka(p, i, j);
                    p.X += 20;
                }
                p.Y += 20;
                p.X = 20;
            }

            plocha[2, 3].jeStart = true;
            prohlizeneBunky.Add(plocha[2, 3]);

            plocha[5, 6].jeCil = true;
        }

        private Bunka hledejCil()
        {
            List<Bunka> pom = new List<Bunka>();

            for (int i = 0; i < prohlizeneBunky.Count; i++)
            {
                Bunka okolniBunka = null;
                Bunka aktBunka = prohlizeneBunky[i];
                Bunka cil = null;

                aktBunka.jeProhlednuto = true;
                if (aktBunka.x > 0)
                {
                    okolniBunka = plocha[aktBunka.x - 1, aktBunka.y];
                    if ((cil = prohledniBunku(okolniBunka, aktBunka, pom)) != null)
                        return cil;
                }

                if (aktBunka.x < plocha.GetLength(1) - 1)
                {
                    okolniBunka = plocha[aktBunka.x + 1, aktBunka.y];
                    if ((cil = prohledniBunku(okolniBunka, aktBunka, pom)) != null)
                        return cil;
                }

                if (aktBunka.y > 0)
                {
                    okolniBunka = plocha[aktBunka.x, aktBunka.y - 1];
                    if ((cil = prohledniBunku(okolniBunka, aktBunka, pom)) != null)
                        return cil;
                }

                if (aktBunka.y < plocha.GetLength(0) - 1)
                {
                    okolniBunka = plocha[aktBunka.x, aktBunka.y + 1];
                    if ((cil = prohledniBunku(okolniBunka, aktBunka, pom)) != null)
                        return cil;
                }
            }

            prohlizeneBunky.Clear();
            prohlizeneBunky.AddRange(pom);
            return null;
        }

        private Bunka prohledniBunku(Bunka b, Bunka bunkaRodic, List<Bunka> cesta)
        {
            if ((b.cesta.Count == 1 || b.cesta.Count > bunkaRodic.cesta.Count + 1) && !b.jeProhlednuto && !b.jeZed)
            {
                b.cesta.AddRange(bunkaRodic.cesta);
                if (b.jeCil)
                    return b;
                cesta.Add(b);
            }
            return null;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < plocha.GetLength(0); i++)
            {
                for (int j = 0; j < plocha.GetLength(1); j++)
                {
                    if (plocha[i, j].jeZed)
                        g.FillRectangle(Brushes.Gray,
                            plocha[i, j].cesta[0].X, plocha[i, j].cesta[0].Y, 18, 18);
                    else if (plocha[i, j].jeStart)
                        g.FillRectangle(Brushes.Red,
                            plocha[i, j].cesta[0].X, plocha[i, j].cesta[0].Y, 18, 18);
                    else if (plocha[i, j].jeCil)
                        g.FillRectangle(Brushes.LightGreen,
                            plocha[i, j].cesta[0].X, plocha[i, j].cesta[0].Y, 18, 18);
                    else if (plocha[i, j].jeProhlednuto)
                        g.FillRectangle(Brushes.Orange,
                            plocha[i, j].cesta[0].X, plocha[i, j].cesta[0].Y, 18, 18);

                    g.DrawRectangle(Pens.Black, plocha[i, j].cesta[0].X, plocha[i, j].cesta[0].Y,
                        18, 18);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bunka cil = null;

            do
            {
                cil = hledejCil();
                this.Invalidate();
                MessageBox.Show("Hledam cil");

                if (prohlizeneBunky.Count == 0)
                {
                    MessageBox.Show("Cesta nenalezena");
                    return;
                }
            } while (cil == null);

            this.Invalidate();
            string cesta = null;

            foreach (Point p in cil.cesta)
            {
                cesta += "(" + p.X + ",";
                cesta += p.Y + ") ";
            }

            MessageBox.Show("Cesta: " + cesta);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < plocha.GetLength(0); i++)
            {
                for (int j = 0; j < plocha.GetLength(1); j++)
                {
                    if (e.X > (j + 1) * 20 && e.X < (j + 2) * 20)
                    {
                        if (e.Y > (i + 1) * 20 && e.Y < (i + 2) * 20)
                        {
                            if (plocha[i, j].jeZed)
                            {
                                plocha[i, j].jeZed = false;
                                this.Invalidate();
                            }
                            else if (!plocha[i, j].jeCil && !plocha[i, j].jeStart)
                            {
                                plocha[i, j].jeZed = true;
                                this.Invalidate();
                            }
                            break;
                        }
                    }
                }
            }
        }
    }

    class Bunka
    {
        public List<Point> cesta = new List<Point>();
        public bool jeStart, jeCil, jeProhlednuto, jeZed;
        public int x, y; //umisteni bunky v 2D poli

        public Bunka(Point souradnice, int x, int y)
        {
            this.cesta.Add(souradnice);
            this.jeStart = false;
            this.jeCil = false;
            this.jeZed = false;
            this.jeProhlednuto = false;
            this.x = x;
            this.y = y;
        }
    }
}
