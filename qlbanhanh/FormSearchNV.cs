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
    public partial class FormSearchNV : Form
    {
        string sqlSearch;
        public FormSearchNV()
        {
            InitializeComponent();
        }

        public FormSearchNV(string sql)
        {
            sqlSearch = sql;
            InitializeComponent();
        }

        private void LoadKH()
        {
            dgvSearchNV.DataSource = null;
            dgvSearchNV.DataSource = new Database().SelectData(sqlSearch);
            dgvSearchNV.Columns["maNhanVien"].HeaderText = "Mã nhân viên";
            dgvSearchNV.Columns["tenNhanVien"].HeaderText = "Tên nhân viên";
            dgvSearchNV.Columns["gioiTinh"].HeaderText = "Giới Tính";
            dgvSearchNV.Columns["diaChi"].HeaderText = "Địa chỉ";
            dgvSearchNV.Columns["sdt"].HeaderText = "Số điện thoại";
        }

        private void FormSearchNV_Load(object sender, EventArgs e)
        {
            LoadKH();
        }
    }
}
