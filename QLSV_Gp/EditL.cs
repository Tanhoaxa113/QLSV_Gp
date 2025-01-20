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
    public partial class EditL : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";
        string MaLop;
        public EditL(string maLop)
        {
            InitializeComponent();
            this.MaLop = maLop;
           
        }
        string MaSV;
        string HoTen;
        string GioiTinh;
        string NgaySinh;
        string DiaChi;
        private void EditL_Load(object sender, EventArgs e)
        {
            txt_wel.Text = MaLop;
            HienThiDanhSachSinhVien();
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
                    string query = "SELECT * FROM SINH_VIEN WHERE MaLop = @MaLop";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaLop", MaLop);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            if (reader.Read())
                            {
                                MaSV = reader["MaSV"].ToString();
                                HoTen = reader["HoTen"].ToString();
                                GioiTinh = reader["GioiTinh"].ToString();
                                NgaySinh = reader["NgaySinh"].ToString();
                                DiaChi = reader["DiaChi"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin sinh viên.");
                            }

                            // Cập nhật dữ liệu trong bảng tạm DS_LOP
                            string updateTempTableQuery = @"
                                UPDATE DS_LOP 
                                SET MaSV = @MaSV,
                                    HoTen = @HoTen, 
                                    NgaySinh = @NgaySinh, 
                                    GioiTinh = @GioiTinh, 
                                    DiaChi = @DiaChi 
                                WHERE MaLop = @MaLop;
                                ";

                            SqlCommand updateTempTableCommand = new SqlCommand(updateTempTableQuery, connection);
                            updateTempTableCommand.Parameters.AddWithValue("@MaLop", MaLop);
                            updateTempTableCommand.Parameters.AddWithValue("@MaSV", MaSV);
                            updateTempTableCommand.Parameters.AddWithValue("@HoTen", HoTen);
                            updateTempTableCommand.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                            updateTempTableCommand.Parameters.AddWithValue("@DiaChi", DiaChi);
                            updateTempTableCommand.ExecuteNonQuery();
                            connection.Close(); // Đóng kết nối

                            // Cập nhật lại các cột trong bảng tạm DS_LOP thành NULL sau khi hiển thị
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                    if (int.TryParse(findText, out _)) // Nếu là số, tìm theo MaSV
                    {
                        query = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi FROM DS_LOP WHERE MaSV = @findText";
                    }
                    else // Nếu là chữ, tìm theo HoTen
                    {
                        query = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi FROM DS_LOP WHERE HoTen LIKE '%' + @findText + '%'";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@findText", findText);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    dgv_lop.DataSource = data; // Cập nhật lại DataGridView

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
                    string query = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, MaLop FROM SINH_VIEN WHERE @MaLop = MaLop"; // Lấy các cột cần hiển thị
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@MaLop", MaLop);
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
        private void mn_del_Click(object sender, EventArgs e)
        {
            if (dgv_lop.SelectedRows.Count > 0)
            {
                string MaSV = dgv_lop.SelectedRows[0].Cells["MaSV"].Value.ToString();

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "UPDATE SINH_VIEN SET MaLop = NULL WHERE MaSV = @MaSV";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@MaSV", MaSV);
                            command.ExecuteNonQuery();
                            connection.Close();

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
                        string query = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, MaLop  FROM SINH_VIEN WHERE @MaLop = MaLop"; // Lấy các cột cần hiển thị
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        adapter.SelectCommand.Parameters.AddWithValue("@MaLop", MaLop);
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
    }
}
