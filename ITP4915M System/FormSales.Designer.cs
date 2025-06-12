using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class FormSales
    {
        private IContainer components = null;
        private DataGridView dgvOrders;
        private Button btnRefresh;
        private Button creatobt;

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
            btnRefresh = new Button();
            creatobt = new Button();
            ((ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvOrders.ColumnHeadersHeight = 34;
            dgvOrders.Location = new Point(16, 75);
            dgvOrders.Margin = new Padding(4, 3, 4, 3);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.RowTemplate.Height = 25;
            dgvOrders.Size = new Size(1320, 537);
            dgvOrders.TabIndex = 0;
            dgvOrders.CellContentClick += dgvOrders_CellContentClick;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(245, 24);
            btnRefresh.Margin = new Padding(4, 3, 4, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(129, 33);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // creatobt
            // 
            creatobt.Location = new Point(47, 24);
            creatobt.Margin = new Padding(4, 3, 4, 3);
            creatobt.Name = "creatobt";
            creatobt.Size = new Size(173, 33);
            creatobt.TabIndex = 2;
            creatobt.Text = "Create New Order";
            creatobt.UseVisualStyleBackColor = true;
            creatobt.Click += creatobt_Click;
            // 
            // FormSales
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 645);
            Controls.Add(creatobt);
            Controls.Add(btnRefresh);
            Controls.Add(dgvOrders);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales Dashboard";
            Load += FormSales_Load;
            ((ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}
