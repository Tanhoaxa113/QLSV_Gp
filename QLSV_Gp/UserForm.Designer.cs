namespace QLSV_Gp
{
    partial class UserForm
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
            this.tb_del = new System.Windows.Forms.TextBox();
            this.lb_dhnamcantho = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.tb_welcome = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nm_account = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_info = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mn_changeP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mn_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_info = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_del
            // 
            this.tb_del.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tb_del.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_del.Enabled = false;
            this.tb_del.Location = new System.Drawing.Point(190, 54);
            this.tb_del.Name = "tb_del";
            this.tb_del.ShortcutsEnabled = false;
            this.tb_del.Size = new System.Drawing.Size(11, 27);
            this.tb_del.TabIndex = 7;
            // 
            // lb_dhnamcantho
            // 
            this.lb_dhnamcantho.AutoSize = true;
            this.lb_dhnamcantho.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dhnamcantho.ForeColor = System.Drawing.Color.Red;
            this.lb_dhnamcantho.Location = new System.Drawing.Point(478, 23);
            this.lb_dhnamcantho.Name = "lb_dhnamcantho";
            this.lb_dhnamcantho.Size = new System.Drawing.Size(650, 92);
            this.lb_dhnamcantho.TabIndex = 6;
            this.lb_dhnamcantho.Text = "TRƯỜNG ĐẠI HỌC NAM CẦN THƠ\r\nNAM CAN THO UNIVERSITY\r\n";
            this.lb_dhnamcantho.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImage = global::QLSV_Gp.Properties.Resources.LOGO_NCT;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo.InitialImage = global::QLSV_Gp.Properties.Resources.LOGO_NCT;
            this.pbLogo.Location = new System.Drawing.Point(176, 23);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(146, 87);
            this.pbLogo.TabIndex = 5;
            this.pbLogo.TabStop = false;
            // 
            // tb_welcome
            // 
            this.tb_welcome.BackColor = System.Drawing.Color.PeachPuff;
            this.tb_welcome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_welcome.Enabled = false;
            this.tb_welcome.ForeColor = System.Drawing.Color.Red;
            this.tb_welcome.Location = new System.Drawing.Point(111, 13);
            this.tb_welcome.Name = "tb_welcome";
            this.tb_welcome.Size = new System.Drawing.Size(181, 27);
            this.tb_welcome.TabIndex = 0;
            this.tb_welcome.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PeachPuff;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nm_account});
            this.menuStrip1.Location = new System.Drawing.Point(92, 43);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(137, 34);
            this.menuStrip1.TabIndex = 1;
            // 
            // nm_account
            // 
            this.nm_account.CheckOnClick = true;
            this.nm_account.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_info,
            this.toolStripSeparator1,
            this.mn_changeP,
            this.toolStripSeparator2,
            this.mn_logout});
            this.nm_account.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nm_account.ForeColor = System.Drawing.Color.OrangeRed;
            this.nm_account.Name = "nm_account";
            this.nm_account.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nm_account.Size = new System.Drawing.Size(124, 30);
            this.nm_account.Text = "Tài Khoản";
            // 
            // mn_info
            // 
            this.mn_info.BackColor = System.Drawing.Color.MistyRose;
            this.mn_info.ForeColor = System.Drawing.Color.Red;
            this.mn_info.Name = "mn_info";
            this.mn_info.Size = new System.Drawing.Size(283, 30);
            this.mn_info.Text = "Thông Tin Cá Nhân";
            this.mn_info.Click += new System.EventHandler(this.mn_info_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.MistyRose;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Salmon;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(280, 6);
            // 
            // mn_changeP
            // 
            this.mn_changeP.BackColor = System.Drawing.Color.MistyRose;
            this.mn_changeP.ForeColor = System.Drawing.Color.Red;
            this.mn_changeP.Name = "mn_changeP";
            this.mn_changeP.Size = new System.Drawing.Size(283, 30);
            this.mn_changeP.Text = "Đổi Mật Khẩu";
            this.mn_changeP.Click += new System.EventHandler(this.mn_changeP_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.MistyRose;
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.Salmon;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(280, 6);
            // 
            // mn_logout
            // 
            this.mn_logout.BackColor = System.Drawing.Color.MistyRose;
            this.mn_logout.ForeColor = System.Drawing.Color.Red;
            this.mn_logout.Name = "mn_logout";
            this.mn_logout.Size = new System.Drawing.Size(283, 30);
            this.mn_logout.Text = "Đăng Xuất";
            this.mn_logout.Click += new System.EventHandler(this.mn_logout_Click);
            // 
            // pb_info
            // 
            this.pb_info.Location = new System.Drawing.Point(219, 46);
            this.pb_info.Name = "pb_info";
            this.pb_info.Size = new System.Drawing.Size(60, 80);
            this.pb_info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_info.TabIndex = 2;
            this.pb_info.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox1.Controls.Add(this.pb_info);
            this.groupBox1.Controls.Add(this.tb_welcome);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox1.Location = new System.Drawing.Point(981, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 134);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xin Chào!";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PeachPuff;
            this.panel1.Location = new System.Drawing.Point(12, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 100);
            this.panel1.TabIndex = 3;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 731);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tb_del);
            this.Controls.Add(this.lb_dhnamcantho);
            this.Controls.Add(this.pbLogo);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.HomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_del;
        private System.Windows.Forms.Label lb_dhnamcantho;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.TextBox tb_welcome;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nm_account;
        private System.Windows.Forms.ToolStripMenuItem mn_info;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mn_changeP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mn_logout;
        private System.Windows.Forms.PictureBox pb_info;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
    }
}