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
    public partial class QLHoaDon : Form
    {
        public QLHoaDon()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void reload()
        {
            dgvHoaDon.DataSource = new Database().SelectData("select * from HDban");

        }

        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            (new ThemHoaDon(null)).ShowDialog();
            reload();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var db = new Database();
            if (MessageBox.Show("Bạn muốn xóa hóa đơn " + dgvHoaDon.CurrentRow.Cells["MaHDBan"].Value.ToString() + " ?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //db.del_HDban(dgvKhachHang.CurrentRow.Cells["maKhach"].Value.ToString());
                db.del_HoaDon(dgvHoaDon.CurrentRow.Cells["maHDban"].Value.ToString());
            }

            reload();
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maKH = dgvHoaDon.Rows[e.RowIndex].Cells["maHDban"].Value.ToString();
                new ThemHoaDon(maKH).ShowDialog();
                reload();
            }
        }
    }
}
