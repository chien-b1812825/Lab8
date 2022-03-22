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
    public partial class fmLogin : Form
    {
        public fmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC;Initial Catalog=QLSV;Integrated Security=True");
            string query = "SELECT * from CANBO WHERE MACB = '" + txtUsername.Text.Trim() + "' and MATKHAU ='" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dbtb = new DataTable();
            sda.Fill(dbtb);
            if (dbtb.Rows.Count == 1)
            {
                fmHome objfmHome = new fmHome(txtUsername.Text.Trim());
                this.Hide();
                objfmHome.Show();
            }
            else
            {
                MessageBox.Show("Cannot connect");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
