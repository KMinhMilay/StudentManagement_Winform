﻿using LAB03_Nhom.DAO;
using Microsoft.VisualBasic.Logging;
using QuanLiHocSinh.DAO;
using QuanLiHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OfficeOpenXml.Style;

namespace QuanLiHocSinh
{
    public partial class frmQLHocSinh : Form
    {
        private string role;
        private string userName;
        public enum ActionType
        {
            None,
            Add,
            Edit,
            Delete
        }
        private ActionType currentAction = ActionType.None;

        public frmQLHocSinh(string role, string userName)
        {
            this.role = role;
            this.userName = userName;
            InitializeComponent();
            hideFrmAddHS();
            loadData();
            LoadClassList();
            ClearControls();
            DisableControls();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;
        }
        void showFrmAddHS()
        {
            btnAccept.Visible = true;
            btnBack.Visible = true;
        }
        void hideFrmAddHS()
        {
            btnAccept.Visible = false;
            btnBack.Visible = false;
        }
        void loadData()
        {
            DataTable dataTable = new DataTable();

            if (role != "0")
            {
                dataTable = StudentDAO.Instance.LoadStudentList(userName, role);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listViewHocSinh.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = new ListViewItem(row["IDHS"].ToString());
                item.SubItems.Add(row["HO"].ToString());
                item.SubItems.Add(row["TEN"].ToString());
                item.SubItems.Add(row["CHUCVU"].ToString());
                DateTime ngaySinh = Convert.ToDateTime(row["NAMSINH"]);
                item.SubItems.Add(ngaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(row["GIOITINH"].ToString());
                item.SubItems.Add(row["QUEQUAN"].ToString());
                item.SubItems.Add(row["DIACHI"].ToString());
                item.SubItems.Add(row["EMAIL"].ToString());
                item.SubItems.Add(row["SDT"].ToString());
                item.SubItems.Add(row["IDLOP"].ToString());
                item.SubItems.Add(row["IDGV"].ToString());
                item.SubItems.Add(row["TENPH"].ToString());
                item.SubItems.Add(row["SDTPH"].ToString());
                item.SubItems.Add(row["IDTRANGTHAI"].ToString());
                item.SubItems.Add(row["TENDN"].ToString());
                item.SubItems.Add(row["isEnable"].ToString());
                listViewHocSinh.Items.Add(item);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            currentAction = ActionType.Add;
            listViewHocSinh.Visible = false;
            ClearControls();
            showFrmAddHS();
            button3.BackColor = Color.LightGreen;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            listViewHocSinh.Visible = true;
            DisableControls();
            hideFrmAddHS();
            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            currentAction = ActionType.None;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            switch (currentAction)
            {
                case ActionType.Add:
                    try
                    {
                        string HoTen = textBox1.Text;
                        string ho = "";
                        string ten = "";
                        int lastIndexOfSpace = HoTen.LastIndexOf(' ');
                        if (lastIndexOfSpace != -1)
                        {
                            ho = HoTen.Substring(0, lastIndexOfSpace);
                            ten = HoTen.Substring(lastIndexOfSpace + 1);
                        }
                        else
                        {
                            MessageBox.Show("Họ tên học sinh không hợp lệ!");
                        }
                        DateTime namSinh = dateTimePicker1.Value;
                        string gioiTinh = comboBox1.Text;
                        string queQuan = comboBox2.Text;
                        string diaChi = textBox3.Text;
                        string email = textBox4.Text;
                        string sdt = textBox5.Text;
                        string maLop = comboBox3.Text;
                        string maChucVu = string.Empty;
                        switch (comboBox6.Text)
                        {
                            case "Lớp trưởng":
                                maChucVu = "LT";
                                break;
                            case "Lớp phó":
                                maChucVu = "LP";
                                break;
                            case "Học sinh":
                                maChucVu = "X";
                                break;
                            default:
                                break;
                        }
                        string maGiaoVien = string.Empty;
                        DataTable idTeacher = StudentDAO.Instance.LoadIdTeacher(textBox6.Text);

                        if (idTeacher.Rows.Count > 0)
                        {
                            foreach (DataRow row in idTeacher.Rows)
                            {
                                string idGV = row["IDGV"].ToString();
                                maGiaoVien = idGV;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã giáo viên");
                        }

                        string maTrangThai = string.Empty;
                        switch (comboBox5.Text)
                        {
                            case "Đang học":
                                maTrangThai = "DH";
                                break;
                            case "Bảo lưu":
                                maTrangThai = "BL";
                                break;
                            case "Nghỉ học":
                                maTrangThai = "NH";
                                break;
                            case "Chuyển trường":
                                maTrangThai = "CT";
                                break;
                            default:
                                break;
                        }

                        string sdtPhuHuynh = textBox9.Text;
                        string tenPhuHuynh = textBox8.Text;

                        if (StudentDAO.Instance.AddStudentList(ho, ten, namSinh, gioiTinh, queQuan, diaChi, email, sdt, maLop, maChucVu, maGiaoVien, maTrangThai, sdtPhuHuynh, tenPhuHuynh))
                        {
                            MessageBox.Show("Thêm học sinh thành công!");
                            loadData();
                            LoadClassList();
                            ClearControls();
                            DisableControls();

                        }
                        else
                        {
                            MessageBox.Show("Thêm học sinh thất bại!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng điền đủ thông tin");
                    }
                    break;
                case ActionType.Edit:
                    try
                    {
                        if (listViewHocSinh.SelectedItems.Count == 1)
                        {
                            ListViewItem selectedItem = listViewHocSinh.SelectedItems[0];

                            string IDHS = labelMTK.Text;
                            string HoTen = textBox1.Text;
                            string ho = "";
                            string ten = "";
                            int lastIndexOfSpace = HoTen.LastIndexOf(' ');
                            if (lastIndexOfSpace != -1)
                            {
                                ho = HoTen.Substring(0, lastIndexOfSpace);
                                ten = HoTen.Substring(lastIndexOfSpace + 1);
                            }
                            else
                            {
                                MessageBox.Show("Họ tên học sinh không hợp lệ!");
                            }
                            DateTime namSinh = dateTimePicker1.Value;
                            string gioiTinh = comboBox1.Text;
                            string queQuan = comboBox2.Text;
                            string diaChi = textBox3.Text;
                            string email = textBox4.Text;
                            string sdt = textBox5.Text;
                            string maChucVu = string.Empty;
                            switch (comboBox6.Text)
                            {
                                case "Lớp trưởng":
                                    maChucVu = "LT";
                                    break;
                                case "Lớp phó":
                                    maChucVu = "LP";
                                    break;
                                case "Học sinh":
                                    maChucVu = "X";
                                    break;
                                default:
                                    break;
                            }

                            string maTrangThai = string.Empty;
                            switch (comboBox5.Text)
                            {
                                case "Đang học":
                                    maTrangThai = "DH";
                                    break;
                                case "Bảo lưu":
                                    maTrangThai = "BL";
                                    break;
                                case "Nghỉ học":
                                    maTrangThai = "NH";
                                    break;
                                case "Chuyển trường":
                                    maTrangThai = "CT";
                                    break;
                                default:
                                    break;
                            }

                            string sdtPhuHuynh = textBox9.Text;
                            string tenPhuHuynh = textBox8.Text;
                            if (comboBox3.Text == selectedItem.SubItems[10].Text)
                            {
                                if (StudentDAO.Instance.UpdateStudentByID(IDHS, ho, ten, namSinh, gioiTinh, queQuan, diaChi, email, sdt, maChucVu, maTrangThai, sdtPhuHuynh, tenPhuHuynh))
                                {
                                    MessageBox.Show("Sửa học sinh thành công!");
                                    loadData();
                                    LoadClassList();
                                    ClearControls();
                                    DisableControls();
                                }
                                else
                                {
                                    MessageBox.Show("Sửa học sinh thất bại!");
                                }
                            }
                            else
                            {

                            }

                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn 1 học sinh trong bảng để sửa!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng điền đủ thông tin");
                    }
                    break;
                case ActionType.Delete:
                    try
                    {
                        if (listViewHocSinh.SelectedItems.Count == 1)
                        {
                            string IDHS = labelMTK.Text;

                            if (StudentDAO.Instance.DeleteStudentByID(IDHS))
                            {
                                MessageBox.Show("Xóa học sinh thành công!");
                                loadData();
                                LoadClassList();
                                ClearControls();
                                DisableControls();
                            }
                            else
                            {
                                MessageBox.Show("Xóa học sinh thất bại!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn 1 học sinh trong bảng để xóa!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng điền đủ thông tin");
                    }
                    break;
                default:
                    break;
            }
        }



        private void listViewHocSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentAction == ActionType.Edit)
            {
                ClearControls();
                if (listViewHocSinh.SelectedItems.Count == 1)
                {
                    ListViewItem selectedItem = listViewHocSinh.SelectedItems[0];
                    labelMTK.Text = selectedItem.SubItems[0].Text;

                    textBox1.Text = selectedItem.SubItems[1].Text + ' ' + selectedItem.SubItems[2].Text;

                    comboBox6.Text = selectedItem.SubItems[3].Text;

                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                    if (DateTime.TryParseExact(selectedItem.SubItems[4].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        dateTimePicker1.Value = parsedDate;
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format!");
                    }

                    comboBox1.Text = selectedItem.SubItems[5].Text;

                    comboBox2.Text = selectedItem.SubItems[6].Text;

                    comboBox3.Text = selectedItem.SubItems[10].Text;

                    textBox3.Text = selectedItem.SubItems[7].Text;

                    textBox4.Text = selectedItem.SubItems[8].Text;

                    textBox5.Text = selectedItem.SubItems[9].Text;

                    textBox8.Text = selectedItem.SubItems[12].Text;

                    textBox9.Text = selectedItem.SubItems[13].Text;

                    comboBox5.Text = selectedItem.SubItems[14].Text;
                }
                else
                {
                    ClearControls();
                }
            }
            else
            {
                if (listViewHocSinh.SelectedItems.Count == 1)
                {
                    ListViewItem selectedItem = listViewHocSinh.SelectedItems[0];
                    labelMTK.Text = selectedItem.SubItems[0].Text;

                    textBox1.ReadOnly = true;
                    textBox1.Text = selectedItem.SubItems[1].Text + ' ' + selectedItem.SubItems[2].Text;

                    comboBox6.Enabled = false;
                    comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox6.Text = selectedItem.SubItems[3].Text;

                    dateTimePicker1.Enabled = false;
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                    if (DateTime.TryParseExact(selectedItem.SubItems[4].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        dateTimePicker1.Value = parsedDate;
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format!");
                    }

                    comboBox1.Enabled = false;
                    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox1.Text = selectedItem.SubItems[5].Text;

                    comboBox2.Enabled = false;
                    comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox2.Text = selectedItem.SubItems[6].Text;

                    comboBox3.Enabled = false;
                    comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox3.Text = selectedItem.SubItems[10].Text;

                    textBox3.ReadOnly = true;
                    textBox3.Text = selectedItem.SubItems[7].Text;

                    textBox4.ReadOnly = true;
                    textBox4.Text = selectedItem.SubItems[8].Text;

                    textBox5.ReadOnly = true;
                    textBox5.Text = selectedItem.SubItems[9].Text;

                    textBox6.ReadOnly = true;

                    textBox8.ReadOnly = true;
                    textBox8.Text = selectedItem.SubItems[12].Text;

                    textBox9.ReadOnly = true;
                    textBox9.Text = selectedItem.SubItems[13].Text;

                    comboBox5.Enabled = false;
                    comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox5.Text = selectedItem.SubItems[14].Text;
                }
                else
                {
                    ClearControls();
                }
            }
        }
        private void ClearControls()
        {
            labelMTK.Text = "Mã học sinh";
            textBox1.ReadOnly = false;
            textBox1.Text = string.Empty;

            comboBox6.Enabled = true;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox6.Text = string.Empty;

            dateTimePicker1.Enabled = true;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.CustomFormat = string.Empty;
            dateTimePicker1.Value = DateTime.Now;

            comboBox1.Enabled = true;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox1.Text = string.Empty;

            comboBox2.Enabled = true;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox2.Text = string.Empty;

            comboBox3.Enabled = true;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox3.Text = string.Empty;
            comboBox3.SelectedIndex = -1;

            textBox3.ReadOnly = false;
            textBox3.Text = string.Empty;

            textBox4.ReadOnly = false;
            textBox4.Text = string.Empty;

            textBox5.ReadOnly = false;
            textBox5.Text = string.Empty;

            textBox6.Enabled = false;
            textBox6.Text = string.Empty;

            textBox8.ReadOnly = false;
            textBox8.Text = string.Empty;

            textBox9.ReadOnly = false;
            textBox9.Text = string.Empty;

            comboBox5.Enabled = true;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox5.Text = string.Empty;

            comboBox4.Text = string.Empty;
        }

        private void DisableControls()
        {
            // Vô hiệu hóa TextBox
            textBox1.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;

            // Vô hiệu hóa ComboBox
            comboBox6.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox5.Enabled = false;

            // Vô hiệu hóa DateTimePicker
            dateTimePicker1.Enabled = false;
        }

        void LoadClassList()
        {
            try
            {
                DataTable classData = StudentDAO.Instance.LoadClassList();

                List<string> idList = new List<string>();

                foreach (DataRow row in classData.Rows)
                {
                    string idlop = row["IDLOP"].ToString();
                    idList.Add(idlop);
                }
                comboBox4.DataSource = idList;
                comboBox3.DataSource = idList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải danh sách lớp: " + ex.Message);
            }
        }
        private void SearchStudents(string studentId, string fullName, string className)
        {
            try
            {
                DataTable searchResult = StudentDAO.Instance.SearchStudentList(studentId, fullName, className);

                listViewHocSinh.Items.Clear();

                foreach (DataRow row in searchResult.Rows)
                {
                    ListViewItem item = new ListViewItem(row["IDHS"].ToString());
                    item.SubItems.Add(row["HO"].ToString());
                    item.SubItems.Add(row["TEN"].ToString());
                    item.SubItems.Add(row["CHUCVU"].ToString());
                    DateTime ngaySinh = Convert.ToDateTime(row["NAMSINH"]);
                    item.SubItems.Add(ngaySinh.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(row["GIOITINH"].ToString());
                    item.SubItems.Add(row["QUEQUAN"].ToString());
                    item.SubItems.Add(row["DIACHI"].ToString());
                    item.SubItems.Add(row["EMAIL"].ToString());
                    item.SubItems.Add(row["SDT"].ToString());
                    item.SubItems.Add(row["IDLOP"].ToString());
                    item.SubItems.Add(row["IDGV"].ToString());
                    item.SubItems.Add(row["TENPH"].ToString());
                    item.SubItems.Add(row["SDTPH"].ToString());
                    item.SubItems.Add(row["IDTRANGTHAI"].ToString());
                    item.SubItems.Add(row["TENDN"].ToString());
                    item.SubItems.Add(row["isEnable"].ToString());
                    listViewHocSinh.Items.Add(item);
                }
                comboBox4.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm học sinh: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadData();
            LoadClassList();
            ClearControls();
            DisableControls();
            labelMTK.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string studentId = textBox10.Text;
            string fullName = textBox7.Text;
            string className = comboBox4.Text;
            SearchStudents(studentId, fullName, className);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentAction = ActionType.Edit;
            button2.BackColor = Color.LightGreen;
            button1.Enabled = false;
            button3.Enabled = false;
            ClearControls();
            showFrmAddHS();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentAction = ActionType.Delete;
            button1.BackColor = Color.LightGreen;
            button3.Enabled = false;
            button2.Enabled = false;
            ClearControls();
            showFrmAddHS();
            DisableControls();
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            string idLop = comboBox3.Text;
            if (!string.IsNullOrEmpty(idLop))
            {
                DataTable teacherList = StudentDAO.Instance.LoadTeacherByClass(idLop);
                textBox6.Text = "";
                foreach (DataRow row in teacherList.Rows)
                {
                    string hoTen = row["HoTen"].ToString();
                    textBox6.Text = hoTen;

                }
                if (textBox6.Text == null || textBox6.Text == "")
                {
                    MessageBox.Show("Lớp này hiện chưa có giáo viên chủ nhiệm");
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại lưu tệp Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Kiểm tra nếu tệp đã tồn tại
                    FileInfo existingFile = new FileInfo(saveFileDialog.FileName);
                    if (existingFile.Exists)
                    {
                        // Tải tệp Excel đã tồn tại
                        using (ExcelPackage package = new ExcelPackage(existingFile))
                        {
                            // Lấy hoặc tạo một worksheet mới có tên "Data"
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Data");
                            if (worksheet == null)
                            {
                                worksheet = package.Workbook.Worksheets.Add("Data");
                            }

                            // Điều chỉnh cấu trúc và ghi tên cột
                            int col = 1;
                            foreach (ColumnHeader columnHeader in listViewHocSinh.Columns)
                            {
                                worksheet.Cells[1, col].Value = columnHeader.Text;
                                worksheet.Cells[1, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[1, col].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                                col++;
                            }

                            // Ghi dữ liệu từ ListView vào tệp Excel
                            int row = 2; // Bắt đầu từ dòng 2 để tránh ghi đè lên tên cột
                            foreach (ListViewItem item in listViewHocSinh.Items)
                            {
                                col = 1; // Reset cột về 1 cho mỗi dòng mới
                                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                                {
                                    worksheet.Cells[row, col].Value = subItem.Text;
                                    col++;
                                }
                                row++;
                            }

                            // Lưu lại tệp Excel
                            package.Save();
                            MessageBox.Show("Dữ liệu đã được ghi đè thành công.");
                        }
                    }
                    else
                    {
                        // Tạo một tệp Excel mới nếu tệp không tồn tại
                        using (ExcelPackage package = new ExcelPackage(existingFile))
                        {
                            // Tạo một worksheet mới có tên "Data"
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                            // Điều chỉnh cấu trúc và ghi tên cột
                            int col = 1;
                            foreach (ColumnHeader columnHeader in listViewHocSinh.Columns)
                            {
                                worksheet.Cells[1, col].Value = columnHeader.Text;
                                worksheet.Cells[1, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[1, col].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                                col++;
                            }

                            // Ghi dữ liệu từ ListView vào tệp Excel
                            int row = 2; // Bắt đầu từ dòng 2 để tránh ghi đè lên tên cột
                            foreach (ListViewItem item in listViewHocSinh.Items)
                            {
                                col = 1; // Reset cột về 1 cho mỗi dòng mới
                                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                                {
                                    worksheet.Cells[row, col].Value = subItem.Text;
                                    col++;
                                }
                                row++;
                            }

                            // Lưu tệp Excel mới
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
