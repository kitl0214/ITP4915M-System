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

        /* Edit Status Method */
        private void DgvOP_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // After edit the status column, update the database and remove the row if status is "Completed"
            if (dgvOP.Columns[e.ColumnIndex].Name == "status")
            {
                string specID = dgvOP.Rows[e.RowIndex].Cells["specID"].Value?.ToString();
                string newStatus = dgvOP.Rows[e.RowIndex].Cells["status"].Value?.ToString();

                if (!string.IsNullOrEmpty(specID) && !string.IsNullOrEmpty(newStatus))
                {
                    try
                    {
                        
                        Database.UpdateRAndDStatus(specID, newStatus);
                        
                        if (newStatus == "Completed")
                        {
                            dgvOP.Rows.RemoveAt(e.RowIndex);
                        }
                        else
                        {
                            
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating status: {ex.Message}", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        LoadData();
                    }
                }
            }
        }

        private void LoadData()
        {
            try
            {
                
                dgvOP.DataSource = Database.GetRDOrders();
                
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
                dgvOP.Columns["deadline"].HeaderText = "Deadline";
                dgvOP.Columns["deadline"].Width = 80;
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
