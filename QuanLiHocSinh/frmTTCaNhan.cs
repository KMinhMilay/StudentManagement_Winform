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
    public partial class frmTTCaNhan : Form
    {
        private Account account;
        private StudentPersonalInformation studentInfo;
        private TeacherPersonalInformation teacherInfo;
        public frmTTCaNhan(Account account)
        {
            this.account = account;
            InitializeComponent();
            CheckUserAccess();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reloadData();
        }

        private void frmTTCaNhan_Load(object sender, EventArgs e)
        {
            getData();
            fillData();
        }
        private void getData()
        {
            if (IsStudent())
            {
                this.studentInfo = AuthDAO.Instance.GetStudentPersonalInfo(this.account.id);
            }
            if (IsTeacher())
            {
                this.teacherInfo = AuthDAO.Instance.GetTeacherPersonalInfo(this.account.id);
            }
        }
        private void fillData()
        {
            if (IsStudent() && this.studentInfo != null)
            {
                this.labelMTK.Text = this.studentInfo.id;
                this.txbLastname.Text = this.studentInfo.lastname;
                this.txbFirstname.Text = this.studentInfo.firstname;
                this.datetimeBirthdate.Value = new DateTime(this.studentInfo.birthdate.Year, this.studentInfo.birthdate.Month, this.studentInfo.birthdate.Day);
                this.cbxGender.SelectedItem = this.studentInfo.gender;
                this.cbxHometown.SelectedItem = this.studentInfo.hometown;
                this.txbEmail.Text = this.studentInfo.email;
                this.txbAddress.Text = this.studentInfo.address;
                this.txbPhoneNumber.Text = this.studentInfo.phoneNumber;
                this.txbParentPhoneNumber.Text = this.studentInfo.parentPhoneNumber;
                this.txbParentName.Text = this.studentInfo.parentName;
                lblOtherInfo1.Text = "Học tại lớp: " + this.studentInfo.idClass;
                lblOtherInfo2.Text = "Giáo viên chủ nhiệm: " + this.studentInfo.teacherName;
                lblOtherInfo3.Text = "Chức vụ: " + this.studentInfo.role;
                lblOtherInfo4.Text = "Trạng thái: " + this.studentInfo.status;
            }
            if (IsTeacher() && this.teacherInfo != null)
            {
                this.labelMTK.Text = this.teacherInfo.id;
                this.txbLastname.Text = this.teacherInfo.lastname;
                this.txbFirstname.Text = this.teacherInfo.firstname;
                this.datetimeBirthdate.Value = new DateTime(this.teacherInfo.birthdate.Year, this.teacherInfo.birthdate.Month, this.teacherInfo.birthdate.Day);
                this.cbxGender.SelectedItem = this.teacherInfo.gender;
                this.cbxHometown.SelectedItem = this.teacherInfo.hometown;
                this.txbEmail.Text = this.teacherInfo.email;
                this.txbAddress.Text = this.teacherInfo.address;
                this.txbPhoneNumber.Text = this.teacherInfo.phoneNumber;
                lblOtherInfo1.Text = "Lớp chủ nhiệm: ";
                lblOtherInfo1.Text += this.teacherInfo.idHomeroomClass == "NO" ? "Chưa có lớp chủ nhiệm" : this.teacherInfo.idHomeroomClass;
                lblOtherInfo2.Text = "Phụ trách môn: " + this.teacherInfo.subjectName;
                lblOtherInfo3.Text = "Lương: " + this.teacherInfo.salary;
            }
        }
        private void reloadData()
        {
            getData();
            fillData();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txbPassword.Text != txbNewPassword.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (AuthDAO.Instance.changePasswordSuccess(this.account.id, txbPassword.Text, this.account.accountType))
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reloadData();
                }
                else
                {
                    MessageBox.Show("Thay đổi mật khẩu không thành công!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void cbxShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowHide.Checked)
            {
                txbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassword.UseSystemPasswordChar = true;
            }
        }
        private void CheckUserAccess()
        {
            if (IsTeacher())
            {
                pnlStudentParent.Visible = false;
                lblOtherInfo4.Visible = false;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (AllFieldsAreFilled())
            {
                if (IsStudent())
                {
                    if (AuthDAO.Instance.UpdateStudentPersonalInfoSuccess(this.account.id, txbLastname.Text, txbFirstname.Text, datetimeBirthdate.Value, cbxGender.SelectedItem.ToString(), cbxHometown.SelectedItem.ToString(), txbAddress.Text, txbEmail.Text, txbPhoneNumber.Text, txbParentName.Text, txbParentPhoneNumber.Text))
                    {
                        MessageBox.Show("Thay đổi thông tin cá nhân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadData();
                    }
                    else MessageBox.Show("Đã có lỗi xảy ra khi thực hiện thay đổi thông tin cá nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (IsTeacher())
                {
                    if (AuthDAO.Instance.UpdateTeacherPersonalInfoSuccess(this.account.id, txbLastname.Text, txbFirstname.Text, datetimeBirthdate.Value, cbxGender.SelectedItem.ToString(), cbxHometown.SelectedItem.ToString(), txbAddress.Text, txbEmail.Text, txbPhoneNumber.Text))
                    {
                        MessageBox.Show("Thay đổi thông tin cá nhân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadData();
                    }
                    else MessageBox.Show("Đã có lỗi xảy ra khi thực hiện thay đổi thông tin cá nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private bool IsStudent()
        {
            return this.account.accountType == "hocsinh";
        }
        private bool IsTeacher()
        {
            return this.account.accountType == "giaovien";
        }
        private bool AllFieldsAreFilled()
        {
            if (IsStudent())
            {
                return grpbxPersonalInfo.Controls.OfType<TextBox>().All(tb => !string.IsNullOrEmpty(tb.Text)) && pnlStudentParent.Controls.OfType<TextBox>().All(tb => !string.IsNullOrEmpty(tb.Text));

            }
            else
            {
                return grpbxPersonalInfo.Controls.OfType<TextBox>().All(tb => !string.IsNullOrEmpty(tb.Text));
            }
        }
    }
}
