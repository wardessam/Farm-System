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
    public partial class viewcomplaint : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);

        public viewcomplaint()
        {
            InitializeComponent();
        }

        private void viewcomplaint_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
        }
        public void topic(string t) {
            label8.Text = t;

        }
        public void statue(string s) {
            label2.Text = s;

        }

    }
}
