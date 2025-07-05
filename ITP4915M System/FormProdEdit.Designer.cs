// ... 省略前面程式碼 ...

/*using Org.BouncyCastle.Asn1.Crmf;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

private void InitializeComponent()
{
    components = new System.ComponentModel.Container();
    textBox1 = new TextBox();
    Qty2 = new TextBox();
    contextMenuStrip1 = new ContextMenuStrip(components);
    PatNo = new Label();
    Qty1 = new Label();
    PartNo2 = new ComboBox();
    Cancel = new Button();      // <-- 修改這裡
    Save = new Button();
    UnitPrice1 = new Label();
    UnitPrice2 = new TextBox();
    PartNo1 = new Label();
    SuspendLayout();
    // 
    // textBox1
    // ... 省略 ...
    // 
    // Cancel
    // 
    Cancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
    Cancel.Location = new Point(336, 323);
    Cancel.Margin = new Padding(2);
    Cancel.Name = "Cancel";
    Cancel.Size = new Size(86, 47);
    Cancel.TabIndex = 16;
    Cancel.Text = "Cancel";
    Cancel.UseVisualStyleBackColor = true;
    Cancel.Click += this.Cancel_Click;
    // 
    // Save
    // ... 省略 ...
    // 
    // FormProdEdit
    // 
    AutoScaleDimensions = new SizeF(8F, 20F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(512, 403);
    Controls.Add(PartNo1);
    Controls.Add(UnitPrice1);
    Controls.Add(UnitPrice2);
    Controls.Add(PartNo2);
    Controls.Add(Cancel);     // <-- 修改這裡
    Controls.Add(Save);
    Controls.Add(Qty1);
    Controls.Add(PatNo);
    Controls.Add(Qty2);
    Controls.Add(textBox1);
    Name = "FormProdEdit";
    Text = "FormProdEdit";
    ResumeLayout(false);
    PerformLayout();
}

// ... 省略 ...
private Button Cancel;  // <-- 修改這裡
private Button Save;
// ... 省略 ... */
