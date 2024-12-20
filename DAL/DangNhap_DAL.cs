using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DangNhap_DAL
    {
        // Dữ liệu tài khoản và mật khẩu cố định
        private readonly string CorrectTaikhoan = "nhom3";
        private readonly string CorrectMatkhau = "123456";

        // Phương thức kiểm tra tài khoản và mật khẩu
        public bool CheckLogin(string taikhoan, string matkhau)
        {
            return taikhoan == CorrectTaikhoan && matkhau == CorrectMatkhau;
        }
    }
}
