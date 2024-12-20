using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDon_DAL
    {
        public List<HoaDon_DTO> LoadTK_DAL()
        {
            var HoaDon = new List<HoaDon_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT * FROM HOADON";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var hoaDon = new HoaDon_DTO
                {
                    ID_HoaDon = reader["ID_HoaDon"].ToString(),
                    ID_CanHo = reader["ID_CanHo"].ToString(),
                    TenHoaDon = reader["TenHoaDon"].ToString(),
                    LoaiHoaDon = reader["LoaiHoaDon"].ToString(),
                    TrangThai = reader["TrangThai"].ToString(),
                    TongTien = reader["TongTien"].ToString(),
                    NgayLapHoaDon = reader["NgayLapHoaDon"].ToString(),
                };
                HoaDon.Add(hoaDon);
            }
            cnn.Close();
            return HoaDon;
        }

        public List<CTHD_DTO> LoadTK_DAL1(string idhoadon)
        {
            var ChiTiet = new List<CTHD_DTO>();

            SqlConnection cnn = DBConnect.Connect();
            cnn.Open();
            string query = "SELECT * FROM ChiTietHoaDon JOIN\r\nHoaDon ON ChiTietHoaDon.ID_HoaDon = HoaDon.ID_HoaDon JOIN\r\nThongKeSuDung ON ChiTietHoaDon.ID_ThongKe = ThongKeSuDung.ID_ThongKe JOIN\r\nKhoanPhi ON ThongKeSuDung.ID_KhoanPhi = KhoanPhi.ID_KhoanPhi WHERE  HoaDon.ID_HoaDon = @ID_HoaDon";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@ID_HoaDon",idhoadon);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
                {
                    var Chitiet = new CTHD_DTO
                    {
                        ID_ChiTietHoaDon = reader["ID_ChiTietHoaDon"].ToString(),
                        ID_HoaDon = reader["ID_HoaDon"].ToString(),
                        ID_CanHo = reader["ID_CanHo"].ToString(),
                        TenHoaDon = reader["TenHoaDon"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        NgayLapHoaDon = reader["NgayLapHoaDon"].ToString(),
                        ID_Thongke = reader["ID_Thongke"].ToString(),
                        TenKhoanPhi = reader["TenKhoanPhi"].ToString(),
                        SoLuong = reader["SoLuong"].ToString(),
                        DonGia = reader["DonGia"].ToString()
                    };
                    ChiTiet.Add(Chitiet);
                }
                reader.Close();
                cnn.Close();
                return ChiTiet;
            }
        }

        
    }

