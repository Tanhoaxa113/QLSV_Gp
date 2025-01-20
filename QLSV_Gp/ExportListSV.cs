using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace QLSV_Gp
{
    public partial class ExportListSV : Form
    {
        DataTable dt_SinhVien = new DataTable();

        // Trong ExportList.cs
        public ExportListSV()
        {
            InitializeComponent();
            dt_SinhVien.Columns.Add("MaSV", typeof(string));
            dt_SinhVien.Columns.Add("HoTen", typeof(string));
            dt_SinhVien.Columns.Add("GioiTinh", typeof(string));
            dt_SinhVien.Columns.Add("NgaySinh", typeof (string));
            dt_SinhVien.Columns.Add("DiaChi", typeof(string));
            dt_SinhVien.Columns.Add("MaLop", typeof(string));
            dgv_SV.DataSource = dt_SinhVien; // Gán DataTable cho DataGridView
        }

        public void ThemSinhVien(string MaSV, string hoTen, string ngaySinh, string gioiTinh, string diaChi, string maLop)
        {
            // Tạo DataRow từ DataTable dt_SinhVien
            DataRow row = dt_SinhVien.NewRow();
            row["MaSV"] = MaSV;
            row["HoTen"] = hoTen;
            row["NgaySinh"] = ngaySinh;
            row["GioiTinh"] = gioiTinh;
            row["DiaChi"] = diaChi;
            row["MaLop"] = maLop;

            dt_SinhVien.Rows.Add(row); // Thêm DataRow vào DataTable
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            // Tạo file Excel mới
            using (ExcelPackage excel = new ExcelPackage())
            {
                // Tạo worksheet
                ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Danh sách sinh viên ");

                // Thêm header
                for (int i = 0; i < dgv_SV.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1].Value = dgv_SV.Columns[i].HeaderText;
                }

                // Thêm dữ liệu
                for (int i = 0; i < dgv_SV.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_SV.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].Value = dgv_SV.Rows[i].Cells[j].Value;
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
            foreach (DataGridViewRow row in dgv_SV.SelectedRows)
            {
                dgv_SV.Rows.Remove(row); // Xóa row trực tiếp từ DataGridView
            }
        }

        private void ExportList_Load(object sender, EventArgs e)
        {

        }
    }
}
