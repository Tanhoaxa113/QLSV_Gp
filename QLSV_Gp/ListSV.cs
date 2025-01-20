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
    public partial class ListSV : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";
        public ListSV()
        {
            InitializeComponent();
            
        }
        
        private void ListSV_Load(object sender, EventArgs e)
        {
            exportList = new ExportListSV();
            HienThiDanhSachSinhVien();
            dg_dsSinhVien.ReadOnly = true;
            txt_find.Text = "Tìm kiếm theo tên, MaSV";
            txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic); // Đổi font, viết nghiêng
            this.ActiveControl = btn_find;
        }
        private void btn_find_Click(object sender, EventArgs e)
        {
            string findText = txt_find.Text.Trim(); // Loại bỏ khoảng trắng thừa

            if (string.IsNullOrEmpty(findText))
            {
                MessageBox.Show("Vui lòng nhập MaSV hoặc HoTen.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query;
                    if (int.TryParse(findText, out _)) // Nếu là số, tìm theo MaSV
                    {
                        query = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, MaLop FROM SINH_VIEN WHERE MaSV = @findText";
                    }
                    else // Nếu là chữ, tìm theo HoTen
                    {
                        query = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, MaLop FROM SINH_VIEN WHERE HoTen LIKE '%' + @findText + '%'";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@findText", findText);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    dg_dsSinhVien.DataSource = data; // Cập nhật lại DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void HienThiDanhSachSinhVien()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, MaLop FROM SINH_VIEN"; // Lấy các cột cần hiển thị
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    dg_dsSinhVien.DataSource = data; // Hiển thị dữ liệu lên DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        ExportListSV exportList;
        private void dg_dsSinhVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem có click vào dòng hợp lệ không
            {
                string MaSV = dg_dsSinhVien.Rows[e.RowIndex].Cells["MaSV"].Value.ToString();
                string hoTen = dg_dsSinhVien.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                string ngaySinh = dg_dsSinhVien.Rows[e.RowIndex].Cells["NgaySinh"].Value.ToString();
                string gioiTinh = dg_dsSinhVien.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
                string diaChi = dg_dsSinhVien.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                string maLop = dg_dsSinhVien.Rows[e.RowIndex].Cells["MaLop"].Value.ToString();

                if (exportList == null || exportList.IsDisposed)
                {
                    exportList = new ExportListSV();
                }

                // Thêm sinh viên vào ListBox (hoặc DataGridView)
                exportList.ThemSinhVien(MaSV, hoTen, ngaySinh, gioiTinh, diaChi, maLop);

                exportList.Show();
            }
        }

        private void dg_dsSinhVien_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) // Click chuột phải vào dòng hợp lệ
            {
                if (e.ColumnIndex >= 0) // Dùng thêm 1 dòng if để tránh event out range do click cột trái cùng (header cell)
                {
                    dg_dsSinhVien.CurrentCell = dg_dsSinhVien.Rows[e.RowIndex].Cells[e.ColumnIndex]; // Chọn ô hiện tại
                    dg_dsSinhVien.Rows[e.RowIndex].Selected = true; // Chọn dòng hiện tại
                }
                else
                {
                    MessageBox.Show("Vui lòng không click vào header cell");
                }

            }
        }
        private void mn_change_Click(object sender, EventArgs e)
        {
            if (dg_dsSinhVien.SelectedRows.Count > 0)
            {
                string MaSV = dg_dsSinhVien.SelectedRows[0].Cells["MaSV"].Value.ToString();
                EditGV changeInfo = new EditGV(MaSV);
                changeInfo.ShowDialog();
            }
        }
        // Sự kiện Click của xóaToolStripMenuItem
        private void mn_del_Click(object sender, EventArgs e)
        {
            if (dg_dsSinhVien.SelectedRows.Count > 0)
            {
                string MaSV = dg_dsSinhVien.SelectedRows[0].Cells["MaSV"].Value.ToString();

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string queryUser = "DELETE FROM KET_QUA WHERE MaSV = @MaSV";
                            SqlCommand commandUser = new SqlCommand(queryUser, connection);
                            commandUser.Parameters.AddWithValue("@MaSV", MaSV);
                            commandUser.ExecuteNonQuery();
                            string query = "DELETE FROM SINH_VIEN WHERE MaSV = @MaSV";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@MaSV", MaSV);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa sinh viên thành công.");
                                HienThiDanhSachSinhVien(); // Cập nhật lại DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Xóa sinh viên thất bại.");
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
            if (txt_find.Text == "Tìm kiếm theo tên, MaSV")
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
                txt_find.Text = "Tìm kiếm theo tên, MaSV";
                txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
                txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic); // Đổi font, viết nghiêng
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, MaLop  FROM SINH_VIEN"; // Lấy các cột cần hiển thị
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        dg_dsSinhVien.DataSource = data; // Hiển thị dữ liệu lên DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }
    }
}
