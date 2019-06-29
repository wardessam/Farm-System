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
    public partial class search : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public search()
        {
            InitializeComponent();
        }
        string s;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            s = richTextBox1.Text;
            flowLayoutPanel1.Controls.Clear();
            con.Open();
            string query = "search_farmer_";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@name", richTextBox1.Text));
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                result_search r_search = new result_search();
                r_search.farmer_name((string)rdr["name"]);
                r_search.farmer_id((int)rdr["id_farmer"]);
                flowLayoutPanel1.Controls.Add(r_search);
            }
            con.Close();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != s)
                flowLayoutPanel1.Controls.Clear();
        }
    }
}
