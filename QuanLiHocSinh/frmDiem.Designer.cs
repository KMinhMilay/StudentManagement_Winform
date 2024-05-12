namespace QuanLiHocSinh
{
    partial class frmDiem
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
            groupBox1 = new GroupBox();
            lvHocSinh = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            groupBox2 = new GroupBox();
            cbbMon = new ComboBox();
            label14 = new Label();
            cbbLop = new ComboBox();
            label7 = new Label();
            btnTimKiem = new Button();
            txbTimTen = new TextBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            lbHocKi = new Label();
            label21 = new Label();
            lbNam = new Label();
            label19 = new Label();
            lbMaHS = new Label();
            label16 = new Label();
            lbDiemTBMon = new Label();
            btnCapNhat = new Button();
            nDiemCK = new NumericUpDown();
            nDiemGK = new NumericUpDown();
            nDiemQT = new NumericUpDown();
            lbMon = new Label();
            lbTen = new Label();
            lbHoVaTen = new Label();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox4 = new GroupBox();
            btnLoad = new Button();
            button3 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nDiemCK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nDiemGK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nDiemQT).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lvHocSinh);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox1.Location = new Point(17, 20);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(1151, 637);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bảng Điểm";
            // 
            // lvHocSinh
            // 
            lvHocSinh.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            lvHocSinh.Location = new Point(37, 37);
            lvHocSinh.Margin = new Padding(4, 5, 4, 5);
            lvHocSinh.Name = "lvHocSinh";
            lvHocSinh.Size = new Size(1071, 561);
            lvHocSinh.TabIndex = 0;
            lvHocSinh.UseCompatibleStateImageBehavior = false;
            lvHocSinh.View = View.Details;
            lvHocSinh.SelectedIndexChanged += lvHocSinh_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Mã hs";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Họ và tên đệm";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Tên";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Môn";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Điểm môn quá trình";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Điểm giữa kì";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Điểm cuối kì";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Điểm trung bình môn";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Năm học";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Học kì";
            columnHeader10.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbbMon);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(cbbLop);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(txbTimTen);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox2.Location = new Point(1189, 20);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(363, 490);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm kiếm";
            // 
            // cbbMon
            // 
            cbbMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbMon.FormattingEnabled = true;
            cbbMon.Location = new Point(100, 300);
            cbbMon.Margin = new Padding(4, 5, 4, 5);
            cbbMon.Name = "cbbMon";
            cbbMon.Size = new Size(195, 33);
            cbbMon.TabIndex = 6;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label14.Location = new Point(121, 270);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(151, 25);
            label14.TabIndex = 5;
            label14.Text = "và theo môn học:";
            // 
            // cbbLop
            // 
            cbbLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbLop.FormattingEnabled = true;
            cbbLop.Location = new Point(96, 207);
            cbbLop.Margin = new Padding(4, 5, 4, 5);
            cbbLop.Name = "cbbLop";
            cbbLop.Size = new Size(195, 33);
            cbbLop.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label7.Location = new Point(150, 177);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(106, 25);
            label7.TabIndex = 3;
            label7.Text = "và theo lớp:";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnTimKiem.Location = new Point(141, 368);
            btnTimKiem.Margin = new Padding(4, 5, 4, 5);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(123, 48);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "TÌM KIẾM";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txbTimTen
            // 
            txbTimTen.Location = new Point(74, 115);
            txbTimTen.Margin = new Padding(4, 5, 4, 5);
            txbTimTen.Name = "txbTimTen";
            txbTimTen.Size = new Size(240, 31);
            txbTimTen.TabIndex = 1;
            txbTimTen.KeyPress += txbTimTen_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(117, 85);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(159, 25);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm theo tên:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbHocKi);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(lbNam);
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(lbMaHS);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(lbDiemTBMon);
            groupBox3.Controls.Add(btnCapNhat);
            groupBox3.Controls.Add(nDiemCK);
            groupBox3.Controls.Add(nDiemGK);
            groupBox3.Controls.Add(nDiemQT);
            groupBox3.Controls.Add(lbMon);
            groupBox3.Controls.Add(lbTen);
            groupBox3.Controls.Add(lbHoVaTen);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox3.Location = new Point(17, 667);
            groupBox3.Margin = new Padding(4, 5, 4, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 5, 4, 5);
            groupBox3.Size = new Size(1534, 187);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin chi tiết";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // lbHocKi
            // 
            lbHocKi.AutoSize = true;
            lbHocKi.Location = new Point(630, 123);
            lbHocKi.Margin = new Padding(4, 0, 4, 0);
            lbHocKi.Name = "lbHocKi";
            lbHocKi.Size = new Size(22, 25);
            lbHocKi.TabIndex = 29;
            lbHocKi.Text = "1";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(611, 68);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(66, 25);
            label21.TabIndex = 28;
            label21.Text = "Học kì";
            // 
            // lbNam
            // 
            lbNam.AutoSize = true;
            lbNam.Location = new Point(489, 125);
            lbNam.Margin = new Padding(4, 0, 4, 0);
            lbNam.Name = "lbNam";
            lbNam.Size = new Size(99, 25);
            lbNam.TabIndex = 27;
            lbNam.Text = "2021-2022";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(506, 68);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(52, 25);
            label19.TabIndex = 26;
            label19.Text = "Năm";
            // 
            // lbMaHS
            // 
            lbMaHS.AutoSize = true;
            lbMaHS.Location = new Point(53, 125);
            lbMaHS.Margin = new Padding(4, 0, 4, 0);
            lbMaHS.Name = "lbMaHS";
            lbMaHS.Size = new Size(111, 25);
            lbMaHS.TabIndex = 19;
            lbMaHS.Text = "NguyenVan";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(71, 68);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(63, 25);
            label16.TabIndex = 18;
            label16.Text = "Mã hs";
            // 
            // lbDiemTBMon
            // 
            lbDiemTBMon.AutoSize = true;
            lbDiemTBMon.Location = new Point(1227, 125);
            lbDiemTBMon.Margin = new Padding(4, 0, 4, 0);
            lbDiemTBMon.Name = "lbDiemTBMon";
            lbDiemTBMon.Size = new Size(37, 25);
            lbDiemTBMon.TabIndex = 13;
            lbDiemTBMon.Text = "x.x";
            // 
            // btnCapNhat
            // 
            btnCapNhat.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnCapNhat.Location = new Point(1364, 88);
            btnCapNhat.Margin = new Padding(4, 5, 4, 5);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(147, 45);
            btnCapNhat.TabIndex = 5;
            btnCapNhat.Text = "CẬP NHẬT";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // nDiemCK
            // 
            nDiemCK.DecimalPlaces = 1;
            nDiemCK.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nDiemCK.Location = new Point(1024, 122);
            nDiemCK.Margin = new Padding(4, 5, 4, 5);
            nDiemCK.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nDiemCK.Name = "nDiemCK";
            nDiemCK.Size = new Size(77, 31);
            nDiemCK.TabIndex = 12;
            nDiemCK.TextAlign = HorizontalAlignment.Center;
            // 
            // nDiemGK
            // 
            nDiemGK.DecimalPlaces = 1;
            nDiemGK.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nDiemGK.Location = new Point(877, 122);
            nDiemGK.Margin = new Padding(4, 5, 4, 5);
            nDiemGK.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nDiemGK.Name = "nDiemGK";
            nDiemGK.Size = new Size(86, 31);
            nDiemGK.TabIndex = 11;
            nDiemGK.TextAlign = HorizontalAlignment.Center;
            // 
            // nDiemQT
            // 
            nDiemQT.DecimalPlaces = 1;
            nDiemQT.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nDiemQT.Location = new Point(723, 122);
            nDiemQT.Margin = new Padding(4, 5, 4, 5);
            nDiemQT.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nDiemQT.Name = "nDiemQT";
            nDiemQT.Size = new Size(86, 31);
            nDiemQT.TabIndex = 10;
            nDiemQT.TextAlign = HorizontalAlignment.Center;
            // 
            // lbMon
            // 
            lbMon.AutoSize = true;
            lbMon.Location = new Point(404, 125);
            lbMon.Margin = new Padding(4, 0, 4, 0);
            lbMon.Name = "lbMon";
            lbMon.Size = new Size(53, 25);
            lbMon.TabIndex = 9;
            lbMon.Text = "Toán";
            // 
            // lbTen
            // 
            lbTen.AutoSize = true;
            lbTen.Location = new Point(321, 125);
            lbTen.Margin = new Padding(4, 0, 4, 0);
            lbTen.Name = "lbTen";
            lbTen.Size = new Size(47, 25);
            lbTen.TabIndex = 8;
            lbTen.Text = "Anh";
            // 
            // lbHoVaTen
            // 
            lbHoVaTen.AutoSize = true;
            lbHoVaTen.Location = new Point(183, 125);
            lbHoVaTen.Margin = new Padding(4, 0, 4, 0);
            lbHoVaTen.Name = "lbHoVaTen";
            lbHoVaTen.Size = new Size(111, 25);
            lbHoVaTen.TabIndex = 7;
            lbHoVaTen.Text = "NguyenVan";
            lbHoVaTen.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(324, 68);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(42, 25);
            label9.TabIndex = 6;
            label9.Text = "Tên";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(167, 68);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(137, 25);
            label8.TabIndex = 5;
            label8.Text = "Họ và tên đệm";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1154, 68);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(194, 25);
            label6.TabIndex = 4;
            label6.Text = "Điểm trung bình môn";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1007, 68);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(119, 25);
            label5.TabIndex = 3;
            label5.Text = "Điểm Cuối kì";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(861, 68);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(123, 25);
            label4.TabIndex = 2;
            label4.Text = "Điểm Giữa Kì";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(703, 68);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(142, 25);
            label3.TabIndex = 1;
            label3.Text = "Điểm Quá trình";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(406, 68);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 0;
            label2.Text = "Môn";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnLoad);
            groupBox4.Controls.Add(button3);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox4.Location = new Point(1189, 520);
            groupBox4.Margin = new Padding(4, 5, 4, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4, 5, 4, 5);
            groupBox4.Size = new Size(363, 137);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Khác";
            // 
            // btnLoad
            // 
            btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnLoad.Location = new Point(193, 58);
            btnLoad.Margin = new Padding(4, 5, 4, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(123, 42);
            btnLoad.TabIndex = 8;
            btnLoad.Text = "TẢI LẠI";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button3.Location = new Point(66, 58);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(119, 42);
            button3.TabIndex = 7;
            button3.Text = "THỐNG KÊ";
            button3.UseVisualStyleBackColor = true;
            // 
            // frmDiem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1571, 873);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmDiem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDiem";
            Load += frmDiem_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nDiemCK).EndInit();
            ((System.ComponentModel.ISupportInitialize)nDiemGK).EndInit();
            ((System.ComponentModel.ISupportInitialize)nDiemQT).EndInit();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Button btnTimKiem;
        private TextBox txbTimTen;
        private GroupBox groupBox3;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cbbLop;
        private Label label7;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label lbHoVaTen;
        private Label lbDiemTBMon;
        private NumericUpDown nDiemCK;
        private NumericUpDown nDiemGK;
        private NumericUpDown nDiemQT;
        private Button btnCapNhat;
        private Label lbMon;
        private Label lbTen;
        private ListView lvHocSinh;
        private ComboBox cbbMon;
        private Label label14;
        private GroupBox groupBox4;
        private Button button3;
        private Button btnLoad;
        private Label lbMaHS;
        private Label label16;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Label lbHocKi;
        private Label label21;
        private Label lbNam;
        private Label label19;
    }
}