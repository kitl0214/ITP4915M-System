// -----------------------------------------------------------------------------
// CreateNewOrder.Designer.cs  –  Customer Name version (designer generated)
// -----------------------------------------------------------------------------
namespace ITP4915M_System
{
    partial class CreateNewOrder
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label NameLb;
        private System.Windows.Forms.Label prodlb;
        private System.Windows.Forms.Label quanlb;
        private System.Windows.Forms.Label uninlb;
        private System.Windows.Forms.Label duedlb;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.TextBox txtProd;
        private System.Windows.Forms.RadioButton gord;
        private System.Windows.Forms.RadioButton ctrd;
        private System.Windows.Forms.CheckBox apcb;
        private System.Windows.Forms.NumericUpDown quannud;
        private System.Windows.Forms.NumericUpDown uninud;
        private System.Windows.Forms.DateTimePicker edcdtp;
        private System.Windows.Forms.Button creatbt;
        private System.Windows.Forms.Button cleanbt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            NameLb = new System.Windows.Forms.Label();
            prodlb = new System.Windows.Forms.Label();
            quanlb = new System.Windows.Forms.Label();
            uninlb = new System.Windows.Forms.Label();
            duedlb = new System.Windows.Forms.Label();
            txtCName = new System.Windows.Forms.TextBox();
            txtProd = new System.Windows.Forms.TextBox();
            gord = new System.Windows.Forms.RadioButton();
            ctrd = new System.Windows.Forms.RadioButton();
            apcb = new System.Windows.Forms.CheckBox();
            quannud = new System.Windows.Forms.NumericUpDown();
            uninud = new System.Windows.Forms.NumericUpDown();
            edcdtp = new System.Windows.Forms.DateTimePicker();
            creatbt = new System.Windows.Forms.Button();
            cleanbt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(quannud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(uninud)).BeginInit();
            SuspendLayout();
            // 
            // NameLb
            // 
            NameLb.AutoSize = true;
            NameLb.Location = new System.Drawing.Point(35, 50);
            NameLb.Name = "NameLb";
            NameLb.Size = new System.Drawing.Size(163, 37);
            NameLb.Text = "Customer :";
            // 
            // prodlb
            // 
            prodlb.AutoSize = true;
            prodlb.Location = new System.Drawing.Point(35, 110);
            prodlb.Name = "prodlb";
            prodlb.Size = new System.Drawing.Size(122, 37);
            prodlb.Text = "Product :";
            // 
            // quanlb
            // 
            quanlb.AutoSize = true;
            quanlb.Location = new System.Drawing.Point(35, 230);
            quanlb.Name = "quanlb";
            quanlb.Size = new System.Drawing.Size(132, 37);
            quanlb.Text = "Quantity :";
            // 
            // uninlb
            // 
            uninlb.AutoSize = true;
            uninlb.Location = new System.Drawing.Point(35, 290);
            uninlb.Name = "uninlb";
            uninlb.Size = new System.Drawing.Size(102, 37);
            uninlb.Text = "Unit $ :";
            // 
            // duedlb
            // 
            duedlb.AutoSize = true;
            duedlb.Location = new System.Drawing.Point(35, 420);
            duedlb.Name = "duedlb";
            duedlb.Size = new System.Drawing.Size(141, 37);
            duedlb.Text = "Due Date :";
            // 
            // txtCName
            // 
            txtCName.Location = new System.Drawing.Point(220, 46);
            txtCName.Name = "txtCName";
            txtCName.Size = new System.Drawing.Size(240, 43);
            // 
            // txtProd
            // 
            txtProd.Location = new System.Drawing.Point(220, 106);
            txtProd.Name = "txtProd";
            txtProd.Size = new System.Drawing.Size(240, 43);
            txtProd.TextChanged += txtProd_TextChanged;
            // 
            // gord
            // 
            gord.AutoSize = true;
            gord.Checked = true;
            gord.Location = new System.Drawing.Point(35, 165);
            gord.Name = "gord";
            gord.Size = new System.Drawing.Size(140, 41);
            gord.Text = "General";
            gord.UseVisualStyleBackColor = true;
            // 
            // ctrd
            // 
            ctrd.AutoSize = true;
            ctrd.Location = new System.Drawing.Point(220, 165);
            ctrd.Name = "ctrd";
            ctrd.Size = new System.Drawing.Size(139, 41);
            ctrd.Text = "Custom";
            ctrd.UseVisualStyleBackColor = true;
            // 
            // apcb
            // 
            apcb.AutoSize = true;
            apcb.Location = new System.Drawing.Point(55, 347);
            apcb.Name = "apcb";
            apcb.Size = new System.Drawing.Size(293, 41);
            apcb.Text = "Extra Pkg (+$1/item)";
            apcb.UseVisualStyleBackColor = true;
            // 
            // quannud
            // 
            quannud.Location = new System.Drawing.Point(220, 224);
            quannud.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            quannud.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quannud.Name = "quannud";
            quannud.Size = new System.Drawing.Size(120, 43);
            quannud.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // uninud
            // 
            uninud.Location = new System.Drawing.Point(220, 284);
            uninud.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            uninud.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            uninud.Name = "uninud";
            uninud.Size = new System.Drawing.Size(120, 43);
            uninud.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // edcdtp
            // 
            edcdtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            edcdtp.Location = new System.Drawing.Point(35, 480);
            edcdtp.Name = "edcdtp";
            edcdtp.Size = new System.Drawing.Size(218, 43);
            // 
            // creatbt
            // 
            creatbt.Location = new System.Drawing.Point(35, 545);
            creatbt.Name = "creatbt";
            creatbt.Size = new System.Drawing.Size(120, 40);
            creatbt.Text = "Create";
            creatbt.UseVisualStyleBackColor = true;
            creatbt.Click += creatbt_Click;
            // 
            // cleanbt
            // 
            cleanbt.Location = new System.Drawing.Point(175, 545);
            cleanbt.Name = "cleanbt";
            cleanbt.Size = new System.Drawing.Size(120, 40);
            cleanbt.Text = "Clear";
            cleanbt.UseVisualStyleBackColor = true;
            cleanbt.Click += cleanbt_Click;
            // 
            // CreateNewOrder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(660, 760);
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                cleanbt, creatbt, edcdtp, uninud, quannud, apcb,
                ctrd, gord, txtProd, txtCName, duedlb, uninlb,
                quanlb, prodlb, NameLb
            });
            Font = new System.Drawing.Font("Segoe UI", 10F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateNewOrder";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Create New Order";
            Load += CreateNewOrder_Load;
            ((System.ComponentModel.ISupportInitialize)(quannud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(uninud)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
