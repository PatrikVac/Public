using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kulicka
{
    public delegate void Delegat();
    public partial class Form1 : Form
    {
        Kulicka koule;
        Delegat posunKulicky;
        public Form1()
        {
            InitializeComponent();
            koule = new Kulicka(ClientSize.Width / 2, ClientSize.Height / 2);
            posunKulicky = new Delegat(koule.zalozeni);
        }

        private void Up_Click(object sender, EventArgs e)
        {
            posunKulicky += koule.Nahoru;
            Invalidate();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            posunKulicky += koule.Dolu;
            Invalidate();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            posunKulicky += koule.Vpravo;
            Invalidate();
        }

        private void Left_Click(object sender, EventArgs e)
        {
            posunKulicky += koule.Vlevo;
            Invalidate();
        }

        private void Posunout_Click(object sender, EventArgs e)
        {
                posunKulicky();
                posunKulicky = new Delegat(koule.zalozeni);
                Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, koule.kulicka);
        }
    }
    class Kulicka
    {
        public Rectangle kulicka;
        public Kulicka(int x, int y)
        {
            kulicka = new Rectangle(x, y, 30, 30);
        }
        public void zalozeni()
        {
            
        }
        public void Vlevo()
        {
            kulicka.X -= 10;
        }
        public void Vpravo()
        {
            kulicka.X += 10;
        }
        public void Nahoru()
        {
            kulicka.Y -= 10;
        }
        public void Dolu()
        {
            kulicka.Y += 10;
        }
    }
}
