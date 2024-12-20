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
    public partial class ChamSocCuDan : Form
    {
        public ChamSocCuDan()
        {
            InitializeComponent();
        }

        // Tạo đối tượng ở BLL để truyền dữ liệu 
        private ChamSocCuDan_BLL bllchamsoccudan = new ChamSocCuDan_BLL();

        private void ChamSocCuDan_Load(object sender, EventArgs e)
        {
            LoadDaTaChamSocCuDan();
        }

        private void LoadDaTaChamSocCuDan()
        {
            try
            {
                List<KhieuNai_DTO> dsKN = bllchamsoccudan.LoadKN();
                dgv_KhieuNai.DataSource = dsKN;

                // Hủy lựa chọn dòng mặc định
                dgv_KhieuNai.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            // Định dạng lại cột NgayGui
            dgv_KhieuNai.Columns["NgayGui"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_KhieuNai.Columns["ID_KhieuNai"].HeaderText = "ID Khiếu Nại";
            dgv_KhieuNai.Columns["NguoiGui"].HeaderText = "Người gửi";
            dgv_KhieuNai.Columns["NguoiTiepNhan"].HeaderText = "Người tiếp nhận";
            dgv_KhieuNai.Columns["NoiDung"].HeaderText = "Nội dung khiếu nại";
            dgv_KhieuNai.Columns["NgayGui"].HeaderText = "Ngày gửi khiếu nại";
            dgv_KhieuNai.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgv_KhieuNai.Columns["NoiDungPhanHoi"].HeaderText = "Nội dung phản hồi";
            dgv_KhieuNai.Columns["NgayGuiPhanHoi"].HeaderText = "Ngày gửi phản hồi";
        }

        private void btn_TraCuu_Click(object sender, EventArgs e)
        {
            string selectedTrangThai = cbb_LoaiKhieuNai.SelectedItem?.ToString();
            string keyword = txt_keyword.Text.Trim();

            // Kiểm tra nếu từ khóa và trạng thái đều trống
            if (string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(selectedTrangThai))
            {
                MessageBox.Show("Vui lòng nhập từ khóa hoặc chọn trạng thái để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tìm kiếm theo trạng thái và từ khóa
                List<KhieuNai_DTO> danhSach = bllchamsoccudan.SearchKNByTrangThaiAndNoiDungBLL(selectedTrangThai, keyword);

                // Hiển thị kết quả trong DataGridView
                dgv_KhieuNai.DataSource = danhSach;

                if (danhSach.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khiếu nại nào phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgv_KhieuNai.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khiếu nại trước khi phân công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi hàm nếu không có dòng nào được chọn
            }

            // Lấy ID khiếu nại của dòng đang chọn trong DataGridView
            string idKhieuNai = dgv_KhieuNai.SelectedRows[0].Cells["ID_KhieuNai"].Value.ToString();

            // Kiểm tra xem khiếu nại đã có người tiếp nhận chưa
            bool hasAssigned = bllchamsoccudan.CheckIfKhieuNaiHasAssigned(idKhieuNai);

            if (hasAssigned)
            {
                // Nếu đã có người tiếp nhận, thông báo và không mở form phân công
                MessageBox.Show("Khiếu nại này đã có người tiếp nhận, không thể phân công lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Nếu chưa có người tiếp nhận, mở form phân công
                PhanCong formPhanCong = new PhanCong(idKhieuNai);
                formPhanCong.ShowDialog(); // Hiển thị form phân công

                // Sau khi form phân công đóng, tải lại dữ liệu cho DataGridView
                LoadDaTaChamSocCuDan();
            }
        }

        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            if (dgv_KhieuNai.SelectedRows.Count > 0)
            {
                // Lấy ID khiếu nại của dòng đang chọn trong DataGridView
                string idKhieuNai = dgv_KhieuNai.SelectedRows[0].Cells["ID_KhieuNai"].Value.ToString();

                // Kiểm tra xem khiếu nại đã được phân công chưa
                bool hasAssigned = bllchamsoccudan.CheckIfKhieuNaiHasAssignedForReply(idKhieuNai);

                if (!hasAssigned)
                {
                    // Nếu chưa được phân công, thông báo và không cho phép phản hồi
                    MessageBox.Show("Khiếu nại này chưa được phân công, không thể thực hiện phản hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng hàm, không cho phép tiếp tục
                }

                // Kiểm tra xem khiếu nại đã có phản hồi hay chưa
                bool hasFeedback = bllchamsoccudan.CheckIfKhieuNaiHasFeedbackBLL(idKhieuNai);

                if (hasFeedback)
                {
                    MessageBox.Show("Khiếu nại này đã có phản hồi, không thể thực hiện phản hồi mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Nếu chưa có phản hồi, mở form PhanHoi và truyền ID khiếu nại
                    PhanHoi formPhanHoi = new PhanHoi(idKhieuNai);
                    formPhanHoi.ShowDialog(); // Hiển thị form phản hồi

                    // Sau khi form phản hồi đóng, tải lại dữ liệu cho DataGridView để cập nhật thông tin
                    LoadDaTaChamSocCuDan();
                }
            }
            else
            {
                // Thông báo nếu không có khiếu nại nào được chọn
                MessageBox.Show("Vui lòng chọn một khiếu nại để phản hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Đóng ứng dụng hoàn toàn, do form đăng nhập đã được ẩn đi nhưng vẫn chạy ngầm
        private void ChamSocCuDan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Tải lại trang chăm sóc cư dân, xóa nội dung tìm kiếm
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDaTaChamSocCuDan();
            cbb_LoaiKhieuNai.SelectedIndex = -1;
            txt_keyword.Clear();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadDaTaChamSocCuDan();
            cbb_LoaiKhieuNai.SelectedIndex = -1;
            txt_keyword.Clear();

        }

        private void btn_QLTI_Click(object sender, EventArgs e)
        {
            QuanLyTienIch f = new QuanLyTienIch();
            this.Hide();
            f.Show();
        }

        private void btn_QLDV_Click(object sender, EventArgs e)
        {
            QuanLyDichVu f = new QuanLyDichVu();
            this.Hide();

            f.Show();
        }

        private void btn_QLCH_Click(object sender, EventArgs e)
        {
            QuanLyCanHo f = new QuanLyCanHo();
            this.Hide();
            f.Show();
        }

        private void btn_QLTK_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan f = new QuanLyTaiKhoan();
            this.Hide();
            f.Show();
        }

        private void btn_QLCDDD_Click(object sender, EventArgs e)
        {
            QuanLyCuDanDaiDien f = new QuanLyCuDanDaiDien();
            this.Hide();
            f.Show();
        }

        private void btn_QLCP_Click(object sender, EventArgs e)
        {
            QuanLyKhoanPhi f = new QuanLyKhoanPhi();
            this.Hide();
            f.Show();
        }

        private void btn_QLHD_Click(object sender, EventArgs e)
        {

        }

        private void btn_TB_Click(object sender, EventArgs e)
        {
            ThongBao f = new ThongBao();
            this.Hide();
            f.Show();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DangNhap f = new DangNhap();
                this.Hide();
                f.Show();
            }
        }
    }
}
