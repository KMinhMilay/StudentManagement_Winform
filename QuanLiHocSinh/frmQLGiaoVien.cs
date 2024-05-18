using OfficeOpenXml.Style;
using OfficeOpenXml;
using QuanLiHocSinh.DAO;
using QuanLiHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiHocSinh
{
    public partial class frmQLGiaoVien : Form
    {
        List<TeacherPersonalInformation> teacherList = new List<TeacherPersonalInformation>();
        private Account account;

        private string currentAction = "";

        private bool _focusOnForm;
        public bool FocusOnForm
        {
            get
            {
                return _focusOnForm;
            }
            set
            {
                _focusOnForm = value;
                FocusOnFormEvent(value);
            }
        }
        public frmQLGiaoVien(Account account)
        {
            this.account = account;
            InitializeComponent();
            hideFrmAddGV();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;
        }
        void showFrmAddGV()
        {
            labelAddGV.Visible = true;
        }
        void hideFrmAddGV()
        {
            labelAddGV.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            currentAction = "ADD";
            btnAdd.BackColor = Color.LightGreen;
            FocusOnForm = true;
            listViewGiaoVien.Visible = false;
            showFrmAddGV();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            currentAction = "";
            listViewGiaoVien.Visible = true;
            btnAdd.BackColor = SystemColors.Control;
            btnUpdate.BackColor = SystemColors.Control;
            btnDelete.BackColor = SystemColors.Control;
            hideFrmAddGV();
            FocusOnForm = false;
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentAction = "UPDATE";
            //FocusOnForm();
            btnUpdate.BackColor = Color.LightGreen;
            FocusOnForm = true;
        }

        private void FocusOnFormEvent(bool isFocused)
        {
            listViewGiaoVien.SelectedItems.Clear();
            btnAdd.Enabled = !isFocused;
            btnRefresh.Enabled = !isFocused;
            btnStatisticize.Enabled = !isFocused;
            foreach (TextBox textBox in grpBoxForm.Controls.OfType<TextBox>())
            {
                textBox.Enabled = isFocused;
            }
            foreach (ComboBox cmb in grpBoxForm.Controls.OfType<ComboBox>())
            {
                cmb.Enabled = isFocused;
            }
            txbId.Enabled = isFocused && currentAction == "ADD";
            birthdatePicker.Enabled = isFocused;
            btnAccept.Visible = isFocused;
            btnBack.Visible = isFocused;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnDelete.BackColor= Color.LightGreen;
            if (MessageBox.Show("Xóa thông tin giáo viên này?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (TeacherDAO.Instance.DeleteTeacherSuccess(txbId.Text))
                {
                    MessageBox.Show("Xóa thông tin giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshForm();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshForm();
        }
        private void refreshForm()
        {
            listViewGiaoVien.Items.Clear();
            txbNameSearch.Text = "";
            txbIdSearch.Text = "";
            cmbClassSearch.SelectedItem = null;
            teacherList.Clear();
            ClearForm();
            loadTeacherList();

            FocusOnForm = false;
            hideFrmAddGV();
            listViewGiaoVien.Visible = true;
        }

        private void frmQLGiaoVien_Load(object sender, EventArgs e)
        {
            txbId.Text = "";
            FocusOnForm = false;
            loadTeacherList();
            loadComboBox();
        }

        private void loadComboBox()
        {
            List<string> classes = TeacherDAO.Instance.GetClassIdList();
            cmbClassSearch.Items.Add("");
            foreach (var item in classes)
            {
                cmbHomeroomClass.Items.Add(item);
                cmbClassSearch.Items.Add(item);
            }
            List<string> subjects = TeacherDAO.Instance.GetSubjectList();
            foreach (var item in subjects)
            {
                cmbSubject.Items.Add(item);
            }
        }

        private void loadTeacherList()
        {
            teacherList = TeacherDAO.Instance.GetTeacherList();

            foreach (var teacher in teacherList)
            {
                ListViewItem item = new ListViewItem(teacher.id);
                item.SubItems.Add(teacher.lastname);
                item.SubItems.Add(teacher.firstname);
                DateTime ngaySinh = Convert.ToDateTime(teacher.birthdate);
                item.SubItems.Add(ngaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(teacher.gender);
                item.SubItems.Add(teacher.hometown);
                item.SubItems.Add(teacher.address);
                item.SubItems.Add(teacher.email);
                item.SubItems.Add(teacher.phoneNumber);
                item.SubItems.Add(teacher.idHomeroomClass);
                item.SubItems.Add(teacher.subjectName);
                item.SubItems.Add(teacher.salary);
                listViewGiaoVien.Items.Add(item);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //ValidateInput();
            if (InputIsValid() && InputIsNotNull())
            {
                if (currentAction == "ADD")
                {
                    if (MessageBox.Show("Thêm thông tin giáo viên này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        try
                        {
                            if (TeacherDAO.Instance.AddTeacherSuccess(txbId.Text, txbLastname.Text, txbFirstname.Text, birthdatePicker.Value, cmbGender.SelectedItem.ToString(), cmbHometown.SelectedItem.ToString(), txbAddress.Text, txbEmail.Text, txbPhoneNumber.Text, cmbHomeroomClass.Text, Int32.Parse(txbSalary.Text), cmbSubject.Text))
                            {
                                MessageBox.Show("Thêm thông tin giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                refreshForm();
                            }
                        }
                        catch (SqlException ex)
                        {
                            //MessageBox.Show("Đã có lỗi xảy ra khi thực hiện thêm giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (currentAction == "UPDATE")
                {
                    try
                    {
                        if (MessageBox.Show("Cập nhật thông tin giáo viên này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (TeacherDAO.Instance.UpdateTeacherSuccess(txbId.Text, txbLastname.Text, txbFirstname.Text, birthdatePicker.Value, cmbGender.SelectedItem.ToString(), cmbHometown.SelectedItem.ToString(), txbAddress.Text, txbEmail.Text, txbPhoneNumber.Text, cmbHomeroomClass.Text, Int32.Parse(txbSalary.Text), cmbSubject.Text))
                            {
                                MessageBox.Show("Cập nhật thông tin giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                refreshForm();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra khi thực hiện cập nhật thông tin giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool InputIsValid()
        {
            return IsValidEmail(txbEmail.Text) && IsValidNumer(txbPhoneNumber.Text) && IsValidNumer(txbSalary.Text);
        }
        private bool InputIsNotNull()
        {
            return grpBoxForm.Controls.OfType<TextBox>().All(tb => !string.IsNullOrEmpty(tb.Text)) && grpBoxForm.Controls.OfType<ComboBox>().Any(cmb => cmb.SelectedIndex != -1);
        }

        private void listViewGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGiaoVien.SelectedItems.Count > 0)
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
                TeacherPersonalInformation teacher = teacherList[listViewGiaoVien.SelectedItems[0].Index];
                txbLastname.Text = teacher.lastname;
                txbFirstname.Text = teacher.firstname;
                txbAddress.Text = teacher.address;
                txbEmail.Text = teacher.email;
                txbPhoneNumber.Text = teacher.phoneNumber;
                txbSalary.Text = teacher.salary;
                cmbGender.SelectedItem = teacher.gender;
                cmbHometown.SelectedItem = teacher.hometown;
                cmbHomeroomClass.SelectedItem = teacher.idHomeroomClass;
                cmbSubject.SelectedItem = teacher.subjectName;
                birthdatePicker.Value = teacher.birthdate;
                txbId.Text = teacher.id;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Enabled = true;
                if (!FocusOnForm)
                {
                    ClearForm();
                }

            }
        }
        private void ClearForm()
        {
            foreach (TextBox txb in grpBoxForm.Controls.OfType<TextBox>())
            {
                txb.Text = "";
            }
            foreach (ComboBox cmb in grpBoxForm.Controls.OfType<ComboBox>())
            {
                cmb.SelectedItem = null;
            }
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool IsValidEmail(string email)
        {
            // Kiểm tra định dạng email.
            string pattern = @"^[\w-]+(\.[\w-]+)*@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,7}$";
            return Regex.IsMatch(email, pattern);
        }
        private bool IsValidNumer(string number)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(number);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            IEnumerable<TeacherPersonalInformation> filteredData = teacherList;
            if (!string.IsNullOrEmpty(txbIdSearch.Text))
            {
                filteredData = filteredData.Where(item => item.id.Contains(txbIdSearch.Text));
            }
            if (!string.IsNullOrEmpty(txbNameSearch.Text))
            {
                filteredData = filteredData.Where(item => item.firstname.Contains(txbNameSearch.Text));
            }
            if (cmbClassSearch.SelectedIndex != -1)
            {
                filteredData = filteredData.Where(item => item.idHomeroomClass.Contains(cmbClassSearch.SelectedItem.ToString()));
            }
            listViewGiaoVien.Items.Clear();
            foreach (var teacher in filteredData)
            {
                ListViewItem item = new ListViewItem(teacher.id);
                item.SubItems.Add(teacher.lastname);
                item.SubItems.Add(teacher.firstname);
                DateTime ngaySinh = Convert.ToDateTime(teacher.birthdate);
                item.SubItems.Add(ngaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(teacher.gender);
                item.SubItems.Add(teacher.hometown);
                item.SubItems.Add(teacher.address);
                item.SubItems.Add(teacher.email);
                item.SubItems.Add(teacher.phoneNumber);
                item.SubItems.Add(teacher.idHomeroomClass);
                item.SubItems.Add(teacher.subjectName);
                item.SubItems.Add(teacher.salary);
                listViewGiaoVien.Items.Add(item);
            }
        }

        private void btnStatisticize_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo existingFile = new FileInfo(saveFileDialog.FileName);
                    if (existingFile.Exists)
                    {
                        using (ExcelPackage package = new ExcelPackage(existingFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Data");
                            if (worksheet == null)
                            {
                                worksheet = package.Workbook.Worksheets.Add("Data");
                            }

                            using (ExcelRange range = worksheet.Cells[1, 7, 1, 11])
                            {
                                range.Merge = true;
                                range.Value = "Danh sách giáo viên";
                                range.Style.Font.Size = 30;
                                range.Style.Font.Name = "Calibri";
                            }

                            int col = 1;
                            foreach (ColumnHeader columnHeader in listViewGiaoVien.Columns)
                            {
                                ExcelRange cell = worksheet.Cells[3, col];
                                cell.Value = columnHeader.Text;
                                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cell.Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                col++;
                            }

                            int row = 4; // Bắt đầu từ hàng 4 để thêm dữ liệu
                            foreach (ListViewItem item in listViewGiaoVien.Items)
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
                            MessageBox.Show("Dữ liệu đã được ghi đè thành công.");
                        }
                    }
                    else
                    {
                        using (ExcelPackage package = new ExcelPackage(existingFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                            using (ExcelRange range = worksheet.Cells[1, 7, 1, 11])
                            {
                                range.Merge = true;
                                range.Value = "Danh sách giáo viên";
                                range.Style.Font.Size = 30;
                                range.Style.Font.Name = "Calibri";
                            }

                            int col = 1;
                            foreach (ColumnHeader columnHeader in listViewGiaoVien.Columns)
                            {
                                ExcelRange cell = worksheet.Cells[3, col];
                                cell.Value = columnHeader.Text;
                                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cell.Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                col++;
                            }

                            int row = 4; // Bắt đầu từ hàng 4 để thêm dữ liệu
                            foreach (ListViewItem item in listViewGiaoVien.Items)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }
    }
}
