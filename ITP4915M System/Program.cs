using System;
using System.Windows.Forms;

namespace ITP4915M_System   // ⚠ 與整個專案命名空間一致
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            
            Application.Run(new LoginForm());       // ★ 關鍵：建立並維持主視窗
        }
    }
}
