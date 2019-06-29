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
    public partial class viewreqcrop : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public viewreqcrop()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void viewreqcrop_Load(object sender, EventArgs e)
        {

        }
        int a_id;
        int d;
        public void ad_id(int i)
        {
            a_id = i;
            con.Open();
            string query1 = "select count(*) from ads_farmer where id_ads = '" + a_id + "' and id_farmer = '" + Form1.id_user + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);

            d = (int)cmd1.ExecuteScalar();
            con.Close();
            if (d != 0)
            {
                con.Open();
                string query = "select statue from ads_farmer where id_ads = '" + a_id + "' and id_farmer = '" + Form1.id_user + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                string f = (string)cmd.ExecuteScalar();
                con.Close();
                if (f == "Accept    ")
                {
                    radioButton1.Checked = true;
                }
                else if (f == "Reject    ")
                {
                    radioButton2.Checked = true;
                }
            }
        }
        public void st()
        {


        }
        public void c_name(string n)
        {
            label1.Text = n;
        }
        public void quality(string q)
        {
            label4.Text = q;
        }
        public void price(int p)
        {
            label6.Text = p.ToString();
        }
        public void s_name(int i)
        {
            con.Open();
            string query = "select name from supplier where id_supplier ='" + i + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            label7.Text = (string)cmd.ExecuteScalar();
            con.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            con.Open();
            string query1 = "select count(*) from ads_farmer where id_ads = '" + a_id + "' and id_farmer = '" + Form1.id_user + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            if ((int)cmd1.ExecuteScalar() == 0)
            {
                string query = "insert into ads_farmer (id_ads,id_farmer,statue) values (@id_ads,@id_farmer,@statue)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id_ads", a_id);
                cmd.Parameters.AddWithValue("@id_farmer", Form1.id_user);
                cmd.Parameters.AddWithValue("@statue", radioButton1.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
                string query = "update ads_farmer set statue='" + radioButton1.Text + "' where id_ads = '" + a_id + "' and id_farmer = '" + Form1.id_user + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            con.Open();
            string query1 = "select count(*) from ads_farmer where id_ads = '" + a_id + "' and id_farmer = '" + Form1.id_user + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            if ((int)cmd1.ExecuteScalar() == 0)
            {
                string query = "insert into ads_farmer (id_ads,id_farmer,statue) values (@id_ads,@id_farmer,@statue)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id_ads", a_id);
                cmd.Parameters.AddWithValue("@id_farmer", Form1.id_user);
                cmd.Parameters.AddWithValue("@statue", radioButton2.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
                string query = "update ads_farmer set statue='" + radioButton2.Text + "' where id_ads = '" + a_id + "' and id_farmer = '" + Form1.id_user + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
