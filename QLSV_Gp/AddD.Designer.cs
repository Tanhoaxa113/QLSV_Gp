namespace QLSV_Gp
{
    partial class AddD
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_listPoint = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_tenMon = new System.Windows.Forms.TextBox();
            this.cbb_maMon = new System.Windows.Forms.ComboBox();
            this.cbb_hocKi = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHẬP ĐIỂM SINH VIÊN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã Môn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên Môn:";
            // 
            // dgv_listPoint
            // 
            this.dgv_listPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listPoint.Location = new System.Drawing.Point(12, 202);
            this.dgv_listPoint.Name = "dgv_listPoint";
            this.dgv_listPoint.Size = new System.Drawing.Size(727, 362);
            this.dgv_listPoint.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Học Kì:";
            // 
            // txt_tenMon
            // 
            this.txt_tenMon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_tenMon.Enabled = false;
            this.txt_tenMon.Location = new System.Drawing.Point(436, 55);
            this.txt_tenMon.Name = "txt_tenMon";
            this.txt_tenMon.Size = new System.Drawing.Size(218, 22);
            this.txt_tenMon.TabIndex = 8;
            // 
            // cbb_maMon
            // 
            this.cbb_maMon.FormattingEnabled = true;
            this.cbb_maMon.Location = new System.Drawing.Point(101, 48);
            this.cbb_maMon.Name = "cbb_maMon";
            this.cbb_maMon.Size = new System.Drawing.Size(183, 29);
            this.cbb_maMon.TabIndex = 10;
            this.cbb_maMon.SelectedIndexChanged += new System.EventHandler(this.cbb_maMon_SelectedIndexChanged);
            // 
            // cbb_hocKi
            // 
            this.cbb_hocKi.FormattingEnabled = true;
            this.cbb_hocKi.Location = new System.Drawing.Point(101, 100);
            this.cbb_hocKi.Name = "cbb_hocKi";
            this.cbb_hocKi.Size = new System.Drawing.Size(183, 29);
            this.cbb_hocKi.TabIndex = 11;
            this.cbb_hocKi.SelectedIndexChanged += new System.EventHandler(this.cbb_hocKi_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "Sắp Xếp Theo Tên";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_sapXep_Click);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(425, 165);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(154, 31);
            this.btn_export.TabIndex = 13;
            this.btn_export.Text = "Xuất Danh Sách";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(585, 165);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(154, 31);
            this.btn_import.TabIndex = 14;
            this.btn_import.Text = "Nhập Danh Sách";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(653, 570);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 31);
            this.button4.TabIndex = 15;
            this.button4.Text = "Lưu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // AddD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 609);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbb_hocKi);
            this.Controls.Add(this.cbb_maMon);
            this.Controls.Add(this.txt_tenMon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_listPoint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "AddD";
            this.Text = "AddD";
            this.Load += new System.EventHandler(this.AddD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listPoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_listPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_tenMon;
        private System.Windows.Forms.ComboBox cbb_maMon;
        private System.Windows.Forms.ComboBox cbb_hocKi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button button4;
    }
}