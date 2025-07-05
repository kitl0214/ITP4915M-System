namespace ITP4915M_System
{
    partial class InvoiceDetailDialog
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblInvoiceIDTitle, lblInvoiceIDValue;
        private System.Windows.Forms.Label lblOrderIDTitle, lblOrderIDValue;
        private System.Windows.Forms.Label lblUserNameTitle, lblUserNameValue;
        private System.Windows.Forms.Label lblOrderTypeTitle, lblOrderTypeValue;
        private System.Windows.Forms.Label lblAmountTitle, lblAmountValue;
        private System.Windows.Forms.Label lblIssueDateTitle, lblIssueDateValue;
        private System.Windows.Forms.Label lblStatusTitle, lblStatusValue;
        private System.Windows.Forms.Label lblFooter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblInvoiceIDTitle = new System.Windows.Forms.Label();
            this.lblInvoiceIDValue = new System.Windows.Forms.Label();
            this.lblOrderIDTitle = new System.Windows.Forms.Label();
            this.lblOrderIDValue = new System.Windows.Forms.Label();
            this.lblUserNameTitle = new System.Windows.Forms.Label();
            this.lblUserNameValue = new System.Windows.Forms.Label();
            this.lblOrderTypeTitle = new System.Windows.Forms.Label();
            this.lblOrderTypeValue = new System.Windows.Forms.Label();
            this.lblAmountTitle = new System.Windows.Forms.Label();
            this.lblAmountValue = new System.Windows.Forms.Label();
            this.lblIssueDateTitle = new System.Windows.Forms.Label();
            this.lblIssueDateValue = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();

            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Padding = new System.Windows.Forms.Padding(20, 20, 20, 16);
            this.Controls.Add(this.panelMain);

            // 
            // lblHeader
            // 
            this.lblHeader.Text = "INVOICE";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(30, 60, 120);
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(16, 10);
            this.panelMain.Controls.Add(this.lblHeader);

            int startY = 60;
            int rowH = 32;
            int col1 = 16, col2 = 120;

            // 資料列（標題＋值，參考現代風格間距）
            var info = new (System.Windows.Forms.Label, System.Windows.Forms.Label, string)[]
            {
                (lblInvoiceIDTitle, lblInvoiceIDValue, "Invoice ID"),
                (lblOrderIDTitle,   lblOrderIDValue,   "Order ID"),
                (lblUserNameTitle,  lblUserNameValue,  "User Name"),
                (lblOrderTypeTitle, lblOrderTypeValue, "Order Type"),
                (lblAmountTitle,    lblAmountValue,    "Amount"),
                (lblIssueDateTitle, lblIssueDateValue, "Issue Date"),
                (lblStatusTitle,    lblStatusValue,    "Status")
            };

            for (int i = 0; i < info.Length; i++)
            {
                info[i].Item1.Text = info[i].Item3 + ":";
                info[i].Item1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                info[i].Item1.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
                info[i].Item1.Location = new System.Drawing.Point(col1, startY + rowH * i);
                info[i].Item1.AutoSize = true;
                this.panelMain.Controls.Add(info[i].Item1);

                info[i].Item2.Text = ""; // 動態填入
                info[i].Item2.Font = new System.Drawing.Font("Segoe UI", i == 4 ? 11F : 10.5F, i == 4 ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
                info[i].Item2.Location = new System.Drawing.Point(col2, startY + rowH * i);
                info[i].Item2.AutoSize = true;
                this.panelMain.Controls.Add(info[i].Item2);

                // 高亮顏色（Amount 用深色、Status 用藍色）
                if (i == 4) info[i].Item2.ForeColor = System.Drawing.Color.FromArgb(200, 60, 30);    // Amount
                if (i == 6) info[i].Item2.ForeColor = System.Drawing.Color.RoyalBlue;                // Status
            }

            // 
            // lblFooter
            // 
            this.lblFooter.Text = "Generated by System · " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblFooter.ForeColor = System.Drawing.Color.DimGray;
            this.lblFooter.AutoSize = true;
            this.lblFooter.Location = new System.Drawing.Point(16, startY + rowH * info.Length + 16);
            this.panelMain.Controls.Add(this.lblFooter);

            // 
            // Dialog 基本屬性
            // 
            this.ClientSize = new System.Drawing.Size(380, startY + rowH * info.Length + 54);
            this.Name = "InvoiceDetailDialog";
            this.Text = "Invoice Detail";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
