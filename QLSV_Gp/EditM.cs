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
    public partial class EditM : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";
        string maMon;
        public EditM(string MaMon)
        {
            InitializeComponent();
            this.maMon = MaMon;
        }
        private void EditM_Load(object sender, EventArgs e)
        {
            LoadThongTinMonHoc();
            LoadDanhSachGiangVien();
            LoadDanhSachKhoa();
            LoadDanhSachHocKi();
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
                            txt_maMon.Enabled = false;
                            txt_tenMon.Text = reader["TenMon"].ToString();


                            // Giảng viên
                            string maGV = reader["MaGV"].ToString();
                            cbb_maGV.SelectedValue = maGV;

                            // Học kỳ
                            cbb_hocKi.SelectedValue = reader["HocKi"].ToString();

                            // Khoa
                            string maKhoa = reader["MaKhoa"].ToString();
                            cbb_maKhoa.SelectedValue = maKhoa;
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

        private string LayHoTenGiangVien(string maGV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT HoTen FROM GIANG_VIEN WHERE MaGV = @maGV";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@maGV", maGV);
                    return command.ExecuteScalar()?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return "";
                }
            }
        }

        private string LayTenKhoa(string maKhoa)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TenKhoa FROM KHOA WHERE MaKhoa = @maKhoa";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@maKhoa", maKhoa);
                    return command.ExecuteScalar()?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return "";
                }
            }
        }

        private void LoadDanhSachGiangVien()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Thêm điều kiện MaGV <> 'admin' vào truy vấn SQL
                    string query = "SELECT MaGV, HoTen FROM GIANG_VIEN WHERE MaGV <> 'admin'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    data.Columns.Add("MaGV_HoTen", typeof(string), "MaGV + ' - ' + HoTen");

                    cbb_maGV.DataSource = data;
                    cbb_maGV.DisplayMember = "MaGV_HoTen";
                    cbb_maGV.ValueMember = "MaGV";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void LoadDanhSachKhoa()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaKhoa, TenKhoa FROM KHOA";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    data.Columns.Add("MaKhoa_TenKhoa", typeof(string), "MaKhoa + ' - ' + TenKhoa");

                    cbb_maKhoa.DataSource = data;
                    cbb_maKhoa.DisplayMember = "MaKhoa_TenKhoa";
                    cbb_maKhoa.ValueMember = "MaKhoa";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void LoadDanhSachHocKi()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DISTINCT HocKi FROM MON";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    cbb_hocKi.DataSource = data;
                    cbb_hocKi.DisplayMember = "HocKi";
                    cbb_hocKi.ValueMember = "HocKi";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE MON 
                                    SET TenMon = @TenMon, 
                                        MaGV = @MaGV, 
                                        HocKi = @HocKi, 
                                        MaKhoa = @MaKhoa 
                                    WHERE MaMon = @MaMon";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenMon", txt_tenMon.Text);
                    command.Parameters.AddWithValue("@MaGV", cbb_maGV.SelectedValue);
                    command.Parameters.AddWithValue("@HocKi", cbb_hocKi.SelectedValue);
                    command.Parameters.AddWithValue("@MaKhoa", cbb_maKhoa.SelectedValue);
                    command.Parameters.AddWithValue("@MaMon", maMon);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin môn học thành công.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin môn học thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void EditM_FormClosed(object sender, FormClosedEventArgs e)
        {
            ListM listM = new ListM();
            listM.Show();
        }
    }
}
