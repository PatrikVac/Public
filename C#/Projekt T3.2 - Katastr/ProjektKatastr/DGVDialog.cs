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
    public partial class DGVDialog : Form
    {
        public DGVDialog(string cmd)
        {
            InitializeComponent();
            SCSBuilder = new SqlConnectionStringBuilder();
            SCSBuilder["Server"] = ".\\SQLEXPRESS";
            SCSBuilder["Initial Catalog"] = "Vaclavek_DB";
            SCSBuilder["Trusted_Connection"] = true;
            conn = new SqlConnection(SCSBuilder.ConnectionString);
            SqlCommand cmm = new SqlCommand(cmd, conn);
            DataTable dTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmm);
            da.Fill(dTable);
            DGV.DataSource = dTable;
        }
        public DataGridViewRow DGVR;
        SqlConnectionStringBuilder SCSBuilder;
        SqlConnection conn;

        private void DGV3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            DGVR = DGV.SelectedRows[0];
        }
    }
}
