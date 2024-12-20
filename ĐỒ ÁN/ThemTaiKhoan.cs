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
    public partial class ThemTaiKhoan : Form
    {
        public ThemTaiKhoan()
        {
            InitializeComponent();
        }

        private TaiKhoan_BLL _taikhoanBLL = new TaiKhoan_BLL();
        private void btn_Them_Click(object sender, EventArgs e)
        {
            TaiKhoan_DTO taikhoan = new TaiKhoan_DTO
            {
                ID_TaiKhoan = txt_IDTK.Text,
                ID_CanHo = cbb_IDCH.Text,
                TenDangNhap = txt_Username.Text,
                MatKhau = txt_password.Text
            };
            try
            {
                _taikhoanBLL.ThemTK(taikhoan, cbb_IDCH.Text);
                MessageBox.Show("Thêm tài khoản thành công");
                this.Close();
                

            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Lỗi: " + ex.Message);
            }
           
        }
        private void LoadDataCH()
        {
            try
            {
                CanHo_BLL _canHoBLL = new CanHo_BLL();
                List<CanHo_DTO> dsCH = _canHoBLL.LoadCHTK();
                cbb_IDCH.DataSource = dsCH;
                cbb_IDCH.DisplayMember = "ID_CanHo";
                cbb_IDCH.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btn_Huy_Click(object sender, EventArgs e)
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

        private void ThemTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDataCH();
        }
    }
}
