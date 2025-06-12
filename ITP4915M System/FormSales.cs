using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class FormSales : FormTemplate
    {
        public FormSales()
        {
            InitializeComponent();
        }

        /* -------------------- life-cycle -------------------- */
        private void FormSales_Load(object sender, EventArgs e)
        {
            LoadOrders();
            AddActionButton();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        /* -------------------- data loading -------------------- */
        private void LoadOrders()
        {
            // reset grid to avoid duplicated button column when re-loading
            dgvOrders.DataSource = null;
            dgvOrders.Columns.Clear();

            DataTable dt = Database.GetAllOrders();   // cid already resolved to customer name
            dgvOrders.DataSource = dt;

            // friendly headers – check column existence
            void H(string col, string text)
            {
                if (dgvOrders.Columns.Contains(col))
                    dgvOrders.Columns[col].HeaderText = text;
            }

            H("oid", "Order ID");
            H("customer", "Customer");
            H("product", "Product");
            H("unit", "Unit");
            H("qty", "Quantity");
            H("order_type", "Order Type");
            H("extra_pkg", "Extra Pkg");
            H("due_date", "Due Date");
            H("total", "Total");
            H("created_at", "Created");
        }

        /* -------------------- UI helpers -------------------- */
        private void AddActionButton()
        {
            if (dgvOrders.Columns["Action"] != null) return;

            var btnCol = new DataGridViewButtonColumn
            {
                Name = "Action",
                HeaderText = "Action",
                Text = "View",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvOrders.Columns.Add(btnCol);
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvOrders.Columns[e.ColumnIndex].Name == "Action")
            {
                string oid = dgvOrders.Rows[e.RowIndex].Cells["oid"].Value?.ToString();
                if (string.IsNullOrEmpty(oid)) return;

                // Example: open detail form
                // using var detail = new OrderDetailForm(oid);
                // detail.ShowDialog(this);
            }
        }

        private void creatobt_Click(object sender, EventArgs e)
        {
            var newForm = new CreateNewOrder();
            newForm.Show();
        }
    }
}
