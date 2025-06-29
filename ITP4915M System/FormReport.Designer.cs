// -----------------------------------------------------------------------------
// FormReport.Designer.cs – two DataGridViews + two export buttons
// -----------------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class FormReport
    {
        private IContainer components = null;
        private DataGridView dgvOrders;
        private DataGridView dgvFollowups;
        private Label lblOrderCount;
        private Label lblFUCount;
        private Button btnExportOrders;
        private Button btnExportFU;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvOrders = new DataGridView();
            dgvFollowups = new DataGridView();
            lblOrderCount = new Label();
            lblFUCount = new Label();
            btnExportOrders = new Button();
            btnExportFU = new Button();
            label1 = new Label();
            label2 = new Label();
            ((ISupportInitialize)dgvOrders).BeginInit();
            ((ISupportInitialize)dgvFollowups).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeight = 34;
            dgvOrders.Location = new Point(72, 35);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.Size = new Size(244, 188);
            dgvOrders.TabIndex = 0;
            // 
            // dgvFollowups
            // 
            dgvFollowups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFollowups.ColumnHeadersHeight = 34;
            dgvFollowups.Location = new Point(72, 313);
            dgvFollowups.Name = "dgvFollowups";
            dgvFollowups.ReadOnly = true;
            dgvFollowups.RowHeadersVisible = false;
            dgvFollowups.RowHeadersWidth = 62;
            dgvFollowups.Size = new Size(244, 189);
            dgvFollowups.TabIndex = 3;
            // 
            // lblOrderCount
            // 
            lblOrderCount.AutoSize = true;
            lblOrderCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOrderCount.Location = new Point(18, 250);
            lblOrderCount.Name = "lblOrderCount";
            lblOrderCount.Size = new Size(0, 25);
            lblOrderCount.TabIndex = 1;
            // 
            // lblFUCount
            // 
            lblFUCount.AutoSize = true;
            lblFUCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFUCount.Location = new Point(18, 530);
            lblFUCount.Name = "lblFUCount";
            lblFUCount.Size = new Size(0, 25);
            lblFUCount.TabIndex = 4;
            // 
            // btnExportOrders
            // 
            btnExportOrders.Location = new Point(361, 44);
            btnExportOrders.Name = "btnExportOrders";
            btnExportOrders.Size = new Size(131, 32);
            btnExportOrders.TabIndex = 2;
            btnExportOrders.Text = "Export Orders";
            btnExportOrders.Click += btnExportOrders_Click;
            // 
            // btnExportFU
            // 
            btnExportFU.Location = new Point(361, 301);
            btnExportFU.Name = "btnExportFU";
            btnExportFU.Size = new Size(163, 32);
            btnExportFU.TabIndex = 5;
            btnExportFU.Text = "Export Follow-ups";
            btnExportFU.Click += btnExportFU_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 9);
            label1.Name = "label1";
            label1.Size = new Size(60, 23);
            label1.TabIndex = 6;
            label1.Text = "Order";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 276);
            label2.Name = "label2";
            label2.Size = new Size(103, 23);
            label2.TabIndex = 7;
            label2.Text = "Follow-ups";
            // 
            // FormReport
            // 
            ClientSize = new Size(936, 663);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvOrders);
            Controls.Add(lblOrderCount);
            Controls.Add(btnExportOrders);
            Controls.Add(dgvFollowups);
            Controls.Add(lblFUCount);
            Controls.Add(btnExportFU);
            Name = "FormReport";
            Text = "Monthly Report";
            Load += FormReport_Load;
            ((ISupportInitialize)dgvOrders).EndInit();
            ((ISupportInitialize)dgvFollowups).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
        private Label label2;
    }
}
