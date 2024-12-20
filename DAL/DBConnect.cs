using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnect
    {
        public static SqlConnection Connect()
        {
            string Cnt = @"Data Source=KIZRIN\KIRSTIN;Initial Catalog=QLCC;Integrated Security=True;Encrypt=True";
            SqlConnection cnn = new SqlConnection(Cnt);
            return cnn;
        }
    }
}
