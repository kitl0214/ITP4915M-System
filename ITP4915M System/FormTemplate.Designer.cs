namespace ITP4915MSystem
{
    partial class FormTemplate
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLogout = new Button();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(663, 44);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(120, 35);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // FormTemplate
            // 
            ClientSize = new Size(837, 588);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormTemplate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blank Page";
            ResumeLayout(false);
        }
    }
}
