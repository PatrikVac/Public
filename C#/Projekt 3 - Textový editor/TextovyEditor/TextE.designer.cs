namespace TextovyEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.SouborDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.NewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.Zvetsit = new System.Windows.Forms.ToolStripButton();
            this.Zmensit = new System.Windows.Forms.ToolStripButton();
            this.FontSizes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.boldButton = new System.Windows.Forms.ToolStripButton();
            this.ItalicButton = new System.Windows.Forms.ToolStripButton();
            this.UnderlineButton = new System.Windows.Forms.ToolStripButton();
            this.StrikeoutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fonts = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ForeButton = new System.Windows.Forms.ToolStripButton();
            this.BackButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ResetStyle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.footer = new System.Windows.Forms.ToolStrip();
            this.delka = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.radky = new System.Windows.Forms.ToolStripLabel();
            this.zalamovat = new System.Windows.Forms.CheckBox();
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.MenuBar.SuspendLayout();
            this.Menu.SuspendLayout();
            this.footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SouborDoc});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(832, 24);
            this.MenuBar.TabIndex = 0;
            // 
            // SouborDoc
            // 
            this.SouborDoc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewDoc,
            this.OpenDoc,
            this.SaveDoc,
            this.SaveAsDoc,
            this.ExitDoc,
            this.toolStripSeparator7});
            this.SouborDoc.Name = "SouborDoc";
            this.SouborDoc.Size = new System.Drawing.Size(57, 20);
            this.SouborDoc.Text = "Soubor";
            // 
            // NewDoc
            // 
            this.NewDoc.Name = "NewDoc";
            this.NewDoc.Size = new System.Drawing.Size(135, 22);
            this.NewDoc.Text = "Nový";
            this.NewDoc.ToolTipText = "Ctrl + N";
            this.NewDoc.Click += new System.EventHandler(this.NewDoc_Click);
            // 
            // OpenDoc
            // 
            this.OpenDoc.Name = "OpenDoc";
            this.OpenDoc.Size = new System.Drawing.Size(135, 22);
            this.OpenDoc.Text = "Otevřít";
            this.OpenDoc.ToolTipText = "Ctrl + O";
            this.OpenDoc.Click += new System.EventHandler(this.OpenDoc_Click);
            // 
            // SaveDoc
            // 
            this.SaveDoc.Name = "SaveDoc";
            this.SaveDoc.Size = new System.Drawing.Size(135, 22);
            this.SaveDoc.Text = "Uložit";
            this.SaveDoc.ToolTipText = "Ctrl + S";
            this.SaveDoc.Click += new System.EventHandler(this.SaveDoc_Click);
            // 
            // SaveAsDoc
            // 
            this.SaveAsDoc.Name = "SaveAsDoc";
            this.SaveAsDoc.Size = new System.Drawing.Size(135, 22);
            this.SaveAsDoc.Text = "Uložit jako..";
            this.SaveAsDoc.ToolTipText = "Ctrl + Shift + S";
            this.SaveAsDoc.Click += new System.EventHandler(this.SaveAsDoc_Click);
            // 
            // ExitDoc
            // 
            this.ExitDoc.Name = "ExitDoc";
            this.ExitDoc.Size = new System.Drawing.Size(135, 22);
            this.ExitDoc.Text = "Konec";
            this.ExitDoc.ToolTipText = "Shift + Escape";
            this.ExitDoc.Click += new System.EventHandler(this.ExitDoc_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(132, 6);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Zvetsit,
            this.Zmensit,
            this.FontSizes,
            this.toolStripSeparator1,
            this.boldButton,
            this.ItalicButton,
            this.UnderlineButton,
            this.StrikeoutButton,
            this.toolStripSeparator2,
            this.fonts,
            this.toolStripSeparator3,
            this.ForeButton,
            this.BackButton,
            this.toolStripSeparator4,
            this.ResetStyle,
            this.toolStripSeparator5});
            this.Menu.Location = new System.Drawing.Point(0, 24);
            this.Menu.Name = "Menu";
            this.Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Menu.Size = new System.Drawing.Size(832, 25);
            this.Menu.TabIndex = 1;
            // 
            // Zvetsit
            // 
            this.Zvetsit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Zvetsit.Image = ((System.Drawing.Image)(resources.GetObject("Zvetsit.Image")));
            this.Zvetsit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Zvetsit.Name = "Zvetsit";
            this.Zvetsit.Size = new System.Drawing.Size(28, 22);
            this.Zvetsit.Text = "A ↑";
            this.Zvetsit.ToolTipText = "Zvětšit";
            this.Zvetsit.Click += new System.EventHandler(this.Zvetsit_Click);
            // 
            // Zmensit
            // 
            this.Zmensit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Zmensit.Image = ((System.Drawing.Image)(resources.GetObject("Zmensit.Image")));
            this.Zmensit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Zmensit.Name = "Zmensit";
            this.Zmensit.Size = new System.Drawing.Size(28, 22);
            this.Zmensit.Text = "A ↓";
            this.Zmensit.ToolTipText = "Zvětšit";
            this.Zmensit.Click += new System.EventHandler(this.Zmensit_Click);
            // 
            // FontSizes
            // 
            this.FontSizes.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.FontSizes.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "36",
            "48",
            "72"});
            this.FontSizes.Name = "FontSizes";
            this.FontSizes.Size = new System.Drawing.Size(75, 25);
            this.FontSizes.ToolTipText = "Velikost písma";
            this.FontSizes.SelectedIndexChanged += new System.EventHandler(this.FontSizes_SelectedIndexChanged);
            this.FontSizes.Leave += new System.EventHandler(this.FontSizes_Leave);
            this.FontSizes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FontSizes_KeyDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // boldButton
            // 
            this.boldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.boldButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.boldButton.Image = ((System.Drawing.Image)(resources.GetObject("boldButton.Image")));
            this.boldButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boldButton.Name = "boldButton";
            this.boldButton.Size = new System.Drawing.Size(23, 22);
            this.boldButton.Text = "B";
            this.boldButton.ToolTipText = "Tučné";
            this.boldButton.Click += new System.EventHandler(this.boldButton_Click);
            // 
            // ItalicButton
            // 
            this.ItalicButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ItalicButton.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ItalicButton.Image = ((System.Drawing.Image)(resources.GetObject("ItalicButton.Image")));
            this.ItalicButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItalicButton.Name = "ItalicButton";
            this.ItalicButton.Size = new System.Drawing.Size(23, 22);
            this.ItalicButton.Text = "I";
            this.ItalicButton.ToolTipText = "Kurzíva";
            this.ItalicButton.Click += new System.EventHandler(this.ItalicButton_Click);
            // 
            // UnderlineButton
            // 
            this.UnderlineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UnderlineButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UnderlineButton.Image = ((System.Drawing.Image)(resources.GetObject("UnderlineButton.Image")));
            this.UnderlineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UnderlineButton.Name = "UnderlineButton";
            this.UnderlineButton.Size = new System.Drawing.Size(23, 22);
            this.UnderlineButton.Text = "U";
            this.UnderlineButton.ToolTipText = "Podtržení";
            this.UnderlineButton.Click += new System.EventHandler(this.UnderlineButton_Click);
            // 
            // StrikeoutButton
            // 
            this.StrikeoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StrikeoutButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StrikeoutButton.Image = ((System.Drawing.Image)(resources.GetObject("StrikeoutButton.Image")));
            this.StrikeoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StrikeoutButton.Name = "StrikeoutButton";
            this.StrikeoutButton.Size = new System.Drawing.Size(23, 22);
            this.StrikeoutButton.Text = "S";
            this.StrikeoutButton.ToolTipText = "Přeškrtnutí";
            this.StrikeoutButton.Click += new System.EventHandler(this.StrikeoutButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // fonts
            // 
            this.fonts.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.fonts.Name = "fonts";
            this.fonts.Size = new System.Drawing.Size(200, 25);
            this.fonts.ToolTipText = "Písmo";
            this.fonts.SelectedIndexChanged += new System.EventHandler(this.fonts_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ForeButton
            // 
            this.ForeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ForeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeButton.ForeColor = System.Drawing.Color.Red;
            this.ForeButton.Image = ((System.Drawing.Image)(resources.GetObject("ForeButton.Image")));
            this.ForeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ForeButton.Name = "ForeButton";
            this.ForeButton.Size = new System.Drawing.Size(23, 22);
            this.ForeButton.Text = "A";
            this.ForeButton.ToolTipText = "Barva popředí písma";
            this.ForeButton.Click += new System.EventHandler(this.ForeButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Red;
            this.BackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(23, 22);
            this.BackButton.Text = "A";
            this.BackButton.ToolTipText = "Barva pozadí písma";
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ResetStyle
            // 
            this.ResetStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ResetStyle.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ResetStyle.Image = ((System.Drawing.Image)(resources.GetObject("ResetStyle.Image")));
            this.ResetStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetStyle.Name = "ResetStyle";
            this.ResetStyle.Size = new System.Drawing.Size(23, 22);
            this.ResetStyle.Text = "R";
            this.ResetStyle.ToolTipText = "Resetovat styl písma";
            this.ResetStyle.Click += new System.EventHandler(this.ResetStyle_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // footer
            // 
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delka,
            this.toolStripSeparator6,
            this.radky});
            this.footer.Location = new System.Drawing.Point(0, 428);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(832, 25);
            this.footer.TabIndex = 3;
            // 
            // delka
            // 
            this.delka.Name = "delka";
            this.delka.Size = new System.Drawing.Size(47, 22);
            this.delka.Text = "0 znaků";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // radky
            // 
            this.radky.Name = "radky";
            this.radky.Size = new System.Drawing.Size(45, 22);
            this.radky.Text = "1 řádek";
            // 
            // zalamovat
            // 
            this.zalamovat.AutoSize = true;
            this.zalamovat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zalamovat.Location = new System.Drawing.Point(537, 27);
            this.zalamovat.Name = "zalamovat";
            this.zalamovat.Size = new System.Drawing.Size(106, 17);
            this.zalamovat.TabIndex = 5;
            this.zalamovat.Text = "Zalamovat řádky";
            this.zalamovat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zalamovat.UseVisualStyleBackColor = true;
            this.zalamovat.CheckStateChanged += new System.EventHandler(this.zalamovat_CheckStateChanged);
            // 
            // TextBox
            // 
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Location = new System.Drawing.Point(0, 49);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(832, 379);
            this.TextBox.TabIndex = 6;
            this.TextBox.Text = "";
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.zalamovat);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.MenuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "Textový Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.footer.ResumeLayout(false);
            this.footer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem SouborDoc;
        private System.Windows.Forms.ToolStripMenuItem NewDoc;
        private System.Windows.Forms.ToolStripMenuItem OpenDoc;
        private System.Windows.Forms.ToolStripMenuItem SaveDoc;
        private System.Windows.Forms.ToolStripMenuItem SaveAsDoc;
        private System.Windows.Forms.ToolStripMenuItem ExitDoc;
        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStrip footer;
        private System.Windows.Forms.ToolStripButton Zmensit;
        private System.Windows.Forms.ToolStripComboBox fonts;
        private System.Windows.Forms.ToolStripLabel delka;
        private System.Windows.Forms.ToolStripComboBox FontSizes;
        private System.Windows.Forms.CheckBox zalamovat;
        private System.Windows.Forms.ToolStripButton Zvetsit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton boldButton;
        private System.Windows.Forms.ToolStripButton ItalicButton;
        private System.Windows.Forms.ToolStripButton UnderlineButton;
        private System.Windows.Forms.ToolStripButton StrikeoutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ForeButton;
        private System.Windows.Forms.ToolStripButton BackButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton ResetStyle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel radky;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.RichTextBox TextBox;
    }
}

