﻿using System;
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
    public partial class av_crop : UserControl
    {
        static string sql = @"Data Source = DESKTOP-14KH0FM\SQLEXPRESS ; Initial Catalog = farm_system ; Integrated Security = True ; MultipleActiveResultSets = True ; User ID = '' ; Password = '' ";
        SqlConnection con = new SqlConnection(sql);
        public int id_c;
        public av_crop()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void farmer_id(int f_i)
        {
            con.Open();
            string query = "select name from farmer where id_farmer ='" + f_i + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            label1.Text = (string)cmd.ExecuteScalar();
            con.Close();
        }
        public void crop_id(int c_i)
        {
            id_c = c_i;
        }
        public void crop_name(string n)
        {
            label3.Text = n;
        }
        public void crop_kind(string c_k)
        {
            label4.Text = c_k;
        }
        public void crop_quantity(int c_q)
        {
            label5.Text = c_q.ToString();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            add_offer add_offer = new add_offer(id_c);
            add_offer.Show();
        }
    }
}
