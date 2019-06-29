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
    public partial class viewoffers : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public viewoffers()
        {
            InitializeComponent();
        }

        private void viewoffers_Load(object sender, EventArgs e)
        {

        }
        public void load_offers()
        {
            flowLayoutPanel1.Controls.Clear();
            con.Open();
            string query1 = "select * from offer";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            while(rdr1.Read())
            {
                string query = "select count(*) from crop where id_crop = '" + rdr1["id_crop"] + "' and id_farmer ='" + Form1.id_user + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int num = (int)cmd.ExecuteScalar();
                if(num!=0)
                {
                    viewoffer v_o = new viewoffer();
                    v_o.id_o((int)rdr1["id_offer"]);
                    v_o.id_r((int)rdr1["id_retailer"]);
                    v_o.id_c((int)rdr1["id_crop"]);
                    v_o.price((int)rdr1["price"]);
                    v_o.quantity((int)rdr1["quantity"]);
                    if(rdr1["statue"]!=DBNull.Value)
                        v_o.statue((string)rdr1["statue"]);                
                    flowLayoutPanel1.Controls.Add(v_o);

                }
            }
            con.Close();

        }
    }
}
