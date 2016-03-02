using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjektKatastr
{
    public partial class UpraveniVlastnictvi : Form
    {
        public UpraveniVlastnictvi(int ID, string table)
        {
            InitializeComponent();
            this.ID = ID;
            this.table = table;
            SCSBuilder = new SqlConnectionStringBuilder();
            SCSBuilder["Server"] = ".\\SQLEXPRESS";
            SCSBuilder["Initial Catalog"] = "Vaclavek_DB";
            SCSBuilder["Trusted_Connection"] = true;
            conn = new SqlConnection(SCSBuilder.ConnectionString);
            NactiTabulky();
        }
        int ID;
        string table;
        string innerjoin = "";
        SqlConnectionStringBuilder SCSBuilder;
        SqlConnection conn;
        private void NactiTabulky()
        {
            if (table == "Parcely")
                innerjoin = "Vlastnici_Parcely ON Vlastnici.ID = Vlastnici_Parcely.ID_Vlastnik WHERE Vlastnici_Parcely.ID_Parcela";
            else
                innerjoin = "Vlastnici_Stavby ON Vlastnici.ID = Vlastnici_Stavby.ID_Vlastnik WHERE Vlastnici_Stavby.ID_Stavba";
            SqlCommand cmm = new SqlCommand("SELECT ID,Jmeno as 'Jméno', Prijmeni as 'Příjmení', Ulice, Mesto as 'Město',PSC as 'PSČ' FROM Vlastnici INNER JOIN " + innerjoin + " = @id", conn);
            cmm.Parameters.Add("@id", SqlDbType.Int);
            cmm.Parameters["@id"].Value = ID;
            DataTable dTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmm);
            da.Fill(dTable);
            DGV.DataSource = dTable;
            btn2.Enabled = false;
            if (DGV.RowCount > 1) btn2.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /* Vybere jenom vlastníky kteří tuto parcelu nevlastní - zabrání duplicitě vlastníků */
            string command = "";
            if (table == "Parcely")
                command = "SELECT Vlastnici.ID,Jmeno as 'Jméno', Prijmeni as 'Příjmení', Ulice, Mesto as 'Město',PSC as 'PSČ' FROM Vlastnici LEFT JOIN (SELECT ID FROM Vlastnici JOIN Vlastnici_Parcely ON ID_Vlastnik = ID WHERE ID_Parcela = " + ID + ") VlastniciParcely ON Vlastnici.ID = VlastniciParcely.ID WHERE VlastniciParcely.ID IS NULL";
            else
                command = "SELECT Vlastnici.ID,Jmeno as 'Jméno', Prijmeni as 'Příjmení', Ulice, Mesto as 'Město',PSC as 'PSČ' FROM Vlastnici LEFT JOIN (SELECT ID FROM Vlastnici JOIN Vlastnici_Stavby ON ID_Vlastnik = ID WHERE ID_Stavba = " + ID + ") VlastniciStavby ON Vlastnici.ID = VlastniciStavby.ID WHERE VlastniciStavby.ID IS NULL";
           
            
            DGVDialog dvg = new DGVDialog(command);
            if (dvg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int novyVlastnik = Convert.ToInt32(dvg.DGVR.Cells["ID"].Value);
                conn.Open();
                command = "INSERT INTO Vlastnici_" + table + " VALUES (@ID_Objekt,@ID_Vlastnik)";

                SqlCommand comm = new SqlCommand(command, conn);
                comm.Parameters.Add("@ID_Objekt", SqlDbType.Int);
                comm.Parameters["@ID_Objekt"].Value = ID;

                comm.Parameters.Add("@ID_Vlastnik", SqlDbType.Int);
                comm.Parameters["@ID_Vlastnik"].Value = novyVlastnik;

                comm.ExecuteNonQuery();
                conn.Close();

                NactiTabulky();
            }
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                btn1.Enabled = false;
                if (DGV.SelectedRows[0].Cells["ID"].Value.ToString() == "") return;
                btn1.Enabled = true;
            }
            catch (Exception) { }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string command = "";
            if (table == "Parcely") command = "DELETE FROM Vlastnici_Parcely WHERE ID_Parcela = @ID_Objekt AND ID_Vlastnik = @ID_Vlastnik";
            else command = "DELETE FROM Vlastnici_Stavby WHERE ID_Stavba = @ID_Objekt AND ID_Vlastnik = @ID_Vlastnik";
            SqlCommand comm = new SqlCommand(command, conn);
            comm.Parameters.Add("@ID_Objekt", SqlDbType.Int);
            comm.Parameters["@ID_Objekt"].Value = ID;

            comm.Parameters.Add("@ID_Vlastnik", SqlDbType.Int);
            comm.Parameters["@ID_Vlastnik"].Value = Convert.ToInt32(DGV.SelectedRows[0].Cells["ID"].Value);
            comm.ExecuteNonQuery();

            conn.Close();

            NactiTabulky();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            int staryVlastnik = Convert.ToInt32(DGV.SelectedRows[0].Cells["ID"].Value);
            string command = "";
            if (table == "Parcely")
                command = "SELECT Vlastnici.ID,Jmeno as 'Jméno', Prijmeni as 'Příjmení', Ulice, Mesto as 'Město',PSC as 'PSČ' FROM Vlastnici LEFT JOIN (SELECT ID FROM Vlastnici JOIN Vlastnici_Parcely ON ID_Vlastnik = ID WHERE ID_Parcela = " + ID + ") VlastniciParcely ON Vlastnici.ID = VlastniciParcely.ID WHERE VlastniciParcely.ID IS NULL";
            else
                command = "SELECT Vlastnici.ID,Jmeno as 'Jméno', Prijmeni as 'Příjmení', Ulice, Mesto as 'Město',PSC as 'PSČ' FROM Vlastnici LEFT JOIN (SELECT ID FROM Vlastnici JOIN Vlastnici_Stavby ON ID_Vlastnik = ID WHERE ID_Stavba = " + ID + ") VlastniciStavby ON Vlastnici.ID = VlastniciStavby.ID WHERE VlastniciStavby.ID IS NULL";


            DGVDialog dvg = new DGVDialog(command);
            if (dvg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int novyVlastnik = Convert.ToInt32(dvg.DGVR.Cells["ID"].Value);
                conn.Open();
                if (table == "Parcely")
                    command = "UPDATE Vlastnici_Parcely SET ID_Vlastnik = @ID_Vlastnik WHERE ID_Vlastnik = @staryVlastnik AND ID_Parcela=@id";
                else command = "UPDATE Vlastnici_Stavby SET ID_Vlastnik = @ID_Vlastnik WHERE ID_Vlastnik = @staryVlastnik AND ID_Stavba=@id";

                SqlCommand comm = new SqlCommand(command, conn);
                comm.Parameters.Add("@ID_Vlastnik", SqlDbType.Int);
                comm.Parameters["@ID_Vlastnik"].Value = novyVlastnik;

                comm.Parameters.Add("@staryVlastnik", SqlDbType.Int);
                comm.Parameters["@staryVlastnik"].Value = staryVlastnik;

                comm.Parameters.Add("@id", SqlDbType.Int);
                comm.Parameters["@id"].Value = ID;

                comm.ExecuteNonQuery();
                conn.Close();

                NactiTabulky();
            }
        }
    }
}
