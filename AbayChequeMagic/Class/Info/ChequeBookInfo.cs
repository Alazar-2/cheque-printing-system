using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for ChequeBookInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class ChequeBookInfo    
{    
    private decimal _chequeBookId;    
    private decimal _accountId;    
    private decimal _layoutId;    
    private int _numberOfChequeLeaves;
    private string _chequeBookName;
    private string _startNumber;
    private string _endNumber;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal ChequeBookId    
    {    
        get { return _chequeBookId; }    
        set { _chequeBookId = value; }    
    }    
    public decimal AccountId    
    {    
        get { return _accountId; }    
        set { _accountId = value; }    
    }    
    public decimal LayoutId    
    {    
        get { return _layoutId; }    
        set { _layoutId = value; }    
    }    
    public int NumberOfChequeLeaves    
    {    
        get { return _numberOfChequeLeaves; }    
        set { _numberOfChequeLeaves = value; }    
    }
    public string ChequeBookName
    {
        get { return _chequeBookName; }
        set { _chequeBookName = value; }
    }
    public string StartNumber    
    {    
        get { return _startNumber; }    
        set { _startNumber = value; }    
    }
    public string EndNumber    
    {    
        get { return _endNumber; }    
        set { _endNumber = value; }    
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
