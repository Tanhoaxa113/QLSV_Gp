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
            this.txt_find = new System.Windows.Forms.TextBox();
            this.dgv_mon = new System.Windows.Forms.DataGridView();
            this.btn_find = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mon)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_find
            // 
            this.txt_find.Location = new System.Drawing.Point(12, 12);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(203, 20);
            this.txt_find.TabIndex = 7;
            // 
            // dgv_mon
            // 
            this.dgv_mon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_mon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mon.Location = new System.Drawing.Point(12, 47);
            this.dgv_mon.Name = "dgv_mon";
            this.dgv_mon.Size = new System.Drawing.Size(244, 316);
            this.dgv_mon.TabIndex = 6;
            // 
            // btn_find
            // 
            this.btn_find.BackgroundImage = global::QLSV_Gp.Properties.Resources.find_icon;
            this.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_find.Location = new System.Drawing.Point(217, 12);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(39, 29);
            this.btn_find.TabIndex = 8;
            this.btn_find.UseVisualStyleBackColor = true;
            // 
            // ListM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 372);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.txt_find);
            this.Controls.Add(this.dgv_mon);
            this.Name = "ListM";
            this.Text = "ListM";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.DataGridView dgv_mon;
    }
}