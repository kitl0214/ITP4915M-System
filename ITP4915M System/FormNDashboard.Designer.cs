// ✅ FormNDashboard.Designer.cs ─ 已加入 Report 分頁
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class FormNDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabMain;
        private TabPage tabSales;
        private TabPage tabProduction;
        private TabPage tabHR;
        private TabPage tabCS;
        private TabPage tabFinance;
        private TabPage tabLogistics;
        private TabPage tabRD;
        private TabPage tabReport;          // ★ 新增

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer
        private void InitializeComponent()
        {
            tabMain = new TabControl();
            tabSales = new TabPage();
            tabProduction = new TabPage();
            tabHR = new TabPage();
            tabCS = new TabPage();
            tabFinance = new TabPage();
            tabLogistics = new TabPage();
            tabRD = new TabPage();
            tabReport = new TabPage();   // ★ 新增

            tabMain.SuspendLayout();
            SuspendLayout();

            /* ---------- TabControl ---------- */
            tabMain.Controls.Add(tabSales);
            tabMain.Controls.Add(tabProduction);
            tabMain.Controls.Add(tabHR);
            tabMain.Controls.Add(tabCS);
            tabMain.Controls.Add(tabFinance);
            tabMain.Controls.Add(tabLogistics);
            tabMain.Controls.Add(tabRD);
            tabMain.Controls.Add(tabReport);                      // ★ 新增
            tabMain.Dock = DockStyle.Fill;
            tabMain.Location = new Point(0, 0);
            tabMain.Margin = new Padding(5);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1509, 920);
            tabMain.TabIndex = 1;

            /* ---------- 個別分頁 ---------- */
            tabSales.Text = "Sales";
            tabProduction.Text = "Production";
            tabHR.Text = "HR";
            tabCS.Text = "Customer Service";
            tabFinance.Text = "Finance";
            tabLogistics.Text = "Logistics";
            tabRD.Text = "R&D";
            tabReport.Text = "Report";          // ★ 新增

            // 統一尺寸與位置（以下為範例，保持一致即可）
            foreach (TabPage tp in tabMain.TabPages)
            {
                tp.Location = new Point(4, 32);
                tp.Margin = new Padding(5);
                tp.Size = new Size(1501, 884);
            }

            /* ---------- Form ---------- */
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1509, 920);
            Controls.Add(tabMain);
            Margin = new Padding(5);
            Name = "FormNDashboard";
            Text = "Dashboard";
            Load += FormDashboard_Load;
            Controls.SetChildIndex(tabMain, 0);

            tabMain.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion
    }
}
