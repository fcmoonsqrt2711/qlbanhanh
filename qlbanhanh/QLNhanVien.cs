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
    public partial class QLNhanVien : Form
    {
        public QLNhanVien()
        {
            InitializeComponent();
        }
        private void reload()
        {
            dgvNhanVien.DataSource = new Database().SelectData("select * from nhanvien");

        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = new Database().SelectData("select * from nhanvien");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            (new ThemNhanVien(null, dgvNhanVien)).ShowDialog();
            reload();
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maNV = dgvNhanVien.Rows[e.RowIndex].Cells["maNhanVien"].Value.ToString();
                new ThemNhanVien(maNV, dgvNhanVien).ShowDialog();
                reload();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var db = new Database();
            if (MessageBox.Show("Bạn muốn xóa khách hàng " + dgvNhanVien.CurrentRow.Cells["tenNhanVien"].Value.ToString() + " ?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.del_NhanVien(dgvNhanVien.CurrentRow.Cells["maNhanVien"].Value.ToString());
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
