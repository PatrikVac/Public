using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Flooder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AllPRoc();
            listBox1.SelectedIndex = 0;
        }
        public void AllPRoc()
        {
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                string title = p.MainWindowTitle;
                if (title != string.Empty) listBox1.Items.Add(title);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                string title = p.MainWindowTitle;
                if (title == listBox1.GetItemText(listBox1.SelectedItem))
                {
                    SetForegroundWindow(p.MainWindowHandle);
                    break;
                }
            }
            celkove = 0;
            button1.Enabled = false;
            button2.Enabled = true;
            timer1.Interval = 2000;
            timer1.Start();
        }
        public int celkove = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(textBox2.Text);
            SendKeys.SendWait(textBox1.Text);
            System.Threading.Thread.Sleep(100);
            SendKeys.SendWait("{ENTER}");
            trvani += 1000;
            celkove++;
            this.Text = "Flooder (Odesláno " + celkove + "x)";
            if (trvani >= Convert.ToInt32(textBox3.Text))
            {
                timer1.Stop();
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Kontrola();

        }
        public int trvani = 0;
        public void Kontrola()
        {
            bool chyba = false;
            try
            {
                if (textBox1.Text == "")
                {
                    button1.Text = "Zadej zprávu!";
                    chyba = true;
                    button1.Enabled = false;
                }
                if (Convert.ToInt32(textBox2.Text) < 100)
                {
                    button1.Text = "Interval alespoň 100 ms";
                    chyba = true;
                    button1.Enabled = false;
                }
                if (Convert.ToInt32(textBox3.Text) < 100)
                {
                    button1.Text = "Trvání alespoň 100 ms";
                    chyba = true;
                    button1.Enabled = false;
                }
                if (Convert.ToInt32(textBox2.Text) < 1000)
                {
                    textBox2.BackColor = Color.Red;
                }
                else {
                    textBox2.BackColor = Color.White;
                }
            }
            catch (Exception)
            {
                chyba = true;
                button1.Text = "Interval alespoň 100 ms, trvání alespoň 100 ms nebo zadej zprávu!";
            }
            if (chyba == false)
            {
                button1.Enabled = true;
                button1.Text = "Start";
            }
        }
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Kontrola();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
