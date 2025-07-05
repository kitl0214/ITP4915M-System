// -----------------------------------------------------------------------------
// FormNDashboard.cs – Main dashboard, holds multiple functional tabs
// -----------------------------------------------------------------------------
using System;
using System.Linq;
using System.Windows.Forms;

namespace ITP4915M_System
{
    /* 改為繼承 FormTemplate，享有 Logout 與 User Info 標籤 */
    public partial class FormNDashboard : FormTemplate
    {
        private readonly string _user;
        private readonly string _dept;

        /* ── 執行期建構子：一定要傳 user / dept ── */
        public FormNDashboard(string user, string dept) : base(user, dept)
        {
            _user = user;
            _dept = dept;
            InitializeComponent();
        }

        /// <summary>只給 Visual Studio 設計工具使用；執行期請勿呼叫</summary>
        protected FormNDashboard() : base()
        {
            InitializeComponent();
        }

        /* 若不想在 Dashboard 顯示使用者資訊，設為 false */
        protected override bool EnableUserInfo => true;

        /* ───────────────────────────────────────── */
        /* life-cycle                                */
        /* ───────────────────────────────────────── */
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            /* ---- 已改造（能吃 user / dept）的表單 ---- */
            Embed(new FormHR(_user, _dept), "HR");
            Embed(new FormCS(_user, _dept), "Customer Service");
            Embed(new FormSales(_user, _dept), "Sales");


            /* ---- 尚未改造的表單，暫用無參數版 ---- */
            Embed(new FormReport(), "Report");
            
            Embed(new FormRD(), "R&D");
            Embed(new FormProd(), "Production");
            Embed(new FormFinance(), "Finance");
            Embed(new FormLogistics(), "Logistics");

            tabMain.SelectedIndex = 0;
        }

        /* ───────────────────────────────────────── */
        /* helper                                    */
        /* ───────────────────────────────────────── */
        /// <summary>
        /// 把子表單嵌入對應 TabPage，標題以 TabPage.Text 比對
        /// </summary>
        private void Embed(Form child, string tabText)
        {
            TabPage? tp = tabMain.TabPages
                                 .Cast<TabPage>()
                                 .FirstOrDefault(p => p.Text == tabText);
            if (tp == null) return;

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            tp.Controls.Add(child);
            child.Show();
        }
    }
}
