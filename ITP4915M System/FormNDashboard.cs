// ✅ FormNDashboard.cs - 加入 FormCS、FormFinance、FormLogistics、FormRD 支援並更新 OnLogout()
using System;
using System.Windows.Forms;
using ITP4915MSystem;

namespace ITP4915M_System
{
    public partial class FormNDashboard : FormTemplate
    {
        public FormNDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            Embed(new FormSales(), "Sales");
            Embed(new FormProd(), "Production");
            Embed(new FormHR(), "HR");
            Embed(new FormCS(), "Customer Service");
            Embed(new FormFinance(), "Finance");
            Embed(new FormLogistics(), "Logistics");
            Embed(new FormRD(), "R&D");
            tabMain.SelectedIndex = 0;
        }

        private void tabProcurement_Click(object sender, EventArgs e)
        {
            // 可實作 tabProcurement 功能
        }

        /// <summary>嵌入子表單至指定 TabPage</summary>
        private void Embed(Form childForm, string tabName)
        {
            var tp = FindTab(tabName);
            if (tp is null) return;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            tp.Controls.Add(childForm);
            childForm.Show();
        }

        /// <summary>按文字尋找 TabPage；找不到則傳 null</summary>
        private TabPage? FindTab(string name)
        {
            foreach (TabPage tp in tabMain.TabPages)
                if (tp.Text.Equals(name, StringComparison.Ordinal))
                    return tp;
            return null;
        }

        /// <summary>登出前清理嵌入子表單</summary>
        protected override void OnLogout()
        {
            foreach (TabPage tp in tabMain.TabPages)
            {
                foreach (Control ctrl in tp.Controls)
                {
                    if (ctrl is Form embeddedForm)
                        embeddedForm.Close();
                }
            }
        }
    }
}
