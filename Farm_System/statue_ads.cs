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
    public partial class statue_ads : Form
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        int id_a;
        public statue_ads(int i)
        {
            InitializeComponent();
            id_a = i;
        }

        private void statue_ads_Load(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from ads_farmer where id_ads='" + id_a + "'";
           
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
           
            while (rdr.Read())
            {
                
                farmer_ads f_a = new farmer_ads();
                f_a.read_id((int)rdr["id_farmer"]);
                f_a.statue((string)rdr["statue"]);
                flowLayoutPanel1.Controls.Add(f_a);
            }
            con.Close();
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
