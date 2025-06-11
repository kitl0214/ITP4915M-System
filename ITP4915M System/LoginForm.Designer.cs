namespace ITP4915M_System
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox cmbDept;
        private TextBox txtUser;
        private TextBox txtPwd;
        private Button btnLogin;
        private Button btnClear;
        private Label lblDept;
        private Label lblUser;
        private Label lblPwd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
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
            cmbDept.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDept.Location = new Point(603, 344);
            cmbDept.Margin = new Padding(5);
            cmbDept.Name = "cmbDept";
            cmbDept.Size = new Size(312, 31);
            cmbDept.TabIndex = 1;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(587, 403);
            txtUser.Margin = new Padding(5);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(312, 30);
            txtUser.TabIndex = 1;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(587, 465);
            txtPwd.Margin = new Padding(5);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(312, 30);
            txtPwd.TabIndex = 2;
            txtPwd.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(587, 531);
            btnLogin.Margin = new Padding(5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(141, 43);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(760, 531);
            btnClear.Margin = new Padding(5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(141, 43);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(417, 347);
            lblDept.Margin = new Padding(5, 0, 5, 0);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(114, 23);
            lblDept.TabIndex = 0;
            lblDept.Text = "Department";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(417, 408);
            lblUser.Margin = new Padding(5, 0, 5, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(96, 23);
            lblUser.TabIndex = 2;
            lblUser.Text = "Username";
            // 
            // lblPwd
            // 
            lblPwd.AutoSize = true;
            lblPwd.Location = new Point(417, 469);
            lblPwd.Margin = new Padding(5, 0, 5, 0);
            lblPwd.Name = "lblPwd";
            lblPwd.Size = new Size(90, 23);
            lblPwd.TabIndex = 4;
            lblPwd.Text = "Password";
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 690);
            Controls.Add(lblDept);
            Controls.Add(cmbDept);
            Controls.Add(lblUser);
            Controls.Add(txtUser);
            Controls.Add(lblPwd);
            Controls.Add(txtPwd);
            Controls.Add(btnLogin);
            Controls.Add(btnClear);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
