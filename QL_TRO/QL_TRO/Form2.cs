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
        public void getRoom()
        {
            PhongList phong = Service.getRoomAvailable();
            Phong show = phong.Head;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            while (show != null)
            {
                dataGridView1.Rows.Add(show.maPhong, show.loaiPhong, show.viTri, show.soNgDk, show.slNgTD, show.giaThue, "đặt phòng");
                show = show.next;

            }
            if (dataGridView1.RowCount < 25)
            {
                dataGridView1.RowCount = 25;
            }

        }
        public Form2()
        {
            InitializeComponent();
        }
        private void datagirdDesign()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.BackgroundColor = Color.FromArgb(30, 30, 30);
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            datagirdDesign();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "";
            getRoom();
           


        }
        private bool isAnonHeadLinkCell(DataGridViewCellEventArgs cellEventArgs)
        {
            if (dataGridView1.Columns[cellEventArgs.ColumnIndex] is DataGridViewLinkColumn && cellEventArgs.RowIndex != 1)
            {
                return true;
            }
            else return false;
        }
        private bool isANonButtonCell(DataGridViewCellEventArgs cellEventArgs)
        {
            if(dataGridView1.Columns[cellEventArgs.ColumnIndex] is DataGridViewButtonColumn && cellEventArgs.RowIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
     
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (isANonButtonCell(e))
            {
                var item = dataGridView1.Rows[e.RowIndex].Cells[0].Value; // index was out of range
                if (item != null)
                {
                    string maPhong = item.ToString();

                    var newForm = new Form1(maPhong, this);
                    newForm.Show(this);
                }
            }
        }
    }
}
