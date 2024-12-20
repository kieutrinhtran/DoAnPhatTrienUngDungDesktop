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

namespace ĐỒ_ÁN
{
    public partial class ThongKe : Form
    {
        private string ID_CH;
        public ThongKe(string iD_CanHo)
        {
            InitializeComponent();
            ID_CH = iD_CanHo;
        }
        ThongKe_BLL _thongkeBLL = new ThongKe_BLL();
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            try
            {
                List<ThongKe_DTO> TKSD = _thongkeBLL.LoadDataTK(ID_CH);
                dgv_TK.DataSource = TKSD;
                try
                {
                    if (TKSD.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy thống kê sử dụng của căn hộ");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
