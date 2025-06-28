// FormReport.Designer.cs – English-only version
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class FormReport
    {
        private IContainer components = null;
        private DataGridView dgvOrders;
        private Label lblOrderCount;
        private Button btnExport;

        /// <summary>Release managed / unmanaged resources.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            dgvOrders = new DataGridView();
            lblOrderCount = new Label();
            btnExport = new Button();
            ((ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeight = 34;
            dgvOrders.Dock = DockStyle.Top;
            dgvOrders.Location = new Point(0, 0);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.Size = new Size(800, 320);
            dgvOrders.TabIndex = 0;
            // 
            // lblOrderCount
            // 
            lblOrderCount.AutoSize = true;
            lblOrderCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOrderCount.Location = new Point(12, 335);
            lblOrderCount.Name = "lblOrderCount";
            lblOrderCount.Size = new Size(160, 23);
            lblOrderCount.TabIndex = 1;
            lblOrderCount.Text = "Total months: 0";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(650, 330);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(120, 35);
            btnExport.TabIndex = 2;
            btnExport.Text = "Export CSV";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // FormReport
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 380);
            Controls.Add(btnExport);
            Controls.Add(lblOrderCount);
            Controls.Add(dgvOrders);
            Name = "FormReport";
            Text = "Report";
            Load += FormReport_Load;
            ((ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
