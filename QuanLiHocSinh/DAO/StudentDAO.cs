using QuanLiHocSinh.DAO;
using QuanLiHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLiHocSinh.DAO
{
    internal class StudentDAO
    {
        private static StudentDAO instance;

        public static StudentDAO Instance
        {
            get { if (instance == null) instance = new StudentDAO(); return instance; }
            private set { instance = value; }
        }
        private StudentDAO() { }

        public DataTable LoadStudentList(string userName, string role)
        {
            string query = "SP_GET_DANHSACHHOCSINH @UserRole , @UserName";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { role, userName });
            return result;
        }
        public DataTable LoadClassList()
        {
            string query = "SELECT IDLOP FROM LOP";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            return result;
        }
        public DataTable SearchStudentList(string studentId, string fullName, string className)
        {
            string query = "SearchStudents @StudentID , @FullName , @ClassName";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { studentId, fullName, className });
            return result;
        }
        public bool AddStudentList(string ho, string ten, DateTime namSinh, string gioiTinh, string queQuan, string diaChi, string email, string sdt, string maLop, string maChucVu, string maGiaoVien, string maTrangThai, string sdtPhuHuynh, string tenPhuHuynh)
        {
            string query = "SP_INS_HOCSINH_AUTO @HO , @TEN , @NAMSINH , @GIOITINH , @QUEQUAN , @DIACHI , @EMAIL , @SDT , @IDLOP , @IDCV , @IDGV , @IDTRANGTHAI , @SDTPH , @TENPH";
            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ho, ten, namSinh, gioiTinh, queQuan, diaChi, email, sdt, maLop, maChucVu, maGiaoVien, maTrangThai, sdtPhuHuynh, tenPhuHuynh });
            return rowsAffected >= 0;
        }
        public DataTable LoadTeacherByClass(string idLop)
        {
            string query = "SP_GET_GIAOVIEN_BY_LOP @IDLop";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { idLop });
            return result;
        }
        public DataTable LoadIdTeacher(string HoTen)
        {
            string query = "FindTeacherIDByFullName @HoTen";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { HoTen });
            return result;
        }
        public bool DeleteStudentByID(string IDHS, string IDGV)
        {
            string query = "DisableStudentByID @IDHS , @IDGV";
            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IDHS, IDGV});
            return rowsAffected >= 0;
        }
        public bool UpdateStudentByID(string IDHS, string Ho, string Ten, DateTime NamSinh, string GioiTinh, string QueQuan, string DiaChi, string Email, string SDT, string IDCV, string IDTRANGTHAI, string SDTPH, string TENPH, string IDGV)
        {
            string query = "UpdateStudentInfo @IDHS , @HO , @TEN , @NAMSINH , @GIOITINH , @QUEQUAN , @DIACHI , @EMAIL , @SDT , @IDCV , @IDTRANGTHAI , @SDTPH , @TENPH , @IDGV";
            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IDHS, Ho, Ten, NamSinh, GioiTinh, QueQuan, DiaChi, Email, SDT, IDCV, IDTRANGTHAI, SDTPH, TENPH, IDGV });
            return rowsAffected >= 0;
        }
        public bool UpdateClassStudentByID(string IDHS, string Ho, string Ten, DateTime NamSinh, string GioiTinh, string QueQuan, string DiaChi, string Email, string SDT,string IDLop, string IDCV, string IDGV, string SDTPH, string TENPH)
        {
            string query = "SP_DoiLopHocSinh @IDHS , @HO , @TEN , @NAMSINH , @GIOITINH , @QUEQUAN , @DIACHI , @EMAIL , @SDT , @IDLop , @IDCV , @IDGV , @SDTPH , @TENPH";
            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IDHS, Ho, Ten, NamSinh, GioiTinh, QueQuan, DiaChi, Email, SDT, IDLop, IDCV, IDGV, SDTPH, TENPH });
            return rowsAffected >= 0;
        }

    }
}
