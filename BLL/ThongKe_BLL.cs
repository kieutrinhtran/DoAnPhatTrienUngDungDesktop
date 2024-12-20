using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThongKe_BLL
    {
        private ThongKe_DAL _thongkeDAL = new ThongKe_DAL();

        public List<ThongKe_DTO> LoadDataTK(string iD_CH)
        {
            return _thongkeDAL.LoadTK_DAL(iD_CH);
        }
    }
}
