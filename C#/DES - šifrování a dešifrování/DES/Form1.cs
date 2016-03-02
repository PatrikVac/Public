using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string plainText = textBox1.Text;
            string key = textBox2.Text;

            if (key.Length != 4)
            {
                MessageBox.Show("Neplatná délka klíče 4 znaky");
                return;
            }

            byte[] keyBytes = ASCIIEncoding.Unicode.GetBytes(key);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();

            CryptoStream crypto = new CryptoStream(
                ms, 
                des.CreateEncryptor(keyBytes, keyBytes), 
                CryptoStreamMode.Write
                );

            StreamWriter sw = new StreamWriter(crypto);
            sw.Write(plainText);
            sw.Close();
            crypto.Close();

            byte[] cryptedTextBytes = ms.ToArray();
            ms.Close();
            textBox4.Text = Convert.ToBase64String(cryptedTextBytes, 0, cryptedTextBytes.Length);
            textBox3.Text = key;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cypherText = textBox4.Text;
            string key = textBox3.Text;

            byte[] keyBytes = ASCIIEncoding.Unicode.GetBytes(key);

            if (key.Length != 4)
            {
                MessageBox.Show("Neplatná délka klíče 4 znaky");
                return;
            }

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(cypherText));

                CryptoStream crypto = new CryptoStream(
                    ms,
                    des.CreateDecryptor(keyBytes, keyBytes),
                    CryptoStreamMode.Read
                );

                StreamReader sr = new StreamReader(crypto);
                textBox5.Text = sr.ReadToEnd();
                sr.Close();
                crypto.Close();
                ms.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
