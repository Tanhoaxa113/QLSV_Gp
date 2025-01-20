namespace QLSV_Gp
{
    partial class InfoForm
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
            this.giangVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVDataSet = new QLSV_Gp.QLSVDataSet();
            this.giangVienTableAdapter = new QLSV_Gp.QLSVDataSetTableAdapters.GiangVienTableAdapter();
            this.pb_info = new System.Windows.Forms.PictureBox();
            this.adminFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lb_info = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.giangVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // giangVienBindingSource
            // 
            this.giangVienBindingSource.DataMember = "GiangVien";
            this.giangVienBindingSource.DataSource = this.qLSVDataSet;
            // 
            // qLSVDataSet
            // 
            this.qLSVDataSet.DataSetName = "QLSVDataSet";
            this.qLSVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // giangVienTableAdapter
            // 
            this.giangVienTableAdapter.ClearBeforeFill = true;
            // 
            // pb_info
            // 
            this.pb_info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_info.Location = new System.Drawing.Point(357, 12);
            this.pb_info.Name = "pb_info";
            this.pb_info.Size = new System.Drawing.Size(77, 92);
            this.pb_info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_info.TabIndex = 1;
            this.pb_info.TabStop = false;
            // 
            // adminFormBindingSource
            // 
            this.adminFormBindingSource.DataSource = typeof(QLSV_Gp.AdminForm);
            // 
            // lb_info
            // 
            this.lb_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_info.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_info.FormattingEnabled = true;
            this.lb_info.ItemHeight = 26;
            this.lb_info.Items.AddRange(new object[] {
            "THÔNG TIN GIẢNG VIÊN:"});
            this.lb_info.Location = new System.Drawing.Point(12, 12);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(339, 260);
            this.lb_info.TabIndex = 0;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(440, 278);
            this.Controls.Add(this.pb_info);
            this.Controls.Add(this.lb_info);
            this.Name = "InfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfoForm";
            this.Load += new System.EventHandler(this.InfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.giangVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminFormBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource adminFormBindingSource;
        private QLSVDataSet qLSVDataSet;
        private System.Windows.Forms.BindingSource giangVienBindingSource;
        private QLSVDataSetTableAdapters.GiangVienTableAdapter giangVienTableAdapter;
        private System.Windows.Forms.PictureBox pb_info;
        private System.Windows.Forms.ListBox lb_info;
    }
}