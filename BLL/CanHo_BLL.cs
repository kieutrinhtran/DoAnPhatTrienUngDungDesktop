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
    public class CanHo_BLL
    {
        private DAL.CanHo_DAL _canhoDAL = new DAL.CanHo_DAL();

        public static List<CanHo_DTO> GetCanHo(string keyword, string loaicanho)
        {
            return CanHo_DAL.GetCanHo(keyword,loaicanho);
        }

        public static List<CanHo_DTO> GetCanHoByLoai(string loaicanho)
        {
            return CanHo_DAL.GetCanHoByLoai(loaicanho);
        }

        public static List<CanHo_DTO> SearchCanHo(string keyword)
        {
            return CanHo_DAL.SearchCanHo_DAL(keyword);
        }

        public void ChinhSuaCanHo(CanHo_DTO canHo)
        {
            if (string.IsNullOrEmpty(canHo.SoCanHo)) throw new Exception("Số căn hộ không được để trống");
            if (!int.TryParse(canHo.SoCanHo, out int soCanHo) || soCanHo <= 0)
                throw new Exception("Số căn hộ không hợp lệ");
            if (string.IsNullOrEmpty(canHo.Tang)) throw new Exception("Số tầng không được để trống");
            if (!int.TryParse(canHo.Tang, out int tang) || tang <= 0)
                throw new Exception("Số tầng phải là một số nguyên dương");
            if (string.IsNullOrEmpty(canHo.LoaiCanHo)) throw new Exception("Loại căn hộ không được để trống");
            if (string.IsNullOrEmpty(canHo.TinhTrang)) throw new Exception("Tình trạng căn hộ không được để trống");
            if (string.IsNullOrEmpty(canHo.DienTich)) throw new Exception("Diện tích căn hộ không được để trống");
            if (!decimal.TryParse(canHo.DienTich, out decimal dienTich) || dienTich <= 0)
                throw new Exception("Diện tích phải là một số thực lớn hơn 0");
            if (string.IsNullOrEmpty(canHo.Gia)) throw new Exception("Giá căn hộ không được để trống");
            if (!decimal.TryParse(canHo.Gia, out decimal gia) || gia <= 0)
                throw new Exception("Giá căn hộ phải là một số thực lớn hơn 0");


            _canhoDAL.ChinhSuaCanHo(canHo);
        }

        public List<CanHo_DTO> LoadCanHo()
        {
            return _canhoDAL.LoadCanHo_DAL();
        }

        public List<CanHo_DTO> LoadCanHo1()
        {
            return _canhoDAL.LoadCanHo_DAL1();
        }

        public List<CanHo_DTO> LoadCHDV()
        {
            return _canhoDAL.LoadCHDV();
        }

        public List<CanHo_DTO> LoadCHTK()
        {
            return _canhoDAL.LoadCHTK_DAL();
        }

        public List<CanHo_DTO> LoadLoai()
        {
            return _canhoDAL.LoadLoai();
        }

        public List<CanHo_DTO> LoadTT()
        {
            return _canhoDAL.LoadTT();
        }

        public void ThemCanHo(CanHo_DTO canHo)
        {
            if (string.IsNullOrEmpty(canHo.ID_CanHo)) throw new Exception("Mã căn hộ không được để trống");
            if (!Regex.IsMatch(canHo.ID_CanHo, @"^CH\d{3}$"))
                throw new Exception("Mã căn hộ phải có định dạng CHXXX, trong đó XXX là số");
            if (string.IsNullOrEmpty(canHo.SoCanHo)) throw new Exception("Số căn hộ không được để trống");
            if (!int.TryParse(canHo.SoCanHo, out int soCanHo) || soCanHo <= 0)
                throw new Exception("Số căn hộ không hợp lệ");
            if (string.IsNullOrEmpty(canHo.Tang)) throw new Exception("Số tầng không được để trống");
            if (!int.TryParse(canHo.Tang, out int tang) || tang <= 0)
                throw new Exception("Số tầng phải là một số nguyên dương");
            if (string.IsNullOrEmpty(canHo.LoaiCanHo)) throw new Exception("Loại căn hộ không được để trống");
            if (string.IsNullOrEmpty(canHo.TinhTrang)) throw new Exception("Tình trạng căn hộ không được để trống");
            if (string.IsNullOrEmpty(canHo.DienTich)) throw new Exception("Diện tích căn hộ không được để trống");
            if (!decimal.TryParse(canHo.DienTich, out decimal dienTich) || dienTich <= 0)
                throw new Exception("Diện tích phải là một số thực lớn hơn 0");
            if (string.IsNullOrEmpty(canHo.Gia)) throw new Exception("Giá căn hộ không được để trống");
            if (!decimal.TryParse(canHo.Gia, out decimal gia) || gia <= 0)
                throw new Exception("Giá căn hộ phải là một số thực lớn hơn 0");







            //Kiểm tra giá trị ID của tồn tại duy nhất
            if (_canhoDAL.KiemTraTonTai(canHo))
                throw new Exception("ID của căn hộ đã tồn tại");
            _canhoDAL.ThemCanHo(canHo);

           
        }

        
    }
}
