namespace QLSV_Gp
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.tb_old = new System.Windows.Forms.TextBox();
            this.tb_confirm = new System.Windows.Forms.TextBox();
            this.tb_new = new System.Windows.Forms.TextBox();
            this.bt_save = new System.Windows.Forms.Button();
            this.cb_password = new System.Windows.Forms.CheckBox();
            this.pb_eyes = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eyes)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_old
            // 
            this.tb_old.BackColor = System.Drawing.Color.SeaShell;
            this.tb_old.Location = new System.Drawing.Point(20, 20);
            this.tb_old.Margin = new System.Windows.Forms.Padding(5);
            this.tb_old.Name = "tb_old";
            this.tb_old.Size = new System.Drawing.Size(272, 34);
            this.tb_old.TabIndex = 0;
            this.tb_old.Enter += new System.EventHandler(this.tb_old_Enter);
            this.tb_old.Leave += new System.EventHandler(this.tb_old_Leave);
            // 
            // tb_confirm
            // 
            this.tb_confirm.BackColor = System.Drawing.Color.SeaShell;
            this.tb_confirm.Location = new System.Drawing.Point(20, 110);
            this.tb_confirm.Margin = new System.Windows.Forms.Padding(5);
            this.tb_confirm.Name = "tb_confirm";
            this.tb_confirm.Size = new System.Drawing.Size(321, 34);
            this.tb_confirm.TabIndex = 3;
            this.tb_confirm.Enter += new System.EventHandler(this.tb_confirm_Enter);
            this.tb_confirm.Leave += new System.EventHandler(this.tb_confirm_Leave);
            // 
            // tb_new
            // 
            this.tb_new.BackColor = System.Drawing.Color.SeaShell;
            this.tb_new.Location = new System.Drawing.Point(20, 66);
            this.tb_new.Margin = new System.Windows.Forms.Padding(5);
            this.tb_new.Name = "tb_new";
            this.tb_new.Size = new System.Drawing.Size(321, 34);
            this.tb_new.TabIndex = 2;
            this.tb_new.Enter += new System.EventHandler(this.tb_new_Enter);
            this.tb_new.Leave += new System.EventHandler(this.tb_new_Leave);
            // 
            // bt_save
            // 
            this.bt_save.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_save.ForeColor = System.Drawing.Color.Red;
            this.bt_save.Location = new System.Drawing.Point(169, 154);
            this.bt_save.Margin = new System.Windows.Forms.Padding(5);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(172, 37);
            this.bt_save.TabIndex = 4;
            this.bt_save.Text = "Lưu";
            this.bt_save.UseVisualStyleBackColor = false;
            this.bt_save.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // cb_password
            // 
            this.cb_password.AutoSize = true;
            this.cb_password.Checked = true;
            this.cb_password.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_password.Location = new System.Drawing.Point(310, 29);
            this.cb_password.Name = "cb_password";
            this.cb_password.Size = new System.Drawing.Size(18, 17);
            this.cb_password.TabIndex = 7;
            this.cb_password.UseVisualStyleBackColor = true;
            this.cb_password.CheckedChanged += new System.EventHandler(this.cb_password_CheckedChanged);
            // 
            // pb_eyes
            // 
            this.pb_eyes.BackColor = System.Drawing.Color.White;
            this.pb_eyes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_eyes.InitialImage = ((System.Drawing.Image)(resources.GetObject("pb_eyes.InitialImage")));
            this.pb_eyes.Location = new System.Drawing.Point(300, 22);
            this.pb_eyes.Name = "pb_eyes";
            this.pb_eyes.Size = new System.Drawing.Size(41, 32);
            this.pb_eyes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_eyes.TabIndex = 8;
            this.pb_eyes.TabStop = false;
            this.pb_eyes.Click += new System.EventHandler(this.pb_eyes_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 221);
            this.Controls.Add(this.pb_eyes);
            this.Controls.Add(this.cb_password);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.tb_new);
            this.Controls.Add(this.tb_confirm);
            this.Controls.Add(this.tb_old);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_eyes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_old;
        private System.Windows.Forms.TextBox tb_confirm;
        private System.Windows.Forms.TextBox tb_new;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.CheckBox cb_password;
        private System.Windows.Forms.PictureBox pb_eyes;
    }
}