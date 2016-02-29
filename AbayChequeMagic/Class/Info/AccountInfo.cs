using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for AccountInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class AccountInfo    
{    
    private decimal _accountId;    
    private decimal _bankId;    
    private string _accountType;    
    private decimal _currentBalance;    
    private decimal _minimumBalance;    
    private string _accountHolderName;    
    private DateTime _createdDate;    
    private string _accountNumber;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal AccountId    
    {    
        get { return _accountId; }    
        set { _accountId = value; }    
    }    
    public decimal BankId    
    {    
        get { return _bankId; }    
        set { _bankId = value; }    
    }    
    public string AccountType    
    {    
        get { return _accountType; }    
        set { _accountType = value; }    
    }    
    public decimal CurrentBalance    
    {    
        get { return _currentBalance; }    
        set { _currentBalance = value; }    
    }    
    public decimal MinimumBalance    
    {    
        get { return _minimumBalance; }    
        set { _minimumBalance = value; }    
    }    
    public string AccountHolderName    
    {    
        get { return _accountHolderName; }    
        set { _accountHolderName = value; }    
    }    
    public DateTime CreatedDate    
    {    
        get { return _createdDate; }    
        set { _createdDate = value; }    
    }    
    public string AccountNumber    
    {    
        get { return _accountNumber; }    
        set { _accountNumber = value; }    
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
