using System;
using System.Windows.Forms;

namespace Gibbed.MassEffect2.AudioExtract
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Extractor());
        }
    }
}
