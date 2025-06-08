// OrderSummaryDialog.cs
using System;
using System.Windows.Forms;

namespace ITP4915M_System
{
    public partial class OrderSummaryDialog : Form
    {
        /// <summary>
        /// 建構子：把訂單資料傳進來顯示
        /// </summary>
        public OrderSummaryDialog(
            int orderId,
            string customer,
            string product,
            int qty,
            int unit,
            bool isCustom,
            bool extraPkg,
            DateTime dueDate,
            int total)
        {
            InitializeComponent();

            lblInfo.Text =
$"""
Order ID : {orderId:000000}

Customer : {customer}
Product  : {product}
Quantity : {qty}
Unit     : ${unit}
Type     : {(isCustom ? "Custom" : "General")}
ExtraPkg : {(extraPkg ? "Yes (+$1)" : "No")}
Due Date : {dueDate:yyyy-MM-dd}

TOTAL    : ${total}
""";
        }
    }
}
