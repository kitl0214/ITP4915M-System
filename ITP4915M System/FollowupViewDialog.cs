// -----------------------------------------------------------------------------
// FollowupViewDialog.cs – event handler separated for designer compatibility
// -----------------------------------------------------------------------------
using System.Data;
using System.Windows.Forms;

namespace ITP4915M_System
{
    public partial class FollowupViewDialog : Form
    {
        public FollowupViewDialog(string orderId, bool refund, bool discount, string comment)
        {
            InitializeComponent();

            Text = $"Follow-Up for Order {orderId}";
            dgvFlags.DataSource = BuildFlagTable(refund, discount);
            txtComment.Text = comment ?? "";
        }

        // ★ Designer-safe事件方法
        private void btnClose_Click(object sender, System.EventArgs e)
            => DialogResult = DialogResult.OK;

        private static DataTable BuildFlagTable(bool refund, bool discount)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Item");
            dt.Columns.Add("Flag");
            dt.Rows.Add("Refund", refund ? "Y" : "");
            dt.Rows.Add("Discount", discount ? "Y" : "");
            return dt;
        }
    }
}
