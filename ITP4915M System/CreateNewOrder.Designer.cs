using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class CreateNewOrder
    {
        private System.ComponentModel.IContainer components = null;

        // UI controls
        private Label Custnlb, prodlb, quanlb, uninlb, duedlb;
        private TextBox txtCust, txtProd;
        private RadioButton gord, ctrd;
        private CheckBox apcb;
        private NumericUpDown quannud, uninud;
        private DateTimePicker edcdtp;
        private Button creatbt, cleanbt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            Custnlb = new Label();
            prodlb = new Label();
            quanlb = new Label();
            uninlb = new Label();
            duedlb = new Label();
            txtCust = new TextBox();
            txtProd = new TextBox();
            gord = new RadioButton();
            ctrd = new RadioButton();
            apcb = new CheckBox();
            quannud = new NumericUpDown();
            uninud = new NumericUpDown();
            edcdtp = new DateTimePicker();
            creatbt = new Button();
            cleanbt = new Button();
            ((System.ComponentModel.ISupportInitialize)quannud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uninud).BeginInit();
            SuspendLayout();
            // 
            // Custnlb
            // 
            Custnlb.AutoSize = true;
            Custnlb.Location = new Point(35, 53);
            Custnlb.Name = "Custnlb";
            Custnlb.Size = new Size(159, 23);
            Custnlb.Text = "Customer Name :";
            // 
            // prodlb
            // 
            prodlb.AutoSize = true;
            prodlb.Location = new Point(35, 115);
            prodlb.Name = "prodlb";
            prodlb.Size = new Size(143, 23);
            prodlb.Text = "Product Name :";
            // 
            // quanlb
            // 
            quanlb.AutoSize = true;
            quanlb.Location = new Point(38, 232);
            quanlb.Name = "quanlb";
            quanlb.Size = new Size(85, 23);
            quanlb.Text = "Quantity";
            // 
            // uninlb
            // 
            uninlb.AutoSize = true;
            uninlb.Location = new Point(38, 299);
            uninlb.Name = "uninlb";
            uninlb.Size = new Size(102, 23);
            uninlb.Text = "Unit Price :";
            // 
            // duedlb
            // 
            duedlb.AutoSize = true;
            duedlb.Location = new Point(38, 445);
            duedlb.Name = "duedlb";
            duedlb.Size = new Size(197, 23);
            duedlb.Text = "Estimated completion";
            // 
            // txtCust
            // 
            txtCust.Location = new Point(236, 53);
            txtCust.Name = "txtCust";
            txtCust.Size = new Size(256, 30);
            // 
            // txtProd
            // 
            txtProd.Location = new Point(236, 115);
            txtProd.Name = "txtProd";
            txtProd.Size = new Size(247, 30);
            txtProd.TextChanged += txtProd_TextChanged;
            // 
            // gord
            // 
            gord.AutoSize = true;
            gord.Checked = true;
            gord.Location = new Point(35, 169);
            gord.Name = "gord";
            gord.Size = new Size(156, 27);
            gord.TabStop = true;
            gord.Text = "General Order";
            // 
            // ctrd
            // 
            ctrd.AutoSize = true;
            ctrd.Location = new Point(236, 169);
            ctrd.Name = "ctrd";
            ctrd.Size = new Size(156, 27);
            ctrd.Text = "Custom Order";
            // 
            // apcb
            // 
            apcb.AutoSize = true;
            apcb.Location = new Point(38, 382);
            apcb.Name = "apcb";
            apcb.Size = new Size(267, 27);
            apcb.Text = "Additional Packaging (+$1)";
            // 
            // quannud
            // 
            quannud.Location = new Point(192, 232);
            quannud.Maximum = 100000;
            quannud.Minimum = 1;
            quannud.Name = "quannud";
            quannud.Size = new Size(165, 30);
            quannud.Value = 1;
            // 
            // uninud
            // 
            uninud.Location = new Point(192, 299);
            uninud.Maximum = 1000000;
            uninud.Minimum = 1;
            uninud.Name = "uninud";
            uninud.Size = new Size(165, 30);
            uninud.Value = 1;
            // 
            // edcdtp
            // 
            edcdtp.Format = DateTimePickerFormat.Short;
            edcdtp.Location = new Point(38, 519);
            edcdtp.Name = "edcdtp";
            edcdtp.Size = new Size(378, 30);
            // 
            // creatbt
            // 
            creatbt.Location = new Point(24, 606);
            creatbt.Name = "creatbt";
            creatbt.Size = new Size(154, 52);
            creatbt.Text = "Create";
            creatbt.Click += creatbt_Click;
            // 
            // cleanbt
            // 
            cleanbt.Location = new Point(222, 606);
            cleanbt.Name = "cleanbt";
            cleanbt.Size = new Size(154, 52);
            cleanbt.Text = "Clear";
            cleanbt.Click += cleanbt_Click;
            // 
            // CreateNewOrder
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 698);
            Controls.AddRange(new Control[]
            {
                Custnlb, txtCust,
                prodlb,  txtProd,
                gord, ctrd,
                quanlb, quannud,
                uninlb, uninud,
                apcb,
                duedlb, edcdtp,
                creatbt, cleanbt
            });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateNewOrder";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create New Order";
            TopMost = true;
            Load += CreateNewOrder_Load;
            ((System.ComponentModel.ISupportInitialize)quannud).EndInit();
            ((System.ComponentModel.ISupportInitialize)uninud).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
