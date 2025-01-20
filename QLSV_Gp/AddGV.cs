using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QLSV_Gp
{
    public partial class AddGV : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM;Initial Catalog=QLSV;Integrated Security=True";
        string filePath = "";


        public AddGV()
        {
            InitializeComponent();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            openFileDialog.Title = "Chọn file Excel";


            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                try
                {
                    using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        DataTable dt = new DataTable();

                        // Xác định số cột bằng cách kiểm tra từng ô trong hàng đầu tiên
                        int lastColumn = 1;
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            if (string.IsNullOrEmpty(worksheet.Cells[1, col].Text))
                            {
                                break;
                            }
                            lastColumn = col;
                        }

                        // Đọc tên cột
                        foreach (var firstRowCell in worksheet.Cells[1, 1, 1, lastColumn])
                        {
                            dt.Columns.Add(firstRowCell.Text);
                        }

                        // Đọc dữ liệu
                        for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                        {
                            var row = worksheet.Cells[rowNumber, 1, rowNumber, lastColumn];
                            DataRow newRow = dt.NewRow();
                            foreach (var cell in row)
                            {
                                newRow[cell.Start.Column - 1] = cell.Text;
                            }
                            dt.Rows.Add(newRow);
                        }

                        dgv_addGV.DataSource = dt;
                        bindingSource.DataSource = dt;
                        dgv_addGV.DataSource = bindingSource;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message);
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

        private void AddGV_Load(object sender, EventArgs e)
        {
            txt_find.Text = "Tìm kiếm theo tên, MaGV";
            txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic);
        }
    }
}