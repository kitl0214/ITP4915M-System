using System;
using System.Data;
using System.Windows.Forms;

namespace ITP4915MSystem
{
    public partial class FormSales : FormTemplate
    {
        public FormSales()
        {
            InitializeComponent();
        }

        private void FormSales_Load(object sender, EventArgs e)
        {
            cmbStatusFilter.SelectedIndex = 0; // All
            LoadOrders();
        }

        private void LoadOrders()
        {
            string status = cmbStatusFilter.Text == "All" ? "%" : cmbStatusFilter.Text;
            string keyword = txtSearch.Text.Trim();

            dvOrders.DataSource = Database.GetOrders(status, keyword);
            dvOrders.ClearSelection();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadOrders();

        private void btnSearch_Click(object sender, EventArgs e) => LoadOrders();

        private void btnNew_Click(object sender, EventArgs e)
        {
            using var dlg = new OrderDialog();      // 自定義對話框
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Database.InsertOrder(dlg.OrderModel);
                LoadOrders();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedOid(out int oid)) return;

            using var dlg = new OrderDialog(oid);   // 帶入現有資料
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Database.UpdateOrder(dlg.OrderModel);
                LoadOrders();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedOid(out int oid)) return;
            Database.UpdateOrderStatus(oid, "CANCELLED");
            LoadOrders();
        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedOid(out int oid)) return;
            Database.UpdateOrderStatus(oid, "SHIPPED");
            Database.InsertDeliveryNote(oid, DateTime.Today);
            LoadOrders();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            CsvHelper.ExportDataGridView(dvOrders); // 你可寫一個靜態工具類
        }

        private bool TryGetSelectedOid(out int oid)
        {
            oid = 0;
            if (dvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order first.");
                return false;
            }
            oid = (int)dvOrders.SelectedRows[0].Cells["oid"].Value;
            return true;
        }
    }
}
