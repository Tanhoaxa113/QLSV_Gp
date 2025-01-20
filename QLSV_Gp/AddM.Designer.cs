namespace QLSV_Gp
{
    partial class AddM
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
            this.btn_save = new System.Windows.Forms.Button();
            this.cbb_khoa = new System.Windows.Forms.ComboBox();
            this.txt_maMon = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_giangVien = new System.Windows.Forms.ComboBox();
            this.txt_hocky = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(376, 344);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(102, 39);
            this.btn_save.TabIndex = 22;
            this.btn_save.Text = "Thêm";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cbb_khoa
            // 
            this.cbb_khoa.FormattingEnabled = true;
            this.cbb_khoa.Location = new System.Drawing.Point(125, 140);
            this.cbb_khoa.Name = "cbb_khoa";
            this.cbb_khoa.Size = new System.Drawing.Size(225, 29);
            this.cbb_khoa.TabIndex = 21;
            this.cbb_khoa.SelectedIndexChanged += new System.EventHandler(this.cbb_khoa_SelectedIndexChanged);
            // 
            // txt_maMon
            // 
            this.txt_maMon.Location = new System.Drawing.Point(125, 260);
            this.txt_maMon.Name = "txt_maMon";
            this.txt_maMon.Size = new System.Drawing.Size(225, 29);
            this.txt_maMon.TabIndex = 20;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(125, 200);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(225, 29);
            this.txt_name.TabIndex = 19;
            this.txt_name.TextChanged += new System.EventHandler(this.txt_name_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Học Kỳ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mã Môn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tên Môn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Mã Khoa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(166, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "THÊM MÔN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Giảng Viên:";
            // 
            // cbb_giangVien
            // 
            this.cbb_giangVien.FormattingEnabled = true;
            this.cbb_giangVien.Items.AddRange(new object[] {
            "Chưa Có Giảng Viên"});
            this.cbb_giangVien.Location = new System.Drawing.Point(125, 320);
            this.cbb_giangVien.Name = "cbb_giangVien";
            this.cbb_giangVien.Size = new System.Drawing.Size(225, 29);
            this.cbb_giangVien.TabIndex = 25;
            // 
            // txt_hocky
            // 
            this.txt_hocky.Location = new System.Drawing.Point(125, 80);
            this.txt_hocky.Name = "txt_hocky";
            this.txt_hocky.Size = new System.Drawing.Size(225, 29);
            this.txt_hocky.TabIndex = 26;
            // 
            // AddM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 394);
            this.Controls.Add(this.txt_hocky);
            this.Controls.Add(this.cbb_giangVien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cbb_khoa);
            this.Controls.Add(this.txt_maMon);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AddM";
            this.Text = "AddM";
            this.Load += new System.EventHandler(this.AddL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cbb_khoa;
        private System.Windows.Forms.TextBox txt_maMon;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb_giangVien;
        private System.Windows.Forms.TextBox txt_hocky;
    }
}