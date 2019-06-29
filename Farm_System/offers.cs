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
    public partial class offers : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public offers()
        {
            InitializeComponent();
        }

        private void offers_Load(object sender, EventArgs e)
        {

        }
        public void load_offers()
        {
            flowLayoutPanel1.Controls.Clear();
            con.Open();
            string query = "all_offers";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_r", Form1.id_user));
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                offer offer = new offer();
                ////offer.farmer_name((int)rdr["id_farmer"]);
                offer.crop_name((int)rdr["id_crop"]);
                offer.crop_quantity((int)rdr["quantity"]);
                offer.price((int)rdr["price"]);
                if (rdr["statue"] == DBNull.Value)
                    offer.offer_statue("Not Respond");
                else
                    offer.offer_statue((string)rdr["statue"]);
                flowLayoutPanel1.Controls.Add(offer);
            }
            con.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
