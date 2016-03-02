using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjektKatastr
{
    public partial class OmezeniSprava : Form
    {
        public OmezeniSprava()
        {
            InitializeComponent();
        }

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            if (check1.Checked)
            {
                group2.Enabled = check2.Checked = false;
                group1.Enabled = true;
            }
            else
            {
                group1.Enabled = check1.Checked = false;
                group2.Enabled = true;
            }
        }
        private void KontrolaVyplneni(object sender, EventArgs e)
        {
            bool povolit = true;
            if (check1.Checked)
            {
                if (lbl1.Text == "") povolit = false;
                if (combo1.Text == "") povolit = false;
            }
            else
            {
                if (lbl2.Text == "") povolit = false;
                if (combo2.Text == "") povolit = false;
            }
            if (lbl5.Text == "0") povolit = false;
            btn2.Enabled = povolit;
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            DGVDialog dvg = new DGVDialog("SELECT ID, Cislo as 'Číslo parcely',Vymera as 'Výměra', Druh, KatastralniUzemi as 'Katastrální území', Obec, CastObce as 'Část obce' FROM Parcely WHERE Omezeni IS NULL");
            if (dvg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lbl1.Text = dvg.DGVR.Cells["ID"].Value.ToString();
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            DGVDialog dvg = new DGVDialog("SELECT ID, ID_Parcela as 'Na parcele s ID',Cislo_Popisne as 'Číslo popisné', Typ FROM Stavby WHERE Omezeni IS NULL");
            if (dvg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lbl2.Text = dvg.DGVR.Cells["ID"].Value.ToString();
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            DGVDialog dvg = new DGVDialog("SELECT ID,Jmeno as 'Jméno', Prijmeni as 'Příjmení', Ulice, Mesto as 'Město',PSC as 'PSČ' FROM Vlastnici");
            if (dvg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lbl3.Text = dvg.DGVR.Cells["Jméno"].Value + " " + dvg.DGVR.Cells["Příjmení"].Value;
                lbl5.Text = dvg.DGVR.Cells["ID"].Value.ToString();
            }
        }
    }
}
