using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITP4915MSystem;
using ITP4915M_System;


namespace ITP4915M_System
{
    public partial class InvoiceDetailDialog : Form
    {
        public InvoiceDetailDialog(string invoiceID)
        {
            InitializeComponent();

            InvoiceDetailModel model = Database.GetInvoiceDetail(invoiceID);
            if (model != null)
            {
                lblInvoiceIDValue.Text = model.InvoiceID;
                lblOrderIDValue.Text = model.OrderID;
                lblUserNameValue.Text = model.UserName;
                lblOrderTypeValue.Text = model.OrderType;
                lblAmountValue.Text = model.Amount.ToString("0.00");
                lblIssueDateValue.Text = model.IssueDate.ToString("d/M/yyyy");
                lblStatusValue.Text = model.Status;
            }
        }

    }
}
