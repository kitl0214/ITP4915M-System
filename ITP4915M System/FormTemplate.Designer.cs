namespace ITP4915MSystem
{
    partial class FormTemplate
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLogout = new Button();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(640, 34);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(126, 38);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // FormTemplate
            // 
            ClientSize = new Size(801, 603);
            Controls.Add(btnLogout);
            Name = "FormTemplate";
            Text = "Main Page";
            Load += FormTemplate_Load;
            ResumeLayout(false);
        }
    }
}
