namespace QLSV_Gp
{
    partial class EditL
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
            this.txt_wel = new System.Windows.Forms.TextBox();
            this.btn_find = new System.Windows.Forms.Button();
            this.txt_find = new System.Windows.Forms.TextBox();
            this.dgv_lop = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lop)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(115, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN LỚP: ";
            // 
            // txt_wel
            // 
            this.txt_wel.BackColor = System.Drawing.SystemColors.Control;
            this.txt_wel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_wel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_wel.ForeColor = System.Drawing.Color.Red;
            this.txt_wel.Location = new System.Drawing.Point(347, 8);
            this.txt_wel.Name = "txt_wel";
            this.txt_wel.Size = new System.Drawing.Size(156, 32);
            this.txt_wel.TabIndex = 2;
            // 
            // btn_find
            // 
            this.btn_find.BackgroundImage = global::QLSV_Gp.Properties.Resources.find_icon;
            this.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_find.Location = new System.Drawing.Point(217, 43);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(39, 29);
            this.btn_find.TabIndex = 8;
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // txt_find
            // 
            this.txt_find.Location = new System.Drawing.Point(12, 43);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(203, 29);
            this.txt_find.TabIndex = 7;
            this.txt_find.Enter += new System.EventHandler(this.txt_find_Enter);
            this.txt_find.Leave += new System.EventHandler(this.txt_find_Leave);
            // 
            // dgv_lop
            // 
            this.dgv_lop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_lop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lop.Location = new System.Drawing.Point(12, 78);
            this.dgv_lop.Name = "dgv_lop";
            this.dgv_lop.Size = new System.Drawing.Size(594, 316);
            this.dgv_lop.TabIndex = 6;
            // 
            // EditL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 409);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.txt_find);
            this.Controls.Add(this.dgv_lop);
            this.Controls.Add(this.txt_wel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "EditL";
            this.Text = "EditL";
            this.Load += new System.EventHandler(this.EditL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_wel;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.DataGridView dgv_lop;
    }
}