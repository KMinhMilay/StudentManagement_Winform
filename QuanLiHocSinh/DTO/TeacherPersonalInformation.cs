using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHocSinh.DTO
{
    internal class TeacherPersonalInformation
    {
        public TeacherPersonalInformation() {
            this.id = "";
            this.lastname = "";
            this.firstname = "";
            this.birthdate = DateTime.Parse(DateTime.Now.ToString());
            this.gender = "";
            this.hometown = "";
            this.address = "";
            this.email = "";
            this.phoneNumber = "";
            this.salary = "";
            this.subjectName = "";
            this.idHomeroomClass = "";
        }
        public TeacherPersonalInformation(DataRow data)
        {
            this.id = data["IDGV"].ToString();
            this.lastname = data["HO"].ToString();
            this.firstname = data["TEN"].ToString();
            this.birthdate = DateTime.Parse(data["NAMSINH"].ToString());
            this.gender = data["GIOITINH"].ToString();
            this.hometown = data["QUEQUAN"].ToString();
            this.address = data["DIACHI"].ToString();
            this.email = data["EMAIL"].ToString();
            this.phoneNumber = data["SDT"].ToString();
            this.salary = data["LUONG"].ToString();
            this.subjectName = data["TENMH"].ToString();
            this.idHomeroomClass = data["IDLOPCN"].ToString();
        }
        public string id { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public DateTime birthdate { get; set; }
        public string gender { get; set; }
        public string hometown { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string salary { get; set; }
        public string subjectName { get; set; }
        public string idHomeroomClass { get; set; }

    }
}
