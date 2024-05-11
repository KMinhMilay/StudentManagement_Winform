using System.Data;

namespace QuanLiHocSinh.DAO
{
    public class MonHocDAO
    {
        private static MonHocDAO instance;

        private MonHocDAO() { }

        public static MonHocDAO Instance
        {
            get
            {
                if (instance == null) instance = new MonHocDAO();
                return instance;
            }
            private set => instance = value;
        }

        public DataTable GetAll()
        {
            string query = "SELECT * FROM MONHOC";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
