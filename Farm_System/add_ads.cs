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
    public partial class add_ads : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public add_ads()
        {
            InitializeComponent();
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        
      

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "add_ads";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@name", bunifuMetroTextbox1.Text));
            cmd.Parameters.Add(new SqlParameter("@price", bunifuMetroTextbox2.Text));
            cmd.Parameters.Add(new SqlParameter("@quality", bunifuMetroTextbox3.Text));
            cmd.Parameters.Add(new SqlParameter("@id_supplier", Form1.id_user));
            MessageBox.Show("Advertisement was submitted successfully");
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox2.Text = "";
            bunifuMetroTextbox3.Text = "";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
