using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbayChequeMagic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // frmChequeEntry ce = new frmChequeEntry();
            Login.Login ce = new Login.Login();
           // ce.WindowState = FormWindowState.Maximized;
            ce.WindowState = FormWindowState.Normal;
            Application.Run(ce);
        }
    }
}
