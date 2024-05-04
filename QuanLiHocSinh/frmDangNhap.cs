using QuanLiHocSinh.DAO;
using QuanLiHocSinh.DTO;

namespace QuanLiHocSinh
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (allInfoIsFilled())
            {
                Account account = AuthDAO.Instance.GetAccount(txbUsername.Text, txbPassword.Text, loginRole());
                if (account != null)
                {

                    frmMain form = new frmMain(account);
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool allInfoIsFilled()
        {
            return Controls.OfType<TextBox>().All(tb => !string.IsNullOrEmpty(tb.Text)) && Controls.OfType<RadioButton>().Any(rbtn => rbtn.Checked);
        }
        private string loginRole()
        {
            if (rbtnAdmin.Checked) return "3";
            else if (rbtnTeacher.Checked) return "2";
            else if (rbtnClassMonitor.Checked) return "1";
            else return "0";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
