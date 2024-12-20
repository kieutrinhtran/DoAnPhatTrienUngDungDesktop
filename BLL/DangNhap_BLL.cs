using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DangNhap_BLL
    {
        private readonly DangNhap_DAL userDAL = new DangNhap_DAL();

        // Phương thức kiểm tra đăng nhập với logic nghiệp vụ
        public bool ValidateLogin(string taikhoan, string matkhau)
        {
            if (string.IsNullOrWhiteSpace(taikhoan) || string.IsNullOrWhiteSpace(matkhau))
            {
                return false;
            }

            return userDAL.CheckLogin(taikhoan, matkhau);
        }
    }
}
