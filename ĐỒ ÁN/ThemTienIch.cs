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
    public partial class ThemTienIch : Form
    {
        public ThemTienIch()
        {
            InitializeComponent();
        }
        private TienIch_BLL _tienichBLL = new TienIch_BLL();
        private void btnthemtienich_Click(object sender, EventArgs e)
        {
            try
            {
               
                TienIch_DTO tienich = new TienIch_DTO
                {
                    ID_TienIch = txt_ID.Text,
                    TenTienIch = txt_Ten.Text,
                    MoTa = txt_MoTa.Text,
                    GioMo = txt_GioMo.Text,
                    GioDong = txt_GioDong.Text,
                    
                };
                //Truyền dữ liệu qua lớp BLL để kiểm tra định dạng và trường dữ liệu bắt buộc
                try
                {
                    _tienichBLL.ThemTienIch(tienich, txt_Gia.Text);
                    MessageBox.Show("Thêm dữ liệu thành công");
                    QuanLyTienIch f = new QuanLyTienIch();
                    
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

        private void btnhuythem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy thao tác Thêm tiện ích mới ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xử lý nếu người dùng chọn "Yes"
                this.Close();
            }
            else
            {
                // Xử lý nếu người dùng chọn "No"
                MessageBox.Show("Tiếp tục thêm tiện ích.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

        }
    }
}
