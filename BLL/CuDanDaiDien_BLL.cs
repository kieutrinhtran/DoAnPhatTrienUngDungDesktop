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
    public class CuDanDaiDien_BLL
    {
        private CuDanDaiDien_DAL _cuDanDAL = new CuDanDaiDien_DAL();
        // Lấy danh sách cư dân
        public List<CuDanDaiDien_DTO> LoadDanhSachCuDan()
        {
            return _cuDanDAL.LoadDanhSachCuDan();
        }
        //Kiểm tra dữ liệu cư dân
        private void ValidateCuDan(CuDanDaiDien_DTO cuDan)
        {
            if (string.IsNullOrWhiteSpace(cuDan.ID_CuDan))
                throw new ArgumentException("ID cư dân không được để trống.");
            if (!Regex.IsMatch(cuDan.ID_CuDan, @"^CD\d{3}$"))
                throw new Exception("Mã cư dân đại diện phải có định dạng CDXXX, trong đó XXX là số");
            if (string.IsNullOrWhiteSpace(cuDan.HoTen))
                throw new ArgumentException("Họ tên không được để trống.");
            if (cuDan.NgaySinh == DateTime.MinValue)
                throw new ArgumentException("Ngày sinh không hợp lệ.");
            if (string.IsNullOrWhiteSpace(cuDan.GioiTinh))
                throw new ArgumentException("Giới tính không được để trống.");
            if (string.IsNullOrWhiteSpace(cuDan.SoDienThoai) || !System.Text.RegularExpressions.Regex.IsMatch(cuDan.SoDienThoai, @"^\d{10,15}$"))
                throw new ArgumentException("Số điện thoại không hợp lệ.");
            if (string.IsNullOrWhiteSpace(cuDan.Email) || !System.Text.RegularExpressions.Regex.IsMatch(cuDan.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email không hợp lệ.");
            if (string.IsNullOrWhiteSpace(cuDan.TinhTrang))
                throw new ArgumentException("Tình trạng không được để trống.");
        }

        // Thêm cư dân mới
        public void ThemCuDan(CuDanDaiDien_DTO cuDan)
        {
            ValidateCuDan(cuDan);// Kiểm tra dữ liệu hợp lệ
                                 // Kiểm tra trùng ID cư dân
            if (_cuDanDAL.KiemTraIDCuDan(cuDan.ID_CuDan))
            {
                throw new Exception("ID cư dân đã tồn tại. Vui lòng nhập ID khác.");
            }

            try
            {
                // Gọi DAL để thêm dữ liệu
                _cuDanDAL.ThemCuDan(cuDan);
            }

            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi thêm cư dân: " + ex.Message);
            }

        }

        // Sửa cư dân
        public void SuaCuDan(CuDanDaiDien_DTO cuDan)
        {
            ValidateCuDan(cuDan);
            try
            {
                _cuDanDAL.SuaCuDan(cuDan); // Gọi DAL để sửa dữ liệu
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi sửa cư dân: " + ex.Message);
            }
        }

        // Xóa cư dân
        public void XoaCuDan(string idCuDan)
        {
            if (string.IsNullOrWhiteSpace(idCuDan))
                throw new ArgumentException("ID cư dân không được để trống.");
            try
            {
                _cuDanDAL.XoaCuDan(idCuDan);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi xóa cư dân: " + ex.Message);
            }
        }

        // Phương thức tìm kiếm cư dân
        public List<CuDanDaiDien_DTO> TimKiemCuDanTheoTuKhoa(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                throw new ArgumentException("Từ khóa tìm kiếm không được để trống.");

            // Gọi DAL để tìm kiếm cư dân theo tất cả các tiêu chí
            return _cuDanDAL.TimKiemCuDanTheoTuKhoa(tuKhoa);
        }
        public List<CuDanDaiDien_DTO> TimKiemCuDanTheoTinhTrang(string tinhTrang)
        {
            // Gọi DAL để tìm kiếm theo Tình trạng
            return _cuDanDAL.TimKiemCuDanTheoTinhTrang(tinhTrang);
        }
        // Tìm kiếm theo cả từ khóa và tình trạng
        public List<CuDanDaiDien_DTO> TimKiemCuDan(string tuKhoa, string tinhTrang)
        {
            return _cuDanDAL.TimKiemCuDan(tuKhoa, tinhTrang);
        }
    }
}
