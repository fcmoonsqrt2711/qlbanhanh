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
    public partial class ThemNhanVien : Form
    {
        private string MaNV;
        private DataGridView dgv;
        public ThemNhanVien()
        {
            InitializeComponent();
        }

        public ThemNhanVien(string maNV,DataGridView dgv)
        {
            this.MaNV = maNV;
            this.dgv = dgv;
            InitializeComponent();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaNV))
            {
                this.Text = "Thêm Nhân Viên";
            }
            else
            {
                var r = new Database().Select(string.Format("SelectNhanVienByID '" + MaNV + "'"));
                txtTenNV.Text = r["tenNhanVien"].ToString();
                if (r["gioiTinh"].ToString().Equals("Nam"))
                {
                    rdbGene1.Checked = true;
                }
                else
                {
                    rdbGene2.Checked = true;
                }
                txtDiaChi.Text = r["diaChi"].ToString();
                txtSDT.Text = r["sdt"].ToString();
                this.Text = "Chỉnh sửa thông tin nhân viên";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            string tenNV = txtTenNV.Text;
            string diaChi = txtDiaChi.Text;
            string SDT = txtSDT.Text;
            string GioiTinh;
            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (rdbGene1.Checked == true)
            {
                GioiTinh = rdbGene1.Text;
            }
            else
            {
                GioiTinh = rdbGene2.Text;
            }
            if (string.IsNullOrEmpty(MaNV))
            {
                sql = "InsertNhanVien";
            }
            else
            {
                sql = "UpdateNhanVien";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maNV",
                    value = MaNV
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@tenNV",
                    value = tenNV
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@GT",
                    value = GioiTinh
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
                    if (string.IsNullOrEmpty(MaNV))
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
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
