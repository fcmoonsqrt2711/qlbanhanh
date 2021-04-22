using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlbanhanh
{
    public class Database
    {
        private string connectionString = "Data Source=KIENNEIK\\SQLEXPRESS01;Initial Catalog=qlbh;Trusted_Connection=Yes;";
        private SqlConnection conn;

        private DataTable dt;
        private SqlCommand cmd;

        public Database()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                //conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connected Failed: " + ex.Message);
            }

        }
        public DataTable SelectData(string sql)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)

            {
                MessageBox.Show("Data Loading ERROR: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataRow Select(string sql)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading Error: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }


        public int ExeCute(string sql, List<CustomParameter> lstPara)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //return (int)cmd.ExecuteScalar();

                foreach (var p in lstPara)
                {
                    cmd.Parameters.AddWithValue(p.key, p.value);
                }
                var rs = cmd.ExecuteNonQuery();
                return (int)rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool executeNonQuery(string sql)
        {
            bool check = true; ;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                check = false;
            }
            return check;
        }

        public bool del_HangHoa(string MaHH)
        {
            bool check = false;
            try
            {
                conn.Open();
                string sql2 = "DELETE From hang where maHang = '" + MaHH + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
                check = true;
                conn.Close();
            }
            catch
            {
                check = false;
                throw;
            }
            return check;
        }

        public int execute(string sql, List<CustomParameter> lstPara)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //return (int)cmd.ExecuteScalar();

                foreach (var p in lstPara)
                {
                    cmd.Parameters.AddWithValue(p.key, p.value);
                }
                var rs = cmd.ExecuteNonQuery();
                return (int)rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool del_KhachHang(string maKH)
        {
            bool check = false;
            try
            {
                conn.Open();
                string sql1 = "DELETE From khach where maKhach = '" + maKH + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                check = true;
                conn.Close();
            }
            catch
            {
                check = false;
                throw;
            }
            return check;
        }

        public bool del_HoaDon(string maHD)
        {
            bool check = false;
            try
            {
                conn.Open();
                string sql1 = "DELETE From HDban where maHDban = '" + maHD + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                check = true;
                conn.Close();
            }
            catch
            {
                check = false;
                throw;
            }
            return check;
        }

        public bool del_HDban(string maKH)
        {
            bool check = false;
            try
            {
                conn.Open();
                string sql1 = "DELETE From HDban where maKhach = '" + maKH + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                check = true;
                conn.Close();
            }
            catch
            {
                check = false;
                throw;
            }
            return check;
        }

        public bool del_NhanVien(string maNV)
        {
            bool check = false;
            try
            {
                conn.Open();
                string sql1 = "DELETE From nhanvien where maNhanVien = '" + maNV + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                check = true;
                conn.Close();
            }
            catch
            {
                check = false;
                throw;
            }
            return check;
        }

    }
}
