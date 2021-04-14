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
    public partial class QLKhachHang : Form
    {
        public QLKhachHang()
        {
            InitializeComponent();
        }

        private void reload()
        {
            dgvKhachHang.DataSource = new Database().SelectData("select * from khach");

        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = new Database().SelectData("select * from khach");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            (new ThemKhachHang(null, dgvKhachHang)).ShowDialog();
            reload();
        }

        private void dgvKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maKH = dgvKhachHang.Rows[e.RowIndex].Cells["maKhach"].Value.ToString();
                new ThemKhachHang(maKH, dgvKhachHang).ShowDialog();
                reload();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var db = new Database();
            if (MessageBox.Show("Bạn muốn xóa khách hàng " + dgvKhachHang.CurrentRow.Cells["tenKhach"].Value.ToString() + " ?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //db.del_HDban(dgvKhachHang.CurrentRow.Cells["maKhach"].Value.ToString());
                db.del_KhachHang(dgvKhachHang.CurrentRow.Cells["maKhach"].Value.ToString());
            }

            reload();
        }

        private void resetValue()
        {
            txbTimKiem.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbTimKiem.Text))
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (cbbTimKiem.SelectedIndex != -1)
                {
                    String valueSearch = txbTimKiem.Text;
                    var db = new Database();
                    String sqlSearch = "";
                    if (cbbTimKiem.SelectedIndex == 0)
                    {
                        sqlSearch = "exec searchTenKH N'" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new FormSearchKH(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (cbbTimKiem.SelectedIndex == 1)
                    {
                        sqlSearch = "exec searchDiaChiKH N'" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new FormSearchKH(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (cbbTimKiem.SelectedIndex == 2)
                    {
                        sqlSearch = "exec searchSDTKH N'" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new FormSearchKH(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                resetValue();
            }
        }
    }
}
