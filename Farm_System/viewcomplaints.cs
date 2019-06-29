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
    public partial class viewcomplaints : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);

        public viewcomplaints()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void viewcomplaints_Load(object sender, EventArgs e)
        {

        }
        public void load_complaints()
        {          
            flowLayoutPanel1.Controls.Clear();
            con.Open();           
            string query = "select * from grivance where id_farmer='" + Form1.id_user+"'";
         
            SqlCommand cmd = new SqlCommand(query, con);
       
            SqlDataReader rdr = cmd.ExecuteReader();
           
            while (rdr.Read())
            {                
                viewcomplaint v_c = new viewcomplaint();
                v_c.topic((string)rdr["topic"]);
                if (rdr["statue"] == DBNull.Value)
                    v_c.statue("Not Respond");
                else
                    v_c.statue((string)rdr["statue"]);
                flowLayoutPanel1.Controls.Add(v_c);
            }
            con.Close();
        }
    }
}
