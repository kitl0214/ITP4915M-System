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
            if (disposing && components != null)
                components.Dispose();
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
            cmbDept.Location = new Point(713, 479);
            cmbDept.Name = "cmbDept";
            cmbDept.Size = new Size(368, 40);
            cmbDept.TabIndex = 0;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(694, 561);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(368, 39);
            txtUser.TabIndex = 1;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(694, 647);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(368, 39);
            txtPwd.TabIndex = 2;
            txtPwd.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(694, 739);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(167, 60);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(898, 739);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(167, 60);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(493, 483);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(142, 32);
            lblDept.TabIndex = 5;
            lblDept.Text = "Department";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(493, 568);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(121, 32);
            lblUser.TabIndex = 6;
            lblUser.Text = "Username";
            // 
            // lblPwd
            // 
            lblPwd.AutoSize = true;
            lblPwd.Location = new Point(493, 653);
            lblPwd.Name = "lblPwd";
            lblPwd.Size = new Size(111, 32);
            lblPwd.TabIndex = 7;
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
