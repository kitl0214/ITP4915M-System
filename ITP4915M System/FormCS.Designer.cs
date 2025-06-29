// -----------------------------------------------------------------------------
// FormCS.Designer.cs – layout; CellDoubleClick event wired
// -----------------------------------------------------------------------------
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace ITP4915M_System
{
    partial class FormCS
    {
        private IContainer components = null;
        private DataGridView dgvOrders;
        private DataGridView dgvFollowups;
        private Button btnLoadOrders;
        private Button btnAddFollowup;
        private Button btnEditFollowup;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            dgvOrders = new DataGridView();
            dgvFollowups = new DataGridView();
            btnLoadOrders = new Button();
            btnAddFollowup = new Button();
            btnEditFollowup = new Button();

            ((ISupportInitialize)dgvOrders).BeginInit();
            ((ISupportInitialize)dgvFollowups).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.Location = new Point(20, 70);
            dgvOrders.Size = new Size(760, 250);
            dgvOrders.ReadOnly = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            // 
            // dgvFollowups
            // 
            dgvFollowups.Location = new Point(20, 350);
            dgvFollowups.Size = new Size(760, 250);
            dgvFollowups.ReadOnly = false;
            dgvFollowups.AllowUserToAddRows = false;
            dgvFollowups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFollowups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvFollowups.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvFollowups.CellContentClick += dgvFollowups_CellContentClick;
            dgvFollowups.RowPrePaint += dgvFollowups_RowPrePaint;
            dgvFollowups.CellValueChanged += dgvFollowups_CellValueChanged;
            dgvFollowups.CurrentCellDirtyStateChanged
                                            += dgvFollowups_CurrentCellDirtyStateChanged;
            dgvFollowups.CellDoubleClick += dgvFollowups_CellDoubleClick;   // ★
            // 
            // btnLoadOrders
            // 
            btnLoadOrders.Location = new Point(20, 25);
            btnLoadOrders.Size = new Size(120, 30);
            btnLoadOrders.Text = "Load Orders";
            btnLoadOrders.Click += btnLoadOrders_Click;
            // 
            // btnAddFollowup
            // 
            btnAddFollowup.Location = new Point(160, 25);
            btnAddFollowup.Size = new Size(160, 30);
            btnAddFollowup.Text = "New Follow-Up";
            btnAddFollowup.Click += btnAddFollowup_Click;
            // 
            // btnEditFollowup
            // 
            btnEditFollowup.Location = new Point(330, 25);
            btnEditFollowup.Size = new Size(160, 30);
            btnEditFollowup.Text = "Edit Follow-Up";
            btnEditFollowup.Click += btnEditFollowup_Click;
            // 
            // FormCS
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 620);
            Controls.AddRange(new Control[]
            {
                btnEditFollowup,
                btnAddFollowup,
                btnLoadOrders,
                dgvFollowups,
                dgvOrders
            });
            Name = "FormCS";
            Text = "Customer Service";
            Load += FormCS_Load;

            ((ISupportInitialize)dgvOrders).EndInit();
            ((ISupportInitialize)dgvFollowups).EndInit();
            ResumeLayout(false);
        }
    }
}
