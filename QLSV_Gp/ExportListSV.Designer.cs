namespace QLSV_Gp
{
    partial class ExportListSV
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
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.dgv_SV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SV)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_del
            // 
            this.btn_del.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del.Location = new System.Drawing.Point(570, 299);
            this.btn_del.Margin = new System.Windows.Forms.Padding(5);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(100, 40);
            this.btn_del.TabIndex = 1;
            this.btn_del.Text = "Xoá";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_export
            // 
            this.btn_export.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Location = new System.Drawing.Point(570, 349);
            this.btn_export.Margin = new System.Windows.Forms.Padding(5);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(100, 40);
            this.btn_export.TabIndex = 2;
            this.btn_export.Text = "Xuất DS";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // dgv_SV
            // 
            this.dgv_SV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SV.Location = new System.Drawing.Point(20, 20);
            this.dgv_SV.Margin = new System.Windows.Forms.Padding(5);
            this.dgv_SV.Name = "dgv_SV";
            this.dgv_SV.RowHeadersWidth = 50;
            this.dgv_SV.RowTemplate.Height = 24;
            this.dgv_SV.Size = new System.Drawing.Size(540, 370);
            this.dgv_SV.TabIndex = 3;
            // 
            // ExportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 403);
            this.Controls.Add(this.dgv_SV);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_del);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ExportList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ExportList";
            this.Load += new System.EventHandler(this.ExportList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.DataGridView dgv_SV;
    }
}