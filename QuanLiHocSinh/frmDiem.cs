using QuanLiHocSinh.DAO;
using QuanLiHocSinh.DTO;
using QuanLiHocSinh.DTO.ModelView;

namespace QuanLiHocSinh
{
    public partial class frmDiem : Form
    {
        private List<DiemModelView> listDiem;
        private int row = -1;
        private Account _account;
        public frmDiem(Account account)
        {
            InitializeComponent();
            _account = account;
        }

        private void LoadForm()
        {
            listDiem = new List<DiemModelView>();
            if (_account.role == "admin" || _account.role == "giaovien")
                btnCapNhat.Enabled = true;
            else
                btnCapNhat.Enabled = false;
            LoadLop();
            LoadMonHoc();
            LoadDataTableFirst();
        }

        private void LoadLop()
        {
            cbbLop.DataSource = LopDAO.Instance.GetAll();
            cbbLop.DisplayMember = "TENLOP";
            cbbLop.ValueMember = "IDLOP";
        }

        private void LoadMonHoc()
        {
            cbbMon.DataSource = MonHocDAO.Instance.GetAll();
            cbbMon.DisplayMember = "TENMH";
            cbbMon.ValueMember = "IDMH";
        }

        private void LoadDataTableFirst()
        {
            listDiem = DiemDAO.Instance.GetAll();
            LoadDataTable(listDiem);
        }

        private void LoadDataTable(List<DiemModelView> listDiem)
        {
            lvHocSinh.Items.Clear();

            foreach (DiemModelView diem in listDiem)
            {
                ListViewItem item = new ListViewItem(diem.IdHocSinh);
                item.SubItems.Add(diem.HoTenHocSinh);
                item.SubItems.Add(diem.TenHocSinh);
                item.SubItems.Add(diem.TenMon);
                item.SubItems.Add(diem.DiemQT.ToString());
                item.SubItems.Add(diem.DiemGK.ToString());
                item.SubItems.Add(diem.DiemCK.ToString());
                item.SubItems.Add(diem.DiemTB.ToString());
                item.SubItems.Add(diem.Nam);
                item.SubItems.Add(diem.HocKy.ToString());
                lvHocSinh.Items.Add(item);
            }
        }

        private void SetData(DiemModelView diem)
        {
            lbMaHS.Text = diem.IdHocSinh;
            lbHoVaTen.Text = diem.HoTenHocSinh;
            lbTen.Text = diem.TenHocSinh;
            lbMon.Text = diem.TenMon;
            lbNam.Text = diem.Nam;
            lbHocKi.Text = diem.HocKy.ToString();
            nDiemQT.Value = (decimal)diem.DiemQT;
            nDiemGK.Value = (decimal)diem.DiemGK;
            nDiemCK.Value = (decimal)diem.DiemCK;
            lbDiemTBMon.Text = diem.DiemTB.ToString();
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void frmDiem_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDataTableFirst();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txbTimTen.Text;
            string maLop = cbbLop.SelectedValue.ToString();
            string maMon = cbbMon.SelectedValue.ToString();

            listDiem = DiemDAO.Instance.FilterData(ten, maLop, maMon);
            LoadDataTable(listDiem);
        }

        private void lvHocSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHocSinh.SelectedItems.Count > 0)
            {
                row = lvHocSinh.SelectedIndices[0];
                SetData(listDiem[row]);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (row == -1)
            {
                MessageBox.Show("Vui lòng chọn đối tượng cần nhập điểm");
                return;
            }

            string idDiem = listDiem[row].IdDiem;
            float diemQT = (float)nDiemQT.Value;
            float diemGK = (float)nDiemGK.Value;
            float diemCK = (float)nDiemCK.Value;
            if (DiemDAO.Instance.UpdateDiem(idDiem, diemQT, diemGK, diemCK))
            {
                MessageBox.Show("Cập nhật điểm thành công");
                LoadForm();
            }
            else
            {
                MessageBox.Show("Lỗi! Vui lòng liên hệ với trung tâm tư vấn.");
            }
        }

        private void txbTimTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
