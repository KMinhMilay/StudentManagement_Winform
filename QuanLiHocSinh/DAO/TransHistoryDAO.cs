using QuanLiHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLiHocSinh.DAO
{
    internal class TransHistoryDAO
    {
        private static TransHistoryDAO instance;

        public static TransHistoryDAO Instance
        {
            get { if (instance == null) instance = new TransHistoryDAO(); return instance; }
            private set { instance = value; }
        }
        private TransHistoryDAO() { }
        public DataTable getTHList()
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("SP_GetTranList");
            return dt;
        }
        public DataTable getValueTHList(string value)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("SP_GetTranListByText @textValue", [value]) ;
            return dt;
        }
    }
}
