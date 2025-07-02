namespace ITP4915M_System
{
    partial class PartPruchingOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Save = new Button();
            button1 = new Button();
            OrderDate = new Label();
            dateTimePicker1 = new DateTimePicker();
            ExpectedDate = new Label();
            dateTimePicker2 = new DateTimePicker();
            Supplier = new Label();
            cmbDept = new ComboBox();
            POID = new Label();
            txtUser = new TextBox();
            dataGridView1 = new DataGridView();
            Total = new Label();
            AddLine = new Button();
            DeleteLine = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Save
            // 
            Save.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Save.Location = new Point(646, 478);
            Save.Margin = new Padding(2);
            Save.Name = "Save";
            Save.Size = new Size(86, 47);
            Save.TabIndex = 0;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(758, 478);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(86, 47);
            button1.TabIndex = 1;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            // 
            // OrderDate
            // 
            OrderDate.AutoSize = true;
            OrderDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OrderDate.Location = new Point(494, 57);
            OrderDate.Margin = new Padding(2, 0, 2, 0);
            OrderDate.Name = "OrderDate";
            OrderDate.Size = new Size(90, 20);
            OrderDate.TabIndex = 6;
            OrderDate.Text = "Order Date:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(610, 52);
            dateTimePicker1.Margin = new Padding(2, 3, 2, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(219, 27);
            dateTimePicker1.TabIndex = 5;
            // 
            // ExpectedDate
            // 
            ExpectedDate.AutoSize = true;
            ExpectedDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExpectedDate.Location = new Point(471, 119);
            ExpectedDate.Margin = new Padding(2, 0, 2, 0);
            ExpectedDate.Name = "ExpectedDate";
            ExpectedDate.Size = new Size(113, 20);
            ExpectedDate.TabIndex = 8;
            ExpectedDate.Text = "Expected Date:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(610, 115);
            dateTimePicker2.Margin = new Padding(2, 3, 2, 3);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(219, 27);
            dateTimePicker2.TabIndex = 7;
            // 
            // Supplier
            // 
            Supplier.AutoSize = true;
            Supplier.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Supplier.Location = new Point(39, 119);
            Supplier.Margin = new Padding(2, 0, 2, 0);
            Supplier.Name = "Supplier";
            Supplier.Size = new Size(71, 20);
            Supplier.TabIndex = 10;
            Supplier.Text = "Supplier:";
            // 
            // cmbDept
            // 
            cmbDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDept.Location = new Point(161, 114);
            cmbDept.Margin = new Padding(2);
            cmbDept.Name = "cmbDept";
            cmbDept.Size = new Size(228, 28);
            cmbDept.TabIndex = 9;
            // 
            // POID
            // 
            POID.AutoSize = true;
            POID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            POID.ForeColor = SystemColors.ControlText;
            POID.Location = new Point(39, 57);
            POID.Margin = new Padding(2, 0, 2, 0);
            POID.Name = "POID";
            POID.Size = new Size(53, 20);
            POID.TabIndex = 12;
            POID.Text = "PO ID:";
            POID.Click += lblUser_Click;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(161, 52);
            txtUser.Margin = new Padding(2);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(228, 27);
            txtUser.TabIndex = 11;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(39, 178);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(790, 164);
            dataGridView1.TabIndex = 13;
            // 
            // Total
            // 
            Total.AutoSize = true;
            Total.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Total.Location = new Point(646, 373);
            Total.Margin = new Padding(2, 0, 2, 0);
            Total.Name = "Total";
            Total.Size = new Size(52, 20);
            Total.TabIndex = 14;
            Total.Text = "Total :";
            Total.Click += label1_Click;
            // 
            // AddLine
            // 
            AddLine.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddLine.Location = new Point(39, 358);
            AddLine.Margin = new Padding(2);
            AddLine.Name = "AddLine";
            AddLine.Size = new Size(100, 35);
            AddLine.TabIndex = 16;
            AddLine.Text = "Add Line";
            AddLine.UseVisualStyleBackColor = true;
            // 
            // DeleteLine
            // 
            DeleteLine.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteLine.Location = new Point(161, 358);
            DeleteLine.Margin = new Padding(2);
            DeleteLine.Name = "DeleteLine";
            DeleteLine.Size = new Size(100, 35);
            DeleteLine.TabIndex = 17;
            DeleteLine.Text = "Delete Line";
            DeleteLine.UseVisualStyleBackColor = true;
            // 
            // PartPruchingOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(DeleteLine);
            Controls.Add(AddLine);
            Controls.Add(Total);
            Controls.Add(dataGridView1);
            Controls.Add(POID);
            Controls.Add(txtUser);
            Controls.Add(Supplier);
            Controls.Add(cmbDept);
            Controls.Add(ExpectedDate);
            Controls.Add(dateTimePicker2);
            Controls.Add(OrderDate);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(Save);
            Margin = new Padding(2);
            Name = "PartPruchingOrder";
            Text = "PartPruchingOrder";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Save;
        private Button button1;
        private Label OrderDate;
        private DateTimePicker dateTimePicker1;
        private Label ExpectedDate;
        private DateTimePicker dateTimePicker2;
        private Label Supplier;
        private ComboBox cmbDept;
        private Label POID;
        private TextBox txtUser;
        private DataGridView dataGridView1;
        private Label Total;
        private Button AddLine;
        private Button DeleteLine;
    }
}