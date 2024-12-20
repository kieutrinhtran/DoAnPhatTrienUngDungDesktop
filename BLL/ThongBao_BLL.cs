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
    public class ThongBao_BLL
    {
        private ThongBao_DAL _thongbaoDAL = new ThongBao_DAL();

        


       

        public static List<ThongBao_DTO> SearchTB(string keyword)
        {
            return ThongBao_DAL.SearchTB(keyword);
        }

        public List<ThongBao_DTO> LoadDataThongBao()
        {
            return _thongbaoDAL.LoadThongBao_DAL();
        }

        public Dictionary<string, string> LoadNguoiGuiList()
        {
            try
            {
                return _thongbaoDAL.GetNguoiGuiList(); // Gọi DAL để lấy danh sách ID và tên người gửi
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách người gửi: " + ex.Message);
            }
        }

        public List<ThongBao_DTO> LoadTB1()
        {
            return _thongbaoDAL.LoadTB_DAL1();
        }

        public void SuaThongBao(string ID_ThongBao, string NguoiGui, string TieuDe, string NoiDung, string NgayGui)
        {
            if (string.IsNullOrEmpty(NguoiGui))
                throw new Exception("Người gửi thông báo không được trống");
            if (string.IsNullOrEmpty(TieuDe))
                throw new Exception("Tiêu đề thông báo không được trống");
            if (string.IsNullOrEmpty(NoiDung))
                throw new Exception("Nội dung thông báo không được trống");

            _thongbaoDAL.SuaThongBao(ID_ThongBao, NguoiGui, TieuDe, NoiDung, NgayGui);
        }

        public void ThemThongBao(ThongBao_DTO thongbao, string cdg)
        {
            //Kiểm tra trường dữ liệu bắt buộc
            if (string.IsNullOrEmpty(thongbao.ID_ThongBao))
                throw new Exception("Mã thông báo không được trống");
            if (!Regex.IsMatch(thongbao.ID_ThongBao, @"^TB\d{3}$"))
                throw new Exception("Mã thông báo phải có định dạng TBXXX, trong đó XXX là số");
            if (string.IsNullOrEmpty(thongbao.NguoiGui))
                throw new Exception("Người gửi thông báo không được trống");
            if (string.IsNullOrEmpty(thongbao.TieuDe))
                throw new Exception("Tiêu đề thông báo không được trống");
            if (string.IsNullOrEmpty(thongbao.NoiDung))
                throw new Exception("Nội dung thông báo không được trống");
            if (string.IsNullOrEmpty(cdg))
                throw new Exception("Vui lòng chọn chế độ gửi");


            //Kiểm tra giá trị ID của tồn tại duy nhất
            if (_thongbaoDAL.KiemTraTonTai(thongbao))
                throw new Exception("ID của thông báo đã tồn tại");
            if (thongbao.TrangThai == "Đã lên lịch gửi")
            {
                DateTime ngayGui = DateTime.Parse(thongbao.NgayGui);
                if (ngayGui <= DateTime.Now)
                    throw new Exception("Ngày gửi phải lớn hơn ngày hiện tại khi chọn chế độ 'Gửi sau'.");
            }

            _thongbaoDAL.ThemThongBao(thongbao);
        }
        public void CapNhatTrangThai(string idThongBao, string trangThai)
        {
            try
            {
                ThongBao_DAL thongBaoDal = new ThongBao_DAL();
                thongBaoDal.CapNhatTrangThai(idThongBao, trangThai);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái: " + ex.Message);
            }
        }
        public void XoaThongBao(string iD_ThongBao)
        {
            //Gọi DAL để thực hiện truy vấn CSDL
            _thongbaoDAL.XoaThongBao_DAL(iD_ThongBao);
        }

        public static List<ThongBao_DTO> GetTBByngay(string ngaybd, string ngaykt)
        {
            return ThongBao_DAL.GetTBByngay(ngaybd, ngaykt);
        }

        public static List<ThongBao_DTO> GetTB(string keyword, string ngaybd, string ngaykt)
        {
            return ThongBao_DAL.GetTB(keyword, ngaybd, ngaykt);
        }
    }
}
