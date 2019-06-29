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
    public partial class requested_crops : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public requested_crops()
        {
            InitializeComponent();
        }

        private void requested_crops_Load(object sender, EventArgs e)
        {
            
        }

        public void load_r_crops()
        {
            flowLayoutPanel1.Controls.Clear();
            con.Open();
            string query = "select * from r_crops";
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                requested_crop rc = new requested_crop();
                rc.farmer_id((int)rdr["id_farmer"]);
                rc.crop_name((string)rdr["name"]);
                flowLayoutPanel1.Controls.Add(rc);
            }
            con.Close();
        }
    }
}
