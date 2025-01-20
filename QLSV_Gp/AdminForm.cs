using System;
using System.Windows.Forms;

namespace QLSV_Gp
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        string MaGV;
        public AdminForm(string MaGV) // Constructor nhận một tham số kiểu string
        {
            InitializeComponent();
            this.MaGV = MaGV;
        }

        private void bt_logout_Click(object sender, EventArgs e)
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

        private void mn_dsGiangVien_Click(object sender, EventArgs e)
        {
            ListGV listGV = new ListGV();// Truyền MaGV cho ListGV
            listGV.ShowDialog();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tb_del;
        }

        private void mn_addGV_Click(object sender, EventArgs e)
        {
            AddGV addGV = new AddGV();// Truyền MaGV cho ListGV
            addGV.ShowDialog();
        }

        private void mn_addSV_Click(object sender, EventArgs e)
        {
            AddSV addSV = new AddSV();
            addSV.ShowDialog();
        }

        private void mn_ListSV_Click(object sender, EventArgs e)
        {
            ListSV listSV = new ListSV();// Truyền MaGV cho ListGV
            listSV.ShowDialog();
        }

        private void mn_addL_Click(object sender, EventArgs e)
        {
            AddL addL = new AddL();// Truyền MaGV cho ListGV
            addL.ShowDialog();
        }

        private void mn_addM_Click_1(object sender, EventArgs e)
        {
            AddM addM = new AddM();// Truyền MaGV cho ListGV
            addM.ShowDialog();
        }

        private void mn_listL_Click(object sender, EventArgs e)
        {
            ListL listL = new ListL();// Truyền MaGV cho ListGV
            listL.ShowDialog();
        }

        private void mn_dsMon_Click(object sender, EventArgs e)
        {

        }
    }
}
