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
            dtpFromSearch.CustomFormat = "";
            dtpFromSearch.Format = DateTimePickerFormat.Custom;
            dtpToSearch.CustomFormat = "";
            dtpToSearch.Format = DateTimePickerFormat.Custom;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void reload(ObjectCommonSearch search)
        {
            string sql = "select * from HDban ";
            sql += " where ngayBan between ";
            if (search.DateTime1 != null && search.DateTime1 != DateTime.MinValue)
            {
                sql += ("'" + search.DateTime1.ToString() + "'");
            }
            else
            {
                sql += ("'" + DateTime.Parse("01/01/2000").ToString() + "'");
            }
            sql += " and ";
            if (search.DateTime2 != null && search.DateTime2 != DateTime.MinValue)
            {
                sql += ("'" + search.DateTime2.ToString() + "'");
            }
            else
            {
                sql += ("'" + DateTime.Parse("01/01/2100").ToString() + "'");
            }
            sql += " and tongTien between ";
            if (search.Int1 > 0)
            {
                sql += search.Int1.ToString();
            }
            else
            {
                sql += int.MinValue.ToString();
            }
            sql += " and ";
            if (search.Int2 > 0)
            {
                sql += search.Int2.ToString();
            }
            else
            {
                sql += int.MaxValue.ToString();
            }
            dgvHoaDon.DataSource = new Database().SelectData(sql);
            
        }

        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            ObjectCommonSearch search = new ObjectCommonSearch();
            reload(search);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            (new ThemHoaDon(null)).ShowDialog();
            ObjectCommonSearch search = new ObjectCommonSearch();
            reload(search);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var db = new Database();
            if (MessageBox.Show("Bạn muốn xóa hóa đơn " + dgvHoaDon.CurrentRow.Cells["MaHDBan"].Value.ToString() + " ?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //db.del_HDban(dgvKhachHang.CurrentRow.Cells["maKhach"].Value.ToString());
                db.del_HoaDon(dgvHoaDon.CurrentRow.Cells["maHDban"].Value.ToString());
            }
            ObjectCommonSearch search = new ObjectCommonSearch();
            reload(search);
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maKH = dgvHoaDon.Rows[e.RowIndex].Cells["maHDban"].Value.ToString();
                new ThemHoaDon(maKH).ShowDialog();
                ObjectCommonSearch search = new ObjectCommonSearch();
                reload(search);
            }
        }

        private void dtpFromSearch_ValueChanged(object sender, EventArgs e)
        {
            dtpFromSearch.CustomFormat = "dd/MM/yyyy hh:mm:ss";
        }

        private void dtpToSearch_ValueChanged(object sender, EventArgs e)
        {
            dtpToSearch.CustomFormat = "dd/MM/yyyy hh:mm:ss";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ObjectCommonSearch search = new ObjectCommonSearch();
            search.DateTime1 = dtpFromSearch.Value;
            search.DateTime2 = dtpToSearch.Value;
            search.Int1 = (int)nudTongTienFromSearch.Value;
            search.Int2 = (int)nudTongTienToSearch.Value;
            reload(search);
        }
    }
}
