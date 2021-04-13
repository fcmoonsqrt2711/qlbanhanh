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
    public partial class QLHangHoa : Form
    {
        public QLHangHoa()
        {
            InitializeComponent();
        }

        private void QLHangHoa_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            dgvHangHoa.DataSource = new Database().SelectData("exec selectAllHang");

            dgvHangHoa.Columns["maHang"].HeaderText = "Mã hàng hóa";
            dgvHangHoa.Columns["tenhang"].HeaderText = "Tên hàng hóa";
            dgvHangHoa.Columns["soLuong"].HeaderText = "Số lượng";
            dgvHangHoa.Columns["giaNhap"].HeaderText = "Giá nhập";
            dgvHangHoa.Columns["giaBan"].HeaderText = "Giá bán";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new ThemHang(null).ShowDialog();
            reload();
        }

        private void dgvHangHoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var msv = dgvHangHoa.Rows[e.RowIndex].Cells["maHang"].Value.ToString();
                new ThemHang(msv).ShowDialog();
                reload();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var db = new Database();
            if (MessageBox.Show("Bạn muốn xóa hàng hóa " + dgvHangHoa.CurrentRow.Cells["tenHang"].Value.ToString() + " ?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.del_HangHoa(dgvHangHoa.CurrentRow.Cells["maHang"].Value.ToString());
            }

            // Hien thi mess thong bao

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
                        sqlSearch = "exec searchMaHang '" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new TimKiemHH(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (cbbTimKiem.SelectedIndex == 1)
                    {
                        sqlSearch = "exec searchTenHang N'" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new TimKiemHH(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (cbbTimKiem.SelectedIndex == 2)
                    {
                        sqlSearch = "exec searchGiaNhap " + valueSearch + " ";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new TimKiemHH(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (cbbTimKiem.SelectedIndex == 3)
                    {
                        sqlSearch = "exec searchGiaBan " + valueSearch + " ";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new TimKiemHH(sqlSearch).Show();
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
