// -----------------------------------------------------------------------------
// FormTemplate.cs – 基底表單
//   • 右上：User / Dept 標籤（EnableUserInfo）
//   • 右上：Logout 按鈕（EnableLogout）
//   • Layout 自動對齊：Logout 在 Label 左側 10px，距窗框 20px
//   • 共用 LogoutToLogin() 便於外部呼叫
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ITP4915M_System
{
    public partial class FormTemplate : Form
    {
        /* ── 常數：排版用 ─────────────────────── */
        private const int MarginRight = 20;   // 與右框距離
        private const int GapBetween = 10;   // Logout 與 Label 間隔

        /* ── 欄位 ───────────────────────────── */
        private readonly string _user;
        private readonly string _dept;
        private Label? lblUserInfo;

        /* ── 子表單可覆寫屬性 ────────────────── */
        protected virtual bool EnableUserInfo => false;
        protected virtual bool EnableLogout => true;

        /* ── 建構子 ─────────────────────────── */
        public FormTemplate(string user = "Guest", string dept = "N/A")
        {
            _user = user;
            _dept = dept;

            InitializeComponent();              // 產生 btnLogout

            if (EnableUserInfo) InitUserLabel();
            btnLogout.Visible = EnableLogout;
        }

        /* ── 初始化 User 標籤 ────────────────── */
        private void InitUserLabel()
        {
            lblUserInfo = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Text = $"User: {_user}  ({_dept})",
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            Controls.Add(lblUserInfo);
            RealignHeaderControls();
        }

        /* ── 共用排版 ────────────────────────── */
        private void RealignHeaderControls()
        {
            int rightEdge = Width - MarginRight;

            if (EnableUserInfo && lblUserInfo != null)
            {
                lblUserInfo.Left = rightEdge - lblUserInfo.Width;
                lblUserInfo.Top = 18;
                rightEdge = lblUserInfo.Left - GapBetween;
            }

            if (EnableLogout && btnLogout.Visible)
            {
                btnLogout.Left = rightEdge - btnLogout.Width;
                btnLogout.Top = 12;
            }
        }

        /* ── 事件：Shown / Resize ─────────────── */
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            RealignHeaderControls();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RealignHeaderControls();
        }

        /* ── Logout 按鈕 ─────────────────────── */
        protected virtual void OnLogout() { }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            OnLogout();
            LogoutToLogin();
        }

        /* ── 靜態：回登入表單 ────────────────── */
        public static void LogoutToLogin()
        {
            var login = Application.OpenForms.OfType<LoginForm>().FirstOrDefault()
                        ?? new LoginForm();

            login.Show();
            login.WindowState = FormWindowState.Normal;
            login.BringToFront();

            foreach (Form f in Application.OpenForms.Cast<Form>().ToList())
                if (f != login) f.Close();
        }

        /* 相容舊程式碼 */
        public static class AppHelper
        {
            public static void LogoutToLogin() => FormTemplate.LogoutToLogin();
        }
    }
}
