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
        private Form2 frm;
        private string maPhong;
        public void fetchList()
        {
            KhachThueList khach = Service.getCustomerRoom(maPhong);
            KhachThue show = khach.Head;

            while (show != null)
            {
                ListViewItem lvItem = new ListViewItem(show.maKhach.ToString());
                lvItem.SubItems.Add(show.ten);
                lvItem.SubItems.Add(show.gioiTinh);
                lvItem.SubItems.Add(show.ngaySinh);
                 
                lvItem.SubItems.Add(show.soCMND);
                lvItem.SubItems.Add(show.sdt);
                lvItem.SubItems.Add(show.queQuan);
             
               
                lvItem.SubItems.Add(show.ngheNghiep);
                lvItem.SubItems.Add(show.ngayVao);



                listView1.Items.Add(lvItem);
                show = show.next;
            }
        }
        public Form1(string maPhong,Form2 frm)
        {

            InitializeComponent();
            this.frm = frm;
            this.maPhong = maPhong;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
            ngaySinhText.CustomFormat = "yyyy/MM/dd";
            ngaySinhText.Format = DateTimePickerFormat.Custom;
            ngayVaoText.CustomFormat = "yyyy/MM/dd";
            ngayVaoText.Format = DateTimePickerFormat.Custom;
            gioiTinh.Items.Add("Nam");
            gioiTinh.Items.Add("Nữ");
            gioiTinh.SelectedIndex = 0;
            gioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            thongTinHeader.Font = new Font("Arial", 10, FontStyle.Bold);
            Phong phong = Service.getRoom(maPhong);
            maPhongText.Text = phong.maPhong.ToString();
            loaiPhongText.Text = phong.loaiPhong;
            vitriText.Text = phong.viTri;
            giaThueText.Text = phong.giaThue.ToString() + " đ";
            songDkText.Text = phong.soNgDk.ToString();
            slTDText.Text = phong.slNgTD.ToString();
            fetchList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dk_btn_Click(object sender, EventArgs e)
        {

            KhachThue khach = new KhachThue();
            khach.maPhong = int.Parse(maPhong);
            khach.ten = tenText.Text;
            khach.soCMND = soCMNDText.Text;
            khach.sdt = sdtText.Text;
            khach.ngaySinh = ngaySinhText.Text;
            khach.ngayVao = ngayVaoText.Text;
            khach.ngheNghiep = ngheNghiepText.Text;
            khach.gioiTinh = gioiTinh.SelectedItem.ToString();
           // khach.ngheNghiep = ngheNghiepText.Text;
    
            khach.queQuan = queQuanText.Text;
          
            bool themKhach = Service.insertCustomer(khach);
            if (themKhach)
            {
                MessageBox.Show("Đăng ký thành công");
                fetchList();
                frm.getRoom();
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string comboBoxx = ngaySinhText.Text;
            MessageBox.Show(comboBoxx);
        }
    }
}
