// -----------------------------------------------------------------------------
// FormSales.cs – Sales Dashboard
//   • 右上角顯示使用者名稱／部門（繼承自 FormTemplate）
//   • 功能：載入、建立、編輯、刪除訂單
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    /// <summary>Sales 主畫面</summary>
    public partial class FormSales : FormTemplate
    {
        /* 讓本頁也顯示 User / Dept；若不要顯示改 false */
        protected override bool EnableUserInfo => true;

        /*─────────────────── 建構子 ───────────────────*/
        public FormSales(string user, string dept) : base(user, dept)
        {
            InitializeComponent();
        }

        /// <remarks>僅供 VS Designer 用；執行期請改用兩參數版本</remarks>
        protected FormSales() : base()
        {
            InitializeComponent();
        }

        /*─────────────────── Form Load ───────────────────*/
        private void FormSales_Load(object sender, EventArgs e)
        {
            dgvOrders.CurrentCellDirtyStateChanged += (_, __) =>
            {
                if (dgvOrders.IsCurrentCellDirty)
                    dgvOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            LoadOrders();
        }

        /*─────────────────── Data Loading ───────────────────*/
        private void LoadOrders()
        {
            dgvOrders.DataSource = null;
            dgvOrders.Columns.Clear();

            DataTable dt = Database.GetAllOrders(); // still returns cid / customer_name
            dt.DefaultView.Sort = "created_at ASC";

            /* 1 ─ remove cid only */
            if (dt.Columns.Contains("cid"))
                dt.Columns.Remove("cid");

            /* 2 ─ unify customer_name format (trim & Title-Case) */
            if (dt.Columns.Contains("customer_name"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    var raw = (r["customer_name"]?.ToString() ?? "").Trim();
                    r["customer_name"] = CultureInfo.CurrentCulture.TextInfo
                                         .ToTitleCase(raw.ToLower());
                }
            }

            /* 3 ─ convert extra_pkg 0/1 -> "Y"/"" */
            if (!dt.Columns.Contains("extra_txt"))
                dt.Columns.Add("extra_txt", typeof(string));

            foreach (DataRow r in dt.Rows)
                r["extra_txt"] = Convert.ToInt32(r["extra_pkg"]) == 1 ? "Y" : "";

            dt.Columns.Remove("extra_pkg");
            dt.Columns["extra_txt"].ColumnName = "extra_pkg";

            dgvOrders.DataSource = dt;

            /* 4 ─ add Sel checkbox column if missing */
            if (dgvOrders.Columns["Sel"] == null)
                dgvOrders.Columns.Insert(0,
                    new DataGridViewCheckBoxColumn
                    {
                        Name = "Sel",
                        Width = 30
                    });

            /* 5 ─ user-friendly headers */
            void H(string c, string t)
            { if (dgvOrders.Columns.Contains(c)) dgvOrders.Columns[c].HeaderText = t; }

            H("oid", "Order ID");
            H("customer_name", "Customer");
            H("product", "Product");
            H("qty", "Qty");
            H("unit", "Unit");
            H("order_type", "Type");
            H("extra_pkg", "Extra Pkg");
            H("due_date", "Due");
            H("total", "Total");
            H("created_at", "Created");

            /* 6 ─ column order */
            void Pos(string c, int p)
            { if (dgvOrders.Columns.Contains(c)) dgvOrders.Columns[c].DisplayIndex = p; }

            Pos("Sel", 0);
            Pos("oid", 1);
            Pos("customer_name", 2);
            Pos("product", 3);
            Pos("qty", 4);
            Pos("unit", 5);
            Pos("order_type", 6);
            Pos("extra_pkg", 7);
            Pos("due_date", 8);
            Pos("total", 9);
            Pos("created_at", 10);

            /* 7 ─ hide row header */
            dgvOrders.RowHeadersVisible = false;
        }

        /*─────────────────── Buttons ───────────────────*/
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
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            int ok = 0, fail = 0;
            foreach (int id in ids)
                try { Database.DeleteOrder(id); ok++; } catch { fail++; }

            MessageBox.Show($"Deleted: {ok}\nFailed: {fail}");
            LoadOrders();
        }
    }
}
