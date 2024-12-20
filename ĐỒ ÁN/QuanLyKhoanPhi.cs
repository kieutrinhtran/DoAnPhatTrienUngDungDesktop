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
    public partial class QuanLyKhoanPhi : Form
    {
        public QuanLyKhoanPhi()
        {
            InitializeComponent();
        }
        private KhoanPhi_BLL _khoanphiBLL = new KhoanPhi_BLL();

        private void QuanLyKhoanPhi_Load(object sender, EventArgs e)
        {
            LoadDataKhoanPhi();
        }

        private void LoadDataKhoanPhi()
        {
            try
            {
                List<KhoanPhi_DTO> dsKhoanPhi = _khoanphiBLL.LoadDataKhoanPhi();
                dgv_KhoanPhi.DataSource = dsKhoanPhi;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        
        
        

        

        
        private void btn_Them_Click(object sender, EventArgs e)
        {
            //Chuyển sang màn hình form thêm khoản phí
            ThemKhoanPhi f = new ThemKhoanPhi();
            f.ShowDialog();
            LoadDataKhoanPhi();
        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn
            if (dgv_KhoanPhi.SelectedRows.Count > 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow selectedRow = dgv_KhoanPhi.SelectedRows[0];
                string ID_KhoanPhi = selectedRow.Cells["ID_KhoanPhi"].Value.ToString();
                string TenKhoanPhi = selectedRow.Cells["TenKhoanPhi"].Value.ToString();
                decimal DonGia = decimal.Parse(selectedRow.Cells["DonGia"].Value.ToString());
                string ChuKy = selectedRow.Cells["ChuKy"].Value.ToString();
                string TrangThai = selectedRow.Cells["TrangThai"].Value.ToString();

                // Truyền dữ liệu sang form chỉnh sửa
                ChinhSuaKhoanPhi f = new ChinhSuaKhoanPhi(ID_KhoanPhi, TenKhoanPhi, DonGia, ChuKy, TrangThai);

                // Hiển thị form chỉnh sửa
                f.Show();

                // Tải lại dữ liệu sau khi chỉnh sửa
                f.FormClosed += (s, args) =>
                {
                    LoadDataKhoanPhi(); // Refresh lại DataGridView
                };
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Chuyển sang màn hình form chỉnh sửa khoản phí
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn
            if (dgv_KhoanPhi.SelectedRows.Count > 0)
            {
                // Lấy ID_KhoanPhi từ dòng được chọn
                DataGridViewRow selectedRow = dgv_KhoanPhi.SelectedRows[0];
                string IDKhoanPhi = selectedRow.Cells["ID_KhoanPhi"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa khoản phí này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Gọi BLL để xóa khoản phí
                        _khoanphiBLL.XoaKhoanPhi(IDKhoanPhi);

                        // Refresh lại DataGridView sau khi xóa
                        LoadDataKhoanPhi();

                        MessageBox.Show("Xóa khoản phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_TraCuu_Click(object sender, EventArgs e)
        {
            string keyword = txt_keyword.Text; // TextBox để nhập từ khóa
            string trangthai = cbb_TrangThai.Text;
            List<KhoanPhi_DTO> danhsach = new List<KhoanPhi_DTO>();
            try
            {
                // Kiểm tra nếu cả từ khóa và trạng thái đều trống
                if (string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(trangthai))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa hoặc chọn trạng thái để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
            {
               
                // Trường hợp chỉ tìm kiếm theo từ khóa
                if (!string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(trangthai))
                {
                    danhsach = KhoanPhi_BLL.SearchKhoanPhi(keyword);
                }
                // Trường hợp chỉ tìm kiếm theo trạng thái
                else if (string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(trangthai))
                {
                    danhsach = KhoanPhi_BLL.GetKhoanPhiByTrangThai(trangthai);
                }
                // Trường hợp kết hợp cả từ khóa và trạng thái
                else if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(trangthai))
                {
                    danhsach = KhoanPhi_BLL.GetKhoanPhi(keyword, trangthai);
                }
                dgv_KhoanPhi.DataSource = danhsach;

                if (danhsach.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khoản phí nào với từ khóa này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadDataKhoanPhi();
            cbb_TrangThai.SelectedIndex = -1;
            txt_keyword.Clear();
        }

        private void btn_CSCD_Click(object sender, EventArgs e)
        {
            ChamSocCuDan f = new ChamSocCuDan();
            f.Show();
            this.Hide();
        }

        private void btn_QLTI_Click(object sender, EventArgs e)
        {
            QuanLyTienIch f = new QuanLyTienIch();
            f.Show();
            this.Hide();
        }

        private void btn_QLDV_Click(object sender, EventArgs e)
        {
            QuanLyDichVu f = new QuanLyDichVu();
            f.Show();
            this.Hide();
        }

        private void btn_QLCH_Click(object sender, EventArgs e)
        {
            QuanLyCanHo f = new QuanLyCanHo();
            f.Show();
            this.Hide();
        }

        private void btn_QLTK_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan f = new QuanLyTaiKhoan();
            f.Show();
            this.Hide();
        }

        private void btn_QLCDDD_Click(object sender, EventArgs e)
        {
            QuanLyCuDanDaiDien f = new QuanLyCuDanDaiDien();
            f.Show();
            this.Hide();
        }

        

        private void btn_QLHD_Click(object sender, EventArgs e)
        {

        }

        private void btn_TB_Click(object sender, EventArgs e)
        {
            ThongBao f = new ThongBao();
            f.Show();
            this.Hide();
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
