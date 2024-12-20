using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDon_BLL
    {
        private HoaDon_DAL _hoadonDAL = new HoaDon_DAL();

        public List<HoaDon_DTO> LoadDataHoaDon()
        {
            return _hoadonDAL.LoadTK_DAL();
        }

        public List<CTHD_DTO> LoadDataHoaDon1(string idhoadon)
        {
            return _hoadonDAL.LoadTK_DAL1(idhoadon);
        }
    }
}
