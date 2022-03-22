using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Lab8
{
    public partial class fmHome : Form
    {
        public fmHome()
        {
            InitializeComponent();
        }

        private void fmHome_Load(object sender, EventArgs e)
        {
            
        }
        public fmHome(string x):this()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC;Initial Catalog=QLSV;Integrated Security=True");
            string query = "SELECT GIANGDAY.MAMON, MONHOC.TENMONHOC,LOP.MALOP, LOP.TENLOP from GIANGDAY INNER JOIN MONHOC ON GIANGDAY.MAMON = MONHOC.MAMON Inner join LOP on giangday.MALOP = lop.MALOP WHERE MACB = '" + x + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dbtb = new DataTable();
            conn.Open();
            sda.Fill(dbtb);
            conn.Close();
            dataGridView1.DataSource = dbtb;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            this.Hide();
            fmDetail objfmDetailClass = new fmDetail(row.Cells[2].ToString(), row.Cells[0].ToString());
            objfmDetailClass.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
