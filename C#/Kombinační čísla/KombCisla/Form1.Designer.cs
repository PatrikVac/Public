namespace KombCisla
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
            this.nko = new System.Windows.Forms.TextBox();
            this.Kcko = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vysledek = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nko
            // 
            this.nko.Location = new System.Drawing.Point(76, 33);
            this.nko.Name = "nko";
            this.nko.Size = new System.Drawing.Size(45, 20);
            this.nko.TabIndex = 0;
            // 
            // Kcko
            // 
            this.Kcko.Location = new System.Drawing.Point(76, 59);
            this.Kcko.Name = "Kcko";
            this.Kcko.Size = new System.Drawing.Size(45, 20);
            this.Kcko.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(127, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 73);
            this.label2.TabIndex = 3;
            this.label2.Text = ")";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(20, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 73);
            this.label3.TabIndex = 4;
            this.label3.Text = "(";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(162, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "=>";
            // 
            // vysledek
            // 
            this.vysledek.Location = new System.Drawing.Point(12, 113);
            this.vysledek.Multiline = true;
            this.vysledek.Name = "vysledek";
            this.vysledek.Size = new System.Drawing.Size(260, 137);
            this.vysledek.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Vypočti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vysledek);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Kcko);
            this.Controls.Add(this.nko);
            this.Name = "Form1";
            this.Text = "Kombinacni cisla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nko;
        private System.Windows.Forms.TextBox Kcko;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vysledek;
        private System.Windows.Forms.Button button1;
    }
}

