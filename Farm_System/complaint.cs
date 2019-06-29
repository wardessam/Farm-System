using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Farm_System
{
    public partial class complaint : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public complaint()
        {
            InitializeComponent();
        }

        private void complaint_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        int id;
        public void id_g(int g)
        {
            string s = "";
            id = g;
            con.Open();
            string Query = "select statue from grivance where id_grivance=" + id;
            SqlCommand cmd = new SqlCommand(Query, con);
            if (cmd.ExecuteScalar() != DBNull.Value)
                s = (string)cmd.ExecuteScalar();
            con.Close();
            if (s != "")
            {
                if (s == "Accept")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
            }

        }
        public void topic(string t)
        {
            label8.Text = t.ToString();
        }
        public void id_f(int f)
        {
            con.Open();
            string Query = "select name from farmer where id_farmer=" + f;
            SqlCommand cmd = new SqlCommand(Query, con);
            label2.Text = (string)cmd.ExecuteScalar();

            con.Close();
        }



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string query = "update grivance set statue='" + radioButton1.Text + "'where id_grivance='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string query = "update grivance set statue='" + radioButton2.Text + "'where id_grivance='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
