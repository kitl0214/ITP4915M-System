// -----------------------------------------------------------------------------
// FollowupViewDialog.Designer.cs – DataGridView(Refund/Discount) + Comment
// -----------------------------------------------------------------------------
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace ITP4915M_System
{
    partial class FollowupViewDialog
    {
        private IContainer components = null;
        private DataGridView dgvFlags;
        private Label lblComment;
        private TextBox txtComment;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            dgvFlags = new DataGridView();
            lblComment = new Label();
            txtComment = new TextBox();
            btnClose = new Button();

            ((ISupportInitialize)dgvFlags).BeginInit();
            SuspendLayout();
            // 
            // dgvFlags
            // 
            dgvFlags.Location = new Point(30, 30);
            dgvFlags.Size = new Size(240, 80);
            dgvFlags.ReadOnly = true;
            dgvFlags.AllowUserToAddRows = false;
            dgvFlags.AllowUserToDeleteRows = false;
            dgvFlags.AllowUserToResizeRows = false;
            dgvFlags.RowHeadersVisible = false;
            dgvFlags.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // lblComment
            // 
            lblComment.Text = "Customer Comment:";
            lblComment.Location = new Point(30, 125);
            lblComment.AutoSize = true;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(30, 150);
            txtComment.Size = new Size(360, 140);
            txtComment.Multiline = true;
            txtComment.ReadOnly = true;
            txtComment.ScrollBars = ScrollBars.Vertical;
            // 
            // btnClose
            // 
            btnClose.Text = "OK";
            btnClose.Size = new Size(90, 30);
            btnClose.Location = new Point(300, 305);
            btnClose.Click += btnClose_Click;      // ★ 用方法取代 Lambda
            // 
            // FollowupViewDialog
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 350);
            Controls.AddRange(new Control[] { dgvFlags, lblComment, txtComment, btnClose });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Follow-Up Details";

            ((ISupportInitialize)dgvFlags).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
