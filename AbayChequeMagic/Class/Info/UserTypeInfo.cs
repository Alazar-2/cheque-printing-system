using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for UserTypeInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class UserTypeInfo    
{    
    private decimal _userTypeId;    
    private string _userType;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal UserTypeId    
    {    
        get { return _userTypeId; }    
        set { _userTypeId = value; }    
    }    
    public string UserType    
    {    
        get { return _userType; }    
        set { _userType = value; }    
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
