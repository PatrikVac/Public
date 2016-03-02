using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KombCisla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        static long Factorial(long x)
        {
            if (x <= 1)
                return 1;
            else
                return x * Factorial(x - 1);
        }

        static long Combinatorial(long a, long b)
        {
            if (a <= 1)
                return 1;
            if(a <= 65 && b <= 65 && (a-b) <= 65)
                return Factorial(a) / (Factorial(b) * Factorial(a - b));
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long n = Convert.ToInt64(nko.Text);
            long k = Convert.ToInt64(Kcko.Text);

            vysledek.Text = Combinatorial(n, k).ToString();
        }
    }
}
