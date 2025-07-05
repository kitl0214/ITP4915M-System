using System;
using System.Linq;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class LoginForm : Form
    {
        public LoginForm() => InitializeComponent();

        /*───────────────────────────────────────────────*/
        /* UI EVENTS                                      */
        /*───────────────────────────────────────────────*/

        private void LoginForm_Load(object sender, EventArgs e)
        {
            RefreshDepartmentList();
            cmbDept.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string dept = cmbDept.Text.Trim();
            string usr = txtUser.Text.Trim();
            string pwd = txtPwd.Text;

            /* 1️⃣ 驗證帳密 */
            if (!Database.ValidateUser(dept, usr, pwd, out var msg))
            {
                MessageBox.Show(msg, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /* 2️⃣ 開啟對應主視窗 */
            Form next = ResolveNextForm(dept, usr);
            next.Show();

            /* 3️⃣ 清除欄位，方便下次登入 */
            ClearCredentials();

            /* 4️⃣ 隱藏自己 */
            Hide();
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearCredentials();

        /*───────────────────────────────────────────────*/
        /* HELPER METHODS                                 */
        /*───────────────────────────────────────────────*/

        private void ClearCredentials()
        {
            txtUser.Clear();
            txtPwd.Clear();
            if (cmbDept.Items.Count > 0) cmbDept.SelectedIndex = 0;
            txtUser.Focus();
        }

        public void RefreshDepartmentList()
        {
            var depts = Database.GetDepartments().ToList();

            cmbDept.Items.Clear();
            cmbDept.Items.Add("Root");            // 超級管理員
            cmbDept.Items.AddRange(depts.ToArray());
        }

        /// <summary>
        /// 根據部門回傳下一個 Form（全部帶 user / dept）
        /// </summary>
        private Form ResolveNextForm(string dept, string user)
        {
            return dept switch
            {
                "Root" => new FormNDashboard(user, dept),
                "HR" => new FormHR(user, dept),
                "Sales" => new FormSales(user, dept),
                "RD" => new FormRD(user, dept),
                "Production" => new FormProd(user, dept),
                "Finance" => new FormFinance(user, dept),
                "Customer Service" => new FormCS(user, dept),
                "Logistics" => new FormLogistics(user, dept),
                _ => new FormTemplate(user, dept)   // fallback
            };
        }
    }
}
