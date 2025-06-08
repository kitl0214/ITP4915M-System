// InputBox.cs   ——  專案通用小對話框
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ITP4915M_System     // ← 與其他檔一致
{
    public class InputBox : Form
    {
        private readonly TextBox txt;
        public string Value => txt.Text;

        public InputBox(string prompt)
        {
            var lbl = new Label
            {
                Text = prompt,
                AutoSize = true,
                Location = new Point(15, 15)
            };
            txt = new TextBox
            {
                Location = new Point(18, 45),
                Width = 250
            };
            var ok = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(40, 85)
            };
            var cancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(150, 85)
            };

            AcceptButton = ok;
            CancelButton = cancel;
            ClientSize = new Size(290, 130);
            Controls.AddRange(new Control[] { lbl, txt, ok, cancel });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
        }
    }
}
