using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Vlacky
{
    public partial class Form1 : Form
    {
        List<Vlak> vlaky = new List<Vlak>();
        List<Kolej> koleje = new List<Kolej>();
        List<Thread> thready = new List<Thread>();
        Thread tS; // thread pro speciální vlak
        Vlak poslatZ5, extra; // vlaky které se budou vracet zpátky do zastávky
        bool chyba = false;
        public Form1()
        {
            /* DRAHY */
            // "STANICE_PRAVA", "STANICE_LEVA", RYCHLOST, Y - VYSKA KOLEJE
            koleje.Add(new Kolej("A", "B", 60, 122));
            koleje.Add(new Kolej("B", "C", 90, 132));
            koleje.Add(new Kolej("B", "C", 90, 115));
            koleje.Add(new Kolej("C", "D", 60, 122));
            koleje.Add(new Kolej("D", "E", 60, 122));
            /* VLAKY */
            for (int i = 0; i < 4; i++)
                vlaky.Add(new Vlak(koleje));
            /* VLÁKNA */
            for (int i = 0; i < 4; i++)
            {
                Thread t = new Thread(vlaky[i].VysliVlak);
                t.IsBackground = true;
                thready.Add(t);
            }
            /* Vyjetí v intervalu 20 s */
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* VLAKY BUDU VYPRAVENY VE 20 vteřinovém INTERVALU */
                foreach (Thread t in thready)
                {
                    t.Start();
                    Thread.Sleep(20000);
                }
            }).Start();
            /* FORM */
            InitializeComponent();
            timer1.Start();
            timer2.Start();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)// vykreslování
        {
            e.Graphics.DrawImage(global::Vlacky.Properties.Resources.projekt, new Point(10, 110));
            foreach (Vlak v in vlaky)
                if (!v.znic)
                    e.Graphics.DrawImage(global::Vlacky.Properties.Resources.vlak, v.pozice);
        }
        private void timer1_Tick(object sender, EventArgs e)// překreslování
        {
            Invalidate();
        } 
        private void Extra_B_Click(object sender, EventArgs e) // pro vyslání spec. vlaku
        { 
            if (!chyba) // pokud je nekde kolize nemůže vyslat další spec. vlak
            {
                Vlak vS;
                vlaky.Add(vS = new Vlak(Extra_1.Text, Extra_2.Text, koleje));
                tS = new Thread(vS.VysliSpecialniVlak);
                tS.IsBackground = true;
                tS.Start();
            }
        }
        private void AlarmB_Click(object sender, EventArgs e)//potvrzení alarmu
        {
            extra.vyjimka = poslatZ5.vyjimka = 2; // vrátí vlaky zpátky do zastávky
            AlarmB.Hide();
        }
        private void timer2_Tick(object sender, EventArgs e)//kontrola kolizí
        {
            if (!chyba) // pokud už byla chyba objevena nebude kontrolovat
                foreach (Vlak v in vlaky)
                {
                    foreach (Vlak v2 in vlaky)
                    { // porovná mezi sebou všechny vlaky jestli nejsou na stejné trati
                        if (v != v2 && v.trat != null && v.trat == v2.trat)
                        {
                            chyba = true;
                            poslatZ5 = v;
                            extra = v2;
                            v2.vyjimka = v.vyjimka = 1; // zastaví vlaky
                            AlarmB.Show();
                            break;
                        }
                    } if (chyba) break; // při kolizi ukončí procházení
                }
            try
            {
                if (poslatZ5.vyjimka == 3 && extra.vyjimka == 3)
                {
                    extra.vyjimka = poslatZ5.vyjimka = 0;
                    chyba = false;
                    //vlaky.Remove(extra);
                }
            }
            catch { }
        }
    }
    class Stanice // x-souřadnice stanice jsou přiděleny názvu stanice
    {
        Dictionary<string, int> stanice_DB = new Dictionary<string, int>();
        public int GetX(string stanice)// vrátí x-souřadnici stanice
        {/* X - souřadnice stanic */
            stanice_DB.Add("A", 20);
            stanice_DB.Add("B", 150);
            stanice_DB.Add("C", 270);
            stanice_DB.Add("D", 400);
            stanice_DB.Add("E", 510);
            return stanice_DB[stanice];
        }
    }
    class Vlak
    {
        public List<Kolej> koleje; // list dostupných kolejí
        public string stanice = "A", cilova, trat = null;
        public bool smer = true, znic = false; // smer 0 - vpravo, 1 - vlevo
        public int vyjimka = 0; // jaký pohyb vlaky vykonávají (při kolizi)
        public PointF pozice = new PointF(10, 122); // pozice vlaku
        public Vlak(List<Kolej> koleje) // konstruktor pro běžná vlak
        {
            this.pozice = new PointF(new Stanice().GetX(stanice), pozice.Y);
            this.koleje = koleje;
        }
        public Vlak(string pocatecni, string cilova, List<Kolej> koleje)// pro spec. vlak
        {
            this.cilova = cilova;
            this.stanice = pocatecni;
            this.pozice = new PointF(new Stanice().GetX(stanice), pozice.Y);
            this.koleje = koleje;
            this.znic = false;
        }
        public float Pos // X - pozice vlaku
        {
            set { this.pozice = new PointF(value, this.pozice.Y); }
            get { return this.pozice.X; }
        }
        public void VysliVlak() // vyšle obyčejný vlak
        {
            if (this.smer) // jede smerem vpravo
            {// projíždí postupně všechny koleje a na každé koleji posune vlak o její úsek
                for (int i = 0; i < koleje.Count; i++) 
                {
                    if (i == 2) i++; // přeskočí 2-kolejku
                    if (!koleje[i].obsazena) // jestli neni trat už obsazena
                    {
                        koleje[i].obsazena = true;
                        this.pozice = new PointF((float)(new Stanice().GetX(koleje[i].stanice_vlevo)), (float)koleje[i].y);
                        int cil = new Stanice().GetX(koleje[i].stanice_vpravo);
                        float rychlost = koleje[i].rychlost / 60;
                        trat = i.ToString(); // označí na jaké je trati
                        while (this.Pos < cil)
                        {
                            if (vyjimka == 0) // obyčejný pohyb dopředu
                            {
                                this.Pos += rychlost;
                                Thread.Sleep(100);
                            }
                            else if (vyjimka == 2) // pokud se vlak musí vrátit do stanice
                            {
                                while (this.Pos >= new Stanice().GetX(koleje[i].stanice_vlevo))
                                {
                                    this.Pos -= rychlost;
                                    Thread.Sleep(100);
                                }
                                vyjimka = 3; // vlak je ke stanici
                            }
                        }
                        this.trat = null; // neobsazuje trat a čeká ve stanici
                        koleje[i].obsazena = false;
                    }
                    else i--;
                }
                smer = false; // když dojede nakonec tak zmení směr
                VysliVlak();
            }
            else // jede smerem vlevo
            {
                for (int i = koleje.Count - 1; i >= 0; i--)
                {
                    if (i == 1) i--;
                    if (!koleje[i].obsazena)
                    {
                        koleje[i].obsazena = true;
                        this.pozice = new PointF((float)(new Stanice().GetX(koleje[i].stanice_vpravo)), (float)koleje[i].y);
                        int cil = new Stanice().GetX(koleje[i].stanice_vlevo);
                        float rychlost = koleje[i].rychlost / 60;
                        trat = i.ToString();
                        while (this.Pos > cil)
                        {
                            if (vyjimka == 0)
                            {
                                this.Pos -= rychlost;
                                Thread.Sleep(100);
                            }
                            else if (vyjimka == 2)
                            {
                                while (this.Pos <= new Stanice().GetX(koleje[i].stanice_vpravo))
                                {
                                    this.Pos += rychlost;
                                    Thread.Sleep(100);
                                } vyjimka = 3;
                            }
                        }
                        this.trat = null;
                        koleje[i].obsazena = false;
                    }
                    else i++;
                }
                smer = true;
                VysliVlak();
            }
        }
        public void VysliSpecialniVlak()// vysle extra vlak
        {
            /* určení směru */
            if (new Stanice().GetX(stanice) > new Stanice().GetX(cilova)) // smer vlevo
                smer = false;
            else if (new Stanice().GetX(stanice) == new Stanice().GetX(cilova))
            { MessageBox.Show("Stanice nemůžou být stejné!"); Thread.CurrentThread.Abort(); }
            else // smer vpravo
                smer = true;
            int min = 0, max= 0;
            /* určí odkud kam pojede */
            foreach (Kolej k in koleje)
            {
                if (smer)
                {
                    if (k.stanice_vlevo == stanice)
                        min = koleje.IndexOf(k);
                    if (k.stanice_vpravo == cilova)
                        max = koleje.IndexOf(k);
                    if (min == 2) min--;
                }
                else
                {
                    if (k.stanice_vlevo == cilova)
                        min = koleje.IndexOf(k);
                    if (k.stanice_vpravo == stanice)
                        max = koleje.IndexOf(k);
                }
            }
            if (this.smer) // jede smerem vpravo
            {
                for (int i = min; i < (max + 1); i++)
                {
                    if (i == 2) i++;
                    this.pozice = new PointF((float)(new Stanice().GetX(koleje[i].stanice_vlevo)), (float)koleje[i].y);
                    int cil = new Stanice().GetX(koleje[i].stanice_vpravo);
                    float rychlost = koleje[i].rychlost / 60;
                    trat = i.ToString();
                    while (this.Pos < cil)
                    {
                        if (vyjimka == 0)
                        {
                            this.Pos += rychlost;
                            Thread.Sleep(100);
                        }
                        else if (vyjimka == 2)
                        {
                            while (this.Pos >= new Stanice().GetX(koleje[i].stanice_vlevo))
                            {
                                this.Pos -= rychlost;
                                Thread.Sleep(100);
                            }
                            break;
                        }
                    }
                    trat = null;
                }
            }
            else // jede smerem vlevo
            {
                for (int i = max; i >= min; i--)
                {
                    if (i == 1) i--;
                    this.pozice = new PointF((float)(new Stanice().GetX(koleje[i].stanice_vpravo)), (float)koleje[i].y);
                    int cil = new Stanice().GetX(koleje[i].stanice_vlevo);
                    float rychlost = koleje[i].rychlost / 60;
                    trat = i.ToString();
                    while (this.Pos > cil)
                    {
                        if (vyjimka == 0)
                        {
                            this.Pos -= rychlost;
                            Thread.Sleep(100);
                        }
                        else if (vyjimka == 2)
                        {
                            while (this.Pos <= new Stanice().GetX(koleje[i].stanice_vpravo))
                            {
                                this.Pos += rychlost;
                                Thread.Sleep(100);
                            }
                            break;
                        }
                    }
                    trat = null;
                }
            }
            znic = true; vyjimka = 3;
            Thread.CurrentThread.Abort();
        }
    }
    class Kolej // mezi jakými je stanicemi, rychlost tratě, y-souřadnice kvůli 2 - kolejce a její obsazení
    {
        public string stanice_vpravo, stanice_vlevo;
        public int rychlost, y;
        public bool obsazena = false;
        public Kolej(string stanice_vlevo,string stanice_vpravo,int rychlost,int y)
        {
            this.rychlost = rychlost;
            this.stanice_vlevo = stanice_vlevo;
            this.stanice_vpravo = stanice_vpravo;
            this.y = y;
        }
    }
}
