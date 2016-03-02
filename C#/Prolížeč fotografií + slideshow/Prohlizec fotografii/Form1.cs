using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Prohlizec_fotografii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pbs = new List<PictureBox>();
        }

        int rows = 0;
        int totalCount = 0;
        int count = 0;
        List<PictureBox> pbs;
        private void Otevrit_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Vyber slozku";
                dlg.RootFolder = System.Environment.SpecialFolder.MyPictures; 
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string[] files = Directory.GetFiles(dlg.SelectedPath);
                    string[] allowedImgs = {".jpg",".jpeg",".png",".gif",".bmp"};
                    
                    foreach (string file in files)
                    {
                        if (in_array(allowedImgs, Path.GetExtension(file)))
                        {
                            
                            PictureBox pb = new PictureBox();
                            pb.Image = Image.FromFile(file);
                            pb.SizeMode = PictureBoxSizeMode.Zoom;
                            pb.Name = "pb" + totalCount;
                            pb.Size = new System.Drawing.Size(50, 50);
                            pb.Click += pbClick;
                            panel1.Controls.Add(pb);
                            int newX = count * (pb.Width + 10);
                            int row = (int)Math.Floor((double)((newX + 60) / panel1.Width));
                            if (row != 0) {
                                rows++;
                                count = 0;
                                newX = count * (pb.Width + 10);
                            }
                            int newY = (pb.Height + 10) * rows;
                            pb.Location = new Point(newX,newY);
                            pbs.Add(pb);
                            count++; totalCount++;
                        }
                            
                    }
                }
            }
        }
        public void pbClick(object o, EventArgs e)
        {
            int index = Convert.ToInt32(((PictureBox)o).Name.Replace("pb",""));
            //
            Form2 nahled = new Form2(pbs, pbs.IndexOf((PictureBox)o));
            nahled.Show();
        }
        public bool in_array(string[] arr,string str){
            foreach (string s in arr)
            {
                if (s == str) return true;        
            }
            return false;
        }
    }
}
