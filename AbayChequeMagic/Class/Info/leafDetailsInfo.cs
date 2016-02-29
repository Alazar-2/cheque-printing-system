using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for leafDetailsInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class leafDetailsInfo    
{    
    private decimal _leafDetailsId;    
    private decimal _leafId;    
    private decimal _payeeId;    
    private decimal _expenseId;    
    private string _chequeLeafNumber;    
    private DateTime _issuedDate;    
    private decimal _amount;    
    private DateTime _currentDate;    
    private string _extraOne;    
    private string _extraTwo;
    private decimal _payeeAccountDetailsd;

    public decimal PayeeAccountDetailsd
    {
        get { return _payeeAccountDetailsd; }
        set { _payeeAccountDetailsd = value; }
    }  
    public decimal LeafDetailsId    
    {    
        get { return _leafDetailsId; }    
        set { _leafDetailsId = value; }    
    }    
    public decimal LeafId    
    {    
        get { return _leafId; }    
        set { _leafId = value; }    
    }    
    public decimal PayeeId    
    {    
        get { return _payeeId; }    
        set { _payeeId = value; }    
    }    
    public decimal ExpenseId    
    {    
        get { return _expenseId; }    
        set { _expenseId = value; }    
    }    
    public string ChequeLeafNumber    
    {    
        get { return _chequeLeafNumber; }    
        set { _chequeLeafNumber = value; }    
    }    
    public DateTime IssuedDate    
    {    
        get { return _issuedDate; }    
        set { _issuedDate = value; }    
    }    
    public decimal Amount    
    {    
        get { return _amount; }    
        set { _amount = value; }    
    }    
    public DateTime CurrentDate    
    {    
        get { return _currentDate; }    
        set { _currentDate = value; }    
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
