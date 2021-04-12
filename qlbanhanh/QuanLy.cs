using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlbanhanh
{
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        private void picBoxSalemans_MouseHover(object sender, EventArgs e)
        {
            picBoxSalemans.Size = new Size(300, 300);
        }

        private void picBoxSalemans_MouseLeave(object sender, EventArgs e)
        {
            picBoxSalemans.Size = new Size(262, 262);
        }

        private void picBoxMerchandise_MouseHover(object sender, EventArgs e)
        {
            picBoxMerchandise.Size = new Size(300, 300);
        }

        private void picBoxMerchandise_MouseLeave(object sender, EventArgs e)
        {
            picBoxMerchandise.Size = new Size(262, 262);
        }

        private void picBoxCustomer_MouseHover(object sender, EventArgs e)
        {
            picBoxCustomer.Size = new Size(300, 300);
        }

        private void picBoxCustomer_MouseLeave(object sender, EventArgs e)
        {
            picBoxCustomer.Size = new Size(262, 262);
        }

        private void picBoxBill_MouseHover(object sender, EventArgs e)
        {
            picBoxBill.Size = new Size(300, 300);
        }

        private void picBoxBill_MouseLeave(object sender, EventArgs e)
        {
            picBoxBill.Size = new Size(262, 262);
        }

        private void picBoxSalemans_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            QLNhanVien qLNV = new QLNhanVien();
            qLNV.ShowDialog();
            this.Visible = true;
        }

        private void picBoxCustomer_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            QLKhachHang qLKH = new QLKhachHang();
            qLKH.ShowDialog();
            this.Visible = true;
        }

        private void picBoxBill_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            QLHoaDon qLHD = new QLHoaDon();
            qLHD.ShowDialog();
            this.Visible = true;
        }

        private void picBoxMerchandise_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            QLHangHoa qLHH = new QLHangHoa();
            qLHH.ShowDialog();
            this.Visible = true;
        }
    }
}
