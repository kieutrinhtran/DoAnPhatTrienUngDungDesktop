using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using System.Data.SqlTypes;
using BLL;

namespace Đồ_án_desktop_2._0
{
    public partial class PhanHoi : Form
    {

        private string idKhieuNai;
        private ChamSocCuDan_BLL bllchamsoccudan = new ChamSocCuDan_BLL();

        public PhanHoi(string idKhieuNai)
        {
            InitializeComponent();
            this.idKhieuNai = idKhieuNai;
            txt_IDKhieuNai.Text = idKhieuNai;
            txt_IDPhanHoi.Text = "PH" + idKhieuNai.Substring(2);  // Tạo ID phản hồi tự động
        }

        // Hàm xử lý khi nhấn nút Phản hồi
        private void btnPhanHoi_Click_1(object sender, EventArgs e)
        {
            try
            {
                string noiDungPhanHoi = txt_NoiDungPhanHoi.Text.Trim();
                DateTime ngayGui = dtp_NgayGui.Value;

                if (string.IsNullOrEmpty(noiDungPhanHoi))
                {
                    MessageBox.Show("Vui lòng nhập nội dung phản hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi BLL để cập nhật phản hồi và thay đổi trạng thái khiếu nại
                bool isUpdated = bllchamsoccudan.CapNhatPhanHoiBLL(idKhieuNai, noiDungPhanHoi, ngayGui);

                if (isUpdated)
                {
                    MessageBox.Show("Phản hồi đã được gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();  // Đóng form
                }
                else
                {
                    MessageBox.Show("Lỗi khi gửi phản hồi, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyPhanHoi_Click(object sender, EventArgs e)
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
                MessageBox.Show("Tiếp tục thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtp_NgayGui_ValueChanged(object sender, EventArgs e)
        {
            // Lấy ngày hiện tại từ máy tính
            DateTime currentDate = DateTime.Today;

            // Kiểm tra nếu ngày được chọn trong DateTimePicker khác ngày hiện tại
            if (dtp_NgayGui.Value.Date != currentDate)
            {
                // Nếu không trùng, hiển thị thông báo và khôi phục lại ngày hiện tại
                MessageBox.Show("Ngày phản hồi phải trùng với ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_NgayGui.Value = currentDate; // Đặt lại giá trị của DateTimePicker
            }
        }
    }
}
