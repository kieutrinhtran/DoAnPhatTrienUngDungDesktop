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
    public partial class QuanLyTaiKhoan : Form
    {
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ThemTaiKhoan f = new ThemTaiKhoan();
            f.ShowDialog();
            LoadDataTaiKhoan();
            
        }
        private TaiKhoan_BLL _taikhoanBLL = new TaiKhoan_BLL();

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDataTaiKhoan();
        }
        private void LoadDataTaiKhoan()
        {
            try
            {
                List<TaiKhoan_DTO> dsTaiKhoan = _taikhoanBLL.LoadTK();
                dgv_TaiKhoan.DataSource = dsTaiKhoan;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }


        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            if (dgv_TaiKhoan.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                string ID_TaiKhoan = dgv_TaiKhoan.SelectedRows[0].Cells["ID_TaiKhoan"].Value.ToString();
                string ID_CanHo = dgv_TaiKhoan.SelectedRows[0].Cells["ID_CanHo"].Value.ToString();
                string TenDangNhap = dgv_TaiKhoan.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();
                string MatKhau = dgv_TaiKhoan.SelectedRows[0].Cells["MatKhau"].Value.ToString();



                // Mở form chỉnh sửa và truyền dữ liệu
                ChinhSuaTaiKhoan f = new ChinhSuaTaiKhoan(ID_TaiKhoan, ID_CanHo, TenDangNhap, MatKhau);
                if (f.ShowDialog() == DialogResult.OK)
                    // Hiển thị form chỉnh sửa
                    f.ShowDialog();

                // Sau khi form chỉnh sửa đóng, làm mới lại dữ liệu trong DataGridView
               LoadDataTaiKhoan();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để chỉnh sửa.");
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
