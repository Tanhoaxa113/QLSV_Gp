namespace QLSV_Gp
{
    partial class ListL
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
            this.dgv_lop = new System.Windows.Forms.DataGridView();
            this.mn_edit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mn_view = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_find = new System.Windows.Forms.Button();
            this.txt_find = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lop)).BeginInit();
            this.mn_edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_lop
            // 
            this.dgv_lop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_lop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lop.ContextMenuStrip = this.mn_edit;
            this.dgv_lop.Location = new System.Drawing.Point(12, 47);
            this.dgv_lop.Name = "dgv_lop";
            this.dgv_lop.Size = new System.Drawing.Size(244, 316);
            this.dgv_lop.TabIndex = 0;
            this.dgv_lop.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_lop_CellDoubleClick);
            this.dgv_lop.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_lop_CellMouseDown);
            // 
            // mn_edit
            // 
            this.mn_edit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mn_edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_view,
            this.mn_delete});
            this.mn_edit.Name = "mn_edit";
            this.mn_edit.Size = new System.Drawing.Size(278, 78);
            // 
            // mn_view
            // 
            this.mn_view.Name = "mn_view";
            this.mn_view.Size = new System.Drawing.Size(277, 26);
            this.mn_view.Text = "Xem Danh Sách Sinh Viên";
            this.mn_view.Click += new System.EventHandler(this.mn_change_Click);
            // 
            // mn_delete
            // 
            this.mn_delete.Name = "mn_delete";
            this.mn_delete.Size = new System.Drawing.Size(277, 26);
            this.mn_delete.Text = "Xoá";
            this.mn_delete.Click += new System.EventHandler(this.mn_del_Click);
            // 
            // btn_find
            // 
            this.btn_find.BackgroundImage = global::QLSV_Gp.Properties.Resources.find_icon;
            this.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_find.Location = new System.Drawing.Point(217, 12);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(39, 29);
            this.btn_find.TabIndex = 5;
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // txt_find
            // 
            this.txt_find.Location = new System.Drawing.Point(12, 12);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(203, 29);
            this.txt_find.TabIndex = 4;
            this.txt_find.Enter += new System.EventHandler(this.txt_find_Enter);
            this.txt_find.Leave += new System.EventHandler(this.txt_find_Leave);
            // 
            // ListL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 372);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.txt_find);
            this.Controls.Add(this.dgv_lop);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ListL";
            this.Text = "ListL";
            this.Load += new System.EventHandler(this.ListL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lop)).EndInit();
            this.mn_edit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_lop;
        private System.Windows.Forms.ContextMenuStrip mn_edit;
        private System.Windows.Forms.ToolStripMenuItem mn_view;
        private System.Windows.Forms.ToolStripMenuItem mn_delete;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_find;
    }
}