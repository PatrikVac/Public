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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SCSBuilder = new SqlConnectionStringBuilder();
            SCSBuilder["Server"] = ".\\SQLEXPRESS";
            SCSBuilder["Initial Catalog"] = "Vaclavek_DB";
            SCSBuilder["Trusted_Connection"] = true;
            conn = new SqlConnection(SCSBuilder.ConnectionString);
        }

        SqlConnectionStringBuilder SCSBuilder;
        SqlConnection conn;

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void check1CH(object sender, EventArgs e)
        {
            if (check1.Checked)
            {
                check2.Checked = false;
                lbl1.Text = "Číslo parcely:";
            }
        }

        private void check2CH(object sender, EventArgs e)
        {
            if (check2.Checked)
            {
                check1.Checked = false;
                lbl1.Text = "Číslo popisné:";
            }
        }
        private DataTable Parcela(int CisloParcely)
        {
            int ID = 0;
            DataTable dTable = new DataTable();
            SqlCommand cmd = new SqlCommand("ZjistiParcelu", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cisloParcely", CisloParcely));
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            try
            {
                ID = (int)rdr["ID"];
            }
            catch (Exception)
            { MessageBox.Show("Tento záznam neexistuje!"); conn.Close(); return dTable; }
            conn.Close();
            cmd = new SqlCommand(
                "Select Cislo as 'Číslo parcely',Vymera as 'Výměra', Druh, Omezeni.Typ as 'Omezení', KatastralniUzemi as 'Katastrální území', Obec, CastObce as 'Část obce',(Vlastnici.Jmeno) + (' ') + (Vlastnici.Prijmeni) as 'Vlastník' from Parcely LEFT JOIN Omezeni ON Omezeni.ID = Parcely.Omezeni JOIN Vlastnici_Parcely ON Parcely.ID = Vlastnici_Parcely.ID_Parcela JOIN Vlastnici ON Vlastnici_Parcely.ID_Vlastnik = Vlastnici.ID WHERE Parcely.ID = @id", conn);
        
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = ID;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dTable);
            return dTable;
        }
        private DataTable Stavba(int CisloParcely)
        {
            int ID = 0;
            DataTable dTable = new DataTable();
            SqlCommand cmd = new SqlCommand("ZjistiStavbu", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cisloPopisne", CisloParcely));
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            try
            {
                ID = (int)rdr["ID"];
            }
            catch (Exception)
            { MessageBox.Show("Tento záznam neexistuje!"); conn.Close(); return dTable; }
            conn.Close();
            cmd = new SqlCommand(
                "Select Stavby.ID, Stavby.ID_Parcela as 'Na parcele s ID',Cislo_Popisne as 'Číslo popisné', Stavby.Typ, Omezeni.Typ as 'Omezení' FROM Stavby LEFT JOIN Omezeni ON Omezeni.ID = Stavby.Omezeni WHERE Stavby.ID = @id", conn);

            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = ID;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dTable);
            return dTable;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            int cislo;
            try
            {
                cislo = Convert.ToInt32(txt1.Text);
            }
            catch (Exception)
            { MessageBox.Show("Zadán neplatný vstup. Vložte číslo."); return; }
            
            if(check1.Checked)
                DGV1.DataSource = Parcela(cislo);
            else DGV1.DataSource = Stavba(cislo);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string where = "";
            if (txt2.Text != "")
                where += " AND KatastralniUzemi = '" + txt2.Text + "'";
            if (txt3.Text != "")
                where += " AND Obec = '" + txt3.Text + "'";
            if (txt4.Text != "")
                where += " AND CastObce = '" + txt4.Text + "'";
            SqlCommand cmd = new SqlCommand(
                 "Select Cislo as 'Číslo parcely',Vymera as 'Výměra', Druh, Omezeni.Typ as 'Omezení', KatastralniUzemi as 'Katastrální území', Obec, CastObce as 'Část obce' from Parcely LEFT JOIN Omezeni ON Omezeni.ID = Parcely.Omezeni WHERE Parcely.ID = Parcely.ID" + where, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();
            da.Fill(dTable);
            DGV2.DataSource = dTable;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                 "Select ID,Typ, VeProspech as 'Ve prospěch',Datum, IDParcely as 'Pro parcelu s ID', IDStavby as 'Pro stavbu s ID' FROM Omezeni", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();
            da.Fill(dTable);
            DGV3.DataSource = dTable;
        }

        private void DGV3_SelectionChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                btn6.Enabled = false;
                if (DGV3.SelectedRows[0].Cells["ID"].Value.ToString() == "") return;
                else btn6.Enabled = true;

                if (DGV3.SelectedRows[0].Cells["Pro parcelu s ID"].Value.ToString() == "" || DGV3.SelectedRows[0].Cells["Pro parcelu s ID"].Value.ToString() == "0")
                    cmd = new SqlCommand("Select Stavby.ID_Parcela as 'Na parcele s ID',Cislo_Popisne as 'Číslo popisné', Stavby.Typ FROM Stavby WHERE ID = " + DGV3.SelectedRows[0].Cells["Pro stavbu s ID"].Value, conn);
                else cmd = new SqlCommand("Select Cislo as 'Číslo parcely',Vymera as 'Výměra', Druh, KatastralniUzemi as 'Katastrální území', Obec, CastObce as 'Část obce' FROM Parcely WHERE ID = " + DGV3.SelectedRows[0].Cells["Pro parcelu s ID"].Value, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();
            da.Fill(dTable);
            DGV4.DataSource = dTable;

            cmd = new SqlCommand("Select Jmeno as 'Jméno', Prijmeni as 'Příjmení', Ulice, Mesto as 'Město',PSC as 'PSČ' FROM Vlastnici WHERE ID = " + DGV3.SelectedRows[0].Cells["Ve prospěch"].Value, conn);

            da = new SqlDataAdapter(cmd);
            dTable = new DataTable();
            da.Fill(dTable);
            DGV5.DataSource = dTable;
            }
            catch (Exception) { }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            OmezeniSprava os = new OmezeniSprava();

            if (os.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int IDStavba = 0, IDParcela = 0, ID;
                string typ, UpdateString;
                if (os.check1.Checked) // parcela
                {
                    IDParcela = Convert.ToInt32(os.lbl1.Text);
                    typ = os.combo1.Text;
                    UpdateString = "UPDATE Parcely SET Omezeni=@IDomezeni WHERE ID=@ID";
                    ID = IDParcela;
                }
                else // stavba
                {
                    IDStavba = Convert.ToInt32(os.lbl2.Text);
                    typ = os.combo2.Text;
                    UpdateString = "UPDATE Stavby SET Omezeni=@IDomezeni WHERE ID=@ID";
                    ID = IDStavba;
                }
                int IDprospech = Convert.ToInt32(os.lbl5.Text);
                conn.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO Omezeni VALUES(@typ, @IDprospech, @Date,@IDParcela,@IDStavba)", conn);
                comm.Parameters.Add("@typ", SqlDbType.VarChar);
                comm.Parameters.Add("@IDprospech", SqlDbType.Int);
                comm.Parameters.Add("@Date", SqlDbType.Date);
                comm.Parameters.Add("@IDParcela", SqlDbType.Int);
                comm.Parameters.Add("@IDStavba", SqlDbType.Int);
                comm.Parameters["@typ"].Value = typ;
                comm.Parameters["@IDprospech"].Value = IDprospech;
                comm.Parameters["@Date"].Value = DateTime.Now;
                comm.Parameters["@IDParcela"].Value = IDParcela;
                comm.Parameters["@IDStavba"].Value = IDStavba;
                comm.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                comm = new SqlCommand("SELECT max(ID) as maxID FROM Omezeni", conn);
                int IDomezeni = (int)comm.ExecuteScalar();
                conn.Close();
                conn.Open();

                comm = new SqlCommand(UpdateString,conn);
                comm.Parameters.Add("@IDomezeni", SqlDbType.Int);
                comm.Parameters["@IDomezeni"].Value = IDomezeni;
                comm.Parameters.Add("@ID", SqlDbType.Int);
                comm.Parameters["@ID"].Value = ID;
                comm.ExecuteNonQuery();

                conn.Close();
                btn3_Click(btn3, EventArgs.Empty);
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(DGV3.SelectedRows[0].Cells["ID"].Value);
            conn.Open();
            SqlCommand comm = new SqlCommand("DELETE FROM Omezeni WHERE ID = @ID", conn);
            comm.Parameters.Add("@ID", SqlDbType.Int);
            comm.Parameters["@ID"].Value = ID;
            comm.ExecuteNonQuery();

            if (DGV3.SelectedRows[0].Cells["Pro parcelu s ID"].Value.ToString() == "" || DGV3.SelectedRows[0].Cells["Pro parcelu s ID"].Value.ToString() == "0")
                comm.CommandText = "UPDATE Stavby SET Omezeni=NULL WHERE Omezeni=@ID";
            else
                comm.CommandText = "UPDATE Parcely SET Omezeni=NULL WHERE Omezeni=@ID";

            comm.ExecuteNonQuery();
            conn.Close();
            btn3_Click(btn3, EventArgs.Empty);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                 "SELECT DISTINCT pID as 'ID',Cislo as 'Číslo parcely', Vymera as 'Výměra',Druh,omezeni as 'Omezení',KatastralniUzemi as 'Katastrální území',Obec,CastObce as 'Část obce','Vlastníci' = Stuff((SELECT ', ' + Vst as [text()] FROM (SELECT Cislo,(Vlastnici.Jmeno) + (' ') + (Vlastnici.Prijmeni) as 'Vst' FROM Parcely LEFT JOIN Vlastnici_Parcely ON Parcely.ID = Vlastnici_Parcely.ID_Parcela LEFT JOIN Vlastnici ON Vlastnici_Parcely.ID_Vlastnik = Vlastnici.ID) t2 WHERE t2.Cislo = t1.Cislo FOR XML PATH('')), 1,1,'') FROM (SELECT Parcely.ID as 'pID',Cislo,Vymera, Druh, KatastralniUzemi,Omezeni.Typ as 'omezeni', Obec, CastObce,(Vlastnici.Jmeno) + (' ') + (Vlastnici.Prijmeni) as 'Vst' FROM Parcely LEFT JOIN Omezeni ON Omezeni.ID = Parcely.Omezeni LEFT JOIN Vlastnici_Parcely ON Parcely.ID = Vlastnici_Parcely.ID_Parcela LEFT JOIN Vlastnici ON Vlastnici_Parcely.ID_Vlastnik = Vlastnici.ID) t1", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();
            da.Fill(dTable);
            DGV6.DataSource = dTable;

            cmd.CommandText =
                "SELECT DISTINCT sID as 'ID', ID_Parcela as 'Na parcele s ID',Cislo_Popisne as 'Číslo popisné', sTyp as 'Typ', omezeni as 'Omezení','Vlastníci' = Stuff((SELECT ', ' + Vst as [text()] FROM (SELECT Stavby.ID as 'sID',(Vlastnici.Jmeno) + (' ') + (Vlastnici.Prijmeni) as 'Vst' FROM Stavby LEFT JOIN Vlastnici_Stavby ON Stavby.ID = Vlastnici_Stavby.ID_Stavba LEFT JOIN Vlastnici ON Vlastnici_Stavby.ID_Vlastnik = Vlastnici.ID) t2 WHERE t2.sID = t1.sID FOR XML PATH('')), 1,1,'') FROM (SELECT Stavby.ID  as 'sID', ID_Parcela,Cislo_Popisne, Stavby.Typ as 'sTyp', Omezeni.Typ as 'omezeni',(Vlastnici.Jmeno) + (' ') + (Vlastnici.Prijmeni) as 'Vst' FROM Stavby LEFT JOIN Omezeni ON Omezeni.ID = Stavby.Omezeni LEFT JOIN Vlastnici_Stavby ON Stavby.ID = Vlastnici_Stavby.ID_Stavba LEFT JOIN Vlastnici ON Vlastnici_Stavby.ID_Vlastnik = Vlastnici.ID) t1";

            da = new SqlDataAdapter(cmd);
            dTable = new DataTable();
            da.Fill(dTable);
            DGV7.DataSource = dTable;

            DGV7.ClearSelection();
        }
        DataGridView DGV_pom;
        string table = "Parcely";
        private void DGV6_Click(object sender, EventArgs e)
        {
            DGV7.ClearSelection();
            DGV_pom = DGV6;
            table = "Parcely";
            SelectionCheck();
        }

        private void DGV7_Click(object sender, EventArgs e)
        {
            DGV6.ClearSelection();
            DGV_pom = DGV7;
            table = "Stavby";
            SelectionCheck();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(DGV_pom.SelectedRows[0].Cells["ID"].Value);
            UpraveniVlastnictvi uv = new UpraveniVlastnictvi(ID, table);
            if (uv.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                btn7_Click(btn7, EventArgs.Empty);
            }
        }

        private void DGVSelectionChanged(object sender, EventArgs e)
        {
            SelectionCheck();
        }
        private void SelectionCheck(){
            try
            {
                button1.Enabled = false;
                if (DGV_pom.SelectedRows[0].Cells["ID"].Value.ToString() == "") return;
                else button1.Enabled = true;
            }
            catch (Exception) { }
        }
    }
}
