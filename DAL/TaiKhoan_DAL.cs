using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoan_DAL
    {
        public void ChinhSuaTK(TaiKhoan_DTO tK)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "UPDATE TaiKhoanCanHo SET ID_TaiKhoan = @ID_TaiKhoan, ID_CanHo=@ID_CanHo, TenDangNhap = @TenDangnhap, Matkhau = @Matkhau WHERE ID_TaiKhoan = @ID_TaiKhoan";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_TaiKhoan", tK.ID_TaiKhoan);
            cmd.Parameters.AddWithValue("@ID_CanHo", tK.ID_CanHo);
            cmd.Parameters.AddWithValue("@TenDangnhap", tK.TenDangNhap);
            cmd.Parameters.AddWithValue("@Matkhau", tK.MatKhau);

            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public bool KiemTraTonTai(TaiKhoan_DTO tK)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT COUNT(1) FROM TaiKhoanCanHo where ID_TaiKhoan = @ID_TaiKhoan";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_TaiKhoan", tK.ID_TaiKhoan);
            int count = (int)cmd.ExecuteScalar();
            cnn.Close();
            return count > 0;
        }

        public bool KiemTraTonTai(string cbb_IDCH)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT COUNT(1) FROM TaiKhoanCanHo where ID_CanHo = @ID_CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_CanHo", cbb_IDCH);
            int count = (int)cmd.ExecuteScalar();
            cnn.Close();
            return count > 0;
        }

       

        public List<TaiKhoan_DTO> LoadTK_DAL()
        {
            var DSTK = new List<TaiKhoan_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT * FROM TaiKhoanCanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var taikhoan = new TaiKhoan_DTO
                {
                    ID_TaiKhoan = reader["ID_TaiKhoan"].ToString(),
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    TenDangNhap = reader["TenDangNhap"].ToString(),
                    MatKhau = reader["MatKhau"].ToString()
                };
                DSTK.Add(taikhoan);
            }
            cnn.Close();
            return DSTK;
        }

        public void ThemTK(TaiKhoan_DTO taikhoan)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "INSERT INTO TaiKhoanCanHo (ID_TaiKhoan, ID_CanHo, TenDangNhap, MatKhau)" + "VALUES (@ID_TaiKhoan, @ID_CanHo, @TenDangNhap, @MatKhau)";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_TaiKhoan", taikhoan.ID_TaiKhoan);
            cmd.Parameters.AddWithValue("@ID_CanHo", taikhoan.ID_CanHo);
            cmd.Parameters.AddWithValue("@TenDangNhap", taikhoan.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", taikhoan.MatKhau);
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
    }
}
