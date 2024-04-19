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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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
            OpenChildForm(new frmQLHocSinh());
            label1.Text = btnTTCN.Text;
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDiem());
            label1.Text = btnDiem.Text;


        }

        private void btnXepLoai_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmXepLoai());
            label1.Text = btnXepLoai.Text;

        }

        private void btnDSHS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLHocSinh());
            label1.Text = btnDSHS.Text;

        }

        private void btnDSGV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLGiaoVien());
            label1.Text = btnDSGV.Text;

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTransHistory());
            label1.Text = btnHistory.Text;

        }
    }

}
