// OrderSummaryDialog.cs
using System;
using System.Windows.Forms;

namespace ITP4915M_System
{
    public partial class OrderSummaryDialog : Form
    {
        /// <summary>編輯 / 建立時傳入訂單資料用於顯示</summary>
        public OrderSummaryDialog(
            int orderId, string customer, string product,
            int qty, int unit, bool isCustom, bool extraPkg,
            DateTime dueDate, int total)
        {
            InitializeComponent();         // ← 只呼叫 Designer 產生的 UI

            // 將資料填進 Label
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

        // 若有需要可在此做額外初始化
        private void OrderSummaryDialog_Load(object sender, EventArgs e) { }
    }
}
