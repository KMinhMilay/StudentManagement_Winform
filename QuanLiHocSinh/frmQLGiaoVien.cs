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
        public frmQLGiaoVien()
        {
            InitializeComponent();
            hideFrmAddGV();
        }
        void showFrmAddGV()
        {

            labelAddGV.Visible = true;
            btnAccept.Visible = true;
            btnBack.Visible = true;
        }
        void hideFrmAddGV()
        {
            labelAddGV.Visible = false;
            btnAccept.Visible = false;
            btnBack.Visible = false;
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
        }
    }
}
