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
using static ITP4915MSystem.Database;

namespace ITP4915M_System
{
    public partial class FormFinance : Form
    {
        public FormFinance()
        {
            InitializeComponent();

            // 事件綁定
            btnAddInvoice.Click += btnAddInvoice_Click;
            btnDeleteInvoice.Click += btnDeleteInvoice_Click;
            btnRefresh.Click += btnRefresh_Click;
            dgvInvoice.CellValueChanged += dgvInvoice_CellValueChanged;
            dgvInvoice.CurrentCellDirtyStateChanged += dgvInvoice_CurrentCellDirtyStateChanged;
            dgvInvoice.RowPrePaint += dgvInvoice_RowPrePaint;

            // 禁止自動新增空白行
            dgvInvoice.AllowUserToAddRows = false;

            LoadInvoices();
        }

        // 讀取發票到 DataGridView，並設下拉、欄位名稱等
        private void LoadInvoices()
        {
            DataTable dt = Database.GetAllInvoices();
            dgvInvoice.DataSource = dt;

            if (dt == null || dt.Columns.Count == 0)
                return;

            // 先安全判斷欄位，然後按你要的順序做
            if (dgvInvoice.Columns.Contains("invoiceID"))
            {
                dgvInvoice.Columns["invoiceID"].HeaderText = "Invoice ID";
                dgvInvoice.Columns["invoiceID"].Width = 100;
            }
            if (dgvInvoice.Columns.Contains("orderID"))
            {
                dgvInvoice.Columns["orderID"].HeaderText = "Order ID";
                dgvInvoice.Columns["orderID"].Width = 90;
            }
            if (dgvInvoice.Columns.Contains("user_name"))
            {
                dgvInvoice.Columns["user_name"].HeaderText = "User Name";
                dgvInvoice.Columns["user_name"].Width = 100;
            }
            if (dgvInvoice.Columns.Contains("order_type"))
            {
                dgvInvoice.Columns["order_type"].HeaderText = "Order Type";
                dgvInvoice.Columns["order_type"].Width = 100;
            }
            if (dgvInvoice.Columns.Contains("amount"))
            {
                dgvInvoice.Columns["amount"].HeaderText = "Amount";
                dgvInvoice.Columns["amount"].Width = 100;
            }
            if (dgvInvoice.Columns.Contains("issueDate"))
            {
                dgvInvoice.Columns["issueDate"].HeaderText = "Issue Date";
                dgvInvoice.Columns["issueDate"].Width = 120;
            }

            // 欄位重新排序（可確保順序正確）
            string[] order = { "invoiceID", "orderID", "user_name", "order_type", "amount", "issueDate", "status" };
            for (int i = 0; i < order.Length; i++)
            {
                if (dgvInvoice.Columns.Contains(order[i]))
                    dgvInvoice.Columns[order[i]].DisplayIndex = i;
            }

            // 狀態用下拉選單
            if (dgvInvoice.Columns.Contains("status"))
            {
                int idx = dgvInvoice.Columns["status"].Index;
                dgvInvoice.Columns.Remove("status");
                var comboCol = new DataGridViewComboBoxColumn
                {
                    Name = "status",
                    HeaderText = "Status",
                    DataPropertyName = "status",
                    Width = 110
                };
                comboCol.Items.AddRange("Pending", "Paid", "Overdue");
                dgvInvoice.Columns.Insert(idx, comboCol);

                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    if (row.Cells["status"] is DataGridViewComboBoxCell cbCell)
                        cbCell.Value = row.Cells["status"].Value ?? "Pending";
                }
            }

            dgvInvoice.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvInvoice.ClearSelection();
            foreach (DataGridViewColumn col in dgvInvoice.Columns)
            {
                if (col.Name == "status")
                    col.ReadOnly = false;  // Status 欄可編輯
                else
                    col.ReadOnly = true;   // 其它全部唯讀
            }
        }


        // 刷新
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        // 新增發票
        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddInvoiceDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string invoiceID = Database.GetNextInvoiceID(); // 自動產生
                    InvoiceModel m = new InvoiceModel
                    {
                        InvoiceID = invoiceID,
                        OrderID = dlg.SelectedOrderID,
                        Amount = dlg.SelectedAmount,
                        IssueDate = DateTime.Now.Date,
                        Status = "Pending"
                    };
                    try
                    {
                        Database.InsertInvoice(m);
                        LoadInvoices();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to add invoice: " + ex.Message);
                    }
                }
            }
        }


        // 刪除發票
        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.SelectedRows.Count > 0)
            {
                string invoiceID = dgvInvoice.SelectedRows[0].Cells["invoiceID"].Value?.ToString();
                if (!string.IsNullOrEmpty(invoiceID))
                {
                    if (MessageBox.Show("Delete this invoice?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            Database.DeleteInvoice(invoiceID);
                            LoadInvoices();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to delete invoice: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }

        // 狀態下拉變動後即時更新資料庫
        private void dgvInvoice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInvoice.Columns[e.ColumnIndex].Name == "status")
            {
                string invoiceID = dgvInvoice.Rows[e.RowIndex].Cells["invoiceID"].Value?.ToString();
                string status = dgvInvoice.Rows[e.RowIndex].Cells["status"].Value?.ToString();
                if (!string.IsNullOrEmpty(invoiceID) && !string.IsNullOrEmpty(status))
                {
                    Database.UpdateInvoiceStatus(invoiceID, status);
                    LoadInvoices();
                }
            }
        }

        // 確保下拉一選就 commit
        private void dgvInvoice_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInvoice.IsCurrentCellDirty)
                dgvInvoice.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // 逾期自動高亮
        private void dgvInvoice_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvInvoice.Rows[e.RowIndex];
            if (row.Cells["status"].Value?.ToString() == "Overdue")
            {
                row.DefaultCellStyle.BackColor = Color.Red;
                row.DefaultCellStyle.ForeColor = Color.White;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }
}