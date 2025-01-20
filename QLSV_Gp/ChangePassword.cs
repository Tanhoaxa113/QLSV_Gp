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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLSV_Gp
{

    public partial class ChangePassword : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM;Initial Catalog=QLSV; Integrated security = True";
        string MaGV;
        public ChangePassword()
        {
            InitializeComponent();
        }
        public ChangePassword(string MaGV)
        {
            InitializeComponent();
            this.MaGV = MaGV;
        }
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            tb_old.UseSystemPasswordChar = true;
            tb_new.UseSystemPasswordChar = true;
            tb_confirm.UseSystemPasswordChar = true;
            pb_eyes.Image = Properties.Resources.EYE_Close;
            this.ActiveControl = bt_save;
            tb_old.Text = "Mật Khẩu cũ"; // Gán giá trị mặc định
            tb_old.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            tb_new.Text = "Mật khẩu mới"; // Gán giá trị mặc định
            tb_new.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            tb_confirm.Text = "Nhập lại mật khẩu mới"; // Gán giá trị mặc định
            tb_confirm.ForeColor = Color.Gray;
        }
        private void pb_eyes_Click(object sender, EventArgs e)
        {
            cb_password.Checked = !cb_password.Checked;
        }
        private void cb_password_CheckedChanged(object sender, EventArgs e)
        {

            if (cb_password.Checked)
            {
                tb_old.UseSystemPasswordChar = false;
                tb_new.UseSystemPasswordChar = false;
                tb_confirm.UseSystemPasswordChar = false;
                pb_eyes.Image = Properties.Resources.EYE_Open;// Hiện mật khẩu
            }
            else
            {
                tb_old.UseSystemPasswordChar = true;
                tb_new.UseSystemPasswordChar = true;
                tb_confirm.UseSystemPasswordChar = true;
                pb_eyes.Image = Properties.Resources.EYE_Close;// Ẩn mật khẩu
            }
        }
        private void tb_old_Enter(object sender, EventArgs e)
        {
            if (tb_old.Text == "Mật Khẩu cũ")
            {
                tb_old.Text = ""; // Xóa nội dung textbox
                tb_old.ForeColor = Color.Black; // Đổi màu chữ về đen
            }
        }
        private void tb_old_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_old.Text))
            {
                tb_old.Text = "Mật Khẩu cũ"; // Gán giá trị mặc định
                tb_old.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            }
        }
        private void tb_new_Enter(object sender, EventArgs e)
        {
            if (tb_new.Text == "Mật khẩu mới")
            {
                tb_new.Text = ""; // Xóa nội dung textbox
                tb_new.ForeColor = Color.Black; // Đổi màu chữ về đen
            }
        }
        private void tb_new_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_new.Text))
            {
                tb_new.Text = "Mật khẩu mới"; // Gán giá trị mặc định
                tb_new.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            }
        }
        private void tb_confirm_Enter(object sender, EventArgs e)
        {
            if (tb_confirm.Text == "Nhập lại mật khẩu mới")
            {
                tb_confirm.Text = ""; // Xóa nội dung textbox
                tb_confirm.ForeColor = Color.Black; // Đổi màu chữ về đen
            }
        }
        private void tb_confirm_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_confirm.Text))
            {
                tb_confirm.Text = "Nhập lại mật khẩu mới"; // Gán giá trị mặc định
                tb_confirm.ForeColor = Color.Gray; // Đổi màu chữ thành xám
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = tb_old.Text;
            string newPassword = tb_new.Text;
            string confirmNewPassword = tb_confirm.Text;

            // Kiểm tra mật khẩu mới và xác nhận mật khẩu mới có khớp nhau không
            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Kiểm tra mật khẩu cũ có đúng không
                    string queryCheck = "SELECT COUNT(*) FROM Users WHERE MaGV = @MaGV AND password = @oldPassword";
                    SqlCommand commandCheck = new SqlCommand(queryCheck, connection);
                    commandCheck.Parameters.AddWithValue("@MaGV", MaGV);
                    commandCheck.Parameters.AddWithValue("@oldPassword", oldPassword);
                    int count = (int)commandCheck.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng.");
                        return;
                    }

                    // Cập nhật mật khẩu mới
                    string queryUpdate = "UPDATE Users SET password = @newPassword WHERE MaGV = @MaGV";
                    SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection);
                    commandUpdate.Parameters.AddWithValue("@MaGV", MaGV);
                    commandUpdate.Parameters.AddWithValue("@newPassword", newPassword);
                    commandUpdate.ExecuteNonQuery();

                    MessageBox.Show("Đổi mật khẩu thành công.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }

}
