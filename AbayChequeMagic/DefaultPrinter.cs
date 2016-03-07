using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbayChequeMagic
{
    public partial class DefaultPrinter : Form
    {
        public DefaultPrinter()
        {
            InitializeComponent();
        }

        private void DefaultPrinter_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    lbxInstalledPrinter.Items.Add(printer);

                }
                //dtblAddedPrinters = new PrinterSP().PrinterViewAll();
                //foreach (DataRow dr in dtblAddedPrinters.Rows)
                //{
                //    lbxcChoosenPrinter.Items.Add(dr["printerName"]);
                //}
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
    }
}
