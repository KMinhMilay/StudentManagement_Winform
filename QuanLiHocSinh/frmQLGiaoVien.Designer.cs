namespace QuanLiHocSinh
{
    partial class frmQLGiaoVien
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
            groupBox4 = new GroupBox();
            txbIdSearch = new TextBox();
            txbNameSearch = new TextBox();
            cmbClassSearch = new ComboBox();
            btnSearch = new Button();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            groupBox3 = new GroupBox();
            btnRefresh = new Button();
            btnAdd = new Button();
            btnStatisticize = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            grpBoxForm = new GroupBox();
            txbId = new TextBox();
            btnBack = new Button();
            btnAccept = new Button();
            txbSalary = new TextBox();
            label16 = new Label();
            cmbSubject = new ComboBox();
            label11 = new Label();
            cmbHomeroomClass = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cmbHometown = new ComboBox();
            label7 = new Label();
            txbPhoneNumber = new TextBox();
            label8 = new Label();
            txbEmail = new TextBox();
            label9 = new Label();
            txbAddress = new TextBox();
            label10 = new Label();
            cmbGender = new ComboBox();
            txbLastname = new TextBox();
            birthdatePicker = new DateTimePicker();
            txbFirstname = new TextBox();
            groupBox1 = new GroupBox();
            labelAddGV = new Label();
            listViewGiaoVien = new ListView();
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
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            grpBoxForm.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txbIdSearch);
            groupBox4.Controls.Add(txbNameSearch);
            groupBox4.Controls.Add(cmbClassSearch);
            groupBox4.Controls.Add(btnSearch);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(label12);
            groupBox4.Location = new Point(10, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1080, 63);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Tìm kiếm";
            // 
            // txbIdSearch
            // 
            txbIdSearch.Location = new Point(191, 24);
            txbIdSearch.Name = "txbIdSearch";
            txbIdSearch.Size = new Size(197, 23);
            txbIdSearch.TabIndex = 9;
            // 
            // txbNameSearch
            // 
            txbNameSearch.Location = new Point(502, 23);
            txbNameSearch.Name = "txbNameSearch";
            txbNameSearch.Size = new Size(197, 23);
            txbNameSearch.TabIndex = 8;
            // 
            // cmbClassSearch
            // 
            cmbClassSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassSearch.FormattingEnabled = true;
            cmbClassSearch.Location = new Point(797, 23);
            cmbClassSearch.Name = "cmbClassSearch";
            cmbClassSearch.Size = new Size(123, 23);
            cmbClassSearch.TabIndex = 7;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(927, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(88, 27);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "TÌM KIẾM";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(774, 26);
            label15.Name = "label15";
            label15.Size = new Size(0, 15);
            label15.TabIndex = 3;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(705, 26);
            label14.Name = "label14";
            label14.Size = new Size(83, 15);
            label14.TabIndex = 2;
            label14.Text = "hoặc theo lớp ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(413, 27);
            label13.Name = "label13";
            label13.Size = new Size(83, 15);
            label13.TabIndex = 1;
            label13.Text = "hoặc theo tên:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(64, 27);
            label12.Name = "label12";
            label12.Size = new Size(122, 15);
            label12.TabIndex = 0;
            label12.Text = "Tìm kiếm theo Mã gv:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnRefresh);
            groupBox3.Controls.Add(btnAdd);
            groupBox3.Controls.Add(btnStatisticize);
            groupBox3.Controls.Add(btnUpdate);
            groupBox3.Controls.Add(btnDelete);
            groupBox3.Location = new Point(10, 454);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1080, 67);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Khác";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(651, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(88, 39);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "TẢI LẠI";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(369, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 39);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "THÊM";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += button3_Click;
            // 
            // btnStatisticize
            // 
            btnStatisticize.Location = new Point(745, 20);
            btnStatisticize.Name = "btnStatisticize";
            btnStatisticize.Size = new Size(88, 39);
            btnStatisticize.TabIndex = 4;
            btnStatisticize.Text = "THỐNG KÊ";
            btnStatisticize.UseVisualStyleBackColor = true;
            btnStatisticize.Click += btnStatisticize_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Enabled = false;
            btnUpdate.Location = new Point(463, 20);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(88, 39);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "CẬP NHẬT";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(557, 20);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 39);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "XÓA";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // grpBoxForm
            // 
            grpBoxForm.Controls.Add(txbId);
            grpBoxForm.Controls.Add(btnBack);
            grpBoxForm.Controls.Add(btnAccept);
            grpBoxForm.Controls.Add(txbSalary);
            grpBoxForm.Controls.Add(label16);
            grpBoxForm.Controls.Add(cmbSubject);
            grpBoxForm.Controls.Add(label11);
            grpBoxForm.Controls.Add(cmbHomeroomClass);
            grpBoxForm.Controls.Add(label1);
            grpBoxForm.Controls.Add(label2);
            grpBoxForm.Controls.Add(label3);
            grpBoxForm.Controls.Add(label4);
            grpBoxForm.Controls.Add(label5);
            grpBoxForm.Controls.Add(label6);
            grpBoxForm.Controls.Add(cmbHometown);
            grpBoxForm.Controls.Add(label7);
            grpBoxForm.Controls.Add(txbPhoneNumber);
            grpBoxForm.Controls.Add(label8);
            grpBoxForm.Controls.Add(txbEmail);
            grpBoxForm.Controls.Add(label9);
            grpBoxForm.Controls.Add(txbAddress);
            grpBoxForm.Controls.Add(label10);
            grpBoxForm.Controls.Add(cmbGender);
            grpBoxForm.Controls.Add(txbLastname);
            grpBoxForm.Controls.Add(birthdatePicker);
            grpBoxForm.Controls.Add(txbFirstname);
            grpBoxForm.Location = new Point(679, 73);
            grpBoxForm.Name = "grpBoxForm";
            grpBoxForm.Size = new Size(411, 375);
            grpBoxForm.TabIndex = 5;
            grpBoxForm.TabStop = false;
            grpBoxForm.Text = "Thông tin";
            // 
            // txbId
            // 
            txbId.Location = new Point(111, 39);
            txbId.Name = "txbId";
            txbId.Size = new Size(128, 23);
            txbId.TabIndex = 37;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(234, 333);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(73, 25);
            btnBack.TabIndex = 57;
            btnBack.Text = "Trở về";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(146, 333);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(73, 25);
            btnAccept.TabIndex = 56;
            btnAccept.Text = "Xác nhận";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // txbSalary
            // 
            txbSalary.Location = new Point(279, 245);
            txbSalary.Name = "txbSalary";
            txbSalary.Size = new Size(112, 23);
            txbSalary.TabIndex = 56;
            txbSalary.KeyPress += txbSalary_KeyPress;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(279, 216);
            label16.Name = "label16";
            label16.Size = new Size(44, 15);
            label16.TabIndex = 55;
            label16.Text = "Lương:";
            // 
            // cmbSubject
            // 
            cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(279, 179);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(112, 23);
            cmbSubject.TabIndex = 54;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(279, 152);
            label11.Name = "label11";
            label11.Size = new Size(112, 15);
            label11.TabIndex = 53;
            label11.Text = "Môn học phụ trách:";
            // 
            // cmbHomeroomClass
            // 
            cmbHomeroomClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHomeroomClass.FormattingEnabled = true;
            cmbHomeroomClass.Location = new Point(279, 115);
            cmbHomeroomClass.Name = "cmbHomeroomClass";
            cmbHomeroomClass.Size = new Size(112, 23);
            cmbHomeroomClass.TabIndex = 52;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(279, 88);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 49;
            label1.Text = "Lớp chủ nhiệm:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 42);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 27;
            label2.Text = "ID tài khoản:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 72);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 28;
            label3.Text = "Họ và tên đệm:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 102);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 29;
            label4.Text = "Tên: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 135);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 30;
            label5.Text = "Năm sinh";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 166);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 31;
            label6.Text = "Giới tính: ";
            // 
            // cmbHometown
            // 
            cmbHometown.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHometown.FormattingEnabled = true;
            cmbHometown.Items.AddRange(new object[] { "An Giang", "Bà Rịa-Vũng Tàu", "Bạc Liêu", "Bắc Kạn", "Bắc Giang", "Bắc Ninh", "Bến Tre", "Bình Dương", "Bình Định", "Bình Phước", "Bình Thuận", "Cà Mau", "Cao Bằng", "Cần Thơ", "Đà Nẵng", "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tây", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hòa Bình", "TP. Hồ Chí Minh", "Hậu Giang", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lào Cai", "Lạng Sơn", "Lâm Đồng", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên – Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái" });
            cmbHometown.Location = new Point(111, 197);
            cmbHometown.Name = "cmbHometown";
            cmbHometown.Size = new Size(128, 23);
            cmbHometown.TabIndex = 43;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 200);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 32;
            label7.Text = "Quê quán:";
            // 
            // txbPhoneNumber
            // 
            txbPhoneNumber.Location = new Point(111, 297);
            txbPhoneNumber.Name = "txbPhoneNumber";
            txbPhoneNumber.Size = new Size(128, 23);
            txbPhoneNumber.TabIndex = 42;
            txbPhoneNumber.KeyPress += txbPhoneNumber_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 235);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 33;
            label8.Text = "Địa chỉ:";
            // 
            // txbEmail
            // 
            txbEmail.Location = new Point(111, 264);
            txbEmail.Name = "txbEmail";
            txbEmail.Size = new Size(128, 23);
            txbEmail.TabIndex = 41;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 267);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 34;
            label9.Text = "Email: ";
            // 
            // txbAddress
            // 
            txbAddress.Location = new Point(111, 232);
            txbAddress.Name = "txbAddress";
            txbAddress.Size = new Size(128, 23);
            txbAddress.TabIndex = 40;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 300);
            label10.Name = "label10";
            label10.Size = new Size(29, 15);
            label10.TabIndex = 35;
            label10.Text = "SDT:";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cmbGender.Location = new Point(111, 163);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(128, 23);
            cmbGender.TabIndex = 39;
            // 
            // txbLastname
            // 
            txbLastname.Location = new Point(111, 69);
            txbLastname.Name = "txbLastname";
            txbLastname.Size = new Size(128, 23);
            txbLastname.TabIndex = 36;
            // 
            // birthdatePicker
            // 
            birthdatePicker.Format = DateTimePickerFormat.Short;
            birthdatePicker.Location = new Point(111, 131);
            birthdatePicker.Name = "birthdatePicker";
            birthdatePicker.Size = new Size(128, 23);
            birthdatePicker.TabIndex = 38;
            // 
            // txbFirstname
            // 
            txbFirstname.Location = new Point(111, 99);
            txbFirstname.Name = "txbFirstname";
            txbFirstname.Size = new Size(128, 23);
            txbFirstname.TabIndex = 37;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelAddGV);
            groupBox1.Controls.Add(listViewGiaoVien);
            groupBox1.Location = new Point(10, 73);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(655, 375);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách";
            // 
            // labelAddGV
            // 
            labelAddGV.AutoSize = true;
            labelAddGV.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            labelAddGV.Location = new Point(225, 171);
            labelAddGV.Name = "labelAddGV";
            labelAddGV.Size = new Size(212, 32);
            labelAddGV.TabIndex = 11;
            labelAddGV.Text = "THÊM GIÁO VIÊN";
            // 
            // listViewGiaoVien
            // 
            listViewGiaoVien.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            listViewGiaoVien.FullRowSelect = true;
            listViewGiaoVien.Location = new Point(12, 26);
            listViewGiaoVien.MultiSelect = false;
            listViewGiaoVien.Name = "listViewGiaoVien";
            listViewGiaoVien.Size = new Size(633, 332);
            listViewGiaoVien.TabIndex = 0;
            listViewGiaoVien.UseCompatibleStateImageBehavior = false;
            listViewGiaoVien.View = View.Details;
            listViewGiaoVien.SelectedIndexChanged += listViewGiaoVien_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID ";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Họ và tên đệm";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Tên";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Năm sinh";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Giới tính";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Quê quán";
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Địa chỉ";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Email";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "SĐT";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Lớp chủ nhiệm";
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Môn học phụ trách";
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Lương";
            // 
            // frmQLGiaoVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 524);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(grpBoxForm);
            Controls.Add(groupBox1);
            Name = "frmQLGiaoVien";
            Text = "frmQLGiaoVien";
            Load += frmQLGiaoVien_Load;
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            grpBoxForm.ResumeLayout(false);
            grpBoxForm.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox4;
        private TextBox txbIdSearch;
        private ComboBox cmbClassSearch;
        private Button btnSearch;
        private Label label15;
        private Label label14;
        private Label label12;
        private GroupBox groupBox3;
        private Button btnRefresh;
        private Button btnAdd;
        private Button btnStatisticize;
        private Button btnUpdate;
        private Button btnDelete;
        private GroupBox grpBoxForm;
        private ComboBox cmbHomeroomClass;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cmbHometown;
        private Label label7;
        private TextBox txbPhoneNumber;
        private Label label8;
        private TextBox txbEmail;
        private Label label9;
        private TextBox txbAddress;
        private Label label10;
        private ComboBox cmbGender;
        private TextBox txbLastname;
        private DateTimePicker birthdatePicker;
        private TextBox txbFirstname;
        private GroupBox groupBox1;
        private ListView listViewGiaoVien;
        private TextBox txbNameSearch;
        private Label label13;
        private TextBox txbSalary;
        private Label label16;
        private ComboBox cmbSubject;
        private Label label11;
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
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private Label labelAddGV;
        private Button btnBack;
        private Button btnAccept;
        private TextBox txbId;
    }
}