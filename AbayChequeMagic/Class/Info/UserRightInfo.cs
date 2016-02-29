using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for UserRightInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class UserRightInfo    
{    
    private decimal _userRightId;    
    private decimal _userTypeId;    
    private decimal _rightId;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal UserRightId    
    {    
        get { return _userRightId; }    
        set { _userRightId = value; }    
    }    
    public decimal UserTypeId    
    {    
        get { return _userTypeId; }    
        set { _userTypeId = value; }    
    }    
    public decimal RightId    
    {    
        get { return _rightId; }    
        set { _rightId = value; }    
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
