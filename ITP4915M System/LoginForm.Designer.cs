﻿using System.Drawing;
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
            label1 = new Label();
            SuspendLayout();
            // 
            // cmbDept
            // 
            cmbDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDept.Location = new Point(608, 255);
            cmbDept.Margin = new Padding(3, 2, 3, 2);
            cmbDept.Name = "cmbDept";
            cmbDept.Size = new Size(312, 31);
            cmbDept.TabIndex = 0;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(606, 311);
            txtUser.Margin = new Padding(3, 2, 3, 2);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(312, 30);
            txtUser.TabIndex = 1;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(606, 373);
            txtPwd.Margin = new Padding(3, 2, 3, 2);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(312, 30);
            txtPwd.TabIndex = 2;
            txtPwd.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(606, 439);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(141, 43);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(779, 439);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(141, 43);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(436, 255);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(114, 23);
            lblDept.TabIndex = 5;
            lblDept.Text = "Department";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(436, 316);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(96, 23);
            lblUser.TabIndex = 6;
            lblUser.Text = "Username";
            // 
            // lblPwd
            // 
            lblPwd.AutoSize = true;
            lblPwd.Location = new Point(436, 377);
            lblPwd.Name = "lblPwd";
            lblPwd.Size = new Size(90, 23);
            lblPwd.TabIndex = 7;
            lblPwd.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(414, 144);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 8;
            label1.Text = "Welcome";
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 610);
            Controls.Add(label1);
            Controls.Add(lblDept);
            Controls.Add(cmbDept);
            Controls.Add(lblUser);
            Controls.Add(txtUser);
            Controls.Add(lblPwd);
            Controls.Add(txtPwd);
            Controls.Add(btnLogin);
            Controls.Add(btnClear);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
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

        private Label label1;
    }
}
