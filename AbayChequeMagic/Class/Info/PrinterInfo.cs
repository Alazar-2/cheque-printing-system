using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for PrinterInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class PrinterInfo    
{    
    private decimal _printerId;    
    private string _printerName;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal PrinterId    
    {    
        get { return _printerId; }    
        set { _printerId = value; }    
    }    
    public string PrinterName    
    {    
        get { return _printerName; }    
        set { _printerName = value; }    
    }    
    public string ExtraOne    
    {    
        get { return _extraOne; }    
        set { _extraOne = value; }    
    }    
    public string ExtraTwo    
    {    
        get { return _extraTwo; }    
        set { _extraTwo = value; }    
    }    
    
}    
}
