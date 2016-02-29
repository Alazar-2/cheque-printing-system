using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for PayeeInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class PayeeInfo    
{    
    private decimal _payeeId;    
    private string _payeeName;    
    private string _printName;    
    private string _address;    
    private string _city;    
    private string _state;    
    private string _pincode;    
    private string _mobile;    
    private string _fax;    
    private string _email;    
    private string _website;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal PayeeId    
    {    
        get { return _payeeId; }    
        set { _payeeId = value; }    
    }    
    public string PayeeName    
    {    
        get { return _payeeName; }    
        set { _payeeName = value; }    
    }    
    public string PrintName    
    {    
        get { return _printName; }    
        set { _printName = value; }    
    }    
    public string Address    
    {    
        get { return _address; }    
        set { _address = value; }    
    }    
    public string City    
    {    
        get { return _city; }    
        set { _city = value; }    
    }    
    public string State    
    {    
        get { return _state; }    
        set { _state = value; }    
    }    
    public string Pincode    
    {    
        get { return _pincode; }    
        set { _pincode = value; }    
    }    
    public string Mobile    
    {    
        get { return _mobile; }    
        set { _mobile = value; }    
    }    
    public string Fax    
    {    
        get { return _fax; }    
        set { _fax = value; }    
    }    
    public string Email    
    {    
        get { return _email; }    
        set { _email = value; }    
    }    
    public string Website    
    {    
        get { return _website; }    
        set { _website = value; }    
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
