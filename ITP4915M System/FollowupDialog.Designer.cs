// -----------------------------------------------------------------------------
// FollowupDialog.Designer.cs  –  UI layout for Follow-Up dialog
// -----------------------------------------------------------------------------
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
        private Label lblComment;

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
            lblComment = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // chkRefund
            // 
            chkRefund.AutoSize = true;
            chkRefund.Location = new Point(25, 25);
            chkRefund.Name = "chkRefund";
            chkRefund.Size = new Size(103, 29);
            chkRefund.Text = "Refund";
            // 
            // chkDiscount
            // 
            chkDiscount.AutoSize = true;
            chkDiscount.Location = new Point(150, 25);
            chkDiscount.Name = "chkDiscount";
            chkDiscount.Size = new Size(111, 29);
            chkDiscount.Text = "Discount";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Location = new Point(25, 70);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(168, 25);
            lblComment.Text = "Customer Comment:";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(25, 100);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(350, 120);
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(200, 240);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(80, 30);
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(295, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 30);
            btnCancel.Text = "Cancel";
            // 
            // FollowupDialog
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 290);
            Controls.AddRange(new Control[] { btnCancel, btnOK, txtComment, lblComment, chkDiscount, chkRefund });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FollowupDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Follow-Up";
            Load += FollowupDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
