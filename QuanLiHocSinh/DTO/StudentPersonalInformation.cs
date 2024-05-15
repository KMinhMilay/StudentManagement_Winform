using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHocSinh.DTO
{
    internal class StudentPersonalInformation
    {
        public StudentPersonalInformation()
        {
            this.id = "";
            this.lastname = "";
            this.firstname = "";
            this.birthdate = DateTime.Parse(DateTime.Now.ToString());
            this.gender = "";
            this.hometown = "";
            this.address = "";
            this.email = "";
            this.phoneNumber = "";
            this.parentPhoneNumber = "";
            this.parentName = "";
            this.teacherName = "";
            this.status = "";
            this.role = "";
            this.idClass = "";
        }
        public StudentPersonalInformation(DataRow data)
        {
            this.id = data["IDHS"].ToString();
            this.lastname = data["HO"].ToString();
            this.firstname = data["TEN"].ToString();
            this.birthdate = DateTime.Parse(data["NAMSINH"].ToString());
            this.gender = data["GIOITINH"].ToString();
            this.hometown = data["QUEQUAN"].ToString();
            this.address = data["DIACHI"].ToString();
            this.email = data["EMAIL"].ToString();
            this.phoneNumber = data["SDT"].ToString();
            this.parentPhoneNumber = data["SDTPH"].ToString();
            this.parentName = data["TENPH"].ToString();
            this.teacherName = data["TENGV"].ToString();
            this.status = data["TRANGTHAI"].ToString();
            this.role = data["TENCV"].ToString();
            this.idClass = data["IDLOP"].ToString();
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
        public string parentPhoneNumber { get; set; }
        public string parentName { get; set; }
        public string teacherName { get; set; }
        public string status { get; set; }
        public string role { get; set; }
        public string idClass { get; set; }
    }
}
