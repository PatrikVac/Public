namespace Tetris
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.PosledniButton = new System.Windows.Forms.Button();
            this.NovaHraButton = new System.Windows.Forms.Button();
            this.obtiznost = new System.Windows.Forms.TrackBar();
            this.obtiznostText = new System.Windows.Forms.Label();
            this.Obtiznosts = new System.Windows.Forms.Label();
            this.UlozitButton = new System.Windows.Forms.Button();
            this.KonecButton = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obtiznost)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.Black;
            this.menuPanel.Controls.Add(this.button1);
            this.menuPanel.Controls.Add(this.PosledniButton);
            this.menuPanel.Controls.Add(this.NovaHraButton);
            this.menuPanel.Controls.Add(this.obtiznost);
            this.menuPanel.Controls.Add(this.obtiznostText);
            this.menuPanel.Controls.Add(this.Obtiznosts);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuPanel.Location = new System.Drawing.Point(354, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(188, 365);
            this.menuPanel.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(26, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Top výsledky";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PosledniButton
            // 
            this.PosledniButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.PosledniButton.FlatAppearance.BorderSize = 3;
            this.PosledniButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.PosledniButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.PosledniButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PosledniButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PosledniButton.ForeColor = System.Drawing.Color.White;
            this.PosledniButton.Location = new System.Drawing.Point(26, 116);
            this.PosledniButton.Name = "PosledniButton";
            this.PosledniButton.Size = new System.Drawing.Size(142, 28);
            this.PosledniButton.TabIndex = 6;
            this.PosledniButton.Text = "Načíst hru";
            this.PosledniButton.UseVisualStyleBackColor = true;
            this.PosledniButton.Click += new System.EventHandler(this.PosledniButton_Click);
            // 
            // NovaHraButton
            // 
            this.NovaHraButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.NovaHraButton.FlatAppearance.BorderSize = 3;
            this.NovaHraButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.NovaHraButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.NovaHraButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NovaHraButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NovaHraButton.ForeColor = System.Drawing.Color.White;
            this.NovaHraButton.Location = new System.Drawing.Point(26, 162);
            this.NovaHraButton.Name = "NovaHraButton";
            this.NovaHraButton.Size = new System.Drawing.Size(142, 44);
            this.NovaHraButton.TabIndex = 5;
            this.NovaHraButton.Text = "NOVÁ HRA";
            this.NovaHraButton.UseVisualStyleBackColor = true;
            this.NovaHraButton.Click += new System.EventHandler(this.NovaHraButton_Click);
            // 
            // obtiznost
            // 
            this.obtiznost.BackColor = System.Drawing.Color.Black;
            this.obtiznost.Location = new System.Drawing.Point(48, 46);
            this.obtiznost.Maximum = 5;
            this.obtiznost.Minimum = 1;
            this.obtiznost.Name = "obtiznost";
            this.obtiznost.Size = new System.Drawing.Size(120, 45);
            this.obtiznost.TabIndex = 4;
            this.obtiznost.Value = 1;
            this.obtiznost.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // obtiznostText
            // 
            this.obtiznostText.AutoSize = true;
            this.obtiznostText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.obtiznostText.ForeColor = System.Drawing.Color.Red;
            this.obtiznostText.Location = new System.Drawing.Point(20, 46);
            this.obtiznostText.Name = "obtiznostText";
            this.obtiznostText.Size = new System.Drawing.Size(30, 31);
            this.obtiznostText.TabIndex = 3;
            this.obtiznostText.Text = "1";
            this.obtiznostText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Obtiznosts
            // 
            this.Obtiznosts.AutoSize = true;
            this.Obtiznosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Obtiznosts.ForeColor = System.Drawing.Color.White;
            this.Obtiznosts.Location = new System.Drawing.Point(20, 15);
            this.Obtiznosts.Name = "Obtiznosts";
            this.Obtiznosts.Size = new System.Drawing.Size(148, 31);
            this.Obtiznosts.TabIndex = 3;
            this.Obtiznosts.Text = "Obtížnost:";
            this.Obtiznosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UlozitButton
            // 
            this.UlozitButton.Enabled = false;
            this.UlozitButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.UlozitButton.FlatAppearance.BorderSize = 3;
            this.UlozitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.UlozitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.UlozitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UlozitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UlozitButton.ForeColor = System.Drawing.Color.White;
            this.UlozitButton.Location = new System.Drawing.Point(96, 116);
            this.UlozitButton.Name = "UlozitButton";
            this.UlozitButton.Size = new System.Drawing.Size(142, 28);
            this.UlozitButton.TabIndex = 0;
            this.UlozitButton.Text = "Uložit hru";
            this.UlozitButton.UseVisualStyleBackColor = true;
            this.UlozitButton.Visible = false;
            this.UlozitButton.Click += new System.EventHandler(this.UlozitButton_Click);
            this.UlozitButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // KonecButton
            // 
            this.KonecButton.Enabled = false;
            this.KonecButton.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.KonecButton.FlatAppearance.BorderSize = 3;
            this.KonecButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.KonecButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.KonecButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KonecButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KonecButton.ForeColor = System.Drawing.Color.White;
            this.KonecButton.Location = new System.Drawing.Point(96, 162);
            this.KonecButton.Name = "KonecButton";
            this.KonecButton.Size = new System.Drawing.Size(142, 28);
            this.KonecButton.TabIndex = 3;
            this.KonecButton.Text = "Konec hry";
            this.KonecButton.UseVisualStyleBackColor = true;
            this.KonecButton.Visible = false;
            this.KonecButton.Click += new System.EventHandler(this.KonecButton_Click);
            this.KonecButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(542, 365);
            this.Controls.Add(this.KonecButton);
            this.Controls.Add(this.UlozitButton);
            this.Controls.Add(this.menuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TetrisX";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obtiznost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label Obtiznosts;
        private System.Windows.Forms.TrackBar obtiznost;
        private System.Windows.Forms.Label obtiznostText;
        private System.Windows.Forms.Button PosledniButton;
        private System.Windows.Forms.Button NovaHraButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button UlozitButton;
        private System.Windows.Forms.Button KonecButton;
    }
}

