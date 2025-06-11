namespace ITP4915MSystem
{
    partial class FormHR
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.DataGridView gvAccounts;
        private System.Windows.Forms.GroupBox grpNew;
        private System.Windows.Forms.TextBox txtNewUser;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.ComboBox cmbNewDept;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblNU;
        private System.Windows.Forms.Label lblNP;
        private System.Windows.Forms.Label lblND;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbFilter = new ComboBox();
            gvAccounts = new DataGridView();
            btnDelete = new Button();
            btnRefresh = new Button();
            grpNew = new GroupBox();
            lblND = new Label();
            lblNP = new Label();
            lblNU = new Label();
            btnAdd = new Button();
            cmbNewDept = new ComboBox();
            txtNewPwd = new TextBox();
            txtNewUser = new TextBox();
            lblFilter = new Label();
            lobt = new Button();
            ((System.ComponentModel.ISupportInitialize)gvAccounts).BeginInit();
            grpNew.SuspendLayout();
            SuspendLayout();
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Items.AddRange(new object[] { "All", "IT", "HR", "Sales" });
            cmbFilter.Location = new Point(175, 21);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(236, 23);
            cmbFilter.TabIndex = 6;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // gvAccounts
            // 
            gvAccounts.AllowUserToAddRows = false;
            gvAccounts.AllowUserToDeleteRows = false;
            gvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvAccounts.ColumnHeadersHeight = 34;
            gvAccounts.Location = new Point(38, 82);
            gvAccounts.MultiSelect = false;
            gvAccounts.Name = "gvAccounts";
            gvAccounts.ReadOnly = true;
            gvAccounts.RowHeadersWidth = 62;
            gvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvAccounts.Size = new Size(452, 246);
            gvAccounts.TabIndex = 5;
            gvAccounts.CellClick += gvAccounts_CellClick;
            gvAccounts.CellContentClick += gvAccounts_CellContentClick;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(579, 126);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 30);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete Selected";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(590, 54);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // grpNew
            // 
            grpNew.Controls.Add(lblND);
            grpNew.Controls.Add(lblNP);
            grpNew.Controls.Add(lblNU);
            grpNew.Controls.Add(btnAdd);
            grpNew.Controls.Add(cmbNewDept);
            grpNew.Controls.Add(txtNewPwd);
            grpNew.Controls.Add(txtNewUser);
            grpNew.Location = new Point(38, 353);
            grpNew.Name = "grpNew";
            grpNew.Size = new Size(649, 171);
            grpNew.TabIndex = 1;
            grpNew.TabStop = false;
            grpNew.Text = "Add New Account";
            // 
            // lblND
            // 
            lblND.AutoSize = true;
            lblND.Location = new Point(18, 105);
            lblND.Name = "lblND";
            lblND.Size = new Size(75, 15);
            lblND.TabIndex = 0;
            lblND.Text = "Department";
            // 
            // lblNP
            // 
            lblNP.AutoSize = true;
            lblNP.Location = new Point(18, 70);
            lblNP.Name = "lblNP";
            lblNP.Size = new Size(60, 15);
            lblNP.TabIndex = 1;
            lblNP.Text = "Password";
            // 
            // lblNU
            // 
            lblNU.AutoSize = true;
            lblNU.Location = new Point(18, 30);
            lblNU.Name = "lblNU";
            lblNU.Size = new Size(64, 15);
            lblNU.TabIndex = 2;
            lblNU.Text = "Username";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(432, 27);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 30);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbNewDept
            // 
            cmbNewDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewDept.Items.AddRange(new object[] { "IT", "HR", "Sales" });
            cmbNewDept.Location = new Point(137, 102);
            cmbNewDept.Name = "cmbNewDept";
            cmbNewDept.Size = new Size(151, 23);
            cmbNewDept.TabIndex = 4;
            // 
            // txtNewPwd
            // 
            txtNewPwd.Location = new Point(137, 63);
            txtNewPwd.Name = "txtNewPwd";
            txtNewPwd.Size = new Size(151, 23);
            txtNewPwd.TabIndex = 5;
            txtNewPwd.UseSystemPasswordChar = true;
            // 
            // txtNewUser
            // 
            txtNewUser.Location = new Point(137, 23);
            txtNewUser.Name = "txtNewUser";
            txtNewUser.Size = new Size(151, 23);
            txtNewUser.TabIndex = 6;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(20, 21);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(75, 15);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Department";
            // 
            // lobt
            // 
            lobt.Location = new Point(565, 193);
            lobt.Name = "lobt";
            lobt.Size = new Size(140, 34);
            lobt.TabIndex = 7;
            lobt.Text = "Logout";
            lobt.UseVisualStyleBackColor = true;
            lobt.Click += lobt_Click;
            // 
            // FormHR
            // 
            ClientSize = new Size(923, 547);
            Controls.Add(lobt);
            Controls.Add(lblFilter);
            Controls.Add(grpNew);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(gvAccounts);
            Controls.Add(cmbFilter);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormHR";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HR Management";
            Load += FormHR_Load;
            ((System.ComponentModel.ISupportInitialize)gvAccounts).EndInit();
            grpNew.ResumeLayout(false);
            grpNew.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button lobt;
    }
}
