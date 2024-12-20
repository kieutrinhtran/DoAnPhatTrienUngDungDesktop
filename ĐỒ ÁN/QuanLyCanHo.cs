using BLL;
using ĐỒ_ÁN;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Đồ_án_desktop_2._0
{
    public partial class QuanLyCanHo : Form
    {
        public QuanLyCanHo()
        {
            InitializeComponent();
        }

        
        private BLL.CanHo_BLL _CanHoBLL = new BLL.CanHo_BLL();
        
        private void btn_Them_Click(object sender, EventArgs e)
        {
            ThemCanHo f = new ThemCanHo();
            f.ShowDialog();
            LoadDataCanHo();
           
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (dgv_CanHo.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                string ID_CanHo = dgv_CanHo.SelectedRows[0].Cells["ID_CanHo"].Value.ToString();
                string So = dgv_CanHo.SelectedRows[0].Cells["SoCanHo"].Value.ToString();
                string Tang = dgv_CanHo.SelectedRows[0].Cells["Tang"].Value.ToString();
                string LoaiCanHo = dgv_CanHo.SelectedRows[0].Cells["LoaiCanHo"].Value.ToString();
                string DienTich = dgv_CanHo.SelectedRows[0].Cells["DienTich"].Value.ToString();
                string Gia = dgv_CanHo.SelectedRows[0].Cells["Gia"].Value.ToString();
                string TinhTrang = dgv_CanHo.SelectedRows[0].Cells["TinhTrang"].Value.ToString();


                // Mở form chỉnh sửa và truyền dữ liệu
                ChinhSuaCanHo f = new ChinhSuaCanHo(ID_CanHo, So, Tang, LoaiCanHo, DienTich, Gia, TinhTrang);
                if (f.ShowDialog() == DialogResult.OK)
                    // Hiển thị form chỉnh sửa
                    f.ShowDialog();

                // Sau khi form chỉnh sửa đóng, làm mới lại dữ liệu trong DataGridView
                LoadDataCanHo();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một căn hộ để chỉnh sửa.");
            }
        }

        private void QuanLyCanHo_Load(object sender, EventArgs e)
        {
            LoadDataCanHo();
            
        }
        private void LoadDataCanHo()
        {
            try
            {
                List<CanHo_DTO> dsCanHo = _CanHoBLL.LoadCanHo();
                dgv_CanHo.DataSource = dsCanHo;
                List<CanHo_DTO> dsCanHo1 = _CanHoBLL.LoadCanHo1();
                cbb_Loai.DataSource = dsCanHo1;
                cbb_Loai.DisplayMember = "LoaiCanHo";
                cbb_Loai.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        private void btn_TraCuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_keyword.Text; // TextBox để nhập từ khóa
                string loaicanho = cbb_Loai.Text;
                List<CanHo_DTO> danhsach = new List<CanHo_DTO>();
                try
                {
                    // Kiểm tra nếu cả từ khóa và trạng thái đều trống
                    if (string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(loaicanho))
                    {
                        MessageBox.Show("Vui lòng nhập từ khóa hoặc loại căn hộ để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Trường hợp chỉ tìm kiếm theo từ khóa
                    if (!string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(loaicanho))
                {
                    danhsach = CanHo_BLL.SearchCanHo(keyword);
                }
                // Trường hợp chỉ tìm kiếm theo trạng thái
                else if (string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(loaicanho))
                {
                    danhsach = CanHo_BLL.GetCanHoByLoai(loaicanho);
                }
                // Trường hợp kết hợp cả từ khóa và trạng thái
                else if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(loaicanho))
                {
                    danhsach = CanHo_BLL.GetCanHo(keyword, loaicanho);
                }
                dgv_CanHo.DataSource = danhsach;

                if (danhsach.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy căn hộ nào với từ khóa này.");
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

       

        private void btn_TB_Click(object sender, EventArgs e)
        {
            ThongBao f = new ThongBao();
            f.Show();
            this.Hide();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadDataCanHo();
            cbb_Loai.SelectedIndex = -1;
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

        private void QuanLyCanHo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_LichSu_Click(object sender, EventArgs e)
        {
            if (dgv_CanHo.SelectedRows.Count > 0)
            {
                string ID_CanHo = dgv_CanHo.SelectedRows[0].Cells["ID_CanHo"].Value.ToString();
                LichSuCanHo f = new LichSuCanHo(ID_CanHo);
                if (f.ShowDialog() == DialogResult.OK)
                    f.ShowDialog();
                
                LoadDataCanHo();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một căn hộ để xem lịch sử");
            }
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            if (dgv_CanHo.SelectedRows.Count > 0)
            {
                string ID_CanHo = dgv_CanHo.SelectedRows[0].Cells["ID_CanHo"].Value.ToString();
                ThongKe f = new ThongKe(ID_CanHo);
                if (f.ShowDialog() == DialogResult.OK)
                    f.ShowDialog();
                LoadDataCanHo();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một căn hộ để xem thống kê");
            }
        }
    }
}
