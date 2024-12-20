using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChamSocCuDan_DAL
    {
        // Lấy danh sách khiếu nại để tải vào DataGridView
        public List<KhieuNai_DTO> LoadKN_DAL()
        {
            var DSKN = new List<KhieuNai_DTO>();

            using (SqlConnection cnn = DBConnect.Connect())
            {
                cnn.Open();

                string query = @"
                                                SELECT k.ID_KhieuNai, 
                               cd.HoTen AS NguoiGui, 
                               b.HoTen AS NguoiTiepNhan, 
                               k.NoiDung, 
                               k.NgayGui, 
                               k.TrangThai,
                               (SELECT TOP 1 p.NoiDung FROM PhanHoi p WHERE p.ID_KhieuNai = k.ID_KhieuNai ORDER BY p.NgayGui DESC) AS NoiDungPhanHoi,
                               (SELECT TOP 1 p.NgayGui FROM PhanHoi p WHERE p.ID_KhieuNai = k.ID_KhieuNai ORDER BY p.NgayGui DESC) AS NgayGuiPhanHoi
                        FROM KhieuNai k
                        INNER JOIN TaiKhoanCanHo tk ON k.NguoiGui = tk.ID_TaiKhoan
                        INNER JOIN CanHo ch ON tk.ID_CanHo = ch.ID_CanHo
                        INNER JOIN LichSuCanHo ls ON ch.ID_CanHo = ls.ID_CanHo
                        INNER JOIN CuDanDaiDien cd ON ls.CuDanSoHuu = cd.ID_CuDan
                        LEFT JOIN BanQuanLy b ON k.NguoiTiepNhan = b.ID_BanQuanLy
                        ORDER BY k.ID_KhieuNai";

                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var kn = new KhieuNai_DTO
                    {
                        ID_KhieuNai = reader["ID_KhieuNai"].ToString(),
                        NguoiGui = reader["NguoiGui"].ToString(),
                        NguoiTiepNhan = reader["NguoiTiepNhan"]?.ToString(),
                        NoiDung = reader["NoiDung"].ToString(),
                        NgayGui = Convert.ToDateTime(reader["NgayGui"]),
                        TrangThai = reader["TrangThai"].ToString(),
                        NoiDungPhanHoi = reader["NoiDungPhanHoi"]?.ToString(),
                        NgayGuiPhanHoi = reader["NgayGuiPhanHoi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["NgayGuiPhanHoi"])
                    };

                    DSKN.Add(kn);
                }
            }
            return DSKN;
        }


        // Tìm kiếm khiếu nại theo trạng thái và nội dung
        public List<KhieuNai_DTO> SearchKNByTrangThaiAndNoiDung(string trangThai, string keyword)
        {
            var result = new List<KhieuNai_DTO>();

            using (SqlConnection cnn = DBConnect.Connect())
            {
                cnn.Open();

                // Xây dựng truy vấn dựa trên trạng thái và từ khóa
                string query = @"          SELECT k.ID_KhieuNai, 
                                           cd.HoTen AS NguoiGui, 
                                           b.HoTen AS NguoiTiepNhan, 
                                           k.NoiDung, 
                                           k.NgayGui, 
                                           k.TrangThai,
                                           (SELECT TOP 1 p.NoiDung 
                                            FROM PhanHoi p 
                                            WHERE p.ID_KhieuNai = k.ID_KhieuNai 
                                            ORDER BY p.NgayGui DESC) AS NoiDungPhanHoi,
                                           (SELECT TOP 1 p.NgayGui 
                                            FROM PhanHoi p 
                                            WHERE p.ID_KhieuNai = k.ID_KhieuNai 
                                            ORDER BY p.NgayGui DESC) AS NgayGuiPhanHoi
                                                    FROM KhieuNai k
                                                    INNER JOIN TaiKhoanCanHo tk ON k.NguoiGui = tk.ID_TaiKhoan
                                                    INNER JOIN CanHo ch ON tk.ID_CanHo = ch.ID_CanHo
                                                    INNER JOIN LichSuCanHo ls ON ch.ID_CanHo = ls.ID_CanHo
                                                    INNER JOIN CuDanDaiDien cd ON ls.CuDanSoHuu = cd.ID_CuDan
                                                    LEFT JOIN BanQuanLy b ON k.NguoiTiepNhan = b.ID_BanQuanLy
                                                    WHERE k.NoiDung LIKE @keyword";

                // Thêm điều kiện cho trạng thái nếu có
                if (!string.IsNullOrEmpty(trangThai))
                {
                    query += " AND k.TrangThai = @TrangThai";
                }

                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    if (!string.IsNullOrEmpty(trangThai))
                    {
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var kn = new KhieuNai_DTO
                        {
                            ID_KhieuNai = reader["ID_KhieuNai"].ToString(),
                            NguoiGui = reader["NguoiGui"].ToString(),
                            NguoiTiepNhan = reader["NguoiTiepNhan"].ToString(),
                            NoiDung = reader["NoiDung"].ToString(),
                            NgayGui = Convert.ToDateTime(reader["NgayGui"]),
                            TrangThai = reader["TrangThai"].ToString(),
                            NoiDungPhanHoi = reader["NoiDungPhanHoi"]?.ToString(),
                            NgayGuiPhanHoi = reader["NgayGuiPhanHoi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["NgayGuiPhanHoi"])
                        };
                        result.Add(kn);
                    }
                }
            }
            return result;
        }

        // Kiểm tra xem khiếu nại đã có người tiếp nhận chưa
        public bool CheckIfKhieuNaiHasAssigned_DAL(string idKhieuNai)
        {
            bool hasAssigned = false;

            using (SqlConnection cnn = DBConnect.Connect())
            {
                cnn.Open();
                string query = "SELECT NguoiTiepNhan FROM KhieuNai WHERE ID_KhieuNai = @IDKhieuNai";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@IDKhieuNai", idKhieuNai);

                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value && !string.IsNullOrEmpty(result.ToString()))
                {
                    hasAssigned = true; // Nếu có người tiếp nhận
                }
            }
            return hasAssigned;
        }

        // Lấy danh sách người tiếp nhận với tên Ban Quản Lý cho form phân công
        public List<KeyValuePair<string, string>> GetNguoiTiepNhanList_DAL()
        {
            var list = new List<KeyValuePair<string, string>>();

            using (SqlConnection cnn = DBConnect.Connect())
            {
                cnn.Open();
                string query = "SELECT ID_BanQuanLy, HoTen FROM BanQuanLy";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Lưu ID và Tên Ban Quản Lý dưới dạng KeyValuePair
                    list.Add(new KeyValuePair<string, string>(reader["ID_BanQuanLy"].ToString(), reader["HoTen"].ToString()));
                }
            }
            return list;
        }

        // Cập nhật người tiếp nhận và trạng thái khiếu nại
        public bool CapNhatNguoiTiepNhanVaTrangThai_DAL(string idKhieuNai, string idNguoiTiepNhan)
        {
            using (SqlConnection cnn = DBConnect.Connect())
            {
                cnn.Open();

                // Cập nhật người tiếp nhận và trạng thái khiếu nại
                string query = @"
            UPDATE KhieuNai 
            SET NguoiTiepNhan = @IDNguoiTiepNhan, 
                TrangThai = N'Đang xử lý'
            WHERE ID_KhieuNai = @IDKhieuNai";

                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@IDNguoiTiepNhan", idNguoiTiepNhan);
                    cmd.Parameters.AddWithValue("@IDKhieuNai", idKhieuNai);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;  // Nếu cập nhật thành công, trả về true
                }
            }
        }

        // Cập nhật phản hồi vào cơ sở dữ liệu và thay đổi trạng thái khiếu nại thành "Đã xử lý"
        public bool CapNhatPhanHoi_DAL(string idKhieuNai, string noiDungPhanHoi, DateTime ngayGui)
        {
            using (SqlConnection cnn = DBConnect.Connect())
            {
                cnn.Open();

                // Tạo ID_PhanHoi mới
                string idPhanHoi = "PH" + idKhieuNai.Substring(2);


                // Cập nhật nội dung phản hồi vào bảng PhanHoi và thay đổi trạng thái của khiếu nại
                string query = @"
                        INSERT INTO PhanHoi (ID_PhanHoi, ID_KhieuNai, NoiDung, NgayGui)
                        VALUES (@IDPhanHoi, @IDKhieuNai, @NoiDungPhanHoi, @NgayGui);

                        UPDATE KhieuNai
                        SET TrangThai = N'Đã xử lý'
                        WHERE ID_KhieuNai = @IDKhieuNai";

                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@IDPhanHoi", idPhanHoi);  // Thêm ID_PhanHoi
                    cmd.Parameters.AddWithValue("@IDKhieuNai", idKhieuNai);
                    cmd.Parameters.AddWithValue("@NoiDungPhanHoi", noiDungPhanHoi);
                    cmd.Parameters.AddWithValue("@NgayGui", ngayGui);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;  // Nếu cập nhật thành công, trả về true
                }
            }
        }

        // Kiểm tra xem khiếu nại đã có phản hồi hay chưa
        public bool CheckIfKhieuNaiHasFeedback(string idKhieuNai)
        {
            string query = "SELECT TOP 1 NoiDung FROM PhanHoi WHERE ID_KhieuNai = @ID_KhieuNai ORDER BY NgayGui DESC";

            using (SqlConnection cnn = DBConnect.Connect())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@ID_KhieuNai", idKhieuNai);

                var result = cmd.ExecuteScalar();
                return result != DBNull.Value && result != null;
            }
        }

        // Kiểm tra xem khiếu nại đã được phân công chưa
        public bool CheckIfKhieuNaiHasAssignedForReply(string idKhieuNai)
        {
            string query = "SELECT NguoiTiepNhan FROM KhieuNai WHERE ID_KhieuNai = @ID_KhieuNai";

            using (SqlConnection cnn = DBConnect.Connect())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@ID_KhieuNai", idKhieuNai);

                var result = cmd.ExecuteScalar();
                return result != DBNull.Value && result != null;
            }
        }
    }
}
