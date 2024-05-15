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
        private Account account;
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
            listViewGiaoVien.Visible = false;
            showFrmAddGV();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            listViewGiaoVien.Visible = true;
            hideFrmAddGV();
            FocusOnForm = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //FocusOnForm();
            FocusOnForm = true;
        }

        private void FocusOnFormEvent(bool isFocused)
        {
            btnAdd.Enabled = !isFocused;
            btnUpdate.Enabled = !isFocused;
            btnRefresh.Enabled = !isFocused;
            btnStatisticize.Enabled = !isFocused;
            foreach (TextBox textBox in grpBoxForm.Controls.OfType<TextBox>())
            {
                textBox.Enabled = isFocused;
            }
            btnAccept.Visible = isFocused;
            btnBack.Visible = isFocused;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("xoa");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void frmQLGiaoVien_Load(object sender, EventArgs e)
        {
            FocusOnForm = false;
            loadTeacherList();

        }

        private void loadTeacherList()
        {
            DataTable data = TeacherDAO.Instance.GetTeacherList();
            foreach (DataRow datarow in data.Rows)
            {
                ListViewItem item = new ListViewItem(datarow["IDGV"].ToString());
                item.SubItems.Add(datarow["HO"].ToString());
                item.SubItems.Add(datarow["TEN"].ToString());
                DateTime ngaySinh = Convert.ToDateTime(datarow["NAMSINH"]);
                item.SubItems.Add(ngaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(datarow["GIOITINH"].ToString());
                item.SubItems.Add(datarow["QUEQUAN"].ToString());
                item.SubItems.Add(datarow["DIACHI"].ToString());
                item.SubItems.Add(datarow["EMAIL"].ToString());
                item.SubItems.Add(datarow["SDT"].ToString());
                item.SubItems.Add(datarow["IDLOPCN"].ToString());
                item.SubItems.Add(datarow["TENMH"].ToString());
                item.SubItems.Add(datarow["LUONG"].ToString());
                listViewGiaoVien.Items.Add(item);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void listViewGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGiaoVien.SelectedItems.Count > 0)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }
    }
}
