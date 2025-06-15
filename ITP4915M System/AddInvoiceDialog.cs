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

namespace ITP4915M_System
{
    public partial class AddInvoiceDialog : Form
    {
        public string SelectedOrderID { get; private set; }
        public decimal SelectedAmount { get; private set; }

        public AddInvoiceDialog()
        {
            InitializeComponent();
            LoadOrderList();
            comboBoxOrders.SelectedIndexChanged += ComboBoxOrders_SelectedIndexChanged;
        }

        private void LoadOrderList()
        {
            var dtOrders = Database.GetInvoiceSelectableOrders();
            comboBoxOrders.DataSource = dtOrders;
            comboBoxOrders.DisplayMember = "oid";
            comboBoxOrders.ValueMember = "oid";

            if (dtOrders.Rows.Count > 0)
            {
                comboBoxOrders.SelectedIndex = 0;
                UpdateOrderDetails(dtOrders.Rows[0]);
            }
        }

        private void ComboBoxOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrders.SelectedItem is DataRowView drv)
            {
                UpdateOrderDetails(drv.Row);
            }
        }

        private void UpdateOrderDetails(DataRow row)
        {
            SelectedOrderID = row["oid"].ToString();
            txtProduct.Text = row["product"].ToString();
            SelectedAmount = Convert.ToDecimal(row["total"]);
            txtAmount.Text = SelectedAmount.ToString("0.00");
            txtOrderType.Text = row["order_type"].ToString(); // 新增這行
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxOrders.SelectedItem == null)
            {
                MessageBox.Show("Please select an order.");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}