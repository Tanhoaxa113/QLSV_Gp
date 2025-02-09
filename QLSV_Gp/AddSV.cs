using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QLSV_Gp
{
    public partial class AddSV : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV;Integrated Security=True";
        string filePath = "";


        public AddSV()
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

                        dgv_AddSV.DataSource = dt;
                        bindingSource.DataSource = dt;
                        dgv_AddSV.DataSource = bindingSource;
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
            if (txt_find.Text == "Tìm kiếm theo tên, MaSV")
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

            if (string.IsNullOrEmpty(findText) || findText == "Tìm kiếm theo tên, MaSV")
            {
                MessageBox.Show("Vui lòng nhập MaSV hoặc HoTen.");
                return;
            }

            // Lọc dữ liệu bằng BindingSource.Filter
            bindingSource.Filter = $"MaSV LIKE '%{findText}%' OR HoTen LIKE '%{findText}%'";
        }
        private void txt_find_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_find.Text))
            {
                txt_find.Text = "Tìm kiếm theo tên, MaSV";
                txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
                txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic); // Đổi font, viết nghiêng

                // Xóa filter của BindingSource để hiển thị tất cả giảng viên
                bindingSource.Filter = null;
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dgv_AddSV.Rows.Count == 0)
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

                    for (int i = 0; i < dgv_AddSV.Rows.Count - 1; i++) // -1 để bỏ qua dòng trống cuối cùng
                    {
                        DataGridViewRow row = dgv_AddSV.Rows[i];

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
                            string maSV = row.Cells["MaSV"].Value.ToString();
                            string hoTen = row.Cells["HoTen"].Value.ToString();
                            string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                            string ngaySinh = row.Cells["ngaySinh"].Value.ToString();
                            string diaChi = row.Cells["DiaChi"].Value.ToString();
                            string maLop = row.Cells["MaLop"].Value.ToString();
                            string query = @"INSERT INTO SINH_VIEN (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, MaLop) 
                                        VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @MaLop)";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@MaSV", maSV);
                            command.Parameters.AddWithValue("@HoTen", hoTen);
                            command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                            command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                            command.Parameters.AddWithValue("@DiaChi", diaChi);
                            command.Parameters.AddWithValue("@MaLop", maLop);
                            command.ExecuteNonQuery();
                            savedRowCount++;
                        }
                    }
                    if (savedRowCount > 0)
                    {
                        MessageBox.Show($"Đã lưu thành công {savedRowCount} sinh viên.");
                        this.Close();
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
            foreach (DataGridViewRow row in dgv_AddSV.SelectedRows)
            {
                dgv_AddSV.Rows.Remove(row); // Xóa row trực tiếp từ DataGridView
            }
        }

        private void AddSV_Load(object sender, EventArgs e)
        {
            txt_find.Text = "Tìm kiếm theo tên, MaSV";
            txt_find.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            txt_find.Font = new Font(txt_find.Font.FontFamily, 10, FontStyle.Italic);
        }
    }
}