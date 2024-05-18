using QuanLiHocSinh.DAO;
using QuanLiHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OfficeOpenXml.ExcelErrorValue;

namespace QuanLiHocSinh
{
    public partial class frmTransHistory : Form
    {
        List<TransactionHistory> transactionHistories = new List<TransactionHistory>();
        public frmTransHistory()
        {
            InitializeComponent();
            loadTHList();
            listBox1.SelectedIndex = -1;

        }
        public void loadTHList()
        {
            textBox1.Clear();
            DataTable data = TransHistoryDAO.Instance.getTHList();
            listBox1.Items.Clear();
            foreach (DataRow row in data.Rows)
            {
                TransactionHistory th = new TransactionHistory
                {
                    TransText = row["transactionText"].ToString()
                };
                transactionHistories.Add(th);
                listBox1.Items.Add(th);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            loadTHList();
        }

        private void frmTransHistory_Load(object sender, EventArgs e)
        {
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            loadTHList();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataTable data = TransHistoryDAO.Instance.getValueTHList(textBox1.Text);
            listBox1.Items.Clear();
            foreach (DataRow row in data.Rows)
            {
                TransactionHistory th = new TransactionHistory
                {
                    TransText = row["transactionText"].ToString()
                };
                transactionHistories.Add(th);
                listBox1.Items.Add(th);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


 
        }
    }
}
