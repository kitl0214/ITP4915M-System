// ========================= FormSales.Designer.cs =========================
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class FormSales
    {
        private IContainer components = null;
        private DataGridView dgvOrders;
        private Button btnCreate;
        private Button btnRefresh;
        private Button btnDelete;
        private Button btnEdit;   // ← 全域 Edit Selected

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvOrders = new DataGridView();
            btnCreate = new Button();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            ((ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvOrders.ColumnHeadersHeight = 46;
            dgvOrders.Location = new Point(19, 104);
            dgvOrders.Margin = new Padding(4, 4, 4, 4);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 82;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(1560, 747);
            dgvOrders.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(49, 33);
            btnCreate.Margin = new Padding(4, 4, 4, 4);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(146, 47);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Create";
            btnCreate.Click += btnCreate_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(203, 33);
            btnRefresh.Margin = new Padding(4, 4, 4, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(129, 47);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(526, 33);
            btnDelete.Margin = new Padding(4, 4, 4, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 47);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete Selected";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(368, 33);
            btnEdit.Margin = new Padding(4, 4, 4, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(121, 47);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit Selected";
            btnEdit.Click += btnEdit_Click;
            // 
            // FormSales
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1599, 897);
            Controls.Add(dgvOrders);
            Controls.Add(btnCreate);
            Controls.Add(btnRefresh);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormSales";
            Text = "Sales";
            Load += FormSales_Load;
            ((ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }
    }
}
