namespace QLSV_Gp
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.lb_dhnamcantho = new System.Windows.Forms.Label();
            this.gb_login = new System.Windows.Forms.GroupBox();
            this.pb_eyes = new System.Windows.Forms.PictureBox();
            this.cb_password = new System.Windows.Forms.CheckBox();
            this.bt_login = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_user = new System.Windows.Forms.TextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.tb_del = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eyes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_dhnamcantho
            // 
            this.lb_dhnamcantho.AutoSize = true;
            this.lb_dhnamcantho.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dhnamcantho.ForeColor = System.Drawing.Color.Red;
            this.lb_dhnamcantho.Location = new System.Drawing.Point(180, 18);
            this.lb_dhnamcantho.Name = "lb_dhnamcantho";
            this.lb_dhnamcantho.Size = new System.Drawing.Size(515, 72);
            this.lb_dhnamcantho.TabIndex = 1;
            this.lb_dhnamcantho.Text = "TRƯỜNG ĐẠI HỌC NAM CẦN THƠ\r\nNAM CAN THO UNIVERSITY\r\n";
            this.lb_dhnamcantho.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lb_dhnamcantho.Click += new System.EventHandler(this.label1_Click);
            // 
            // gb_login
            // 
            this.gb_login.BackColor = System.Drawing.Color.AntiqueWhite;
            this.gb_login.Controls.Add(this.pb_eyes);
            this.gb_login.Controls.Add(this.cb_password);
            this.gb_login.Controls.Add(this.bt_login);
            this.gb_login.Controls.Add(this.tb_password);
            this.gb_login.Controls.Add(this.tb_user);
            this.gb_login.ForeColor = System.Drawing.Color.Red;
            this.gb_login.Location = new System.Drawing.Point(213, 206);
            this.gb_login.Name = "gb_login";
            this.gb_login.Size = new System.Drawing.Size(285, 180);
            this.gb_login.TabIndex = 3;
            this.gb_login.TabStop = false;
            this.gb_login.Text = "Đăng Nhập";
            // 
            // pb_eyes
            // 
            this.pb_eyes.BackColor = System.Drawing.Color.White;
            this.pb_eyes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_eyes.InitialImage = ((System.Drawing.Image)(resources.GetObject("pb_eyes.InitialImage")));
            this.pb_eyes.Location = new System.Drawing.Point(238, 88);
            this.pb_eyes.Name = "pb_eyes";
            this.pb_eyes.Size = new System.Drawing.Size(33, 29);
            this.pb_eyes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_eyes.TabIndex = 5;
            this.pb_eyes.TabStop = false;
            this.pb_eyes.Click += new System.EventHandler(this.pb_eyes_Click);
            // 
            // cb_password
            // 
            this.cb_password.AutoSize = true;
            this.cb_password.Checked = true;
            this.cb_password.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_password.Location = new System.Drawing.Point(256, 96);
            this.cb_password.Name = "cb_password";
            this.cb_password.Size = new System.Drawing.Size(15, 14);
            this.cb_password.TabIndex = 4;
            this.cb_password.UseVisualStyleBackColor = true;
            this.cb_password.CheckedChanged += new System.EventHandler(this.cb_password_CheckedChanged);
            // 
            // bt_login
            // 
            this.bt_login.BackColor = System.Drawing.Color.PaleTurquoise;
            this.bt_login.Location = new System.Drawing.Point(80, 129);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(130, 41);
            this.bt_login.TabIndex = 2;
            this.bt_login.Text = "Đăng Nhập";
            this.bt_login.UseVisualStyleBackColor = false;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // tb_password
            // 
            this.tb_password.AcceptsReturn = true;
            this.tb_password.AcceptsTab = true;
            this.tb_password.Location = new System.Drawing.Point(8, 88);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(224, 29);
            this.tb_password.TabIndex = 1;
            this.tb_password.Enter += new System.EventHandler(this.tb_password_Enter);
            this.tb_password.Leave += new System.EventHandler(this.tb_password_Leave);
            // 
            // tb_user
            // 
            this.tb_user.AcceptsReturn = true;
            this.tb_user.AcceptsTab = true;
            this.tb_user.Location = new System.Drawing.Point(6, 34);
            this.tb_user.Name = "tb_user";
            this.tb_user.Size = new System.Drawing.Size(273, 29);
            this.tb_user.TabIndex = 0;
            this.tb_user.Enter += new System.EventHandler(this.textBoxTenDangNhap_Enter);
            this.tb_user.Leave += new System.EventHandler(this.textBoxTenDangNhap_Leave);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.White;
            this.pbLogo.BackgroundImage = global::QLSV_Gp.Properties.Resources.LOGO_NCT;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo.InitialImage = global::QLSV_Gp.Properties.Resources.LOGO_NCT;
            this.pbLogo.Location = new System.Drawing.Point(13, 18);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(146, 87);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // tb_del
            // 
            this.tb_del.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tb_del.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_del.Enabled = false;
            this.tb_del.Location = new System.Drawing.Point(27, 49);
            this.tb_del.Name = "tb_del";
            this.tb_del.ShortcutsEnabled = false;
            this.tb_del.Size = new System.Drawing.Size(11, 22);
            this.tb_del.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(133, 516);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 57);
            this.label1.TabIndex = 5;
            this.label1.Text = "Trường Đại học Nam Cần Thơ (Nam Can Tho University)\r\n168, Nguyễn Văn Cừ (nối dài)" +
    ", P. An Bình, Q. Ninh Kiều, TP. Cần Thơ\r\nĐiện thoại: (0292) 3 798 222 - 3 798 66" +
    "8; Email: dnc@moet.edu.vn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HomePage
            // 
            this.AcceptButton = this.bt_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 582);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_del);
            this.Controls.Add(this.gb_login);
            this.Controls.Add(this.lb_dhnamcantho);
            this.Controls.Add(this.pbLogo);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.gb_login.ResumeLayout(false);
            this.gb_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eyes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lb_dhnamcantho;
        private System.Windows.Forms.GroupBox gb_login;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_user;
        private System.Windows.Forms.CheckBox cb_password;
        private System.Windows.Forms.PictureBox pb_eyes;
        private System.Windows.Forms.TextBox tb_del;
        private System.Windows.Forms.Label label1;
    }
}

