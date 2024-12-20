using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_desktop_2._0
{
    public partial class ChinhSuaTienIch : Form
    {
        private TienIch_BLL _tienichBLL = new TienIch_BLL();
        // Constructor nhận tham số từ form chính
        public ChinhSuaTienIch(string ID_TienIch, string TenTienIch, string GioMo, string GioDong, string MoTa, string GiaTien)
        {
            InitializeComponent();

            // Gán các tham số vào biến của form
            txt_ID.Text = ID_TienIch;
            txt_Ten.Text = TenTienIch;
            txt_GioMo.Text = GioMo;
            txt_GioDong.Text = GioDong;
            txt_MoTa.Text = MoTa;
            txt_Gia.Text = GiaTien;
        }

        private void btnchinhsuatienich_Click(object sender, EventArgs e)
        {
            // Lấy thông tin đã chỉnh sửa từ các TextBox
            string updatedID = txt_ID.Text;
            string updatedName = txt_Ten.Text;
            string updatedGioMo = txt_GioMo.Text;
            string updatedGioDong = txt_GioDong.Text;
            string updatedMoTa = txt_MoTa.Text;
            string updatedGiaTien = txt_Gia.Text;

            
            TienIch_BLL _tienIchBL = new TienIch_BLL();
            //Kiểm tra trường dữ liệu bắt buộc

           

            try
            {
               
                // Cập nhật thông tin vào cơ sở dữ liệu
                _tienichBLL.ChinhSuaTienIch(updatedID, updatedName, updatedGioMo, updatedGioDong, updatedMoTa, updatedGiaTien);
                MessageBox.Show("Thông tin đã được cập nhật thành công!");
                this.Close();  // Đóng form chỉnh sửa sau khi lưu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message);
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
                MessageBox.Show("Tiếp tục chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
