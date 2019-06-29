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
    public partial class search_av_crops : Form
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        int id_farmer;
        public search_av_crops(int i)
        {
            InitializeComponent();
            id_farmer = i;
        }

        private void search_av_crops_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            con.Open();
            string query = "select * from crop where id_farmer = '" + id_farmer + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                av_crop av = new av_crop();
                av.farmer_id((int)rdr["id_farmer"]);
                av.crop_id((int)rdr["id_crop"]);
                av.crop_kind((string)rdr["kind"]);
                av.crop_quantity((int)rdr["quantity"]);
                av.crop_name((string)rdr["name"]);
                flowLayoutPanel1.Controls.Add(av);
            }
        }
    }
}
