namespace ProjektKatastr
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.check2 = new System.Windows.Forms.RadioButton();
            this.check1 = new System.Windows.Forms.RadioButton();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.btn1 = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.btn2 = new System.Windows.Forms.Button();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.DGV5 = new System.Windows.Forms.DataGridView();
            this.btn4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.DGV4 = new System.Windows.Forms.DataGridView();
            this.DGV3 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.DGV7 = new System.Windows.Forms.DataGridView();
            this.DGV6 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV6)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(854, 487);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.check2);
            this.tabPage1.Controls.Add(this.check1);
            this.tabPage1.Controls.Add(this.DGV1);
            this.tabPage1.Controls.Add(this.btn1);
            this.tabPage1.Controls.Add(this.txt1);
            this.tabPage1.Controls.Add(this.lbl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(846, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vyhledávání podle čísla";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // check2
            // 
            this.check2.AutoSize = true;
            this.check2.Location = new System.Drawing.Point(142, 6);
            this.check2.Name = "check2";
            this.check2.Size = new System.Drawing.Size(120, 17);
            this.check2.TabIndex = 8;
            this.check2.Text = "Vyhledávání staveb";
            this.check2.UseVisualStyleBackColor = true;
            this.check2.CheckedChanged += new System.EventHandler(this.check2CH);
            // 
            // check1
            // 
            this.check1.AutoSize = true;
            this.check1.Checked = true;
            this.check1.Location = new System.Drawing.Point(8, 6);
            this.check1.Name = "check1";
            this.check1.Size = new System.Drawing.Size(117, 17);
            this.check1.TabIndex = 7;
            this.check1.TabStop = true;
            this.check1.Text = "Vyhledávání parcel";
            this.check1.UseVisualStyleBackColor = true;
            this.check1.CheckedChanged += new System.EventHandler(this.check1CH);
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGV1.Location = new System.Drawing.Point(3, 69);
            this.DGV1.Name = "DGV1";
            this.DGV1.ReadOnly = true;
            this.DGV1.RowHeadersVisible = false;
            this.DGV1.RowHeadersWidth = 50;
            this.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV1.Size = new System.Drawing.Size(840, 389);
            this.DGV1.TabIndex = 6;
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(176, 40);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 4;
            this.btn1.Text = "Vyhledat";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(90, 42);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(70, 20);
            this.txt1.TabIndex = 3;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(8, 45);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(71, 13);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Číslo parcely:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGV2);
            this.tabPage2.Controls.Add(this.btn2);
            this.tabPage2.Controls.Add(this.txt4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txt3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txt2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(846, 461);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vyhledávání podle území a obce";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGV2.Location = new System.Drawing.Point(3, 94);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowHeadersVisible = false;
            this.DGV2.RowHeadersWidth = 50;
            this.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV2.Size = new System.Drawing.Size(840, 364);
            this.DGV2.TabIndex = 11;
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(217, 65);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 23);
            this.btn2.TabIndex = 10;
            this.btn2.Text = "Vyhledat";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(122, 67);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(70, 20);
            this.txt4.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Část obce:";
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(122, 41);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(70, 20);
            this.txt3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Obec:";
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(122, 15);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(70, 20);
            this.txt2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Katastrální území:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.DGV5);
            this.tabPage3.Controls.Add(this.btn4);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.btn6);
            this.tabPage3.Controls.Add(this.btn3);
            this.tabPage3.Controls.Add(this.lbl2);
            this.tabPage3.Controls.Add(this.DGV4);
            this.tabPage3.Controls.Add(this.DGV3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(846, 461);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Správa omezení";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Omezení je vystaveno ve prospěch:";
            // 
            // DGV5
            // 
            this.DGV5.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV5.Location = new System.Drawing.Point(3, 384);
            this.DGV5.Name = "DGV5";
            this.DGV5.ReadOnly = true;
            this.DGV5.RowHeadersVisible = false;
            this.DGV5.RowHeadersWidth = 50;
            this.DGV5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV5.Size = new System.Drawing.Size(840, 73);
            this.DGV5.TabIndex = 20;
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(124, 3);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(115, 23);
            this.btn4.TabIndex = 19;
            this.btn4.Text = "Vytvořit omezení";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(629, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Vybrané omezení:";
            // 
            // btn6
            // 
            this.btn6.Enabled = false;
            this.btn6.Location = new System.Drawing.Point(728, 3);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(115, 23);
            this.btn6.TabIndex = 17;
            this.btn6.Text = "Zrušit";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(3, 3);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(115, 23);
            this.btn3.TabIndex = 15;
            this.btn3.Text = "Načíst omezení";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(5, 272);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(246, 13);
            this.lbl2.TabIndex = 14;
            this.lbl2.Text = "Parcela / stavba pro kterou je omezení vytvořeno:";
            // 
            // DGV4
            // 
            this.DGV4.AllowUserToAddRows = false;
            this.DGV4.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV4.Location = new System.Drawing.Point(0, 288);
            this.DGV4.Name = "DGV4";
            this.DGV4.ReadOnly = true;
            this.DGV4.RowHeadersVisible = false;
            this.DGV4.RowHeadersWidth = 50;
            this.DGV4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV4.Size = new System.Drawing.Size(840, 73);
            this.DGV4.TabIndex = 13;
            // 
            // DGV3
            // 
            this.DGV3.AllowUserToAddRows = false;
            this.DGV3.AllowUserToResizeRows = false;
            this.DGV3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV3.Location = new System.Drawing.Point(3, 27);
            this.DGV3.MultiSelect = false;
            this.DGV3.Name = "DGV3";
            this.DGV3.ReadOnly = true;
            this.DGV3.RowHeadersVisible = false;
            this.DGV3.RowHeadersWidth = 50;
            this.DGV3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV3.Size = new System.Drawing.Size(840, 241);
            this.DGV3.TabIndex = 12;
            this.DGV3.SelectionChanged += new System.EventHandler(this.DGV3_SelectionChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.btn7);
            this.tabPage4.Controls.Add(this.DGV7);
            this.tabPage4.Controls.Add(this.DGV6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(846, 461);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Změny vlastníků";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(596, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "U vybrané:";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(661, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Upravit vlastnictví";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(8, 5);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(155, 23);
            this.btn7.TabIndex = 16;
            this.btn7.Text = "Načíst parcely a stavby";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // DGV7
            // 
            this.DGV7.AllowUserToAddRows = false;
            this.DGV7.AllowUserToResizeRows = false;
            this.DGV7.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV7.Location = new System.Drawing.Point(3, 242);
            this.DGV7.MultiSelect = false;
            this.DGV7.Name = "DGV7";
            this.DGV7.ReadOnly = true;
            this.DGV7.RowHeadersVisible = false;
            this.DGV7.RowHeadersWidth = 50;
            this.DGV7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV7.Size = new System.Drawing.Size(840, 216);
            this.DGV7.TabIndex = 14;
            this.DGV7.SelectionChanged += new System.EventHandler(this.DGVSelectionChanged);
            this.DGV7.Click += new System.EventHandler(this.DGV7_Click);
            // 
            // DGV6
            // 
            this.DGV6.AllowUserToAddRows = false;
            this.DGV6.AllowUserToResizeRows = false;
            this.DGV6.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV6.Location = new System.Drawing.Point(3, 31);
            this.DGV6.MultiSelect = false;
            this.DGV6.Name = "DGV6";
            this.DGV6.ReadOnly = true;
            this.DGV6.RowHeadersVisible = false;
            this.DGV6.RowHeadersWidth = 50;
            this.DGV6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV6.Size = new System.Drawing.Size(840, 205);
            this.DGV6.TabIndex = 13;
            this.DGV6.SelectionChanged += new System.EventHandler(this.DGVSelectionChanged);
            this.DGV6.Click += new System.EventHandler(this.DGV6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 487);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Katastrální úřad";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.RadioButton check2;
        private System.Windows.Forms.RadioButton check1;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.DataGridView DGV4;
        private System.Windows.Forms.DataGridView DGV3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DGV5;
        private System.Windows.Forms.DataGridView DGV7;
        private System.Windows.Forms.DataGridView DGV6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
    }
}

