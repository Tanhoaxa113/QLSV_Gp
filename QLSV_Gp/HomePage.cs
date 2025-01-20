using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace QLSV_Gp
{
    
    public partial class HomePage : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";

        public HomePage()
        { 
            InitializeComponent();
            tb_password.UseSystemPasswordChar = true;
            pb_eyes.Image = Properties.Resources.EYE_Close;
        }
        private void bt_login_Click(object sender, EventArgs e)
        {
            string MaGV = tb_user.Text;
            
            string password = tb_password.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE MaGV = @MaGV AND password = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaGV", MaGV);
                    command.Parameters.AddWithValue("@password", password);
                    int count = (int)command.ExecuteScalar();
                    if (count > 0 && MaGV == "admin")
                    {
                        // Nếu là admin, mở form admin
                        AdminForm adminForm = new AdminForm(MaGV);
                        adminForm.Show();
                        this.Hide(); // Ẩn form đăng nhập hiện tại
                    }
                    else
                    {
                        // Nếu không phải admin, kiểm tra đăng nhập thông thường
                        query = "SELECT COUNT(*) FROM Users WHERE MaGV = @MaGV COLLATE Latin1_General_CS_AS AND password = @password COLLATE Latin1_General_CS_AS";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MaGV", MaGV);
                        command.Parameters.AddWithValue("@password", password);
                        count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            // Nếu đăng nhập thành công, mở form user
                            UserForm userForm = new UserForm(MaGV);
                            userForm.Show();
                           
                            this.Hide(); // Ẩn form đăng nhập hiện tại
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://ctu.edu.vn/"); // Thay https://ctu.edu.vn/
        }
            
        private void cb_password_CheckedChanged(object sender, EventArgs e)
        {
            
            if (cb_password.Checked)
            {
                tb_password.UseSystemPasswordChar = false;
                pb_eyes.Image = Properties.Resources.EYE_Open;// Hiện mật khẩu
            }
            else
            {
                tb_password.UseSystemPasswordChar = true;
                pb_eyes.Image = Properties.Resources.EYE_Close;// Ẩn mật khẩu
            }
        }

        private void pb_eyes_Click(object sender, EventArgs e)
        {
            cb_password.Checked = !cb_password.Checked;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tb_del; // Focus vào tb_del (textbox ẩn giúp không bị tự động đặt con trỏ ở username)
            tb_user.Text = "Tên đăng nhập"; // Gán giá trị mặc định
            tb_user.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            tb_password.Text = "Mật khẩu"; // Gán giá trị mặc định
            tb_password.ForeColor = Color.Gray; // Đổi màu chữ thành xám
        }
        private void textBoxTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (tb_user.Text == "Tên đăng nhập")
            {
                tb_user.Text = ""; // Xóa nội dung textbox
                tb_user.ForeColor = Color.Black; // Đổi màu chữ về đen
            }
            

        }
        private void textBoxTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_user.Text))
            {
                tb_user.Text = "Tên đăng nhập"; // Gán giá trị mặc định
                tb_user.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            } 
        }

        private void tb_password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_password.Text))
            {
                tb_password.Text = "Mật khẩu"; // Gán giá trị mặc định
                tb_password.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            }
        }

        private void tb_password_Enter(object sender, EventArgs e)
        {
            if (tb_password.Text == "Mật khẩu")
            {
                tb_password.Text = ""; // Xóa nội dung textbox
                tb_password.ForeColor = Color.Black; // Đổi màu chữ về đen
            }
        } 
    }
}
