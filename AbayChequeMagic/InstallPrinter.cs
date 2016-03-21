using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AbayChequeMagic
{
    public partial class InstallPrinter : Form
    {
        public InstallPrinter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string printer = "rundll32 printui.dll,PrintUIEntry /im";
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "C:\\CSharp\\AddPrinter";
            proc.StartInfo.WorkingDirectory = "C:\\CSharp\\AddPrinter";
            proc.Start();
        }
    }
}
