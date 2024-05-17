using QuanLiHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLiHocSinh.DAO
{
    internal class TeacherDAO
    {
        private static TeacherDAO instance;

        public static TeacherDAO Instance
        {
            get { if (instance == null) instance = new TeacherDAO(); return instance; }
            private set { instance = value; }
        }
        private TeacherDAO() { }

        public List<TeacherPersonalInformation> GetTeacherList()
        {
            List<TeacherPersonalInformation> list = new List<TeacherPersonalInformation> ();
            DataTable dt = DataProvider.Instance.ExecuteQuery("SP_GetTeacherList");
            foreach (DataRow dataRow in dt.Rows)
            {
                TeacherPersonalInformation teacher = new TeacherPersonalInformation(dataRow);
                list.Add(teacher);
            }
            return list;
        }
        public List<string> GetClassIdList()
        {
            List<string> list = new List<string>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("SP_GetClassList");
            foreach (DataRow data in dt.Rows)
            {
                list.Add(data[0].ToString());
            }
            return list;
        }
        public List<string> GetSubjectList()
        {
            List<string> list = new List<string>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("SP_GetSubjectList");
            foreach (DataRow data in dt.Rows)
            {
                list.Add(data[0].ToString());
            }
            return list;
        }
        public bool DeleteTeacherSuccess(string id)
        {
            return DataProvider.Instance.ExecuteNonQuery("SP_DeleteTeacher @id", [id]) > 0;
        }
        public bool UpdateTeacherSuccess(string id, string lastname, string firstname, DateTime birthdate, string gender, string hometown, string address, string email, string phoneNumber, string idHomeroomClass, int salary, string subjectName)
        {
            return DataProvider.Instance.ExecuteNonQuery("SP_UpdateTeacherInfo_ByAdmin @id , @lastname , @firstname , @birthdate , @gender , @hometown , @address , @email , @phoneNumber , @idHomeroomClass , @salary , @subjectName", [id, lastname, firstname, birthdate, gender, hometown, address, email, phoneNumber, idHomeroomClass, salary, subjectName]) > 0;
        }
        public bool AddTeacherSuccess(string id, string lastname, string firstname, DateTime birthdate, string gender, string hometown, string address, string email, string phoneNumber, string idHomeroomClass, int salary, string subjectName)
        {
            return DataProvider.Instance.ExecuteNonQuery("SP_AddTeacherInfo_ByAdmin @id , @lastname , @firstname , @birthdate , @gender , @hometown , @address , @email , @phoneNumber , @idHomeroomClass , @salary , @subjectName", [id, lastname, firstname, birthdate, gender, hometown, address, email, phoneNumber, idHomeroomClass, salary, subjectName]) > 0;
        }
    }
}
