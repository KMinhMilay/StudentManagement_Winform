using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHocSinh.DTO
{
    internal class TransactionHistory
    {
        public string TransText { get; set; }
        public override string ToString()
        {
            return $"{TransText}";
        }
    }
}
