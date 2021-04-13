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
    public partial class TimKiemHH : Form
    {
        string sqlSearch;
        public TimKiemHH()
        {
            InitializeComponent();
        }

        public TimKiemHH(string sql)
        {
            sqlSearch = sql;
            InitializeComponent();
        }

        private void LoadDSHH()
        {
            dgvSearchHH.DataSource = null;
            dgvSearchHH.DataSource = new Database().SelectData(sqlSearch);
            dgvSearchHH.Columns["maHang"].HeaderText = "Mã hàng hóa";
            dgvSearchHH.Columns["tenhang"].HeaderText = "Tên hàng hóa";
            dgvSearchHH.Columns["soLuong"].HeaderText = "Số lượng";
            dgvSearchHH.Columns["giaNhap"].HeaderText = "Giá nhập";
            dgvSearchHH.Columns["giaBan"].HeaderText = "Giá bán";
        }
        private void TimKiemHH_Load(object sender, EventArgs e)
        {
            LoadDSHH();
        }
    }
}
