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
    public partial class viewreqcrops : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public viewreqcrops()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void viewreqcrops_Load(object sender, EventArgs e)
        {

        }
        public void load_ads()
        {
            con.Open();
            string query = "select * from advertisement";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            while(rdr.Read())
            {
                viewreqcrop r_c = new viewreqcrop();
                r_c.ad_id((int)rdr["id_advertisement"]);               
                r_c.s_name((int)rdr["id_supplier"]);
                r_c.c_name((string)rdr["name"]);
                r_c.quality((string)rdr["quality"]);
                r_c.price((int)rdr["price"]);
                flowLayoutPanel1.Controls.Add(r_c);
            }
            con.Close();
        }
    }
}
