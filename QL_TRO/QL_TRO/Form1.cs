using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace QL_TRO
{
    public partial class Form1 : Form
    {
        static string sql_connect = ConfigurationManager.ConnectionStrings["sql_connect"].ConnectionString;
        SqlConnection con = new SqlConnection(sql_connect);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if(con.State == ConnectionState.Open)
            {
                MessageBox.Show("Connected");
            }
           
        }
    }
}
