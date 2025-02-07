using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

namespace QLSV_Gp
{
    public partial class AddGV : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV;Integrated Security=True";
        string filePath = "";



        public AddGV()
        {
            InitializeComponent();
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
        BindingSource bindingSource = new BindingSource();
        private void btn_find_Click(object sender, EventArgs e)
        {
            string findText = txt_find.Text.Trim();

            if (string.IsNullOrEmpty(findText) || findText == "Tìm kiếm theo tên, MaGV")
            {
                MessageBox.Show("Vui lòng nhập MaGV hoặc HoTen.");
                return;
            }

            // Lọc dữ liệu bằng BindingSource.Filter
            bindingSource.Filter = $"MaGV LIKE '%{findText}%' OR HoTen LIKE '%{findText}%'";
        }
        private void txt_find_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_find.Text))
            {
                txt_find.Text = "Tìm kiếm theo tên, MaGV";
                txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
                txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic); // Đổi font, viết nghiêng

                // Xóa filter của BindingSource để hiển thị tất cả giảng viên
                bindingSource.Filter = null;
            }
        }
        int slGV = 0;
        private void btn_browse_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn file Excel
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            openFileDialog.Title = "Chọn file Excel";
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;



            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Đọc dữ liệu từ file Excel
                    DataTable dt = ReadExcelFile(filePath);


                    // Thêm dữ liệu vào dgv_addGV
                    foreach (DataRow row in dt.Rows)
                    {
                        // Tăng số lượng giảng viên và tạo MaGV
                        slGV++;
                        string maGV = "25" + slGV.ToString();

                        // Thêm một dòng mới vào dgv_addGV
                        dgv_addGV.Rows.Add(maGV, row["HoTen"], row["GioiTinh"], row["DienThoai"], row["Email"]);
                    }
                    slGV++;
                    txt_maGV.Text = "25" + slGV.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                string gioiTinh = cb_nam.Checked ? "Nam" : "Nữ";

                dgv_addGV.Rows.Add(txt_maGV.Text, txt_hoTen.Text, gioiTinh, txt_dienThoai.Text, txt_email.Text);
                slGV ++;
                txt_maGV.Text = "25" + slGV.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Hàm đọc dữ liệu từ file Excel
        private DataTable ReadExcelFile(string filePath)
        {
            DataTable dt = new DataTable();


            // Sử dụng thư viện EPPlus để đọc file Excel
            using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // Đọc tên cột
                foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                {
                    dt.Columns.Add(firstRowCell.Text);
                }

                // Đọc dữ liệu
                for (int rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                {
                    var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                    DataRow newRow = dt.NewRow();
                    foreach (var cell in row)
                    {
                        newRow[cell.Start.Column - 1] = cell.Text;
                    }
                    dt.Rows.Add(newRow);
                }
            }

            return dt;
        }

        // Hàm lấy số lượng giảng viên từ database
        private int LaySoLuongGiangVien()
        {
            int soLuongGV = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM GIANG_VIEN";
                    SqlCommand command = new SqlCommand(query, connection);
                    soLuongGV = (int)command.ExecuteScalar();
                    this.slGV = soLuongGV;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            return soLuongGV;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dgv_addGV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu.");
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int savedRowCount = 0;
                    byte[] defaultAvatar;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Properties.Resources.default_avatar.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        defaultAvatar = ms.ToArray();
                    }

                    for (int i = 0; i < dgv_addGV.Rows.Count - 1; i++) // -1 để bỏ qua dòng trống cuối cùng
                    {
                        DataGridViewRow row = dgv_addGV.Rows[i];

                        // Kiểm tra dữ liệu của các ô trong dòng
                        bool isValidRow = true;

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                            {
                                isValidRow = false;
                                break;
                            }
                        }
                        if (isValidRow) // Chỉ lưu dòng có dữ liệu hợp lệ
                        {
                            string maGV = row.Cells["MaGV"].Value.ToString();
                            string hoTen = row.Cells["HoTen"].Value.ToString();
                            string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                            string dienThoai = row.Cells["DienThoai"].Value.ToString();
                            string email = row.Cells["Email"].Value.ToString();
                            string query = @"INSERT INTO GIANG_VIEN (MaGV, HoTen, GioiTinh, DienThoai, Email, Anh) 
                                        VALUES (@MaGV, @HoTen, @GioiTinh, @DienThoai, @Email, @Anh)";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@MaGV", maGV);
                            command.Parameters.AddWithValue("@HoTen", hoTen);
                            command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                            command.Parameters.AddWithValue("@DienThoai", dienThoai);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Anh", defaultAvatar);
                            command.ExecuteNonQuery();
                            // Lưu mật khẩu mặc định vào bảng Users
                            string queryUser = "INSERT INTO Users (MaGV, password, admin) VALUES (@MaGV, '123456', 0)";
                            SqlCommand commandUser = new SqlCommand(queryUser, connection);
                            commandUser.Parameters.AddWithValue("@MaGV", maGV);
                            commandUser.ExecuteNonQuery();
                            savedRowCount++;
                        }
                    }
                    if (savedRowCount > 0)
                    {
                        MessageBox.Show($"Đã lưu thành công {savedRowCount} giảng viên.");
                    }
                    else
                    {
                        MessageBox.Show("Không có giảng viên nào được lưu.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }
        private void btn_del_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_addGV.SelectedRows)
            {
                dgv_addGV.Rows.Remove(row); // Xóa row trực tiếp từ DataGridView
            }
        }
       
        private void cb_nam_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_nam.Checked)
            {
                cb_nu.Checked = false;
            }
        }

        private void cb_nu_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_nu.Checked)
            {
                cb_nam.Checked = false;
            }
        }

        private void AddGV_Load(object sender, EventArgs e)
        {
            dgv_addGV.Columns.Add("MaGV", "Mã GV");
            dgv_addGV.Columns.Add("HoTen", "Họ Tên");
            dgv_addGV.Columns.Add("GioiTinh", "Giới Tính");
            dgv_addGV.Columns.Add("DienThoai", "Điện Thoại");
            dgv_addGV.Columns.Add("Email", "Email");

            // Thêm các thuộc tính tùy chỉnh cho các cột nếu cần (ví dụ: chiều rộng, căn chỉnh,...)
            dgv_addGV.Columns["MaGV"].Width = 120;
            dgv_addGV.Columns["HoTen"].Width = 135;
            dgv_addGV.Columns["DienThoai"].Width = 120;
            dgv_addGV.Columns["Email"].Width = 120;
            dgv_addGV.Columns["GioiTinh"].Width = 120;
            txt_find.Text = "Tìm kiếm theo tên, MaGV";
            txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic);
            LaySoLuongGiangVien();
            txt_maGV.Text = "25" + slGV.ToString();
        }
    }
}