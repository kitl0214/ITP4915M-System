// -----------------------------------------------------------------------------
// FormCS.cs – Customer-Service dashboard (friendly headers + yellow-row style)
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
            dgvOrders.RowHeadersVisible = false;                 // hide left gutter

            void Header(string col, string txt)
            { if (dgvOrders.Columns.Contains(col)) dgvOrders.Columns[col].HeaderText = txt; }

            Header("oid", "Order ID");
            Header("customer_name", "Customer");
            Header("product", "Product");
            Header("unit", "Unit");
            Header("qty", "Quantity");
            Header("order_type", "Order Type");
            Header("extra_pkg", "Extra Package");
            Header("due_date", "Due Date");
            Header("total", "Total");
            Header("created_at", "Created At");
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

        /* ---------- core: build follow-up grid ---------- */
        private void LoadFollowups()
        {
            dgvFollowups.DataSource = Database.GetAllFollowups();

            /* Done button column ------------------------------------------------ */
            const string doneCol = "Action";
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

            /* status → ComboBox column ----------------------------------------- */
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

            /* friendly headers for follow-ups grid ----------------------------- */
            void FH(string col, string txt)
            { if (dgvFollowups.Columns.Contains(col)) dgvFollowups.Columns[col].HeaderText = txt; }

            FH("fid", "ID");
            FH("oid", "Order ID");
            FH("product", "Product");
            FH("created_at", "Created At");
            FH("due_date", "Due Date");
            FH("qty", "Quantity");
            FH("action", "Action");
            FH("comment", "Comment");
            FH("status", "Status");
            FH("followup_time", "Follow-Up Time");

            dgvFollowups.ClearSelection();     // avoid blue overlay on single row
        }

        /* ---------- Done button ---------- */
        private void dgvFollowups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvFollowups.Columns[e.ColumnIndex].Name != "Action") return;

            int fid = Convert.ToInt32(dgvFollowups.Rows[e.RowIndex].Cells["fid"].Value);
            Database.SetFollowupCompleted(fid);
            LoadFollowups();
        }

        /* ---------- ComboBox change ---------- */
        private void dgvFollowups_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvFollowups.Columns[e.ColumnIndex].Name != "status") return;

            int fid = Convert.ToInt32(dgvFollowups.Rows[e.RowIndex].Cells["fid"].Value);
            string newSt = dgvFollowups.Rows[e.RowIndex].Cells["status"].Value?.ToString() ?? "PENDING";

            Database.SetFollowupStatus(fid, newSt);
            dgvFollowups.InvalidateRow(e.RowIndex);   // refresh color
        }

        private void dgvFollowups_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFollowups.IsCurrentCellDirty)
                dgvFollowups.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /* ---------- row color style ---------- */
        private void dgvFollowups_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvFollowups.Rows[e.RowIndex];
            string sts = row.Cells["status"].Value?.ToString() ?? "";

            Color back = sts switch
            {
                "PENDING" => Color.Gold,
                "COMPLETED" => Color.LightGreen,
                _ => dgvFollowups.DefaultCellStyle.BackColor
            };

            row.DefaultCellStyle.BackColor = back;
            row.DefaultCellStyle.SelectionBackColor = back;
            row.DefaultCellStyle.ForeColor = Color.Black;   // always black
            row.DefaultCellStyle.SelectionForeColor = Color.Black;
        }
    }
}
