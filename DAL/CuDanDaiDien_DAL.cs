using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CuDanDaiDien_DAL
    {
        public void ThemCuDan(CuDanDaiDien_DTO cuDan)
        {
            try
            {
                using (SqlConnection cnn = DBConnect.Connect())
                {
                    cnn.Open();
                    string query = "INSERT INTO CuDanDaiDien (ID_CuDan, HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, TinhTrang) " +
                                   "VALUES (@ID_CuDan, @HoTen, @NgaySinh, @GioiTinh, @SoDienThoai, @Email, @TinhTrang)";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID_CuDan", cuDan.ID_CuDan));
                        cmd.Parameters.Add(new SqlParameter("@HoTen", cuDan.HoTen));
                        cmd.Parameters.Add(new SqlParameter("@NgaySinh", cuDan.NgaySinh));
                        cmd.Parameters.Add(new SqlParameter("@GioiTinh", cuDan.GioiTinh));
                        cmd.Parameters.Add(new SqlParameter("@SoDienThoai", cuDan.SoDienThoai));
                        cmd.Parameters.Add(new SqlParameter("@Email", cuDan.Email));
                        cmd.Parameters.Add(new SqlParameter("@TinhTrang", cuDan.TinhTrang));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm cư dân: " + ex.Message);
            }
        }


        public void SuaCuDan(CuDanDaiDien_DTO cuDan)
        {
            try
            {
                using (SqlConnection cnn = DBConnect.Connect())
                {
                    cnn.Open();
                    string query = "UPDATE CuDanDaiDien SET " +
                                   "HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, " +
                                   "SoDienThoai = @SoDienThoai, Email = @Email, TinhTrang = @TinhTrang " +
                                   "WHERE ID_CuDan = @ID_CuDan";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID_CuDan", cuDan.ID_CuDan));
                        cmd.Parameters.Add(new SqlParameter("@HoTen", cuDan.HoTen));
                        cmd.Parameters.Add(new SqlParameter("@NgaySinh", cuDan.NgaySinh));
                        cmd.Parameters.Add(new SqlParameter("@GioiTinh", cuDan.GioiTinh));
                        cmd.Parameters.Add(new SqlParameter("@SoDienThoai", cuDan.SoDienThoai));
                        cmd.Parameters.Add(new SqlParameter("@Email", cuDan.Email));
                        cmd.Parameters.Add(new SqlParameter("@TinhTrang", cuDan.TinhTrang));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa cư dân: " + ex.Message);
            }
        }

        public void XoaCuDan(string idCuDan)
        {
            try
            {
                using (SqlConnection cnn = DBConnect.Connect())
                {
                    cnn.Open();
                    string query = "DELETE FROM CuDanDaiDien WHERE ID_CuDan = @ID_CuDan";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID_CuDan", idCuDan));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa cư dân: " + ex.Message);
            }
        }

        public bool KiemTraIDCuDan(string idCuDan)
        {
            try
            {
                using (SqlConnection cnn = DBConnect.Connect())
                {
                    cnn.Open();
                    string query = "SELECT COUNT(*) FROM CuDanDaiDien WHERE ID_CuDan = @ID_CuDan";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID_CuDan", idCuDan));
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra ID cư dân: " + ex.Message);
            }
        }

        public List<CuDanDaiDien_DTO> LoadDanhSachCuDan()
        {
            var danhSachCuDan = new List<CuDanDaiDien_DTO>();
            try
            {
                using (SqlConnection cnn = DBConnect.Connect())
                {
                    cnn.Open();
                    string query = "SELECT * FROM CuDanDaiDien";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var cuDan = new CuDanDaiDien_DTO
                                {
                                    ID_CuDan = reader["ID_CuDan"].ToString(),
                                    HoTen = reader["HoTen"].ToString(),
                                    NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : DateTime.MinValue,
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    SoDienThoai = reader["SoDienThoai"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    TinhTrang = reader["TinhTrang"].ToString()
                                };
                                danhSachCuDan.Add(cuDan);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách cư dân: " + ex.Message);
            }
            return danhSachCuDan;
        }
        // Phương thức tìm kiếm cư dân theo tất cả các trường
        public List<CuDanDaiDien_DTO> TimKiemCuDanTheoTuKhoa(string tuKhoa)
        {
            List<CuDanDaiDien_DTO> danhSachCuDan = new List<CuDanDaiDien_DTO>();

            using (SqlConnection cnn = DBConnect.Connect())
            {
                // SQL Query để tìm kiếm theo nhiều trường (ID, HoTen, SoDienThoai, NgaySinh, GioiTinh, Email, TinhTrang)
                string query = @"
                    SELECT * FROM CuDanDaiDien
                    WHERE ID_CuDan LIKE @TuKhoa
                    OR HoTen LIKE @TuKhoa
                    OR SoDienThoai LIKE @TuKhoa
                    OR NgaySinh LIKE @TuKhoa
                    OR GioiTinh LIKE @TuKhoa
                    OR Email LIKE @TuKhoa
                    OR TinhTrang LIKE @TuKhoa
                ";

                SqlCommand command = new SqlCommand(query, cnn);
                command.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CuDanDaiDien_DTO cuDan = new CuDanDaiDien_DTO
                    {
                        ID_CuDan = reader["ID_CuDan"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        TinhTrang = reader["TinhTrang"].ToString(),
                        NgaySinh = reader["NgaySinh"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString()
                    };
                    danhSachCuDan.Add(cuDan);
                }
            }

            return danhSachCuDan;
        }
        public List<CuDanDaiDien_DTO> TimKiemCuDanTheoTinhTrang(string tinhTrang)
        {
            List<CuDanDaiDien_DTO> danhSachCuDan = new List<CuDanDaiDien_DTO>();

            using (SqlConnection cnn = DBConnect.Connect())
            {
                // SQL Query để tìm kiếm theo Tình trạng
                string query = "SELECT * FROM CuDanDaiDien WHERE TinhTrang = @TinhTrang";

                SqlCommand command = new SqlCommand(query, cnn);
                command.Parameters.AddWithValue("@TinhTrang", tinhTrang);

                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CuDanDaiDien_DTO cudan = new CuDanDaiDien_DTO
                    {
                        ID_CuDan = reader["ID_CuDan"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        TinhTrang = reader["TinhTrang"].ToString(),
                        NgaySinh = reader["NgaySinh"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString()
                    };
                    danhSachCuDan.Add(cudan);
                }
            }

            return danhSachCuDan;
        }
        // Tìm kiếm theo cả từ khóa và tình trạng
        public List<CuDanDaiDien_DTO> TimKiemCuDan(string tuKhoa, string tinhTrang)
        {
            List<CuDanDaiDien_DTO> danhSachCuDan = new List<CuDanDaiDien_DTO>();
            // SQL Query để tìm kiếm theo nhiều trường (ID, HoTen, SoDienThoai, NgaySinh, GioiTinh, Email, TinhTrang)
            string query = @"
                    SELECT * FROM CuDanDaiDien
                    WHERE (ID_CuDan LIKE @TuKhoa
                    OR HoTen LIKE @TuKhoa
                    OR SoDienThoai LIKE @TuKhoa
                    OR NgaySinh LIKE @TuKhoa
                    OR GioiTinh LIKE @TuKhoa
                    OR Email LIKE @TuKhoa) AND TinhTrang = @TinhTrang
                ";


            using (SqlConnection cnn = DBConnect.Connect())
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                cmd.Parameters.AddWithValue("@TinhTrang", tinhTrang);

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CuDanDaiDien_DTO cuDan = new CuDanDaiDien_DTO
                    {
                        ID_CuDan = reader["ID_CuDan"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        TinhTrang = reader["TinhTrang"].ToString()
                    };
                    danhSachCuDan.Add(cuDan);
                }
            }
            return danhSachCuDan;
        }
    }
}
