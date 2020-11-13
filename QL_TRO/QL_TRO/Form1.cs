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
using QL_TRO.model;


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

        private void Form1_Load(object sender, EventArgs e)
        {
            TestDN test = Service.fetchDN();
            Node show = test.Head;
           
            while(show != null)
            {
                ListViewItem lvItem = new ListViewItem(show.MaPhong.ToString());
                lvItem.SubItems.Add(show.MaPhong.ToString());
                lvItem.SubItems.Add(show.SoDien.ToString());
                lvItem.SubItems.Add(show.SoNuoc.ToString());
                lvItem.SubItems.Add(show.thangDoc.ToString());
                listView1.Items.Add(lvItem);
                show = show.next;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
