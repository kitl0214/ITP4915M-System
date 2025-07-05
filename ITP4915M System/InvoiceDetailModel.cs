using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITP4915M_System
{
    public class InvoiceDetailModel
    {
        public string InvoiceID { get; set; }
        public string OrderID { get; set; }
        public string UserName { get; set; }
        public string OrderType { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public string Status { get; set; }
    }
}

