using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlbanhanh
{
    public partial class ThemHoaDon : Form
    {
        private string mhd;
        public ThemHoaDon(string mhd)
        {
            this.mhd = mhd;
            InitializeComponent();
        }

        private void ThemHoaDon_Load(object sender, EventArgs e)
        {
            Database csdl = new Database();
            //DataTable maNVTable = new DataTable();
            DataTable maNVTable = csdl.SelectData("Select maNhanVien, tenNhanVien from nhanvien");
            //maNVTable.Rows.Add(new object[] { 0, "Chọn nhân viên"});
            //maNVTable.Rows.Add(csdl.SelectData("Select maNhanVien, tenNhanVien from nhanvien").Rows);
            DataRow dr = maNVTable.NewRow();
            dr["maNhanVien"] = 0;
            dr["tenNhanVien"] = "Chọn nhân viên";
            maNVTable.Rows.InsertAt(dr, 0);
            cbMaNV.DataSource = maNVTable.Copy();
            cbMaNV.DisplayMember = "tenNhanVien";
            cbMaNV.ValueMember = "maNhanVien";
            //cbMaNV.SelectedItem = 0;
            DataTable maKhachTable = csdl.SelectData("Select maKhach, tenKhach from khach");
            DataRow dr2 = maKhachTable.NewRow();
            dr2["maKhach"] = 0;
            dr2["tenKhach"] = "Chọn khách hàng";
            maKhachTable.Rows.InsertAt(dr2, 0);
            cbMaKhach.DataSource = maKhachTable.Copy();
            cbMaKhach.DisplayMember = "tenKhach";
            cbMaKhach.ValueMember = "maKhach";
            if (string.IsNullOrEmpty(mhd))
            {
                this.Text = "Thêm hóa đơn";
            }
            else
            {
                var r = csdl.Select(string.Format("SelectHoaDonByID '" + mhd + "'"));
                cbMaNV.SelectedValue = r["maNhanVien"].ToString();
                dtpNgayBan.Value = DateTime.Parse(r["ngayBan"].ToString());
                cbMaKhach.SelectedValue = r["maKhach"].ToString();
                nudTongTien.Value = int.Parse(r["tongtien"].ToString());
                this.Text = "Chỉnh sửa hóa đơn";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            DataRowView drvMaNV = (DataRowView)cbMaNV.SelectedItem;
            string maNV = drvMaNV.Row.Field<string>("maNhanVien");
            string ngayBan = dtpNgayBan.Value.ToString();
            DataRowView drvMaKhach = (DataRowView)cbMaKhach.SelectedItem;
            string maKhach = drvMaKhach.Row.Field<string>("maKhach");
            string tongTien = nudTongTien.Value.ToString();

            if (maNV == "0")
            {
                MessageBox.Show("Thao tác không thành công");
                return;
            }

            if(maKhach == "0")
            {
                MessageBox.Show("Thao tác không thành công");
                return;
            }

            List<CustomParameter> lstPara = new List<CustomParameter>();

            if (string.IsNullOrEmpty(mhd))
            {
                sql = "InsertHoaDon";
            }
            else
            {
                sql = "UpdateHoaDon";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maHD",
                    value = mhd
                });
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@maNV",
                value = maNV
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@ngayBan",
                value = ngayBan
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@maKH",
                value = maKhach
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@tongTien",
                value = tongTien
            });

            var rs = new Database().execute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(mhd))
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
