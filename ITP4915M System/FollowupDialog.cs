using System;
using System.Windows.Forms;

namespace ITP4915M_System
{
    public partial class FollowupDialog : Form
    {
        public string SelectedAction { get; private set; } = "NONE";
        public string CustomerComment => txtComment.Text.Trim();

        public FollowupDialog(string oid)
        {
            InitializeComponent();
            Text = $"Follow-Up for Order {oid}";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool r = chkRefund.Checked;
            bool d = chkDiscount.Checked;

            SelectedAction = (r, d) switch
            {
                (true, true) => "BOTH",
                (true, false) => "REFUND",
                (false, true) => "DISCOUNT",
                _ => "NONE"
            };
        }
    }
}
