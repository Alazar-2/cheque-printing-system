using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for DateFormatInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class DateFormatInfo    
{    
    private decimal _dateFormatId;    
    private string _dateFormat;    
    private string _dateFormatName;
    private string _extraOne;  
    private string _extraTwo;    
    
    public decimal DateFormatId    
    {    
        get { return _dateFormatId; }    
        set { _dateFormatId = value; }    
    }    
    public string DateFormat    
    {    
        get { return _dateFormat; }    
        set { _dateFormat = value; }    
    }
    public string DateFormatName    
    {    
        get { return _dateFormatName; }
        set { _dateFormatName = value; }    
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
