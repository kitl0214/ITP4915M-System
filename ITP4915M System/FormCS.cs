// -----------------------------------------------------------------------------
// FormCS.cs – Customer-Service dashboard (status ComboBox, edit button, colors)
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

        /* ---------- orders ---------- */
        private void btnLoadOrders_Click(object sender, EventArgs e) => LoadOrders();

        private void LoadOrders() => dgvOrders.DataSource = Database.GetAllOrders();

        /* ---------- follow-ups ---------- */

        private void btnAddFollowup_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select one order first.");
                return;
            }

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
            if (dgvFollowups.SelectedRows.Count == 0 ||
                dgvFollowups.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Please select one follow-up first.");
                return;
            }

            var row = dgvFollowups.SelectedRows[0];

            if (!int.TryParse(row.Cells["fid"].Value?.ToString(), out int fid))
            {
                MessageBox.Show("Invalid follow-up record.");
                return;
            }

            string oid = row.Cells["oid"]?.Value?.ToString() ?? "";
            string act = row.Cells["action"]?.Value?.ToString() ?? "";
            string comm = row.Cells["comment"]?.Value?.ToString() ?? "";

            using var dlg = new FollowupDialog(oid, act, comm);
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            Database.UpdateFollowup(fid, dlg.SelectedAction, dlg.CustomerComment);
            LoadFollowups();
        }

        /* ---------- core: load & build follow-up grid ---------- */
        private void LoadFollowups()
        {
            dgvFollowups.DataSource = Database.GetAllFollowups();

            /* Done 按鈕欄 */
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

            /* status → ComboBox 欄 */
            const string stsCol = "status";
            if (dgvFollowups.Columns[stsCol] is not DataGridViewComboBoxColumn)
            {
                int idx = dgvFollowups.Columns[stsCol].Index;
                string dprop = dgvFollowups.Columns[stsCol].DataPropertyName;

                dgvFollowups.Columns.Remove(stsCol);

                var cbo = new DataGridViewComboBoxColumn
                {
                    Name = stsCol,
                    HeaderText = "Status",
                    DataPropertyName = dprop,
                    DataSource = new[] { "PENDING", "COMPLETED" },
                    Width = 110,
                    FlatStyle = FlatStyle.Flat
                };
                dgvFollowups.Columns.Insert(idx, cbo);
            }

            /* 清除預設選取，避免唯一列被藍色覆蓋 */
            dgvFollowups.ClearSelection();
        }

        /* 完成按鈕 */
        private void dgvFollowups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvFollowups.Columns[e.ColumnIndex].Name != "Action") return;

            int fid = Convert.ToInt32(dgvFollowups.Rows[e.RowIndex].Cells["fid"].Value);
            Database.SetFollowupCompleted(fid);
            LoadFollowups();
        }

        /* ComboBox 變動 → 寫回 DB */
        private void dgvFollowups_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvFollowups.Columns[e.ColumnIndex].Name != "status") return;

            int fid = Convert.ToInt32(dgvFollowups.Rows[e.RowIndex].Cells["fid"].Value);
            string newSt = dgvFollowups.Rows[e.RowIndex].Cells["status"].Value?.ToString() ?? "PENDING";

            Database.SetFollowupStatus(fid, newSt);
            dgvFollowups.InvalidateRow(e.RowIndex);   // refresh color
        }

        /* 必須用傳統事件方法，Designer 才能解析 */
        private void dgvFollowups_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFollowups.IsCurrentCellDirty)
                dgvFollowups.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvFollowups_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvFollowups.Rows[e.RowIndex];
            string sts = row.Cells["status"].Value?.ToString() ?? "";

            Color clr = sts switch
            {
                "PENDING" => Color.Gold,
                "COMPLETED" => Color.LightGreen,
                _ => dgvFollowups.DefaultCellStyle.BackColor
            };

            row.DefaultCellStyle.BackColor = clr;
            row.DefaultCellStyle.SelectionBackColor = clr;   // same when selected
        }
    }
}
