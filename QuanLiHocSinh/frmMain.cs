using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiHocSinh.DAO;
using QuanLiHocSinh.DTO;

namespace QuanLiHocSinh
{
    public partial class frmMain : Form
    {
        private Account account;
        public frmMain(Account account)
        {
            this.account = account;
            InitializeComponent();
            btnDSHS.Visible = isAccessibleToStudentList();
            btnDSGV.Visible = isAccessibleToTeacherList();
            btnHistory.Visible = isAccessibleTotransactionHistory();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }



        private void btnTTCN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTTCaNhan(this.account));
            label1.Text = btnTTCN.Text;

        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDiem(this.account));
            label1.Text = btnDiem.Text;


        }

        private void btnXepLoai_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmXepLoai(this.account));
            label1.Text = btnXepLoai.Text;

        }

        private void btnDSHS_Click(object sender, EventArgs e)
        {
            if (account.role != "hocsinh")
            {
                string roleInt = "0";

                if (account.role == "loptruong")
                {
                    roleInt = "1";
                }
                else if (account.role == "giaovienthuong" && account.username != "admin")
                {
                    roleInt = "2";
                }
                //chỉnh ở đây nè Trung
                else if (account.role == "giaovienthuong" && account.username == "admin")
                {
                    roleInt = "3";
                }

                OpenChildForm(new frmQLHocSinh(roleInt, account.username, account.id));
                label1.Text = btnDSHS.Text;
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        private void btnDSGV_Click(object sender, EventArgs e)
        {

            OpenChildForm(new frmQLGiaoVien(this.account));
            label1.Text = btnDSGV.Text;

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTransHistory());
            label1.Text = btnHistory.Text;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool isAccessibleToStudentList()
        {
            return this.account.role == "loptruong" || this.account.accountType == "giaovien";
        }
        private bool isAccessibleToTeacherList()
        {
            return this.account.role == "admin";
        }
        private bool isAccessibleTotransactionHistory()
        {
            return this.account.role == "admin";
        }
    }

}
