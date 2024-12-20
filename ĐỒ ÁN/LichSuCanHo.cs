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
    public partial class LichSuCanHo : Form
    {

        private string ID_CH;
        public LichSuCanHo(string iD_CanHo)
        {
            InitializeComponent();
            ID_CH = iD_CanHo;  
        }
        LichSuCanHo_BLL _lichsuBLL = new LichSuCanHo_BLL();
        private void LichSuCanHo_Load(object sender, EventArgs e)
        {
            try
            {
                List<LichSuCanHo_DTO> LSCH = _lichsuBLL.LoadDataLS(ID_CH);
                dgv_LichSu.DataSource = LSCH; 
                try
                {
                    if (LSCH.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy lịch sử căn hộ");
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

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
