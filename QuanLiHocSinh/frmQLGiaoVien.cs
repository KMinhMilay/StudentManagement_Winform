using QuanLiHocSinh.DAO;
using QuanLiHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            FocusOnForm = true;
            listViewGiaoVien.Visible = false;
            showFrmAddGV();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            currentAction = "";
            listViewGiaoVien.Visible = true;
            hideFrmAddGV();
            FocusOnForm = false;
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentAction = "UPDATE";
            //FocusOnForm();
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
            birthdatePicker.Enabled = isFocused;
            btnAccept.Visible = isFocused;
            btnBack.Visible = isFocused;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
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
            teacherList.Clear();
            ClearForm();
            loadTeacherList();
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
            foreach (var item in classes)
            {
                cmbHomeroomClass.Items.Add(item);
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
            if (currentAction == "ADD")
            {
                if (MessageBox.Show("Thêm thông tin giáo viên này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (TeacherDAO.Instance.AddTeacherSuccess(txbId.Text, txbLastname.Text, txbFirstname.Text, birthdatePicker.Value, cmbGender.SelectedItem.ToString(), cmbHometown.SelectedItem.ToString(), txbAddress.Text, txbEmail.Text, txbPhoneNumber.Text, cmbHomeroomClass.Text, Int32.Parse(txbSalary.Text), cmbSubject.Text))
                    {
                        MessageBox.Show("Thêm thông tin giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hideFrmAddGV();
                        listViewGiaoVien.Visible = true;
                        refreshForm();
                    }
                }
            }
            if (currentAction == "UPDATE")
            {
                if (MessageBox.Show("Cập nhật thông tin giáo viên này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (TeacherDAO.Instance.UpdateTeacherSuccess(txbId.Text,txbLastname.Text,txbFirstname.Text,birthdatePicker.Value,cmbGender.SelectedItem.ToString(),cmbHometown.SelectedItem.ToString(),txbAddress.Text,txbEmail.Text,txbPhoneNumber.Text,cmbHomeroomClass.Text,Int32.Parse(txbSalary.Text),cmbSubject.Text))
                    {
                        MessageBox.Show("Cập nhật thông tin giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshForm();
                    }
                }
            }
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
                btnAdd .Enabled = true;
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
    }
}
