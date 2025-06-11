namespace ITP4915MSystem
{
    partial class FormHR
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView gvAccounts;
        private ComboBox cmbFilter;
        private ComboBox cmbNewDept;
        private TextBox txtNewUser;
        private TextBox txtNewPwd;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnLogout;
        private Label lblFilter;
        private Label lblNewUser;
        private Label lblNewPwd;
        private Label lblNewDept;
        private GroupBox grpAdd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            gvAccounts = new DataGridView();
            cmbFilter = new ComboBox();
            cmbNewDept = new ComboBox();
            txtNewUser = new TextBox();
            txtNewPwd = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnLogout = new Button();
            lblFilter = new Label();
            lblNewUser = new Label();
            lblNewPwd = new Label();
            lblNewDept = new Label();
            grpAdd = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)gvAccounts).BeginInit();
            grpAdd.SuspendLayout();
            SuspendLayout();
            // 
            // gvAccounts
            // 
            gvAccounts.AllowUserToAddRows = false;
            gvAccounts.AllowUserToDeleteRows = false;
            gvAccounts.ColumnHeadersHeight = 34;
            gvAccounts.Location = new Point(39, 92);
            gvAccounts.Margin = new Padding(5, 5, 5, 5);
            gvAccounts.Name = "gvAccounts";
            gvAccounts.ReadOnly = true;
            gvAccounts.RowHeadersWidth = 62;
            gvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvAccounts.Size = new Size(786, 399);
            gvAccounts.TabIndex = 2;
            gvAccounts.CellClick += gvAccounts_CellClick;
      
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Location = new Point(118, 34);
            cmbFilter.Margin = new Padding(5, 5, 5, 5);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(218, 31);
            cmbFilter.TabIndex = 1;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // cmbNewDept
            // 
            cmbNewDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewDept.Location = new Point(173, 149);
            cmbNewDept.Margin = new Padding(5, 5, 5, 5);
            cmbNewDept.Name = "cmbNewDept";
            cmbNewDept.Size = new Size(233, 31);
            cmbNewDept.TabIndex = 5;
            // 
            // txtNewUser
            // 
            txtNewUser.Location = new Point(173, 41);
            txtNewUser.Margin = new Padding(5, 5, 5, 5);
            txtNewUser.Name = "txtNewUser";
            txtNewUser.Size = new Size(233, 30);
            txtNewUser.TabIndex = 1;
            // 
            // txtNewPwd
            // 
            txtNewPwd.Location = new Point(173, 95);
            txtNewPwd.Margin = new Padding(5, 5, 5, 5);
            txtNewPwd.Name = "txtNewPwd";
            txtNewPwd.Size = new Size(233, 30);
            txtNewPwd.TabIndex = 3;
            txtNewPwd.UseSystemPasswordChar = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(471, 41);
            btnAdd.Margin = new Padding(5, 5, 5, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(126, 43);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(471, 95);
            btnDelete.Margin = new Padding(5, 5, 5, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(126, 43);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(471, 149);
            btnRefresh.Margin = new Padding(5, 5, 5, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(126, 43);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(691, 805);
            btnLogout.Margin = new Padding(5, 5, 5, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(134, 43);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(39, 38);
            lblFilter.Margin = new Padding(5, 0, 5, 0);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(53, 23);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Filter";
            // 
            // lblNewUser
            // 
            lblNewUser.AutoSize = true;
            lblNewUser.Location = new Point(31, 46);
            lblNewUser.Margin = new Padding(5, 0, 5, 0);
            lblNewUser.Name = "lblNewUser";
            lblNewUser.Size = new Size(96, 23);
            lblNewUser.TabIndex = 0;
            lblNewUser.Text = "Username";
            // 
            // lblNewPwd
            // 
            lblNewPwd.AutoSize = true;
            lblNewPwd.Location = new Point(31, 100);
            lblNewPwd.Margin = new Padding(5, 0, 5, 0);
            lblNewPwd.Name = "lblNewPwd";
            lblNewPwd.Size = new Size(90, 23);
            lblNewPwd.TabIndex = 2;
            lblNewPwd.Text = "Password";
            // 
            // lblNewDept
            // 
            lblNewDept.AutoSize = true;
            lblNewDept.Location = new Point(31, 153);
            lblNewDept.Margin = new Padding(5, 0, 5, 0);
            lblNewDept.Name = "lblNewDept";
            lblNewDept.Size = new Size(114, 23);
            lblNewDept.TabIndex = 4;
            lblNewDept.Text = "Department";
            // 
            // grpAdd
            // 
            grpAdd.Controls.Add(lblNewUser);
            grpAdd.Controls.Add(txtNewUser);
            grpAdd.Controls.Add(lblNewPwd);
            grpAdd.Controls.Add(txtNewPwd);
            grpAdd.Controls.Add(lblNewDept);
            grpAdd.Controls.Add(cmbNewDept);
            grpAdd.Controls.Add(btnAdd);
            grpAdd.Controls.Add(btnDelete);
            grpAdd.Controls.Add(btnRefresh);
            grpAdd.Location = new Point(39, 521);
            grpAdd.Margin = new Padding(5, 5, 5, 5);
            grpAdd.Name = "grpAdd";
            grpAdd.Padding = new Padding(5, 5, 5, 5);
            grpAdd.Size = new Size(786, 245);
            grpAdd.TabIndex = 3;
            grpAdd.TabStop = false;
            grpAdd.Text = "Add New Account";
            // 
            // FormHR
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 874);
            Controls.Add(lblFilter);
            Controls.Add(cmbFilter);
            Controls.Add(gvAccounts);
            Controls.Add(grpAdd);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 5, 5, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormHR";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HR Dashboard";
            Load += FormHR_Load;
            ((System.ComponentModel.ISupportInitialize)gvAccounts).EndInit();
            grpAdd.ResumeLayout(false);
            grpAdd.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
