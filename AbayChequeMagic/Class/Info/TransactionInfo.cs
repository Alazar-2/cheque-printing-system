using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for TransactionInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class TransactionInfo    
{    
    private decimal _transactionId;    
    private decimal _accountId;    
    private string _transactionNumber;    
    private DateTime _transactionDate;    
    private decimal _amount;    
    private string _transactionType;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal TransactionId    
    {    
        get { return _transactionId; }    
        set { _transactionId = value; }    
    }    
    public decimal AccountId    
    {    
        get { return _accountId; }    
        set { _accountId = value; }    
    }    
    public string TransactionNumber    
    {    
        get { return _transactionNumber; }    
        set { _transactionNumber = value; }    
    }    
    public DateTime TransactionDate    
    {    
        get { return _transactionDate; }    
        set { _transactionDate = value; }    
    }    
    public decimal Amount    
    {    
        get { return _amount; }    
        set { _amount = value; }    
    }    
    public string TransactionType    
    {    
        get { return _transactionType; }    
        set { _transactionType = value; }    
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
