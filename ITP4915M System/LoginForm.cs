using System;
using System.Windows.Forms;
using ITP4915M_System;

namespace ITP4915MSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // ① 讓下拉選單同時包含 HR 與 Sales
            cmbDept.Items.Clear();
            cmbDept.Items.AddRange(new object[] { "HR", "Sales", "RD", "Production", "Logistics" /* …其他 */ });
            cmbDept.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var dept = cmbDept.Text.Trim();
            var usr = txtUser.Text.Trim();
            var pwd = txtPwd.Text;

            if (!Database.ValidateUser(dept, usr, pwd, out var msg))
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Hide();   // 登入成功 → 隱藏自己

            // ② 依部門決定要開啟的表單
            Form next = dept switch
            {
                "HR" => new FormHR(),
                "Sales" => new FormSales(),   // ← 新增\
                "RD" => new FormRD(),
                "Production" => new FormProd(),
                "logistics" => new FormLogistics(),
                _ => new FormTemplate() // 其餘部門用空白模板
            };

            next.Owner = this;   // 讓子頁 Logout 時能呼叫 Owner.Show()
            next.ShowDialog();

            Show();              // 回到登入畫面
            txtPwd.Clear();      // 清密碼欄
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPwd.Clear();
            cmbDept.SelectedIndex = 0;
            txtUser.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
