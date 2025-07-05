// -----------------------------------------------------------------------------
// FormTemplate.Designer.cs – 只放 Logout 按鈕
// -----------------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class FormTemplate
    {
        private IContainer components = null;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new Container();
            btnLogout = new Button();

            /* ---------- btnLogout ---------- */
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Size = new Size(110, 40);
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;

            /* ---------- FormTemplate ---------- */
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(btnLogout);
            MinimumSize = new Size(600, 400);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Page";

            /* 初步排版 */
            btnLogout.Left = ClientSize.Width - btnLogout.Width - MarginRight;
            btnLogout.Top = 12;
        }
        #endregion
    }
}
