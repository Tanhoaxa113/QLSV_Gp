namespace QLSV_Gp
{
    partial class EditM
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_maMon = new System.Windows.Forms.TextBox();
            this.txt_tenMon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.cbb_hocKi = new System.Windows.Forms.ComboBox();
            this.cbb_maKhoa = new System.Windows.Forms.ComboBox();
            this.cbb_maGV = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN MÔN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Môn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã GV:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên Môn:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mã Khoa:";
            // 
            // txt_maMon
            // 
            this.txt_maMon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_maMon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_maMon.Enabled = false;
            this.txt_maMon.Location = new System.Drawing.Point(109, 47);
            this.txt_maMon.Name = "txt_maMon";
            this.txt_maMon.Size = new System.Drawing.Size(172, 22);
            this.txt_maMon.TabIndex = 7;
            // 
            // txt_tenMon
            // 
            this.txt_tenMon.Location = new System.Drawing.Point(109, 97);
            this.txt_tenMon.Name = "txt_tenMon";
            this.txt_tenMon.Size = new System.Drawing.Size(217, 29);
            this.txt_tenMon.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "Học Kì:";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(409, 290);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 33);
            this.btn_save.TabIndex = 14;
            this.btn_save.Text = "Lưu";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cbb_hocKi
            // 
            this.cbb_hocKi.FormattingEnabled = true;
            this.cbb_hocKi.Location = new System.Drawing.Point(109, 197);
            this.cbb_hocKi.Name = "cbb_hocKi";
            this.cbb_hocKi.Size = new System.Drawing.Size(217, 29);
            this.cbb_hocKi.TabIndex = 15;
            // 
            // cbb_maKhoa
            // 
            this.cbb_maKhoa.FormattingEnabled = true;
            this.cbb_maKhoa.Location = new System.Drawing.Point(109, 247);
            this.cbb_maKhoa.Name = "cbb_maKhoa";
            this.cbb_maKhoa.Size = new System.Drawing.Size(217, 29);
            this.cbb_maKhoa.TabIndex = 16;
            // 
            // cbb_maGV
            // 
            this.cbb_maGV.FormattingEnabled = true;
            this.cbb_maGV.Location = new System.Drawing.Point(109, 147);
            this.cbb_maGV.Name = "cbb_maGV";
            this.cbb_maGV.Size = new System.Drawing.Size(217, 29);
            this.cbb_maGV.TabIndex = 17;
            // 
            // EditM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 335);
            this.Controls.Add(this.cbb_maGV);
            this.Controls.Add(this.cbb_maKhoa);
            this.Controls.Add(this.cbb_hocKi);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_tenMon);
            this.Controls.Add(this.txt_maMon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EditM";
            this.Text = "EditM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditM_FormClosed);
            this.Load += new System.EventHandler(this.EditM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_maMon;
        private System.Windows.Forms.TextBox txt_tenMon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cbb_hocKi;
        private System.Windows.Forms.ComboBox cbb_maKhoa;
        private System.Windows.Forms.ComboBox cbb_maGV;
    }
}