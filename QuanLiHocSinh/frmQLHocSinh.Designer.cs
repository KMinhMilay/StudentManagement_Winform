namespace QuanLiHocSinh
{
    partial class frmQLHocSinh
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
            label19 = new Label();
            listViewHocSinh = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader17 = new ColumnHeader();
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
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            groupBox2 = new GroupBox();
            comboBox6 = new ComboBox();
            btnBack = new Button();
            btnAccept = new Button();
            comboBox5 = new ComboBox();
            label16 = new Label();
            comboBox3 = new ComboBox();
            textBox6 = new TextBox();
            label11 = new Label();
            label1 = new Label();
            labelMTK = new Label();
            label2 = new Label();
            textBox8 = new TextBox();
            label3 = new Label();
            textBox9 = new TextBox();
            label4 = new Label();
            label17 = new Label();
            label5 = new Label();
            label18 = new Label();
            label6 = new Label();
            comboBox2 = new ComboBox();
            label7 = new Label();
            textBox5 = new TextBox();
            label8 = new Label();
            textBox4 = new TextBox();
            label9 = new Label();
            textBox3 = new TextBox();
            label10 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            groupBox3 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            button5 = new Button();
            button2 = new Button();
            button1 = new Button();
            groupBox4 = new GroupBox();
            textBox10 = new TextBox();
            textBox7 = new TextBox();
            comboBox4 = new ComboBox();
            button6 = new Button();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(listViewHocSinh);
            groupBox1.Location = new Point(9, 96);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(749, 500);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 40F);
            label19.Location = new Point(135, 208);
            label19.Name = "label19";
            label19.Size = new Size(486, 89);
            label19.TabIndex = 1;
            label19.Text = "Thêm Học Sinh";
            // 
            // listViewHocSinh
            // 
            listViewHocSinh.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader17, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12, columnHeader13, columnHeader14, columnHeader15, columnHeader16 });
            listViewHocSinh.FullRowSelect = true;
            listViewHocSinh.Location = new Point(14, 29);
            listViewHocSinh.Margin = new Padding(3, 4, 3, 4);
            listViewHocSinh.MultiSelect = false;
            listViewHocSinh.Name = "listViewHocSinh";
            listViewHocSinh.Size = new Size(723, 447);
            listViewHocSinh.TabIndex = 0;
            listViewHocSinh.UseCompatibleStateImageBehavior = false;
            listViewHocSinh.View = View.Details;
            listViewHocSinh.SelectedIndexChanged += listViewHocSinh_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Họ";
            columnHeader2.Width = 100;
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "Tên";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Chức vụ";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Ngày sinh";
            columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Giới tính";
            columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Quê quán";
            columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Địa chỉ";
            columnHeader7.Width = 200;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Email";
            columnHeader8.Width = 180;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "SĐT";
            columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Lớp";
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "GVCN";
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Tên Phụ huynh";
            columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "SĐT Phụ huynh";
            columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Trạng thái";
            columnHeader14.Width = 80;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Tên đăng nhập";
            columnHeader15.Width = 100;
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "isEnable";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox6);
            groupBox2.Controls.Add(btnBack);
            groupBox2.Controls.Add(btnAccept);
            groupBox2.Controls.Add(comboBox5);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(comboBox3);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(labelMTK);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBox8);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox9);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Location = new Point(774, 96);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(470, 500);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin";
            // 
            // comboBox6
            // 
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.FormattingEnabled = true;
            comboBox6.Items.AddRange(new object[] { "Lớp trưởng", "Lớp phó", "Học sinh" });
            comboBox6.Location = new Point(127, 130);
            comboBox6.Margin = new Padding(3, 4, 3, 4);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(146, 28);
            comboBox6.TabIndex = 56;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(262, 444);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(83, 33);
            btnBack.TabIndex = 55;
            btnBack.Text = "Trở về";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(161, 444);
            btnAccept.Margin = new Padding(3, 4, 3, 4);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(83, 33);
            btnAccept.TabIndex = 6;
            btnAccept.Text = "Xác nhận";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "Đang học", "Bảo lưu", "Nghỉ học", "Chuyển trường" });
            comboBox5.Location = new Point(313, 393);
            comboBox5.Margin = new Padding(3, 4, 3, 4);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(135, 28);
            comboBox5.TabIndex = 54;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(311, 353);
            label16.Name = "label16";
            label16.Size = new Size(75, 20);
            label16.TabIndex = 53;
            label16.Text = "Trạng thái";
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(361, 49);
            comboBox3.Margin = new Padding(3, 4, 3, 4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(87, 28);
            comboBox3.TabIndex = 52;
            comboBox3.TextChanged += comboBox3_TextChanged;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(311, 127);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(138, 27);
            textBox6.TabIndex = 51;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(311, 93);
            label11.Name = "label11";
            label11.Size = new Size(148, 20);
            label11.TabIndex = 50;
            label11.Text = "Giáo viên Chủ nhiệm:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(311, 53);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 49;
            label1.Text = "Lớp:";
            // 
            // labelMTK
            // 
            labelMTK.AutoSize = true;
            labelMTK.Location = new Point(146, 53);
            labelMTK.Name = "labelMTK";
            labelMTK.Size = new Size(107, 20);
            labelMTK.TabIndex = 48;
            labelMTK.Text = "\"Mã tài khoản\"";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 53);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 27;
            label2.Text = "ID tài khoản:";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(312, 305);
            textBox8.Margin = new Padding(3, 4, 3, 4);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(137, 27);
            textBox8.TabIndex = 47;
            textBox8.TextChanged += textBox8_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 93);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 28;
            label3.Text = "Họ và tên:";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(311, 212);
            textBox9.Margin = new Padding(3, 4, 3, 4);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(137, 27);
            textBox9.TabIndex = 46;
            textBox9.TextChanged += textBox9_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 133);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 29;
            label4.Text = "Chức vụ:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(311, 269);
            label17.Name = "label17";
            label17.Size = new Size(99, 20);
            label17.TabIndex = 45;
            label17.Text = "Họ và tên PH:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 177);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 30;
            label5.Text = "Ngày sinh";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(310, 173);
            label18.Name = "label18";
            label18.Size = new Size(107, 20);
            label18.TabIndex = 44;
            label18.Text = "SDT phụ huynh";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 219);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 31;
            label6.Text = "Giới tính: ";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "An Giang", "Bà Rịa - Vũng tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh ", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước ", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Đà Lạt", "Đà Nẵng", "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hạ Long", "Hà Nam", "Hà Nội", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hậu Giang", "Hòa Bình", "Huế", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang", "TP.HCM", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái", "NULL" });
            comboBox2.Location = new Point(127, 260);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(146, 28);
            comboBox2.TabIndex = 43;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 264);
            label7.Name = "label7";
            label7.Size = new Size(76, 20);
            label7.TabIndex = 32;
            label7.Text = "Quê quán:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(127, 393);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(146, 27);
            textBox5.TabIndex = 42;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 311);
            label8.Name = "label8";
            label8.Size = new Size(58, 20);
            label8.TabIndex = 33;
            label8.Text = "Địa chỉ:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(127, 349);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(146, 27);
            textBox4.TabIndex = 41;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 353);
            label9.Name = "label9";
            label9.Size = new Size(53, 20);
            label9.TabIndex = 34;
            label9.Text = "Email: ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(127, 307);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(146, 27);
            textBox3.TabIndex = 40;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 397);
            label10.Name = "label10";
            label10.Size = new Size(38, 20);
            label10.TabIndex = 35;
            label10.Text = "SDT:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            comboBox1.Location = new Point(127, 215);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(146, 28);
            comboBox1.TabIndex = 39;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(127, 89);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(146, 27);
            textBox1.TabIndex = 36;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(127, 172);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(146, 27);
            dateTimePicker1.TabIndex = 38;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button4);
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(button5);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(button1);
            groupBox3.Location = new Point(9, 604);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(1234, 89);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Khác";
            // 
            // button4
            // 
            button4.Location = new Point(744, 27);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(101, 52);
            button4.TabIndex = 5;
            button4.Text = "TẢI LẠI";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(422, 27);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(101, 52);
            button3.TabIndex = 2;
            button3.Text = "THÊM";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(851, 27);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(101, 52);
            button5.TabIndex = 4;
            button5.Text = "THỐNG KÊ";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.Location = new Point(529, 27);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(101, 52);
            button2.TabIndex = 1;
            button2.Text = "CẬP NHẬT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(637, 27);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(101, 52);
            button1.TabIndex = 0;
            button1.Text = "XÓA";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBox10);
            groupBox4.Controls.Add(textBox7);
            groupBox4.Controls.Add(comboBox4);
            groupBox4.Controls.Add(button6);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(label12);
            groupBox4.Location = new Point(9, 4);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(1234, 84);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Tìm kiếm";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(218, 32);
            textBox10.Margin = new Padding(3, 4, 3, 4);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(225, 27);
            textBox10.TabIndex = 9;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(574, 31);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(225, 27);
            textBox7.TabIndex = 8;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(911, 31);
            comboBox4.Margin = new Padding(3, 4, 3, 4);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(140, 28);
            comboBox4.TabIndex = 7;
            // 
            // button6
            // 
            button6.Location = new Point(1059, 28);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(101, 36);
            button6.TabIndex = 6;
            button6.Text = "TÌM KIẾM";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(885, 35);
            label15.Name = "label15";
            label15.Size = new Size(0, 20);
            label15.TabIndex = 3;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(806, 35);
            label14.Name = "label14";
            label14.Size = new Size(108, 20);
            label14.TabIndex = 2;
            label14.Text = "hoặc theo Lớp ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(450, 36);
            label13.Name = "label13";
            label13.Size = new Size(127, 20);
            label13.TabIndex = 1;
            label13.Text = "hoặc theo Họ tên:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(73, 36);
            label12.Name = "label12";
            label12.Size = new Size(150, 20);
            label12.TabIndex = 0;
            label12.Text = "Tìm kiếm theo Mã hs:";
            // 
            // frmQLHocSinh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 699);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmQLHocSinh";
            Text = "frmQLHocSinh";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label labelMTK;
        private Label label2;
        private TextBox textBox8;
        private Label label3;
        private TextBox textBox9;
        private Label label4;
        private Label label17;
        private Label label5;
        private Label label18;
        private Label label6;
        private ComboBox comboBox2;
        private Label label7;
        private TextBox textBox5;
        private Label label8;
        private TextBox textBox4;
        private Label label9;
        private TextBox textBox3;
        private Label label10;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private GroupBox groupBox3;
        private Button button3;
        private Button button2;
        private Button button1;
        private GroupBox groupBox4;
        private Label label11;
        private Label label1;
        private ComboBox comboBox3;
        private TextBox textBox6;
        private Button button4;
        private Button button5;
        private Label label14;
        private Label label13;
        private Label label12;
        private ListView listViewHocSinh;
        private TextBox textBox10;
        private TextBox textBox7;
        private ComboBox comboBox4;
        private Button button6;
        private Label label15;
        private ComboBox comboBox5;
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
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private Button btnAccept;
        private Button btnBack;
        private ComboBox comboBox6;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private Label label19;
    }
}