using System;
using System.Windows.Forms;

namespace ITP4915MSystem
{
    public partial class FormHR : Form
    {
        private string _selectedUser = string.Empty;

        public FormHR()
        {
            InitializeComponent();
            cmbFilter.SelectedIndex = 0;
            cmbNewDept.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            gvAccounts.DataSource = Database.GetAccounts(cmbFilter.Text);
            gvAccounts.ClearSelection();
            _selectedUser = string.Empty;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadData();

        private void gvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var cellValue = gvAccounts.Rows[e.RowIndex].Cells["username"].Value;
            _selectedUser = cellValue?.ToString() ?? string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var user = txtNewUser.Text.Trim();
            var pwd = txtNewPwd.Text;
            var dept = cmbNewDept.Text;

            if (user == "" || pwd == "")
            {
                MessageBox.Show("Username / Password required");
                return;
            }

            try
            {
                Database.AddAccount(dept, user, pwd);
                LoadData();
                txtNewUser.Clear();
                txtNewPwd.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUser == "")
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
                LoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Owner?.Show();                  // 顯示登入頁
            Close();                        // 關閉 HR
        }
    }
}
