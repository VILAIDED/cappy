using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_TRO.model;
using QL_TRO.dataAccess;

namespace QL_TRO
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TestDN dnlist =  Service.fetchDN();
            Node show = dnlist.Head;
            while(show != null)
            {
                dataGridView1.Rows.Add(show.MaDienNuoc, show.MaPhong, show.SoDien, show.SoNuoc, show.thangDoc);
                show = show.next;
                
            }
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "đặt phòng";
            btn.UseColumnTextForButtonValue = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            MessageBox.Show(item.ToString());
        }
    }
}
