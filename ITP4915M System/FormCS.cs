// -----------------------------------------------------------------------------
// FormCS.cs – Customer-Service dashboard
//   • adds RefundFlag / DiscountFlag by reading action ENUM
//   • double-click row → read-only FollowupViewDialog
// -----------------------------------------------------------------------------
using ITP4915MSystem;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    public partial class FormCS : Form
    {
        private DataTable _followups;

        public FormCS() => InitializeComponent();

        /* ---------- life-cycle ---------- */
        private void FormCS_Load(object sender, EventArgs e)
        {
            LoadOrders();
            LoadFollowups();
        }

        /* ---------- Orders ---------- */
        private void btnLoadOrders_Click(object sender, EventArgs e) => LoadOrders();

        private void LoadOrders()
        {
            dgvOrders.DataSource = Database.GetAllOrders();
            dgvOrders.RowHeadersVisible = false;

            void H(string col, string txt)
            { if (dgvOrders.Columns.Contains(col)) dgvOrders.Columns[col].HeaderText = txt; }

            H("oid", "Order ID");
            H("customer_name", "Customer");
            H("product", "Product");
            H("unit", "Unit");
            H("qty", "Quantity");
            H("order_type", "Order Type");
            H("extra_pkg", "Extra Package");
            H("due_date", "Due Date");
            H("total", "Total");
            H("created_at", "Created At");
        }

        /* ---------- Add / Edit follow-up ---------- */
        private void btnAddFollowup_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            { MessageBox.Show("Please select one order first."); return; }

            string oid = dgvOrders.SelectedRows[0].Cells["oid"].Value.ToString();
            using var dlg = new FollowupDialog(oid);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Database.AddFollowup(oid, dlg.SelectedAction, dlg.CustomerComment);
                LoadFollowups();
            }
        }

        private void btnEditFollowup_Click(object sender, EventArgs e)
        {
            if (dgvFollowups.SelectedRows.Count == 0 || dgvFollowups.SelectedRows[0].IsNewRow)
            { MessageBox.Show("Please select one follow-up first."); return; }

            var row = dgvFollowups.SelectedRows[0];
            if (!int.TryParse(row.Cells["fid"].Value?.ToString(), out int fid))
            { MessageBox.Show("Invalid follow-up record."); return; }

            string oid = row.Cells["oid"]?.Value?.ToString() ?? "";
            string act = row.Cells["action"]?.Value?.ToString() ?? "";
            string comm = row.Cells["comment"]?.Value?.ToString() ?? "";

            using var dlg = new FollowupDialog(oid, act, comm);
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            Database.UpdateFollowup(fid, dlg.SelectedAction, dlg.CustomerComment);
            LoadFollowups();
        }

        /* ---------- build follow-up grid ---------- */
        private void LoadFollowups()
        {
            _followups = Database.GetAllFollowups();

            // add Y/blank flags based on action enum
            AddFlagColumn(_followups, "RefundFlag");
            AddFlagColumn(_followups, "DiscountFlag");

            dgvFollowups.DataSource = _followups;

            /* Done button --------------------------------------------------- */
            const string doneCol = "ActionBtn";
            if (!dgvFollowups.Columns.Contains(doneCol))
            {
                dgvFollowups.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = doneCol,
                    HeaderText = "Complete",
                    Text = "Done",
                    UseColumnTextForButtonValue = true,
                    Width = 70
                });
            }

            /* status → ComboBox --------------------------------------------- */
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

            /* friendly headers --------------------------------------------- */
            void FH(string col, string txt)
            { if (dgvFollowups.Columns.Contains(col)) dgvFollowups.Columns[col].HeaderText = txt; }

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

            dgvFollowups.ClearSelection();
        }

        /* ---------- flag helper ---------- */
        private static void AddFlagColumn(DataTable dt, string flagCol)
        {
            if (dt.Columns.Contains(flagCol))
                return;

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

        /* ---------- Done button click ---------- */
        private void dgvFollowups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvFollowups.Columns[e.ColumnIndex].Name != "ActionBtn") return;

            int fid = Convert.ToInt32(dgvFollowups.Rows[e.RowIndex].Cells["fid"].Value);
            Database.SetFollowupCompleted(fid);
            LoadFollowups();
        }

        /* ---------- status change ---------- */
        private void dgvFollowups_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvFollowups.Columns[e.ColumnIndex].Name != "status") return;

            int fid = Convert.ToInt32(dgvFollowups.Rows[e.RowIndex].Cells["fid"].Value);
            string newSt = dgvFollowups.Rows[e.RowIndex].Cells["status"].Value?.ToString() ?? "PENDING";
            Database.SetFollowupStatus(fid, newSt);
            dgvFollowups.InvalidateRow(e.RowIndex);
        }

        private void dgvFollowups_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFollowups.IsCurrentCellDirty)
                dgvFollowups.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /* ---------- row color ---------- */
        private void dgvFollowups_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
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

        /* ---------- double-click → read-only dialog ---------- */
        private void dgvFollowups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvFollowups.Rows[e.RowIndex];
            string act = r.Cells["action"].Value?.ToString()?.Trim().ToUpper() ?? "NONE";

            bool refund = act is "REFUND" or "BOTH";
            bool discount = act is "DISCOUNT" or "BOTH";

            string comment = r.Cells["comment"]?.Value?.ToString() ?? "";
            string oid = r.Cells["oid"]?.Value?.ToString() ?? "";

            using var dlg = new FollowupViewDialog(oid, refund, discount, comment);
            dlg.ShowDialog(this);
        }
    }
}
