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
using static System.Net.Mime.MediaTypeNames;

namespace Đồ_án_desktop_2._0
{
    public partial class ThemDichVu : Form
    {
        public ThemDichVu()
        {
            InitializeComponent();
        }

        private DichVu_BLL _dichvuBLL = new DichVu_BLL();
      

       

        private void btn_Them_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng ở lớp DTO để chứa giá trị của các trường
            DichVu_DTO dichvu = new DichVu_DTO
            {
                ID_The = txt_IDThe.Text,
                ID_CanHo = cbb_IDCH.Text,
                TinhTrang = cbb_TT.Text,
                LoaiThe = cbb_LoaiThe.Text,
                LoaiXe = cbb_LoaiXe.Text,
                BienSoXe = txt_BSX.Text
            };


            //Truyền dữ liệu qua lớp BLL để kiểm tra định dạng và trường dữ liệu bắt buộc
            try
            {
                _dichvuBLL.ThemDichVu(dichvu);
                MessageBox.Show("Thêm dữ liệu thành công");
                
                this.Close();
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
        private void LoadDataLoaiThe()
        {
            try
            {
                List<DichVu_DTO> dsLoaiThe = _dichvuBLL.LoadLoaiThe();
                cbb_LoaiThe.DataSource = dsLoaiThe;
                cbb_LoaiThe.DisplayMember = "LoaiThe";
                cbb_LoaiThe.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            }
        private void LoadDataLoaiXe()
        {
            try
            {
                List<DichVu_DTO> dsLoaiXe = _dichvuBLL.LoadLoaiXe();
                cbb_LoaiXe.DataSource = dsLoaiXe;
                cbb_LoaiXe.DisplayMember = "LoaiXe";
                cbb_LoaiXe.SelectedIndex = -1;
                }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void LoadDataTinhTrang()
        {
            try
            {
                List<DichVu_DTO> dsTT = _dichvuBLL.LoadTinhTrang();
                cbb_TT.DataSource = dsTT;
                cbb_TT.DisplayMember = "TinhTrang";
                cbb_TT.Text = "Đang sử dụng";
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
                CanHo_BLL _canhoBLL = new CanHo_BLL();
                List<CanHo_DTO> dsCH = _canhoBLL.LoadCHDV();
                cbb_IDCH.DataSource = dsCH;
                cbb_IDCH.DisplayMember = "ID_CanHo";
                cbb_IDCH.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void ThemDichVu_Load(object sender, EventArgs e)
        {
            LoadDataCH();
            LoadDataLoaiThe();
            LoadDataTinhTrang();
            LoadDataLoaiXe();
        }

        private void cbb_LoaiThe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra giá trị được chọn trong ComboBox Loại Thẻ
            if (cbb_LoaiThe.SelectedItem != null)
            {
                string selectedLoaiThe = cbb_LoaiThe.Text;

                // Nếu loại thẻ không phải "Thẻ xe", vô hiệu hóa TextBox
                if (selectedLoaiThe != "Thẻ xe")
                {
                    txt_BSX.Enabled = false;
                    txt_BSX.Clear(); // Xóa dữ liệu cũ
                    cbb_LoaiXe.Enabled = false;
                    cbb_LoaiXe.SelectedIndex = -1; // Reset ComboBox
                }
                else
                {
                    txt_BSX.Enabled = true;
                    cbb_LoaiXe.Enabled = true;
                }
            }
        }
    }
}
