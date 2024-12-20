using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChamSocCuDan_BLL
    {
        private ChamSocCuDan_DAL _CSKDDAL = new ChamSocCuDan_DAL();

        // Tải toàn bộ danh sách khiếu nại từ cơ sở dữ liệu thông qua lớp DAL
        public List<KhieuNai_DTO> LoadKN()
        {
            return _CSKDDAL.LoadKN_DAL();
        }

        // Tìm kiếm khiếu nại theo trạng thái và từ khóa (cả hai hoặc một trong hai)
        public List<KhieuNai_DTO> SearchKNByTrangThaiAndNoiDungBLL(string trangThai, string keyword)
        {
            return _CSKDDAL.SearchKNByTrangThaiAndNoiDung(trangThai, keyword);
        }

        // Kiểm tra xem khiếu nại đã có người tiếp nhận chưa
        public bool CheckIfKhieuNaiHasAssigned(string idKhieuNai)
        {
            return _CSKDDAL.CheckIfKhieuNaiHasAssigned_DAL(idKhieuNai);
        }

        // Lấy danh sách những người có thể tiếp nhận khiếu nại từ cơ sở dữ liệu    
        public List<KeyValuePair<string, string>> GetNguoiTiepNhanList()
        {
            return _CSKDDAL.GetNguoiTiepNhanList_DAL();
        }

        // Cập nhật người tiếp nhận và trạng thái khiếu nại
        public bool CapNhatNguoiTiepNhanVaTrangThai(string idKhieuNai, string idNguoiTiepNhan)
        {
            return _CSKDDAL.CapNhatNguoiTiepNhanVaTrangThai_DAL(idKhieuNai, idNguoiTiepNhan);
        }

        // Cập nhật phản hồi và trạng thái khiếu nại thành "Đã xử lý"
        public bool CapNhatPhanHoiBLL(string idKhieuNai, string noiDungPhanHoi, DateTime ngayGui)
        {
            return _CSKDDAL.CapNhatPhanHoi_DAL(idKhieuNai, noiDungPhanHoi, ngayGui);
        }

        // Kiểm tra xem khiếu nại đã được phân công chưa
        public bool CheckIfKhieuNaiHasAssignedForReply(string idKhieuNai)
        {
            return _CSKDDAL.CheckIfKhieuNaiHasAssignedForReply(idKhieuNai);
        }

        // Kiểm tra xem khiếu nại đã có phản hồi hay chưa
        public bool CheckIfKhieuNaiHasFeedbackBLL(string idKhieuNai)
        {
            return _CSKDDAL.CheckIfKhieuNaiHasFeedback(idKhieuNai);
        }
    }
}
