using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbayChequeMagic
{
    public partial class PrinterIPAddress : Form
    {
        public PrinterIPAddress()
        {
            InitializeComponent();
        }

        private void PrinterIPAddress_Load(object sender, EventArgs e)
        {
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
                    var portName = printer.GetPropertyValue("IpAddress");
                    //IPHostEntry hostInfo = Dns.GetHostByName("MachineName");
                    //MessageBox.Show(hostInfo.ToString());
                    ///  string strIPAdress = hostInfo.Addre­ssList[0].ToString(); 

                  //   MessageBox.Show("name: " + name + " status: " + status + " isdefault " + isDefault + " ntked? " + " portName " + portName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
