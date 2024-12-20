using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LichSuCanHo_BLL
    {
        private LichSu_DAL _lichsuDAL = new LichSu_DAL();
        public List<LichSuCanHo_DTO> LoadDataLS(string ID_CH)
        {
            return _lichsuDAL.LoadLS_DAL(ID_CH);
        }
    }
}
