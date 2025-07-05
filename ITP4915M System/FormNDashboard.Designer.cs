// -----------------------------------------------------------------------------
// FormNDashboard.Designer.cs – layout (TabControl + 8 TabPages, no "Home")
// -----------------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    /* 類別宣告與 .cs 檔保持一致 */
    partial class FormNDashboard
    {
        private IContainer components = null;
        private TabControl tabMain;
        private TabPage tabSales;
        private TabPage tabProduction;
        private TabPage tabHR;
        private TabPage tabCS;
        private TabPage tabFinance;
        private TabPage tabLogistics;
        private TabPage tabRD;
        private TabPage tabReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new Container();
            tabMain = new TabControl();
            tabSales = new TabPage();
            tabProduction = new TabPage();
            tabHR = new TabPage();
            tabCS = new TabPage();
            tabFinance = new TabPage();
            tabLogistics = new TabPage();
            tabRD = new TabPage();
            tabReport = new TabPage();

            tabMain.SuspendLayout();
            SuspendLayout();

            /* ---------- TabControl ---------- */
            tabMain.Controls.AddRange(new Control[]
            {
                tabSales, tabProduction, tabHR, tabCS,
                tabFinance, tabLogistics, tabRD, tabReport
            });
            tabMain.Dock = DockStyle.Fill;
            tabMain.Location = new Point(0, 0);
            tabMain.Margin = new Padding(5);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1500, 900);

            /* ---------- 各分頁 ---------- */
            tabSales.Text = "Sales";
            tabProduction.Text = "Production";
            tabHR.Text = "HR";
            tabCS.Text = "Customer Service";
            tabFinance.Text = "Finance";
            tabLogistics.Text = "Logistics";
            tabRD.Text = "R&D";
            tabReport.Text = "Report";

            foreach (TabPage tp in tabMain.TabPages)
                tp.Padding = new Padding(5);

            /* ---------- Form ---------- */
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 900);
            Controls.Add(tabMain);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(900, 600);
            Name = "FormNDashboard";
            Text = "HR Dashboard";
            Load += FormDashboard_Load;

            tabMain.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion
    }
}
