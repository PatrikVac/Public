using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace Autobusy
{
    public partial class Form1 : Form
    {
        static char[] abeceda = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        int[,] matice = new int[abeceda.Length, abeceda.Length];
        static int size = 30, start;
        static List<Bod> body;
        static List<Bod> prujezdniBody = new List<Bod>();
        static List<Bod> cesta = new List<Bod>();
        List<Autobus> autobusy = new List<Autobus>();
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(size * 20 + 1, size * 20 + 1);
            vytvorPlochu();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public void vytvorPlochu()
        {
            for (int i = 0; i < matice.GetLength(0); i++)
            {
                for (int j = 0; j < matice.GetLength(1); j++)
                {
                    matice[i, j] = -1;
                }
            }
            OpenFileDialog opf = new OpenFileDialog();
            opf.FileName = "mapa.txt";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(opf.FileName);
                    string line = sr.ReadLine();
                    string[] value = line.Split(new string[] { "," }, StringSplitOptions.None);
                    char[] chars = new char[value.Length - 1];
                    for(int i = 1; i < value.Length; i++)
                        chars[i - 1] = Convert.ToChar(value[i]);
                    while (sr.Peek() >= 0)
                    {
                        line = sr.ReadLine();
                        value = line.Split(new string[] { "," }, StringSplitOptions.None);
                        int charc = CharToNum(Convert.ToChar(value[0]));
                        for(int i = 1; i < value.Length; i++)
                            matice[charc, CharToNum(chars[i - 1])] = Convert.ToInt32(value[i]);
                    }
                    sr.Close();
                }
                catch (Exception se)
                {
                    MessageBox.Show("Chyba! " + se);
                }
            }
            Invalidate();
            VytvorPoradi();
        }
        public void VytvorPoradi()
        {
            body = new List<Bod>();
            for (int i = 0; i < matice.GetLength(0); i++)
            {
                int poc = 0;
                for (int j = 0; j < matice.GetLength(1); j++)
                {
                    if(matice[i,j] == 1)
                        poc++;
                }
                if(poc != 0)
                    body.Add(new Bod(i,poc));
            }
            Vykresli();
        }
        public void Vykresli()
        {
            PointF stred = new PointF(ClientSize.Width / 2, ClientSize.Height / 2);
            for (int i = 0; i < body.Count; i++)
            {
                body[i].x = (int)(stred.X + Math.Cos(((360 / body.Count) * i) * (Math.PI / 180.0)) * 200);
                body[i].y = (int)(stred.Y + Math.Sin(((360 / body.Count) * i) * (Math.PI / 180.0)) * 200);
                body[i].rec = new Rectangle(body[i].x, body[i].y, size, size);
            }
            for (int i = 0; i < body.Count; i++)
            {
                for (int j = 0; j < matice.GetLength(1); j++)
                {
                    if (matice[body[i].znak, j] == 1)
                    {
                        foreach (Bod b in body)
                            if (b.znak == j)
                                body[i].spojen.Add(b);
                    }
                }
            }
            Invalidate();
        }
        static List<Cesta> projdute = new List<Cesta>();
        static List<Bod> NajdiCestu(Bod bod)
        {
            cesta.Add(bod);
            if (bod.spojen.Count == 1 && prujezdniBody.Count != 2) return null;
            foreach (Bod s in bod.spojen)
            {
                if (s.znak == start)
                {
                    if (cesta.Count == prujezdniBody.Count)
                    {
                        cesta.Add(s);
                        return cesta;
                    }
                }
                bool obsahuje = false;
                if (!cesta.Contains(s) && prujezdniBody.Contains(s))
                {
                    cesta.Add(s);
                    foreach (Cesta pc in projdute)
                        if (pc.Stejne(cesta))
                            obsahuje = true;
                    if (!obsahuje)
                    {
                        cesta.RemoveAt(cesta.Count - 1);
                        return NajdiCestu(s);
                    }
                    cesta.RemoveAt(cesta.Count - 1);
                }
            }
            projdute.Add(new Cesta(cesta));
            cesta.RemoveAt(cesta.Count - 1);
            if (cesta.Count == 0) return null;
            Bod posledni = cesta[cesta.Count - 1];
            cesta.Remove(posledni);
            return NajdiCestu(posledni);
        }
        public void NajdiCestu()
        {
            List<Bod> pom = new List<Bod>();
            start = prujezdniBody[0].znak;
            cesta = NajdiCestu(prujezdniBody[0]);
            if (cesta == null) { MessageBox.Show("Cesta nenalezena"); cesta = new List<Bod>(); return; }
            autobusy.Add(new Autobus(20, cesta));
            button1.Enabled = false;
            timer1.Start();
            Invalidate();
            
        }
        private int CharToNum(char ch)
        {
            for (int c = 0; c < abeceda.Length; c++)
            {
                if (abeceda[c] == ch)
                    return c;
            }
            return -1;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Bod b in body)
            {
                foreach (Bod x in b.spojen)
                {
                    g.DrawLine(Pens.Black, b.x + size / 2, b.y + size / 2, x.x + size / 2, x.y + size / 2);
                }
            }
            foreach (Bod b in body)
            {
                Image img;
                if (b.zastavka)
                {
                    img = Autobusy.Properties.Resources.bus_stop_icon;
                    g.DrawImage(img, b.rec);
                }
                else
                {
                    img = Autobusy.Properties.Resources.crossroad;
                    g.DrawImage(img, b.rec);
                }
                g.DrawString(abeceda[b.znak].ToString(), new Font("Arial", 10f), Brushes.Red, b.rec);
            }
            if (autobusy.Count > 0)
            {
                Image img = Autobusy.Properties.Resources.bus;
                foreach (Autobus a in autobusy)
                {
                    g.DrawImage(img, a.rec);
                    g.DrawString(a.cestujicich + " / " + a.kapacita, new Font("Arial", 12f), Brushes.Blue, a.rec);
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Bod b in body)
            {
                if (b.rec.Contains(e.Location))
                {
                    if (!b.zastavka)
                    {
                        b.zastavka = true;
                        prujezdniBody.Add(b);
                    }
                    else
                    {
                        b.zastavka = false;
                        prujezdniBody.Remove(b);
                    }
                }         
            }
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(prujezdniBody.Count > 1)
                NajdiCestu();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Autobus a in autobusy)
                a.Move();
            Invalidate();
        }
    }
    class Autobus
    {
        Bod from, to;
        public int cestujicich, kapacita, inter = 0;
        float deltaX, deltaY;
        public RectangleF rec;
        List<Bod> trasa = new List<Bod>();
        public Autobus(int kapacita, List<Bod> vstup)
        {
            this.kapacita = kapacita;
            string s = "";
            foreach (Bod b in vstup)
            {
                trasa.Add(b);
                s += b.znak;
            }
            MessageBox.Show(s);
            this.from = trasa[0];
            this.to = trasa[1];
            rec = new Rectangle(from.x + 15, from.y + 15, 60, 34);
        }

        public void Move()
        {
            float alfa = (float)(Math.Atan((float)(to.y - from.y) / (float)(to.x - from.x)) * 180.0 / Math.PI);
            if (to.x < from.x)
            {
                alfa = 180 + alfa;
            }
            float posun = 2f;
            deltaX = (float)Math.Cos(alfa * Math.PI / 180.0) * posun;
            deltaY = (float)Math.Sin(alfa * Math.PI / 180.0) * posun;
            rec.X += deltaX;
            rec.Y += deltaY;
            if (rec.IntersectsWith(to.rec))
            {
                inter++;
                if (inter + 1 == trasa.Count) { inter = 0;}
                this.from = trasa[0 + inter];
                this.to = trasa[1 + inter];
                Random rnd = new Random();
                cestujicich += rnd.Next(0, 20); // nastoupi
                cestujicich -= rnd.Next(0, 20); // vystoupi
                if (cestujicich < 0) cestujicich = 0;
                if (cestujicich > 20) cestujicich = 20;
            }
        }
    }
    class Cesta
    {
        List<Bod> path = new List<Bod>();
        public Cesta(List<Bod> nova)
        {
            nova.Reverse();
            foreach (Bod b in nova)
                path.Add(b);
        }
        public bool Stejne(List<Bod> por)
        {
            if (path == por)
                return true;
            return false;
        }
    }
    class Bod : IComparable<Bod>
    {
        public bool zastavka;
        public int x, y, sousednich, znak;
        public Rectangle rec;
        public List<Bod> spojen = new List<Bod>();
        public Bod[] sousedni = new Bod[6];

        public Bod(int x, int y, Rectangle rec)
        {
            this.x = x;
            this.y = y;
            this.rec = rec;
        }
        public Bod(int znak, int sousednich)
        {
            this.sousednich = sousednich;
            this.znak = znak;
            this.x = 0;
            this.y = 0;
        }
        public int CompareTo(Bod oth)
        {
            if(oth.sousednich == this.sousednich)
                return this.znak.CompareTo(oth.znak);
            return oth.sousednich.CompareTo(this.sousednich);
        }
    }
}
