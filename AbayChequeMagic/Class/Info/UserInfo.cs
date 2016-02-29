using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for UserInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class UserInfo    
{    
    private string _username;    
    private decimal _userTypeId;    
    private string _password;    
    private decimal _employeeId;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public string Username    
    {    
        get { return _username; }    
        set { _username = value; }    
    }    
    public decimal UserTypeId    
    {    
        get { return _userTypeId; }    
        set { _userTypeId = value; }    
    }    
    public string Password    
    {    
        get { return _password; }    
        set { _password = value; }    
    }
    public decimal EmployeeId
    {
        get { return _employeeId; }
        set { _employeeId = value; }
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
