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
    public partial class InfoForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-09B6QVM\MSSQLSERVER2024;Initial Catalog=QLSV; Integrated security = True";

        string MaGV;
        public InfoForm()
        {
            InitializeComponent();
        }
        public InfoForm(string MaGV)
        {
            InitializeComponent();
            this.MaGV = MaGV;
        }
        private void InfoForm_Load(object sender, EventArgs e)
        {
            ShowInfo();
            this.ActiveControl = pb_info;
        }
        private void ShowInfo()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM GIANG_VIEN WHERE MaGV = @MaGV";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaGV", MaGV);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] anhData = (byte[])reader["Anh"];
                            MemoryStream ms = new MemoryStream(anhData);
                            Image anh = Image.FromStream(ms);
                            pb_info.Image = anh;
                            lb_info.Items.Add("Mã Giảng Viên: " + reader["MaGV"].ToString());
                            lb_info.Items.Add("Họ Tên: " + reader["HoTen"].ToString());
                            lb_info.Items.Add("Giới Tính: " + reader["GioiTinh"].ToString());
                            lb_info.Items.Add("Điện Thoại: " + reader["DienThoai"].ToString());
                            lb_info.Items.Add("Email: " + reader["Email"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin giảng viên.");
                        }
                    }
                    string queryMon = "SELECT TenMon FROM MON WHERE MaGV = @MaGV";
                    SqlCommand commandMon = new SqlCommand(queryMon, connection);
                    commandMon.Parameters.AddWithValue("@MaGV", MaGV);

                    using (SqlDataReader readerMon = commandMon.ExecuteReader())
                    {
                        lb_info.Items.Add("Danh sách môn giảng dạy:");
                        if (readerMon.HasRows)
                        {
                            while (readerMon.Read())
                            {
                                lb_info.Items.Add("- " + readerMon["TenMon"].ToString());
                            }
                        }
                        else
                        {
                            lb_info.Items.Add("- Không có môn học nào.");
                        }
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
