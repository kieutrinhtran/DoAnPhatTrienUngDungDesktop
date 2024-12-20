namespace Đồ_án_desktop_2._0
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cb_HienThiMK = new System.Windows.Forms.CheckBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lbl_ThongBao = new System.Windows.Forms.Label();
            this.btn_DangNhap = new Guna.UI2.WinForms.Guna2Button();
            this.txt_MatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_TaiKhoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(104, 23);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 100, 2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Padding = new System.Windows.Forms.Padding(5, 5, 100, 5);
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(279, 50);
            this.guna2HtmlLabel1.TabIndex = 5;
            this.guna2HtmlLabel1.Text = "ĐĂNG NHẬP";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_HienThiMK
            // 
            this.cb_HienThiMK.AutoSize = true;
            this.cb_HienThiMK.BackColor = System.Drawing.Color.Transparent;
            this.cb_HienThiMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_HienThiMK.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.cb_HienThiMK.Location = new System.Drawing.Point(184, 301);
            this.cb_HienThiMK.Margin = new System.Windows.Forms.Padding(2);
            this.cb_HienThiMK.Name = "cb_HienThiMK";
            this.cb_HienThiMK.Size = new System.Drawing.Size(159, 24);
            this.cb_HienThiMK.TabIndex = 9;
            this.cb_HienThiMK.Text = "Hiển thị mật khẩu";
            this.cb_HienThiMK.UseVisualStyleBackColor = false;
            this.cb_HienThiMK.CheckedChanged += new System.EventHandler(this.btnHienThiMatKhau_CheckedChanged);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.White;
            this.guna2GroupBox1.BorderRadius = 15;
            this.guna2GroupBox1.BorderThickness = 2;
            this.guna2GroupBox1.CausesValidation = false;
            this.guna2GroupBox1.Controls.Add(this.lbl_ThongBao);
            this.guna2GroupBox1.Controls.Add(this.btn_DangNhap);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GroupBox1.Controls.Add(this.txt_MatKhau);
            this.guna2GroupBox1.Controls.Add(this.txt_TaiKhoan);
            this.guna2GroupBox1.Controls.Add(this.cb_HienThiMK);
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Location = new System.Drawing.Point(442, 92);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(379, 426);
            this.guna2GroupBox1.TabIndex = 15;
            this.guna2GroupBox1.Text = "guna2GroupBox1";
            // 
            // lbl_ThongBao
            // 
            this.lbl_ThongBao.AutoSize = true;
            this.lbl_ThongBao.Location = new System.Drawing.Point(38, 74);
            this.lbl_ThongBao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ThongBao.Name = "lbl_ThongBao";
            this.lbl_ThongBao.Size = new System.Drawing.Size(119, 25);
            this.lbl_ThongBao.TabIndex = 13;
            this.lbl_ThongBao.Text = "lbl_ThongBao";
            this.lbl_ThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BorderRadius = 10;
            this.btn_DangNhap.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_DangNhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangNhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DangNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_DangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangNhap.ForeColor = System.Drawing.Color.White;
            this.btn_DangNhap.Location = new System.Drawing.Point(23, 346);
            this.btn_DangNhap.Margin = new System.Windows.Forms.Padding(2);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(329, 46);
            this.btn_DangNhap.TabIndex = 12;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.BorderRadius = 10;
            this.txt_MatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MatKhau.DefaultText = "Mật khẩu";
            this.txt_MatKhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MatKhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MatKhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MatKhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_MatKhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MatKhau.IconLeft = ((System.Drawing.Image)(resources.GetObject("txt_MatKhau.IconLeft")));
            this.txt_MatKhau.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txt_MatKhau.Location = new System.Drawing.Point(23, 221);
            this.txt_MatKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.PasswordChar = '\0';
            this.txt_MatKhau.PlaceholderText = "";
            this.txt_MatKhau.SelectedText = "";
            this.txt_MatKhau.Size = new System.Drawing.Size(329, 60);
            this.txt_MatKhau.TabIndex = 2;
            this.txt_MatKhau.TextOffset = new System.Drawing.Point(10, 0);
            this.txt_MatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            this.txt_MatKhau.Enter += new System.EventHandler(this.txt_MatKhau_Enter);
            this.txt_MatKhau.Leave += new System.EventHandler(this.txt_MatKhau_Leave);
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.txt_TaiKhoan.BorderRadius = 10;
            this.txt_TaiKhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TaiKhoan.DefaultText = "Tài khoản";
            this.txt_TaiKhoan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_TaiKhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_TaiKhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TaiKhoan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TaiKhoan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_TaiKhoan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TaiKhoan.IconLeft = ((System.Drawing.Image)(resources.GetObject("txt_TaiKhoan.IconLeft")));
            this.txt_TaiKhoan.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txt_TaiKhoan.Location = new System.Drawing.Point(23, 133);
            this.txt_TaiKhoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.PasswordChar = '\0';
            this.txt_TaiKhoan.PlaceholderText = "";
            this.txt_TaiKhoan.SelectedText = "";
            this.txt_TaiKhoan.Size = new System.Drawing.Size(329, 60);
            this.txt_TaiKhoan.TabIndex = 1;
            this.txt_TaiKhoan.TextOffset = new System.Drawing.Point(10, 0);
            this.txt_TaiKhoan.Enter += new System.EventHandler(this.txt_Taikhoan_Enter);
            this.txt_TaiKhoan.Leave += new System.EventHandler(this.txt_TaiKhoan_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(506, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 38);
            this.label2.TabIndex = 53;
            this.label2.Text = "QUẢN LÝ CHUNG CƯ";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.ErrorImage")));
            this.guna2PictureBox2.Image = global::ĐỒ_ÁN.Properties.Resources.logo;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(428, 19);
            this.guna2PictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(103, 70);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 54;
            this.guna2PictureBox2.TabStop = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btn_DangNhap;
            this.ClientSize = new System.Drawing.Size(1253, 576);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.guna2GroupBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý chung cư";
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txt_TaiKhoan;
        private Guna.UI2.WinForms.Guna2TextBox txt_MatKhau;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.CheckBox cb_HienThiMK;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2Button btn_DangNhap;
        private System.Windows.Forms.Label lbl_ThongBao;
    }
}

