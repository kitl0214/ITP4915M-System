// -----------------------------------------------------------------------------
// FormHR.Designer.cs – Human-Resources 佈局（移除本地 Logout 按鈕）
// -----------------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    /* 保持與邏輯檔相同的繼承結構 */
    partial class FormHR
    {
        private IContainer components = null;

        private DataGridView gvAccounts;
        private ComboBox cmbFilter;
        private ComboBox cmbNewDept;
        private TextBox txtNewUser;
        private TextBox txtNewPwd;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnRefresh;
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
            components = new Container();
            gvAccounts = new DataGridView();
            cmbFilter = new ComboBox();
            cmbNewDept = new ComboBox();
            txtNewUser = new TextBox();
            txtNewPwd = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            lblFilter = new Label();
            lblNewUser = new Label();
            lblNewPwd = new Label();
            lblNewDept = new Label();
            grpAdd = new GroupBox();

            ((ISupportInitialize)gvAccounts).BeginInit();
            grpAdd.SuspendLayout();
            SuspendLayout();

            /* ---------- gvAccounts ---------- */
            gvAccounts.AllowUserToAddRows = false;
            gvAccounts.AllowUserToDeleteRows = false;
            gvAccounts.ColumnHeadersHeight = 34;
            gvAccounts.Location = new Point(39, 92);
            gvAccounts.ReadOnly = true;
            gvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvAccounts.Size = new Size(786, 399);
            gvAccounts.CellClick += gvAccounts_CellClick;

            /* ---------- Filter ComboBox ---------- */
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Location = new Point(118, 34);
            cmbFilter.Size = new Size(218, 31);
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;

            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(39, 38);
            lblFilter.Text = "Filter";

            /* ---------- GroupBox: Add New ---------- */
            grpAdd.Text = "Add New Account";
            grpAdd.Location = new Point(39, 521);
            grpAdd.Size = new Size(786, 245);

            lblNewUser.AutoSize = true;
            lblNewUser.Location = new Point(31, 46);
            lblNewUser.Text = "Username";

            txtNewUser.Location = new Point(173, 41);
            txtNewUser.Size = new Size(233, 30);

            lblNewPwd.AutoSize = true;
            lblNewPwd.Location = new Point(31, 100);
            lblNewPwd.Text = "Password";

            txtNewPwd.Location = new Point(173, 95);
            txtNewPwd.Size = new Size(233, 30);
            txtNewPwd.UseSystemPasswordChar = true;

            lblNewDept.AutoSize = true;
            lblNewDept.Location = new Point(31, 153);
            lblNewDept.Text = "Department";

            cmbNewDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewDept.Location = new Point(173, 149);
            cmbNewDept.Size = new Size(233, 31);

            btnAdd.Location = new Point(471, 41);
            btnAdd.Size = new Size(126, 43);
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;

            btnDelete.Location = new Point(471, 95);
            btnDelete.Size = new Size(126, 43);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;

            btnRefresh.Location = new Point(471, 149);
            btnRefresh.Size = new Size(126, 43);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;

            grpAdd.Controls.AddRange(new Control[]
            {
                lblNewUser, txtNewUser,
                lblNewPwd,  txtNewPwd,
                lblNewDept, cmbNewDept,
                btnAdd, btnDelete, btnRefresh
            });

            /* ---------- FormHR ---------- */
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 874);
            Controls.AddRange(new Control[]
            {
                lblFilter, cmbFilter, gvAccounts, grpAdd
                // btnLogout 已由 FormTemplate 提供，這裡不再加入
            });
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HR Dashboard";
            Load += FormHR_Load;

            ((ISupportInitialize)gvAccounts).EndInit();
            grpAdd.ResumeLayout(false);
            grpAdd.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
