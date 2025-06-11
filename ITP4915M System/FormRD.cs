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
        public FormRD()
        {
            InitializeComponent();
            LoadData();
            dgvOP.CellBeginEdit += DgvOP_CellBeginEdit;
            dgvOP.CellEndEdit += DgvOP_CellEndEdit;
        }

        private void DgvOP_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Allow edit status
            if (dgvOP.Columns[e.ColumnIndex].Name != "status")
            {
                e.Cancel = true;
            }
        }

        private void LoadData()
        {
            try
            {
                
                dgvOP.DataSource = Database.GetRDOrders();
                dgvOP.ReadOnly = true;
                /* Spec ID */
                dgvOP.Columns["specID"].HeaderText = "Tailor Made ID";
                dgvOP.Columns["specID"].Width = 120;
                /* Order ID */
                dgvOP.Columns["orderID"].HeaderText = "Order ID";
                dgvOP.Columns["orderID"].Width = 80;
                /* Description */
                dgvOP.Columns["description"].HeaderText = "Description";
                dgvOP.Columns["description"].Width = 200;
                dgvOP.Columns["description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                /* Approved By ID */
                dgvOP.Columns["approvedByID"].HeaderText = "User ID";
                dgvOP.Columns["approvedByID"].Width = 80;
                /* Approved By Name */
                dgvOP.Columns["approvedByName"].HeaderText = "User Name";
                dgvOP.Columns["approvedByName"].Width = 120;
                /* Approval Date */
                dgvOP.Columns["approvalDate"].HeaderText = "Approval Date";
                dgvOP.Columns["approvalDate"].Width = 120;
                /* Status */
                dgvOP.Columns["status"].HeaderText = "Status";

                /* Auto size rows height to fit the full content */
                dgvOP.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                // Clear Default Selection
                dgvOP.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grpNew_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
