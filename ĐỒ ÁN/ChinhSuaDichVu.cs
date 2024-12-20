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
    public partial class ChinhSuaDichVu : Form
    {
       

        private DichVu_BLL _dichvuBLL = new DichVu_BLL();

        // Constructor nhận tham số từ form chính
        private string TT;
        private string LT;
        private string LX;
        private string IDCH;
        public ChinhSuaDichVu(string ID_The, string ID_CanHo, string TinhTrang, string LoaiThe, string LoaiXe, string BienSoXe)
        {
            InitializeComponent();
            
            // Gán các tham số vào biến của form
            txt_IDThe.Text = ID_The;
            cbb_IDCH.Text = ID_CanHo;
            cbb_TT.Text = TinhTrang;
            cbb_LoaiThe.Text = LoaiThe;
            cbb_LoaiXe.Text = LoaiXe;
            txt_BSX.Text = BienSoXe;
            TT = TinhTrang;
            LT = LoaiThe;
            LX = LoaiXe;
            IDCH = ID_CanHo;
        }


        private void LoadDataLoaiThe()
        {
            try
            {
                List<DichVu_DTO> dsLoaiThe = _dichvuBLL.LoadLoaiThe();
                cbb_LoaiThe.DataSource = dsLoaiThe;
                cbb_LoaiThe.DisplayMember = "LoaiThe";

                // Đặt giá trị được chọn sau khi gán DataSource
                if (!string.IsNullOrEmpty(LT))
                {
                    cbb_LoaiThe.Text = LT;
                }
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

                if (!string.IsNullOrEmpty(LX) && dsLoaiXe.Any(x => x.LoaiXe == LX))
                {
                    cbb_LoaiXe.Text = LX;
                }
                else
                {
                    cbb_LoaiXe.SelectedIndex = -1; // Không chọn giá trị mặc định
                }
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

                // Đặt giá trị được chọn sau khi gán DataSource
                if (!string.IsNullOrEmpty(TT))
                {
                    cbb_TT.Text = TT;
                }
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

                // Đặt giá trị được chọn sau khi gán DataSource
                if (!string.IsNullOrEmpty(IDCH))
                {
                    cbb_IDCH.Text = IDCH;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin đã chỉnh sửa từ các TextBox
            string updatedIDThe = txt_IDThe.Text;
            string updatedIDCH = cbb_IDCH.Text;
            string updatedTT = cbb_TT.Text;
            string updatedLoaiThe = cbb_LoaiThe.Text;
            string updatedLoaiXe = cbb_LoaiXe.Text;
            string updatedBSX = txt_BSX.Text;


            DichVu_BLL _dichvuBLL = new DichVu_BLL();

            try
            {
                // Cập nhật thông tin vào cơ sở dữ liệu
                _dichvuBLL.ChinhSuaDichVu(updatedIDThe, updatedIDCH, updatedTT, updatedLoaiThe, updatedLoaiXe, updatedBSX);
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

        private void ChinhSuaDichVu_Load(object sender, EventArgs e)
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
