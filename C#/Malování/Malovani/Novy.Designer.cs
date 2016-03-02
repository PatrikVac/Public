namespace Malovani
{
    partial class Novy
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BgColor = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.OKb = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BgColor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Název:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BgColor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.height);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.width);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Předvolby";
            // 
            // BgColor
            // 
            this.BgColor.BackColor = System.Drawing.Color.Transparent;
            this.BgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BgColor.Location = new System.Drawing.Point(99, 71);
            this.BgColor.Name = "BgColor";
            this.BgColor.Size = new System.Drawing.Size(25, 25);
            this.BgColor.TabIndex = 10;
            this.BgColor.TabStop = false;
            this.BgColor.Click += new System.EventHandler(this.BgColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Barva pozadí:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "px";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "px";
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(99, 46);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(63, 20);
            this.height.TabIndex = 6;
            this.height.Text = "768";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Výška:";
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(99, 20);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(63, 20);
            this.width.TabIndex = 4;
            this.width.Text = "1366";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Šířka:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(66, 6);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(244, 20);
            this.name.TabIndex = 2;
            this.name.Text = "Nový obrázek";
            // 
            // OKb
            // 
            this.OKb.Location = new System.Drawing.Point(316, 9);
            this.OKb.Name = "OKb";
            this.OKb.Size = new System.Drawing.Size(158, 30);
            this.OKb.TabIndex = 3;
            this.OKb.Text = "OK";
            this.OKb.UseVisualStyleBackColor = true;
            this.OKb.Click += new System.EventHandler(this.OKb_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(316, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Zrušit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Novy
            // 
            this.AcceptButton = this.OKb;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 146);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.OKb);
            this.Controls.Add(this.name);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Novy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nový";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BgColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox BgColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button OKb;
        private System.Windows.Forms.Button button2;
    }
}