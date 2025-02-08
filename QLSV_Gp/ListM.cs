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
    public partial class ListM : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";
        public ListM()
        {
            InitializeComponent();
        }
        private void ListM_Load(object sender, EventArgs e)
        {
            LoadDanhSachMonHoc();
            dgv_mon.ReadOnly = true; // Ngăn người dùng sửa dữ liệu trên DataGridView
            txt_find.Text = "Tìm kiếm theo MaMon, MaKhoa";
            txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic); // Đổi font, viết nghiêng
            this.ActiveControl = btn_find;

        }
        private void LoadDanhSachMonHoc()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaMon, TenMon, MaGV, HocKi, MaKhoa FROM MON";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    dgv_mon.DataSource = data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void btn_find_Click(object sender, EventArgs e)
        {
            string findText = txt_find.Text.Trim(); // Loại bỏ khoảng trắng thừa

            if (string.IsNullOrEmpty(findText))
            {
                MessageBox.Show("Vui lòng nhập MaMon hoặc MaKhoa");
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT MaMon, TenMon, MaGV, HocKi, MaKhoa FROM MON WHERE MaMon LIKE @FindText OR MaKhoa LIKE @FindText";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@FindText", "%" + findText + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        dgv_mon.DataSource = data;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }
        private void txt_find_Enter(object sender, EventArgs e)
        {
            if (txt_find.Text == "Tìm kiếm theo MaMon, MaKhoa")
            {
                txt_find.Text = ""; // Xóa nội dung textbox
                txt_find.ForeColor = Color.Black; // Đổi màu chữ về đen
                txt_find.Font = new Font(txt_find.Font.FontFamily, 14, FontStyle.Regular); // Đổi font, viết nghiêng
            }
        }

        private void txt_find_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_find.Text))
            {
                txt_find.Text = "Tìm kiếm theo MaMon, MaKhoa";
                txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
                txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic); // Đổi font, viết nghiêng
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT MaMon, TenMon, MaGV, HocKi, MaKhoa FROM MON"; // Lấy các cột cần hiển thị
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        dgv_mon.DataSource = data; // Hiển thị dữ liệu lên DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }
        private void dgv_mon_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) // Click chuột phải vào dòng hợp lệ
            {
                dgv_mon.CurrentCell = dgv_mon.Rows[e.RowIndex].Cells[e.ColumnIndex]; // Chọn ô hiện tại
                dgv_mon.Rows[e.RowIndex].Selected = true; // Chọn dòng hiện tại
            }
        }

        // Thêm sự kiện Click cho mn_xoa
        private void mn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_mon.SelectedRows.Count > 0)
            {
                string maMon = dgv_mon.SelectedRows[0].Cells["MaMon"].Value.ToString();

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "DELETE FROM MON WHERE MaMon = @MaMon";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@MaMon", maMon);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa môn học thành công.");
                                LoadDanhSachMonHoc(); // Cập nhật lại DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Xóa môn học thất bại.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        // Thêm sự kiện Click cho mn_sua
        private void mn_sua_Click(object sender, EventArgs e)
        {
            if (dgv_mon.SelectedRows.Count > 0)
            {
                string maMon = dgv_mon.SelectedRows[0].Cells["MaMon"].Value.ToString();
                EditM editM = new EditM(maMon); // Truyền maMon cho form EditM
                editM.ShowDialog();
                this.Hide();
            }
        }
    }
}
