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
    public partial class fmDetail : Form
    {
        String id_monhoc;
        public fmDetail()
        {
            InitializeComponent();
        }
        public fmDetail(string x, string y) : this()
        {
            id_monhoc = y;
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC;Initial Catalog=QLSV;Integrated Security=True");
            string query = "select SINHVIEN.MSSV, SINHVIEN.HOCTEN, DIEMTHI.DIEM from DIEMTHI inner join SINHVIEN on DIEMTHI.MSSV = SINHVIEN.MSSV inner join MONHOC on DIEMTHI.MAMON = MONHOC.MAMON where SINHVIEN.MALOP='" + x + "' AND MONHOC.MAMON='" + y + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dbtb = new DataTable();
            conn.Open();
            sda.Fill(dbtb);
            conn.Close();
            dataGridView1.DataSource = dbtb;
        }
        private void fmDetail_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
