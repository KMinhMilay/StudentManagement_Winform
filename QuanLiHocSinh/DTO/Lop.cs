using System.Data;

namespace QuanLiHocSinh.DTO
{
    public class Lop
    {
        public string IdLop { get; set; }
        public string TenLop { get; set; }
        public int SoLuong { get; set; }

        public Lop(DataRow row)
        {
            this.IdLop = row["IDLOP"].ToString();
            this.TenLop = row["TENLOP"].ToString();
            this.SoLuong = int.Parse(row["SOLUONG"].ToString());
        }
        public Lop()
        {

        }
    }
}
