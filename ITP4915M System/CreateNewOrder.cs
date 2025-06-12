using System;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class CreateNewOrder : Form
    {
        public CreateNewOrder()
        {
            InitializeComponent();
        }

        /*-------------- Create button --------------*/
        private void creatbt_Click(object sender, EventArgs e)
        {
            // 1) Validate input
            if (string.IsNullOrWhiteSpace(txtCust.Text) ||
                string.IsNullOrWhiteSpace(txtProd.Text))
            {
                MessageBox.Show("Customer & Product name are required.");
                return;
            }

            bool isCustom = ctrd.Checked;          // radio
            int qty = (int)quannud.Value;
            int unit = (int)uninud.Value;
            bool extraPack = apcb.Checked;
            int addCost = extraPack ? 1 : 0;
            int total = qty * unit + addCost;

            int newId = Database.GetNextOrderId();   // e.g., 123

            // 2) Summary dialog
            using var sum = new OrderSummaryDialog(
                orderId: newId,
                customer: txtCust.Text.Trim(),
                product: txtProd.Text.Trim(),
                qty: qty,
                unit: unit,
                isCustom: isCustom,
                extraPkg: extraPack,
                dueDate: edcdtp.Value.Date,
                total: total);

            if (sum.ShowDialog(this) != DialogResult.OK) return;

            // 3) Insert into DB
            var model = new OrderModel
            {
                Oid = newId,
                Customer = txtCust.Text.Trim(),
                Product = txtProd.Text.Trim(),
                Unit = unit,
                Qty = qty,
                IsCustom = isCustom,
                ExtraPack = extraPack,
                DueDate = edcdtp.Value.Date,
                Total = total
            };

            try
            {
                Database.InsertOrder(model);
                MessageBox.Show($"Order #{model.Oid:000000} created!", "Success");
                DialogResult = DialogResult.OK;   // signal parent to refresh
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Error:\n" + ex.Message, "Error");
            }
        }

        /*-------------- Clear button --------------*/
        private void cleanbt_Click(object sender, EventArgs e)
        {
            txtCust.Clear();
            txtProd.Clear();
            quannud.Value = 1;
            uninud.Value = 1;
            gord.Checked = true;
            apcb.Checked = false;
            edcdtp.Value = DateTime.Today;
        }

        private void CreateNewOrder_Load(object sender, EventArgs e) { }

        private void txtProd_TextChanged(object sender, EventArgs e) { }
    }
}
