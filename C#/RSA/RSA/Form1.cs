using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte[] plaintText, cypherText;
        RSACryptoServiceProvider rsa;
        RSAParameters privateKey, publicKey;
        Encoding byteConverter = new UnicodeEncoding();

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            // export klíčů
            rsa = new RSACryptoServiceProvider();
            privateKey = rsa.ExportParameters(true);
            publicKey = rsa.ExportParameters(false);

            textBox3.Text = "e = " + BitConverter.ToString(publicKey.Exponent) + ", N = " + BitConverter.ToString(publicKey.Modulus);
            textBox4.Text = "d = " + BitConverter.ToString(privateKey.Exponent) + ", N = " + BitConverter.ToString(privateKey.Modulus);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // sifrovani
            plaintText = byteConverter.GetBytes(textBox1.Text);

            RSACryptoServiceProvider rsaSifrovani = new RSACryptoServiceProvider();
            rsaSifrovani.ImportParameters(publicKey);

            cypherText = rsaSifrovani.Encrypt(plaintText, false);

            textBox2.Text = BitConverter.ToString(cypherText);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // dešifrování
            RSACryptoServiceProvider rsaDesifrovani = new RSACryptoServiceProvider();
            rsaDesifrovani.ImportParameters(privateKey);

            plaintText = rsaDesifrovani.Decrypt(cypherText, false);

            textBox1.Text = byteConverter.GetString(plaintText);
        }
    }
}
