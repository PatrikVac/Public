namespace Malovani
{
    partial class inForm
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
            this.inText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // inText
            // 
            this.inText.BackColor = System.Drawing.Color.White;
            this.inText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inText.Location = new System.Drawing.Point(101, 70);
            this.inText.Name = "inText";
            this.inText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.inText.Size = new System.Drawing.Size(10, 10);
            this.inText.TabIndex = 0;
            this.inText.Text = "";
            this.inText.Visible = false;
            this.inText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inText_KeyDown);
            // 
            // inForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 262);
            this.Controls.Add(this.inText);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "inForm";
            this.Text = "Nový dokument";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.inForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox inText;
    }
}