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
    public partial class ThemCanHo : Form
    {
        public ThemCanHo()
        {
            InitializeComponent();
        }
        private BLL.CanHo_BLL _CanHoBLL = new BLL.CanHo_BLL();
        private void LoadDataLoaiCanHo()
        {
            try
            {
                List<CanHo_DTO> dsLoai = _CanHoBLL.LoadLoai();
                cbb_Loai.DataSource = dsLoai;
                cbb_Loai.DisplayMember = "LoaiCanHo";
                cbb_Loai.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void LoadDataLTTCanHo()
        {
            try
            {
                List<CanHo_DTO> dsTT = _CanHoBLL.LoadTT();
                cbb_TT.DataSource = dsTT;
                cbb_TT.DisplayMember = "TinhTrang";
                cbb_TT.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            CanHo_DTO canHo = new CanHo_DTO
            {
                ID_CanHo = txt_ID.Text,
                SoCanHo = txt_So.Text,
                Tang = txt_Tang.Text,
                LoaiCanHo = cbb_Loai.Text,
                DienTich = txt_DT.Text,
                Gia = txt_Gia.Text,
                TinhTrang = cbb_TT.Text
            };
            try
            {
                _CanHoBLL.ThemCanHo(canHo);
                MessageBox.Show("Thêm căn hộ thành công");
                QuanLyCanHo f = new QuanLyCanHo();
                
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            
        }

      

        private void btnHuy_Click(object sender, EventArgs e)
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

        private void ThemCanHo_Load(object sender, EventArgs e)
        {
            LoadDataLoaiCanHo();
            LoadDataLTTCanHo();
        }
    }
}
