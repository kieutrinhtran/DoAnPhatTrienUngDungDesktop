using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TienIch_DAL
    {
        public void ChinhSuaTienIch(string ID_TienIch, string TenTienIch, string GioMo, string GioDong, string MoTa, string GiaTien)
        {
            //Kết nối CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "UPDATE TienIch SET TenTienIch = @TenTienIch, GioMo = @GioMo, GioDong = @GioDong, MoTa = @MoTa, GiaTien = @GiaTien WHERE ID_TienIch = @ID_TienIch";
            SqlCommand command = new SqlCommand(query, cnn);
            command.Parameters.AddWithValue("@ID_TienIch", ID_TienIch);
            command.Parameters.AddWithValue("@TenTienIch", TenTienIch);
            command.Parameters.AddWithValue("@GioMo", GioMo);
            command.Parameters.AddWithValue("@GioDong", GioDong);
            command.Parameters.AddWithValue("@MoTa", MoTa);
            command.Parameters.AddWithValue("@GiaTien", GiaTien);

            command.ExecuteNonQuery();
            cnn.Close();
        }


        public bool KiemTraTonTai(TienIch_DTO tienich)
        {
            //Kết nối CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "Select Count(1) from TienIch where ID_TienIch = @ID_TienIch";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_TienIch", tienich.ID_TienIch);

            int count = (int)cmd.ExecuteScalar();
            cnn.Close();
            return count > 0;
        }

        public List<TienIch_DTO> LoadTienIch_DAL()
        {
            //Tạo danh sách (List) để chứa các dữ liệu lấy về từ DB
            var DSTienIch = new List<TienIch_DTO>();

            //Kết nối với CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM TienIch";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Đưa từng dòng dữ liệu từ Reader vào DTO
                var tienich = new TienIch_DTO
                {
                    ID_TienIch = reader["ID_TienIch"].ToString(),
                    TenTienIch = reader["TenTienIch"].ToString(),
                    GioMo = reader["GioMo"].ToString(),
                    GioDong = reader["GioDong"].ToString(),
                    MoTa = reader["MoTa"].ToString(),
                    GiaTien = Convert.ToInt32(reader["GiaTien"])
                };

                //Đưa từng dòng dữ liệu từ DTO vào List
                DSTienIch.Add(tienich);
            }
            cnn.Close();
            return DSTienIch;

        }

        public void ThemTienIch(TienIch_DTO tienich, decimal gia)
        {
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "INSERT INTO TienIch (ID_TienIch, TenTienIch, GioMo, GioDong, MoTa, GiaTien)" + "VALUES (@ID_TienIch, @TenTienIch, @GioMo, @GioDong, @MoTa, @GiaTien)";

            //Thuc hien cau truy van
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_TienIch", tienich.ID_TienIch);
            cmd.Parameters.AddWithValue("@TenTienIch", tienich.TenTienIch);
            cmd.Parameters.AddWithValue("@GioMo", tienich.GioMo);
            cmd.Parameters.AddWithValue("@GioDong", tienich.GioDong);
            cmd.Parameters.AddWithValue("@MoTa", tienich.MoTa);
            cmd.Parameters.AddWithValue("@GiaTien", gia);

            cmd.ExecuteNonQuery();

            cnn.Close();
        }

        public void XoaTienIch_DAL(string iD_TienIch)
        {
            //Kết nối CSDL 
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "DELETE FROM TienIch WHERE ID_TienIch = @ID_TienIch";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_TienIch", iD_TienIch);

            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
