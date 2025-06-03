using System;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // 部門清單集中在建構子維護
            cmbDept.Items.AddRange(new object[]
            {
                "Root",
                "HR",
                "Sales",
                "RD",
                "Production",
                "Logistics"
            });
            cmbDept.SelectedIndex = 0;  // 預設 Root
            cmbDept.Sorted = false;    // 保持自訂順序
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

            Hide();   // 登入成功 → 隱藏自己

            Form next = dept switch
            {
                "Root" => new FormNDashboard(),   // 查看全部頁面
                "HR" => new FormHR(),
                "Sales" => new FormSales(),
                "RD" => new FormRD(),
                "Production" => new FormProd(),
                "Logistics" => new FormLogistics(),
                _ => new FormTemplate()
            };

            next.Owner = this;   // 子頁 Logout 時可呼叫 Owner.Show()
            next.ShowDialog();

            Show();              // 返回登入
            txtPwd.Clear();      // 清除密碼框
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPwd.Clear();
            cmbDept.SelectedIndex = 0;
            txtUser.Focus();
        }

        // 空方法—Designer 綁定用；日後可放初始化程式
        private void LoginForm_Load(object sender, EventArgs e) { }
    }
}
