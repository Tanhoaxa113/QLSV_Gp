using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_Gp
{
    public partial class ListL : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM;Initial Catalog=QLSV; Integrated security = True";
        public ListL()
        {
            InitializeComponent();
        }
        ExportListL exportListL;
        private void ListL_Load(object sender, EventArgs e)
        {
            exportListL = new ExportListL();
            HienThiDanhSachLop();
            dgv_lop.ReadOnly = true;
            txt_find.Text = "Tìm kiếm theo MaLop, MaKhoa";
            txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic); // Đổi font, viết nghiêng
            this.ActiveControl = btn_find;
        }
        private void btn_find_Click(object sender, EventArgs e)
        {
            string findText = txt_find.Text.Trim(); // Loại bỏ khoảng trắng thừa

            if (string.IsNullOrEmpty(findText))
            {
                MessageBox.Show("Vui lòng nhập MaLop hoặc MaKhoa");
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT MaLop, MaKhoa FROM LOP WHERE MaLop LIKE @FindText OR MaKhoa LIKE @FindText";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@FindText", "%" + findText + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        dgv_lop.DataSource = data;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        private void HienThiDanhSachLop()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaLop, MaKhoa FROM LOP"; // Lấy các cột cần hiển thị
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dgv_lop.DataSource = data; // Hiển thị dữ liệu lên DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void dgv_lop_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem có click vào dòng hợp lệ không
            {
                string maLop = dgv_lop.Rows[e.RowIndex].Cells["MaLop"].Value.ToString();
                string maKhoa = dgv_lop.Rows[e.RowIndex].Cells["MaKhoa"].Value.ToString();
                if (exportListL == null || exportListL.IsDisposed)
                {
                    exportListL = new ExportListL();
                }
                int soLuong = LaySoLuongSinhVien(maLop);

                if (exportListL == null || exportListL.IsDisposed)
                {
                    exportListL = new ExportListL();
                }
                // Thêm lớp và số lượng sinh viên vào ListBox 
                exportListL.ThemLop(maLop, maKhoa, soLuong);
                exportListL.Show();
            }
        }
        private int LaySoLuongSinhVien(string maLop)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM SINH_VIEN WHERE MaLop = @MaLop";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaLop", maLop);

                    int soLuong = (int)command.ExecuteScalar();
                    return soLuong;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return 0; // Hoặc xử lý lỗi theo cách khác
                }
            }
        }
        private void mn_change_Click(object sender, EventArgs e)
        {
            string maLop = dgv_lop.SelectedRows[0].Cells["MaLop"].Value.ToString();
            if (dgv_lop.SelectedRows.Count > 0 && string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Không tìm thấy thông tin lớp!");
            }
            else
            {
                maLop = dgv_lop.SelectedRows[0].Cells["MaLop"].Value.ToString();
                EditL editL = new EditL(maLop);
                editL.ShowDialog();
            }

        }
        // Sự kiện Click của xóaToolStripMenuItem
        private void mn_del_Click(object sender, EventArgs e)
        {
            if (dgv_lop.SelectedRows.Count > 0)
            {
                string maLop = dgv_lop.SelectedRows[0].Cells["MaLop"].Value.ToString();

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string queryUser = "DELETE FROM SINH_VIEN WHERE MaLop = @MaLop";
                            SqlCommand commandUser = new SqlCommand(queryUser, connection);
                            commandUser.Parameters.AddWithValue("@MaLop", maLop);
                            commandUser.ExecuteNonQuery();
                            string query = "DELETE FROM LOP WHERE MaLop = @MaLop";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@MaLop", maLop);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa lớp thành công.");
                                HienThiDanhSachLop(); // Cập nhật lại DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Xóa lớp thất bại.");
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
        private void txt_find_Enter(object sender, EventArgs e)
        {
            if (txt_find.Text == "Tìm kiếm theo MaLop, MaKhoa")
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
                txt_find.Text = "Tìm kiếm theo MaLop, MaKhoa";
                txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
                txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic); // Đổi font, viết nghiêng
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT MaLop, MaKhoa FROM LOP"; // Lấy các cột cần hiển thị
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        dgv_lop.DataSource = data; // Hiển thị dữ liệu lên DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }
        private void dgv_lop_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) // Click chuột phải vào dòng hợp lệ
            {
                if (e.ColumnIndex >= 0) // Dùng thêm 1 dòng if để tránh event out range do click cột trái cùng (header cell)
                {
                    dgv_lop.CurrentCell = dgv_lop.Rows[e.RowIndex].Cells[e.ColumnIndex]; // Chọn ô hiện tại
                    dgv_lop.Rows[e.RowIndex].Selected = true; // Chọn dòng hiện tại
                }
                else
                {
                    MessageBox.Show("Vui lòng không click vào header cell");
                }

            }
        }
    }
}

