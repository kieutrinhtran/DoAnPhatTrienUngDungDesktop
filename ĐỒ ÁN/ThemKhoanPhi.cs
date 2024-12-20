using BLL;
using DAL;
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
    public partial class ThemKhoanPhi : Form
    {
        

        
        public ThemKhoanPhi()
        {
            InitializeComponent();
        }
        private KhoanPhi_BLL _khoanphiBLL = new KhoanPhi_BLL();
        private void LoadTrangThaiKhoanPhi()
        {
            
            try
            {
                KhoanPhi_BLL khoanphi_BLL = new KhoanPhi_BLL();
                List<string> TrangThaiList = khoanphi_BLL.GetTT();
                cbb_ChuKy.DataSource = TrangThaiList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadChuKy()
        {
            try
            {
                KhoanPhi_BLL khoanphi_BLL = new KhoanPhi_BLL();
                List<string> ChuKyList = khoanphi_BLL.GetChuKy();
                cbb_ChuKy.DataSource = ChuKyList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            
        }


        
        

        private void ThemKhoanPhi_Load(object sender, EventArgs e)
        {
            var khoanPhiBLL = new KhoanPhi_BLL();
            var dsChuKy = khoanPhiBLL.LoadChuKy();
            var dsTrangThai = khoanPhiBLL.LoadTrangThaiKhoanPhi();

            // Gán nguồn dữ liệu
            cbb_ChuKy.DataSource = dsChuKy;
            cbb_ChuKy.DisplayMember = "ChuKy";
            cbb_TrangThai.DataSource = dsTrangThai;
            cbb_TrangThai.SelectedItem = "Đang áp dụng";
            cbb_ChuKy.SelectedIndex = -1;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {

                KhoanPhi_DTO khoanphi = new KhoanPhi_DTO
                {
                    ID_KhoanPhi = txt_ID.Text,
                    TenKhoanPhi = txt_Ten.Text,
                    ChuKy = cbb_ChuKy.Text,
                    TrangThai = cbb_TrangThai.Text,
                };
                //Truyền dữ liệu qua lớp BLL để kiểm tra định dạng và trường dữ liệu bắt buộc
                try
                {
                    _khoanphiBLL.ThemKhoanPhi(khoanphi, txt_DonGia.Text);
                    MessageBox.Show("Thêm khoản phí thành công");
                    
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
    
    
}
