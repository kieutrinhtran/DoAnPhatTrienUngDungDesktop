using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhieuNai_DTO
    {
        public string ID_KhieuNai { get; set; }
        public string NguoiGui { get; set; }
        public string NguoiTiepNhan { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayGui { get; set; }
        public string TrangThai { get; set; }
        public string NoiDungPhanHoi { get; set; }
        public DateTime? NgayGuiPhanHoi { get; set; }
    }
}
