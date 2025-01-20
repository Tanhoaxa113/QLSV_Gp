using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_Gp
{
    public partial class AddM : Form
    {
        public AddM()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";

        private void AddL_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhoa();
            this.ActiveControl = btn_save;
            txt_maMon.Text = "";
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
        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                txt_maMon.Text = "";
                return;
            }

            string[] words = txt_name.Text.Split(' ');
            string maMon = "";
            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    maMon += word[0].ToString().ToUpper();
                }
            }
            txt_maMon.Text = maMon;
        }
        private void cbb_khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKhoa = cbb_khoa.SelectedValue.ToString();
            string maGVPattern = "";

            switch (selectedKhoa)
            {
                case "KTE":
                    maGVPattern = "1%";
                    break;
                case "OTO":
                    maGVPattern = "2%";
                    break;
                case "TIN":
                    maGVPattern = "3%";
                    break;
                default:
                    maGVPattern = "%";
                    break;
            }
            LoadDanhSachGiangVien(maGVPattern); 
        }

        private void LoadDanhSachGiangVien(string maGVPattern)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = $"SELECT MaGV, HoTen FROM GIANG_VIEN WHERE MaGV LIKE '{maGVPattern}'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    data.Columns.Add("MaGV_HoTen", typeof(string), "MaGV + ' - ' + HoTen");
                    DataRow nullRow = data.NewRow();
                    nullRow["MaGV"] = DBNull.Value;
                    nullRow["HoTen"] = "Chưa có giảng viên";
                    nullRow["MaGV_HoTen"] = "Chưa có giảng viên";
                    data.Rows.InsertAt(nullRow, 0); 
                    cbb_giangVien.DataSource = data;
                    // Hiển thị cột MaGV_HoTen
                    cbb_giangVien.DisplayMember = "MaGV_HoTen";
                    // Vẫn giữ ValueMember là MaGV
                    cbb_giangVien.ValueMember = "MaGV";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                foreach (DataRowView rowView in cbb_giangVien.Items)
                {
                    string maGV = rowView["MaGV"].ToString();
                    if (maGV == "admin")
                    {
                        rowView.Delete();
                        break;
                    }
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
                    string query = "INSERT INTO MON (MaMon,TenMon, MaGV, HocKi, MaKhoa) " +
                                   "VALUES (@MaMon, @TenMon, @MaGV, @HocKi, @MaKhoa)";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Lấy giá trị từ các controls
                    command.Parameters.AddWithValue("@MaMon", txt_maMon.Text);
                    command.Parameters.AddWithValue("@TenMon", txt_name.Text);
                    command.Parameters.AddWithValue("@HocKi", txt_hocky.Text);
                    command.Parameters.AddWithValue("@MaKhoa", cbb_khoa.SelectedValue);

                    // Kiểm tra xem đã chọn giảng viên chưa
                    if (cbb_giangVien.SelectedValue == DBNull.Value)
                    {
                        command.Parameters.AddWithValue("@MaGV", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@MaGV", cbb_giangVien.SelectedValue);
                    }

                    // Thực thi câu lệnh INSERT
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm môn học thành công!");
                        // Xử lý sau khi thêm thành công (ví dụ: reset các controls, đóng form,...)
                    }
                    else
                    {
                        MessageBox.Show("Thêm môn học thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
