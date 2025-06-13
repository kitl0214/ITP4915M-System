// -----------------------------------------------------------------------------
// CreateNewOrder.cs  –  建立 / 編輯訂單（使用 Customer ID）
// -----------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class CreateNewOrder : Form
    {
        private readonly OrderModel? _original;   // null = 新增

        /*─── 建立新訂單 ───*/
        public CreateNewOrder()
        {
            InitializeComponent();
            _original = null;
        }

        /*─── 編輯舊訂單 ───*/
        public CreateNewOrder(OrderModel existing) : this()
        {
            _original = existing;
            Text = $"Edit Order #{existing.Oid:000000}";
            creatbt.Text = "Save";

            txtCid.Text = existing.Customer;      // 存放 ID 字串
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
            /* 1) 必填驗證 ─ Customer ID 必須是正整數 */
            if (!int.TryParse(txtCid.Text.Trim(), out int cid) || cid <= 0)
            {
                MessageBox.Show("Please enter a valid numeric Customer ID.", "Missing / Invalid",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCid.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProd.Text))
            {
                MessageBox.Show("Please enter the product name.", "Missing Field",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProd.Focus();
                return;
            }

            /* 2) 計算金額 */
            bool isCustom = ctrd.Checked;
            int qty = (int)quannud.Value;
            int unit = (int)uninud.Value;
            bool extraPkg = apcb.Checked;
            int total = qty * unit + (extraPkg ? qty : 0);

            int oid = _original?.Oid ?? Database.GetNextOrderId();

            /* 3) 預覽對話框 */
            using var sum = new OrderSummaryDialog(
                orderId: oid,
                customer: $"#{cid}",
                product: txtProd.Text.Trim(),
                qty: qty,
                unit: unit,
                isCustom: isCustom,
                extraPkg: extraPkg,
                dueDate: edcdtp.Value.Date,
                total: total);

            if (sum.ShowDialog(this) != DialogResult.OK) return;

            /* 4) 組成模型、寫入 DB */
            var model = new OrderModel
            {
                Oid = oid,
                Customer = cid.ToString(),     // 以字串形式存放 ID
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
                if (_original == null) Database.InsertOrder(model);
                else Database.UpdateOrder(model);

                DialogResult = DialogResult.OK;   // 通知父窗刷新
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Error:\n" + ex.Message, "Error");
            }
        }

        /*─── Clear ───*/
        private void cleanbt_Click(object? sender, EventArgs e)
        {
            txtCid.Clear(); txtProd.Clear();
            quannud.Value = 1; uninud.Value = 1;
            gord.Checked = true; ctrd.Checked = false;
            apcb.Checked = false;
            edcdtp.Value = DateTime.Today;
        }

        /*─── 其餘事件 (若需) ───*/
        private void CreateNewOrder_Load(object? s, EventArgs e) { }
        private void txtProd_TextChanged(object? s, EventArgs e) { }
    }
}
