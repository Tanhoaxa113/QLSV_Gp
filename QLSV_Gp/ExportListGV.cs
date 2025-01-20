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
    public partial class ExportListGV : Form
    {
        DataTable dtGiangVien = new DataTable();
        public ExportListGV()
        {
            InitializeComponent();

            // Khởi tạo DataTable (chỉ một lần)
            dtGiangVien.Columns.Add("MaGV", typeof(string));
            dtGiangVien.Columns.Add("HoTen", typeof(string));
            dtGiangVien.Columns.Add("GioiTinh", typeof(string));
            dtGiangVien.Columns.Add("DienThoai", typeof(string));
            dtGiangVien.Columns.Add("Email", typeof(string));

            dgvGiangVien.DataSource = dtGiangVien; // Gán DataTable cho DataGridView
        }

        public void ThemGiangVien(string maGV, string hoTen, string gioiTinh, string dienThoai, string email)
        {
            // Tạo DataRow từ DataTable dtGiangVien
            DataRow row = dtGiangVien.NewRow();
            row["MaGV"] = maGV;
            row["HoTen"] = hoTen;
            row["GioiTinh"] = gioiTinh;
            row["DienThoai"] = dienThoai;
            row["Email"] = email;

            dtGiangVien.Rows.Add(row); // Thêm DataRow vào DataTable
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            // Tạo file Excel mới
            using (ExcelPackage excel = new ExcelPackage())
            {
                // Tạo worksheet
                ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Danh sách giảng viên");

                // Thêm header
                for (int i = 0; i < dgvGiangVien.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1].Value = dgvGiangVien.Columns[i].HeaderText;
                }

                // Thêm dữ liệu
                for (int i = 0; i < dgvGiangVien.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvGiangVien.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].Value = dgvGiangVien.Rows[i].Cells[j].Value;
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
            foreach (DataGridViewRow row in dgvGiangVien.SelectedRows)
            {
                dgvGiangVien.Rows.Remove(row); // Xóa row trực tiếp từ DataGridView
            }
        }

        private void ExportList_Load(object sender, EventArgs e)
        {

        }
    }
}
