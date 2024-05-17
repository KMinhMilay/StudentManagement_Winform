using QuanLiHocSinh.DAO;
using QuanLiHocSinh.DTO;
using QuanLiHocSinh.DTO.ModelView;

namespace QuanLiHocSinh
{
    public partial class frmXepLoai : Form
    {

        private List<XepLoaiModelView> listXL;
        private List<string> listHocLuc;
        private List<string> listHanhKiem;
        private int row = -1;
        private Account _account;

        public frmXepLoai(Account account)
        {
            InitializeComponent();
            _account = account;
        }

        private void LoadForm()
        {
            listXL = new List<XepLoaiModelView>();
            listHocLuc = new List<string>() { "Giỏi", "Khá", "Trung bình", "Yếu", "Kém" };
            listHanhKiem = new List<string>() { "Giỏi", "Khá", "Trung bình", "Yếu", "Kém" };
            if (_account.role == "admin" || _account.role == "giaovien")
                btnCapNhat.Enabled = true;
            else
                btnCapNhat.Enabled = false;
            LoadLop();
            LoadHocLuc();
            LoadFilterHanhKiem();
            LoadHanhKiem();
            LoadDataTableFirst();
        }

        private void LoadLop()
        {
            cbbLop.DataSource = LopDAO.Instance.GetAll();
            cbbLop.DisplayMember = "TENLOP";
            cbbLop.ValueMember = "IDLOP";
        }

        private void LoadHocLuc()
        {
            cbbHocLuc.DataSource = listHocLuc;
        }

        private void LoadFilterHanhKiem()
        {
            cbbHanhKiem.DataSource = listHanhKiem;
        }

        private void LoadHanhKiem()
        {
            cbbHK.DataSource = listHanhKiem;
        }

        private void LoadDataTableFirst()
        {
            listXL = XepLoaiDAO.Instance.GetAll();
            LoadDataTable(listXL);
        }

        private void LoadDataTable(List<XepLoaiModelView> listXL)
        {
            lvHocSinh.Items.Clear();

            foreach (XepLoaiModelView xl in listXL)
            {
                ListViewItem item = new ListViewItem(xl.Nam);
                item.SubItems.Add(xl.IdHS);
                item.SubItems.Add(xl.HoVaTenHS);
                item.SubItems.Add(xl.TenHS);
                item.SubItems.Add(xl.TenLop);
                item.SubItems.Add(xl.DiemTongKet.ToString());
                item.SubItems.Add(xl.HocLuc);
                item.SubItems.Add(xl.HanhKiem);
                item.SubItems.Add(xl.HocKy.ToString());
                lvHocSinh.Items.Add(item);
            }
        }

        private void SetData(XepLoaiModelView xl)
        {
            lbMaHS.Text = xl.IdHS;
            lbHoVaTen.Text = xl.HoVaTenHS;
            lbTen.Text = xl.TenHS;
            lbLop.Text = xl.TenLop;
            lbDTB.Text = xl.DiemTongKet.ToString();
            lbHocLuc.Text = xl.HocLuc;
            if (xl.HanhKiem != null)
                cbbHK.SelectedItem = xl.HanhKiem;
            lbNam.Text = xl.Nam;
            lbHocKy.Text = xl.HocKy.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmXepLoai_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void lvHocSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHocSinh.SelectedItems.Count > 0)
            {
                row = lvHocSinh.SelectedIndices[0];
                SetData(listXL[row]);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenHs = txbSearch.Text;
            string maLop = cbbLop.SelectedValue.ToString();
            string hocLuc = cbbHocLuc.SelectedItem.ToString();
            string hanhKiem = cbbHanhKiem.SelectedItem.ToString();
            listXL = XepLoaiDAO.Instance.FilterData(tenHs, maLop, hocLuc, hanhKiem);
            LoadDataTable(listXL);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDataTableFirst();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (row == -1)
            {
                MessageBox.Show("Vui lòng chọn đối tượng cần xếp loại");
                return;
            }

            int idXepLoai = listXL[row].IdXepLoai;
            string hanhKiem = cbbHanhKiem.SelectedItem.ToString();
            float diemTongKet = listXL[row].DiemTongKet;
            string hocLucDiem = "";
            string hocLuc = "";
            if (diemTongKet < 3.5)
            {
                hocLucDiem = listHocLuc[4];
                hocLuc = hocLucDiem;
            }
            else if (diemTongKet < 5)
            {
                hocLucDiem = listHocLuc[3];
                hocLuc = hocLucDiem;
            }
            else if (diemTongKet < 6.5)
            {
                hocLucDiem = listHocLuc[2];
                hocLuc = hocLucDiem;
            }
            else if (diemTongKet < 8)
            {
                hocLucDiem = listHocLuc[1];
                if (hanhKiem.Equals(hocLucDiem) || hanhKiem.Equals(listHocLuc[0]))
                {
                    hocLuc = hocLucDiem;
                }
                else
                {
                    hocLuc = listHocLuc[2];
                }
            }
            else
            {
                hocLucDiem = listHocLuc[0];
                if (hanhKiem.Equals(hocLucDiem))
                {
                    hocLuc = hocLucDiem;
                }
                else
                {
                    hocLuc = listHocLuc[1];
                }
            }

            XepLoai xl = new XepLoai()
            {
                IdXepLoai = idXepLoai,
                HanhKiem = hanhKiem,
                HocLuc = hocLuc
            };
            if (XepLoaiDAO.Instance.UpdateData(xl))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Lỗi! Vui lòng liên hệ với trung tâm tư vấn.");
            }
        }
    }
}
