namespace kulicka
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
            this.Posunout = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.Right = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Posunout
            // 
            this.Posunout.Location = new System.Drawing.Point(535, 256);
            this.Posunout.Name = "Posunout";
            this.Posunout.Size = new System.Drawing.Size(75, 23);
            this.Posunout.TabIndex = 0;
            this.Posunout.Text = "Posunout";
            this.Posunout.UseVisualStyleBackColor = true;
            this.Posunout.Click += new System.EventHandler(this.Posunout_Click);
            // 
            // Left
            // 
            this.Left.Location = new System.Drawing.Point(512, 318);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(42, 23);
            this.Left.TabIndex = 1;
            this.Left.Text = "←";
            this.Left.UseVisualStyleBackColor = true;
            this.Left.Click += new System.EventHandler(this.Left_Click);
            // 
            // Right
            // 
            this.Right.Location = new System.Drawing.Point(596, 318);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(42, 23);
            this.Right.TabIndex = 2;
            this.Right.Text = "→";
            this.Right.UseVisualStyleBackColor = true;
            this.Right.Click += new System.EventHandler(this.Right_Click);
            // 
            // Up
            // 
            this.Up.Location = new System.Drawing.Point(554, 294);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(42, 23);
            this.Up.TabIndex = 3;
            this.Up.Text = "↑";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // Down
            // 
            this.Down.Location = new System.Drawing.Point(554, 318);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(42, 23);
            this.Down.TabIndex = 4;
            this.Down.Text = "↓";
            this.Down.UseVisualStyleBackColor = true;
            this.Down.Click += new System.EventHandler(this.Down_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 366);
            this.Controls.Add(this.Down);
            this.Controls.Add(this.Up);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.Posunout);
            this.Name = "Form1";
            this.Text = "Kulička";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Posunout;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button Right;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button Down;
    }
}

