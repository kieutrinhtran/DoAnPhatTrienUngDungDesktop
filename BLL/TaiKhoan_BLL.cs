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
    public class TaiKhoan_BLL
    {
        private TaiKhoan_DAL _taikhoanDAL = new TaiKhoan_DAL();

        public void ChinhSuaTK(TaiKhoan_DTO taikhoan)
        {
            if (string.IsNullOrEmpty(taikhoan.ID_TaiKhoan)) throw new Exception("Mã tài khoản không được để trống");
            if (string.IsNullOrEmpty(taikhoan.ID_CanHo)) throw new Exception("Mã căn hộ không được để trống");
            if (string.IsNullOrEmpty(taikhoan.TenDangNhap)) throw new Exception("Tên đăng nhập không được để trống");
            if (string.IsNullOrEmpty(taikhoan.MatKhau)) throw new Exception("Mật khẩu không được để trống");
           
            _taikhoanDAL.ChinhSuaTK(taikhoan);
        }

       

        public List<TaiKhoan_DTO> LoadTK()
        {
            return _taikhoanDAL.LoadTK_DAL();
        }

        public void ThemTK(TaiKhoan_DTO taikhoan, string cbb_IDCH)
        {
            if (string.IsNullOrEmpty(taikhoan.ID_TaiKhoan)) throw new Exception("Mã tài khoản không được để trống");
            if (!Regex.IsMatch(taikhoan.ID_TaiKhoan, @"^TK\d{3}$"))
                throw new Exception("Mã tài khoản phải có định dạng TKXXX, trong đó XXX là số");
            if (string.IsNullOrEmpty(taikhoan.ID_CanHo)) throw new Exception("Mã căn hộ không được để trống");
            if (string.IsNullOrEmpty(taikhoan.TenDangNhap)) throw new Exception("Tên đăng nhập không được để trống");
            if (string.IsNullOrEmpty(taikhoan.MatKhau)) throw new Exception("Mật khẩu không được để trống");
            if (_taikhoanDAL.KiemTraTonTai(taikhoan))
                throw new Exception("ID của tài khoản đã tồn tại");
            if (_taikhoanDAL.KiemTraTonTai(cbb_IDCH))
                throw new Exception("Mỗi căn hộ chỉ được tạo duy nhất 1 tài khoản");
            _taikhoanDAL.ThemTK(taikhoan);
        }
    }
}
