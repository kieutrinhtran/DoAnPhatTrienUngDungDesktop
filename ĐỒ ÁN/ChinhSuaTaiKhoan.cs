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
using System.Web.Caching;
using System.Windows.Forms;

namespace Đồ_án_desktop_2._0
{
    public partial class ChinhSuaTaiKhoan : Form
    {
        public ChinhSuaTaiKhoan(string ID_TaiKhoan, string ID_CanHo, string TenDangnhap, string Matkhau)
        {
            InitializeComponent();
            txt_IDTK.Text = ID_TaiKhoan;
            cbb_IDCH.Text = ID_CanHo;
            Txt_Username.Text = TenDangnhap;
            Txt_Password.Text = Matkhau;

        }
        private BLL.TaiKhoan_BLL _TaiKhoanBLL = new BLL.TaiKhoan_BLL();
        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            TaiKhoan_DTO TK = new TaiKhoan_DTO
            {
                ID_TaiKhoan = txt_IDTK.Text,
                ID_CanHo = cbb_IDCH.Text,
                TenDangNhap = Txt_Username.Text,
                MatKhau = Txt_Password.Text

            };
            try
            {
                _TaiKhoanBLL.ChinhSuaTK(TK);
                MessageBox.Show("Chỉnh sửa thành công");
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

        private void ChinhSuaTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDataCH();
        }
    }
}
