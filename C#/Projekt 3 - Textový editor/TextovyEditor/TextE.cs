using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TextovyEditor
{
    public partial class MainForm : Form
    {
        // Proměnné
        public bool ulozeno = false;
        public string Uloziste = "";
        public bool bold = false;
        public bool italic = false;
        public bool underline = false;
        public bool strikeout = false;
        private string Nazev = "Text Editor";
        public string configLoc;
        //--
        public MainForm()
        {
            InitializeComponent();
            // Nahraje všechny dostupné fonty
            fonts.Text = TextBox.Font.Name;
            System.Drawing.Text.InstalledFontCollection fonty = new System.Drawing.Text.InstalledFontCollection();
            for (int i = 0; i < fonty.Families.Length; i++)
            {
                fonts.Items.Add(fonty.Families[i].Name);
            }
            // počáteční délka
            delka.Text = TextBox.Text.Length + " znaků";
            // čtení souboru config a nahrávání informací
            if (File.Exists("config.cfg"))
            {
                try
                {
                    StreamReader sr = new StreamReader("config.cfg");
                    string[] values;
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();
                        values = line.Split(new string[] { "=" }, StringSplitOptions.None);
                        switch (values[0])
                        {
                            case "BackColor": TextBox.BackColor = Color.FromArgb(Convert.ToInt32(values[1])); break;
                            case "ForeColor": TextBox.ForeColor = Color.FromArgb(Convert.ToInt32(values[1])); break;
                            case "Font": NastavitFont(values[1]); break;
                            case "Bold": if (values[1] == "True") { TextBox.Font = StylPisma(FontStyle.Bold); } break;
                            case "Italic": if (values[1] == "True") { TextBox.Font = StylPisma(FontStyle.Italic); } break;
                            case "Underline": if (values[1] == "True") { TextBox.Font = StylPisma(FontStyle.Underline); } break;
                            case "Strikeout": if (values[1] == "True") { TextBox.Font = StylPisma(FontStyle.Strikeout); } break;
                            case "FontSize": NastavitVelikost(values[1]); break;
                        }
                    }
                    sr.Close();
                }
                catch (Exception se)
                {
                    MessageBox.Show("Chyba! " + se);
                }
            }
            else
            {
                File.Create("config.cfg");
            }
        }
        private bool empty(string text)
        {
            if (text == "") return true;
            return false;
        }
        private DialogResult YNDialog(string zprava)
        {
            YNDialog dialog = new YNDialog(zprava);
            dialog.Text = Nazev;
            return dialog.ShowDialog();
        } 
        private void Exit()
        {
            this.Close();
        } // ukončí program
        private void Novy()
        {
            if (!ulozeno && !empty(TextBox.Text))
            {
                DialogResult dr = YNDialog("Chcete uložit tento dokument?");
                if (dr == DialogResult.Yes)
                {
                    if (empty(Uloziste))
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Textový soubor|*.txt|RTF soubor|*.rtf";
                        sfd.Title = "Uložit soubor";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            FileStream fs = (FileStream)sfd.OpenFile();
                            StreamWriter sw = new StreamWriter(fs);
                            sw.Write(TextBox.Text);
                            sw.Close();
                            fs.Close();
                            TextBox.Text = "";
                            ulozeno = false;
                            Uloziste = "";
                            this.Text = Nazev + " - Nový dokument";
                        }
                    }
                    else
                    {
                        FileStream fs = File.Create(Uloziste);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write(TextBox.Text);
                        sw.Close();
                        fs.Close();
                        this.Text = Nazev + " - Nový dokument";
                        ulozeno = false;
                        TextBox.Text = "";
                        Uloziste = "";
                    }
                }
                else if (dr == DialogResult.No)
                {
                    TextBox.Text = "";
                    Uloziste = "";
                    this.Text = Nazev + " - Nový dokument";
                    ulozeno = false;
                }
            }
            else if (ulozeno)
            {
                TextBox.Text = "";
                Uloziste = "";
                this.Text = Nazev + " - Nový dokument";
                ulozeno = false;
            }
            else
            {
                TextBox.Text = "";
                Uloziste = "";
                this.Text = Nazev + " - Nový dokument";
                ulozeno = false;
            }
        } // založí nový dokument
        private void OpenFileDialogOwn()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Textové a RTF soubory|*.txt;*.rtf|Všechny soubory (*.*)|*.*";
            ofd.Title = "Otevřít soubor";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fso = File.OpenRead(ofd.FileName);
                StreamReader sr = new StreamReader(fso);
                TextBox.Text = sr.ReadToEnd();
                ulozeno = true;
                Uloziste = ofd.FileName;
                this.Text = Nazev + " - " + Path.GetFileName(ofd.FileName);
                sr.Close();
                fso.Close();
            }
        } // Otevře dialog pro otevření souboru
        private void Open()
        {
            if (!ulozeno && !empty(TextBox.Text))
            {
                DialogResult dr = YNDialog("Chcete uložit tento dokument?");
                if (dr == DialogResult.Yes)
                {
                    if (empty(Uloziste))
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Textový soubor|*.txt|RTF soubor|*.rtf";
                        sfd.Title = "Uložit soubor";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            FileStream fs = (FileStream)sfd.OpenFile();
                            StreamWriter sw = new StreamWriter(fs);
                            sw.Write(TextBox.Text);
                            sw.Close();
                            fs.Close();
                            OpenFileDialogOwn();
                        }
                    }
                    else
                    {
                        FileStream fs = File.Create(Uloziste);
                        StreamWriter sw = new StreamWriter(fs, UnicodeEncoding.Unicode);
                        sw.Write(TextBox.Text);
                        sw.Close();
                        fs.Close();
                        OpenFileDialogOwn();
                    }
                }
                else if (dr == DialogResult.No)
                    OpenFileDialogOwn();
            }
            else if (ulozeno)
                OpenFileDialogOwn();
            else
                OpenFileDialogOwn();
        }  // otevření jiného dokumentu
        private void Save()
        {
            if (!ulozeno)
            {
                if (empty(Uloziste))
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Textový soubor|*.txt|RTF soubor|*.rtf";
                    sfd.Title = "Uložit soubor";
                    sfd.FileName = "Nový dokument";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FileStream fs = (FileStream)sfd.OpenFile();
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write(TextBox.Text);
                        sw.Close();
                        fs.Close();
                        ulozeno = true;
                        Uloziste = sfd.FileName;
                        this.Text = Nazev + " - " + Path.GetFileName(Uloziste);
                    }
                }
                else
                {
                    FileStream fs = File.Create(Uloziste);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(TextBox.Text);
                    sw.Close();
                    fs.Close();
                    this.Text = Nazev + " - " + Path.GetFileName(Uloziste);
                    ulozeno = true;
                }
            }
        } // ukládání dokumentu
        private void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Textový soubor|*.txt|RTF soubor|*.rtf";
            sfd.Title = "Uložit soubor jako...";
            sfd.FileName = "Nový dokument";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = (FileStream)sfd.OpenFile();
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(TextBox.Text);
                sw.Close();
                fs.Close();
                ulozeno = true;
                Uloziste = sfd.FileName;
                this.Text = Nazev + " - " + Path.GetFileName(Uloziste);
            }
        } // ukládání dokumentu jako..
        private void NewDoc_Click(object sender, EventArgs e)
        {
            Novy();
        }
        private void SaveDoc_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void SaveAsDoc_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
        private void ExitDoc_Click(object sender, EventArgs e)
        {
            Exit();
        }
        private void MainForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ulozeno && !empty(TextBox.Text))
            {
                DialogResult dr = YNDialog("Chcete uložit tento dokument před zavřením?");
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (dr == DialogResult.Yes)
                {
                    Save();
                }
            }
            Font pismo = TextBox.Font;
            string Config = "BackColor=" + TextBox.BackColor.ToArgb() + "\r\nForeColor=" + TextBox.ForeColor.ToArgb() + "\r\nFont=" + pismo.Name + "\r\nBold=" + bold + "\r\nItalic=" + italic + "\r\nUnderline=" + underline + "\r\nStrikeout=" + strikeout + "\r\nFontSize=" + pismo.Size;
            try
            {
                TextWriter tw = new StreamWriter("config.cfg");
                tw.Write(Config);
                tw.Close();
            }
            catch (Exception se)
            {
                MessageBox.Show("Chyba! " + se);
            }
        } // při zavírání programu
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Shift && e.KeyCode == Keys.S)
                Save();
            if (e.Control && e.KeyCode == Keys.A)
                TextBox.SelectAll();
            if (e.Control && e.KeyCode == Keys.O)
                Open();
            if (e.Control && e.Shift && e.KeyCode == Keys.S)
                SaveAs();
            if (e.Control && e.KeyCode == Keys.N)
                Novy();
            if (e.Shift && e.KeyCode == Keys.Escape)
                Exit();
        } // klávesové zkratky
        private void OpenDoc_Click(object sender, EventArgs e)
        {
            Open();
        }
        public Font VelikostPisma(float velikost)
        {
            Font pismo = TextBox.Font;
            if (pismo != null && velikost >= 1)
            {
                float aktVelikost = pismo.Size;
                if (aktVelikost != velikost)
                {
                    pismo = new Font(pismo.Name, velikost,
                        pismo.Style, pismo.Unit,
                        pismo.GdiCharSet, pismo.GdiVerticalFont);
                    FontSizes.Text = velikost.ToString();
                }
            }
            return pismo;
        }
        public Font StylPisma(FontStyle styl)
        {
            Font pismo = TextBox.Font;
            if (pismo != null)
            {
                FontStyle aktStyl = pismo.Style;
                switch (styl)
                {
                    case FontStyle.Bold:
                        if (aktStyl == FontStyle.Regular) { aktStyl = styl; bold = true; }
                        else if (bold == false) { aktStyl |= styl; bold = true; }
                        else if (bold == true) { aktStyl &= ~styl; bold = false; }
                        if (aktStyl.ToString() == "-1") { aktStyl = FontStyle.Regular; }
                        break;
                    case FontStyle.Italic:
                        if (aktStyl == FontStyle.Regular) { aktStyl = styl; italic = true; }
                        else if (italic == false) { aktStyl |= styl; italic = true; }
                        else if (italic == true) { aktStyl &= ~styl; italic = false; }
                        if (aktStyl.ToString() == "-1") { aktStyl = FontStyle.Regular; }
                        break;
                    case FontStyle.Strikeout:
                        if (aktStyl == FontStyle.Regular) { aktStyl = styl; strikeout = true; }
                        else if (strikeout == false) { aktStyl |= styl; strikeout = true; }
                        else if (strikeout == true) { aktStyl &= ~styl; strikeout = false; }
                        if (aktStyl.ToString() == "-1") { aktStyl = FontStyle.Regular; }
                        break;
                    case FontStyle.Underline:
                        if (aktStyl == FontStyle.Regular) { aktStyl = styl; underline = true; }
                        else if (underline == false) { aktStyl |= styl; underline = true; }
                        else if (underline == true) { aktStyl &= ~styl; underline = false; }
                        if (aktStyl.ToString() == "-1") { aktStyl = FontStyle.Regular; }
                        break;
                }
                pismo = new Font(pismo.Name, pismo.Size,
                    aktStyl, pismo.Unit,
                    pismo.GdiCharSet, pismo.GdiVerticalFont);
            }
            return pismo;
        }
        public void NastavitVelikost(string size)
        {
            size = size.Replace('.', ',');
            FontSizes.Text = size;
            if (size != "")
            {
                try
                {
                    if (Convert.ToSingle(size) >= 1 && Convert.ToSingle(size) <= 1639.35)
                        TextBox.Font = VelikostPisma(Convert.ToSingle(FontSizes.Text));

                    else
                    {
                        MessageBox.Show("Číslo musí být mezi 1 a 1639.35");
                        FontSizes.Text = TextBox.Font.Size.ToString();
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Neplatné číslo!");
                    FontSizes.Text = TextBox.Font.Size.ToString();
                }
            }
        }
        public void NastavitFont(string text)
        {
            try
            {
                TextBox.Font = new Font(text, TextBox.Font.Size,
                        TextBox.Font.Style, TextBox.Font.Unit,
                        TextBox.Font.GdiCharSet, TextBox.Font.GdiVerticalFont);
                fonts.Text = text;
            }
            catch (Exception)
            {
            }
        }
        private void Zmensit_Click(object sender, EventArgs e)
        {
            TextBox.Font = VelikostPisma(TextBox.Font.Size - 1);
        }
        private void boldButton_Click(object sender, EventArgs e)
        {
            TextBox.Font = StylPisma(FontStyle.Bold);
        }
        private void FontSizes_Leave(object sender, EventArgs e)
        {
            NastavitVelikost(FontSizes.Text);
        }
        private void FontSizes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NastavitVelikost(FontSizes.Text);
            }
        }
        private void FontSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            NastavitVelikost(FontSizes.Text);
        }
        private void ItalicButton_Click(object sender, EventArgs e)
        {
            TextBox.Font = StylPisma(FontStyle.Italic);
        }
        private void UnderlineButton_Click(object sender, EventArgs e)
        {
            TextBox.Font = StylPisma(FontStyle.Underline);
        }
        private void StrikeoutButton_Click(object sender, EventArgs e)
        {
            TextBox.Font = StylPisma(FontStyle.Strikeout);
        }
        private void fonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            NastavitFont(fonts.Text);
        }
        private void ForeButton_Click(object sender, EventArgs e)
        {
            ColorDialog clr = new ColorDialog();
            if (clr.ShowDialog() == DialogResult.OK)
            {//clr.Color
                TextBox.ForeColor = clr.Color;
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            ColorDialog clr = new ColorDialog();
            if (clr.ShowDialog() == DialogResult.OK)
            {
                TextBox.BackColor = clr.Color;
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            delka.Text = TextBox.Text.Length + " znaků";
            int lines = 0;
            foreach (string line in TextBox.Lines)
            {
                lines++;
            }
            if (lines <= 1) radky.Text = "1 řádek";
            if (lines >= 2 && lines <=4) radky.Text = lines+" řádky";
            if (lines >= 5) radky.Text = lines+ " řádků"; 
            
            ulozeno = false;
        }
        private void ResetStyle_Click(object sender, EventArgs e)
        {
            TextBox.Font = new Font("Microsoft Sans Serif", 9.0F,
                    FontStyle.Regular, TextBox.Font.Unit,
                    TextBox.Font.GdiCharSet, TextBox.Font.GdiVerticalFont);
            TextBox.BackColor = Color.White;
            TextBox.ForeColor = Color.Black;
            bold = false;
            italic = false;
            underline = false;
            strikeout = false;
        }
        private void zalamovat_CheckStateChanged(object sender, EventArgs e)
        {
            if (zalamovat.Checked) TextBox.WordWrap = true;
            else if (!zalamovat.Checked) TextBox.WordWrap = false;
        }
        private void Zvetsit_Click(object sender, EventArgs e)
        {
            TextBox.Font = VelikostPisma(TextBox.Font.Size + 1);
        }
    }
}
