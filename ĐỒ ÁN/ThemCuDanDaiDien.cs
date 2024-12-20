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
    public partial class ThemCuDanDaiDien : Form
    {
        private CuDanDaiDien_BLL _cudanBLL = new CuDanDaiDien_BLL();

        public ThemCuDanDaiDien()
        {
            InitializeComponent();
            _cudanBLL = new CuDanDaiDien_BLL();
            cbb_TT.Text = "Đang cư trú";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng CDDD_DTO
                var cuDan = new DTO.CuDanDaiDien_DTO
                {
                    ID_CuDan = txt_ID.Text,
                    HoTen = txt_HoTen.Text,
                    NgaySinh = dtp_NgaySinh.Value, // Lấy giá trị từ DateTimePicker
                    GioiTinh = cbb_GioiTinh.Text, // Lấy giá trị từ ComboBox
                    SoDienThoai = txt_SDT.Text,
                    Email = txt_email.Text,
                    TinhTrang = cbb_TT.Text // Lấy giá trị từ ComboBox
                };

                // Gọi BLL để thêm cư dân vào cơ sở dữ liệu
                _cudanBLL.ThemCuDan(cuDan);
                this.Close();

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm cư dân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
            }
            catch (ArgumentException argEx)
            {
                // Lỗi từ BLL khi dữ liệu không hợp lệ
                MessageBox.Show(argEx.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Lỗi hệ thống khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hỏi người dùng có chắc chắn muốn đóng form không
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn đóng form này?",
                                                 "Xác nhận đóng form",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        

       

        private void btn_ChinhSua_Click(object sender, EventArgs e)
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

        private void dtp_NgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
