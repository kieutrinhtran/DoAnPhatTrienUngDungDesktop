using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_desktop_2._0
{
    public partial class ChinhSuaCuDanDaiDien : Form
    {
        // Các thuộc tính để nhận dữ liệu từ form chính
        public string ID_CuDan { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TinhTrang { get; set; }

        private CuDanDaiDien_BLL _cudanBLL = new CuDanDaiDien_BLL();
        public ChinhSuaCuDanDaiDien()
        {
            InitializeComponent();
        }





        private void ChinhSuaCuDanDaiDien_Load(object sender, EventArgs e)
        {
            // Điền dữ liệu vào các TextBox khi form sửa được mở
            txt_ID.Text = ID_CuDan;
            txt_ID.Enabled = false;
            txt_HoTen.Text = HoTen;
            dtp_NgaySinh.Text = NgaySinh.ToString("yyyy-MM-dd");  // Chuyển định dạng Ngày
            cbb_GioiTinh.Text = GioiTinh;
            txt_SDT.Text = SoDienThoai;
            txt_email.Text = Email;
            cbb_TT.Text = TinhTrang;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txt_HoTen.Text))
                {
                    MessageBox.Show("Họ tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_HoTen.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(dtp_NgaySinh.Text) || !DateTime.TryParse(dtp_NgaySinh.Text, out DateTime ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtp_NgaySinh.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cbb_GioiTinh.Text))
                {
                    MessageBox.Show("Giới tính không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbb_GioiTinh.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_SDT.Text) || !Regex.IsMatch(txt_SDT.Text, @"^\d{10,15}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập số từ 10 đến 15 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SDT.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_email.Text) || !Regex.IsMatch(txt_email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không hợp lệ. Vui lòng nhập đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_email.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cbb_TT.Text))
                {
                    MessageBox.Show("Tình trạng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbb_TT.Focus();
                    return;
                }

                // Tạo đối tượng CDDD_DTO
                var cuDan = new DTO.CuDanDaiDien_DTO
                {
                    ID_CuDan = ID_CuDan, // Giữ nguyên ID_CuDan khi chỉnh sửa
                    HoTen = txt_HoTen.Text,
                    NgaySinh = ngaySinh,
                    GioiTinh = cbb_GioiTinh.Text,
                    SoDienThoai = txt_SDT.Text,
                    Email = txt_email.Text,
                    TinhTrang = cbb_TT.Text
                };

                // Gọi BLL để thêm cư dân vào cơ sở dữ liệu
                _cudanBLL.SuaCuDan(cuDan);  // Kiểm tra kết quả trả về từ BLL

                MessageBox.Show("Cập nhật cư dân thành công!");
                this.Close();  // Đóng form sau khi cập nhật thành công
            }
            catch (Exception ex)
            {
                // Bắt lỗi và hiển thị thông báo
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy thao tác?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xử lý nếu người dùng chọn "Yes"
                this.Close();
            }
            else
            {
                // Xử lý nếu người dùng chọn "No"
                MessageBox.Show("Tiếp tục chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
