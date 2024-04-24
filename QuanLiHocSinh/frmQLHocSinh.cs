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
    public partial class frmQLHocSinh : Form
    {
        public frmQLHocSinh()
        {
            InitializeComponent();
            hideFrmAddHS();
        }
        void showFrmAddHS()
        {
            labelAddHS.Visible = true;
            btnAccept.Visible = true;
            btnBack.Visible = true;
        }
        void hideFrmAddHS()
        {
            labelAddHS.Visible = false;
            btnAccept.Visible = false;
            btnBack.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listViewHocSinh.Visible = false;
            showFrmAddHS();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            listViewHocSinh.Visible = true;
            hideFrmAddHS();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }
    }
}
