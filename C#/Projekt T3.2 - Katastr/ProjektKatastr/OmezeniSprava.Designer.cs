namespace ProjektKatastr
{
    partial class OmezeniSprava
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
            this.label1 = new System.Windows.Forms.Label();
            this.check1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.group1 = new System.Windows.Forms.GroupBox();
            this.btn4 = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.combo1 = new System.Windows.Forms.ComboBox();
            this.group2 = new System.Windows.Forms.GroupBox();
            this.btn5 = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.combo2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.check2 = new System.Windows.Forms.RadioButton();
            this.lbl3 = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.lbl5 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parcela ID:";
            // 
            // check1
            // 
            this.check1.AutoSize = true;
            this.check1.Checked = true;
            this.check1.Location = new System.Drawing.Point(17, 3);
            this.check1.Name = "check1";
            this.check1.Size = new System.Drawing.Size(79, 17);
            this.check1.TabIndex = 1;
            this.check1.TabStop = true;
            this.check1.Text = "Pro parcelu";
            this.check1.UseVisualStyleBackColor = true;
            this.check1.CheckedChanged += new System.EventHandler(this.check1_CheckedChanged);
            this.check1.Click += new System.EventHandler(this.KontrolaVyplneni);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stavba ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vystaveno ve prospěch ID: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Typ omezení:";
            // 
            // group1
            // 
            this.group1.Controls.Add(this.btn4);
            this.group1.Controls.Add(this.lbl1);
            this.group1.Controls.Add(this.combo1);
            this.group1.Controls.Add(this.label4);
            this.group1.Controls.Add(this.label1);
            this.group1.Location = new System.Drawing.Point(11, 19);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(261, 68);
            this.group1.TabIndex = 6;
            this.group1.TabStop = false;
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(169, 11);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(86, 23);
            this.btn4.TabIndex = 13;
            this.btn4.Text = "Zvolit ->";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(81, 16);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(0, 13);
            this.lbl1.TabIndex = 7;
            this.lbl1.TextChanged += new System.EventHandler(this.KontrolaVyplneni);
            // 
            // combo1
            // 
            this.combo1.FormattingEnabled = true;
            this.combo1.Items.AddRange(new object[] {
            "zástavní právo",
            "omezení bourání domů",
            "věcné břemeno"});
            this.combo1.Location = new System.Drawing.Point(84, 38);
            this.combo1.Name = "combo1";
            this.combo1.Size = new System.Drawing.Size(171, 21);
            this.combo1.TabIndex = 6;
            this.combo1.TextChanged += new System.EventHandler(this.KontrolaVyplneni);
            // 
            // group2
            // 
            this.group2.Controls.Add(this.btn5);
            this.group2.Controls.Add(this.lbl2);
            this.group2.Controls.Add(this.combo2);
            this.group2.Controls.Add(this.label6);
            this.group2.Controls.Add(this.label2);
            this.group2.Enabled = false;
            this.group2.Location = new System.Drawing.Point(11, 110);
            this.group2.Name = "group2";
            this.group2.Size = new System.Drawing.Size(261, 68);
            this.group2.TabIndex = 8;
            this.group2.TabStop = false;
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(169, 11);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(86, 23);
            this.btn5.TabIndex = 14;
            this.btn5.Text = "Zvolit ->";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(81, 16);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(0, 13);
            this.lbl2.TabIndex = 7;
            this.lbl2.TextChanged += new System.EventHandler(this.KontrolaVyplneni);
            // 
            // combo2
            // 
            this.combo2.FormattingEnabled = true;
            this.combo2.Items.AddRange(new object[] {
            "zástavní právo",
            "omezení bourání domů",
            "věcné břemeno"});
            this.combo2.Location = new System.Drawing.Point(84, 38);
            this.combo2.Name = "combo2";
            this.combo2.Size = new System.Drawing.Size(171, 21);
            this.combo2.TabIndex = 6;
            this.combo2.TextChanged += new System.EventHandler(this.KontrolaVyplneni);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Typ omezení:";
            // 
            // check2
            // 
            this.check2.AutoSize = true;
            this.check2.Location = new System.Drawing.Point(17, 93);
            this.check2.Name = "check2";
            this.check2.Size = new System.Drawing.Size(76, 17);
            this.check2.TabIndex = 7;
            this.check2.Text = "Pro stavbu";
            this.check2.UseVisualStyleBackColor = true;
            this.check2.CheckedChanged += new System.EventHandler(this.check1_CheckedChanged);
            this.check2.Click += new System.EventHandler(this.KontrolaVyplneni);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(76, 212);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(0, 13);
            this.lbl3.TabIndex = 9;
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(170, 179);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(110, 19);
            this.btn1.TabIndex = 10;
            this.btn1.Text = "Zvolit osobu ->";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn2.Enabled = false;
            this.btn2.Location = new System.Drawing.Point(30, 243);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(86, 23);
            this.btn2.TabIndex = 11;
            this.btn2.Text = "OK";
            this.btn2.UseVisualStyleBackColor = true;
            // 
            // btn3
            // 
            this.btn3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn3.Location = new System.Drawing.Point(158, 243);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(86, 23);
            this.btn3.TabIndex = 12;
            this.btn3.Text = "Storno";
            this.btn3.UseVisualStyleBackColor = true;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.BackColor = System.Drawing.Color.Transparent;
            this.lbl5.Location = new System.Drawing.Point(145, 181);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(13, 13);
            this.lbl5.TabIndex = 13;
            this.lbl5.Text = "0";
            this.lbl5.TextChanged += new System.EventHandler(this.KontrolaVyplneni);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Jméno:";
            // 
            // OmezeniSprava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 278);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.group2);
            this.Controls.Add(this.check2);
            this.Controls.Add(this.group1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.check1);
            this.Name = "OmezeniSprava";
            this.Text = "Vytvoření omezení";
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox group1;
        private System.Windows.Forms.GroupBox group2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.RadioButton check1;
        public System.Windows.Forms.RadioButton check2;
        public System.Windows.Forms.ComboBox combo1;
        public System.Windows.Forms.Label lbl1;
        public System.Windows.Forms.Label lbl2;
        public System.Windows.Forms.ComboBox combo2;
        public System.Windows.Forms.Label lbl5;
    }
}