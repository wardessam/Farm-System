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
    public partial class av_crops : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public av_crops()
        {
            InitializeComponent();
        }

        private void av_crops_Load(object sender, EventArgs e)
        {

        }
        public void load_crops()
        {
            con.Open();
            string query = "av_crops";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            while(rdr.Read())
            {
                av_crop av_crop = new av_crop();
                av_crop.farmer_id((int)rdr["id_farmer"]);
                av_crop.crop_id((int)rdr["id_crop"]);
                av_crop.crop_name((string)rdr["name"]);
                av_crop.crop_kind((string)rdr["kind"]);
                av_crop.crop_quantity((int)rdr["quantity"]);
                flowLayoutPanel1.Controls.Add(av_crop); 
            }
            con.Close();
        }
    }
}
