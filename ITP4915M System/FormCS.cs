using ITP4915MSystem;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ITP4915M_System
{
    public partial class FormCS : Form
    {
        public FormCS()
        {
            InitializeComponent();
        }

        /* ---------- life-cycle ---------- */
        private void FormCS_Load(object sender, EventArgs e)
        {
            LoadOrders();
            LoadFollowups();
        }

        /* ---------- orders ---------- */
        private void btnLoadOrders_Click(object sender, EventArgs e) => LoadOrders();

        private void LoadOrders()
        {
            DataTable dt = Database.GetAllOrders();  // already exists in your project
            dgvOrders.DataSource = dt;
        }

        /* ---------- follow-ups ---------- */
        private void btnAddFollowup_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select one order first.");
                return;
            }

            string oid = dgvOrders.SelectedRows[0].Cells["oid"].Value.ToString();

            using var dlg = new FollowupDialog(oid);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Database.AddFollowup(oid, dlg.SelectedAction, dlg.CustomerComment);
                LoadFollowups();
            }
        }

        private void LoadFollowups()
        {
            DataTable dt = Database.GetAllFollowups();
            dgvFollowups.DataSource = dt;

            const string colName = "Action";
            if (!dgvFollowups.Columns.Contains(colName))
            {
                var btn = new DataGridViewButtonColumn
                {
                    Name = colName,
                    HeaderText = "Complete",
                    Text = "Done",
                    UseColumnTextForButtonValue = true,
                    Width = 70
                };
                dgvFollowups.Columns.Add(btn);
            }
        }

        private void dgvFollowups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvFollowups.Columns[e.ColumnIndex].Name != "Action") return;

            int fid = Convert.ToInt32(dgvFollowups.Rows[e.RowIndex].Cells["fid"].Value);
            Database.SetFollowupCompleted(fid);
            LoadFollowups();
        }

        private void dgvFollowups_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvFollowups.Rows[e.RowIndex];
            string status = row.Cells["status"].Value?.ToString() ?? "";
            if (status == "PENDING")
                row.DefaultCellStyle.BackColor = Color.Gold;
            else if (status == "COMPLETED")
                row.DefaultCellStyle.BackColor = Color.LightGreen;
        }
    }
}
