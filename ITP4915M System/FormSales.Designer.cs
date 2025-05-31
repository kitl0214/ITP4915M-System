using System;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915MSystem          // ← 按需更改
{
    partial class FormSales : FormTemplate   // 仍然繼承 FormTemplate
    {
        private System.ComponentModel.IContainer components = null;

        // UI controls
        private Label lblTitle;
        private ComboBox cmbStatusFilter;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dvOrders;
        private Button btnNew;
        private Button btnEdit;
        private Button btnCancel;
        private Button btnShip;
        private Button btnRefresh;
        private Button btnExportCsv;

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            cmbStatusFilter = new ComboBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dvOrders = new DataGridView();
            btnNew = new Button();
            btnEdit = new Button();
            btnCancel = new Button();
            btnShip = new Button();
            btnRefresh = new Button();
            btnExportCsv = new Button();
            ((System.ComponentModel.ISupportInitialize)(dvOrders)).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(152, 25);
            lblTitle.Text = "Sales Dashboard";

            // cmbStatusFilter
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Items.AddRange(new object[] { "All", "PENDING", "SHIPPED", "CANCELLED" });
            cmbStatusFilter.Location = new Point(20, 55);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(120, 28);

            // txtSearch
            txtSearch.Location = new Point(160, 55);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Order ID / Customer";
            txtSearch.Size = new Size(220, 28);

            // btnSearch
            btnSearch.Location = new Point(390, 53);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 30);
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;

            // dvOrders
            dvOrders.AllowUserToAddRows = false;
            dvOrders.AllowUserToDeleteRows = false;
            dvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvOrders.Location = new Point(20, 95);
            dvOrders.MultiSelect = false;
            dvOrders.Name = "dvOrders";
            dvOrders.ReadOnly = true;
            dvOrders.RowTemplate.Height = 25;
            dvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvOrders.Size = new Size(740, 260);

            // btnNew
            btnNew.Location = new Point(20, 370);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(80, 32);
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;

            // btnEdit
            btnEdit.Location = new Point(110, 370);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(80, 32);
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;

            // btnCancel
            btnCancel.Location = new Point(200, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 32);
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // btnShip
            btnShip.Location = new Point(290, 370);
            btnShip.Name = "btnShip";
            btnShip.Size = new Size(80, 32);
            btnShip.Text = "Ship";
            btnShip.UseVisualStyleBackColor = true;
            btnShip.Click += btnShip_Click;

            // btnRefresh
            btnRefresh.Location = new Point(380, 370);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(80, 32);
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;

            // btnExportCsv
            btnExportCsv.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportCsv.Location = new Point(680, 370);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(100, 32);
            btnExportCsv.Text = "Export CSV";
            btnExportCsv.UseVisualStyleBackColor = true;
            btnExportCsv.Click += btnExportCsv_Click;

            // FormSales
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 420);
            Controls.Add(btnExportCsv);
            Controls.Add(btnRefresh);
            Controls.Add(btnShip);
            Controls.Add(btnCancel);
            Controls.Add(btnEdit);
            Controls.Add(btnNew);
            Controls.Add(dvOrders);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(cmbStatusFilter);
            Controls.Add(lblTitle);
            Name = "FormSales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales Management";
            Load += FormSales_Load;
            ((System.ComponentModel.ISupportInitialize)(dvOrders)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
