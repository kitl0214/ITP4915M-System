// =========================== FormSales.cs ===========================
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class FormSales : Form
    {
        public FormSales() => InitializeComponent();

        private void FormSales_Load(object sender, EventArgs e)
        {
            dgvOrders.CurrentCellDirtyStateChanged += (_, __) =>
            {
                if (dgvOrders.IsCurrentCellDirty)
                    dgvOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            LoadOrders();
        }

        /* ───── Data Loading ───── */
        private void LoadOrders()
        {
            dgvOrders.DataSource = null;
            dgvOrders.Columns.Clear();

            DataTable dt = Database.GetAllOrders();          // 仍然含 cid / customer
            dt.DefaultView.Sort = "created_at ASC";

            /* ❶ 如果有 cid / customer，就把它直接移除 --------- */
            if (dt.Columns.Contains("customer"))
                dt.Columns.Remove("customer");   // ← 徹底刪欄
            else if (dt.Columns.Contains("cid"))
                dt.Columns.Remove("cid");

            /* ❷ extra_pkg 文字化（保持原樣） ------------------- */
            if (!dt.Columns.Contains("extra_txt"))
                dt.Columns.Add("extra_txt", typeof(string));

            foreach (DataRow r in dt.Rows)
                r["extra_txt"] = Convert.ToInt32(r["extra_pkg"]) == 1 ? "Y" : "";

            dt.Columns.Remove("extra_pkg");
            dt.Columns["extra_txt"].ColumnName = "extra_pkg";

            dgvOrders.DataSource = dt;

            /* ❸ 勾選欄 Sel（保持原樣） ------------------------- */
            if (dgvOrders.Columns["Sel"] == null)
                dgvOrders.Columns.Insert(0,
                    new DataGridViewCheckBoxColumn { Name = "Sel", Width = 30 });

            /* ❹ 友善標題（把 customer 那行刪掉即可） ---------- */
            void H(string c, string t)
            { if (dgvOrders.Columns.Contains(c)) dgvOrders.Columns[c].HeaderText = t; }

            H("oid", "Order ID");          // ← 沒有 Customer ID 再也不設
            H("product", "Product");
            H("qty", "Qty"); H("unit", "Unit");
            H("order_type", "Type"); H("extra_pkg", "Extra Pkg");
            H("due_date", "Due"); H("total", "Total"); H("created_at", "Created");

            /* ❺ 欄位順序：少了 customer，依序往前推 ----------- */
            void Pos(string c, int p)
            { if (dgvOrders.Columns.Contains(c)) dgvOrders.Columns[c].DisplayIndex = p; }

            Pos("Sel", 0); Pos("oid", 1);
            Pos("product", 2); Pos("qty", 3);
            Pos("unit", 4); Pos("order_type", 5);
            Pos("extra_pkg", 6); Pos("due_date", 7);
            Pos("total", 8); Pos("created_at", 9);
        }

        /* ───── Buttons ───── */
        private void btnRefresh_Click(object? s, EventArgs e) => LoadOrders();

        private void btnCreate_Click(object? s, EventArgs e)
        {
            using var dlg = new CreateNewOrder();
            if (dlg.ShowDialog(this) == DialogResult.OK) LoadOrders();
        }

        private void btnEdit_Click(object? s, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            { MessageBox.Show("Highlight a row to edit."); return; }

            int oid = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["oid"].Value);
            using var dlg = new CreateNewOrder(Database.GetOrder(oid));
            if (dlg.ShowDialog(this) == DialogResult.OK) LoadOrders();
        }

        private void btnDelete_Click(object? s, EventArgs e)
        {
            var ids = new List<int>();
            foreach (DataGridViewRow r in dgvOrders.Rows)
                if (r.Cells["Sel"] is DataGridViewCheckBoxCell ck &&
                    ck.Value is bool b && b && r.Cells["oid"].Value != null)
                    ids.Add(Convert.ToInt32(r.Cells["oid"].Value));

            if (ids.Count == 0)
            { MessageBox.Show("Tick checkbox to delete."); return; }

            if (MessageBox.Show($"Delete {ids.Count} order(s)?", "Confirm",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            int ok = 0, fail = 0;
            foreach (int id in ids)
                try { Database.DeleteOrder(id); ok++; } catch { fail++; }

            MessageBox.Show($"Deleted: {ok}\nFailed: {fail}");
            LoadOrders();
        }
    }
}
