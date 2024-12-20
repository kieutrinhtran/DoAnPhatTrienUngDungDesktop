using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThongKe_DAL
    {
        public List<ThongKe_DTO> LoadTK_DAL(object iD_CH)
        {
            //Tạo danh sách (List) để chứa các dữ liệu lấy về từ DB
            var TKCH = new List<ThongKe_DTO>();

            //Kết nối với CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT ID_ThongKe, TenKhoanPhi, TK.ID_CanHo, SoLuong, TK.TrangThai FROM ThongKeSuDung TK JOIN KhoanPhi KP ON TK.ID_KhoanPhi = KP.ID_KhoanPhi JOIN CanHo CH ON TK.ID_CanHo = CH.ID_CanHo Where TK.ID_CanHo = @ID_CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_CanHo", iD_CH);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Đưa từng dòng dữ liệu từ Reader vào DTO
                var ls = new ThongKe_DTO
                {
                    ID_ThongKe = reader["ID_ThongKe"].ToString(),
                    KhoanPhi = reader["TenKhoanPhi"].ToString(),
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    SoLuong = reader["SoLuong"].ToString(),
                    TrangThai = reader["TrangThai"].ToString(),
                };

                //Đưa từng dòng dữ liệu từ DTO vào List
                TKCH.Add(ls);
            }
            cnn.Close();
            return TKCH;
        }
    }
}
