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
    public partial class ExportListL : Form
    {
        DataTable dt_lop = new DataTable();
        string connectionString = @"Data Source=DESKTOP-09B6QVM;Initial Catalog=QLSV; Integrated security = True";
        string maLop;
        string maKhoa;
        int soLuong;
        public void ThemLop(string maLop, string maKhoa, int soLuong)
        {
            // Tạo DataRow từ DataTable dt_lop
            DataRow row = dt_lop.NewRow();
            row["MaLop"] = maLop;
            row["MaKhoa"] = maKhoa;
            row["SoLuong"] = soLuong;
            this.maLop = maLop;
            this.maKhoa = maKhoa;
            this.soLuong = soLuong;
            dt_lop.Rows.Add(row); // Thêm DataRow vào DataTable
        }
        public ExportListL()
        {
            InitializeComponent();

            // Khởi tạo DataTable (chỉ một lần)
            dt_lop.Columns.Add("MaLop", typeof(string));
            dt_lop.Columns.Add("MaKhoa", typeof(string));
            dt_lop.Columns.Add("SoLuong", typeof(int));

            dgv_lop.DataSource = dt_lop; // Gán DataTable cho DataGridView
        }

        public class SinhVien
        {
            public string MaSV { get; set; }
            public string HoTen { get; set; }
            public string GioiTinh { get; set; }
            public string NgaySinh { get; set; }
            public string DiaChi { get; set; }
        }
        private List<SinhVien> LayDanhSachSinhVien(string maLop)
        {
            List<SinhVien> danhSachSinhVien = new List<SinhVien>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaSV, HoTen, GioiTinh, NgaySinh, DiaChi FROM SINH_VIEN WHERE MaLop = @MaLop";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaLop", maLop);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SinhVien sv = new SinhVien();
                            sv.MaSV = reader["MaSV"].ToString();
                            sv.HoTen = reader["HoTen"].ToString();
                            sv.GioiTinh = reader["GioiTinh"].ToString();
                            sv.NgaySinh = reader["NgaySinh"].ToString();
                            sv.DiaChi = reader["DiaChi"].ToString();
                            // Đọc các thông tin khác của sinh viên nếu cần
                            danhSachSinhVien.Add(sv);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            return danhSachSinhVien;
        }

        
        

        private void btn_export_Click(object sender, EventArgs e)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            // Tạo file Excel mới
            using (ExcelPackage excel = new ExcelPackage())
            {
                // Tạo worksheet
                ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Danh sách Lớp");

                // Thêm header
                ws.Cells[1, 1].Value = "Danh Sách Lớp: ";
                ws.Cells[1, 2].Value = maLop;
                ws.Cells[2, 1].Value = "MaSV";
                ws.Cells[2, 2].Value = "Họ tên";
                ws.Cells[2, 3].Value = "Giới tính";
                ws.Cells[2, 4].Value = "Ngày sinh";
                ws.Cells[2, 5].Value = "Địa chỉ";
                int rowIndex = 3;

                // Thêm dữ liệu
                if (maLop != null)
                {
                        // Lấy danh sách sinh viên thuộc lớp này
                        List<SinhVien> danhSachSinhVien = LayDanhSachSinhVien(maLop);
                        // Thêm dữ liệu sinh viên vào worksheet
                        foreach (SinhVien sv in danhSachSinhVien)
                        {
                            ws.Cells[rowIndex, 1].Value = sv.MaSV;
                            ws.Cells[rowIndex, 2].Value = sv.HoTen;
                            ws.Cells[rowIndex, 3].Value = sv.GioiTinh;
                            ws.Cells[rowIndex, 4].Value = sv.NgaySinh;
                            ws.Cells[rowIndex, 5].Value = sv.DiaChi;
                            rowIndex++;
                        }
                }
                // Lưu file Excel
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
        
        private void btn_del_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_lop.SelectedRows)
            {
                dgv_lop.Rows.Remove(row); // Xóa row trực tiếp từ DataGridView
            }
        }

        private void ExportList_Load(object sender, EventArgs e)
        {

        }
    }
}
