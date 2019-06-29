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
    public partial class view_ads : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public view_ads()
        {
            InitializeComponent();
        }

        private void view_ads_Load(object sender, EventArgs e)
        {

        }
        public void load_ads()
        {
            con.Open();
            flowLayoutPanel1.Controls.Clear();
            string query = "read_ad";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@sup_id", Form1.id_user));
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                ad ad = new ad();
                ad.name_crop((string)rdr["name"]);
                ad.price((int)rdr["price"]);
                ad.quality((string)rdr["quality"]);
                ad.read_id((int)rdr["id_advertisement"]);
                flowLayoutPanel1.Controls.Add(ad);

            }
            con.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
