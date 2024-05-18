using QuanLiHocSinh.DTO;
using QuanLiHocSinh.DTO.ModelView;
using System.Data;

namespace QuanLiHocSinh.DAO
{
    public class XepLoaiDAO
    {
        private static XepLoaiDAO instance;

        public static XepLoaiDAO Instance
        {
            get { if (instance == null) instance = new XepLoaiDAO(); return instance; }
            private set { instance = value; }
        }
        private XepLoaiDAO() { }

        public List<XepLoaiModelView> GetAll()
        {
            string query = "exec Proc_GetXepLoai";
            List<XepLoaiModelView> list = new List<XepLoaiModelView>();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    XepLoaiModelView xl = new XepLoaiModelView(row);
                    list.Add(xl);
                }
            }
            return list;
        }

        public List<XepLoaiModelView> FilterData(string tenHs, string maLop, string hocLuc, string hanhKiem)
        {
            string query = "exec Proc_FilterXepLoai @tenhs , @malop , @hocluc , @hanhkiem";
            List<XepLoaiModelView> list = new List<XepLoaiModelView>();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { tenHs, maLop, hocLuc, hanhKiem });
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    XepLoaiModelView xl = new XepLoaiModelView(row);
                    list.Add(xl);
                }
            }
            return list;
        }

        public bool UpdateData(XepLoai xl)
        {
            string query = "exec Proc_XepLoai_Update @idxeploai , @hanhkiem , @hocluc";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { xl.IdXepLoai, xl.HanhKiem, xl.HocLuc }) > 0;
        }
    }
}
