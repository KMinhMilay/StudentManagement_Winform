using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHocSinh.DTO
{
    internal class Student
    {
        public Student(string idHS, string HoTen, string NamSinh, string GioiTinh, string QueQuan,
            string DiaChi, string Email, string Sdt, string idLop, string ChucVu, string idGV, string idTrangThai,
            string sdtPH, string tenPH, string tenDN, string isEnable)
        {
            this.idHS = idHS;
            this.HoTen = HoTen;
            this.NamSinh = NamSinh;
            this.GioiTinh = GioiTinh;
            this.QueQuan = QueQuan;
            this.DiaChi = DiaChi;
            this.Email = Email;
            this.Sdt = Sdt;
            this.idLop = idLop;
            this.ChucVu = ChucVu;
            this.idGV = idGV;
            this.idTrangThai = idTrangThai;
            this.sdtPH = sdtPH;
            this.tenPH = tenPH;
            this.tenDN = tenDN;
            this.isEnable = isEnable;
        }

        public Student(DataRow data)
        {
            this.idHS = data["IDHS"].ToString();
            this.HoTen = data["HOTEN"].ToString();
            this.NamSinh = data["NAMSINH"].ToString();
            this.GioiTinh = data["GIOITINH"].ToString();
            this.QueQuan = data["QUEQUAN"].ToString();
            this.DiaChi = data["DIACHI"].ToString();
            this.Email = data["EMAIL"].ToString();
            this.Sdt = data["SDT"].ToString();
            this.idLop = data["IDLOP"].ToString();
            this.ChucVu = data["CHUCVU"].ToString();
            this.idGV = data["IDGV"].ToString();
            this.idTrangThai = data["IDTRANGTHAI"].ToString();
            this.sdtPH = data["SDTPH"].ToString();
            this.tenPH = data["TENPH"].ToString();
            this.tenDN = data["TENDN"].ToString();
            this.isEnable = data["isEnable"].ToString();
        }
        public string idHS { get; set; }
        public string HoTen { get; set; }
        public string NamSinh { get; set; }
        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string idLop { get; set; }
        public string ChucVu { get; set; }
        public string idGV { get; set; }
        public string idTrangThai { get; set; }
        public string sdtPH { get; set; }
        public string tenPH { get; set; }
        public string tenDN { get; set; }
        public string isEnable { get; set; }

    }
}
