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
    public partial class EditSV : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";
        string maSV;

        public EditSV(string MaSV)
        {
            InitializeComponent();
            this.maSV = MaSV;
        }
        private void EditSV_Load(object sender, EventArgs e)
        {
            txt_maSV.Text = maSV;
            txt_maSV.Enabled = false;
            LoadThongTinSinhVien();
        }
        private void LoadThongTinSinhVien()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM SINH_VIEN WHERE MaSV = @maSV";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@maSV", maSV);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_hoTen.Text = reader["HoTen"].ToString();
                            txt_ngaySinh.Text = reader["NgaySinh"].ToString();
                            txt_diaChi.Text = reader["DiaChi"].ToString();
                            txt_lop.Text = reader["MaLop"].ToString();

                            if (reader["GioiTinh"].ToString() == "Nam")
                            {
                                cb_nam.Checked = true;
                                cb_nu.Checked = false;
                            }
                            else
                            {
                                cb_nam.Checked = false;
                                cb_nu.Checked = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin sinh viên.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE SINH_VIEN 
                                    SET HoTen = @HoTen, 
                                        NgaySinh = @NgaySinh, 
                                        GioiTinh = @GioiTinh, 
                                        DiaChi = @DiaChi,
                                        MaLop = @MaLop
                                    WHERE MaSV = @MaSV";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@HoTen", txt_hoTen.Text);
                    command.Parameters.AddWithValue("@NgaySinh", txt_ngaySinh.Text);
                    command.Parameters.AddWithValue("@GioiTinh", cb_nam.Checked ? "Nam" : "Nữ");
                    command.Parameters.AddWithValue("@DiaChi", txt_diaChi.Text);
                    command.Parameters.AddWithValue("@MaLop", txt_lop.Text);
                    command.Parameters.AddWithValue("@MaSV", maSV);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin sinh viên thành công.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin sinh viên thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void cb_nam_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_nam.Checked)
            {
                cb_nu.Checked = false;
            }
        }

        private void cb_nu_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_nu.Checked)
            {
                cb_nam.Checked = false;
            }
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Lấy ngày được chọn
            DateTime selectedDate = monthCalendar1.SelectionStart;

            // Hiển thị ngày đã định dạng
            txt_ngaySinh.Text = selectedDate.ToString();
        }
        private void btn_cal_Click(object sender, EventArgs e)
        {
            // Hiển thị MonthCalendar
            monthCalendar1.Visible = true;

            // Đưa MonthCalendar lên trên cùng
            monthCalendar1.BringToFront();

            // Thêm sự kiện DateSelected cho MonthCalendar
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Lấy ngày được chọn
            DateTime selectedDate = monthCalendar1.SelectionStart;

            // Hiển thị ngày đã định dạng
            txt_ngaySinh.Text = selectedDate.ToString();

            // Ẩn MonthCalendar
            monthCalendar1.Visible = false;

            // Gỡ bỏ sự kiện DateSelected
            monthCalendar1.DateSelected -= monthCalendar1_DateSelected;
        }


        private void EditSV_FormClosed(object sender, FormClosedEventArgs e)
        {
            ListSV listSV = new ListSV();
            listSV.Show();
        }
    }
}
