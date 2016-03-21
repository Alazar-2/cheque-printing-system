using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Management;
using System.Net;

namespace AbayChequeMagic
{
    public partial class Add_printer : Form
    {
        public Add_printer()
        {
            InitializeComponent();
        }
        DataTable dtblAddedPrinters;
        private void Add_printer_Load(object sender, EventArgs e)
        {
          //  ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (var printer in printerQuery.Get())
            {
                try
                {
                    var name = printer.GetPropertyValue("Name");
                    var status = printer.GetPropertyValue("Status");
                    var isDefault = printer.GetPropertyValue("Default");
                    //var ipAddress = printer.GetPropertyValue("PortNumber");
                    var isNetworkPrinter = printer.GetPropertyValue("Network");
                    var xResoltion = printer.GetPropertyValue("horizontalResolution");
                    var yResoltion = printer.GetPropertyValue("VerticalResolution");
                    //Console.WriteLine("{0} (Status: {1}, Default: {2}, Network: {3}",
                    //            name, status, isDefault, isNetworkPrinter);
                 //   var portName = printer.GetPropertyValue("IpAddress");
                    //IPHostEntry hostInfo = Dns.GetHostByName("MachineName");
                    //MessageBox.Show(hostInfo.ToString());
                  ///  string strIPAdress = hostInfo.Addre­ssList[0].ToString(); 

                   // MessageBox.Show("name: " + name + " status: " + status + " isdefault " + isDefault + " ntked? " + " portName " + portName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
        private void PrinterIpAddress()
        {
             var scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();

            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            var results = searcher.Get();
            Console.WriteLine("Network printers list:");
            foreach (var printer in results)
            {
                var portName = printer.Properties["PortName"].Value;

                var searcher2 = new ManagementObjectSearcher("SELECT * FROM Win32_TCPIPPrinterPort where Name LIKE '" + portName + "'");
                var results2 = searcher2.Get();
                foreach (var printer2 in results2)
                {
                    Console.WriteLine("Name:" + printer.Properties["Name"].Value);
                    //Console.WriteLine("PortName:" + portName);
                    Console.WriteLine("PortNumber:" + printer2.Properties["PortNumber"].Value);
                    Console.WriteLine("HostAddress:" + printer2.Properties["HostAddress"].Value);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (object obj in lbxInstalledPrinter.SelectedItems)
                {

                    if (!lbxcChoosenPrinter.Items.Contains(obj.ToString()))
                    {

                        lbxcChoosenPrinter.Items.Add(obj.ToString());
                    }
                }
                for (int i = lbxInstalledPrinter.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    lbxInstalledPrinter.Items.RemoveAt(lbxInstalledPrinter.SelectedIndices[i]);
                }
            }
            catch (Exception ex)
            {
                Messages.InformationMessage(ex.Message);
            }
            if (lbxInstalledPrinter.Items.Count == 0)
            {
                btnAdd.Enabled = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (object obj in lbxcChoosenPrinter.SelectedItems)
                {

                    if (!lbxInstalledPrinter.Items.Contains(obj.ToString()))
                    {

                        lbxInstalledPrinter.Items.Add(obj.ToString());
                    }
                }
                for (int i = lbxcChoosenPrinter.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    lbxcChoosenPrinter.Items.RemoveAt(lbxcChoosenPrinter.SelectedIndices[i]);
                }

            }
            catch (Exception ex)
            {

                Messages.InformationMessage(ex.Message);
            }
            if (lbxcChoosenPrinter.Items.Count == 0)
            {
                btnRemove.Enabled = false;
            }
        }
        string strIsPrinterChoosen = "0";
        string strDefaultPrinterName = string.Empty;

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDefaultPrinter(string printerName);
        private void lkbtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (lbxcChoosenPrinter.SelectedItems.Count > 0)
                {
                    if (lbxcChoosenPrinter.SelectedItems.Count == 1)
                    {
                        strDefaultPrinterName = lbxcChoosenPrinter.SelectedItem.ToString();
                        strIsPrinterChoosen = "1";
                   //     frmChequeEntry fEntry = new frmChequeEntry();
                        frmChequeEntry.strPrinterName = strDefaultPrinterName;
                        SetDefaultPrinter(strDefaultPrinterName);
                    }
                    else
                    {
                        Messages.ExceptionMessage("Please select exactly one printer");
                    }
                }
                else
                {
                    Messages.ExceptionMessage("Please choose a printer from the right-hand side list");
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private bool SetDefaultPrinter()
        {
            CompanyInfo infoCompany = new CompanyInfo();
            infoCompany.ExtraOne = strDefaultPrinterName;
            infoCompany.ExtraTwo = strIsPrinterChoosen;
            return new CompanySP().CompanySetDefaultPrinter(infoCompany);
        }
        string strResolution = string.Empty;
        private void btnResolution_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxResolution.SelectedItems.Count > 0)
                {
                    if (lbxResolution.SelectedItems.Count == 1)
                    {
                        strResolution = lbxResolution.SelectedItem.ToString();
                       
                       // MessageBox.Show(strResolution);
                     //   PrinterResolution pkresolution= printDoc.PrinterSettings.PrinterResolutions[comboPrintResolution.SelectedIndex];
                    }
                    else
                    {
                        Messages.ExceptionMessage("Please select exactly one Resolution");
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
    }
}
