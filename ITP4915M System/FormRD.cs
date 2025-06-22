using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class FormRD : Form
    {
        private Button btnRefresh;

        public FormRD()
        {
            InitializeComponent();

           
            // 新增手動刷新按鈕
            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Size = new Size(80, 30);
            btnRefresh.Location = new Point(-140, 10); 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Click += btnRefresh_Click;
            this.Controls.Add(btnRefresh);

            // 註冊事件
            dgvOP.CellBeginEdit += DgvOP_CellBeginEdit;
            dgvTR.CellBeginEdit += DgvTR_CellBeginEdit;
            dgvOP.CellValueChanged += DgvOP_CellValueChanged;
            dgvTR.CellValueChanged += DgvTR_CellValueChanged;
            dgvTR.RowPrePaint += DgvTR_RowPrePaint;
            dgvCP.ReadOnly = true;

            // 讓下拉一選即時觸發
            dgvOP.CurrentCellDirtyStateChanged += dgvOP_CurrentCellDirtyStateChanged;
            dgvTR.CurrentCellDirtyStateChanged += dgvTR_CurrentCellDirtyStateChanged;

            // 關閉自動新增行
            dgvOP.AllowUserToAddRows = false;
            dgvTR.AllowUserToAddRows = false;
            dgvCP.AllowUserToAddRows = false;

            LoadData();
        }

        // Ongoing 只允許編輯 status
        private void DgvOP_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvOP.Columns[e.ColumnIndex].Name != "status") e.Cancel = true;
        }
        private void DgvTR_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvTR.Columns[e.ColumnIndex].Name != "status") e.Cancel = true;
        }

        // 狀態切換即時分流
        private void DgvOP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOP.Columns[e.ColumnIndex].Name == "status")
            {
                string specID = dgvOP.Rows[e.RowIndex].Cells["specID"].Value?.ToString();
                string newStatus = dgvOP.Rows[e.RowIndex].Cells["status"].Value?.ToString();
                if (!string.IsNullOrEmpty(specID) && !string.IsNullOrEmpty(newStatus))
                {
                    Database.UpdateRAndDStatus(specID, newStatus);
                    LoadData();
                }
            }
        }
        private void DgvTR_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTR.Columns[e.ColumnIndex].Name == "status")
            {
                string specID = dgvTR.Rows[e.RowIndex].Cells["specID"].Value?.ToString();
                string newStatus = dgvTR.Rows[e.RowIndex].Cells["status"].Value?.ToString();
                if (!string.IsNullOrEmpty(specID) && !string.IsNullOrEmpty(newStatus))
                {
                    Database.UpdateRAndDStatus(specID, newStatus);
                    LoadData();
                }
            }
        }

        // 下拉一選就即時觸發 ValueChanged
        private void dgvOP_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvOP.IsCurrentCellDirty)
                dgvOP.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dgvTR_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTR.IsCurrentCellDirty)
                dgvTR.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // Task Reminder 過期資料自動黃底
        private void DgvTR_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvTR.Rows[e.RowIndex];
            if (row.Cells["deadLine"].Value != null &&
                DateTime.TryParse(row.Cells["deadLine"].Value.ToString(), out var deadline))
            {
                if (deadline < DateTime.Now)
                    row.DefaultCellStyle.BackColor = Color.Red;
                else
                    row.DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        // 手動刷新
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {

            try
            {

                DataTable dtAll = Database.GetRDOrders();
                var now = DateTime.Now;
                var soon = now.AddDays(14);

                var allRows = dtAll.AsEnumerable();

                // Ongoing: status=On Going，且 deadline > soon（超過14天才到期）
                var ongoing = allRows
                    .Where(row => row.Field<string>("status") == "On Going"
                        && row.Field<DateTime?>("deadLine") > soon);

                // Task Reminder: status=On Going，且 deadline <= soon（不論已過期還是即將到期）
                var reminder = allRows
                    .Where(row => row.Field<string>("status") == "On Going"
                        && row.Field<DateTime?>("deadLine") <= soon);

                var completed = allRows
                    .Where(row => row.Field<string>("status") == "Completed");

                dgvOP.DataSource = ongoing.Any() ? ongoing.CopyToDataTable() : null;
                dgvTR.DataSource = reminder.Any() ? reminder.CopyToDataTable() : null;
                dgvCP.DataSource = completed.Any() ? completed.CopyToDataTable() : null;

                SetHeaders(dgvOP, true);
                SetHeaders(dgvTR, true);
                SetHeaders(dgvCP, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // 設定欄位與 status 下拉/唯讀
        private void SetHeaders(DataGridView dgv, bool useComboBox)
        {
            if (dgv.DataSource == null) return;
            if (dgv.Columns.Contains("approvedByName"))
                dgv.Columns.Remove("approvedByName");

            dgv.Columns["specID"].HeaderText = "Tailor Made ID";
            dgv.Columns["specID"].Width = 120;
            dgv.Columns["orderID"].HeaderText = "Order ID";
            dgv.Columns["orderID"].Width = 80;
            if (dgv.Columns.Contains("customer_name"))
            {
                dgv.Columns["customer_name"].HeaderText = "Customer";
                dgv.Columns["customer_name"].Width = 120;
            }
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 200;
            dgv.Columns["description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.Columns["deadLine"].HeaderText = "Deadline";
            dgv.Columns["deadLine"].Width = 120;

            // 狀態欄動態加 ComboBox
            if (dgv.Columns.Contains("status"))
            {
                int idx = dgv.Columns["status"].Index;
                dgv.Columns.Remove("status");
                if (useComboBox)
                {
                    var comboCol = new DataGridViewComboBoxColumn
                    {
                        Name = "status",
                        HeaderText = "Status",
                        DataPropertyName = "status",
                        Width = 90
                    };
                    comboCol.Items.AddRange("On Going", "Completed");
                    dgv.Columns.Insert(idx, comboCol);

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["status"] is DataGridViewComboBoxCell cbCell)
                        {
                            cbCell.Value = row.Cells["status"].Value ?? "On Going";
                        }
                    }
                }
                else
                {
                    var textCol = new DataGridViewTextBoxColumn
                    {
                        Name = "status",
                        HeaderText = "Status",
                        DataPropertyName = "status",
                        Width = 90
                    };
                    dgv.Columns.Insert(idx, textCol);
                }
            }

            // ---- 這裡加欄位順序（強制排序） ----
            if (dgv.Columns.Contains("specID")) dgv.Columns["specID"].DisplayIndex = 0;
            if (dgv.Columns.Contains("orderID")) dgv.Columns["orderID"].DisplayIndex = 1;
            if (dgv.Columns.Contains("customer_name")) dgv.Columns["customer_name"].DisplayIndex = 2;
            if (dgv.Columns.Contains("description")) dgv.Columns["description"].DisplayIndex = 3;
            if (dgv.Columns.Contains("deadLine")) dgv.Columns["deadLine"].DisplayIndex = 4;
            if (dgv.Columns.Contains("status")) dgv.Columns["status"].DisplayIndex = 5;
            // -------------------------------------

            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.ClearSelection();
        }

    }
}
