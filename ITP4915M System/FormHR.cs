// -----------------------------------------------------------------------------
// FormHR.cs – Human-Resources Dashboard
//   • 右上角顯示 User / Dept（來自 FormTemplate）
//   • 人員帳號：篩選 / 新增 / 刪除 / 即時刷新
//   • 登出按鈕由 FormTemplate 提供；如需額外清理，可覆寫 OnLogout()
// -----------------------------------------------------------------------------
using ITP4915MSystem;          // Database.*
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ITP4915M_System
{
    public partial class FormHR : FormTemplate
    {
        protected override bool EnableUserInfo => true;   // 顯示登入資訊

        /*─────────────── 建構子 ───────────────*/
        public FormHR(string user, string dept) : base(user, dept)
        {
            InitializeComponent();
            RefreshDepartmentLists();
            LoadData();
        }

        /// <remarks>僅供設計工具使用；執行期請勿呼叫</remarks>
        protected FormHR() : base()
        {
            InitializeComponent();
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                RefreshDepartmentLists();
                LoadData();
            }
        }

        /*─────────────── 常數 / 欄位 ───────────────*/
        private static readonly string[] MasterDepts =
        {
            "Root","HR","Sales","RD","Production",
            "Finance","Customer Service","Logistics"
        };
        private string _selectedUser = string.Empty;

        /*─────────────── Data Binding ───────────────*/
        private void RefreshDepartmentLists()
        {
            var dbDepts = Database.GetDepartments().ToList();
            var allDepts = MasterDepts.Union(dbDepts, StringComparer.OrdinalIgnoreCase)
                                      .OrderBy(d => d).ToList();

            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("All");
            cmbFilter.Items.AddRange(allDepts.ToArray());
            if (cmbFilter.SelectedIndex < 0) cmbFilter.SelectedIndex = 0;

            cmbNewDept.Items.Clear();
            cmbNewDept.Items.AddRange(allDepts.ToArray());
            if (cmbNewDept.SelectedIndex < 0) cmbNewDept.SelectedIndex = 0;
        }

        private void LoadData()
        {
            gvAccounts.DataSource = Database.GetAccounts(cmbFilter.Text);
            gvAccounts.ClearSelection();
            _selectedUser = string.Empty;
        }

        /*─────────────── UI 事件 ───────────────*/
        private void FormHR_Load(object sender, EventArgs e) { }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadData();

        private void gvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedUser = gvAccounts.Rows[e.RowIndex]
                                       .Cells["username"].Value?.ToString() ?? "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = txtNewUser.Text.Trim();
            string pwd = txtNewPwd.Text;
            string dept = cmbNewDept.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Username / Password required"); return;
            }

            try
            {
                Database.AddAccount(user, pwd, dept);
                AfterAccountChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedUser))
            {
                MessageBox.Show("Select a row first."); return;
            }

            if (MessageBox.Show($"Delete {_selectedUser} ?",
                                "Confirm",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Database.DeleteAccount(_selectedUser);
                AfterAccountChanged();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        /*─────────────── Logout 追加清理 (可選) ───────────────*/
        protected override void OnLogout()
        {
            // 例：把當前選取清掉；或釋放資源
            _selectedUser = string.Empty;
            base.OnLogout();   // 保留父類其他處理
        }

        /*─────────────── Helper ───────────────*/
        private void AfterAccountChanged()
        {
            RefreshDepartmentLists();
            LoadData();

            foreach (LoginForm lf in Application.OpenForms.OfType<LoginForm>())
                lf.RefreshDepartmentList();

            txtNewUser.Clear();
            txtNewPwd.Clear();
            txtNewUser.Focus();
        }
    }
}
