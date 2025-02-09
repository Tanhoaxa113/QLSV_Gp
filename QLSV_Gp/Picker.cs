using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_Gp
{
    public partial class Picker : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";
        public Picker()
        {
            InitializeComponent();
        }
        private void Picker_Load(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void LoadDanhSachLop()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaLop FROM LOP";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    cbb_lop.DataSource = data;
                    cbb_lop.DisplayMember = "MaLop";
                    cbb_lop.ValueMember = "MaLop";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void LoadDanhSachMonHoc(string maKhoa = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaMon, TenMon FROM MON";

                    // Nếu maKhoa được cung cấp, thêm điều kiện lọc theo maKhoa
                    if (!string.IsNullOrEmpty(maKhoa))
                    {
                        query += " WHERE MaKhoa = @maKhoa";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Nếu maKhoa được cung cấp, thêm tham số @maKhoa vào truy vấn
                    if (!string.IsNullOrEmpty(maKhoa))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@maKhoa", maKhoa);
                    }

                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    data.Columns.Add("MaMon_TenMon", typeof(string), "MaMon + ' - ' + TenMon");

                    cbb_mon.DataSource = data;
                    cbb_mon.DisplayMember = "MaMon_TenMon";
                    cbb_mon.ValueMember = "MaMon";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng Form Picker

            // Mở lại Form Admin
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            string maLop = cbb_lop.SelectedValue.ToString();
            string maMon = cbb_mon.SelectedValue.ToString();

            // Mở Form ListPoint và truyền maLop, maMon
            ListPoint listPoint = new ListPoint(maLop, maMon);
            listPoint.ShowDialog();
        }
        private void cbb_lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maLop = cbb_lop.SelectedValue.ToString();
            string maKhoa = maLop.Substring(4, 3); // Lấy 3 ký tự từ vị trí thứ 5 (index 4)
            LoadDanhSachMonHoc(maKhoa);
        }

    }
}
