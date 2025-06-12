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
            cmbDept.Location = new Point(713, 479);
            cmbDept.Margin = new Padding(6, 7, 6, 7);
            cmbDept.Name = "cmbDept";
            cmbDept.Size = new Size(368, 40);
            cmbDept.TabIndex = 1;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(694, 561);
            txtUser.Margin = new Padding(6, 7, 6, 7);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(368, 39);
            txtUser.TabIndex = 1;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(694, 647);
            txtPwd.Margin = new Padding(6, 7, 6, 7);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(368, 39);
            txtPwd.TabIndex = 2;
            txtPwd.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(694, 739);
            btnLogin.Margin = new Padding(6, 7, 6, 7);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(167, 60);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(898, 739);
            btnClear.Margin = new Padding(6, 7, 6, 7);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(167, 60);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(493, 483);
            lblDept.Margin = new Padding(6, 0, 6, 0);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(142, 32);
            lblDept.TabIndex = 0;
            lblDept.Text = "Department";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(493, 568);
            lblUser.Margin = new Padding(6, 0, 6, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(121, 32);
            lblUser.TabIndex = 2;
            lblUser.Text = "Username";
            // 
            // lblPwd
            // 
            lblPwd.AutoSize = true;
            lblPwd.Location = new Point(493, 653);
            lblPwd.Margin = new Padding(6, 0, 6, 0);
            lblPwd.Name = "lblPwd";
            lblPwd.Size = new Size(111, 32);
            lblPwd.TabIndex = 4;
            lblPwd.Text = "Password";
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 849);
            Controls.Add(lblDept);
            Controls.Add(cmbDept);
            Controls.Add(lblUser);
            Controls.Add(txtUser);
            Controls.Add(lblPwd);
            Controls.Add(txtPwd);
            Controls.Add(btnLogin);
            Controls.Add(btnClear);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6, 7, 6, 7);
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
