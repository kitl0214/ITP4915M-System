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
            // 將各部門表單嵌入對應 TabPage
            Embed(new FormSales(), "Sales");
            Embed(new FormProd(), "Production");
           
            Embed(new FormHR(), "HR");

            tabMain.SelectedIndex = 0;    // 預設顯示 Sales
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
    }
}
