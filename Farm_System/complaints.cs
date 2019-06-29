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
    public partial class complaints : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public complaints()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void view_complaints()
        {
            flowLayoutPanel1.Controls.Clear();
            con.Open();
            string query = "select * from grivance ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                complaint v_s = new complaint();
                v_s.id_g((int)rdr["id_grivance"]);
                v_s.topic((string)rdr["topic"]);
                v_s.id_f((int)rdr["id_farmer"]);

                flowLayoutPanel1.Controls.Add(v_s);


            }
            con.Close();
        }
    }
}

