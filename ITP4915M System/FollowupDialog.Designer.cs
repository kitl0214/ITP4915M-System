using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class FollowupDialog
    {
        private System.ComponentModel.IContainer components = null;
        private CheckBox chkRefund;
        private CheckBox chkDiscount;
        private TextBox txtComment;
        private Button btnOK;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            chkRefund = new CheckBox();
            chkDiscount = new CheckBox();
            txtComment = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // chkRefund
            // 
            chkRefund.Location = new Point(30, 30);
            chkRefund.Size = new Size(120, 24);
            chkRefund.Text = "Refund";
            // 
            // chkDiscount
            // 
            chkDiscount.Location = new Point(160, 30);
            chkDiscount.Size = new Size(120, 24);
            chkDiscount.Text = "Discount";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(30, 70);
            txtComment.Size = new Size(340, 90);
            txtComment.Multiline = true;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(200, 180);
            btnOK.Size = new Size(80, 30);
            btnOK.Text = "Confirm";
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(290, 180);
            btnCancel.Size = new Size(80, 30);
            btnCancel.Text = "Cancel";
            btnCancel.DialogResult = DialogResult.Cancel;
            // 
            // FollowupDialog
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 260);
            Controls.AddRange(new Control[] { chkRefund, chkDiscount, txtComment, btnOK, btnCancel });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
        }
    }
}
