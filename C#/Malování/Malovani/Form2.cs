using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Malovani
{
    public partial class inForm : Form
    {
        public bool zmena = false;
        public string ulozeno;
        public float size;
        public Color color;
        public Bitmap bmp;
        public Graphics g;
        Pen p;
        int oX, oY, nX, nY;
        bool malovani;
        public int PaintType = 0;
        /* 0 - štětec
         * 1 - čára
         * 2 - kruh
         * 3 - obdélník
         */
        List<Color> originalColors = new List<Color>();
        public inForm(string name, float inSize, Color inColor, int inWidth, int inHeight, Color inBackColor)
        {
            InitializeComponent();
            //----------
            this.Text = name;
            size = inSize;
            color = inColor;
            p = new Pen(inColor, inSize);
            bmp = new Bitmap(inWidth, inHeight);
            g = Graphics.FromImage(bmp);
            g.Clear(inBackColor);
            //----------   
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            AutoScroll = true;
            AutoScrollMinSize = bmp.Size;
            malovani = false;          
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        public inForm(string inFile, float inSize, Color inColor)
        {
            InitializeComponent();
            //----------
            this.Text = inFile;
            size = inSize;
            color = inColor;
            p = new Pen(inColor, inSize);
            bmp = new Bitmap(Image.FromFile(inFile));
            g = Graphics.FromImage(bmp);
            ulozeno = inFile;
            //----------   
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            AutoScroll = true;
            AutoScrollMinSize = bmp.Size;
            malovani = false;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                malovani = true;
                oX = e.X - AutoScrollPosition.X;
                oY = e.Y - AutoScrollPosition.Y;
            }
            else Invalidate();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(bmp, new Point(AutoScrollPosition.X, AutoScrollPosition.Y));
            if (malovani == true)
            {
                switch (PaintType)
                {
                    case 1:
                        SetPen();
                        Point local = this.PointToClient(Cursor.Position);
                        gr.DrawLine(p, oX + AutoScrollPosition.X, oY + AutoScrollPosition.Y, local.X, local.Y);
                        break;
                    case 2:
                        SetPen();
                        local = this.PointToClient(Cursor.Position);
                        if (size > Math.Abs(local.X - (oX + AutoScrollPosition.X)) || size > Math.Abs(local.Y - (oY + AutoScrollPosition.Y)))
                        {
                            if (Math.Abs(local.X - (oX + AutoScrollPosition.X)) > Math.Abs(local.Y - (oY + AutoScrollPosition.Y)))
                                p = new Pen(color, Math.Abs(local.Y - (oY + AutoScrollPosition.Y)));
                            else
                                p = new Pen(color, Math.Abs(local.X - (oX + AutoScrollPosition.X)));
                        }
                        gr.DrawEllipse(p, oX + AutoScrollPosition.X, oY + AutoScrollPosition.Y, local.X - (oX + AutoScrollPosition.X), local.Y - (oY + AutoScrollPosition.Y));
                        break;
                    case 3:
                        SetPen();
                        local = this.PointToClient(Cursor.Position);
                        int nnX = local.X - (oX + AutoScrollPosition.X), nnY = local.Y - (oY + AutoScrollPosition.Y);
                        int ooX = (oX + AutoScrollPosition.X), ooY = (oY + AutoScrollPosition.Y); 
                        if (size > Math.Abs(local.X - (oX + AutoScrollPosition.X)) || size > Math.Abs(local.Y - (oY + AutoScrollPosition.Y)))
                        {
                            if (Math.Abs(local.X - (oX + AutoScrollPosition.X)) > Math.Abs(local.Y - (oY + AutoScrollPosition.Y)))
                                p = new Pen(color, Math.Abs(local.Y - (oY + AutoScrollPosition.Y)));
                            else
                                p = new Pen(color, Math.Abs(local.X - (oX + AutoScrollPosition.X)));
                        }
                        gr.DrawRectangle(p, ooX, ooY, nnX, nnY);
                        break;
                    case 4:
                        Pen DashPen = new Pen(Brushes.Black, 1f);
                        DashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        local = this.PointToClient(Cursor.Position);
                        gr.DrawRectangle(DashPen, oX + AutoScrollPosition.X, oY + AutoScrollPosition.Y, local.X - (oX + AutoScrollPosition.X), local.Y - (oY + AutoScrollPosition.Y));
                        break;
                }
            }
        }
        private void SetPen()
        {
            p = new Pen(color, size);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && malovani)
            {
                switch (PaintType)
                {
                    case 1:
                        SetPen();
                        g.DrawLine(p, oX, oY, e.X - AutoScrollPosition.X, e.Y - AutoScrollPosition.Y);
                        break;
                    case 2:
                        SetPen();
                        Point local = this.PointToClient(Cursor.Position);
                        if (size > Math.Abs(local.X - (oX + AutoScrollPosition.X)) || size > Math.Abs(local.Y - (oY + AutoScrollPosition.Y)))
                        {
                            if (Math.Abs(local.X - (oX + AutoScrollPosition.X)) > Math.Abs(local.Y - (oY + AutoScrollPosition.Y)))
                                p = new Pen(color, Math.Abs(local.Y - (oY + AutoScrollPosition.Y)));
                            else
                                p = new Pen(color, Math.Abs(local.X - (oX + AutoScrollPosition.X)));
                        }
                        g.DrawEllipse(p, oX, oY, e.X - oX - AutoScrollPosition.X, e.Y - oY - AutoScrollPosition.Y);
                        break;
                    case 3:
                        SetPen();
                        local = this.PointToClient(Cursor.Position);
                        int nX = e.X - oX - AutoScrollPosition.X;
                        int nY = e.Y - oY - AutoScrollPosition.Y;
                        if (size > Math.Abs(local.X - (oX + AutoScrollPosition.X)) || size > Math.Abs(local.Y - (oY + AutoScrollPosition.Y)))
                        {
                            if (Math.Abs(local.X - (oX + AutoScrollPosition.X)) > Math.Abs(local.Y - (oY + AutoScrollPosition.Y)))
                                p = new Pen(color, Math.Abs(local.Y - (oY + AutoScrollPosition.Y)));
                            else
                                p = new Pen(color, Math.Abs(local.X - (oX + AutoScrollPosition.X)));
                        }
                        g.DrawRectangle(p, oX, oY, nX, nY);
                        break;
                    case 4:
                        local = this.PointToClient(Cursor.Position);
                        inText.Text = "";
                        inText.Location = new Point(oX + AutoScrollPosition.X, oY + AutoScrollPosition.Y);
                        inText.Size = new Size(e.X - oX - AutoScrollPosition.X, e.Y - oY - AutoScrollPosition.Y);
                        inText.Visible = true;
                        ((Form1)MdiParent).FontBox.Visible = true;
                        break;
                }
                zmena = true;
            }
            Invalidate();
            malovani = false;
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (malovani)
            {
                switch(PaintType)
                {
                    case 0:
                        p = new Pen(color, size);
                        p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        nX = e.X - AutoScrollPosition.X;
                        nY = e.Y - AutoScrollPosition.Y;
                        g.DrawLine(p, oX, oY, nX, nY);
                        oX = nX; oY = nY;
                    break;
                }
                Invalidate();
            }
        }

        private void inText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Control)
            {
                Font f = inText.Font;
                StringFormat sf = new StringFormat();

                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                Brush s = Brushes.Black;
                Point local = this.PointToClient(Cursor.Position);
                Rectangle r = new Rectangle(oX, oY, inText.Width, inText.Height);
                g.DrawString(inText.Text, f, new SolidBrush(color), r, sf);
                inText.Hide();
                ((Form1)MdiParent).FontBox.Visible = false;
                Invalidate();
            }
        }
        /* u změny RGB kanálů jsem naprosto nepochopil zadání*/
        public void ChangeC(int val, string color)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color orig = bmp.GetPixel(i, j);
                    int nRed = orig.R, nGreen = orig.G, nBlue = orig.B;
                    if(color == "R")
                        nRed = val;
                    if (color == "G")
                        nGreen = val;
                    if (color == "B")
                        nBlue = val;
                    Color newColor = Color.FromArgb(val, nRed, nGreen, nBlue);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            Invalidate();
            
        }
        private void inForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (zmena)
            {
                Dialog dg = new Dialog("Uložit..", "Chcete před zavřením uložit " + this.Text + "?", "Uložit", "Neukládat", "Zrušit");
                DialogResult dr = dg.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    if (ulozeno != null)
                    {
                        bmp.Save(ulozeno);
                        zmena = false;
                        e.Cancel = false;
                    }
                    else
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Jpeg|*.jpeg|Jpg|*.jpg|PNG|*.png|Bitmap|*.bmp|Gif|*.gif";
                        sfd.FileName = "Nový obrázek";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            bmp.Save(sfd.FileName);
                            ulozeno = sfd.FileName;
                            zmena = false;
                            e.Cancel = false;
                        }
                    }
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
                else if (dr == DialogResult.No)
                    e.Cancel = false;
            }
        }
    }
}
