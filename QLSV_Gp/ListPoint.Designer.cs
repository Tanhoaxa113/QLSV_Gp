namespace QLSV_Gp
{
    partial class ListPoint
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
            this.txt_maLop = new System.Windows.Forms.TextBox();
            this.txt_maMon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_listPoint = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_tenMon = new System.Windows.Forms.TextBox();
            this.btn_luu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_maLop
            // 
            this.txt_maLop.Location = new System.Drawing.Point(64, 56);
            this.txt_maLop.Name = "txt_maLop";
            this.txt_maLop.Size = new System.Drawing.Size(207, 29);
            this.txt_maLop.TabIndex = 0;
            // 
            // txt_maMon
            // 
            this.txt_maMon.Location = new System.Drawing.Point(371, 56);
            this.txt_maMon.Name = "txt_maMon";
            this.txt_maMon.Size = new System.Drawing.Size(60, 29);
            this.txt_maMon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "BẢNG ĐIỂM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lớp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã Môn:";
            // 
            // dgv_listPoint
            // 
            this.dgv_listPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listPoint.Location = new System.Drawing.Point(17, 101);
            this.dgv_listPoint.Name = "dgv_listPoint";
            this.dgv_listPoint.Size = new System.Drawing.Size(727, 511);
            this.dgv_listPoint.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 632);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Xuất Bảng Điểm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tên Môn:";
            // 
            // txt_tenMon
            // 
            this.txt_tenMon.Location = new System.Drawing.Point(544, 56);
            this.txt_tenMon.Name = "txt_tenMon";
            this.txt_tenMon.Size = new System.Drawing.Size(199, 29);
            this.txt_tenMon.TabIndex = 8;
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(668, 632);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(75, 32);
            this.btn_luu.TabIndex = 9;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // ListPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 676);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.txt_tenMon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_listPoint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_maMon);
            this.Controls.Add(this.txt_maLop);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ListPoint";
            this.Text = "ListPoint";
            this.Load += new System.EventHandler(this.ListPoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listPoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_maLop;
        private System.Windows.Forms.TextBox txt_maMon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_listPoint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_tenMon;
        private System.Windows.Forms.Button btn_luu;
    }
}