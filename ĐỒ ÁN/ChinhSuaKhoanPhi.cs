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
    public partial class ChinhSuaKhoanPhi : Form
    {
        public ChinhSuaKhoanPhi()
        {
            InitializeComponent();
        }
        public string ID_KhoanPhi { get; set; }
        public string TenKhoanPhi { get; set; }
        public decimal DonGia { get; set; }
        public string ChuKy { get; set; }
        public string TrangThai { get; set; }
        public ChinhSuaKhoanPhi(string id, string ten, decimal dongia, string chuky, string trangthai)
        {
            InitializeComponent();

            // Gán dữ liệu vào các thuộc tính
            ID_KhoanPhi = id;
            TenKhoanPhi = ten;
            DonGia = dongia;
            ChuKy = chuky;
            TrangThai = trangthai;
        }

        private void ChinhSuaKhoanPhi_Load(object sender, EventArgs e)
        {
            // Load dữ liệu vào ComboBox
            var khoanPhiBLL = new KhoanPhi_BLL();
            var dsChuKy = khoanPhiBLL.LoadChuKy();
            var dsTrangThai = khoanPhiBLL.LoadTrangThaiKhoanPhi();

            // Gán nguồn dữ liệu
            cbb_ChuKy.DataSource = dsChuKy.Select(kp => kp.ChuKy).ToList();
            cbb_TT.DataSource = dsTrangThai;

            // Hiển thị dữ liệu
            txt_ID.Text = ID_KhoanPhi;
            txt_Ten.Text = TenKhoanPhi;
            txt_DonGia.Text = DonGia.ToString();

            // Đặt giá trị được chọn
            cbb_ChuKy.SelectedIndex = cbb_ChuKy.Items.IndexOf(ChuKy);
            cbb_TT.SelectedIndex = cbb_TT.Items.IndexOf(TrangThai);
        }


        private KhoanPhi_BLL _khoanPhiBLL = new KhoanPhi_BLL();

       
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
                    MessageBox.Show("Tiếp tục chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            try
            {

                // Tạo đối tượng chứa dữ liệu mới
                KhoanPhi_DTO khoanphi = new KhoanPhi_DTO
                {
                    ID_KhoanPhi = txt_ID.Text,
                    TenKhoanPhi = txt_Ten.Text,
                    ChuKy = cbb_ChuKy.Text,
                    TrangThai = cbb_TT.Text,
                };
                //Truyền dữ liệu qua lớp BLL để kiểm tra định dạng và trường dữ liệu bắt buộc
                try
                {
                    // Gọi BLL để cập nhật dữ liệu
                    _khoanPhiBLL.SuaKhoanPhi(khoanphi, txt_DonGia.Text);

                    MessageBox.Show("Cập nhật khoản phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đóng form chỉnh sửa
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
