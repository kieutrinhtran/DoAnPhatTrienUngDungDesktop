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
    public partial class ChinhSuaCanHo : Form
    {
        public ChinhSuaCanHo(string ID_CanHo, string So, string Tang, string LoaiCanHo, string DienTich, string Gia, string TinhTrang)
        {
            InitializeComponent();
            txt_ID.Text = ID_CanHo; txt_So.Text = So; txt_Tang.Text = Tang; cbb_Loai.Text = LoaiCanHo; txt_DT.Text = DienTich; txt_Gia.Text = Gia; cbb_TT.Text = TinhTrang;
            LCH = LoaiCanHo; TT = TinhTrang;
        }
        private BLL.CanHo_BLL _CanHoBLL = new BLL.CanHo_BLL();

       

        private void ChinhSuaCanHo_Load(object sender, EventArgs e)
        {
            LoadDataLoaiCanHo();
            LoadDataLTTCanHo();
        }
        private string LCH;
        private string TT;
        private void LoadDataLoaiCanHo()
        {
            try
            {
                List<CanHo_DTO> dsLoai = _CanHoBLL.LoadLoai();
                cbb_Loai.DataSource = dsLoai;
                cbb_Loai.DisplayMember = "LoaiCanHo";
                if (!string.IsNullOrEmpty(LCH))
                {
                    cbb_Loai.Text = LCH;
                }
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



        private void btn_Sua_Click(object sender, EventArgs e)
        {
            CanHo_DTO canho = new CanHo_DTO
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
                _CanHoBLL.ChinhSuaCanHo(canho);
                MessageBox.Show("Chỉnh sửa thành công");
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
                MessageBox.Show("Tiếp tục chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
