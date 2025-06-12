using System;
using System.Linq;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /*───────────────────────────────────────────────*/
        /* UI EVENTS                                      */
        /*───────────────────────────────────────────────*/

        private void LoginForm_Load(object sender, EventArgs e)
        {
            RefreshDepartmentList();   // dynamic dept list
            cmbDept.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string dept = cmbDept.Text.Trim();
            string usr = txtUser.Text.Trim();
            string pwd = txtPwd.Text;

            if (!Database.ValidateUser(dept, usr, pwd, out var msg))
            {
                MessageBox.Show(msg, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form next = ResolveNextForm(dept);
            next.Show();
            Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPwd.Clear();
            cmbDept.SelectedIndex = 0;
            txtUser.Focus();
        }

        /*───────────────────────────────────────────────*/
        /* HELPER METHODS                                 */
        /*───────────────────────────────────────────────*/

        public void RefreshDepartmentList()
        {
            var depts = Database.GetDepartments().ToList();

            cmbDept.Items.Clear();
            cmbDept.Items.Add("Root");             // super-user
            cmbDept.Items.AddRange(depts.ToArray());
        }

        private Form ResolveNextForm(string dept)
        {
            return dept switch
            {
                "Root" => new FormNDashboard(), // ⬅ 若名稱不同請自行替換
                "HR" => new FormHR(),
                "Sales" => new FormSales(),
                "RD" => new FormRD(),
                "Production" => new FormProd(),
                "Finance" => new FormFinance(),
                "Customer Service" => new FormCS(),
                "Logistics" => new FormLogistics(),
                _ => new FormTemplate()     // fallback
            };
        }
    }
}
