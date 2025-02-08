namespace QLSV_Gp
{
    partial class ListM
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
            this.dgv_mon = new System.Windows.Forms.DataGridView();
            this.mn_edit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mn_sua = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mn_xoa = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_find = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mon)).BeginInit();
            this.mn_edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_find
            // 
            this.txt_find.Location = new System.Drawing.Point(15, 50);
            this.txt_find.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(336, 29);
            this.txt_find.TabIndex = 7;
            this.txt_find.Enter += new System.EventHandler(this.txt_find_Enter);
            this.txt_find.Leave += new System.EventHandler(this.txt_find_Leave);
            // 
            // dgv_mon
            // 
            this.dgv_mon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_mon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mon.ContextMenuStrip = this.mn_edit;
            this.dgv_mon.Location = new System.Drawing.Point(20, 92);
            this.dgv_mon.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgv_mon.Name = "dgv_mon";
            this.dgv_mon.Size = new System.Drawing.Size(580, 494);
            this.dgv_mon.TabIndex = 6;
            this.dgv_mon.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_mon_CellMouseDown);
            // 
            // mn_edit
            // 
            this.mn_edit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mn_edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_sua,
            this.toolStripSeparator1,
            this.mn_xoa});
            this.mn_edit.Name = "mn_edit";
            this.mn_edit.Size = new System.Drawing.Size(112, 62);
            // 
            // mn_sua
            // 
            this.mn_sua.Name = "mn_sua";
            this.mn_sua.Size = new System.Drawing.Size(111, 26);
            this.mn_sua.Text = "Sửa";
            this.mn_sua.Click += new System.EventHandler(this.mn_sua_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // mn_xoa
            // 
            this.mn_xoa.Name = "mn_xoa";
            this.mn_xoa.Size = new System.Drawing.Size(111, 26);
            this.mn_xoa.Text = "Xoá";
            this.mn_xoa.Click += new System.EventHandler(this.mn_xoa_Click);
            // 
            // btn_find
            // 
            this.btn_find.BackgroundImage = global::QLSV_Gp.Properties.Resources.find_icon;
            this.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_find.Location = new System.Drawing.Point(361, 45);
            this.btn_find.Margin = new System.Windows.Forms.Padding(5);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(54, 37);
            this.btn_find.TabIndex = 8;
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "DANH SÁCH MÔN";
            // 
            // ListM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 601);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.txt_find);
            this.Controls.Add(this.dgv_mon);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ListM";
            this.Text = "ListM";
            this.Load += new System.EventHandler(this.ListM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mon)).EndInit();
            this.mn_edit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.DataGridView dgv_mon;
        private System.Windows.Forms.ContextMenuStrip mn_edit;
        private System.Windows.Forms.ToolStripMenuItem mn_sua;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mn_xoa;
        private System.Windows.Forms.Label label1;
    }
}