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
    }
}
