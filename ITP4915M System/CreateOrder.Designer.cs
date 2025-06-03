namespace ITP4915M_System
{
    partial class CreateOrder
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
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            label2 = new Label();
            monthCalendar1 = new MonthCalendar();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 342);
            label1.Name = "label1";
            label1.Size = new Size(251, 23);
            label1.TabIndex = 0;
            label1.Text = " Estimated Completion Date";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(238, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 30);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(605, 667);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(790, 667);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 3;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(120, 247);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(177, 27);
            checkBox1.TabIndex = 4;
            checkBox1.Text = " Extra Packaging";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 188);
            label2.Name = "label2";
            label2.Size = new Size(85, 23);
            label2.TabIndex = 5;
            label2.Text = "Quantity";
            label2.Click += label2_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(288, 342);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(228, 186);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(180, 30);
            numericUpDown1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 135);
            label3.Name = "label3";
            label3.Size = new Size(134, 23);
            label3.TabIndex = 8;
            label3.Text = "Product Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(81, 84);
            label4.Name = "label4";
            label4.Size = new Size(117, 23);
            label4.TabIndex = 9;
            label4.Text = "Customer ID";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(228, 135);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 30);
            textBox2.TabIndex = 10;
            // 
            // CreateOrder
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1137, 748);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(monthCalendar1);
            Controls.Add(label2);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "CreateOrder";
            Text = "CreateOrder";
            Load += CreateOrder_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private Label label2;
        private MonthCalendar monthCalendar1;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
    }
}