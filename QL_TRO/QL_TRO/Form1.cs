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
using QL_TRO.dataAccess;

namespace QL_TRO
{
    public partial class Form1 : Form
    {
      
        SqlConnection con = new SqlConnection(helper.ConnectString());
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
