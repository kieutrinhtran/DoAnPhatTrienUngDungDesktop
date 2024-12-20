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
    public class DichVu_BLL
    {
        private DichVu_DAL _dichvuDAL = new DichVu_DAL();

        public static List<DichVu_DTO> GetThe(string keyword, string loaithe)
        {
            return DichVu_DAL.GetThe(keyword, loaithe);
        }

        public static List<DichVu_DTO> GetTheByLoai(string loaithe)
        {
            return DichVu_DAL.GetTheByLoai(loaithe);
        }

        public static List<DichVu_DTO> SearchThe(string keyword)
        {
            return DichVu_DAL.SearchThe_DAL(keyword);
        }

        public void ChinhSuaDichVu(string ID_The, string ID_CanHo, string TinhTrang, string LoaiThe, string LoaiXe, string BienSoXe)
        {
            //Kiểm tra trường dữ liệu bắt buộc
            if (string.IsNullOrEmpty(ID_The))
                throw new Exception("Mã thẻ không được trống");
            if (string.IsNullOrEmpty(ID_CanHo))
                throw new Exception("Mã căn hộ không được trống");
            if (string.IsNullOrEmpty(TinhTrang))
                throw new Exception("Tình trạng thẻ không được trống");
            if (string.IsNullOrEmpty(LoaiThe))
                throw new Exception("Loại thẻ không được trống");
            if (LoaiThe == "Thẻ xe")
            {
                if (string.IsNullOrEmpty(LoaiXe))
                    throw new Exception("Vui lòng chọn loại xe");
                if (string.IsNullOrEmpty(BienSoXe))
                    throw new Exception("Vui lòng điền biển số xe");
            }
            _dichvuDAL.ChinhSuaDichVu(ID_The, ID_CanHo, TinhTrang, LoaiThe, LoaiXe, BienSoXe);
        }

      

        public List<DichVu_DTO> LoadDataDichVu()
        {
            return _dichvuDAL.LoadDichVu_DAL();
        }

        public List<DichVu_DTO> LoadLoaiThe()
        {
            return _dichvuDAL.LoadLoaiThe_DAL();
        }

        public List<DichVu_DTO> LoadLoaiXe()
        {
            return _dichvuDAL.LoadLoaiXe_DAL();
        }

        public List<DichVu_DTO> LoadTinhTrang()
        {
            return _dichvuDAL.LoadTT_DAL();
        }

        public void ThemDichVu(DichVu_DTO dichvu)
        {
            //Kiểm tra trường dữ liệu bắt buộc
            if (string.IsNullOrEmpty(dichvu.ID_The))
                throw new Exception("Mã thẻ không được trống");
            if (!Regex.IsMatch(dichvu.ID_The, @"^T\d{3}$"))
                throw new Exception("Mã thẻ phải có định dạng TXXX, trong đó XXX là số");
            if (string.IsNullOrEmpty(dichvu.ID_CanHo))
                throw new Exception("Mã căn hộ không được trống");
            if (string.IsNullOrEmpty(dichvu.TinhTrang))
                throw new Exception("Tình trạng thẻ không được trống");
            if (string.IsNullOrEmpty(dichvu.LoaiThe))
                throw new Exception("Loại thẻ không được trống");
            if (dichvu.LoaiThe == "Thẻ xe")
            {
                if (string.IsNullOrEmpty(dichvu.BienSoXe))
                    throw new Exception("Vui lòng điền biển số xe");
            }


            //Kiểm tra giá trị ID của tồn tại duy nhất
            if (_dichvuDAL.KiemTraTonTai(dichvu))
                throw new Exception("ID của thẻ đã tồn tại");

            //Gọi DAL để truy vấn vào CSDL 
            _dichvuDAL.ThemDichVu(dichvu);

        }

        

        public void XoaDichVu(string iD_The)
        {
            _dichvuDAL.XoaDichVu(iD_The);
        }
    }
}
