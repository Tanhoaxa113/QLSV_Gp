namespace QLSV_Gp
{
    partial class ListGV
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
            this.components = new System.ComponentModel.Container();
            this.dg_dsGiangVien = new System.Windows.Forms.DataGridView();
            this.mn_edit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mn_change = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mn_del = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_find = new System.Windows.Forms.TextBox();
            this.btn_find = new System.Windows.Forms.Button();
            this.pb_info = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_dsGiangVien)).BeginInit();
            this.mn_edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_dsGiangVien
            // 
            this.dg_dsGiangVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_dsGiangVien.ContextMenuStrip = this.mn_edit;
            this.dg_dsGiangVien.Location = new System.Drawing.Point(12, 83);
            this.dg_dsGiangVien.Name = "dg_dsGiangVien";
            this.dg_dsGiangVien.RowHeadersWidth = 51;
            this.dg_dsGiangVien.RowTemplate.Height = 24;
            this.dg_dsGiangVien.Size = new System.Drawing.Size(537, 414);
            this.dg_dsGiangVien.TabIndex = 0;
            this.dg_dsGiangVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_dsGiangVien_CellContentClick);
            this.dg_dsGiangVien.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_dsGiangVien_CellDoubleClick);
            this.dg_dsGiangVien.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_dsGiangVien_CellMouseDown);
            // 
            // mn_edit
            // 
            this.mn_edit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mn_edit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mn_edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_change,
            this.toolStripSeparator1,
            this.mn_del});
            this.mn_edit.Name = "mn_edit";
            this.mn_edit.Size = new System.Drawing.Size(112, 62);
            // 
            // mn_change
            // 
            this.mn_change.Name = "mn_change";
            this.mn_change.Size = new System.Drawing.Size(111, 26);
            this.mn_change.Text = "Sửa";
            this.mn_change.Click += new System.EventHandler(this.mn_change_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // mn_del
            // 
            this.mn_del.Name = "mn_del";
            this.mn_del.Size = new System.Drawing.Size(111, 26);
            this.mn_del.Text = "Xoá";
            this.mn_del.Click += new System.EventHandler(this.mn_del_Click);
            // 
            // txt_find
            // 
            this.txt_find.Location = new System.Drawing.Point(8, 43);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(215, 29);
            this.txt_find.TabIndex = 2;
            this.txt_find.Enter += new System.EventHandler(this.txt_find_Enter);
            this.txt_find.Leave += new System.EventHandler(this.txt_find_Leave);
            // 
            // btn_find
            // 
            this.btn_find.BackgroundImage = global::QLSV_Gp.Properties.Resources.find_icon;
            this.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_find.Location = new System.Drawing.Point(229, 43);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(42, 34);
            this.btn_find.TabIndex = 3;
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // pb_info
            // 
            this.pb_info.Location = new System.Drawing.Point(554, 43);
            this.pb_info.Name = "pb_info";
            this.pb_info.Size = new System.Drawing.Size(150, 200);
            this.pb_info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_info.TabIndex = 1;
            this.pb_info.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "DANH SÁCH GIẢNG VIÊN";
            // 
            // ListGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 513);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.txt_find);
            this.Controls.Add(this.pb_info);
            this.Controls.Add(this.dg_dsGiangVien);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ListGV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListGV";
            this.Load += new System.EventHandler(this.ListGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_dsGiangVien)).EndInit();
            this.mn_edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_info)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_dsGiangVien;
        private System.Windows.Forms.ContextMenuStrip mn_edit;
        private System.Windows.Forms.ToolStripMenuItem mn_change;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mn_del;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.PictureBox pb_info;
        private System.Windows.Forms.Label label1;
    }
}