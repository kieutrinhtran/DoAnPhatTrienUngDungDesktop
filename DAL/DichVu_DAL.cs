using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DichVu_DAL
    {
        public static List<DichVu_DTO> GetThe(string keyword, string loaithe)
        {
            List<DichVu_DTO> danhSach = new List<DichVu_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM The WHERE LoaiThe = @LoaiThe INTERSECT (SELECT * FROM The WHERE ID_CanHo LIKE @keyword OR ID_The LIKE @keyword  OR TinhTrang LIKE @keyword OR LoaiThe LIKE @keyword OR LoaiXe LIKE @keyword OR BienSoXe LIKE @keyword)";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@LoaiThe", loaithe);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new DichVu_DTO
                {
                    ID_The = reader["ID_The"].ToString(),
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    TinhTrang = reader["TinhTrang"].ToString(),
                    LoaiThe = reader["LoaiThe"].ToString(),
                    LoaiXe = reader["LoaiXe"].ToString(),
                    BienSoXe = reader["BienSoXe"].ToString(),
                });
            }
            return danhSach;
        }

        public static List<DichVu_DTO> GetTheByLoai(string loaithe)
        {
            List<DichVu_DTO> danhSach = new List<DichVu_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM The WHERE LoaiThe = @LoaiThe";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@LoaiThe", loaithe);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new DichVu_DTO
                {
                    ID_The = reader["ID_The"].ToString(),
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    TinhTrang = reader["TinhTrang"].ToString(),
                    LoaiThe = reader["LoaiThe"].ToString(),
                    LoaiXe = reader["LoaiXe"].ToString(),
                    BienSoXe = reader["BienSoXe"].ToString(),
                });



            }
            return danhSach;
        }

        public static List<DichVu_DTO> SearchThe_DAL(string keyword)
        {
            List<DichVu_DTO> danhSach = new List<DichVu_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM The WHERE ID_CanHo LIKE @keyword OR ID_The LIKE @keyword OR TinhTrang LIKE @keyword OR LoaiThe LIKE @keyword OR LoaiXe LIKE @keyword OR BienSoXe LIKE @keyword";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new DichVu_DTO
                {
                    ID_The = reader["ID_The"].ToString(),
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    TinhTrang = reader["TinhTrang"].ToString(),
                    LoaiThe = reader["LoaiThe"].ToString(),
                    LoaiXe = reader["LoaiXe"].ToString(),
                    BienSoXe = reader["BienSoXe"].ToString(),
                });



            }
            return danhSach;
        }

        public void ChinhSuaDichVu(string iD_The, string iD_CanHo, string tinhTrang, string loaiThe, string loaiXe, string bienSoXe)
        {
            //Kết nối CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "UPDATE The SET ID_CanHo = @ID_CanHo, TinhTrang = @TinhTrang, LoaiThe = @LoaiThe, LoaiXe = @LoaiXe, BienSoXe = @BienSoXe WHERE ID_The = @ID_The";
            SqlCommand command = new SqlCommand(query, cnn);
            command.Parameters.AddWithValue("@ID_The", iD_The);
            command.Parameters.AddWithValue("@ID_CanHo", iD_CanHo);
            command.Parameters.AddWithValue("@TinhTrang", tinhTrang);
            command.Parameters.AddWithValue("@LoaiThe", loaiThe);
            command.Parameters.AddWithValue("@LoaiXe", loaiXe);
            command.Parameters.AddWithValue("@BienSoxe", bienSoXe);

            command.ExecuteNonQuery();
            cnn.Close();
        }

        public bool KiemTraTonTai(DichVu_DTO dichvu)
        {
            //Kết nối CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "Select Count(1) from The where ID_The = @ID_The";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_The", dichvu.ID_The);

            int count = (int)cmd.ExecuteScalar();
            cnn.Close();
            return count > 0;
        }

        public List<DichVu_DTO> LoadCH_DAL()
        {
            var DSDichVu = new List<DichVu_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT DISTINCT ID_CanHo FROM The";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var DichVu = new DichVu_DTO
                {

                    ID_CanHo = reader["ID_CanHo"].ToString()
                };
                DSDichVu.Add(DichVu);
            }
            cnn.Close();
            return DSDichVu;
        }

        public List<DichVu_DTO> LoadDichVu_DAL()
        {
            //Tạo danh sách (List) để chứa các dữ liệu lấy về từ DB
            var DSDichVu = new List<DichVu_DTO>();

            //Kết nối với CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM The";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Đưa từng dòng dữ liệu từ Reader vào DTO
                var dichvu = new DichVu_DTO
                {
                    ID_The = reader["ID_The"].ToString(),
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    TinhTrang = reader["TinhTrang"].ToString(),
                    LoaiThe = reader["LoaiThe"].ToString(),
                    LoaiXe = reader["LoaiXe"].ToString(),
                    BienSoXe = reader["BienSoXe"].ToString()
                    
                };

                //Đưa từng dòng dữ liệu từ DTO vào List
                DSDichVu.Add(dichvu);
            }
            cnn.Close();
            return DSDichVu;
        }

        public List<DichVu_DTO> LoadLoaiThe_DAL()
        {
            var DSDichVu3 = new List<DichVu_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT DISTINCT LoaiThe FROM The";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var DichVu = new DichVu_DTO
                {

                    LoaiThe = reader["LoaiThe"].ToString()
                };
                DSDichVu3.Add(DichVu);
            }
            cnn.Close();
            return DSDichVu3;
        }

        public List<DichVu_DTO> LoadLoaiXe_DAL()
        {
            var DSDichVu1 = new List<DichVu_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT DISTINCT LoaiXe FROM The WHERE LoaiXe IS NOT NULL AND TRIM(LoaiXe) <> ''";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var DichVu = new DichVu_DTO
                {

                    LoaiXe = reader["LoaiXe"].ToString()
                };
                DSDichVu1.Add(DichVu);
            }
            cnn.Close();
            return DSDichVu1;
        }

        public List<DichVu_DTO> LoadTT_DAL()
        {
            var DSDichVu2 = new List<DichVu_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT DISTINCT TinhTrang FROM The";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var DichVu = new DichVu_DTO
                {

                    TinhTrang = reader["TinhTrang"].ToString()
                };
                DSDichVu2.Add(DichVu);
            }
            cnn.Close();
            return DSDichVu2;
        }

        public void ThemDichVu(DichVu_DTO dichvu)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "INSERT INTO The (ID_The, ID_CanHo, TinhTrang, LoaiThe, LoaiXe, BienSoXe)" + "VALUES (@ID_The, @ID_CanHo, @TinhTrang, @LoaiThe, @LoaiXe, @BienSoXe)";

            //Thuc hien cau truy van
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_The", dichvu.ID_The);
            cmd.Parameters.AddWithValue("@ID_CanHo", dichvu.ID_CanHo);
            cmd.Parameters.AddWithValue("@TinhTrang", dichvu.TinhTrang);
            cmd.Parameters.AddWithValue("@LoaiThe", dichvu.LoaiThe);
            cmd.Parameters.AddWithValue("@LoaiXe", dichvu.LoaiXe);
            cmd.Parameters.AddWithValue("@BienSoXe", dichvu.BienSoXe);

            cmd.ExecuteNonQuery();

            cnn.Close();
        }

        public List<DichVu_DTO> TimKiemDichVu(string keyword)
        {
            List<DichVu_DTO> danhSach = new List<DichVu_DTO>();
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string searchquery = @"SELECT * FROM The WHERE ID_The LIKE @keyword 
                                 OR ID_CanHo LIKE @keyword OR TinhTrang LIKE @keyword 
                                 OR LoaiThe LIKE @keyword or LoaiXe LIKE @keyword or BienSoXe LIKE @keyword";

            SqlCommand cmd = new SqlCommand(searchquery, cnn);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            SqlDataReader searchreader = cmd.ExecuteReader();
            while (searchreader.Read())
            {
                danhSach.Add(new DichVu_DTO
                {
                    ID_The = searchreader["ID_KhoanPhi"].ToString(),
                    ID_CanHo = searchreader["ID_CanHo"].ToString(),
                    TinhTrang = searchreader["TinhTrang"].ToString(),
                    LoaiThe = searchreader["LoaiThe"].ToString(),
                    LoaiXe = searchreader["LoaiXe"].ToString(),
                    BienSoXe = searchreader["BienSoXe"].ToString()
                });
            }
            return danhSach;
        }

        public void XoaDichVu(string iD_The)
        {
            //Kết nối CSDL 
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "DELETE FROM The WHERE ID_The = @ID_The";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_The", iD_The);

            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
