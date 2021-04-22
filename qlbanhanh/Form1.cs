using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlbanhanh
{
    public partial class formDangNhap : Form
    {
        public formDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txbDangNhap.Text == "admin" && txbMatKhau.Text == "admin")
            {
                this.Visible = false;
                QuanLy formQL = new QuanLy();
                formQL.ShowDialog();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Tên truy cập hoặc mật khẩu sai");
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linklbTaiKhoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Tên truy cập: admin\n" + "Mật khẩu: admin");
        }

        private void linklbAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Application.StartupPath + "\\Huong_ dan\\index.html");

        }
    }
}
