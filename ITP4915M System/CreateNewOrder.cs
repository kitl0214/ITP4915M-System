using System;
using System.Windows.Forms;
using ITP4915MSystem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ITP4915M_System
{
    public partial class CreateNewOrder : Form
    {
        public CreateNewOrder()
        {
            InitializeComponent();
        }

        /*-------------- 建立按鈕 --------------*/
        private void creatbt_Click(object sender, EventArgs e)
        {
            // 1) 驗證輸入
            if (string.IsNullOrWhiteSpace(txtCust.Text) ||
                string.IsNullOrWhiteSpace(txtProd.Text))
            {
                MessageBox.Show("Customer & Product name are required."); return;
            }

            // Radio 必選（已預設 General 打勾），理論上不會同時為 false
            bool isCustom = ctrd.Checked;

            int qty = (int)quannud.Value;
            int unit = (int)uninud.Value;
            bool extraPack = apcb.Checked;
            int addCost = extraPack ? 1 : 0;
            int total = qty * unit + addCost;

            int newId = Database.GetNextOrderId();          // 000123

            // 2) 顯示確認對話框
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

            // 3) 寫進資料庫
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
                DialogResult = DialogResult.OK;   // 關閉並通知父窗刷新
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Error:\n" + ex.Message, "Error");
            }
        }

        /*-------------- 清除按鈕 --------------*/
        private void cleanbt_Click(object sender, EventArgs e)
        {
            txtCust.Clear(); txtProd.Clear();
            quannud.Value = 1; uninud.Value = 1;
            gord.Checked = true; ctrd.Checked = false;
            apcb.Checked = false;
            edcdtp.Value = DateTime.Today;
        }

        private void CreateNewOrder_Load(object sender, EventArgs e) { }

        private void txtProd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
