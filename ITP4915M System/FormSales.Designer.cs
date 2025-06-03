namespace ITP4915M_System
{
    partial class FormSales
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            btcreato = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 26);
            label1.Name = "label1";
            label1.Size = new Size(151, 23);
            label1.TabIndex = 0;
            label1.Text = "Sales Dashboard";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(71, 89);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 31);
            comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(83, 164);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 30);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(59, 322);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(390, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(734, 410);
            dataGridView1.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(59, 389);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 6;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(220, 242);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 7;
            button4.Text = "Cancel";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(220, 322);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 8;
            button5.Text = "Ship";
            button5.UseVisualStyleBackColor = true;
            // 
            // btcreato
            // 
            btcreato.Location = new Point(44, 242);
            btcreato.Name = "btcreato";
            btcreato.Size = new Size(147, 34);
            btcreato.TabIndex = 9;
            btcreato.Text = "CreatOrder";
            btcreato.UseVisualStyleBackColor = true;
            btcreato.Click += btcreato_Click;
            // 
            // FormSales
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1222, 711);
            Controls.Add(btcreato);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "FormSales";
            Text = "FormSales";
            Load += FormSales_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button btcreato;
    }
}