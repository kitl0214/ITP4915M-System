// ✅ LoginForm.cs - 修改後的完整版本（不再使用 ShowDialog）
using System;
using System.Windows.Forms;
using ITP4915M_System;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            cmbDept.Items.AddRange(new object[]
            {
                "Root",
                "HR",
                "Sales",
                "RD",
                "Production",
                "Logistics"
            });
            cmbDept.SelectedIndex = 0;
            cmbDept.Sorted = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string dept = cmbDept.Text.Trim();
            string usr = txtUser.Text.Trim();
            string pwd = txtPwd.Text;

            if (!Database.ValidateUser(dept, usr, pwd, out var msg))
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 根據部門開啟新表單
            Form next = dept switch
            {
                "Root" => new FormNDashboard(),
                "HR" => new FormHR(),
                "Sales" => new FormSales(),
                "RD" => new FormRD(),
                "Production" => new FormProd(),
                "Logistics" => new FormLogistics(),
                _ => new FormTemplate()
            };

            next.Show();   // ✅ 開新頁
            this.Hide();   // ✅ 隱藏登入頁（不再使用 ShowDialog）
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPwd.Clear();
            cmbDept.SelectedIndex = 0;
            txtUser.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e) { }
    }
}

// ✅ 登出邏輯範例（任何頁面使用）
// 呼叫此方法以完全登出並回登入畫面：
public static class AppHelper
{
    public static void LogoutToLogin()
    {
        LoginForm login = new LoginForm();
        login.Show();

        foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
        {
            if (form != login)
                form.Close();
        }
    }
}

// 使用方式：btnLogout_Click 中只需呼叫：
// AppHelper.LogoutToLogin();