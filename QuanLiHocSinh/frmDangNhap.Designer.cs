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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(271, 143);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(271, 191);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // txbUsername
            // 
            txbUsername.Location = new Point(363, 140);
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(231, 23);
            txbUsername.TabIndex = 2;
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(363, 188);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(231, 23);
            txbPassword.TabIndex = 3;
            // 
            // rbtnStudent
            // 
            rbtnStudent.AutoSize = true;
            rbtnStudent.Location = new Point(266, 242);
            rbtnStudent.Name = "rbtnStudent";
            rbtnStudent.Size = new Size(72, 19);
            rbtnStudent.TabIndex = 4;
            rbtnStudent.TabStop = true;
            rbtnStudent.Text = "Học sinh";
            rbtnStudent.UseVisualStyleBackColor = true;
            // 
            // rbtnClassMonitor
            // 
            rbtnClassMonitor.AutoSize = true;
            rbtnClassMonitor.Location = new Point(344, 242);
            rbtnClassMonitor.Name = "rbtnClassMonitor";
            rbtnClassMonitor.Size = new Size(84, 19);
            rbtnClassMonitor.TabIndex = 5;
            rbtnClassMonitor.TabStop = true;
            rbtnClassMonitor.Text = "Lớp trưởng";
            rbtnClassMonitor.UseVisualStyleBackColor = true;
            // 
            // rbtnTeacher
            // 
            rbtnTeacher.AutoSize = true;
            rbtnTeacher.Location = new Point(434, 242);
            rbtnTeacher.Name = "rbtnTeacher";
            rbtnTeacher.Size = new Size(74, 19);
            rbtnTeacher.TabIndex = 6;
            rbtnTeacher.TabStop = true;
            rbtnTeacher.Text = "Giáo viên";
            rbtnTeacher.UseVisualStyleBackColor = true;
            // 
            // rbtnAdmin
            // 
            rbtnAdmin.AutoSize = true;
            rbtnAdmin.Location = new Point(514, 242);
            rbtnAdmin.Name = "rbtnAdmin";
            rbtnAdmin.Size = new Size(93, 19);
            rbtnAdmin.TabIndex = 7;
            rbtnAdmin.TabStop = true;
            rbtnAdmin.Text = "Quản trị viên";
            rbtnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(433, 279);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 31);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(519, 279);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 31);
            btnExit.TabIndex = 9;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 418);
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
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
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
    }
}
