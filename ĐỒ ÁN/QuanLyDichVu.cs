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
    public partial class QuanLyDichVu : Form
    {
        public QuanLyDichVu()
        {
            InitializeComponent();
            LoadDataDichVu();
        }
        private DichVu_BLL _dichvuBLL = new DichVu_BLL();

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ThemDichVu f = new ThemDichVu();
            f.ShowDialog();
            LoadDataDichVu();

            
        }
        private void LoadDataDichVu()
        {
            try
            {
                List<DichVu_DTO> dsDichVu = _dichvuBLL.LoadDataDichVu();
                dgv_DichVu.DataSource = dsDichVu;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {


            if (dgv_DichVu.SelectedRows.Count > 0)
            {
              
                // Lấy dữ liệu từ dòng được chọn
                string ID_The = dgv_DichVu.SelectedRows[0].Cells["ID_The"].Value.ToString();
                string ID_CH = dgv_DichVu.SelectedRows[0].Cells["ID_CanHo"].Value.ToString();
                string TinhTrang = dgv_DichVu.SelectedRows[0].Cells["TinhTrang"].Value.ToString();
                string LoaiThe = dgv_DichVu.SelectedRows[0].Cells["LoaiThe"].Value.ToString();
                string LoaiXe = dgv_DichVu.SelectedRows[0].Cells["LoaiXe"].Value.ToString();
                string BienSoXe = dgv_DichVu.SelectedRows[0].Cells["BienSoXe"].Value.ToString();




                // Mở form chỉnh sửa và truyền dữ liệu
                ChinhSuaDichVu f = new ChinhSuaDichVu(ID_The, ID_CH, TinhTrang, LoaiThe, LoaiXe, BienSoXe);
                if (f.ShowDialog() == DialogResult.OK)
                    // Hiển thị form chỉnh sửa

                    f.ShowDialog();

                // Sau khi form chỉnh sửa đóng, làm mới lại dữ liệu trong DataGridView
                LoadDataDichVu();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thẻ để chỉnh sửa.");
            }
            
        }

        private void QuanLyDichVu_Load(object sender, EventArgs e)
        {
            LoadDataDichVu();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn
            if (dgv_DichVu.SelectedRows.Count > 0)
            {
                // Lấy ID_KhoanPhi từ dòng được chọn
                DataGridViewRow selectedRow = dgv_DichVu.SelectedRows[0];
                string ID_The = selectedRow.Cells["ID_The"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa dịch vụ thẻ này ?", "Xóa dịch vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    string ID_The1 = dgv_DichVu.CurrentRow.Cells["ID_The"].Value.ToString();

                    try
                    {
                        _dichvuBLL.XoaDichVu(ID_The);
                        MessageBox.Show("Xóa dịch vụ thành công");
                        LoadDataDichVu();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
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
            try
            {
                string keyword = txt_keyword.Text; // TextBox để nhập từ khóa
                string loaithe = cbb_LoaiThe.Text;
                // Kiểm tra nếu không có từ khóa và không chọn tình trạng
                if (string.IsNullOrWhiteSpace(keyword) && string.IsNullOrWhiteSpace(loaithe))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa hoặc chọn loại thẻ để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<DichVu_DTO> danhsach = new List<DichVu_DTO>();
                // Trường hợp chỉ tìm kiếm theo từ khóa
                if (!string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(loaithe))
                {
                    danhsach = DichVu_BLL.SearchThe(keyword);
                }
                // Trường hợp chỉ tìm kiếm theo trạng thái
                else if (string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(loaithe))
                {
                    danhsach = DichVu_BLL.GetTheByLoai(loaithe);
                }
                // Trường hợp kết hợp cả từ khóa và trạng thái
                else if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(loaithe))
                {
                    danhsach = DichVu_BLL.GetThe(keyword, loaithe);
                }
                dgv_DichVu.DataSource = danhsach;

                if (danhsach.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thẻ nào với từ khóa này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadDataDichVu();
            cbb_LoaiThe.SelectedIndex = -1;
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
