// -----------------------------------------------------------------------------
// FormSales.Designer.cs – layout for Sales Dashboard
// -----------------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    /* ★ 不再繼承 Form，繼承關係已在 FormSales.cs 宣告 */
    partial class FormSales
    {
        private IContainer components = null;
        private DataGridView dgvOrders;
        private Button btnCreate;
        private Button btnRefresh;
        private Button btnDelete;
        private Button btnEdit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new Container();
            dgvOrders = new DataGridView();
            btnCreate = new Button();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnEdit = new Button();

            ((ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();

            /* ---------- dgvOrders ---------- */
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvOrders.ColumnHeadersHeight = 46;
            dgvOrders.Location = new Point(16, 75);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 82;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(1320, 537);
            dgvOrders.TabIndex = 0;

            /* ---------- btnCreate ---------- */
            btnCreate.Location = new Point(41, 24);
            btnCreate.Size = new Size(124, 34);
            btnCreate.Text = "Create";
            btnCreate.Click += btnCreate_Click;

            /* ---------- btnRefresh ---------- */
            btnRefresh.Location = new Point(172, 24);
            btnRefresh.Size = new Size(109, 34);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;

            /* ---------- btnEdit ---------- */
            btnEdit.Location = new Point(311, 24);
            btnEdit.Size = new Size(102, 34);
            btnEdit.Text = "Edit";
            btnEdit.Click += btnEdit_Click;

            /* ---------- btnDelete ---------- */
            btnDelete.Location = new Point(445, 24);
            btnDelete.Size = new Size(110, 34);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;

            /* ---------- FormSales ---------- */
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 645);
            Controls.AddRange(new Control[]
            {
                dgvOrders, btnCreate, btnRefresh, btnEdit, btnDelete
            });
            Name = "FormSales";
            Text = "Sales";
            Load += FormSales_Load;

            ((ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}
