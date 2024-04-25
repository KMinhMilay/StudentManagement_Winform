using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHocSinh.DTO
{
    public class Account
    {
        public Account(string id, string username, string idClass, string accountType, string role) {
            this.id = id;
            this.username = username;
            this.idClass = idClass;
            this.accountType = accountType;
            this.role = role;
        }

        public Account(DataRow data)
        {
            this.id = data["ID"].ToString();
            this.username = data["TENDN"].ToString();
            this.idClass = data["LOP"].ToString();
            this.accountType = data["LOAITAIKHOAN"].ToString();
            this.role = data["CHUCVU"].ToString();
        }
        public string id { get; set; }
        public string username { get; set; }
        public string idClass { get; set; }
        public string accountType { get; set; }
        public string role { get; set; }
    }
}
