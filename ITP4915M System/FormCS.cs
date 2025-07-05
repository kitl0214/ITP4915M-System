// -----------------------------------------------------------------------------
// FormCS.cs – Customer-Service Dashboard
//   • 只顯示「未開發票」訂單
//   • Follow-up Grid 取消 “Complete / Done” 欄
//   • 行標頭寬度縮至 20 px
// -----------------------------------------------------------------------------
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class FormCS : FormTemplate
    {
        private DataTable? _followups;
        protected override bool EnableUserInfo => true;

        /*── 建構子 ─────────────────────────────*/
        public FormCS(string user, string dept) : base(user, dept) => InitializeComponent();
        protected FormCS() : base() => InitializeComponent();   // 供 VS Designer

        /*── Form Load ─────────────────────────*/
        private void FormCS_Load(object sender, EventArgs e)
        {
            LoadOrders();
            LoadFollowups();
        }

        /*──────────────── Orders Grid ─────────*/
        private void btnLoadOrders_Click(object? s, EventArgs e) => LoadOrders();

        private void LoadOrders()
        {
            dgvOrders.DataSource = Database.GetOrdersWithoutInvoice();
            dgvOrders.RowHeadersVisible = false;

            void H(string col, string cap)
            { if (dgvOrders.Columns.Contains(col)) dgvOrders.Columns[col].HeaderText = cap; }

            H("oid", "Order ID");
            H("customer_name", "Customer");
            H("product", "Product");
            H("unit", "Unit");
            H("qty", "Qty");
            H("order_type", "Order Type");
            H("extra_pkg", "Extra Package");
            H("due_date", "Due Date");
            H("total", "Total");
            H("created_at", "Created At");

            dgvOrders.ClearSelection();
        }

        /*──────── 新增 / 編輯 Follow-up ────────*/
        private void btnAddFollowup_Click(object? s, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            { MessageBox.Show("Please select one order first."); return; }

            string oid = dgvOrders.SelectedRows[0].Cells["oid"].Value!.ToString()!;
            using var dlg = new FollowupDialog(oid);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Database.AddFollowup(oid, dlg.SelectedAction, dlg.CustomerComment);
                LoadFollowups();
            }
        }

        private void btnEditFollowup_Click(object? s, EventArgs e)
        {
            if (dgvFollowups.SelectedRows.Count == 0)
            { MessageBox.Show("Please select one follow-up first."); return; }

            var row = dgvFollowups.SelectedRows[0];
            if (!int.TryParse(row.Cells["fid"].Value?.ToString(), out int fid))
            { MessageBox.Show("Invalid follow-up record."); return; }

            string oid = row.Cells["oid"].Value?.ToString() ?? "";
            string act = row.Cells["action"].Value?.ToString() ?? "";
            string comm = row.Cells["comment"].Value?.ToString() ?? "";

            using var dlg = new FollowupDialog(oid, act, comm);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Database.UpdateFollowup(fid, dlg.SelectedAction, dlg.CustomerComment);
                LoadFollowups();
            }
        }

        /*──────────────── Follow-ups Grid ─────*/
        private void LoadFollowups()
        {
            _followups = Database.GetAllFollowups();
            AddFlagColumn(_followups, "RefundFlag");
            AddFlagColumn(_followups, "DiscountFlag");

            dgvFollowups.DataSource = _followups;

            /* Status 欄改為 ComboBox */
            const string stsCol = "status";
            if (dgvFollowups.Columns[stsCol] is not DataGridViewComboBoxColumn)
            {
                int idx = dgvFollowups.Columns[stsCol].Index;
                string dp = dgvFollowups.Columns[stsCol].DataPropertyName;
                dgvFollowups.Columns.Remove(stsCol);

                var cbo = new DataGridViewComboBoxColumn
                {
                    Name = stsCol,
                    HeaderText = "Status",
                    DataPropertyName = dp,
                    DataSource = new[] { "PENDING", "COMPLETED" },
                    Width = 110,
                    FlatStyle = FlatStyle.Flat
                };
                dgvFollowups.Columns.Insert(idx, cbo);
            }

            /* 欄位標題 */
            void FH(string col, string cap)
            { if (dgvFollowups.Columns.Contains(col)) dgvFollowups.Columns[col].HeaderText = cap; }

            FH("fid", "ID");
            FH("oid", "Order ID");
            FH("product", "Product");
            FH("created_at", "Created At");
            FH("due_date", "Due Date");
            FH("qty", "Qty");
            FH("action", "Action");
            FH("comment", "Comment");
            FH("status", "Status");
            FH("followup_time", "Follow-Up Time");
            FH("RefundFlag", "Refund");
            FH("DiscountFlag", "Discount");

            /* 行標頭收窄 */
            dgvFollowups.RowHeadersVisible = true;
            dgvFollowups.RowHeadersWidth = 20;
            dgvFollowups.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            dgvFollowups.ClearSelection();
        }

        /*──────── Flag Helper ─────────────────*/
        private static void AddFlagColumn(DataTable dt, string flagCol)
        {
            if (dt.Columns.Contains(flagCol)) return;

            dt.Columns.Add(flagCol, typeof(string));

            foreach (DataRow r in dt.Rows)
            {
                string act = r["action"]?.ToString()?.Trim().ToUpper() ?? "NONE";
                bool has = flagCol switch
                {
                    "RefundFlag" => act is "REFUND" or "BOTH",
                    "DiscountFlag" => act is "DISCOUNT" or "BOTH",
                    _ => false
                };
                r[flagCol] = has ? "Y" : "";
            }
        }

        /*──────── Status 變更 ────────────────*/
        private void dgvFollowups_CellValueChanged(object? s, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvFollowups.Columns[e.ColumnIndex].Name != "status") return;

            int fid = Convert.ToInt32(dgvFollowups.Rows[e.RowIndex].Cells["fid"].Value);
            string st = dgvFollowups.Rows[e.RowIndex].Cells["status"].Value?.ToString() ?? "PENDING";
            Database.SetFollowupStatus(fid, st);
        }

        private void dgvFollowups_CurrentCellDirtyStateChanged(object? s, EventArgs e)
        {
            if (dgvFollowups.IsCurrentCellDirty)
                dgvFollowups.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /*──────── 行著色 ─────────────────────*/
        private void dgvFollowups_RowPrePaint(object? s, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvFollowups.Rows[e.RowIndex];
            string st = row.Cells["status"].Value?.ToString() ?? "";
            Color c = st switch
            {
                "PENDING" => Color.Gold,
                "COMPLETED" => Color.LightGreen,
                _ => dgvFollowups.DefaultCellStyle.BackColor
            };
            row.DefaultCellStyle.BackColor = c;
            row.DefaultCellStyle.SelectionBackColor = c;
            row.DefaultCellStyle.ForeColor = Color.Black;
            row.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        /*──────── 雙擊檢視 ────────────────────*/
        private void dgvFollowups_CellDoubleClick(object? s, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var r = dgvFollowups.Rows[e.RowIndex];
            string act = r.Cells["action"].Value?.ToString()?.Trim().ToUpper() ?? "NONE";

            bool refund = act is "REFUND" or "BOTH";
            bool discount = act is "DISCOUNT" or "BOTH";

            string comment = r.Cells["comment"].Value?.ToString() ?? "";
            string oid = r.Cells["oid"].Value?.ToString() ?? "";

            using var dlg = new FollowupViewDialog(oid, refund, discount, comment);
            dlg.ShowDialog(this);
        }
    }
}
