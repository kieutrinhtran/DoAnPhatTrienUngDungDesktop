using BLL;
using DTO;
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
    public partial class PhanCong : Form
    {
        private ChamSocCuDan_BLL bllchamsoccudan = new ChamSocCuDan_BLL();
        private string idKhieuNai; // ID của khiếu nại cần phân công


        // Constructor mới nhận ID khiếu nại
        public PhanCong(string idKhieuNai)
        {
            InitializeComponent();
            this.idKhieuNai = idKhieuNai;
        }

        private void PhanCong_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách người tiếp nhận từ BLL
                List<KeyValuePair<string, string>> nguoiTiepNhanList = bllchamsoccudan.GetNguoiTiepNhanList();

                // Thiết lập nguồn dữ liệu cho ComboBox
                cbb_NguoiTiepNhan.DisplayMember = "Value";  // Hiển thị tên Ban Quản Lý
                cbb_NguoiTiepNhan.ValueMember = "Key";     // Lưu trữ ID_BanQuanLy

                // Gán dữ liệu vào ComboBox
                cbb_NguoiTiepNhan.DataSource = nguoiTiepNhanList;

                // Đặt lại trạng thái ComboBox sao cho không có giá trị mặc định được chọn
                cbb_NguoiTiepNhan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu không có người tiếp nhận được chọn
                if (cbb_NguoiTiepNhan.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn người tiếp nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy ID người tiếp nhận từ ComboBox
                string idNguoiTiepNhan = cbb_NguoiTiepNhan.SelectedValue.ToString();

                // Cập nhật người tiếp nhận và trạng thái khiếu nại trong BLL
                bool isUpdated = bllchamsoccudan.CapNhatNguoiTiepNhanVaTrangThai(idKhieuNai, idNguoiTiepNhan);
                if (isUpdated)
                {
                    MessageBox.Show("Phân công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();  // Đóng form phân công
                }
                else
                {
                    MessageBox.Show("Lỗi khi phân công, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnHuyPhanCong_Click(object sender, EventArgs e)
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
    }
}
