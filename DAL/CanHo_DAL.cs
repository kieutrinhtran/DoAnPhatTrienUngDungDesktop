using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CanHo_DAL
    {
        public static List<CanHo_DTO> GetCanHo(string keyword, string loaicanho)
        {
            List<CanHo_DTO> danhSach = new List<CanHo_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM CanHo WHERE LoaiCanHo = @LoaiCanHo INTERSECT (SELECT * FROM CanHo WHERE ID_CanHo LIKE @keyword OR SoCanHo LIKE @keyword OR LoaiCanHo LIKE @keyword OR TinhTrang LIKE @keyword OR Tang LIKE @keyword OR DienTich LIKE @keyword or Gia LIKE @keyword)";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@LoaiCanHo", loaicanho);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new CanHo_DTO
                {
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    SoCanHo = reader["SoCanHo"].ToString(),
                    Tang = reader["Tang"].ToString(),
                    LoaiCanHo = reader["LoaiCanHo"].ToString(),
                    DienTich = reader["DienTich"].ToString(),
                    Gia = reader["Gia"].ToString(),
                    TinhTrang = reader["TinhTrang"].ToString()
                });



            }
            return danhSach;
        }

        public static List<CanHo_DTO> GetCanHoByLoai(string loaicanho)
        {
            List<CanHo_DTO> danhSach = new List<CanHo_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM CanHo WHERE LoaiCanHo = @LoaiCanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@LoaiCanHo", loaicanho);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new CanHo_DTO
                {
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    SoCanHo = reader["SoCanHo"].ToString(),
                    Tang = reader["Tang"].ToString(),
                    LoaiCanHo = reader["LoaiCanHo"].ToString(),
                    DienTich = reader["DienTich"].ToString(),
                    Gia = reader["Gia"].ToString(),
                    TinhTrang = reader["TinhTrang"].ToString()
                });



            }
            return danhSach;
        }

        

        public static List<CanHo_DTO> SearchCanHo_DAL(string keyword)
        {
            List<CanHo_DTO> danhSach = new List<CanHo_DTO>();


            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM CanHo WHERE ID_CanHo LIKE @keyword OR LoaiCanHo LIKE @keyword OR TinhTrang LIKE @keyword OR Tang LIKE @keyword OR DienTich LIKE @keyword or Gia LIKE @keyword";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(new CanHo_DTO
                {
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    SoCanHo = reader["SoCanHo"].ToString(),
                    Tang = reader["Tang"].ToString(),
                    LoaiCanHo = reader["LoaiCanHo"].ToString(),
                    DienTich = reader["DienTich"].ToString(),
                    Gia = reader["Gia"].ToString(),
                    TinhTrang = reader["TinhTrang"].ToString()
                });



            }
            return danhSach;
        }

        public void ChinhSuaCanHo(CanHo_DTO canHo)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "UPDATE CanHo SET ID_CanHo = @ID_CanHo, SoCanHo = @SoCanHo, Tang = @Tang, LoaiCanHo = @LoaiCanHo, DienTich = @DienTich, Gia = @Gia,  TinhTrang = @TinhTrang WHERE ID_CanHo = @ID_CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_CanHo", canHo.ID_CanHo);
            cmd.Parameters.AddWithValue("@SoCanHo", canHo.SoCanHo);
            cmd.Parameters.AddWithValue("@Tang", canHo.Tang);
            cmd.Parameters.AddWithValue("@LoaiCanHo", canHo.LoaiCanHo);
            cmd.Parameters.AddWithValue("@DienTich", canHo.DienTich);
            cmd.Parameters.AddWithValue("@Gia", canHo.Gia);
            cmd.Parameters.AddWithValue("@TinhTrang", canHo.TinhTrang);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public bool KiemTraTonTai(CanHo_DTO canHo)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT COUNT(1) FROM CanHo where ID_CanHo = @ID_CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_CanHo", canHo.ID_CanHo);
            int count = (int)cmd.ExecuteScalar();
            cnn.Close();
            return count >0;
        }

        

        public List<CanHo_DTO> LoadCanHo_DAL()
        {
            var DSCanHo = new List<CanHo_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT * FROM CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var canho = new CanHo_DTO
                {
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    SoCanHo = reader["SoCanHo"].ToString(),
                    Tang = reader["Tang"].ToString(),
                    LoaiCanHo = reader["LoaiCanHo"].ToString(),
                    DienTich = reader["DienTich"].ToString(),
                    Gia = reader["Gia"].ToString(),
                    TinhTrang = reader["TinhTrang"].ToString(),
                };
                DSCanHo.Add(canho);
            }
            cnn.Close();
            return DSCanHo;
        }

        public List<CanHo_DTO> LoadCanHo_DAL1()
        {
            var DSCanHo = new List<CanHo_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT DISTINCT LoaiCanHo FROM CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var canho = new CanHo_DTO
                {

                    LoaiCanHo = reader["LoaiCanHo"].ToString()
                };
                DSCanHo.Add(canho);
            }
            cnn.Close();
            return DSCanHo;
        }

        public List<CanHo_DTO> LoadCHDV()
        {
            var DSCHTK = new List<CanHo_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT DISTINCT ID_CanHo FROM CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var canho = new CanHo_DTO
                {

                    ID_CanHo = reader["ID_CanHo"].ToString()
                };
                DSCHTK.Add(canho);
            }
            cnn.Close();
            return DSCHTK;
        }

        public List<CanHo_DTO> LoadCHTK_DAL()
        {
            var DSCHTK = new List<CanHo_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT DISTINCT ID_CanHo FROM CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var canho = new CanHo_DTO
                {

                    ID_CanHo = reader["ID_CanHo"].ToString()
                };
                DSCHTK.Add(canho);
            }
            cnn.Close();
            return DSCHTK;
        }

        public List<CanHo_DTO> LoadLoai()
        {
            var DSLoaiCanHo = new List<CanHo_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT DISTINCT LoaiCanHo FROM CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var CanHo = new CanHo_DTO
                {

                    LoaiCanHo= reader["LoaiCanHo"].ToString()
                };
                DSLoaiCanHo.Add(CanHo);
            }
            cnn.Close();
            return DSLoaiCanHo;
        }

        public List<CanHo_DTO> LoadTT()
        {
            var DSTT = new List<CanHo_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT DISTINCT TinhTrang FROM CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var CanHo = new CanHo_DTO
                {

                    TinhTrang = reader["TinhTrang"].ToString()
                };
                DSTT.Add(CanHo);
            }
            cnn.Close();
            return DSTT;
        }

        public void ThemCanHo(CanHo_DTO canHo)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = @"INSERT INTO CanHo (ID_CanHo, SoCanHo, Tang, LoaiCanHo, DienTich, Gia, TinhTrang)" + "VALUES (@ID_CanHo, @SoCanHo, @Tang, @LoaiCanHo, @DienTich, @Gia, @TinhTrang)";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_CanHo", canHo.ID_CanHo);
            cmd.Parameters.AddWithValue("@SoCanHo", canHo.SoCanHo);
            cmd.Parameters.AddWithValue("@Tang", canHo.Tang);
            cmd.Parameters.AddWithValue("@LoaiCanHo", canHo.LoaiCanHo);
            cmd.Parameters.AddWithValue("@DienTich", canHo.DienTich);
            cmd.Parameters.AddWithValue("@Gia", canHo.Gia);
            cmd.Parameters.AddWithValue("@TinhTrang", canHo.TinhTrang);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

       
    }
}
