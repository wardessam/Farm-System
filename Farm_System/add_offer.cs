using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Farm_System
{   
    public partial class add_offer : Form
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public int id_crop;
        public add_offer(int i)
        {
            InitializeComponent();
            id_crop = i;
        }

        private void add_offer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "inse_offer";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_r", Form1.id_user));
            cmd.Parameters.Add(new SqlParameter("@p", textBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@q", textBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@id_c", id_crop));            
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Offer was submitted successfully");
            textBox2.Text = "";
            textBox3.Text = "";
            button1.Enabled = false; 
        }
    }
}
