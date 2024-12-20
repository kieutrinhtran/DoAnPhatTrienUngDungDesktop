using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_desktop_2._0
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private readonly DangNhap_BLL userBLL = new DangNhap_BLL();



        // Bật tắt hiển thị mật khẩu
        private void btnHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            // Khi checkbox được chọn, hiển thị mật khẩu
            if (cb_HienThiMK.Checked)
            {
                txt_MatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                // Khi checkbox không được chọn, ẩn mật khẩu
                txt_MatKhau.UseSystemPasswordChar = true;
            }
        }

        // Nếu checkbox không được chọn, ẩn mật khẩu
        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (!cb_HienThiMK.Checked)
            {
                txt_MatKhau.UseSystemPasswordChar = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txt_TaiKhoan.Text.Trim();
            string MatKhau = txt_MatKhau.Text.Trim();

            // Kiểm tra đăng nhập thông qua BLL
            bool isValid = userBLL.ValidateLogin(TaiKhoan, MatKhau);

            if (isValid)
            {
                ManHinhChinh manHinhChinh = new ManHinhChinh();
                manHinhChinh.Show();
                this.Hide();
            }
            else
            {
                // Hiển thị thông báo lỗi với màu đỏ
                lbl_ThongBao.ForeColor = Color.Red;
                lbl_ThongBao.Text = "Thông tin đăng nhập chưa chính xác. \n Vui lòng nhập lại!";

                // Đặt lại nội dung TextBox về mặc định
                txt_TaiKhoan.Text = "Tài khoản";
                txt_MatKhau.Text = "Mật khẩu";
                txt_MatKhau.UseSystemPasswordChar = false; // Đảm bảo mật khẩu hiển thị như văn bản

                // Đưa con trỏ về TextBox tài khoản để người dùng nhập lại
                txt_TaiKhoan.Focus();
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu phím Enter được nhấn
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Ngăn chặn sự kiện KeyPress để không thêm ký tự Enter vào TextBox
                e.Handled = true;

                // Gọi sự kiện Click của nút đăng nhập
                btn_DangNhap.PerformClick();
            }
        }


        private void txt_Taikhoan_Enter(object sender, EventArgs e)
        {
            if (txt_TaiKhoan.Text == "Tài khoản")
            {
                txt_TaiKhoan.Text = null;
            }
        }

        private void txt_TaiKhoan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TaiKhoan.Text))
            {
                txt_TaiKhoan.Text = "Tài khoản";
            }
        }

        private void txt_MatKhau_Enter(object sender, EventArgs e)
        {
            if (txt_MatKhau.Text == "Mật khẩu")
            {
                txt_MatKhau.Text = null;
            }
        }

        private void txt_MatKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MatKhau.Text))
            {
                txt_MatKhau.Text = "Mật khẩu";
            }
        }
    }
}
