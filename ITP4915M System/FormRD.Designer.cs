namespace ITP4915M_System
{
    partial class FormRD
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelOP;
        private System.Windows.Forms.Label labelOP;
        private System.Windows.Forms.DataGridView dgvOP;
        private System.Windows.Forms.Panel panelTR;
        private System.Windows.Forms.Label labelTR;
        private System.Windows.Forms.DataGridView dgvTR;
        private System.Windows.Forms.Panel panelCP;
        private System.Windows.Forms.Label labelCP;
        private System.Windows.Forms.DataGridView dgvCP;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // TableLayoutPanel
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F)); // Button row
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(this.tableLayoutPanel1);

            // Refresh Button Panel
            var panelTop = new System.Windows.Forms.Panel();
            panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTop.Padding = new System.Windows.Forms.Padding(8, 8, 0, 8);

            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 32);
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            panelTop.Controls.Add(this.btnRefresh);

            this.tableLayoutPanel1.Controls.Add(panelTop, 0, 0);

            // Panel for Ongoing Projects
            this.panelOP = new System.Windows.Forms.Panel();
            this.panelOP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOP.Padding = new System.Windows.Forms.Padding(0);
            this.labelOP = new System.Windows.Forms.Label();
            this.labelOP.Text = "Ongoing Projects";
            this.labelOP.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelOP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelOP.Height = 26;
            this.labelOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dgvOP = new System.Windows.Forms.DataGridView();
            this.dgvOP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelOP.Controls.Add(this.dgvOP);
            this.panelOP.Controls.Add(this.labelOP);
            this.tableLayoutPanel1.Controls.Add(this.panelOP, 0, 1);

            // Panel for Task Reminder
            this.panelTR = new System.Windows.Forms.Panel();
            this.panelTR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTR.Padding = new System.Windows.Forms.Padding(0);
            this.labelTR = new System.Windows.Forms.Label();
            this.labelTR.Text = "Task Reminder";
            this.labelTR.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTR.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelTR.Height = 26;
            this.labelTR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dgvTR = new System.Windows.Forms.DataGridView();
            this.dgvTR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelTR.Controls.Add(this.dgvTR);
            this.panelTR.Controls.Add(this.labelTR);
            this.tableLayoutPanel1.Controls.Add(this.panelTR, 0, 2);

            // Panel for Completed Projects
            this.panelCP = new System.Windows.Forms.Panel();
            this.panelCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCP.Padding = new System.Windows.Forms.Padding(0);
            this.labelCP = new System.Windows.Forms.Label();
            this.labelCP.Text = "Completed Projects";
            this.labelCP.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelCP.Height = 26;
            this.labelCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dgvCP = new System.Windows.Forms.DataGridView();
            this.dgvCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelCP.Controls.Add(this.dgvCP);
            this.panelCP.Controls.Add(this.labelCP);
            this.tableLayoutPanel1.Controls.Add(this.panelCP, 0, 3);

            // Form 基本屬性
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Name = "FormRD";
            this.Text = "FormRD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(800, 600);
        }

        #endregion
    }
}
