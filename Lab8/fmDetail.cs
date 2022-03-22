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
        String id_monhoc,id_sinhvien;
        SqlCommandBuilder scb;
        SqlDataAdapter sda;
        DataTable dbtb;
        public fmDetail()
        {
            InitializeComponent();
        }
        public fmDetail(string x, string y) : this()
        {
            id_monhoc = y;
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC;Initial Catalog=QLSV;Integrated Security=True");
            string query = "select DISTINCT SINHVIEN.MSSV, SINHVIEN.HOCTEN, DIEMTHI.DIEM from DIEMTHI inner join SINHVIEN on DIEMTHI.MSSV = SINHVIEN.MSSV inner join MONHOC on DIEMTHI.MAMON = MONHOC.MAMON where SINHVIEN.MALOP='" + x + "' AND MONHOC.MAMON='" + y + "'";
            sda = new SqlDataAdapter(query, conn);
            dbtb = new DataTable();
            // conn.Open();
            sda.Fill(dbtb);
            dataGridView1.DataSource = dbtb;
        }
        private void fmDetail_Load(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(dbtb);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Refresh();
        }
    }
}
