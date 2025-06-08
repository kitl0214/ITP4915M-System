// ✅ FormNDashboard.Designer.cs - 修復錯誤，移除無效事件綁定，確保編譯通過
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

            tabMain.SuspendLayout();
            SuspendLayout();

            // tabMain
            tabMain.Controls.Add(tabSales);
            tabMain.Controls.Add(tabProduction);
            tabMain.Controls.Add(tabHR);
            tabMain.Controls.Add(tabCS);
            tabMain.Controls.Add(tabFinance);
            tabMain.Controls.Add(tabLogistics);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Location = new Point(0, 0);
            tabMain.Margin = new Padding(5);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1509, 920);
            tabMain.TabIndex = 1;

            // tabSales
            tabSales.Location = new Point(4, 32);
            tabSales.Margin = new Padding(5);
            tabSales.Name = "tabSales";
            tabSales.Size = new Size(1501, 884);
            tabSales.TabIndex = 0;
            tabSales.Text = "Sales";

            // tabProduction
            tabProduction.Location = new Point(4, 32);
            tabProduction.Margin = new Padding(5);
            tabProduction.Name = "tabProduction";
            tabProduction.Size = new Size(1501, 884);
            tabProduction.TabIndex = 1;
            tabProduction.Text = "Production";

            // tabHR
            tabHR.Location = new Point(4, 32);
            tabHR.Margin = new Padding(5);
            tabHR.Name = "tabHR";
            tabHR.Size = new Size(1501, 884);
            tabHR.TabIndex = 2;
            tabHR.Text = "HR";

            // tabCS
            tabCS.Location = new Point(4, 32);
            tabCS.Margin = new Padding(5);
            tabCS.Name = "tabCS";
            tabCS.Size = new Size(1501, 884);
            tabCS.TabIndex = 3;
            tabCS.Text = "Customer Service";

            // tabFinance
            tabFinance.Location = new Point(4, 32);
            tabFinance.Margin = new Padding(5);
            tabFinance.Name = "tabFinance";
            tabFinance.Size = new Size(1501, 884);
            tabFinance.TabIndex = 4;
            tabFinance.Text = "Finance";

            // tabLogistics
            tabLogistics.Location = new Point(4, 32);
            tabLogistics.Margin = new Padding(5);
            tabLogistics.Name = "tabLogistics";
            tabLogistics.Size = new Size(1501, 884);
            tabLogistics.TabIndex = 5;
            tabLogistics.Text = "Logistics";

            // FormNDashboard
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