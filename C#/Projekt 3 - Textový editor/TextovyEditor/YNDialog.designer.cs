namespace TextovyEditor
{
    partial class YNDialog
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
            this.Yes = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.Button();
            this.Oznameni = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Yes
            // 
            this.Yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Yes.Location = new System.Drawing.Point(12, 38);
            this.Yes.Name = "Yes";
            this.Yes.Size = new System.Drawing.Size(128, 22);
            this.Yes.TabIndex = 0;
            this.Yes.Text = "Ano";
            this.Yes.UseVisualStyleBackColor = true;
            // 
            // No
            // 
            this.No.DialogResult = System.Windows.Forms.DialogResult.No;
            this.No.Location = new System.Drawing.Point(163, 38);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(128, 22);
            this.No.TabIndex = 1;
            this.No.Text = "Ne";
            this.No.UseVisualStyleBackColor = true;
            // 
            // Oznameni
            // 
            this.Oznameni.Location = new System.Drawing.Point(12, 0);
            this.Oznameni.Name = "Oznameni";
            this.Oznameni.Size = new System.Drawing.Size(432, 35);
            this.Oznameni.TabIndex = 2;
            this.Oznameni.Text = "s";
            this.Oznameni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Oznameni.Click += new System.EventHandler(this.Oznameni_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(316, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // YNDialog
            // 
            this.AcceptButton = this.Yes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.No;
            this.ClientSize = new System.Drawing.Size(458, 67);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Oznameni);
            this.Controls.Add(this.No);
            this.Controls.Add(this.Yes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "YNDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.YNDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Yes;
        private System.Windows.Forms.Button No;
        private System.Windows.Forms.Label Oznameni;
        private System.Windows.Forms.Button button1;
    }
}