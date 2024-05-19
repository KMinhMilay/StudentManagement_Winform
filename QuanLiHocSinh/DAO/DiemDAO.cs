using DTO;
using QuanLiHocSinh.DTO.ModelView;
using System.Data;
//using System.Data;

namespace QuanLiHocSinh.DAO
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

        public List<DiemModelView> GetAll(string userRole, string userName)
        {
            string query = "exec Proc_GetDiem @UserRole , @UserName";
            List<DiemModelView> list = new List<DiemModelView>();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] {userRole, userName});
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    DiemModelView diem = new DiemModelView(row);
                    list.Add(diem);
                }
            }
            return list;
        }
        public List<DiemModelView> FilterData(string tenHs, string maLop, string maMon)
        {
            string query = "exec Proc_GetDiem_Filter @tenhs , @malop , @mamon";
            List<DiemModelView> list = new List<DiemModelView>();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { tenHs, maLop, maMon });
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    DiemModelView diem = new DiemModelView(row);
                    list.Add(diem);
                }
            }

            return list;
        }

        public bool UpdateDiem(string idDiem, float diemQT, float diemGK, float diemCK, string idgv)
        {
            string query = "exec Proc_Diem_Update @iddiem , @diemqt , @diemgk , @diemck , @idgv";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idDiem, diemQT, diemGK, diemCK, idgv }) > 0;
        }
    }
}
