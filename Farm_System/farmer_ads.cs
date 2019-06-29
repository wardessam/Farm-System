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
    public partial class farmer_ads : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public farmer_ads()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void farmer_ads_Load(object sender, EventArgs e)
        {

        }
        public void read_id(int id)
        {
            con.Open();
            string query = "select name from farmer where id_farmer ='"+id+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            label2.Text = (string)cmd.ExecuteScalar();
            con.Close();
        }
        public void statue(string st)
        {
            label4.Text = st;
        }
    }
}
