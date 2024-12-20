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
    public partial class QuanLyCuDanDaiDien : Form
    {

        private CuDanDaiDien_BLL _cuDanBLL = new CuDanDaiDien_BLL();
        public QuanLyCuDanDaiDien()
        {
            InitializeComponent();
            LoadDanhSachCuDan();
        }



        // Tải danh sách cư dân từ cơ sở dữ liệu lên DataGridView
        public void LoadDanhSachCuDan()
        {
            List<CuDanDaiDien_DTO> danhSachCuDan = _cuDanBLL.LoadDanhSachCuDan();
            dgv_CDDD.DataSource = danhSachCuDan;
        }

        // Xử lý khi nhấn nút "Thêm"
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemCuDanDaiDien themCuDanDaiDien = new ThemCuDanDaiDien();
            themCuDanDaiDien.ShowDialog();
            LoadDanhSachCuDan(); // Tải lại danh sách sau khi thêm
        }

        // Xử lý khi nhấn nút "Sửa"
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgv_CDDD.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ dòng đã chọn sử dụng CurrentRow
                string idCuDan = dgv_CDDD.CurrentRow.Cells["ID_CuDan"].Value?.ToString();
                string hoTen = dgv_CDDD.CurrentRow.Cells["HoTen"].Value?.ToString();
                DateTime ngaySinh = dgv_CDDD.CurrentRow.Cells["NgaySinh"].Value != null
                    ? Convert.ToDateTime(dgv_CDDD.CurrentRow.Cells["NgaySinh"].Value)
                    : DateTime.MinValue;
                string gioiTinh = dgv_CDDD.CurrentRow.Cells["GioiTinh"].Value?.ToString();
                string soDienThoai = dgv_CDDD.CurrentRow.Cells["SoDienThoai"].Value?.ToString();
                string email = dgv_CDDD.CurrentRow.Cells["Email"].Value?.ToString();
                string tinhTrang = dgv_CDDD.CurrentRow.Cells["TinhTrang"].Value?.ToString();

                // Kiểm tra dữ liệu
                if (string.IsNullOrEmpty(idCuDan) || string.IsNullOrEmpty(hoTen))
                {
                    MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng chỉnh sửa cư dân
                ChinhSuaCuDanDaiDien chinhSuaCuDanDaiDien = new ChinhSuaCuDanDaiDien
                {
                    ID_CuDan = idCuDan,
                    HoTen = hoTen,
                    NgaySinh = ngaySinh,
                    GioiTinh = gioiTinh,
                    SoDienThoai = soDienThoai,
                    Email = email,
                    TinhTrang = tinhTrang
                };

                // Mở form chỉnh sửa
                chinhSuaCuDanDaiDien.ShowDialog();

                // Sau khi sửa xong, tải lại danh sách cư dân
                LoadDanhSachCuDan();
            }
            else
            {
                // Nếu không có dòng nào được chọn
                MessageBox.Show("Vui lòng chọn một dòng trong bảng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xử lý khi nhấn nút "this.Hide()"
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv_CDDD.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn cư dân để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idCuDan = dgv_CDDD.SelectedRows[0].Cells["ID_CuDan"].Value?.ToString();

            if (string.IsNullOrEmpty(idCuDan))
            {
                MessageBox.Show("ID cư dân không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa cư dân này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _cuDanBLL.XoaCuDan(idCuDan);
                    MessageBox.Show("Xóa cư dân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachCuDan(); // Tải lại danh sách sau khi this.Hide()
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi this.Hide() cư dân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tinhTrang = cbb_TinhTrang.SelectedItem?.ToString();
            string tuKhoa = txt_keyword.Text;

            // Kiểm tra nếu không có từ khóa và không chọn tình trạng
            if (string.IsNullOrWhiteSpace(tuKhoa) && string.IsNullOrWhiteSpace(tinhTrang))
            {
                MessageBox.Show("Vui lòng nhập từ khóa hoặc chọn tình trạng để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<CuDanDaiDien_DTO> danhSachCuDan = new List<CuDanDaiDien_DTO>();

                // Tìm kiếm theo từ khóa và tình trạng
                if (!string.IsNullOrWhiteSpace(tuKhoa) && string.IsNullOrWhiteSpace(tinhTrang))
                {
                    // Tìm kiếm chỉ bằng từ khóa
                    danhSachCuDan = _cuDanBLL.TimKiemCuDanTheoTuKhoa(tuKhoa);
                }
                else if (string.IsNullOrWhiteSpace(tuKhoa) && !string.IsNullOrWhiteSpace(tinhTrang))
                {
                    // Tìm kiếm chỉ bằng tình trạng
                    danhSachCuDan = _cuDanBLL.TimKiemCuDanTheoTinhTrang(tinhTrang);
                }
                else
                {
                    // Tìm kiếm bằng cả từ khóa và tình trạng
                    danhSachCuDan = _cuDanBLL.TimKiemCuDan(tuKhoa, tinhTrang);
                }

                // Hiển thị kết quả tìm kiếm lên DataGridView
                dgv_CDDD.DataSource = danhSachCuDan;
                if (danhSachCuDan.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy cư dân nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadDanhSachCuDan();
            cbb_TinhTrang.SelectedIndex = -1;
            txt_keyword.Clear();
        }

        private void btn_CSCD_Click(object sender, EventArgs e)
        {
            ChamSocCuDan f = new ChamSocCuDan();
            this.Close();
            f.Show();
            
        }

        private void btn_QLTI_Click(object sender, EventArgs e)
        {
            QuanLyTienIch f = new QuanLyTienIch();
            this.Close();
            f.Show();
            
        }

        private void btn_QLDV_Click(object sender, EventArgs e)
        {
            QuanLyDichVu f = new QuanLyDichVu();
            this.Close();
            f.Show();
            
        }

        private void btn_QLCH_Click(object sender, EventArgs e)
        {
            QuanLyCanHo f = new QuanLyCanHo();
            this.Close();
            f.Show();
            
        }

        private void btn_QLTK_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan f = new QuanLyTaiKhoan();
            this.Close();
            f.Show();
            
        }

       

        private void btn_QLCP_Click(object sender, EventArgs e)
        {
            QuanLyKhoanPhi f = new QuanLyKhoanPhi();
            this.Close();
            f.Show();
            
        }

        private void btn_QLHD_Click(object sender, EventArgs e)
        {

        }

        private void btn_TB_Click(object sender, EventArgs e)
        {
            ThongBao f = new ThongBao();
            this.Close();
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
