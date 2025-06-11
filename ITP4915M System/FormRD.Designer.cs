namespace ITP4915M_System
{
    partial class FormRD
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
            ongoingProjects = new GroupBox();
            dgvOP = new DataGridView();
            taskReminder = new GroupBox();
            dgvTR = new DataGridView();
            completedProjects = new GroupBox();
            dgvCP = new DataGridView();
            ongoingProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOP).BeginInit();
            taskReminder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTR).BeginInit();
            completedProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCP).BeginInit();
            SuspendLayout();
            // 
            // ongoingProjects
            // 
            ongoingProjects.Controls.Add(dgvOP);
            ongoingProjects.Location = new Point(12, 48);
            ongoingProjects.Name = "ongoingProjects";
            ongoingProjects.Size = new Size(776, 171);
            ongoingProjects.TabIndex = 2;
            ongoingProjects.TabStop = false;
            ongoingProjects.Text = "Ongoing Projects";
            // 
            // dgvOP
            // 
            dgvOP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOP.Dock = DockStyle.Fill;
            dgvOP.Location = new Point(3, 19);
            dgvOP.Name = "dgvOP";
            dgvOP.Size = new Size(770, 149);
            dgvOP.TabIndex = 7;
            dgvOP.CellContentClick += dataGridView1_CellContentClick;
            // 
            // taskReminder
            // 
            taskReminder.Controls.Add(dgvTR);
            taskReminder.Location = new Point(15, 225);
            taskReminder.Name = "taskReminder";
            taskReminder.Size = new Size(770, 171);
            taskReminder.TabIndex = 8;
            taskReminder.TabStop = false;
            taskReminder.Text = "Task Reminder";
            // 
            // dgvTR
            // 
            dgvTR.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTR.Dock = DockStyle.Fill;
            dgvTR.Location = new Point(3, 19);
            dgvTR.Name = "dgvTR";
            dgvTR.Size = new Size(764, 149);
            dgvTR.TabIndex = 7;
            // 
            // completedProjects
            // 
            completedProjects.Controls.Add(dgvCP);
            completedProjects.Location = new Point(18, 402);
            completedProjects.Name = "completedProjects";
            completedProjects.Size = new Size(764, 171);
            completedProjects.TabIndex = 9;
            completedProjects.TabStop = false;
            completedProjects.Text = "Completed Projects";
            // 
            // dgvCP
            // 
            dgvCP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCP.Dock = DockStyle.Fill;
            dgvCP.Location = new Point(3, 19);
            dgvCP.Name = "dgvCP";
            dgvCP.Size = new Size(758, 149);
            dgvCP.TabIndex = 7;
            // 
            // FormRD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 592);
            Controls.Add(completedProjects);
            Controls.Add(taskReminder);
            Controls.Add(ongoingProjects);
            Name = "FormRD";
            Text = "FormRD";
            ongoingProjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOP).EndInit();
            taskReminder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTR).EndInit();
            completedProjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCP).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox ongoingProjects;
        private DataGridView dgvOP;
        private GroupBox taskReminder;
        private DataGridView dgvTR;
        private GroupBox completedProjects;
        private DataGridView dgvCP;
    }
}