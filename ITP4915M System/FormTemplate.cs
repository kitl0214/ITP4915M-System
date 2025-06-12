using System;
using System.Linq;
using System.Windows.Forms;

namespace ITP4915M_System
{
    public partial class FormTemplate : Form
    {
        public FormTemplate()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 讓子類有機會在真正登出前做清理
            OnLogout();

            // 收集目前所有開啟中的表單（包含自己）
            var formsToClose = Application.OpenForms.Cast<Form>().ToList();

            // 開啟新的 LoginForm
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            // 關閉舊表單
            foreach (var form in formsToClose)
            {
                if (form != loginForm)
                    form.Close();
            }
        }

        /// <summary>
        /// 讓子類在登出時可覆寫額外清理邏輯
        /// </summary>
        protected virtual void OnLogout() { }

        private void FormTemplate_Load(object sender, EventArgs e)
        {
            // 其他共用初始化可放這裡
        }

        /*─────────────────────────────────────────*/
        /* 靜態工具 (可被任何表單呼叫以快速回登入頁)    */
        /*─────────────────────────────────────────*/
        public static class AppHelper
        {
            /// <summary>
            /// 關閉所有現有表單並重新顯示 LoginForm
            /// </summary>
            public static void LogoutToLogin()
            {
                var oldForms = Application.OpenForms.Cast<Form>().ToList();
                LoginForm login = new LoginForm();
                login.Show();

                foreach (var f in oldForms)
                {
                    if (f != login)
                        f.Close();
                }
            }
        }
    }
}
