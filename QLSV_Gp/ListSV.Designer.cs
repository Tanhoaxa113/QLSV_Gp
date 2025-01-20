namespace QLSV_Gp
{
    partial class ListSV
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
            this.txt_find = new System.Windows.Forms.TextBox();
            this.dg_dsSinhVien = new System.Windows.Forms.DataGridView();
            this.mn_strip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mn_change = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_del = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_find = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_dsSinhVien)).BeginInit();
            this.mn_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_find
            // 
            this.txt_find.Location = new System.Drawing.Point(24, 57);
            this.txt_find.Margin = new System.Windows.Forms.Padding(5);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(242, 29);
            this.txt_find.TabIndex = 5;
            this.txt_find.Enter += new System.EventHandler(this.txt_find_Enter);
            this.txt_find.Leave += new System.EventHandler(this.txt_find_Leave);
            // 
            // dg_dsSinhVien
            // 
            this.dg_dsSinhVien.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dg_dsSinhVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_dsSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_dsSinhVien.ContextMenuStrip = this.mn_strip;
            this.dg_dsSinhVien.Location = new System.Drawing.Point(24, 96);
            this.dg_dsSinhVien.Margin = new System.Windows.Forms.Padding(5);
            this.dg_dsSinhVien.Name = "dg_dsSinhVien";
            this.dg_dsSinhVien.RowHeadersWidth = 51;
            this.dg_dsSinhVien.RowTemplate.Height = 24;
            this.dg_dsSinhVien.Size = new System.Drawing.Size(657, 359);
            this.dg_dsSinhVien.TabIndex = 4;
            this.dg_dsSinhVien.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_dsSinhVien_CellDoubleClick);
            this.dg_dsSinhVien.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_dsSinhVien_CellMouseDown);
            // 
            // mn_strip
            // 
            this.mn_strip.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mn_strip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mn_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_change,
            this.mn_del});
            this.mn_strip.Name = "mn_strip";
            this.mn_strip.Size = new System.Drawing.Size(112, 56);
            // 
            // mn_change
            // 
            this.mn_change.Name = "mn_change";
            this.mn_change.Size = new System.Drawing.Size(111, 26);
            this.mn_change.Text = "Sửa";
            this.mn_change.Click += new System.EventHandler(this.mn_change_Click);
            // 
            // mn_del
            // 
            this.mn_del.Name = "mn_del";
            this.mn_del.Size = new System.Drawing.Size(111, 26);
            this.mn_del.Text = "Xoá";
            this.mn_del.Click += new System.EventHandler(this.mn_del_Click);
            // 
            // btn_find
            // 
            this.btn_find.BackgroundImage = global::QLSV_Gp.Properties.Resources.find_icon;
            this.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_find.Location = new System.Drawing.Point(276, 57);
            this.btn_find.Margin = new System.Windows.Forms.Padding(5);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(35, 29);
            this.btn_find.TabIndex = 6;
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(194, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "DANH SÁCH SINH VIÊN";
            // 
            // ListSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(699, 469);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.txt_find);
            this.Controls.Add(this.dg_dsSinhVien);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ListSV";
            this.Text = "ListSV";
            this.Load += new System.EventHandler(this.ListSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_dsSinhVien)).EndInit();
            this.mn_strip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.DataGridView dg_dsSinhVien;
        private System.Windows.Forms.ContextMenuStrip mn_strip;
        private System.Windows.Forms.ToolStripMenuItem mn_change;
        private System.Windows.Forms.ToolStripMenuItem mn_del;
        private System.Windows.Forms.Label label1;
    }
}