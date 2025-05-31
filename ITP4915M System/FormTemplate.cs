using System;
using System.Windows.Forms;

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
            Owner?.Show();   // 回到登入
            Close();
        }
    }
}
