namespace QuanLiHocSinh
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel_left = new Panel();
            btnHistory = new Button();
            panel_main = new Panel();
            btnDSGV = new Button();
            button5 = new Button();
            btnTTCN = new Button();
            btnXepLoai = new Button();
            btnDiem = new Button();
            btnDSHS = new Button();
            label1 = new Label();
            panel_top = new Panel();
            panel_left.SuspendLayout();
            panel_top.SuspendLayout();
            SuspendLayout();
            // 
            // panel_left
            // 
            panel_left.Controls.Add(btnHistory);
            panel_left.Controls.Add(btnDSGV);
            panel_left.Controls.Add(button5);
            panel_left.Controls.Add(btnTTCN);
            panel_left.Controls.Add(btnXepLoai);
            panel_left.Controls.Add(btnDiem);
            panel_left.Controls.Add(btnDSHS);
            panel_left.Location = new Point(0, 0);
            panel_left.Name = "panel_left";
            panel_left.Size = new Size(154, 589);
            panel_left.TabIndex = 1;
            // 
            // btnHistory
            // 
            btnHistory.Location = new Point(3, 322);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(148, 42);
            btnHistory.TabIndex = 6;
            btnHistory.Text = "Lịch sử thao tác";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // panel_main
            // 
            panel_main.Anchor = AnchorStyles.None;
            panel_main.Location = new Point(154, 26);
            panel_main.Name = "panel_main";
            panel_main.Size = new Size(1116, 563);
            panel_main.TabIndex = 4;
            // 
            // btnDSGV
            // 
            btnDSGV.Location = new Point(3, 274);
            btnDSGV.Name = "btnDSGV";
            btnDSGV.Size = new Size(148, 42);
            btnDSGV.TabIndex = 5;
            btnDSGV.Text = "Danh sách giáo viên";
            btnDSGV.UseVisualStyleBackColor = true;
            btnDSGV.Click += btnDSGV_Click;
            // 
            // button5
            // 
            button5.Location = new Point(3, 468);
            button5.Name = "button5";
            button5.Size = new Size(148, 42);
            button5.TabIndex = 4;
            button5.Text = "Đăng xuất";
            button5.UseVisualStyleBackColor = true;
            // 
            // btnTTCN
            // 
            btnTTCN.Location = new Point(3, 82);
            btnTTCN.Name = "btnTTCN";
            btnTTCN.Size = new Size(148, 42);
            btnTTCN.TabIndex = 3;
            btnTTCN.Text = "Thông tin cá nhân";
            btnTTCN.UseVisualStyleBackColor = true;
            btnTTCN.Click += btnTTCN_Click;
            // 
            // btnXepLoai
            // 
            btnXepLoai.Location = new Point(3, 178);
            btnXepLoai.Name = "btnXepLoai";
            btnXepLoai.Size = new Size(148, 42);
            btnXepLoai.TabIndex = 2;
            btnXepLoai.Text = "Xếp loại";
            btnXepLoai.UseVisualStyleBackColor = true;
            btnXepLoai.Click += btnXepLoai_Click;
            // 
            // btnDiem
            // 
            btnDiem.Location = new Point(3, 130);
            btnDiem.Name = "btnDiem";
            btnDiem.Size = new Size(148, 42);
            btnDiem.TabIndex = 1;
            btnDiem.Text = "Điểm số\r\n";
            btnDiem.UseVisualStyleBackColor = true;
            btnDiem.Click += btnDiem_Click;
            // 
            // btnDSHS
            // 
            btnDSHS.Location = new Point(3, 226);
            btnDSHS.Name = "btnDSHS";
            btnDSHS.Size = new Size(148, 42);
            btnDSHS.TabIndex = 0;
            btnDSHS.Text = "Danh sách học sinh";
            btnDSHS.UseVisualStyleBackColor = true;
            btnDSHS.Click += btnDSHS_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(408, 2);
            label1.Name = "label1";
            label1.Size = new Size(397, 21);
            label1.TabIndex = 2;
            label1.Text = "Chào mừng bạn đến với ứng dụng quản lí học sinh";
            // 
            // panel_top
            // 
            panel_top.Controls.Add(label1);
            panel_top.Location = new Point(154, 0);
            panel_top.Name = "panel_top";
            panel_top.Size = new Size(1116, 27);
            panel_top.TabIndex = 3;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1270, 589);
            Controls.Add(panel_top);
            Controls.Add(panel_main);
            Controls.Add(panel_left);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMenu";
            panel_left.ResumeLayout(false);
            panel_top.ResumeLayout(false);
            panel_top.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_left;
        private Button button5;
        private Button btnTTCN;
        private Button btnXepLoai;
        private Button btnDiem;
        private Button btnDSHS;
        private Label label1;
        private Panel panel_top;
        private Panel panel_main;
        private Button btnHistory;
        private Button btnDSGV;
    }
}