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
    public partial class ThemKhachHang : Form
    {
        private string maKH;
        private DataGridView dgv;

        public ThemKhachHang()
        {
            InitializeComponent();
        }

        public ThemKhachHang(string maKH, DataGridView dgv)
        {
            this.maKH = maKH;
            this.dgv = dgv;
            InitializeComponent();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void ThemKhachHang_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maKH))
            {
                this.Text = "Thêm khách hàng";
            }
            else
            {
                var r = new Database().Select(string.Format("SelectKhachHangByID '" + maKH + "'"));
                txtTenKH.Text = r["tenKhach"].ToString();
                txtDiaChi.Text = r["diaChi"].ToString();
                txtSDT.Text = r["sdt"].ToString();
                this.Text = "Chỉnh sửa khách hàng";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            string tenKhachHang = txtTenKH.Text;
            string diaChi = txtDiaChi.Text;
            string SDT = txtSDT.Text;

            List<CustomParameter> lstPara = new List<CustomParameter>();

            if (string.IsNullOrEmpty(maKH))
            {
                sql = "InsertKhachHang";
            }
            else
            {
                sql = "UpdateKhachHang";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maKH",
                    value = maKH
                });
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@tenKH",
                value = tenKhachHang
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@diaChi",
                value = diaChi
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@SDT",
                value = SDT
            });

            var rs = new Database().execute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(maKH))
                {
                    MessageBox.Show("Thêm mới thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thao tác không thành công");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
