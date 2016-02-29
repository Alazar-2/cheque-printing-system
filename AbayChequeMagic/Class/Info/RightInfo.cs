using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for RightInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class RightInfo    
{    
    private decimal _rightId;    
    private string _rightName;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal RightId    
    {    
        get { return _rightId; }    
        set { _rightId = value; }    
    }    
    public string RightName    
    {    
        get { return _rightName; }    
        set { _rightName = value; }    
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
