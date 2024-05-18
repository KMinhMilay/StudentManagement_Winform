using System.Data;

namespace QuanLiHocSinh.DTO.ModelView
{
    public class XepLoaiModelView
    {
        public int IdXepLoai { get; set; }
        public int IdHK { get; set; }
        public int HocKy { get; set; }
        public string Nam { get; set; }
        public string IdHS { get; set; }
        public string HoVaTenHS { get; set; }
        public string TenHS { get; set; }
        public string IdLop { get; set; }
        public string TenLop { get; set; }
        public float DiemTongKet { get; set; }
        public string HocLuc { get; set; }
        public string HanhKiem { get; set; }

        public XepLoaiModelView() { }
        public XepLoaiModelView(DataRow row)
        {
            IdXepLoai = int.Parse(row["IDXEPLOAI"].ToString());
            IdHK = int.Parse(row["IDHK"].ToString());
            HocKy = int.Parse(row["HOCKY"].ToString());
            Nam = row["NAM"].ToString();
            IdHS = row["IDHS"].ToString();
            HoVaTenHS = row["HoTenHocSinh"].ToString();
            TenHS = row["TEN"].ToString();
            IdLop = row["IDLOP"].ToString();
            TenLop = row["TENLOP"].ToString();
            DiemTongKet = DiemModelView.ConvertStringToFloat(row["DIEMTONGKET"].ToString());
            HocLuc = row["HOCLUC"].ToString();
            HanhKiem = row["HANHKIEM"].ToString();
        }
    }
}
