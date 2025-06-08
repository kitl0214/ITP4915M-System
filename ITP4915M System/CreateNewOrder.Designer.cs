// CreateNewOrder.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System
{
    partial class CreateNewOrder
    {
        private System.ComponentModel.IContainer components = null;

        // UI 控制項宣告
        private Label Custnlb, prodlb, quanld, uninlb, ecdlb;
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
            quanld = new Label();
            uninlb = new Label();
            ecdlb = new Label();
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
            Custnlb.Location = new Point(38, 95);
            Custnlb.Margin = new Padding(4, 0, 4, 0);
            Custnlb.Name = "Custnlb";
            Custnlb.Size = new Size(159, 23);
            Custnlb.TabIndex = 0;
            Custnlb.Text = "Customer Name :";
            // 
            // prodlb
            // 
            prodlb.AutoSize = true;
            prodlb.Location = new Point(38, 179);
            prodlb.Margin = new Padding(4, 0, 4, 0);
            prodlb.Name = "prodlb";
            prodlb.Size = new Size(143, 23);
            prodlb.TabIndex = 2;
            prodlb.Text = "Product Name :";
            // 
            // quanld
            // 
            quanld.AutoSize = true;
            quanld.Location = new Point(38, 366);
            quanld.Margin = new Padding(4, 0, 4, 0);
            quanld.Name = "quanld";
            quanld.Size = new Size(85, 23);
            quanld.TabIndex = 6;
            quanld.Text = "Quantity";
            // 
            // uninlb
            // 
            uninlb.AutoSize = true;
            uninlb.Location = new Point(38, 477);
            uninlb.Margin = new Padding(4, 0, 4, 0);
            uninlb.Name = "uninlb";
            uninlb.Size = new Size(102, 23);
            uninlb.TabIndex = 8;
            uninlb.Text = "Unit Price :";
            // 
            // ecdlb
            // 
            ecdlb.AutoSize = true;
            ecdlb.Location = new Point(38, 688);
            ecdlb.Margin = new Padding(4, 0, 4, 0);
            ecdlb.Name = "ecdlb";
            ecdlb.Size = new Size(197, 23);
            ecdlb.TabIndex = 11;
            ecdlb.Text = "Estimated completion";
            // 
            // txtCust
            // 
            txtCust.Location = new Point(265, 90);
            txtCust.Margin = new Padding(4, 5, 4, 5);
            txtCust.Name = "txtCust";
            txtCust.Size = new Size(287, 30);
            txtCust.TabIndex = 1;
            // 
            // txtProd
            // 
            txtProd.Location = new Point(265, 179);
            txtProd.Margin = new Padding(4, 5, 4, 5);
            txtProd.Name = "txtProd";
            txtProd.Size = new Size(287, 30);
            txtProd.TabIndex = 3;
            txtProd.TextChanged += txtProd_TextChanged;
            // 
            // gord
            // 
            gord.AutoSize = true;
            gord.Checked = true;
            gord.Location = new Point(38, 265);
            gord.Margin = new Padding(4, 5, 4, 5);
            gord.Name = "gord";
            gord.Size = new Size(156, 27);
            gord.TabIndex = 4;
            gord.TabStop = true;
            gord.Text = "General Order";
            // 
            // ctrd
            // 
            ctrd.AutoSize = true;
            ctrd.Location = new Point(265, 265);
            ctrd.Margin = new Padding(4, 5, 4, 5);
            ctrd.Name = "ctrd";
            ctrd.Size = new Size(156, 27);
            ctrd.TabIndex = 5;
            ctrd.Text = "Custom Order";
            // 
            // apcb
            // 
            apcb.AutoSize = true;
            apcb.Location = new Point(38, 580);
            apcb.Margin = new Padding(4, 5, 4, 5);
            apcb.Name = "apcb";
            apcb.Size = new Size(267, 27);
            apcb.TabIndex = 10;
            apcb.Text = "Additional Packaging (+$1)";
            // 
            // quannud
            // 
            quannud.Location = new Point(192, 360);
            quannud.Margin = new Padding(4, 5, 4, 5);
            quannud.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            quannud.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quannud.Name = "quannud";
            quannud.Size = new Size(165, 30);
            quannud.TabIndex = 7;
            quannud.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // uninud
            // 
            uninud.Location = new Point(192, 469);
            uninud.Margin = new Padding(4, 5, 4, 5);
            uninud.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            uninud.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            uninud.Name = "uninud";
            uninud.Size = new Size(165, 30);
            uninud.TabIndex = 9;
            uninud.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // edcdtp
            // 
            edcdtp.Format = DateTimePickerFormat.Short;
            edcdtp.Location = new Point(38, 767);
            edcdtp.Margin = new Padding(4, 5, 4, 5);
            edcdtp.Name = "edcdtp";
            edcdtp.Size = new Size(411, 30);
            edcdtp.TabIndex = 12;
            // 
            // creatbt
            // 
            creatbt.Location = new Point(55, 912);
            creatbt.Margin = new Padding(4, 5, 4, 5);
            creatbt.Name = "creatbt";
            creatbt.Size = new Size(154, 52);
            creatbt.TabIndex = 13;
            creatbt.Text = "Create";
            creatbt.Click += creatbt_Click;
            // 
            // cleanbt
            // 
            cleanbt.Location = new Point(265, 912);
            cleanbt.Margin = new Padding(4, 5, 4, 5);
            cleanbt.Name = "cleanbt";
            cleanbt.Size = new Size(154, 52);
            cleanbt.TabIndex = 14;
            cleanbt.Text = "Clear";
            cleanbt.Click += cleanbt_Click;
            // 
            // CreateNewOrder
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 1027);
            Controls.Add(Custnlb);
            Controls.Add(txtCust);
            Controls.Add(prodlb);
            Controls.Add(txtProd);
            Controls.Add(gord);
            Controls.Add(ctrd);
            Controls.Add(quanld);
            Controls.Add(quannud);
            Controls.Add(uninlb);
            Controls.Add(uninud);
            Controls.Add(apcb);
            Controls.Add(ecdlb);
            Controls.Add(edcdtp);
            Controls.Add(creatbt);
            Controls.Add(cleanbt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
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
