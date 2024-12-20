
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
    public partial class TaoThongBao : Form
    {
        public TaoThongBao()
        {
            InitializeComponent();
            
        }

        private ThongBao_BLL _thongbaoBLL = new ThongBao_BLL();

        private string cdg;
        private void btnguithong_Click(object sender, EventArgs e)
        {
            try
            {
                cdg = cbb_CheDo.Text;
                // Tạo đối tượng DTO từ giao diện
                DTO.ThongBao_DTO thongbao = new DTO.ThongBao_DTO
                {
                    ID_ThongBao = txt_IDThongBao.Text,
                    NguoiGui = cbb_NguoiGui.SelectedValue?.ToString(),
                    TieuDe = txt_TieuDe.Text,
                    NoiDung = txt_NoiDung.Text,
                    NgayGui = dtp_LichGui.Value.ToString("yyyy-MM-dd"),
                    TrangThai = cbb_CheDo.SelectedItem?.ToString() == "Gửi ngay" ? "Đã gửi" : "Đã lên lịch gửi"
                };

                // Gửi xuống tầng BLL để xử lý
                _thongbaoBLL.ThemThongBao(thongbao, cdg);

                MessageBox.Show("Thêm dữ liệu thành công");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }



        private void LoadNguoiGui()
        {
            try
            {
                ThongBao_BLL thongbao = new ThongBao_BLL();
                Dictionary<string, string> nguoiGuiList = thongbao.LoadNguoiGuiList();

                cbb_NguoiGui.DataSource = new BindingSource(nguoiGuiList, null);
                cbb_NguoiGui.DisplayMember = "Value"; // Hiển thị giá trị (HoTen)
                cbb_NguoiGui.ValueMember = "Key";     // Giá trị ẩn (ID_BanQuanLy)
                cbb_NguoiGui.SelectedIndex = -1;      // Không chọn giá trị mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người gửi: " + ex.Message);
            }
        }



        private void TaoThongBao_Load(object sender, EventArgs e)
        {
            // Đảm bảo ComboBox được điền đầy đủ giá trị
            cbb_CheDo.Items.Add("Gửi ngay");
            cbb_CheDo.Items.Add("Gửi sau");

            // Đặt giá trị mặc định cho ComboBox
            cbb_CheDo.SelectedIndex = -1; // Không có lựa chọn mặc định
            LoadNguoiGui();
        }

        private void cbbchedogui_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_CheDo.SelectedItem != null)
            {
                string selectedMode = cbb_CheDo.SelectedItem.ToString(); 
                string idThongBao = txt_IDThongBao.Text;                   

                if (selectedMode == "Gửi ngay")
                {
                    dtp_LichGui.Value = DateTime.Now; 
                    dtp_LichGui.Enabled = false;     

                    // Cập nhật trạng thái "Đã gửi" vào cơ sở dữ liệu
                    CapNhatTrangThaiThongBao(idThongBao, "Đã gửi");
                }
                else if (selectedMode == "Gửi sau")
                {
                    dtp_LichGui.Enabled = true;      
                    CapNhatTrangThaiThongBao(idThongBao, "Đã lên lịch gửi");
                }
            }
        }

        private void CapNhatTrangThaiThongBao(string idThongBao, string trangThai)
        {
            try
            {
                ThongBao_BLL thongBaoBLL = new ThongBao_BLL();
                thongBaoBLL.CapNhatTrangThai(idThongBao, trangThai);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message, "Lỗi");
            }
        }

        private void btn_Huyr_Click(object sender, EventArgs e)
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

