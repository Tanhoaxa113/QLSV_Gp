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
    
    public partial class EditGV : Form
    {
        
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";
        string filePath = "";
        string MaGV;

        public EditGV(string MaGV)
        {
            InitializeComponent();
            this.MaGV = MaGV;
        }

        private void ChangeInfo_Load(object sender, EventArgs e)
        {
            ShowInfo();
            this.ActiveControl = pb_info;
            tb_MatKhau.UseSystemPasswordChar = true;
            pb_eyes.Image = Properties.Resources.EYE_Close;
        }
        private void pb_eyes_Click(object sender, EventArgs e)
        {
            cb_password.Checked = !cb_password.Checked;
        }
        private void cb_password_CheckedChanged(object sender, EventArgs e)
        {

            if (cb_password.Checked)
            {
                tb_MatKhau.UseSystemPasswordChar = false;
                pb_eyes.Image = Properties.Resources.EYE_Open;// Hiện mật khẩu
            }
            else
            {
                tb_MatKhau.UseSystemPasswordChar = true;
                pb_eyes.Image = Properties.Resources.EYE_Close;// Ẩn mật khẩu
            }
        }
        private void ShowInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM GIANG_VIEN gv JOIN Users u ON gv.MaGV = u.MaGV WHERE gv.MaGV = @MaGV";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaGV", MaGV);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // ... (Hiển thị ảnh)
                            byte[] anhData = (byte[])reader["Anh"];
                            MemoryStream ms = new MemoryStream(anhData);
                            Image anh = Image.FromStream(ms);
                            pb_info.Image = anh;
                            // Hiển thị thông tin lên các Label và TextBox
                            tb_MaGV.Text =  reader["MaGV"].ToString();
                            tb_MatKhau.Text = reader["password"].ToString();
                            tb_HoTen.Text = reader["HoTen"].ToString();
                            tb_GioiTinh.Text = reader["GioiTinh"].ToString();
                            tb_DienThoai.Text = reader["DienThoai"].ToString();
                            tb_Email.Text = reader["Email"].ToString();

                            // ... (Hiển thị danh sách môn học )
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin giảng viên.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // Sự kiện Click của nút Lưu (bt_save)
        private void bt_save_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // ... (Cập nhật ảnh)
                    if (!string.IsNullOrEmpty(filePath)) // Kiểm tra xem có ảnh mới được chọn không
                    {
                        byte[] anhData;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pb_info.Image.Save(ms, pb_info.Image.RawFormat);
                            anhData = ms.ToArray();
                        }

                        string queryAnh = "UPDATE GIANG_VIEN SET Anh = @Anh WHERE MaGV = @MaGV";
                        SqlCommand commandAnh = new SqlCommand(queryAnh, connection);
                        commandAnh.Parameters.AddWithValue("@Anh", anhData);
                        commandAnh.Parameters.AddWithValue("@MaGV", MaGV);
                        commandAnh.ExecuteNonQuery();
                    }

                    // Cập nhật thông tin giảng viên
                    string queryInfo = @"UPDATE GIANG_VIEN 
                                SET HoTen = @HoTen, 
                                    GioiTinh = @GioiTinh, 
                                    DienThoai = @DienThoai, 
                                    Email = @Email 
                                WHERE MaGV = @MaGV";
                    SqlCommand commandInfo = new SqlCommand(queryInfo, connection);
                    commandInfo.Parameters.AddWithValue("@HoTen", tb_HoTen.Text); // Lấy giá trị từ TextBox
                    commandInfo.Parameters.AddWithValue("@GioiTinh", tb_GioiTinh.Text); // Lấy giá trị từ TextBox
                    commandInfo.Parameters.AddWithValue("@DienThoai", tb_DienThoai.Text); // Lấy giá trị từ TextBox
                    commandInfo.Parameters.AddWithValue("@Email", tb_Email.Text); // Lấy giá trị từ TextBox
                    commandInfo.Parameters.AddWithValue("@MaGV", MaGV);
                    commandInfo.ExecuteNonQuery();

                    // Cập nhật mật khẩu
                    string queryPassword = "UPDATE Users SET password = @newPassword WHERE MaGV = @MaGV";
                    SqlCommand commandPassword = new SqlCommand(queryPassword, connection);
                    commandPassword.Parameters.AddWithValue("@newPassword", tb_MatKhau.Text); // Lấy giá trị từ TextBox
                    commandPassword.Parameters.AddWithValue("@MaGV", MaGV);
                    commandPassword.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin thành công.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void bt_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Title = "Chọn ảnh giảng viên";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                pb_info.Image = Image.FromFile(filePath);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
