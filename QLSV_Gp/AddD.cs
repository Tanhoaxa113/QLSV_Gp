using OfficeOpenXml;
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
    public partial class AddD : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";
        string maGV;
        string maMon;
        public AddD(string MaGV)
        {
            InitializeComponent();
            this.maGV = MaGV;
        }
        private void AddD_Load(object sender, EventArgs e)
        {
            LoadDanhSachMonHoc();
            if (cbb_maMon.SelectedValue != null)
            {
                maMon = cbb_maMon.SelectedValue.ToString();
                txt_tenMon.Text = LayTenMonHoc(maMon);
            }
        }

        private void LoadDanhSachMonHoc()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Chỉ lấy MaMon từ bảng MON
                    string query = "SELECT MaMon FROM MON WHERE MaGV = @maGV";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@maGV", maGV);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    cbb_maMon.DataSource = data;
                    cbb_maMon.DisplayMember = "MaMon"; // Hiển thị MaMon trên combobox
                    cbb_maMon.ValueMember = "MaMon";

                    // Thêm sự kiện SelectedIndexChanged cho cbb_maMon để cập nhật txt_tenMon
                    cbb_maMon.SelectedIndexChanged += cbb_maMon_SelectedIndexChanged;

                    // Sau khi load danh sách môn học, load danh sách học kỳ
                    LoadDanhSachHocKi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void LoadDanhSachHocKi()
        {
            if (cbb_maMon.SelectedValue == null)
            {
                return; // Chưa chọn môn học
            }

            // Lấy MaMon từ cbb_maMon.SelectedValue dưới dạng chuỗi
            string maMon = cbb_maMon.SelectedValue.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Lấy danh sách học kỳ riêng biệt
                    string query = "SELECT DISTINCT HocKi FROM MON WHERE MaGV = @maGV AND MaMon = @maMon"; // Thêm điều kiện MaMon
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@maGV", maGV);
                    adapter.SelectCommand.Parameters.AddWithValue("@maMon", maMon); // Thêm tham số @maMon
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    cbb_hocKi.DataSource = data;
                    cbb_hocKi.DisplayMember = "HocKi";
                    cbb_hocKi.ValueMember = "HocKi";

                    // Sau khi load danh sách học kỳ, load danh sách sinh viên
                    LoadDanhSachSinhVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void LoadDanhSachSinhVien()
        {
            if (cbb_maMon.SelectedValue == null || cbb_hocKi.SelectedValue == null)
            {
                return; // Chưa chọn môn học hoặc học kỳ
            }

            string maMon = cbb_maMon.SelectedValue.ToString();
            if (int.TryParse(cbb_hocKi.SelectedValue.ToString(), out int hocKi))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        // Sử dụng hocKi (kiểu int) trong câu truy vấn SQL
                        string query = @"SELECT sv.MaSV, sv.HoTen, kq.DiemTB, kq.ChuyenCan, kq.GiuaKy, kq.DiemCuoiKy, kq.GhiChu
                                FROM SINH_VIEN sv
                                INNER JOIN KET_QUA kq ON sv.MaSV = kq.MaSV
                                WHERE kq.MaMon = @maMon AND kq.HocKi = @hocKi";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        adapter.SelectCommand.Parameters.AddWithValue("@maMon", maMon);
                        adapter.SelectCommand.Parameters.AddWithValue("@hocKi", hocKi); // Sử dụng hocKi
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        dgv_listPoint.DataSource = data;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }
        private void btn_sapXep_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ dgv_listPoint
            DataTable dt = (DataTable)dgv_listPoint.DataSource;

            // Sắp xếp DataTable theo cột HoTen
            dt.DefaultView.Sort = "HoTen ASC";

            // Gán lại DataSource cho dgv_listPoint
            dgv_listPoint.DataSource = dt;
        }

        // Sự kiện khi thay đổi lựa chọn môn học
        private void cbb_maMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_maMon.SelectedValue != null)
            {
                string maMon = cbb_maMon.SelectedValue.ToString();
                txt_tenMon.Text = LayTenMonHoc(maMon); // Cập nhật txt_tenMon
                LoadDanhSachSinhVien(); // Load lại danh sách sinh viên
            }
        }

        // Sự kiện khi thay đổi lựa chọn học kỳ
        private void cbb_hocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachSinhVien();
        }
        private string LayTenMonHoc(string maMon)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TenMon FROM MON WHERE MaMon = @maMon";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@maMon", maMon);
                    return command.ExecuteScalar()?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return "";
                }
            }
        }
        private void btn_export_Click(object sender, EventArgs e)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Bảng điểm");

                // Ghi header
                ws.Cells[1, 1].Value = "BẢNG ĐIỂM";
                ws.Cells[2, 1].Value = "Học kỳ: " + cbb_hocKi.SelectedValue.ToString();
                ws.Cells[3, 1].Value = cbb_maMon.SelectedValue.ToString();
                ws.Cells[3, 2].Value = txt_tenMon.Text;

                // Ghi header cho bảng điểm
                int rowIndex = 5; // Bắt đầu ghi header bảng điểm từ dòng thứ 5
                for (int i = 0; i < dgv_listPoint.Columns.Count; i++)
                {
                    ws.Cells[rowIndex, i + 1].Value = dgv_listPoint.Columns[i].HeaderText;
                }
                rowIndex++; // Tăng rowIndex để ghi data từ dòng tiếp theo

                // Ghi data từ dgv_listPoint
                for (int i = 0; i < dgv_listPoint.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_listPoint.Columns.Count; j++)
                    {
                        ws.Cells[rowIndex, j + 1].Value = dgv_listPoint.Rows[i].Cells[j].Value;
                    }
                    rowIndex++;
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                    excel.SaveAs(excelFile);
                    MessageBox.Show("Xuất dữ liệu thành công!");
                }
            }
        }
        private void btn_import_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            openFileDialog.Title = "Chọn file Excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    dgv_listPoint.DataSource = null;
                    dgv_listPoint.Rows.Clear();
                    // Đọc dữ liệu từ file Excel
                    DataTable dt = ReadExcelFile(filePath);

                    // Xử lý dữ liệu (ví dụ: hiển thị lên dgv_listPoint, lưu vào database,...)
                    dgv_listPoint.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private DataTable ReadExcelFile(string filePath)
        {
            DataTable dt = new DataTable();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets[0];
                // Đọc header cho bảng điểm
                int rowIndex = 5;
                foreach (var cell in ws.Cells[rowIndex, 1, rowIndex, ws.Dimension.End.Column])
                {
                    dt.Columns.Add(cell.Text);
                }
                rowIndex++;

                // Đọc data
                for (; rowIndex <= ws.Dimension.End.Row; rowIndex++)
                {
                    DataRow row = dt.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        row[j] = ws.Cells[rowIndex, j + 1].Value;
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (dgv_listPoint.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command;

                    foreach (DataGridViewRow row in dgv_listPoint.Rows)
                    {
                        if (row.IsNewRow) continue; // Bỏ qua dòng mới (dòng trống cuối cùng)

                        string maSV = row.Cells["MaSV"].Value.ToString();
                        string diemTB = row.Cells["DiemTB"].Value?.ToString();
                        string chuyenCan = row.Cells["ChuyenCan"].Value?.ToString();
                        string giuaKy = row.Cells["GiuaKy"].Value?.ToString();
                        string diemCuoiKy = row.Cells["DiemCuoiKy"].Value?.ToString();
                        string ghiChu = row.Cells["GhiChu"].Value?.ToString();
                        string hocKi = cbb_hocKi.SelectedValue.ToString();
                        // Kiểm tra xem bản ghi đã tồn tại trong CSDL chưa
                        string checkQuery = "SELECT COUNT(*) FROM KET_QUA WHERE MaSV = @MaSV AND MaMon = @MaMon";
                        command = new SqlCommand(checkQuery, connection);
                        command.Parameters.AddWithValue("@MaSV", maSV);
                        command.Parameters.AddWithValue("@MaMon", maMon);
                        int existingRecordCount = (int)command.ExecuteScalar();

                        if (existingRecordCount > 0)
                        {
                            // Nếu bản ghi đã tồn tại, cập nhật dữ liệu
                            string updateQuery = @"UPDATE KET_QUA 
                                            SET DiemTB = @DiemTB, 
                                                ChuyenCan = @ChuyenCan, 
                                                GiuaKy = @GiuaKy, 
                                                DiemCuoiKy = @DiemCuoiKy, 
                                                GhiChu = @GhiChu,
                                                HocKi = @HocKi
                                            WHERE MaSV = @MaSV AND MaMon = @MaMon";
                            command = new SqlCommand(updateQuery, connection);
                            command.Parameters.AddWithValue("@DiemTB", diemTB);
                            command.Parameters.AddWithValue("@ChuyenCan", chuyenCan);
                            command.Parameters.AddWithValue("@GiuaKy", giuaKy);
                            command.Parameters.AddWithValue("@DiemCuoiKy", diemCuoiKy);
                            command.Parameters.AddWithValue("@GhiChu", ghiChu);
                            command.Parameters.AddWithValue("@MaSV", maSV);
                            command.Parameters.AddWithValue("@MaMon", maMon);
                            command.Parameters.AddWithValue("@HocKi", hocKi);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            // Nếu bản ghi chưa tồn tại, thêm dữ liệu mới
                            string insertQuery = @"INSERT INTO KET_QUA (MaSV, MaMon, DiemTB, ChuyenCan, GiuaKy, DiemCuoiKy, GhiChu, HocKi) 
                                            VALUES (@MaSV, @MaMon, @DiemTB, @ChuyenCan, @GiuaKy, @DiemCuoiKy, @GhiChu, @HocKi)";
                            command = new SqlCommand(insertQuery, connection);
                            command.Parameters.AddWithValue("@MaSV", maSV);
                            command.Parameters.AddWithValue("@MaMon", maMon);
                            command.Parameters.AddWithValue("@DiemTB", diemTB);
                            command.Parameters.AddWithValue("@ChuyenCan", chuyenCan);
                            command.Parameters.AddWithValue("@GiuaKy", giuaKy);
                            command.Parameters.AddWithValue("@DiemCuoiKy", diemCuoiKy);
                            command.Parameters.AddWithValue("@GhiChu", ghiChu);
                            command.Parameters.AddWithValue("@HocKi", hocKi);
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Lưu dữ liệu thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }
    }
}
