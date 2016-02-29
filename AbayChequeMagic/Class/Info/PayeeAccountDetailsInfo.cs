using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for PayeeAccountDetailsInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class PayeeAccountDetailsInfo    
{    
    private decimal _payeeAccountDetailsd;    
    private decimal _payeeId;    
    private string _bank;    
    private string _branch;    
    private string _accountNumber;    
    private string _accountType;    
    private string _contactNumber;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal PayeeAccountDetailsd    
    {    
        get { return _payeeAccountDetailsd; }    
        set { _payeeAccountDetailsd = value; }    
    }    
    public decimal PayeeId    
    {    
        get { return _payeeId; }    
        set { _payeeId = value; }    
    }    
    public string Bank    
    {    
        get { return _bank; }    
        set { _bank = value; }    
    }    
    public string Branch    
    {    
        get { return _branch; }    
        set { _branch = value; }    
    }    
    public string AccountNumber    
    {    
        get { return _accountNumber; }    
        set { _accountNumber = value; }    
    }    
    public string AccountType    
    {    
        get { return _accountType; }    
        set { _accountType = value; }    
    }    
    public string ContactNumber    
    {    
        get { return _contactNumber; }    
        set { _contactNumber = value; }    
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
