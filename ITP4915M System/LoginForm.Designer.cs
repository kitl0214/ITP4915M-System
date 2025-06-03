using System.Drawing;
using System.Windows.Forms;

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
            cmbDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDept.Location = new Point(371, 129);
            cmbDept.Margin = new Padding(5);
            cmbDept.Name = "cmbDept";
            cmbDept.Size = new Size(235, 31);
            cmbDept.TabIndex = 7;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(387, 195);
            txtUser.Margin = new Padding(5);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Username";
            txtUser.Size = new Size(235, 30);
            txtUser.TabIndex = 6;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(387, 264);
            txtPwd.Margin = new Padding(5);
            txtPwd.Name = "txtPwd";
            txtPwd.PlaceholderText = "Password";
            txtPwd.Size = new Size(235, 30);
            txtPwd.TabIndex = 5;
            txtPwd.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(175, 341);
            btnLogin.Margin = new Padding(5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(148, 49);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(387, 341);
            btnClear.Margin = new Padding(5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(148, 49);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(175, 132);
            lblDept.Margin = new Padding(5, 0, 5, 0);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(114, 23);
            lblDept.TabIndex = 2;
            lblDept.Text = "Department";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(175, 201);
            lblUser.Margin = new Padding(5, 0, 5, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(96, 23);
            lblUser.TabIndex = 1;
            lblUser.Text = "Username";
            // 
            // lblPwd
            // 
            lblPwd.AutoSize = true;
            lblPwd.Location = new Point(175, 270);
            lblPwd.Margin = new Padding(5, 0, 5, 0);
            lblPwd.Name = "lblPwd";
            lblPwd.Size = new Size(90, 23);
            lblPwd.TabIndex = 0;
            lblPwd.Text = "Password";
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 736);
            Controls.Add(lblPwd);
            Controls.Add(lblUser);
            Controls.Add(lblDept);
            Controls.Add(btnClear);
            Controls.Add(btnLogin);
            Controls.Add(txtPwd);
            Controls.Add(txtUser);
            Controls.Add(cmbDept);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Department Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
