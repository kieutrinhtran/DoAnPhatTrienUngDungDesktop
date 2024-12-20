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
    public partial class ThongBao : Form
    {
        public ThongBao()
        {
            InitializeComponent();
        }

        private ThongBao_BLL _thongbaoBLL = new ThongBao_BLL();


        private void ThongBao_Load(object sender, EventArgs e)
        {
            LoadDataThongBao();

            //Người dùng chỉ thực hiện chỉnh sửa và xóa thông báo khi thông báo có trạng thái "Đã lên lịch gửi"
            dgv_ThongBao.SelectionChanged += dgvthongbao_SelectionChanged;
            btn_Xoa.Enabled = false;
            btn_ChinhSua.Enabled = false;
            
        }

        private void LoadDataThongBao()
        {
            try
            {
                List<DTO.ThongBao_DTO> DSThongBao = _thongbaoBLL.LoadDataThongBao();
                dgv_ThongBao.DataSource = DSThongBao;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        
        

        private void dgvthongbao_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng được chọn
            if (dgv_ThongBao.CurrentRow != null)
            {
                // Lấy giá trị trong cột "TrangThai" của dòng hiện tại
                string trangThai = dgv_ThongBao.CurrentRow.Cells["TrangThai"].Value?.ToString();

                // Kích hoạt hoặc vô hiệu hóa các nút dựa trên trạng thái
                if (trangThai == "Đã lên lịch gửi")
                {
                    btn_Xoa.Enabled = true; 
                    btn_ChinhSua.Enabled = true; 
                }
                else
                {
                    btn_Xoa.Enabled = false; 
                    btn_ChinhSua.Enabled = false; 
                }
            }
        }
        
        private void btn_Them_Click(object sender, EventArgs e)
        {
            //Chuyển sang màn hình form thêm sản phẩm
            TaoThongBao f = new TaoThongBao();
            f.ShowDialog();
            LoadDataThongBao();
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

        private void btn_QLCP_Click(object sender, EventArgs e)
        {
            QuanLyKhoanPhi f = new QuanLyKhoanPhi();
            f.Show();
            this.Hide();
        }

        private void btn_QLHD_Click(object sender, EventArgs e)
        {

        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            if (dgv_ThongBao.CurrentRow != null)
            {
                // Lấy thông tin từ dòng được chọn
                string idThongBao = dgv_ThongBao.CurrentRow.Cells["ID_ThongBao"].Value.ToString();
                string tieuDe = dgv_ThongBao.CurrentRow.Cells["TieuDe"].Value?.ToString();
                string noiDung = dgv_ThongBao.CurrentRow.Cells["NoiDung"].Value?.ToString();
                string nguoiGui = dgv_ThongBao.CurrentRow.Cells["NguoiGui"].Value?.ToString();
                DateTime ngayGui = DateTime.Parse(dgv_ThongBao.CurrentRow.Cells["NgayGui"].Value.ToString());

                // Mở form chỉnh sửa và truyền dữ liệu
                ChinhSuaThongBao editForm = new ChinhSuaThongBao(idThongBao, tieuDe, noiDung, nguoiGui, ngayGui);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDataThongBao(); // Tải lại dữ liệu sau khi chỉnh sửa
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thông báo để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa thông báo này ?", "Xóa thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string ID_ThongBao = dgv_ThongBao.CurrentRow.Cells["ID_ThongBao"].Value.ToString();

                try
                {
                    _thongbaoBLL.XoaThongBao(ID_ThongBao);
                    MessageBox.Show("Xóa thông báo thành công");
                    LoadDataThongBao();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btn_TraCuu_Click(object sender, EventArgs e)
        {
            string keyword = txt_keyword.Text; // TextBox để nhập từ khóa
            string ngaybd = dtp_BD.Value.ToString("yyyy-MM-dd");
            string ngaykt = dtp_KT.Value.ToString("yyyy-MM-dd"); // Lấy ngày kết thúc từ DateTimePicker khác

            List<ThongBao_DTO> danhsach = new List<DTO.ThongBao_DTO>();
            try
            {
                // Kiểm tra nếu cả từ khóa và trạng thái đều trống
                if (string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(ngaybd) && string.IsNullOrEmpty(ngaykt))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa hoặc chọn khoảng thời gian để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Trường hợp chỉ tìm kiếm theo từ khóa
                    if (!string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(ngaybd) && string.IsNullOrEmpty(ngaykt))
                    {
                        danhsach = ThongBao_BLL.SearchTB(keyword);
                    }
                    // Trường hợp chỉ tìm kiếm theo khoảng ngày
                    else if (string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(ngaybd) && !string.IsNullOrEmpty(ngaykt))
                    {
                        danhsach = ThongBao_BLL.GetTBByngay(ngaybd, ngaykt);
                    }
                    // Trường hợp kết hợp cả từ khóa và khoảng ngày
                    else if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(ngaybd) && !string.IsNullOrEmpty(ngaykt))
                    {
                        danhsach = ThongBao_BLL.GetTB(keyword, ngaybd, ngaykt);
                    }

                    dgv_ThongBao.DataSource = danhsach;

                    if (danhsach.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông báo nào với từ khóa hoặc khoảng thời gian này.");
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
            LoadDataThongBao();
            
            txt_keyword.Clear();
            
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

        private void dtp_KT_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
