using System;
using System.Linq;
using System.Windows.Forms;
using ITP4915M_System;

namespace ITP4915MSystem
{
    public partial class FormTemplate : Form
    {
        public FormTemplate()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 執行登出清理（給子類用）
            OnLogout();

            // 收集當前所有開啟中的表單（包含自己）
            var formsToClose = Application.OpenForms.Cast<Form>().ToList();

            // 建立新的 LoginForm
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            // 關閉所有舊表單
            foreach (var form in formsToClose)
            {
                if (form != loginForm)
                    form.Close();
            }
        }


        /// <summary>提供給子類覆寫的登出前邏輯</summary>
        protected virtual void OnLogout() { }

        private void FormTemplate_Load(object sender, EventArgs e)
        {

        }
        public static class AppHelper
        {
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