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
    public partial class viewoffer : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public viewoffer()
        {
            InitializeComponent();
        }

        private void viewoffer_Load(object sender, EventArgs e)
        {

        }
        public void id_r(int r)
        {
            con.Open();
            string query = "select name from retailer where id_retailer = '" +r +"'";
            SqlCommand cmd = new SqlCommand(query, con);
            label1.Text = (string)cmd.ExecuteScalar();
            con.Close();
        }
        public void id_c(int c)
        {
            con.Open();
            string query = "select name from crop where id_crop = '" + c + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            label2.Text = (string)cmd.ExecuteScalar();
            con.Close();
        }
        public void price(int p)
        {
            label6.Text = p.ToString();
        }
        public void quantity(int q)
        {
            label8.Text = q.ToString();
        }
        public void statue(string s)
        {
            if (s == "Accept    ")
                radioButton1.Checked= true;
            else
                radioButton2.Checked = true;
        }
        int id;
        public void id_o(int i)
        {
            id = i;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = "update offer set statue='" + radioButton1.Text + "' where id_offer = '"+id+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = "update offer set statue='" + radioButton2.Text + "' where id_offer = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
