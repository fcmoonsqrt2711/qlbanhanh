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
    public partial class ThemHang : Form
    {
        private string maHangHoa;
        public ThemHang(string maHangHoa)
        {
            this.maHangHoa = maHangHoa;
            InitializeComponent();
        }

        private void ThemHang_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            if (string.IsNullOrEmpty(maHangHoa))
            {
                this.Text = "Thêm hàng hóa";

            }
            else
            {
                var r = new Database().Select(string.Format("SelectHangById '" + maHangHoa + "'"));
                txtTenHH.Text = r["tenHang"].ToString();
                txtSL.Text = r["soLuong"].ToString();
                txtGiaN.Text = r["giaNhap"].ToString();
                txtGiaX.Text = r["giaBan"].ToString();

                this.Text = "Chỉnh sửa thông tin độc giả";
            }    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            string TenHang = txtTenHH.Text;
            string SL = txtSL.Text;
            string GiaNhap = txtGiaN.Text;
            string GiaBan = txtGiaX.Text;

            List<CustomParameter> lstPara = new List<CustomParameter>();

            if (string.IsNullOrEmpty(maHangHoa))
            {
                sql = "InsertHang";
            }
            else
            {
                sql = "UpdateHang";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maHang",
                    value = maHangHoa
                });
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@tenHang",
                value = TenHang
            });          

            lstPara.Add(new CustomParameter()
            {
                key = "@soLuong",
                value = SL
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@giaNhap",
                value = GiaNhap
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@giaBan",
                value = GiaBan
            });


            var rs = new Database().ExeCute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(maHangHoa))
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
}
