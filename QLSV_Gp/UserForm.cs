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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLSV_Gp
{
    public partial class UserForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM;Initial Catalog=QLSV; Integrated security = True";
  
        string MaGV;
        public UserForm()
        {
            InitializeComponent();
          
        }
        public UserForm(string MaGV) // Constructor nhận một tham số kiểu string
        {
            InitializeComponent();
            this.MaGV = MaGV;
            // Sử dụng message để hiển thị hoặc xử lý dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Câu truy vấn SQL để lấy họ tên từ bảng GIANG_VIEN
                    string query = "SELECT HoTen,Anh FROM GIANG_VIEN WHERE MaGV = @MaGV";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaGV", MaGV);
                    // Thực thi câu truy vấn và lấy kết quả
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hoTen = reader["HoTen"].ToString();
                            tb_welcome.Text = hoTen; // Hiển thị họ tên lên textbox
                            byte[] anhData = (byte[])reader["Anh"];
                            MemoryStream ms = new MemoryStream(anhData);
                            Image anh = Image.FromStream(ms);
                            pb_info.Image = anh;
                        }
                    }
                    string password_query = "SELECT password FROM Users WHERE MaGV = @MaGV";
                    SqlCommand password_command = new SqlCommand(password_query, connection);
                    password_command.Parameters.AddWithValue("@MaGV", MaGV);
                    using (SqlDataReader password_reader = password_command.ExecuteReader())
                    {
                        if (password_reader.Read())
                        {
                            string password = password_reader["password"].ToString();
                            if(password == "123456")
                            {
                                MessageBox.Show("Mật khẩu hiện tại là mật khẩu mặc định, vui lòng đổi lại mật khẩu sau khi đăng nhập!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            tb_welcome.ReadOnly = true; // Đặt textbox là read-only
        }
        private void HomePage_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tb_del;

        }

        private void mn_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Ẩn form hiện tại
                this.Hide();

                // Hiển thị form HomePage
                HomePage homePage = new HomePage();
                homePage.Show();
            }
        }

        private void mn_info_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm(MaGV);// Truyền MaGV cho InfoForm
            infoForm.ShowDialog();
        }

        private void mn_changeP_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(MaGV);// Truyền MaGV cho ChangePassword
            changePassword.ShowDialog();
        }
    }
}
