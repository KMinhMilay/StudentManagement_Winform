using OfficeOpenXml.Style;
using OfficeOpenXml;
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
        private string userRole;
        private string userName;
        public frmXepLoai(Account account)
        {
            InitializeComponent();
            cbbLop.SelectedIndex = -1;
            cbbHocLuc.SelectedIndex = -1;
            cbbHanhKiem.SelectedIndex = -1;
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
            label7.Visible = this._account.role == "admin";
            cbbLop.Visible = this._account.role == "admin";
            listXL = new List<XepLoaiModelView>();
            listHocLuc = new List<string>() { "Giỏi", "Khá", "Trung bình", "Yếu", "Kém" };
            listHanhKiem = new List<string>() { "Giỏi", "Khá", "Trung bình", "Yếu", "Kém" };
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
            cbbLop.SelectedIndex = -1;

        }

        private void LoadHocLuc()
        {
            cbbHocLuc.DataSource = listHocLuc;
            cbbHocLuc.SelectedIndex = -1;
        }

        private void LoadFilterHanhKiem()
        {
            cbbHanhKiem.DataSource = listHanhKiem;
            cbbHanhKiem.SelectedIndex = -1;

        }

        private void LoadHanhKiem()
        {
            cbbHK.DataSource = listHanhKiem;

            cbbHK.SelectedIndex = -1;
        }

        private void LoadDataTableFirst()
        {
            listXL = XepLoaiDAO.Instance.GetAll(userRole,userName);
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
            cbbLop.SelectedIndex = -1;
            cbbHocLuc.SelectedIndex = -1;
            cbbHanhKiem.SelectedIndex = -1;
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

                        using (ExcelRange range = worksheet.Cells[1, 7, 1, 12])
                        {
                            range.Merge = true;
                            range.Value = "Thống kê xếp loại học sinh";
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
