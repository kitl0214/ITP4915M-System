using System;
using System.Linq;
using System.Windows.Forms;
using ITP4915M_System;
using ITP4915MSystem;
using static ITP4915MSystem.FormTemplate;

namespace ITP4915MSystem
{
    public partial class FormHR : Form
    {
        /*─────────────────────────────────────────*/
        /* MASTER DEPARTMENT LIST                   */
        /*─────────────────────────────────────────*/
        private static readonly string[] MasterDepts =
        {
            "Root",
            "HR",
            "Sales",
            "RD",
            "Production",
            "Finance",
            "Customer Service",
            "Logistics"
        };

        private string _selectedUser = string.Empty;

        public FormHR()
        {
            InitializeComponent();
            RefreshDepartmentLists();
            LoadData();
        }

        /*─────────────────────────────────────────*/
        /* DATA BINDING                            */
        /*─────────────────────────────────────────*/
        private void RefreshDepartmentLists()
        {
            var dbDepts = Database.GetDepartments().ToList();
            var allDepts = MasterDepts
                           .Union(dbDepts, StringComparer.OrdinalIgnoreCase)
                           .OrderBy(d => d)
                           .ToList();

            // Filter ComboBox (include "All")
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("All");
            cmbFilter.Items.AddRange(allDepts.ToArray());
            if (cmbFilter.SelectedIndex < 0) cmbFilter.SelectedIndex = 0;

            // New-Dept ComboBox (no "All")
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

        /*─────────────────────────────────────────*/
        /* UI EVENTS                               */
        /*─────────────────────────────────────────*/
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
            => LoadData();

        private void gvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedUser = gvAccounts.Rows[e.RowIndex]
                                         .Cells["username"].Value?.ToString() ?? string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = txtNewUser.Text.Trim();
            string pwd = txtNewPwd.Text;
            string dept = cmbNewDept.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Username / Password required");
                return;
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
                MessageBox.Show("Select a row first.");
                return;
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

        private void btnLogout_Click(object sender, EventArgs e)
            => AppHelper.LogoutToLogin();

        /*─────────────────────────────────────────*/
        /* HELPER                                  */
        /*─────────────────────────────────────────*/
        private void AfterAccountChanged()
        {
            RefreshDepartmentLists();
            LoadData();

            // Notify every opened LoginForm to refresh its department list
            foreach (LoginForm lf in Application.OpenForms.OfType<LoginForm>())
                lf.RefreshDepartmentList();

            txtNewUser.Clear();
            txtNewPwd.Clear();
            txtNewUser.Focus();
        }

        private void FormHR_Load(object sender, EventArgs e)
        {

        }


    }
}
