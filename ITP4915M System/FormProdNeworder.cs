using ITP4915MSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ITP4915M_System
{
    public partial class FormProdNeworder : Form
    {
        public FormProdNeworder()
        {
            InitializeComponent();
            this.groupBox = new System.Windows.Forms.GroupBox();
            RadioButton radioButton1 = new RadioButton();
            radioButton1.Text = "General";
            RadioButton radioButton2 = new RadioButton();
            radioButton2.Text = "RB2";
            RadioButton radioButton3 = new RadioButton();
            radioButton3.Text = "Pickle";
            this.groupBox.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.High,
                this.radioButton2,
                this.radioButton3,

            });

        }

        private void lblNewUser_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var ProductionName = this.ProductionName.Text;
            var Priority = this.groupBox.Text;
            var PlannedStart = this.PlannedStart.Text;
            var PlannedEnd = this.PlannedEnd.Text;
            var OwnerDept = this.OwnerDept.Text;
            var ResponsiblePerson = this.ResponsiblePerson.Text;
            var NoteRemark = this.NoteRemark.Text;


            RadioButton sel = groupBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            string priority = sel?.Text ?? "(未選擇)";



            //string textValue = null;
            //string tagValue = null;

            //foreach (Control ctrl in groupBox.Controls)
            //{
            //    if (ctrl is RadioButton rb && rb.Checked)
            //    {
            //        textValue = rb.Text;
            //        tagValue = rb.Tag?.ToString();
            //        break;
            //    }
            //}



        }

        private void txtNewUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormProdNewoldorder_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void High_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
