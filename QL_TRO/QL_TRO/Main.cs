using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_TRO
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            hideMenu();
        }
        private Form activeForm = null;


        
        private void openForm(Form childForm,string title)
        {
            // hàm này mình gọi để bật screen sau khi mình bấm menu (button bên menu ấy)
            if(activeForm != null)
            {
                activeForm.Close();
               
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFrame.Controls.Add(childForm);
            panelFrame.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            titleFrame.Text = title;
        }
        private void hideMenu()
        {
            panel3menu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panel3menu.Visible == true)
            {
                panel3menu.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            openForm(form2, "Đặt Phòng");

        }

        private void booking_btn_Click(object sender, EventArgs e)
        {
            showSubMenu(panel3menu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            openForm(form2, "Đặt Phòng");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Payment form = new Payment();
            openForm(form, "Tính tiền phòng");
        }
    }
}
