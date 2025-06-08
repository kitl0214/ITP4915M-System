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
            lblInfo.AutoSize = false;
            lblInfo.Location = new Point(20, 20);
            lblInfo.Size = new Size(360, 220);
            lblInfo.Font = new Font("Consolas", 10);
            lblInfo.TextAlign = ContentAlignment.TopLeft;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(80, 260);
            btnOK.Size = new Size(90, 34);
            btnOK.Text = "OK";
            btnOK.DialogResult = DialogResult.OK;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(220, 260);
            btnCancel.Size = new Size(90, 34);
            btnCancel.Text = "Cancel";
            btnCancel.DialogResult = DialogResult.Cancel;
            // 
            // OrderSummaryDialog
            // 
            AcceptButton = btnOK;
            CancelButton = btnCancel;
            AutoScaleDimensions = new SizeF(8F, 15F);
            ClientSize = new Size(400, 320);
            Controls.AddRange(new Control[] { lblInfo, btnOK, btnCancel });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;              // ★ 置於最前
            ShowInTaskbar = false;
            Text = "Order Summary";
            ResumeLayout(false);
        }
        #endregion
    }
}
