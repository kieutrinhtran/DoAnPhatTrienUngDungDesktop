using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LichSu_DAL
    {
        public List<LichSuCanHo_DTO> LoadLS_DAL(string ID_CH)
        {
            //Tạo danh sách (List) để chứa các dữ liệu lấy về từ DB
            var LSCH = new List<LichSuCanHo_DTO>();

            //Kết nối với CSDL
            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();

            string query = "SELECT * FROM LichSuCanHo Where ID_CanHo = @ID_CanHo";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_CanHo", ID_CH);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Đưa từng dòng dữ liệu từ Reader vào DTO
                var ls = new LichSuCanHo_DTO
                {
                    ID_LichSuCanHo = reader["ID_LichSuCanHo"].ToString(),
                    ID_CuDanSoHuu = reader["CuDanSoHuu"].ToString(),
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    NgayDangKySoHuu = reader["NgayDangKySoHuu"].ToString(),
                    NgayKetThucSoHuu = reader["NgayKetThucSoHuu"].ToString(),
                };

                //Đưa từng dòng dữ liệu từ DTO vào List
                LSCH.Add(ls);
            }
            cnn.Close();
            return LSCH;
        }
    }
}
