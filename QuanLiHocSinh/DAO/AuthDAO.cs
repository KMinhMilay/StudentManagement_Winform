using LAB03_Nhom.DAO;
using QuanLiHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHocSinh.DAO
{
    internal class AuthDAO
    {
        private static AuthDAO instance;

        public static AuthDAO Instance
        {
            get { if (instance == null) instance = new AuthDAO(); return instance; }
            private set { instance = value; }
        }
        private AuthDAO() { }

        public Account GetAccount(string username, string password, string role)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SP_Login @username , @password , @role", [username, password, role]);

            if (data.Rows.Count > 0 )
            {
                return new Account(data.Rows[0]);
            }
            return null;
        }
    }
}
