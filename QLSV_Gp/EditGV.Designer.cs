namespace QLSV_Gp
{
    partial class EditGV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditGV));
            this.bt_browse = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.pb_info = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_MaGV = new System.Windows.Forms.TextBox();
            this.tb_MatKhau = new System.Windows.Forms.TextBox();
            this.tb_HoTen = new System.Windows.Forms.TextBox();
            this.tb_GioiTinh = new System.Windows.Forms.TextBox();
            this.tb_DienThoai = new System.Windows.Forms.TextBox();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_password = new System.Windows.Forms.CheckBox();
            this.pb_eyes = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eyes)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_browse
            // 
            this.bt_browse.Location = new System.Drawing.Point(482, 276);
            this.bt_browse.Name = "bt_browse";
            this.bt_browse.Size = new System.Drawing.Size(101, 40);
            this.bt_browse.TabIndex = 2;
            this.bt_browse.Text = "Đổi Ảnh";
            this.bt_browse.UseVisualStyleBackColor = true;
            this.bt_browse.Click += new System.EventHandler(this.bt_browse_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(482, 324);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(101, 40);
            this.bt_save.TabIndex = 3;
            this.bt_save.Text = "Lưu";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // pb_info
            // 
            this.pb_info.Location = new System.Drawing.Point(463, 45);
            this.pb_info.Name = "pb_info";
            this.pb_info.Size = new System.Drawing.Size(120, 160);
            this.pb_info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_info.TabIndex = 1;
            this.pb_info.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(139, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "THÔNG TIN GIẢNG VIÊN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 21);
            this.label5.TabIndex = 8;
            // 
            // tb_MaGV
            // 
            this.tb_MaGV.BackColor = System.Drawing.SystemColors.Control;
            this.tb_MaGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_MaGV.Enabled = false;
            this.tb_MaGV.Location = new System.Drawing.Point(147, 44);
            this.tb_MaGV.Name = "tb_MaGV";
            this.tb_MaGV.ReadOnly = true;
            this.tb_MaGV.Size = new System.Drawing.Size(270, 22);
            this.tb_MaGV.TabIndex = 9;
            // 
            // tb_MatKhau
            // 
            this.tb_MatKhau.Location = new System.Drawing.Point(147, 84);
            this.tb_MatKhau.Name = "tb_MatKhau";
            this.tb_MatKhau.Size = new System.Drawing.Size(228, 29);
            this.tb_MatKhau.TabIndex = 10;
            // 
            // tb_HoTen
            // 
            this.tb_HoTen.Location = new System.Drawing.Point(147, 137);
            this.tb_HoTen.Name = "tb_HoTen";
            this.tb_HoTen.Size = new System.Drawing.Size(270, 29);
            this.tb_HoTen.TabIndex = 11;
            // 
            // tb_GioiTinh
            // 
            this.tb_GioiTinh.Location = new System.Drawing.Point(147, 187);
            this.tb_GioiTinh.Name = "tb_GioiTinh";
            this.tb_GioiTinh.Size = new System.Drawing.Size(270, 29);
            this.tb_GioiTinh.TabIndex = 12;
            // 
            // tb_DienThoai
            // 
            this.tb_DienThoai.Location = new System.Drawing.Point(147, 237);
            this.tb_DienThoai.Name = "tb_DienThoai";
            this.tb_DienThoai.Size = new System.Drawing.Size(270, 29);
            this.tb_DienThoai.TabIndex = 13;
            // 
            // tb_Email
            // 
            this.tb_Email.Location = new System.Drawing.Point(147, 287);
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(270, 29);
            this.tb_Email.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Email: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "Điện Thoại: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "Giới Tính: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 18;
            this.label6.Text = "Họ Tên: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mật Khẩu:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 20;
            this.label8.Text = "Mã GV: ";
            // 
            // cb_password
            // 
            this.cb_password.AutoSize = true;
            this.cb_password.Checked = true;
            this.cb_password.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_password.Location = new System.Drawing.Point(402, 95);
            this.cb_password.Name = "cb_password";
            this.cb_password.Size = new System.Drawing.Size(15, 14);
            this.cb_password.TabIndex = 21;
            this.cb_password.UseVisualStyleBackColor = true;
            this.cb_password.CheckedChanged += new System.EventHandler(this.cb_password_CheckedChanged);
            // 
            // pb_eyes
            // 
            this.pb_eyes.BackColor = System.Drawing.Color.White;
            this.pb_eyes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_eyes.InitialImage = ((System.Drawing.Image)(resources.GetObject("pb_eyes.InitialImage")));
            this.pb_eyes.Location = new System.Drawing.Point(381, 84);
            this.pb_eyes.Name = "pb_eyes";
            this.pb_eyes.Size = new System.Drawing.Size(36, 29);
            this.pb_eyes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_eyes.TabIndex = 22;
            this.pb_eyes.TabStop = false;
            this.pb_eyes.Click += new System.EventHandler(this.pb_eyes_Click);
            // 
            // ChangeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 376);
            this.Controls.Add(this.pb_eyes);
            this.Controls.Add(this.cb_password);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Email);
            this.Controls.Add(this.tb_DienThoai);
            this.Controls.Add(this.tb_GioiTinh);
            this.Controls.Add(this.tb_HoTen);
            this.Controls.Add(this.tb_MatKhau);
            this.Controls.Add(this.tb_MaGV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_browse);
            this.Controls.Add(this.pb_info);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Red;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ChangeInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeInfo";
            this.Load += new System.EventHandler(this.ChangeInfo_Load);
            this.Click += new System.EventHandler(this.pb_eyes_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pb_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eyes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pb_info;
        private System.Windows.Forms.Button bt_browse;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_MaGV;
        private System.Windows.Forms.TextBox tb_MatKhau;
        private System.Windows.Forms.TextBox tb_HoTen;
        private System.Windows.Forms.TextBox tb_GioiTinh;
        private System.Windows.Forms.TextBox tb_DienThoai;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cb_password;
        private System.Windows.Forms.PictureBox pb_eyes;
    }
}