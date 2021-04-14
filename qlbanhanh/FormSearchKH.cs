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
    public partial class FormSearchKH : Form
    {
        string sqlSearch;
        public FormSearchKH()
        {
            InitializeComponent();
        }
        public FormSearchKH(string sql)
        {
            sqlSearch = sql;
            InitializeComponent();
        }

        private void LoadKH()
        {
            dvgSearch.DataSource = null;
            dvgSearch.DataSource = new Database().SelectData(sqlSearch);
            dvgSearch.Columns["maKhach"].HeaderText = "Mã khách hàng";
            dvgSearch.Columns["tenKhach"].HeaderText = "Tên khách hàng";
            dvgSearch.Columns["diaChi"].HeaderText = "Địa chỉ";
            dvgSearch.Columns["sdt"].HeaderText = "Số điện thoại";
        }

        private void FormSearchKH_Load(object sender, EventArgs e)
        {
            LoadKH();
        }
    }
}
