namespace Vlacky
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
            this.Extra_B = new System.Windows.Forms.Button();
            this.Extra_1 = new System.Windows.Forms.ComboBox();
            this.Extra_2 = new System.Windows.Forms.ComboBox();
            this.AlarmB = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Extra_B
            // 
            this.Extra_B.Location = new System.Drawing.Point(487, 12);
            this.Extra_B.Name = "Extra_B";
            this.Extra_B.Size = new System.Drawing.Size(74, 33);
            this.Extra_B.TabIndex = 0;
            this.Extra_B.Text = "Vyslat vlak";
            this.Extra_B.UseVisualStyleBackColor = true;
            this.Extra_B.Click += new System.EventHandler(this.Extra_B_Click);
            // 
            // Extra_1
            // 
            this.Extra_1.FormattingEnabled = true;
            this.Extra_1.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.Extra_1.Location = new System.Drawing.Point(395, 19);
            this.Extra_1.Name = "Extra_1";
            this.Extra_1.Size = new System.Drawing.Size(33, 21);
            this.Extra_1.TabIndex = 1;
            this.Extra_1.Text = "A";
            // 
            // Extra_2
            // 
            this.Extra_2.FormattingEnabled = true;
            this.Extra_2.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.Extra_2.Location = new System.Drawing.Point(434, 19);
            this.Extra_2.Name = "Extra_2";
            this.Extra_2.Size = new System.Drawing.Size(34, 21);
            this.Extra_2.TabIndex = 2;
            this.Extra_2.Text = "B";
            // 
            // AlarmB
            // 
            this.AlarmB.BackColor = System.Drawing.Color.Red;
            this.AlarmB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AlarmB.Location = new System.Drawing.Point(228, 22);
            this.AlarmB.Name = "AlarmB";
            this.AlarmB.Size = new System.Drawing.Size(113, 23);
            this.AlarmB.TabIndex = 3;
            this.AlarmB.Text = "Potvrdit alarm";
            this.AlarmB.UseVisualStyleBackColor = false;
            this.AlarmB.Visible = false;
            this.AlarmB.Click += new System.EventHandler(this.AlarmB_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(573, 177);
            this.Controls.Add(this.AlarmB);
            this.Controls.Add(this.Extra_2);
            this.Controls.Add(this.Extra_1);
            this.Controls.Add(this.Extra_B);
            this.Name = "Form1";
            this.Text = "Vlaky";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Extra_B;
        private System.Windows.Forms.ComboBox Extra_1;
        private System.Windows.Forms.ComboBox Extra_2;
        private System.Windows.Forms.Button AlarmB;
        private System.Windows.Forms.Timer timer2;

    }
}

