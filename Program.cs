using System;
using System.Windows.Forms;


namespace Wave_Priject
{
    internal static class Program
    {
        static void Main ()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmWaveOrder());
        }
    }
}


