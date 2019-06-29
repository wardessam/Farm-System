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
    public partial class addavcrops : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public addavcrops()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "add_av_crops";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@name", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@kind", textBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@quantity", textBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@id_f", Form1.id_user));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Crop is added successfully");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";            
        }
    }
}
