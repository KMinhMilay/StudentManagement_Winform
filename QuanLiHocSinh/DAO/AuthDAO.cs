using LAB03_Nhom.DAO;
using QuanLiHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        public StudentPersonalInformation GetStudentPersonalInfo(string id)
        {
            DataTable data;

            data = DataProvider.Instance.ExecuteQuery("SP_GetStudentPersonalInfo @id", [id]);

            if (data.Rows.Count > 0)
            {
                return new StudentPersonalInformation(data.Rows[0]);
            }
            return null;
        }
        public TeacherPersonalInformation GetTeacherPersonalInfo(string id)
        {
            DataTable data;

            data = DataProvider.Instance.ExecuteQuery("SP_GetTeacherPersonalInfo @id", [id]);

            if (data.Rows.Count > 0)
            {
                return new TeacherPersonalInformation(data.Rows[0]);
            }
            return null;
        }
        public bool UpdateStudentPersonalInfoSuccess(string id, string lastname, string firstname, DateTime birthdate, string gender, string hometown, string address, string email, string phoneNumber, string parentName, string parentPhoneNumber)
        {
            return DataProvider.Instance.ExecuteNonQuery("SP_UpdateStudentPersonalInfo @id , @lastname , @firstname , @birthdate , @gender , @hometown , @address , @email , @phoneNumber , @parentName , @parentPhoneNumber", [id, lastname, firstname, birthdate, gender, hometown, address, email, phoneNumber, parentName, parentPhoneNumber]) > 0;
        }
        public bool UpdateTeacherPersonalInfoSuccess(string id, string lastname, string firstname, DateTime birthdate, string gender, string hometown, string address, string email, string phoneNumber)
        {
            return DataProvider.Instance.ExecuteNonQuery("SP_UpdateTeacherPersonalInfo @id , @lastname , @firstname , @birthdate , @gender , @hometown , @address , @email , @phoneNumber", [id, lastname, firstname, birthdate, gender, hometown, address, email, phoneNumber]) > 0;
        }
        public bool changePasswordSuccess(string id, string password, string accountType)
        {
            return DataProvider.Instance.ExecuteNonQuery("SP_ChangePassword @id , @password , @accountType", [id, password, accountType]) > 0;
        }
    }
}
