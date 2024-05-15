namespace QuanLiHocSinh
{
    partial class frmDangNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txbUsername = new TextBox();
            txbPassword = new TextBox();
            rbtnStudent = new RadioButton();
            rbtnClassMonitor = new RadioButton();
            rbtnTeacher = new RadioButton();
            rbtnAdmin = new RadioButton();
            btnLogin = new Button();
            btnExit = new Button();
            cbxShowHide = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(310, 191);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(310, 255);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // txbUsername
            // 
            txbUsername.Location = new Point(415, 187);
            txbUsername.Margin = new Padding(3, 4, 3, 4);
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(263, 27);
            txbUsername.TabIndex = 2;
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(415, 251);
            txbPassword.Margin = new Padding(3, 4, 3, 4);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(263, 27);
            txbPassword.TabIndex = 3;
            txbPassword.UseSystemPasswordChar = true;
            // 
            // rbtnStudent
            // 
            rbtnStudent.AutoSize = true;
            rbtnStudent.Location = new Point(304, 337);
            rbtnStudent.Margin = new Padding(3, 4, 3, 4);
            rbtnStudent.Name = "rbtnStudent";
            rbtnStudent.Size = new Size(87, 24);
            rbtnStudent.TabIndex = 4;
            rbtnStudent.TabStop = true;
            rbtnStudent.Text = "Học sinh";
            rbtnStudent.UseVisualStyleBackColor = true;
            // 
            // rbtnClassMonitor
            // 
            rbtnClassMonitor.AutoSize = true;
            rbtnClassMonitor.Location = new Point(393, 337);
            rbtnClassMonitor.Margin = new Padding(3, 4, 3, 4);
            rbtnClassMonitor.Name = "rbtnClassMonitor";
            rbtnClassMonitor.Size = new Size(104, 24);
            rbtnClassMonitor.TabIndex = 5;
            rbtnClassMonitor.TabStop = true;
            rbtnClassMonitor.Text = "Lớp trưởng";
            rbtnClassMonitor.UseVisualStyleBackColor = true;
            // 
            // rbtnTeacher
            // 
            rbtnTeacher.AutoSize = true;
            rbtnTeacher.Location = new Point(496, 337);
            rbtnTeacher.Margin = new Padding(3, 4, 3, 4);
            rbtnTeacher.Name = "rbtnTeacher";
            rbtnTeacher.Size = new Size(92, 24);
            rbtnTeacher.TabIndex = 6;
            rbtnTeacher.TabStop = true;
            rbtnTeacher.Text = "Giáo viên";
            rbtnTeacher.UseVisualStyleBackColor = true;
            // 
            // rbtnAdmin
            // 
            rbtnAdmin.AutoSize = true;
            rbtnAdmin.Location = new Point(587, 337);
            rbtnAdmin.Margin = new Padding(3, 4, 3, 4);
            rbtnAdmin.Name = "rbtnAdmin";
            rbtnAdmin.Size = new Size(114, 24);
            rbtnAdmin.TabIndex = 7;
            rbtnAdmin.TabStop = true;
            rbtnAdmin.Text = "Quản trị viên";
            rbtnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(484, 387);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(97, 41);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(593, 387);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(86, 41);
            btnExit.TabIndex = 9;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // cbxShowHide
            // 
            cbxShowHide.AutoSize = true;
            cbxShowHide.Location = new Point(415, 293);
            cbxShowHide.Margin = new Padding(3, 4, 3, 4);
            cbxShowHide.Name = "cbxShowHide";
            cbxShowHide.Size = new Size(127, 24);
            cbxShowHide.TabIndex = 10;
            cbxShowHide.Text = "Hiện mật khẩu";
            cbxShowHide.UseVisualStyleBackColor = true;
            cbxShowHide.CheckedChanged += cbxShowHide_CheckedChanged;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 557);
            Controls.Add(cbxShowHide);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(rbtnAdmin);
            Controls.Add(rbtnTeacher);
            Controls.Add(rbtnClassMonitor);
            Controls.Add(rbtnStudent);
            Controls.Add(txbPassword);
            Controls.Add(txbUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            FormClosing += frmDangNhap_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txbUsername;
        private TextBox txbPassword;
        private RadioButton rbtnStudent;
        private RadioButton rbtnClassMonitor;
        private RadioButton rbtnTeacher;
        private RadioButton rbtnAdmin;
        private Button btnLogin;
        private Button btnExit;
        private CheckBox cbxShowHide;
    }
}
