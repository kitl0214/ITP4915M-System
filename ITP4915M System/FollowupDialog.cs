// -----------------------------------------------------------------------------
// FollowupDialog.cs  –  Add / Edit customer follow-up (refund / discount / both)
// -----------------------------------------------------------------------------
using System;
using System.Windows.Forms;

namespace ITP4915M_System
{
    public partial class FollowupDialog : Form
    {
        public string SelectedAction { get; private set; } = "NONE";
        public string CustomerComment => txtComment.Text.Trim();

        /*─── 新增模式 ───*/
        public FollowupDialog(string oid)
        {
            InitializeComponent();
            Text = $"Follow-Up for Order {oid}";
        }

        /*─── 編輯模式 ───*/
        public FollowupDialog(string oid, string currentAction, string currentComment)
            : this(oid)   // 呼叫新增模式建構子以載入基本 UI
        {
            txtComment.Text = currentComment ?? "";

            switch (currentAction?.ToUpperInvariant())
            {
                case "REFUND":
                    chkRefund.Checked = true;
                    chkDiscount.Checked = false;
                    break;
                case "DISCOUNT":
                    chkRefund.Checked = false;
                    chkDiscount.Checked = true;
                    break;
                case "BOTH":
                    chkRefund.Checked = true;
                    chkDiscount.Checked = true;
                    break;
                default:  // "NONE" 或 null
                    chkRefund.Checked = false;
                    chkDiscount.Checked = false;
                    break;
            }
        }

        /*─── OK 按鈕 ───*/
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

        private void FollowupDialog_Load(object sender, EventArgs e) { }
    }
}
