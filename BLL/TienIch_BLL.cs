using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class TienIch_BLL
    {
        private TienIch_DAL _tienichDAL = new TienIch_DAL();

        public void ChinhSuaTienIch(string ID_TienIch, string TenTienIch, string GioMo, string GioDong, string MoTa, string GiaTien)
        {
            if (string.IsNullOrEmpty(TenTienIch))
                throw new Exception("Tên tiện ích không được trống");
            Regex timeRegex = new Regex(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]$");
            //Kiểm tra trường dữ liệu bắt buộc
           
            if (string.IsNullOrEmpty(GioMo))
                throw new Exception("Vui lòng nhập giờ mở");
            if (!timeRegex.IsMatch(GioMo))
                throw new Exception("Giờ mở không hợp lệ. Định dạng hợp lệ là HH:mm (ví dụ: 08:30 hoặc 23:59).");
            if (string.IsNullOrEmpty(GioDong))
                throw new Exception("Vui lòng nhập giờ đóng");
            if (!timeRegex.IsMatch(GioDong))
                throw new Exception("Giờ đóng không hợp lệ. Định dạng hợp lệ là HH:mm (ví dụ: 08:30 hoặc 23:59).");
            if (!decimal.TryParse(GiaTien, out decimal gia) || gia <= 0)
                throw new Exception("Giá tiền của tiện ích không hợp lệ.");
            _tienichDAL.ChinhSuaTienIch(ID_TienIch, TenTienIch, GioMo, GioDong, MoTa, GiaTien);
        }

        public List<TienIch_DTO> LoadDataTienIch()
        {
            return _tienichDAL.LoadTienIch_DAL();
        }

        public void ThemTienIch(TienIch_DTO tienich,string txt_Gia)
        {
            Regex timeRegex = new Regex(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]$");
            //Kiểm tra trường dữ liệu bắt buộc
            if (string.IsNullOrEmpty(tienich.ID_TienIch))
                throw new Exception("Mã tiện ích không được trống");
            if (!Regex.IsMatch(tienich.ID_TienIch, @"^TI\d{3}$"))
                throw new Exception("Mã tiện ích phải có định dạng TIXXX, trong đó XXX là số");
            if (string.IsNullOrEmpty(tienich.TenTienIch))
                throw new Exception("Tên tiện ích không được trống");
            if (string.IsNullOrEmpty(tienich.GioMo))
                throw new Exception("Vui lòng nhập giờ mở");
            if (!timeRegex.IsMatch(tienich.GioMo))
                throw new Exception("Giờ mở không hợp lệ. Định dạng hợp lệ là HH:mm (ví dụ: 08:30 hoặc 23:59).");
            if (string.IsNullOrEmpty(tienich.GioDong))
                throw new Exception("Vui lòng nhập giờ đóng");
            if (!timeRegex.IsMatch(tienich.GioDong))
                throw new Exception("Giờ đóng không hợp lệ. Định dạng hợp lệ là HH:mm (ví dụ: 08:30 hoặc 23:59).");
            if (!decimal.TryParse(txt_Gia, out decimal gia) || gia <= 0)
                throw new Exception("Giá tiền của tiện ích không hợp lệ.");
            
            



            //Kiểm tra giá trị ID của tồn tại duy nhất
            if (_tienichDAL.KiemTraTonTai(tienich))
                throw new Exception("ID của tiện ích đã tồn tại");

            //Gọi DAL để truy vấn vào CSDL 
            _tienichDAL.ThemTienIch(tienich, gia);

        }

        public void XoaTienIch(string iD_TienIch)
        {
            //Gọi DAL để thực hiện truy vấn CSDL
            _tienichDAL.XoaTienIch_DAL(iD_TienIch);
        }
    }
}
