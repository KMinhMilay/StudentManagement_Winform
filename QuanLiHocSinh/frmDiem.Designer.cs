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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            groupBox2 = new GroupBox();
            comboBox2 = new ComboBox();
            label14 = new Label();
            comboBox1 = new ComboBox();
            label7 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            label15 = new Label();
            label16 = new Label();
            label13 = new Label();
            button2 = new Button();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox4 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            label20 = new Label();
            label21 = new Label();
            label17 = new Label();
            label19 = new Label();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listView1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(806, 382);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bảng Điểm";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            listView1.Location = new Point(26, 22);
            listView1.Name = "listView1";
            listView1.Size = new Size(751, 338);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox2.Location = new Point(832, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(254, 294);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm kiếm";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(70, 180);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(138, 23);
            comboBox2.TabIndex = 6;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label14.Location = new Point(85, 162);
            label14.Name = "label14";
            label14.Size = new Size(100, 15);
            label14.TabIndex = 5;
            label14.Text = "và theo môn học:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(67, 124);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 23);
            comboBox1.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label7.Location = new Point(105, 106);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 3;
            label7.Text = "và theo lớp:";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button1.Location = new Point(99, 221);
            button1.Name = "button1";
            button1.Size = new Size(86, 29);
            button1.TabIndex = 2;
            button1.Text = "TÌM KIẾM";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(52, 69);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(82, 51);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm theo tên:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(numericUpDown3);
            groupBox3.Controls.Add(numericUpDown2);
            groupBox3.Controls.Add(numericUpDown1);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox3.Location = new Point(12, 400);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1074, 112);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin chi tiết";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(37, 75);
            label15.Name = "label15";
            label15.Size = new Size(70, 15);
            label15.TabIndex = 19;
            label15.Text = "NguyenVan";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(50, 41);
            label16.Name = "label16";
            label16.Size = new Size(39, 15);
            label16.TabIndex = 18;
            label16.Text = "Mã hs";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(859, 75);
            label13.Name = "label13";
            label13.Size = new Size(24, 15);
            label13.TabIndex = 13;
            label13.Text = "x.x";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button2.Location = new Point(955, 53);
            button2.Name = "button2";
            button2.Size = new Size(103, 27);
            button2.TabIndex = 5;
            button2.Text = "CẬP NHẬT";
            button2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 1;
            numericUpDown3.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown3.Location = new Point(717, 73);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(54, 23);
            numericUpDown3.TabIndex = 12;
            numericUpDown3.TextAlign = HorizontalAlignment.Center;
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 1;
            numericUpDown2.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown2.Location = new Point(614, 73);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(60, 23);
            numericUpDown2.TabIndex = 11;
            numericUpDown2.TextAlign = HorizontalAlignment.Center;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown1.Location = new Point(506, 73);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(60, 23);
            numericUpDown1.TabIndex = 10;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(283, 75);
            label12.Name = "label12";
            label12.Size = new Size(33, 15);
            label12.TabIndex = 9;
            label12.Text = "Toán";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(225, 75);
            label11.Name = "label11";
            label11.Size = new Size(29, 15);
            label11.TabIndex = 8;
            label11.Text = "Anh";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(128, 75);
            label10.Name = "label10";
            label10.Size = new Size(70, 15);
            label10.TabIndex = 7;
            label10.Text = "NguyenVan";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(227, 41);
            label9.Name = "label9";
            label9.Size = new Size(27, 15);
            label9.TabIndex = 6;
            label9.Text = "Tên";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(117, 41);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 5;
            label8.Text = "Họ và tên đệm";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(808, 41);
            label6.Name = "label6";
            label6.Size = new Size(126, 15);
            label6.TabIndex = 4;
            label6.Text = "Điểm trung bình môn";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(705, 41);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 3;
            label5.Text = "Điểm Cuối kì";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(603, 41);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 2;
            label4.Text = "Điểm Giữa Kì";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(492, 41);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 1;
            label3.Text = "Điểm Quá trình";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(284, 41);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 0;
            label2.Text = "Môn";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button4);
            groupBox4.Controls.Add(button3);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox4.Location = new Point(832, 312);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(254, 82);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Khác";
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button4.Location = new Point(135, 35);
            button4.Name = "button4";
            button4.Size = new Size(86, 25);
            button4.TabIndex = 8;
            button4.Text = "TẢI LẠI";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button3.Location = new Point(46, 35);
            button3.Name = "button3";
            button3.Size = new Size(83, 25);
            button3.TabIndex = 7;
            button3.Text = "THỐNG KÊ";
            button3.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(441, 74);
            label20.Name = "label20";
            label20.Size = new Size(14, 15);
            label20.TabIndex = 29;
            label20.Text = "1";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(428, 41);
            label21.Name = "label21";
            label21.Size = new Size(42, 15);
            label21.TabIndex = 28;
            label21.Text = "Học kì";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(342, 75);
            label17.Name = "label17";
            label17.Size = new Size(68, 15);
            label17.TabIndex = 27;
            label17.Text = "2021-2022";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(354, 41);
            label19.Name = "label19";
            label19.Size = new Size(33, 15);
            label19.TabIndex = 26;
            label19.Text = "Năm";
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
            // frmDiem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 524);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmDiem";
            Text = "frmDiem";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private GroupBox groupBox3;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboBox1;
        private Label label7;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label10;
        private Label label13;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Button button2;
        private Label label12;
        private Label label11;
        private ListView listView1;
        private ComboBox comboBox2;
        private Label label14;
        private GroupBox groupBox4;
        private Button button3;
        private Button button4;
        private Label label15;
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
        private Label label20;
        private Label label21;
        private Label label17;
        private Label label19;
    }
}