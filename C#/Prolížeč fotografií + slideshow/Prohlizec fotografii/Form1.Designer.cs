namespace Prohlizec_fotografii
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
            this.Otevrit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Otevrit
            // 
            this.Otevrit.Location = new System.Drawing.Point(12, 12);
            this.Otevrit.Name = "Otevrit";
            this.Otevrit.Size = new System.Drawing.Size(78, 23);
            this.Otevrit.TabIndex = 0;
            this.Otevrit.Text = "Otevrit";
            this.Otevrit.UseVisualStyleBackColor = true;
            this.Otevrit.Click += new System.EventHandler(this.Otevrit_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(10, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 321);
            this.panel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 374);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Otevrit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Otevrit;
        private System.Windows.Forms.Panel panel1;
    }
}

