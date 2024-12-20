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
    public class KhoanPhi_BLL
    {
        public KhoanPhi_DAL _khoanphiDAL = new KhoanPhi_DAL();

        public List<KhoanPhi_DTO> LoadDataKhoanPhi()
        {
            return _khoanphiDAL.LoadKhoanPhi_DAL();
        }
        
        public List<string> LoadTrangThaiKhoanPhi()
        {
            return _khoanphiDAL.LoadTrangThaiKhoanPhi();
        }

        public void ThemKhoanPhi(KhoanPhi_DTO KhoanPhi, string txt_DonGia)
        {
            //Kiểm tra trường dữ liệu bắt buộc
            if (string.IsNullOrEmpty(KhoanPhi.ID_KhoanPhi))
                throw new Exception("Mã khoản phí không được trống");
            if (!Regex.IsMatch(KhoanPhi.ID_KhoanPhi, @"^KP\d{3}$"))
                throw new Exception("Mã khoản phí phải có định dạng KPXXX, trong đó XXX là số");
            if (string.IsNullOrEmpty(KhoanPhi.TenKhoanPhi))
                throw new Exception("Tên khoản phí không được trống");
            if (!decimal.TryParse(txt_DonGia, out decimal gia) || gia <= 0)
                throw new Exception("Giá tiền của khoản phí phải lớn hơn 0.");
            if (string.IsNullOrEmpty(KhoanPhi.ChuKy))
                throw new Exception("Chu kỳ khoản phí không được trống");
            if (string.IsNullOrEmpty(KhoanPhi.TrangThai))
                throw new Exception("Trạng thái khoản phí không được trống");
            

            //Kiểm tra giá trị ID của tồn tại duy nhất
            if (_khoanphiDAL.KiemTraTonTai(KhoanPhi))
                throw new Exception("ID của khoản phí đã tồn tại");

            //Gọi DAL để truy vấn vào CSDL 
            _khoanphiDAL.ThemKhoanPhi(KhoanPhi, gia);

        }
        public void SuaKhoanPhi(KhoanPhi_DTO KhoanPhi, string txt_DonGia)
        {
            if (string.IsNullOrEmpty(KhoanPhi.ID_KhoanPhi))
                throw new Exception("Mã khoản phí không được trống");
            if (string.IsNullOrEmpty(KhoanPhi.TenKhoanPhi))
                throw new Exception("Tên khoản phí không được trống");
            if (!decimal.TryParse(txt_DonGia, out decimal gia) || gia <= 0)
                throw new Exception("Giá tiền của khoản phí phải lớn hơn 0.");
            if (string.IsNullOrEmpty(KhoanPhi.ChuKy))
                throw new Exception("Chu kỳ khoản phí không được trống");
            if (string.IsNullOrEmpty(KhoanPhi.TrangThai))
                throw new Exception("Trạng thái khoản phí không được trống");


           

            KhoanPhi_DAL suakhoanphi_dal = new KhoanPhi_DAL();
            suakhoanphi_dal.ChinhSuaKhoanPhi(KhoanPhi, txt_DonGia);
        }

        private KhoanPhi_DAL _khoanPhiDAL = new KhoanPhi_DAL();

        public void XoaKhoanPhi(string ID_KhoanPhi)
        {
            _khoanPhiDAL.XoaKhoanPhi(ID_KhoanPhi);
        }

        public List<KhoanPhi_DTO> TimKiemKhoanPhi(string keyword)
        {
            //Kiểm tra đã nhập từ khóa chưa
            if (string.IsNullOrEmpty(keyword))
                throw new Exception("Vui lòng nhập từ khóa để tìm kiếm.");
            return _khoanPhiDAL.TimKiemKhoanPhi(keyword);
        }

        public static List<KhoanPhi_DTO> SearchKhoanPhi(string keyword)
        {
            return KhoanPhi_DAL.SearchKhoanPhi_DAL(keyword);
        }

       

        public static List<KhoanPhi_DTO> GetKhoanPhi(string keyword, string trangthai)
        {
            return KhoanPhi_DAL.GetKhoanPhi(keyword, trangthai);
        }

        public List<KhoanPhi_DTO> LoadChuKy()
        {
            return _khoanphiDAL.LoadChuKy();
        }

        public List<string> GetChuKy()
        {
            return _khoanphiDAL.LoadChuKyKhoanPhi();
        }

        public List<string> GetTT()
        {
            return _khoanphiDAL.LoadTrangThai();
        }

        public static List<KhoanPhi_DTO> GetKhoanPhiByTrangThai(string trangthai)
        {
            return KhoanPhi_DAL.GetKhoanPhi(trangthai);
        }

       
        }
    }

