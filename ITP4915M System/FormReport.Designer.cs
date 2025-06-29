// -----------------------------------------------------------------------------
// FormReport.Designer.cs  –  simple layout
//   • 上半部：訂單月份統計 + Export Orders 按鈕 + 筆數摘要
//   • 下半部：待跟進月份統計 + Export Follow-ups 按鈕 + 筆數摘要
//   • 兩張 DataGridView 以 DisplayedCells 自動調欄寬（執行時在 FormReport.cs 設定）
// -----------------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class FormReport
    {
        private IContainer components = null;

        private Label lblOrdersTitle;
        private DataGridView dgvOrders;
        private Button btnExportOrders;
        private Label lblOrderCount;

        private Label lblFUTitle;
        private DataGridView dgvFollowups;
        private Button btnExportFU;
        private Label lblFUCount;

        /// <summary>clean resources</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows-Form Designer
        private void InitializeComponent()
        {
            lblOrdersTitle = new Label();
            dgvOrders = new DataGridView();
            btnExportOrders = new Button();
            lblOrderCount = new Label();
            lblFUTitle = new Label();
            dgvFollowups = new DataGridView();
            btnExportFU = new Button();
            lblFUCount = new Label();
            ((ISupportInitialize)dgvOrders).BeginInit();
            ((ISupportInitialize)dgvFollowups).BeginInit();
            SuspendLayout();
            // 
            // lblOrdersTitle
            // 
            lblOrdersTitle.AutoSize = true;
            lblOrdersTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOrdersTitle.Location = new Point(39, 31);
            lblOrdersTitle.Margin = new Padding(5, 0, 5, 0);
            lblOrdersTitle.Name = "lblOrdersTitle";
            lblOrdersTitle.Size = new Size(66, 28);
            lblOrdersTitle.TabIndex = 0;
            lblOrdersTitle.Text = "Order";
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeight = 34;
            dgvOrders.Location = new Point(39, 69);
            dgvOrders.Margin = new Padding(5, 5, 5, 5);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.Size = new Size(471, 337);
            dgvOrders.TabIndex = 1;
            // 
            // btnExportOrders
            // 
            btnExportOrders.Location = new Point(536, 69);
            btnExportOrders.Margin = new Padding(5, 5, 5, 5);
            btnExportOrders.Name = "btnExportOrders";
            btnExportOrders.Size = new Size(220, 54);
            btnExportOrders.TabIndex = 2;
            btnExportOrders.Text = "Export Orders";
            btnExportOrders.Click += btnExportOrders_Click;
            // 
            // lblOrderCount
            // 
            lblOrderCount.AutoSize = true;
            lblOrderCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOrderCount.Location = new Point(536, 128);
            lblOrderCount.Margin = new Padding(5, 0, 5, 0);
            lblOrderCount.Name = "lblOrderCount";
            lblOrderCount.Size = new Size(133, 25);
            lblOrderCount.TabIndex = 3;
            lblOrderCount.Text = "Total orders: 0";
            // 
            // lblFUTitle
            // 
            lblFUTitle.AutoSize = true;
            lblFUTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFUTitle.Location = new Point(39, 460);
            lblFUTitle.Margin = new Padding(5, 0, 5, 0);
            lblFUTitle.Name = "lblFUTitle";
            lblFUTitle.Size = new Size(115, 28);
            lblFUTitle.TabIndex = 4;
            lblFUTitle.Text = "Follow-ups";
            // 
            // dgvFollowups
            // 
            dgvFollowups.AllowUserToAddRows = false;
            dgvFollowups.AllowUserToDeleteRows = false;
            dgvFollowups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFollowups.ColumnHeadersHeight = 34;
            dgvFollowups.Location = new Point(39, 498);
            dgvFollowups.Margin = new Padding(5, 5, 5, 5);
            dgvFollowups.Name = "dgvFollowups";
            dgvFollowups.ReadOnly = true;
            dgvFollowups.RowHeadersVisible = false;
            dgvFollowups.RowHeadersWidth = 62;
            dgvFollowups.Size = new Size(471, 337);
            dgvFollowups.TabIndex = 5;
            // 
            // btnExportFU
            // 
            btnExportFU.Location = new Point(536, 498);
            btnExportFU.Margin = new Padding(5, 5, 5, 5);
            btnExportFU.Name = "btnExportFU";
            btnExportFU.Size = new Size(220, 54);
            btnExportFU.TabIndex = 6;
            btnExportFU.Text = "Export Follow-ups";
            btnExportFU.Click += btnExportFU_Click;
            // 
            // lblFUCount
            // 
            lblFUCount.AutoSize = true;
            lblFUCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFUCount.Location = new Point(536, 567);
            lblFUCount.Margin = new Padding(5, 0, 5, 0);
            lblFUCount.Name = "lblFUCount";
            lblFUCount.Size = new Size(196, 25);
            lblFUCount.TabIndex = 7;
            lblFUCount.Text = "Pending follow-ups: 0";
            // 
            // FormReport
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 882);
            Controls.Add(lblOrdersTitle);
            Controls.Add(dgvOrders);
            Controls.Add(btnExportOrders);
            Controls.Add(lblOrderCount);
            Controls.Add(lblFUTitle);
            Controls.Add(dgvFollowups);
            Controls.Add(btnExportFU);
            Controls.Add(lblFUCount);
            Margin = new Padding(5, 5, 5, 5);
            Name = "FormReport";
            Text = "Monthly Report";
            Load += FormReport_Load;
            ((ISupportInitialize)dgvOrders).EndInit();
            ((ISupportInitialize)dgvFollowups).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
