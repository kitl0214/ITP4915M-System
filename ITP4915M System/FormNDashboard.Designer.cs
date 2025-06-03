using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using Org.BouncyCastle.Asn1.Crmf;
using static System.Net.Mime.MediaTypeNames;

namespace ITP4915M_System
{
    partial class FormNDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabMain;
        private TabPage tabSales;
        private TabPage tabProduction;
        private TabPage tabProcurement;
        private TabPage tabHR;

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
            tabProcurement = new TabPage();
            tabHR = new TabPage();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Dock = DockStyle.Fill;
            tabMain.TabPages.AddRange(new TabPage[]
            {
                tabSales,
                tabProduction,
                tabProcurement,
                tabHR
            });
            tabMain.Location = new Point(0, 0);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(960, 600);
            // 
            // tabSales
            // 
            tabSales.Text = "Sales";
            // 
            // tabProduction
            // 
            tabProduction.Text = "Production";
            // 
            // tabProcurement
            // 
            tabProcurement.Text = "Procurement";
            // 
            // tabHR
            // 
            tabHR.Text = "HR";
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 600);
            Controls.Add(tabMain);
            Name = "FormDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += FormDashboard_Load;
            ResumeLayout(false);
        }
        #endregion
    }
}
