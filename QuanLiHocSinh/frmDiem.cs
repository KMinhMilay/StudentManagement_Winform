using OfficeOpenXml.Style;
using OfficeOpenXml;
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
        private string userRole;
        private string userName;
        public frmDiem(Account account)
        {
            InitializeComponent();
            _account = account;
            userName = _account.username;

            if (_account.role != "hocsinh")
            {
                userRole = "0";
                if (_account.role == "loptruong")
                {
                    userRole = "1";
                }
                else if (_account.role == "giaovienthuong" && account.username != "admin")
                {
                    userRole = "2";
                }
                else if (_account.role == "admin" && account.username == "admin")
                {
                    userRole = "3";
                }
            }
        }

        private void LoadForm()
        {
            cbbMon.SelectedIndex = -1;
            cbbLop.SelectedIndex = -1;
            listDiem = new List<DiemModelView>();
            if (_account.role == "admin" || _account.role == "giaovienthuong")
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

            cbbLop.SelectedIndex = -1;
        }

        private void LoadMonHoc()
        {
            cbbMon.DataSource = MonHocDAO.Instance.GetAll();
            cbbMon.DisplayMember = "TENMH";
            cbbMon.ValueMember = "IDMH";
            cbbMon.SelectedIndex = -1;

        }

        private void LoadDataTableFirst()
        {
            listDiem = DiemDAO.Instance.GetAll(userRole,userName);
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
            cbbMon.SelectedIndex = -1;
            cbbLop.SelectedIndex = -1;
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
            if (DiemDAO.Instance.UpdateDiem(idDiem, diemQT, diemGK, diemCK, this._account.id))
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

        private void button3_Click(object sender, EventArgs e)
        {
            // Set the license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo newFile = new FileInfo(saveFileDialog.FileName);

                    // Ensure any existing file is deleted before creating a new one
                    if (newFile.Exists)
                    {
                        newFile.Delete();
                    }

                    using (ExcelPackage package = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                        using (ExcelRange range = worksheet.Cells[1, 7, 1, 11])
                        {
                            range.Merge = true;
                            range.Value = "Thống kê điểm học sinh";
                            range.Style.Font.Size = 30;
                            range.Style.Font.Name = "Calibri";
                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        int col = 1;
                        foreach (ColumnHeader columnHeader in lvHocSinh.Columns)
                        {
                            ExcelRange cell = worksheet.Cells[3, col];
                            cell.Value = columnHeader.Text;
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cell.Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            col++;
                        }

                        int row = 4; // Bắt đầu từ hàng 4 để thêm dữ liệu
                        foreach (ListViewItem item in lvHocSinh.Items)
                        {
                            col = 1;
                            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                            {
                                ExcelRange cell = worksheet.Cells[row, col];
                                cell.Value = subItem.Text;
                                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                col++;
                            }
                            row++;
                        }

                        // Tự động điều chỉnh độ rộng của các cột để chứa đủ dữ liệu
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        package.Save();
                        MessageBox.Show("Dữ liệu đã được xuất thành công.");
                    }
                }
                catch (IOException ioEx)
                {
                    MessageBox.Show("Lỗi truy cập tệp: " + ioEx.Message);
                }
                catch (UnauthorizedAccessException uaEx)
                {
                    MessageBox.Show("Lỗi quyền truy cập: " + uaEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }
    }
}
