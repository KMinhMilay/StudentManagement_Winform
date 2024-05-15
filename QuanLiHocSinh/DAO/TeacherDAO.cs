using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DataTable GetTeacherList()
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("SP_GetTeacherList");
            return dt;
        }
    }
}
