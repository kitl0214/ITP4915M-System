// -----------------------------------------------------------------------------
// CreateNewOrder.cs  –  Create / Edit Order (uses Customer Name)
// -----------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class CreateNewOrder : Form
    {
        private readonly OrderModel? _original;   // null = new order

        /*─── create new order ───*/
        public CreateNewOrder()
        {
            InitializeComponent();
            _original = null;
        }

        /*─── edit existing order ───*/
        public CreateNewOrder(OrderModel existing) : this()
        {
            _original = existing;
            Text = $"Edit Order #{existing.Oid:000000}";
            creatbt.Text = "Save";

            txtCName.Text = existing.Customer;      // customer name
            txtProd.Text = existing.Product;
            uninud.Value = existing.Unit;
            quannud.Value = existing.Qty;
            gord.Checked = !existing.IsCustom;
            ctrd.Checked = existing.IsCustom;
            apcb.Checked = existing.ExtraPack;
            edcdtp.Value = existing.DueDate;
        }

        /*─── Create / Save ───*/
        private void creatbt_Click(object? sender, EventArgs e)
        {
            /* 1) validation – customer name required */
            string custName = txtCName.Text.Trim();
            if (string.IsNullOrWhiteSpace(custName))
            {
                MessageBox.Show("Please enter the customer name.", "Missing Field",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProd.Text))
            {
                MessageBox.Show("Please enter the product name.", "Missing Field",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProd.Focus();
                return;
            }

            /* 2) calculate amount */
            bool isCustom = ctrd.Checked;
            int qty = (int)quannud.Value;
            int unit = (int)uninud.Value;
            bool extraPkg = apcb.Checked;
            int total = qty * unit + (extraPkg ? qty : 0);

            int oid = _original?.Oid ?? Database.GetNextOrderId();

            /* 3) preview dialog */
            using var sum = new OrderSummaryDialog(
                orderId: oid,
                customer: custName,
                product: txtProd.Text.Trim(),
                qty: qty,
                unit: unit,
                isCustom: isCustom,
                extraPkg: extraPkg,
                dueDate: edcdtp.Value.Date,
                total: total);

            if (sum.ShowDialog(this) != DialogResult.OK) return;

            /* 4) build model & write DB */
            var model = new OrderModel
            {
                Oid = oid,
                Customer = custName,
                Product = txtProd.Text.Trim(),
                Unit = unit,
                Qty = qty,
                IsCustom = isCustom,
                ExtraPack = extraPkg,
                DueDate = edcdtp.Value.Date,
                Total = total
            };

            try
            {
                if (_original == null)
                    Database.InsertOrder(model);
                else
                    Database.UpdateOrder(model);

                DialogResult = DialogResult.OK;   // notify parent to refresh
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Error:\n" + ex.Message, "Error");
            }
        }

        /*─── Clear ───*/
        private void cleanbt_Click(object? sender, EventArgs e)
        {
            txtCName.Clear();
            txtProd.Clear();
            quannud.Value = 1;
            uninud.Value = 1;
            gord.Checked = true;
            ctrd.Checked = false;
            apcb.Checked = false;
            edcdtp.Value = DateTime.Today;
        }

        /*─── other events (optional) ───*/
        private void CreateNewOrder_Load(object? s, EventArgs e) { }
        private void txtProd_TextChanged(object? s, EventArgs e) { }
    }
}
