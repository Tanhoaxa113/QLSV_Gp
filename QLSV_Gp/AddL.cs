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
    public partial class AddL : Form
    {
        public AddL()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-09B6QVM;Initial Catalog=QLSV; Integrated security = True";

        private void AddL_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhoa();
            this.ActiveControl = btn_save;
            txt_maLop.Text = "";
        }
        private void LoadDanhSachKhoa()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaKhoa FROM KHOA";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    cbb_khoa.DataSource = data;
                    cbb_khoa.DisplayMember = "MaKhoa";
                    cbb_khoa.ValueMember = "MaKhoa";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private string LaySoThuTuMaLop(string prefix)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TOP 1 MaLop FROM LOP WHERE MaLop LIKE @prefix + '%' ORDER BY MaLop DESC";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@prefix", prefix);
                    string lastMaLop = (string)command.ExecuteScalar();

                    int n = 1;
                    if (!string.IsNullOrEmpty(lastMaLop))
                    {
                        n = int.Parse(lastMaLop.Substring(prefix.Length)) + 1;
                    }

                    return n.ToString("D2"); // Định dạng số thứ tự với 2 chữ số
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return "01"; // Trả về giá trị mặc định nếu có lỗi
                }
            }
        }
        private void GanGiaTriMaLop()
        {
            if (cbb_khoa.SelectedValue == null)
            {
                txt_maLop.Text = ""; // Ví dụ gán giá trị mặc định
                return;
            }
            try
            {
                string namHoc = "";
                if (txt_year.Text.Length >= 2)
                {
                    namHoc = txt_year.Text.Substring(txt_year.Text.Length - 2);
                }
                else
                {
                    namHoc = "00";
                }
                string maKhoa = cbb_khoa.SelectedValue.ToString();
                string prefix = "DH" + namHoc + maKhoa;
                string n = LaySoThuTuMaLop(prefix);

                txt_maLop.Text = prefix + n;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            
                
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Kiểm tra xem MaLop đã tồn tại chưa
                    if (KiemTraMaLopTonTai(txt_maLop.Text))
                    {
                        MessageBox.Show("Mã lớp đã tồn tại!");
                        return;
                    }

                    string query = "INSERT INTO LOP (MaLop, MaKhoa) VALUES (@MaLop, @MaKhoa)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaLop", txt_maLop.Text);
                    command.Parameters.AddWithValue("@MaKhoa", cbb_khoa.SelectedValue.ToString());

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm lớp thành công!");
                        // Xóa các textbox sau khi thêm thành công
                        txt_maLop.Clear();
                        txt_year.Clear();
                        cbb_khoa.SelectedIndex = 0; // Hoặc bất kỳ giá trị mặc định nào khác
                    }
                    else
                    {
                        MessageBox.Show("Thêm lớp thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private bool KiemTraMaLopTonTai(string maLop)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM LOP WHERE MaLop = @MaLop";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaLop", maLop);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return false; // Trả về false nếu có lỗi
                }
            }
        }

        private void txt_year_TextChanged(object sender, EventArgs e)
        {
            // Gán lại giá trị cho txt_maLop khi txt_year thay đổi
            GanGiaTriMaLop();
            txt_class.Text = txt_maLop.Text;
        }

        private void cbb_khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gán lại giá trị cho txt_maLop khi cbb_khoa thay đổi
            GanGiaTriMaLop();
        }
    }
}
