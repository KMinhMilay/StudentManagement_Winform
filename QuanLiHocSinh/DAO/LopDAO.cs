using System.Data;

namespace QuanLiHocSinh.DAO
{
    public class LopDAO
    {
        private static LopDAO instance;

        private LopDAO() { }

        public static LopDAO Instance
        {
            get
            {
                if (instance == null) instance = new LopDAO();
                return instance;
            }
            private set => instance = value;
        }

        public DataTable GetAll()
        {
            string query = "SELECT * FROM LOP";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
