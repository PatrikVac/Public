using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextovyEditor
{
    public partial class YNDialog : Form
    {
        public YNDialog(string zprava)
        {
            InitializeComponent();
            Oznameni.Text = zprava;
        }

        private void YNDialog_Load(object sender, EventArgs e)
        {

        }

        private void Oznameni_Click(object sender, EventArgs e)
        {

        }
    }
}
