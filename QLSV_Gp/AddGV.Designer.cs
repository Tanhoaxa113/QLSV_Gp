namespace QLSV_Gp
{
    partial class AddGV
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
            this.dgv_addGV = new System.Windows.Forms.DataGridView();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            this.btn_find = new System.Windows.Forms.Button();
            this.txt_find = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_hoTen = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_nam = new System.Windows.Forms.CheckBox();
            this.cb_nu = new System.Windows.Forms.CheckBox();
            this.txt_dienThoai = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_maGV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_addGV
            // 
            this.dgv_addGV.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgv_addGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_addGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_addGV.Location = new System.Drawing.Point(10, 262);
            this.dgv_addGV.Margin = new System.Windows.Forms.Padding(5);
            this.dgv_addGV.Name = "dgv_addGV";
            this.dgv_addGV.RowHeadersWidth = 51;
            this.dgv_addGV.RowTemplate.Height = 24;
            this.dgv_addGV.Size = new System.Drawing.Size(667, 141);
            this.dgv_addGV.TabIndex = 0;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btn_save.ForeColor = System.Drawing.Color.Red;
            this.btn_save.Location = new System.Drawing.Point(567, 411);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(110, 40);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Lưu";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btn_delete.ForeColor = System.Drawing.Color.Red;
            this.btn_delete.Location = new System.Drawing.Point(450, 411);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(111, 40);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "Xoá";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btn_browse.ForeColor = System.Drawing.Color.Red;
            this.btn_browse.Location = new System.Drawing.Point(450, 210);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(110, 40);
            this.btn_browse.TabIndex = 3;
            this.btn_browse.Text = "Nhập File";
            this.btn_browse.UseVisualStyleBackColor = false;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // btn_find
            // 
            this.btn_find.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btn_find.BackgroundImage = global::QLSV_Gp.Properties.Resources.find_icon;
            this.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_find.Location = new System.Drawing.Point(233, 221);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(35, 29);
            this.btn_find.TabIndex = 5;
            this.btn_find.UseVisualStyleBackColor = false;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // txt_find
            // 
            this.txt_find.Location = new System.Drawing.Point(8, 221);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(215, 29);
            this.txt_find.TabIndex = 4;
            this.txt_find.Enter += new System.EventHandler(this.txt_find_Enter);
            this.txt_find.Leave += new System.EventHandler(this.txt_find_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(266, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "THÊM GIẢNG VIÊN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Họ Tên:";
            // 
            // txt_hoTen
            // 
            this.txt_hoTen.Location = new System.Drawing.Point(113, 117);
            this.txt_hoTen.Name = "txt_hoTen";
            this.txt_hoTen.Size = new System.Drawing.Size(207, 29);
            this.txt_hoTen.TabIndex = 8;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(427, 163);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(250, 29);
            this.txt_email.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(366, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "Giới Tính:";
            // 
            // cb_nam
            // 
            this.cb_nam.AutoSize = true;
            this.cb_nam.Location = new System.Drawing.Point(470, 69);
            this.cb_nam.Name = "cb_nam";
            this.cb_nam.Size = new System.Drawing.Size(64, 25);
            this.cb_nam.TabIndex = 17;
            this.cb_nam.Text = "Nam";
            this.cb_nam.UseVisualStyleBackColor = true;
            this.cb_nam.CheckedChanged += new System.EventHandler(this.cb_nam_CheckedChanged);
            // 
            // cb_nu
            // 
            this.cb_nu.AutoSize = true;
            this.cb_nu.Checked = true;
            this.cb_nu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_nu.Location = new System.Drawing.Point(569, 69);
            this.cb_nu.Name = "cb_nu";
            this.cb_nu.Size = new System.Drawing.Size(52, 25);
            this.cb_nu.TabIndex = 18;
            this.cb_nu.Text = "Nữ";
            this.cb_nu.UseVisualStyleBackColor = true;
            this.cb_nu.CheckedChanged += new System.EventHandler(this.cb_nu_CheckedChanged);
            // 
            // txt_dienThoai
            // 
            this.txt_dienThoai.Location = new System.Drawing.Point(113, 163);
            this.txt_dienThoai.Name = "txt_dienThoai";
            this.txt_dienThoai.Size = new System.Drawing.Size(207, 29);
            this.txt_dienThoai.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "Điện Thoại:";
            // 
            // txt_maGV
            // 
            this.txt_maGV.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_maGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_maGV.Enabled = false;
            this.txt_maGV.Location = new System.Drawing.Point(89, 65);
            this.txt_maGV.Name = "txt_maGV";
            this.txt_maGV.Size = new System.Drawing.Size(222, 22);
            this.txt_maGV.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Mã GV:";
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btn_add.ForeColor = System.Drawing.Color.Red;
            this.btn_add.Location = new System.Drawing.Point(567, 210);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(110, 40);
            this.btn_add.TabIndex = 23;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // AddGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(691, 463);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_maGV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_dienThoai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_nu);
            this.Controls.Add(this.cb_nam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_hoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.txt_find);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.dgv_addGV);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AddGV";
            this.Text = "AddList";
            this.Load += new System.EventHandler(this.AddGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_addGV;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_hoTen;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_nam;
        private System.Windows.Forms.CheckBox cb_nu;
        private System.Windows.Forms.TextBox txt_dienThoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_maGV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_add;
    }
}