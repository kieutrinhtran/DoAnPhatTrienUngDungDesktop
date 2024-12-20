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
    public partial class ManHinhChinh : Form
    {
        public ManHinhChinh()
        {
            InitializeComponent();
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
            f.Show();
            this.Hide();
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {

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
