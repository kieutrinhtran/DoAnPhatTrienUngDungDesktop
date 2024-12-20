using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThongBao_DAL
    {
        public List<ThongBao_DTO> LoadThongBao_DAL()
        {
            //Tạo danh sách (List) để chứa các dữ liệu lấy về từ DB
            var DSThongBao = new List<ThongBao_DTO>();

            //Kết nối với CSDL
            SqlConnection conn = DBConnect.Connect();
            conn.Open();

            string query = "SELECT ID_ThongBao, HoTen AS NguoiGui, TieuDe, NoiDung, NgayGui, TrangThai FROM ThongBao JOIN BanQuanLy ON ThongBao.NguoiGui = BanQuanLy.ID_BanQuanLy";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Đưa từng dòng dữ liệu từ Reader vào DTO
                var thongbao = new ThongBao_DTO
                {
                    ID_ThongBao = reader["ID_ThongBao"].ToString(),
                    NguoiGui = reader["NguoiGui"].ToString(),
                    TieuDe = reader["TieuDe"].ToString(),
                    NoiDung = reader["NoiDung"].ToString(),
                    NgayGui = reader["NgayGui"].ToString(),
                    TrangThai = reader["TrangThai"].ToString(),
                };

                //Đưa từng dòng dữ liệu từ DTO vào List
                DSThongBao.Add(thongbao);
            }
            conn.Close();
            return DSThongBao;
        }

        public void ThemThongBao(ThongBao_DTO thongbao)
        {
            SqlConnection conn = DBConnect.Connect();
            conn.Open();

            string query = @"INSERT INTO ThongBao (ID_ThongBao, NguoiGui, TieuDe, NoiDung, NgayGui, TrangThai)
                         VALUES (@ID_ThongBao, @NguoiGui, @TieuDe, @NoiDung, @NgayGui, @TrangThai)"; ;

            //Thuc hien cau truy van
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID_ThongBao", thongbao.ID_ThongBao);
            cmd.Parameters.AddWithValue("@NguoiGui", thongbao.NguoiGui);
            cmd.Parameters.AddWithValue("@TieuDe", thongbao.TieuDe);
            cmd.Parameters.AddWithValue("@NoiDung", thongbao.NoiDung);
            cmd.Parameters.AddWithValue("@NgayGui", DateTime.Parse(thongbao.NgayGui));
            cmd.Parameters.AddWithValue("@TrangThai", thongbao.TrangThai);

            cmd.ExecuteNonQuery();

            conn.Close();
        }


        public Dictionary<string, string> GetNguoiGuiList()
        {
            Dictionary<string, string> nguoiGuiList = new Dictionary<string, string>();
            string query = "SELECT ID_BanQuanLy, HoTen FROM BanQuanLy";

            SqlConnection conn = DBConnect.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string idNguoiGui = reader["ID_BanQuanLy"].ToString();
                string tenNguoiGui = reader["HoTen"].ToString();
                nguoiGuiList.Add(idNguoiGui, tenNguoiGui);
            }


            return nguoiGuiList;
        }

        public void CapNhatTrangThai(string idThongBao, string trangThai)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "UPDATE ThongBao SET TrangThai = @TrangThai WHERE ID_ThongBao = @ID_ThongBao";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@TrangThai", trangThai);
            cmd.Parameters.AddWithValue("@ID_ThongBao", idThongBao);
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        public void XoaThongBao_DAL(string iD_ThongBao)
        {
            //Kết nối CSDL 
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "DELETE FROM ChiTietThongBao WHERE ID_ThongBao = @ID_ThongBao";
            SqlCommand cmd = new SqlCommand(query, cnn);
            string query1 = "DELETE FROM ThongBao WHERE ID_ThongBao = @ID_ThongBao";
            SqlCommand cmd1 = new SqlCommand(query1, cnn);
            cmd.Parameters.AddWithValue("@ID_ThongBao", iD_ThongBao);
            cmd1.Parameters.AddWithValue("@ID_ThongBao", iD_ThongBao);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cnn.Close();
        }

        public bool KiemTraTonTai(ThongBao_DTO thongbao)
        {
            //Kết nối CSDL
            SqlConnection conn = DBConnect.Connect();
            conn.Open();

            string query = "Select Count(1) from ThongBao where ID_ThongBao = @ID_ThongBao";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID_ThongBao", thongbao.ID_ThongBao);

            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            return count > 0;
        }

        public void SuaThongBao(string iD_ThongBao, string nguoiGui, string tieuDe, string noiDung, string ngayGui)
        {

            //Kết nối CSDL
            SqlConnection conn = DBConnect.Connect();
            conn.Open();

            string query = "UPDATE ThongBao SET NguoiGui = @NguoiGui, TieuDe = @TieuDe, NoiDung = @NoiDung, NgayGui = @NgayGui WHERE ID_ThongBao = @ID_ThongBao";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ID_ThongBao", iD_ThongBao);
            command.Parameters.AddWithValue("@NguoiGui", nguoiGui);
            command.Parameters.AddWithValue("@TieuDe", tieuDe);
            command.Parameters.AddWithValue("@NoiDung", noiDung);
            command.Parameters.AddWithValue("@NgayGui", ngayGui);

            command.ExecuteNonQuery();
            conn.Close();
        }

        public List<ThongBao_DTO> LoadTB_DAL1()
        {
            var DSTB = new List<ThongBao_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT DISTINCT NguoiGui FROM ThongBao";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var thongbao = new ThongBao_DTO
                {

                    NguoiGui = reader["NguoiGui"].ToString()
                };
                DSTB.Add(thongbao);
            }
            cnn.Close();
            return DSTB;
        }

        public static List<ThongBao_DTO> SearchTB(string keyword)
        {
            List<ThongBao_DTO> danhSach = new List<ThongBao_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM ThongBao WHERE ID_ThongBao LIKE @keyword OR NguoiGui LIKE @keyword OR TieuDe LIKE @keyword OR NoiDung LIKE @keyword OR NgayGui LIKE @keyword OR TrangThai LIKE @keyword ";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new ThongBao_DTO
                {
                    ID_ThongBao = reader["ID_ThongBao"].ToString(),
                    NguoiGui = reader["NguoiGui"].ToString(),
                    TieuDe = reader["TieuDe"].ToString(),
                    NoiDung = reader["NoiDung"].ToString(),
                    NgayGui = reader["NgayGui"].ToString(),
                    TrangThai = reader["TrangThai"].ToString(),
                });



            }
            return danhSach;
        }

        

        public static List<ThongBao_DTO> GetTB(string keyword, string ngaybd, string ngaykt)
        {
            List<ThongBao_DTO> danhSach = new List<ThongBao_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            // Truy vấn để tìm kiếm theo từ khóa và khoảng ngày
            string query = "SELECT * FROM ThongBao WHERE NgayGui BETWEEN @NgayBD AND @NgayKT " +
                           "AND (ID_ThongBao LIKE @keyword OR NguoiGui LIKE @keyword OR TieuDe LIKE @keyword OR " +
                           "NoiDung LIKE @keyword OR TrangThai LIKE @keyword)";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            cmd.Parameters.AddWithValue("@NgayBD", ngaybd);
            cmd.Parameters.AddWithValue("@NgayKT", ngaykt);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new ThongBao_DTO
                {
                    ID_ThongBao = reader["ID_ThongBao"].ToString(),
                    NguoiGui = reader["NguoiGui"].ToString(),
                    TieuDe = reader["TieuDe"].ToString(),
                    NoiDung = reader["NoiDung"].ToString(),
                    NgayGui = reader["NgayGui"].ToString(),
                    TrangThai = reader["TrangThai"].ToString(),
                });
            }
            cnn.Close();
            return danhSach;
        }
        public static List<ThongBao_DTO> GetTBByngay(string ngaybd, string ngaykt)
        {
            List<ThongBao_DTO> danhSach = new List<ThongBao_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM ThongBao WHERE NgayGui BETWEEN @NgayBD AND @NgayKT ";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@NgayBD", ngaybd);
            cmd.Parameters.AddWithValue("@NgayKT", ngaykt);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new ThongBao_DTO
                {
                    ID_ThongBao = reader["ID_ThongBao"].ToString(),
                    NguoiGui = reader["NguoiGui"].ToString(),
                    TieuDe = reader["TieuDe"].ToString(),
                    NoiDung = reader["NoiDung"].ToString(),
                    NgayGui = reader["NgayGui"].ToString(),
                    TrangThai = reader["TrangThai"].ToString(),
                });



            }
            return danhSach;

        }


    }
}

