using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhoanPhi_DAL
    {
        public bool KiemTraTonTai(KhoanPhi_DTO khoanphi)
        {
            //Kết nối CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "Select Count(1) from KhoanPhi where ID_KhoanPhi = @ID_KhoanPhi";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_KhoanPhi", khoanphi.ID_KhoanPhi);

            int count = (int)cmd.ExecuteScalar();
            cnn.Close();
            return count > 0;
        }


        public List<KhoanPhi_DTO> LoadKhoanPhi_DAL()
        {
            //Tạo danh sách (List) để chứa các dữ liệu lấy về từ DB
            var DSKhoanPhi = new List<KhoanPhi_DTO>();

            //Kết nối với CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM KhoanPhi";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Đưa từng dòng dữ liệu từ Reader vào DTO
                var khoanphi = new KhoanPhi_DTO
                {
                    ID_KhoanPhi = reader["ID_KhoanPhi"].ToString(),
                    TenKhoanPhi = reader["TenKhoanPhi"].ToString(),
                    DonGia = Convert.ToInt32(reader["DonGia"]),
                    ChuKy = reader["ChuKy"].ToString(),
                    TrangThai = reader["TrangThai"].ToString(),
                };

                //Đưa từng dòng dữ liệu từ DTO vào List
                DSKhoanPhi.Add(khoanphi);
            }
            cnn.Close();
            return DSKhoanPhi;

        }
        public List<string> LoadTrangThaiKhoanPhi()
        {
            // Danh sách để chứa giá trị trạng thái
            var dsTrangThai = new List<string>();

            // Kết nối với CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT DISTINCT TrangThai FROM KhoanPhi";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // Đưa từng giá trị vào danh sách
                dsTrangThai.Add(reader["TrangThai"].ToString());
            }

            cnn.Close();
            return dsTrangThai;
        }

        

        public void ThemKhoanPhi(KhoanPhi_DTO khoanphi, decimal gia)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "INSERT INTO KhoanPhi (ID_KhoanPhi, TenKhoanPhi, DonGia, ChuKy, TrangThai)" + "VALUES (@ID_KhoanPhi, @TenKhoanPhi, @DonGia, @ChuKy, @TrangThai)";

            //Thuc hien cau truy van
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_KhoanPhi", khoanphi.ID_KhoanPhi);
            cmd.Parameters.AddWithValue("@TenKhoanPhi", khoanphi.TenKhoanPhi);
            cmd.Parameters.AddWithValue("@DonGia", gia);
            cmd.Parameters.AddWithValue("@ChuKy", khoanphi.ChuKy);
            cmd.Parameters.AddWithValue("@TrangThai", khoanphi.TrangThai);

            cmd.ExecuteNonQuery();

            cnn.Close();
        }
        public void ChinhSuaKhoanPhi(KhoanPhi_DTO KhoanPhi, string txt_DonGia)
        {
            string query = "UPDATE KhoanPhi " + "SET TenKhoanPhi = @TenKhoanPhi, DonGia = @DonGia, ChuKy = @ChuKy, TrangThai = @TrangThai " +
                           "WHERE ID_KhoanPhi = @ID_KhoanPhi";

            using (SqlConnection cnn = DBConnect.Connect())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);

                // Gán tham số cho câu lệnh SQL
                cmd.Parameters.AddWithValue("@ID_KhoanPhi", KhoanPhi.ID_KhoanPhi);
                cmd.Parameters.AddWithValue("@TenKhoanPhi", KhoanPhi.TenKhoanPhi);
                cmd.Parameters.AddWithValue("@DonGia",txt_DonGia );
                cmd.Parameters.AddWithValue("@ChuKy", KhoanPhi.ChuKy);
                cmd.Parameters.AddWithValue("@TrangThai", KhoanPhi.TrangThai);

                // Thực thi câu lệnh
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        public void XoaKhoanPhi(string idKhoanPhi)
        {
            using (SqlConnection cnn = DBConnect.Connect())
            {
                cnn.Open();
                string query = "DELETE FROM KhoanPhi WHERE ID_KhoanPhi = @ID_KhoanPhi";
                SqlCommand command = new SqlCommand(query, cnn);
                command.Parameters.AddWithValue("@ID_KhoanPhi", idKhoanPhi);

                command.ExecuteNonQuery();
                cnn.Close();
            }
        }
        public List<KhoanPhi_DTO> TimKiemKhoanPhi(string keyword)
        {
            List<KhoanPhi_DTO> danhSach = new List<KhoanPhi_DTO>();
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string searchquery = @"SELECT * FROM KhoanPhi WHERE ID_KhoanPhi LIKE @keyword 
                                 OR TenKhoanPhi LIKE @keyword OR DonGia LIKE @keyword 
                                 OR ChuKy LIKE @keyword or TrangThai LIKE @keyword";

            SqlCommand cmd = new SqlCommand(searchquery, cnn);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            SqlDataReader searchreader = cmd.ExecuteReader();
            while (searchreader.Read())
            {
                danhSach.Add(new KhoanPhi_DTO
                {
                    ID_KhoanPhi = searchreader["ID_KhoanPhi"].ToString(),
                    TenKhoanPhi = searchreader["TenKhoanPhi"].ToString(),
                    DonGia = Convert.ToInt32(searchreader["DonGia"]),
                    ChuKy = searchreader["ChuKy"].ToString(),
                    TrangThai = searchreader["TrangThai"].ToString(),
                });
            }
            return danhSach;
        }

        public static List<KhoanPhi_DTO> SearchKhoanPhi_DAL(string keyword)
        {
            List<KhoanPhi_DTO> danhSach = new List<KhoanPhi_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM KhoanPhi WHERE ID_KhoanPhi LIKE @keyword OR TenKhoanPhi LIKE @keyword OR ChuKy LIKE @keyword OR TrangThai LIKE @keyword OR DonGia LIKE @keyword ";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new KhoanPhi_DTO
                {
                    ID_KhoanPhi = reader["ID_KhoanPhi"].ToString(),
                    TenKhoanPhi = reader["TenKhoanPhi"].ToString(),
                    DonGia = Convert.ToDecimal(reader["DonGia"]),
                    ChuKy = reader["ChuKy"].ToString(),
                    TrangThai = reader["TrangThai"].ToString()
                });



            }
            return danhSach;
        }

        

        public static List<KhoanPhi_DTO> GetKhoanPhi(string keyword, string trangthai)
        {
            List<KhoanPhi_DTO> danhSach = new List<KhoanPhi_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM KhoanPhi WHERE TrangThai = @TrangThai INTERSECT (SELECT * FROM KhoanPhi WHERE ID_KhoanPhi LIKE @keyword OR TenKhoanPhi LIKE @keyword OR ChuKy LIKE @keyword OR TrangThai LIKE @keyword OR DonGia LIKE @keyword )";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@TrangThai", trangthai);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new KhoanPhi_DTO
                {
                    ID_KhoanPhi = reader["ID_KhoanPhi"].ToString(),
                    TenKhoanPhi = reader["TenKhoanPhi"].ToString(),
                    DonGia = Convert.ToDecimal(reader["DonGia"]),
                    ChuKy = reader["ChuKy"].ToString(),
                    TrangThai = reader["TrangThai"].ToString()
                });



            }
            return danhSach;
        }

        public List<KhoanPhi_DTO> LoadChuKy()
        {
            // Danh sách để chứa giá trị chu kỳ
            var dsChuKy = new List<KhoanPhi_DTO>();

            // Kết nối với CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT DISTINCT ChuKy FROM KhoanPhi";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // Đưa từng giá trị vào danh sách
                var dschuky = new KhoanPhi_DTO
                {

                    ChuKy = reader["ChuKy"].ToString()
                };
                dsChuKy.Add(dschuky);
            }

            cnn.Close();
            return dsChuKy;
        }
        private string connectstring = @"Data Source=DESKTOP-DUUE3UH\ZRPPROACE;Initial Catalog=QLCCU;Integrated Security=True;Encrypt=False";

        public List<string> LoadChuKyKhoanPhi()
        {
            var list = new List<string>();

            using (SqlConnection cnn = new SqlConnection(connectstring))
            {
                cnn.Open();
                string query = "SELECT DISTINCT ChuKy FROM KhoanPhi";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader["ChuKy"].ToString());
                }
            }

            return list;
        }

        public List<string> LoadTrangThai()
        {
            var list = new List<string>();

            using (SqlConnection cnn = new SqlConnection(connectstring))
            {
                cnn.Open();
                string query = "SELECT DISTINCT TrangThai FROM KhoanPhi";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader["TrangThai"].ToString());
                }
            }

            return list;
        }

        public static List<KhoanPhi_DTO> GetKhoanPhi(string trangthai)
        {
            List<KhoanPhi_DTO> danhSach = new List<KhoanPhi_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM KhoanPhi WHERE TrangThai = @TrangThai";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@TrangThai", trangthai);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new KhoanPhi_DTO
                {
                    ID_KhoanPhi = reader["ID_KhoanPhi"].ToString(),
                    TenKhoanPhi = reader["TenKhoanPhi"].ToString(),
                    DonGia = Convert.ToDecimal(reader["DonGia"]),
                    ChuKy = reader["ChuKy"].ToString(),
                    TrangThai = reader["TrangThai"].ToString()
                });



            }
            return danhSach;
        }

        public static List<KhoanPhi_DTO> SearchTB(string keyword)
        {
            throw new NotImplementedException();
        }

        public static List<KhoanPhi_DTO> GetTBByngaygui(string ngaygui)
        {
            throw new NotImplementedException();
        }

        public static List<KhoanPhi_DTO> GetTB(string keyword, string ngaygui)
        {
            throw new NotImplementedException();
        }
    }
}
