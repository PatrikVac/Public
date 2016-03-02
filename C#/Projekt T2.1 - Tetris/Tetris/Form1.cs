using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tetris
{
    public partial class Form1 : Form
    {
        Size dilek;
        int uroven = 1, score = 0, radku = 0, pauza = 2,rychlost = 1000, velikostDilku = 30;
        Kostka veHre, nasledujici;
        private BunkaPlochy[,] plocha = new BunkaPlochy[12, 22];
        List<Zaznam> top = new List<Zaznam>();
        List<Point> ps = new List<Point>();
        Graphics gs;
        public Form1()
        {
            InitializeComponent();
            dilek = new Size(velikostDilku, velikostDilku);
            this.ClientSize = new Size(18 * dilek.Width, 22 * dilek.Height);
            UlozitButton.Location = new Point(13 * dilek.Width, 12 * dilek.Height);
            KonecButton.Location = new Point(13 * dilek.Width, 14 * dilek.Height);
            KonecButton.Size = UlozitButton.Size = new Size(4 * dilek.Width, dilek.Height);
            this.menuPanel.Width = 6 * dilek.Width;
            vytvoreniPlochy();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        /* Vytvoření herní plochy */
        private void vytvoreniPlochy()
        {
            for (int i = 0; i < plocha.GetLength(0); i++)
            {
                for (int j = 0; j < plocha.GetLength(1); j++)
                {
                    plocha[i, j] = new BunkaPlochy(i, j, dilek);
                    if (i == 0 || i == 11 || j == 0 || j == 21)
                    {
                        plocha[i, j].stena = true;
                        if(i == 21)
                        plocha[i, j].prazdna = false;
                    }
                }
            }
            Random rn = new Random();
            //veHre = new Kostka(dilek, rn.Next(0, 7));
            nasledujici = new Kostka(dilek, rn.Next(0, 7));
            nasledujici.DalsiUkazka();
        } 
        /* Vykreslení herní plochy */
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (pauza != 2)
            {
                g.FillPath(veHre.barva, veHre.path);
                g.DrawPath(Pens.Black, veHre.path);
            }
            for (int i = 0; i < plocha.GetLength(0); i++)
            {
                for (int j = 0; j < plocha.GetLength(1); j++)
                {
                    if (plocha[i, j].stena)
                    {
                        g.FillRectangle(Brushes.Gray, plocha[i, j].rec);
                        g.DrawRectangle(Pens.Black, plocha[i, j].rec);
                    }
                    else if(!plocha[i, j].prazdna)
                    {
                        if(plocha[i, j].barva == null)
                            plocha[i, j].VariableToLGB();
                        g.FillRectangle(plocha[i, j].barva, plocha[i, j].rec);
                        g.DrawRectangle(Pens.Black, plocha[i, j].rec);
                    }
                }
            }
            Rectangle rect = new Rectangle(new Point(13 * dilek.Width, dilek.Height), new Size(4 * dilek.Width, 5 * dilek.Height));
            g.FillRectangle(new LinearGradientBrush(rect,Color.Azure, Color.RoyalBlue, LinearGradientMode.Vertical), rect);
            g.DrawRectangle(new Pen(Brushes.CornflowerBlue,5), rect);
            g.FillPath(nasledujici.barva, nasledujici.path);
            g.DrawPath(Pens.Black, nasledujici.path);
            g.DrawString("Score: " + score.ToString(), new Font("Arial", 17f, FontStyle.Bold), Brushes.Wheat, 13 * dilek.Width, 6 * dilek.Height + 10);
            g.DrawString("Řad: " + radku.ToString(), new Font("Arial", 17f, FontStyle.Bold), Brushes.Wheat, 13 * dilek.Width, 7 * dilek.Height + 10);
            g.DrawString("Úroveň:", new Font("Arial", 25f, FontStyle.Bold), Brushes.WhiteSmoke, 13 * dilek.Width - 10, 8 * dilek.Height + 10);
            g.DrawString(uroven.ToString(), new Font("Arial", 30f, FontStyle.Bold), new HatchBrush(HatchStyle.Weave, Color.Red, Color.DarkBlue), 14 * dilek.Width + 10, 10 * dilek.Height);
            gs = g;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int novaUroven = (int)Math.Round((decimal)score / 1000) + 1;
            if (uroven < novaUroven)
            {
                uroven = novaUroven;
                rychlost = rychlost - ((uroven + obtiznost.Value - 1) * 10);
                if (rychlost <= 0)
                    rychlost = 1;
                timer1.Interval = rychlost;
            }
            veHre.Posun();
            foreach (Point rc in veHre.Visible(gs))
            {
                for (int o = 0; o < plocha.GetLength(0); o++)
                {
                    for (int u = 0; u < plocha.GetLength(1); u++)
                    {
                        if (plocha[o, u].rec.Contains(rc))
                        {
                            if (!plocha[o, u].prazdna)
                            {
                                veHre.PosunZpet();
                                foreach (Point pr in veHre.Visible(gs))
                                {
                                    for (int i = 0; i < plocha.GetLength(0); i++)
                                    {
                                        for (int j = 0; j < plocha.GetLength(1); j++)
                                        {
                                            if (plocha[i, j].rec.Contains(pr))
                                            {
                                                if (j < 2) { KonecHry(); return; }
                                                plocha[i, j].prazdna = false;
                                                plocha[i, j].barva = veHre.barva;
                                                plocha[i, j].LGBToVariable();
                                            }
                                        }
                                    }
                                }
                                Random rn = new Random();
                                veHre = new Kostka(dilek, nasledujici.typ);
                                nasledujici = new Kostka(dilek, rn.Next(0, 7));
                                nasledujici.DalsiUkazka();
                                Invalidate();
                                kontrolaRady();
                                return;
                            }
                        }
                    }
                }
            }
            if ((veHre.path.GetBounds().Y + veHre.path.GetBounds().Height) / dilek.Height > 21)
            {
                veHre.PosunZpet();
                foreach (Point rc in veHre.Visible(gs))
                {
                    for (int i = 0; i < plocha.GetLength(0); i++)
                    {
                        for (int j = 0; j < plocha.GetLength(1); j++)
                        {
                            if (plocha[i, j].rec.Contains(rc))
                            {
                                plocha[i, j].prazdna = false;
                                plocha[i, j].barva = veHre.barva;
                                plocha[i, j].LGBToVariable();
                            }
                        }
                    }
                }
                Random rn = new Random();
                veHre = new Kostka(dilek, nasledujici.typ);
                nasledujici = new Kostka(dilek, rn.Next(0, 7));
                nasledujici.DalsiUkazka();
            }
            kontrolaRady();
            Invalidate();
        }
        /* Události kláves */
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Region rg = new Region(veHre.path);
            if (e.KeyCode == Keys.Up && pauza == 0)
            {
                veHre.Rotovat();
                if (Math.Round(veHre.path.GetBounds().X) / dilek.Width < 0.9 || Math.Round((Math.Round(veHre.path.GetBounds().X) + veHre.path.GetBounds().Width) / dilek.Width) > 11 || !vPoradku() || veHre.path.GetBounds().Bottom > dilek.Height * 21)
                    veHre.RotovatZpet();
                Invalidate();
            }
            if (e.KeyCode == Keys.Left && pauza == 0)
            {
                veHre.Vlevo();
                if (Math.Round(veHre.path.GetBounds().X) / dilek.Width < 0.9 || !vPoradku())
                    veHre.Vpravo();
                Invalidate();
            }
            if (e.KeyCode == Keys.Right && pauza == 0)
            {
                veHre.Vpravo();
                if (Math.Round((Math.Round(veHre.path.GetBounds().X) + veHre.path.GetBounds().Width) / dilek.Width) > 11 || !vPoradku())
                    veHre.Vlevo();
                Invalidate();
            }
            if (e.KeyCode == Keys.Down && pauza == 0)
                timer1.Interval = rychlost;

            if (e.KeyCode == Keys.Space)
            {
                if (pauza == 0)
                {
                    timer1.Stop();
                    UlozitButton.Visible = KonecButton.Visible = UlozitButton.Enabled = KonecButton.Enabled = true;
                    pauza++;
                }
                else if (pauza == 1) { UlozitButton.Visible = KonecButton.Visible = UlozitButton.Enabled = KonecButton.Enabled = false; timer1.Start(); pauza--; }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                if (rychlost > 1)
                    timer1.Interval = rychlost / 10;
        }
        /* Kontrola interselectu GraphicsPathu s okolím */
        private bool vPoradku()
        {
            foreach (Point rc in veHre.Visible(gs))
            {
                for (int o = 0; o < plocha.GetLength(0); o++)
                {
                    for (int u = 0; u < plocha.GetLength(1); u++)
                    {
                        if (plocha[o, u].rec.Contains(rc))
                        {
                            if (!plocha[o, u].prazdna)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        /* Kontrola zaplněných řad, mizení a sesunutí */
        private void kontrolaRady()
        {
            bool[] rada = new bool[plocha.GetLength(1)];
            int rad = 0;
            for (int i = 1; i < plocha.GetLength(1) - 1; i++)
            {
                rada[i] = true;
                for (int j = 1; j < plocha.GetLength(0) - 1; j++)
                {  
                    if (plocha[j, i].prazdna)
                    {
                        rada[i] = false;
                        break;
                    }
                }
                if (rada[i]) rad++;
            }
            switch (rad)
            {
                case 1: score += (uroven + obtiznost.Value - 1) * 40 + 40; break;
                case 2: score += (uroven + obtiznost.Value - 1) * 100 + 100; break;
                case 3: score += (uroven + obtiznost.Value - 1) * 300 + 300; break;
                case 4: score += (uroven + obtiznost.Value - 1) * 1200 + 1200; break;
            }
            radku += rad;
            for (int i = 1; i < plocha.GetLength(1) - 1; i++)
            {
                if (rada[i])
                {
                    for (int pi = i; pi > 1; pi--)
                    {
                        for (int j = 1; j < (plocha.GetLength(0) - 1); j++)
                        {
                            plocha[j,pi].prazdna = plocha[j,pi - 1].prazdna;
                            plocha[j,pi].barva = plocha[j,pi - 1].barva;
                        }
                    }
                }
            }
            Invalidate();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            obtiznostText.Text = obtiznost.Value.ToString();
        }
        /* Start nové hry */
        private void NovaHraButton_Click(object sender, EventArgs e)
        {
            Random rn = new Random();
            veHre = new Kostka(dilek, rn.Next(0, 7));
            //timer1.Interval = rychlost = 1000 - 100 * obtiznost.Value;
            menuPanel.Enabled = false;
            menuPanel.Hide();
            pauza = 0;
            timer1.Start(); 
        }
        /* Vypsání TOP výsledků */
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                top.Sort();
                string s = "Pořadí\tJméno\t\tScore\t\tŘad\n_____________________________________________________________\n";
                for (int i = 0; i < (top.Count < 10 ? top.Count : 10); i++)
                {
                    s += "     " + (i + 1) + ".\t" + top[i].jmeno + "\t\t" + top[i].score + "\t\t  " + top[i].rad + "\n";
                }
                MessageBox.Show(s, "Top výsledky");
            }
            catch (Exception se)
            {
                MessageBox.Show("Chyba! \n" + se);
            }
        }
        /* Ukončení bežící nebo prohrané hry */
        public void KonecHry()
        {
            pauza = 2;
            timer1.Stop();
            try
            {
                if (score > 0)
                {
                    JmenoDialog jd = new JmenoDialog();
                    if (jd.ShowDialog() == DialogResult.OK)
                        top.Add(new Zaznam(jd.textBox1.Text, this.score, this.radku));
                }
                score = 0;
                radku = 0;
                rychlost = 1000;
                uroven = 1;
                vytvoreniPlochy();
                menuPanel.Enabled = true;
                menuPanel.Show();
                UlozitButton.Visible = KonecButton.Visible = UlozitButton.Enabled = KonecButton.Enabled = false;
                Invalidate();
            }
            catch (Exception e)
            {
                MessageBox.Show("Chyba! \n" + e);
            }
        }
        /* Serializace score */
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (top.Count > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                Stream s = File.Create("score.bin");
                bf.Serialize(s, top);
                s.Close();
            }
        }
        /* Deserializace / načtení score */
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("score.bin"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Stream s = File.Open("score.bin", FileMode.Open);
                top = (List<Zaznam>)bf.Deserialize(s);
                s.Close();
            }
        }
        /* Uložení spuštěné hry */
        private void UlozitButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Tetris save|*.tetris";
            sfd.Title = "Uložit hru";
            sfd.FileName = "Game";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bf = new BinaryFormatter();
                Stream s = File.Create(sfd.FileName);
                bf.Serialize(s, new Hra(plocha, veHre, nasledujici, score, uroven, radku, rychlost, obtiznost.Value));
                s.Close();
            }
        }
        /* Předčasné ukončení hry */
        private void KonecButton_Click(object sender, EventArgs e)
        {
            KonecHry();
        }
        /* Načtení uložené hry */
        private void PosledniButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Tetris save|*.tetris";
            ofd.Title = "Načíst hru";
            ofd.FileName = "Game";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Hra h;
                BinaryFormatter bf = new BinaryFormatter();
                Stream s = File.Open(ofd.FileName, FileMode.Open);
                h = (Hra)bf.Deserialize(s);
                s.Close();
                plocha = h.plocha;
                score = h.score;
                radku = h.radku;
                obtiznost.Value = h.obtiznost;
                veHre = new Kostka(dilek, h.K1.typ);
                //------
                Matrix m = new Matrix();
                m.Translate(h.K1.pos.X - veHre.path.GetBounds().X, h.K1.pos.Y - veHre.path.GetBounds().Y);
                veHre.stred = new PointF(h.K1.stred.X, h.K1.stred.Y);
                veHre.path.Transform(m);
                while (h.K1.otoceno > 0)
                {
                    veHre.Rotovat();
                    h.K1.otoceno--;
                }
                //----
                nasledujici = new Kostka(dilek, h.K2.typ);
                nasledujici.DalsiUkazka();
                timer1.Interval = rychlost = h.rychlost;
                menuPanel.Enabled = false;
                menuPanel.Hide();
                pauza = 0;
                timer1.Start();
                Invalidate();
            }
        }
    }
    [Serializable]
    class BunkaPlochy 
    {
        public bool prazdna, stena;
        public int x, y;
        public Rectangle rec;
        Color[] LC;
        RectangleF LGBrec;
        [NonSerialized]
        public LinearGradientBrush barva = new LinearGradientBrush(new Point(0, 0), new Point(5, 5), Color.Orange, Color.OrangeRed);

        public BunkaPlochy(int x, int y, Size velikost)
        {
            barva = new LinearGradientBrush(new Point(0, 0), new Point(5, 5), Color.Orange, Color.OrangeRed);
            rec = new Rectangle(x * velikost.Width, y * velikost.Height, velikost.Width, velikost.Height);
            this.prazdna = true;
            this.stena = false;
            this.x = x;
            this.y = y;
        }
        public void LGBToVariable()
        {
            LC = barva.LinearColors;
            LGBrec = barva.Rectangle;
        }
        public void VariableToLGB()
        {
            barva = new LinearGradientBrush(new PointF(LGBrec.X, LGBrec.Y), new PointF(LGBrec.Right, LGBrec.Bottom), LC[0], LC[1]);
        }
    }
    [Serializable]
    class Kostka
    {
        [NonSerialized]
        public LinearGradientBrush barva;
        [NonSerialized]
        public GraphicsPath path = new GraphicsPath();
        public PointF stred, pos;
        [NonSerialized]
        Size dilek;
        public int typ, otoceno = 0;
        public Kostka(Size dilek,int typ)
        {
            this.typ = typ;
            this.dilek = dilek;
            stred = new PointF(dilek.Width * 6 + dilek.Width / 2, dilek.Height / 2);
            if (typ == 1)
            {
                barva = new LinearGradientBrush(new Point(0, 0), new Point(5, 5), Color.Orange, Color.OrangeRed);
                path.AddRectangle(new Rectangle(dilek.Width * 6, 0, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 7, dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, - dilek.Height, dilek.Width, dilek.Height));
            }
            else if (typ == 2)
            {
                barva = new LinearGradientBrush(new Point(0, 0), new Point(5, 5), Color.Blue, Color.Aqua);
                path.AddRectangle(new Rectangle(dilek.Width * 6, 0, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 5, dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, -dilek.Height, dilek.Width, dilek.Height));
            }
            else if (typ == 3)
            {
                barva = new LinearGradientBrush(new Point(0, 0), new Point(5, 5), Color.GreenYellow, Color.Green);
                path.AddRectangle(new Rectangle(dilek.Width * 5, 0, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 5, -dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, 0, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, dilek.Height, dilek.Width, dilek.Height));
            }
            else if (typ == 4)
            {
                barva = new LinearGradientBrush(new Point(0, 0), new Point(5, 5), Color.Red, Color.DarkRed);
                path.AddRectangle(new Rectangle(dilek.Width * 6, 0, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, -dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 5, 0, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 5, dilek.Height, dilek.Width, dilek.Height));
            }
            else if (typ == 5)
            {
                barva = new LinearGradientBrush(new Point(0, 0), new Point(5, 5), Color.Purple, Color.MediumPurple);
                path.AddRectangle(new Rectangle(dilek.Width * 6, 0, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 7, 0, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, -dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, dilek.Height, dilek.Width, dilek.Height));
            }
            else if (typ == 6)
            {
                barva = new LinearGradientBrush(new Point(0, 0), new Point(5, 5), Color.Yellow, Color.FromArgb(100, Color.Yellow));
                path.AddRectangle(new Rectangle(dilek.Width * 5, 0, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 5, -dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 5, dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, -dilek.Height, dilek.Width, dilek.Height));
            }
            else
            {
                barva = new LinearGradientBrush(new Point(0, 0), new Point(5, 5), Color.Cyan, Color.White);
                path.AddRectangle(new Rectangle(dilek.Width * 6, 0, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, -dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, dilek.Height, dilek.Width, dilek.Height));
                path.AddRectangle(new Rectangle(dilek.Width * 6, dilek.Height * 2, dilek.Width, dilek.Height));
            }
        }
        public void Rotovat()
        {
            Matrix m = new Matrix();
            m.RotateAt(90, stred);
            path.Transform(m);
            otoceno++;
        }
        public void RotovatZpet()
        {
            Matrix m = new Matrix();
            m.RotateAt(-90, stred);
            path.Transform(m);
            otoceno--;
        }
        public void Posun()
        {
            Matrix m = new Matrix();
            m.Translate(0, dilek.Width);
            stred = new PointF(stred.X, stred.Y + dilek.Height);
            path.Transform(m);
            pos = new PointF(path.GetBounds().X, path.GetBounds().Y);
        }
        public void PosunZpet()
        {
            Matrix m = new Matrix();
            m.Translate(0, -dilek.Height);
            stred = new PointF(stred.X, stred.Y - dilek.Height);
            path.Transform(m);
            pos = new PointF(path.GetBounds().X, path.GetBounds().Y);
        }
        public void Vlevo()
        {
            Matrix m = new Matrix();
            stred = new PointF(stred.X - dilek.Width, stred.Y);
            m.Translate(-dilek.Width, 0);
            path.Transform(m);
            pos = new PointF(path.GetBounds().X, path.GetBounds().Y);
        }
        public void Vpravo()
        {
            Matrix m = new Matrix();
            stred = new PointF(stred.X + dilek.Width, stred.Y);
            m.Translate(dilek.Width, 0);
            path.Transform(m);
            pos = new PointF(path.GetBounds().X, path.GetBounds().Y);
        }
        public void DalsiUkazka()
        {
            Matrix m = new Matrix();
            m.Translate(14 * dilek.Width - path.GetBounds().X, 3 * dilek.Height);
            if (typ == 0) m.Translate(dilek.Width / 2, -dilek.Height / 2);
            path.Transform(m);
        }
        public List<Point> Visible(Graphics g)
        {
            List<Point> rcs = new List<Point>();
            int sz = dilek.Width;
            if (path.IsVisible(stred, g)) rcs.Add(new Point((int)stred.X, (int)stred.Y));
            if (path.IsVisible(new Point((int)stred.X + sz, (int)stred.Y), g)) rcs.Add(new Point((int)stred.X + sz, (int)stred.Y));
            if (path.IsVisible(new Point((int)stred.X, (int)stred.Y + sz), g)) rcs.Add(new Point((int)stred.X, (int)stred.Y + sz));
            if (path.IsVisible(new Point((int)stred.X + sz, (int)stred.Y + sz), g)) rcs.Add(new Point((int)stred.X + sz, (int)stred.Y + sz));
            if (path.IsVisible(new Point((int)stred.X - sz, (int)stred.Y), g)) rcs.Add(new Point((int)stred.X - sz, (int)stred.Y));
            if (path.IsVisible(new Point((int)stred.X, (int)stred.Y - sz), g)) rcs.Add(new Point((int)stred.X, (int)stred.Y - sz));
            if (path.IsVisible(new Point((int)stred.X - sz, (int)stred.Y - sz), g)) rcs.Add(new Point((int)stred.X - sz, (int)stred.Y - sz));
            if (path.IsVisible(new Point((int)stred.X - sz, (int)stred.Y + sz), g)) rcs.Add(new Point((int)stred.X - sz, (int)stred.Y + sz));
            if (path.IsVisible(new Point((int)stred.X + sz, (int)stred.Y - sz), g)) rcs.Add(new Point((int)stred.X + sz, (int)stred.Y - sz));
            if (path.IsVisible(new Point((int)stred.X + sz * 2, (int)stred.Y), g)) rcs.Add(new Point((int)stred.X + sz * 2, (int)stred.Y));
            if (path.IsVisible(new Point((int)stred.X - sz * 2, (int)stred.Y), g)) rcs.Add(new Point((int)stred.X - sz * 2, (int)stred.Y));
            if (path.IsVisible(new Point((int)stred.X, (int)stred.Y - sz * 2), g)) rcs.Add(new Point((int)stred.X, (int)stred.Y - sz * 2));
            if (path.IsVisible(new Point((int)stred.X, (int)stred.Y + sz * 2), g)) rcs.Add(new Point((int)stred.X, (int)stred.Y + sz * 2));
            return rcs;
        }
    }
    [Serializable]
    class Zaznam : IComparable<Zaznam> // Záznam ve score
    {
        public int score, rad;
        public string jmeno;
        public Zaznam(string jmeno, int score, int rad)
        {
            this.score = score;
            this.jmeno = jmeno;
            this.rad = rad;
        }
        public int CompareTo(Zaznam oth)
        {
            return oth.score.CompareTo(this.score);
        }
    }
    [Serializable]
    class Hra // Serializuje se
    {
        public int uroven, score, radku, rychlost, obtiznost;
        public BunkaPlochy[,] plocha;
        public Kostka K1, K2;
        public Hra(BunkaPlochy[,] plocha, Kostka K1, Kostka K2, int score, int uroven, int radku, int rychlost, int obtiznost)
        {
            this.K1 = K1;
            this.K2 = K2;
            this.plocha = plocha;
            this.score = score;
            this.uroven = uroven;
            this.radku = radku;
            this.rychlost = rychlost;
            this.obtiznost = obtiznost;
        }
    }
}
