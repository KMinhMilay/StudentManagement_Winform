using LAB03_Nhom.DAO;
using QuanLiHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System;
//using System.Data;

namespace DAO
{
    public class DiemDAO
    {
        private static DiemDAO instance;

        private DiemDAO() { }

        public static DiemDAO Instance
        {
            get
            {
                if (instance == null) instance = new DiemDAO();
                return instance;
            }
            private set => instance = value;
        }

        public DataTable LayDanhSachDiem(string maHocSinh, string maMonHoc, string maHocKy, string maNamHoc, string maLop)
        {
            string query = "EXEC LayDanhSachDiem @maHocSinh , @maMonHoc , @maHocKy , @maNamHoc , @maLop";
            object[] parameters = new object[] { maHocSinh, maMonHoc, maHocKy, maNamHoc, maLop };
            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }

        public DataTable LayDanhSachDiemHocSinh(string maHocSinh, string maMonHoc, string maHocKy, string maNamHoc, string maLop)
        {
            string query = "EXEC LayDanhSachDiemHocSinh @maHocSinh , @maMonHoc , @maHocKy , @maNamHoc , @maLop";
            object[] parameters = new object[] { maHocSinh, maMonHoc, maHocKy, maNamHoc, maLop };
            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }

        public void ThemDiem(DiemDTO diem)
        {
            string query = "EXEC ThemDiem @maHocSinh , @maMonHoc , @maHocKy , @maNamHoc , @maLop , @maLoaiDiem , @diemSo";
            object[] parameters = new object[] { 
                diem.MaHocSinh, diem.MaMonHoc, diem.MaHocKy, diem.MaNamHoc, diem.MaLop, diem.MaLoaiDiem, diem.DiemSo 
            };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        public void XoaDiem(int stt)
        {
            string query = "EXEC XoaDiem @STT";
            object[] parameters = new object[] { stt };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }
    }
}
