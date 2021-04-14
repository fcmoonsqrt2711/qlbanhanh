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


    }
}
