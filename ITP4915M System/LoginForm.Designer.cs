namespace ITP4915MSystem
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPwd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbDept = new ComboBox();
            txtUser = new TextBox();
            txtPwd = new TextBox();
            btnLogin = new Button();
            btnClear = new Button();
            lblDept = new Label();
            lblUser = new Label();
            lblPwd = new Label();
            SuspendLayout();
            // 
            // cmbDept
            // 
            cmbDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDept.Items.AddRange(new object[] { "HR", "Sales" });
            cmbDept.Location = new Point(355, 251);
            cmbDept.Name = "cmbDept";
            cmbDept.Size = new Size(151, 31);
            cmbDept.TabIndex = 7;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(346, 296);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Username";
            txtUser.Size = new Size(151, 30);
            txtUser.TabIndex = 6;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(346, 339);
            txtPwd.Name = "txtPwd";
            txtPwd.PlaceholderText = "Password";
            txtPwd.Size = new Size(151, 30);
            txtPwd.TabIndex = 5;
            txtPwd.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(219, 380);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(355, 380);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 30);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(219, 259);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(114, 23);
            lblDept.TabIndex = 2;
            lblDept.Text = "Department";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(219, 299);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(96, 23);
            lblUser.TabIndex = 1;
            lblUser.Text = "Username";
            // 
            // lblPwd
            // 
            lblPwd.AutoSize = true;
            lblPwd.Location = new Point(219, 339);
            lblPwd.Name = "lblPwd";
            lblPwd.Size = new Size(90, 23);
            lblPwd.TabIndex = 0;
            lblPwd.Text = "Password";
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AllowDrop = true;
            ClientSize = new Size(742, 519);
            Controls.Add(lblPwd);
            Controls.Add(lblUser);
            Controls.Add(lblDept);
            Controls.Add(btnClear);
            Controls.Add(btnLogin);
            Controls.Add(txtPwd);
            Controls.Add(txtUser);
            Controls.Add(cmbDept);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Department Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
