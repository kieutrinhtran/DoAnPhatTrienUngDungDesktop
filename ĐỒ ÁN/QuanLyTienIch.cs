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
    public partial class QuanLyTienIch : Form
    {
        public QuanLyTienIch()
        {
            InitializeComponent();
        }

        private TienIch_BLL _tienichBLL = new TienIch_BLL();
        

        private void QuanLyTienIch_Load(object sender, EventArgs e)
        {
            LoadDataTienIch();
        }

        private void LoadDataTienIch()
        {
            try
            {
                List<TienIch_DTO> dsTienIch = _tienichBLL.LoadDataTienIch();
                dgv_TienIch.DataSource = dsTienIch;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        

      
        // Phương thức để làm mới DataGridView sau khi cập nhật
        private void RefreshDataGridView()
        {
            LoadDataTienIch();
        }

        private void btn_CSCD_Click(object sender, EventArgs e)
        {
            ChamSocCuDan f = new ChamSocCuDan();
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

        private void btn_Them_Click(object sender, EventArgs e)
        {
            //Chuyển sang màn hình form thêm sản phẩm
            ThemTienIch f = new ThemTienIch();
            f.ShowDialog();
            LoadDataTienIch();
        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            if (dgv_TienIch.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                string ID_TienIch = dgv_TienIch.SelectedRows[0].Cells["ID_TienIch"].Value.ToString();
                string TenTienIch = dgv_TienIch.SelectedRows[0].Cells["TenTienIch"].Value.ToString();
                string GioMo = dgv_TienIch.SelectedRows[0].Cells["GioMo"].Value.ToString();
                string GioDong = dgv_TienIch.SelectedRows[0].Cells["GioDong"].Value.ToString();
                string MoTa = dgv_TienIch.SelectedRows[0].Cells["MoTa"].Value.ToString();
                string GiaTien = dgv_TienIch.SelectedRows[0].Cells["GiaTien"].Value.ToString();

                // Mở form chỉnh sửa và truyền dữ liệu
                ChinhSuaTienIch frm = new ChinhSuaTienIch(ID_TienIch, TenTienIch, GioMo, GioDong, MoTa, GiaTien);
                if (frm.ShowDialog() == DialogResult.OK)
                    // Hiển thị form chỉnh sửa
                    frm.ShowDialog();

                // Sau khi form chỉnh sửa đóng, làm mới lại dữ liệu trong DataGridView
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tiện ích để chỉnh sửa.");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa tiện ích này ?", "Xóa tiện ích", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string ID_TienIch = dgv_TienIch.CurrentRow.Cells["ID_TienIch"].Value.ToString();

                try
                {
                    _tienichBLL.XoaTienIch(ID_TienIch);
                    MessageBox.Show("Xóa tiện ích thành công");
                    LoadDataTienIch();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    } 
}
