namespace Đồ_án_desktop_2._0
{
    partial class PhanCong
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
            this.btn_Huy = new Guna.UI2.WinForms.Guna2Button();
            this.btn_PhanCong = new Guna.UI2.WinForms.Guna2Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_NguoiTiepNhan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.SuspendLayout();
            // 
            // btn_Huy
            // 
            this.btn_Huy.BorderRadius = 10;
            this.btn_Huy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Huy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Huy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Huy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Huy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.ForeColor = System.Drawing.Color.White;
            this.btn_Huy.Location = new System.Drawing.Point(282, 194);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(167, 47);
            this.btn_Huy.TabIndex = 31;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.Click += new System.EventHandler(this.btnHuyPhanCong_Click);
            // 
            // btn_PhanCong
            // 
            this.btn_PhanCong.BorderRadius = 10;
            this.btn_PhanCong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_PhanCong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_PhanCong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_PhanCong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_PhanCong.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PhanCong.ForeColor = System.Drawing.Color.White;
            this.btn_PhanCong.Location = new System.Drawing.Point(98, 194);
            this.btn_PhanCong.Name = "btn_PhanCong";
            this.btn_PhanCong.Size = new System.Drawing.Size(167, 47);
            this.btn_PhanCong.TabIndex = 30;
            this.btn_PhanCong.Text = "Phân công";
            this.btn_PhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(165, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 26);
            this.label6.TabIndex = 32;
            this.label6.Text = "CHI TIẾT PHÂN CÔNG";
            // 
            // cbb_NguoiTiepNhan
            // 
            this.cbb_NguoiTiepNhan.BackColor = System.Drawing.Color.Transparent;
            this.cbb_NguoiTiepNhan.BorderRadius = 10;
            this.cbb_NguoiTiepNhan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_NguoiTiepNhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_NguoiTiepNhan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_NguoiTiepNhan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_NguoiTiepNhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_NguoiTiepNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_NguoiTiepNhan.ItemHeight = 30;
            this.cbb_NguoiTiepNhan.Location = new System.Drawing.Point(213, 101);
            this.cbb_NguoiTiepNhan.Name = "cbb_NguoiTiepNhan";
            this.cbb_NguoiTiepNhan.Size = new System.Drawing.Size(275, 36);
            this.cbb_NguoiTiepNhan.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(46, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "Người tiếp nhận:";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.CausesValidation = false;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.guna2GroupBox1.Enabled = false;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Location = new System.Drawing.Point(36, 71);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(470, 98);
            this.guna2GroupBox1.TabIndex = 35;
            this.guna2GroupBox1.Text = "guna2GroupBox1";
            // 
            // PhanCong
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(563, 280);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbb_NguoiTiepNhan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_PhanCong);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PhanCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhanCong";
            this.Load += new System.EventHandler(this.PhanCong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_Huy;
        private Guna.UI2.WinForms.Guna2Button btn_PhanCong;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_NguoiTiepNhan;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
    }
}