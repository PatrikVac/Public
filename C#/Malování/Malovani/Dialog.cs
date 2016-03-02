using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Malovani
{
    public partial class Dialog : Form
    {
        public Dialog(string Text, string Oznam, string b1, string b2, string b3)
        {
            InitializeComponent();
            this.Text = Text;
            label1.Text = Oznam;
            button1.Text = b1;
            button2.Text = b2;
            button3.Text = b3;
        }
    }
}
