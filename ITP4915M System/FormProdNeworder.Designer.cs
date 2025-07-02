namespace ITP4915M_System
{
    partial class FormProdNeworder
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
            button3 = new Button();
            button2 = new Button();
            label3 = new Label();
            label2 = new Label();
            PlannedEnd = new DateTimePicker();
            PlannedStart = new DateTimePicker();
            label4 = new Label();
            lblNewUser = new Label();
            ProductionName = new TextBox();
            label5 = new Label();
            NoteRemark = new TextBox();
            OwnerDept = new ComboBox();
            label6 = new Label();
            ResponsiblePerson = new ComboBox();
            label7 = new Label();
            Low = new RadioButton();
            label8 = new Label();
            Medium = new RadioButton();
            label9 = new Label();
            OrderID = new TextBox();
            groupBox = new GroupBox();
            High = new RadioButton();
            Quantity1 = new Label();
            Quantity2 = new TextBox();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(776, 949);
            button3.Name = "button3";
            button3.Size = new Size(132, 46);
            button3.TabIndex = 20;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(586, 949);
            button2.Name = "button2";
            button2.Size = new Size(132, 46);
            button2.TabIndex = 18;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 590);
            label3.Name = "label3";
            label3.Size = new Size(147, 32);
            label3.TabIndex = 16;
            label3.Text = "Planned End";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 510);
            label2.Name = "label2";
            label2.Size = new Size(155, 32);
            label2.TabIndex = 15;
            label2.Text = "Planned Start";
            // 
            // PlannedEnd
            // 
            PlannedEnd.Location = new Point(320, 583);
            PlannedEnd.Name = "PlannedEnd";
            PlannedEnd.Size = new Size(353, 39);
            PlannedEnd.TabIndex = 14;
            PlannedEnd.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // PlannedStart
            // 
            PlannedStart.Location = new Point(320, 510);
            PlannedStart.Name = "PlannedStart";
            PlannedStart.Size = new Size(353, 39);
            PlannedStart.TabIndex = 13;
            PlannedStart.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 45);
            label4.Name = "label4";
            label4.Size = new Size(199, 32);
            label4.TabIndex = 21;
            label4.Text = "Production Board";
            // 
            // lblNewUser
            // 
            lblNewUser.AutoSize = true;
            lblNewUser.Location = new Point(72, 219);
            lblNewUser.Margin = new Padding(6, 0, 6, 0);
            lblNewUser.Name = "lblNewUser";
            lblNewUser.Size = new Size(201, 32);
            lblNewUser.TabIndex = 22;
            lblNewUser.Text = "Production Name";
            lblNewUser.Click += lblNewUser_Click;
            // 
            // ProductionName
            // 
            ProductionName.Location = new Point(318, 212);
            ProductionName.Margin = new Padding(6, 6, 6, 6);
            ProductionName.Name = "ProductionName";
            ProductionName.Size = new Size(275, 39);
            ProductionName.TabIndex = 23;
            ProductionName.TextChanged += txtNewUser_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 849);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(153, 32);
            label5.TabIndex = 24;
            label5.Text = "Note Remark";
            // 
            // NoteRemark
            // 
            NoteRemark.Location = new Point(320, 844);
            NoteRemark.Margin = new Padding(6, 6, 6, 6);
            NoteRemark.Name = "NoteRemark";
            NoteRemark.Size = new Size(275, 39);
            NoteRemark.TabIndex = 25;
            NoteRemark.TextChanged += textBox1_TextChanged;
            // 
            // OwnerDept
            // 
            OwnerDept.FormattingEnabled = true;
            OwnerDept.Location = new Point(320, 660);
            OwnerDept.Name = "OwnerDept";
            OwnerDept.Size = new Size(214, 40);
            OwnerDept.TabIndex = 27;
            OwnerDept.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(72, 668);
            label6.Name = "label6";
            label6.Size = new Size(143, 32);
            label6.TabIndex = 26;
            label6.Text = "Owner Dept";
            // 
            // ResponsiblePerson
            // 
            ResponsiblePerson.FormattingEnabled = true;
            ResponsiblePerson.Location = new Point(320, 756);
            ResponsiblePerson.Name = "ResponsiblePerson";
            ResponsiblePerson.Size = new Size(214, 40);
            ResponsiblePerson.TabIndex = 29;
            ResponsiblePerson.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(72, 759);
            label7.Name = "label7";
            label7.Size = new Size(219, 32);
            label7.TabIndex = 28;
            label7.Text = "Responsible Person";
            label7.Click += label7_Click;
            // 
            // Low
            // 
            Low.AutoSize = true;
            Low.Location = new Point(26, 56);
            Low.Name = "Low";
            Low.Size = new Size(87, 36);
            Low.TabIndex = 30;
            Low.Text = "Low";
            Low.UseVisualStyleBackColor = true;
            Low.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(72, 346);
            label8.Name = "label8";
            label8.Size = new Size(89, 32);
            label8.TabIndex = 31;
            label8.Text = "Priority";
            label8.Click += label8_Click_1;
            // 
            // Medium
            // 
            Medium.AutoSize = true;
            Medium.Checked = true;
            Medium.Location = new Point(161, 56);
            Medium.Name = "Medium";
            Medium.Size = new Size(135, 36);
            Medium.TabIndex = 33;
            Medium.TabStop = true;
            Medium.Text = "Medium";
            Medium.UseVisualStyleBackColor = true;
            Medium.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(73, 147);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(105, 32);
            label9.TabIndex = 34;
            label9.Text = "Order ID";
            // 
            // OrderID
            // 
            OrderID.Location = new Point(318, 140);
            OrderID.Margin = new Padding(6, 6, 6, 6);
            OrderID.Name = "OrderID";
            OrderID.Size = new Size(275, 39);
            OrderID.TabIndex = 35;
            OrderID.TextChanged += textBox3_TextChanged;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(High);
            groupBox.Controls.Add(Medium);
            groupBox.Controls.Add(Low);
            groupBox.Cursor = Cursors.No;
            groupBox.Location = new Point(309, 286);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(544, 126);
            groupBox.TabIndex = 36;
            groupBox.TabStop = false;
            groupBox.Text = "Priority";
            groupBox.Enter += groupBox1_Enter;
            // 
            // High
            // 
            High.AutoSize = true;
            High.Checked = true;
            High.Location = new Point(323, 56);
            High.Name = "High";
            High.Size = new Size(96, 36);
            High.TabIndex = 34;
            High.TabStop = true;
            High.Text = "High";
            High.UseVisualStyleBackColor = true;
            High.CheckedChanged += High_CheckedChanged;
            // 
            // Quantity1
            // 
            Quantity1.AutoSize = true;
            Quantity1.Location = new Point(72, 443);
            Quantity1.Margin = new Padding(6, 0, 6, 0);
            Quantity1.Name = "Quantity1";
            Quantity1.Size = new Size(106, 32);
            Quantity1.TabIndex = 37;
            Quantity1.Text = "Quantity";
            // 
            // Quantity2
            // 
            Quantity2.Location = new Point(318, 440);
            Quantity2.Margin = new Padding(6);
            Quantity2.Name = "Quantity2";
            Quantity2.Size = new Size(275, 39);
            Quantity2.TabIndex = 38;
            // 
            // FormProdNeworder
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(954, 1029);
            Controls.Add(Quantity1);
            Controls.Add(Quantity2);
            Controls.Add(groupBox);
            Controls.Add(label9);
            Controls.Add(OrderID);
            Controls.Add(label8);
            Controls.Add(ResponsiblePerson);
            Controls.Add(label7);
            Controls.Add(OwnerDept);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(NoteRemark);
            Controls.Add(lblNewUser);
            Controls.Add(ProductionName);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(PlannedEnd);
            Controls.Add(PlannedStart);
            Name = "FormProdNeworder";
            Text = "FormProdNewolder";
            Load += FormProdNewoldorder_Load;
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private Label label3;
        private Label label2;
        private DateTimePicker PlannedEnd;
        private DateTimePicker PlannedStart;
        private Label label4;
        private Label lblNewUser;
        private TextBox ProductionName;
        private Label label5;
        private TextBox NoteRemark;
        private ComboBox OwnerDept;
        private Label label6;
        private ComboBox ResponsiblePerson;
        private Label label7;
        private RadioButton Low;
        private Label label8;
        private RadioButton High;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton Medium;
        private TextBox textBox2;
        private Label label9;
        private TextBox OrderID;
        private GroupBox groupBox;
        private Label Quantity1;
        private TextBox Quantity2;
    }
}