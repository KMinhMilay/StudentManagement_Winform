using System.Data;

namespace QuanLiHocSinh.DTO.ModelView
{
    public class DiemModelView
    {
        public string IdDiem { get; set; }
        public int IdHocKy { get; set; }
        public int HocKy { get; set; }
        public int IdNam { get; set; }
        public string Nam { get; set; }
        public string IdMonHoc { get; set; }
        public string TenMon { get; set; }
        public string IdHocSinh { get; set; }
        public string HoTenHocSinh { get; set; }
        public string TenHocSinh { get; set; }
        public float? DiemQT { get; set; }
        public float? DiemGK { get; set; }
        public float? DiemCK { get; set; }
        public float? DiemTB { get; set; }

        public DiemModelView() { }
        public DiemModelView(DataRow row)
        {
            this.IdDiem = row["IDDIEM"].ToString();
            this.IdHocKy = int.Parse(row["IDHK"].ToString());
            this.HocKy = int.Parse(row["HOCKY"].ToString());
            this.IdNam = int.Parse(row["IDNAM"].ToString());
            this.Nam = row["NAM"].ToString();
            this.IdMonHoc = row["IDMH"].ToString();
            this.TenMon = row["TENMH"].ToString();
            this.IdHocSinh = row["IDHS"].ToString();
            this.HoTenHocSinh = row["HoTenHocSinh"].ToString();
            this.TenHocSinh = row["TEN"].ToString();
            this.DiemQT = ConvertStringToFloat(row["DIEMQT"].ToString());
            this.DiemGK = ConvertStringToFloat(row["DIEMGK"].ToString());
            this.DiemCK = ConvertStringToFloat(row["DIEMCK"].ToString());
            this.DiemTB = ConvertStringToFloat(row["DTB"].ToString());
        }

        private float ConvertStringToFloat(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            return float.Parse(str);
        }
    }

}
