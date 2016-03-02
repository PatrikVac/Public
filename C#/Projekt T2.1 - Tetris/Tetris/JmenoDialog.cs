using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Tetris
{
    public partial class JmenoDialog : Form
    {
        public JmenoDialog()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && !textBox1.Text.Contains('='))
                button1.Enabled = true;
            else button1.Enabled = false;
        }
    }

}
