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
    public partial class ListPoint : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";
        string maLop;
        string maMon;
        public ListPoint(string MaLop, string MaMon)
        {
            InitializeComponent();
            this.maLop = MaLop;
            this.maMon = MaMon;
        }
        private void ListPoint_Load(object sender, EventArgs e)
        {
            LoadThongTinMonHoc();
            LoadDanhSachSinhVien();
            txt_maLop.Text = maLop;
        }
        private void LoadThongTinMonHoc()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM MON WHERE MaMon = @maMon";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@maMon", maMon);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_maMon.Text = reader["MaMon"].ToString();
                            txt_tenMon.Text = reader["TenMon"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin môn học.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void LoadDanhSachSinhVien()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Cập nhật câu truy vấn SQL để lấy thêm các cột
                    string query = @"SELECT sv.MaSV, sv.HoTen, kq.DiemTB, kq.ChuyenCan, kq.GiuaKy, kq.DiemCuoiKy, kq.GhiChu, kq.HocKi
                            FROM SINH_VIEN sv
                            INNER JOIN KET_QUA kq ON sv.MaSV = kq.MaSV
                            WHERE sv.MaLop = @maLop AND kq.MaMon = @maMon";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@maLop", maLop);
                    adapter.SelectCommand.Parameters.AddWithValue("@maMon", maMon);
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

        private void btn_export_Click(object sender, EventArgs e)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Bảng điểm");

                // Ghi header
                ws.Cells[1,1].Value = "BẢNG ĐIỂM";
                ws.Cells[2,1].Value = txt_maLop.Text;
                ws.Cells[3,1].Value = txt_maMon.Text;
                ws.Cells[4,1].Value = txt_tenMon.Text;

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
                    int savedRowCount = 0;

                    for (int i = 0; i < dgv_listPoint.Rows.Count - 1; i++) // -1 để bỏ qua dòng trống cuối cùng
                    {
                        DataGridViewRow row = dgv_listPoint.Rows[i];

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
                            string diemTB = row.Cells["DiemTB"].Value.ToString();
                            string chuyenCan = row.Cells["ChuyenCan"].Value.ToString();
                            string giuaKy = row.Cells["GiuaKy"].Value.ToString();
                            string diemCuoiKy = row.Cells["DiemCuoiKy"].Value.ToString();
                            string ghiChu = row.Cells["GhiChu"].Value.ToString();
                            string hocKi = row.Cells["HocKi"].Value.ToString();

                            string query = @"UPDATE KET_QUA 
                                    SET DiemTB = @DiemTB, 
                                        ChuyenCan = @ChuyenCan, 
                                        GiuaKy = @GiuaKy, 
                                        DiemCuoiKy = @DiemCuoiKy, 
                                        GhiChu = @GhiChu,
                                        HocKi = @HocKi
                                    WHERE MaSV = @MaSV AND MaMon = @MaMon";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@DiemTB", diemTB);
                            command.Parameters.AddWithValue("@ChuyenCan", chuyenCan);
                            command.Parameters.AddWithValue("@GiuaKy", giuaKy);
                            command.Parameters.AddWithValue("@DiemCuoiKy", diemCuoiKy);
                            command.Parameters.AddWithValue("@GhiChu", ghiChu);
                            command.Parameters.AddWithValue("@HocKi", hocKi);
                            command.Parameters.AddWithValue("@MaSV", maSV);
                            command.Parameters.AddWithValue("@MaMon", maMon);
                            command.ExecuteNonQuery();
                            savedRowCount++;
                        }
                    }

                    if (savedRowCount > 0)
                    {
                        MessageBox.Show($"Đã lưu thành công {savedRowCount} sinh viên.");
                    }
                    else
                    {
                        MessageBox.Show("Không có sinh viên nào được lưu.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }
    }
}
