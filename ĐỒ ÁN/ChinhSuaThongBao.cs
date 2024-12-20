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
    public partial class ChinhSuaThongBao : Form
    {
        private ThongBao_BLL _thongBaoBLL = new ThongBao_BLL();
        private string nguoigui;
        public ChinhSuaThongBao(string idThongBao, string tieuDe, string noiDung, string nguoiGui, DateTime ngayGui)
        {
            InitializeComponent();
            // Gán dữ liệu cho các control
            txt_ID.Text = idThongBao; // Gán ID thông báo
            txt_TieuDe.Text = tieuDe; // Gán tiêu đề
            txt_NoiDung.Text = noiDung; // Gán nội dung
            cbb_NguoiGui.SelectedValue = nguoiGui; // Chọn giá trị theo ID người gửi
            dtp_NgayGui.Value = ngayGui; // Gán ngày gửi
            nguoigui = nguoiGui;
            LoadNguoiGui();

        }
        private void LoadNguoiGui()
        {
            try
            {
                ThongBao_BLL thongbao = new ThongBao_BLL();
                Dictionary<string, string> nguoiGuiList = thongbao.LoadNguoiGuiList();

                cbb_NguoiGui.DataSource = new BindingSource(nguoiGuiList, null);
                cbb_NguoiGui.DisplayMember = "Value"; // Hiển thị tên người gửi
                cbb_NguoiGui.ValueMember = "Key";     // Lưu ID người gửi
                if (!string.IsNullOrEmpty(nguoigui))
                {
                    cbb_NguoiGui.Text = nguoigui;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người gửi: " + ex.Message);
            }
        }
        private void btnchinhsuatb_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ form chỉnh sửa và gán vào đối tượng ThongBaoDTO
                string ID_ThongBao = txt_ID.Text;
                string NguoiGui = cbb_NguoiGui.SelectedValue.ToString(); // Lấy ID người gửi từ ComboBox
                string TieuDe = txt_TieuDe.Text;
                string NoiDung = txt_NoiDung.Text;
                string NgayGui = dtp_NgayGui.Value.ToString("yyyy-MM-dd"); // Format ngày gửi

                // Gọi phương thức chỉnh sửa thông báo
                _thongBaoBLL.SuaThongBao(ID_ThongBao, NguoiGui, TieuDe, NoiDung, NgayGui);

                MessageBox.Show("Chỉnh sửa thông báo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trả kết quả về form chính và đóng form chỉnh sửa
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi khi có lỗi xảy ra
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
