using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Mapping;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_Gp
{
    public partial class ListGV : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM;Initial Catalog=QLSV; Integrated security = True";

        public ListGV()
        {
            InitializeComponent();
        }

        private void ListGV_Load(object sender, EventArgs e)
        {
            exportList = new ExportListGV();
            HienThiDanhSachGiangVien();
            dg_dsGiangVien.ReadOnly = true;
            txt_find.Text = "Tìm kiếm theo tên, MaGV";
            txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic); // Đổi font, viết nghiêng
            this.ActiveControl = pb_info;
        }
        private void btn_find_Click(object sender, EventArgs e)
        {
            string findText = txt_find.Text.Trim(); // Loại bỏ khoảng trắng thừa

            if (string.IsNullOrEmpty(findText))
            {
                MessageBox.Show("Vui lòng nhập MaGV hoặc HoTen.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query;
                    if (int.TryParse(findText, out _)) // Nếu là số, tìm theo MaGV
                    {
                        query = "SELECT MaGV, HoTen, GioiTinh, DienThoai, Email FROM GIANG_VIEN WHERE MaGV = @findText";
                    }
                    else // Nếu là chữ, tìm theo HoTen
                    {
                        query = "SELECT MaGV, HoTen, GioiTinh, DienThoai, Email FROM GIANG_VIEN WHERE HoTen LIKE '%' + @findText + '%'";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@findText", findText);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    dg_dsGiangVien.DataSource = data; // Cập nhật lại DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void HienThiDanhSachGiangVien()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaGV, HoTen, GioiTinh, DienThoai, Email FROM GIANG_VIEN"; // Lấy các cột cần hiển thị
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    dg_dsGiangVien.DataSource = data; // Hiển thị dữ liệu lên DataGridView
                    foreach (DataGridViewRow row in dg_dsGiangVien.Rows)
                    {
                        if (row.Cells["MaGV"].Value.ToString() == "admin")
                        {
                            row.Visible = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        ExportListGV exportList;
        private void dg_dsGiangVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem có click vào dòng hợp lệ không
            {
                string maGV = dg_dsGiangVien.Rows[e.RowIndex].Cells["MaGV"].Value.ToString();
                string hoTen = dg_dsGiangVien.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                string gioiTinh = dg_dsGiangVien.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
                string dienThoai = dg_dsGiangVien.Rows[e.RowIndex].Cells["DienThoai"].Value.ToString();
                string email = dg_dsGiangVien.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                if (exportList == null || exportList.IsDisposed)
                {
                    exportList = new ExportListGV();
                }
                // Thêm giảng viên vào ListBox (hoặc DataGridView)
                exportList.ThemGiangVien(maGV, hoTen, gioiTinh, dienThoai, email);
                exportList.Show();
            }
        }
        
        private void dg_dsGiangVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem có click vào dòng hợp lệ không
            {
                string maGV = dg_dsGiangVien.Rows[e.RowIndex].Cells["MaGV"].Value.ToString(); // Lấy MaGV của giảng viên được click

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT Anh FROM GIANG_VIEN WHERE MaGV = @MaGV";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MaGV", maGV);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read() && reader["Anh"] != DBNull.Value)
                            {
                                byte[] anhData = (byte[])reader["Anh"];
                                MemoryStream ms = new MemoryStream(anhData);
                                Image anh = Image.FromStream(ms);
                                pb_info.Image = anh;
                            }
                            else
                            {
                                pb_info.Image = null; 
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
        private void dg_dsGiangVien_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) // Click chuột phải vào dòng hợp lệ
            {
                if (e.ColumnIndex >= 0) // Dùng thêm 1 dòng if để tránh event out range do click cột trái cùng (header cell)
                {
                    dg_dsGiangVien.CurrentCell = dg_dsGiangVien.Rows[e.RowIndex].Cells[e.ColumnIndex]; // Chọn ô hiện tại
                    dg_dsGiangVien.Rows[e.RowIndex].Selected = true; // Chọn dòng hiện tại
                }
                else
                {
                    MessageBox.Show("Vui lòng không click vào header cell");
                }

            }
        }
        private void mn_change_Click(object sender, EventArgs e)
        {
            string maGV = dg_dsGiangVien.SelectedRows[0].Cells["MaGV"].Value.ToString();
            if (dg_dsGiangVien.SelectedRows.Count > 0 && string.IsNullOrEmpty(maGV))
            {
                MessageBox.Show("Không tìm thấy thông tin giảng viên!");
            }
            else
            { 
                maGV = dg_dsGiangVien.SelectedRows[0].Cells["MaGV"].Value.ToString();
                EditGV changeInfo = new EditGV(maGV);
                changeInfo.ShowDialog();
            }
            
        }
        // Sự kiện Click của xóaToolStripMenuItem
        private void mn_del_Click(object sender, EventArgs e)
        {
            if (dg_dsGiangVien.SelectedRows.Count > 0)
            {
                string maGV = dg_dsGiangVien.SelectedRows[0].Cells["MaGV"].Value.ToString();

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa giảng viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string queryUser = "DELETE FROM Users WHERE MaGV = @MaGV";
                            SqlCommand commandUser = new SqlCommand(queryUser, connection);
                            commandUser.Parameters.AddWithValue("@MaGV", maGV);
                            commandUser.ExecuteNonQuery();
                            string query = "DELETE FROM GIANG_VIEN WHERE MaGV = @MaGV";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@MaGV", maGV);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa giảng viên thành công.");
                                HienThiDanhSachGiangVien(); // Cập nhật lại DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Xóa giảng viên thất bại.");
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
            if (txt_find.Text == "Tìm kiếm theo tên, MaGV")
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
                txt_find.Text = "Tìm kiếm theo tên, MaGV";
                txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
                txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic); // Đổi font, viết nghiêng
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT MaGV, HoTen, GioiTinh, DienThoai, Email FROM GIANG_VIEN"; // Lấy các cột cần hiển thị
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        dg_dsGiangVien.DataSource = data; // Hiển thị dữ liệu lên DataGridView
                        foreach (DataGridViewRow row in dg_dsGiangVien.Rows)
                        {
                            if (row.Cells["MaGV"].Value.ToString() == "admin")
                            {
                                row.Visible = false;
                                break;
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
    }
}