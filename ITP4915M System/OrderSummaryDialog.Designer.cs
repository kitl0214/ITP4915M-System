// OrderSummaryDialog.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class OrderSummaryDialog
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblInfo;
        private Button btnOK, btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            lblInfo = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Consolas", 10F);
            lblInfo.Location = new Point(20, 20);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(360, 220);
            lblInfo.TabIndex = 0;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(159, 499);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(90, 34);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(319, 499);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 34);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            // 
            // OrderSummaryDialog
            // 
            AcceptButton = btnOK;
            CancelButton = btnCancel;
            ClientSize = new Size(686, 609);
            Controls.Add(lblInfo);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrderSummaryDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Order Summary";
            TopMost = true;
            ResumeLayout(false);
        }
        #endregion
    }
}
