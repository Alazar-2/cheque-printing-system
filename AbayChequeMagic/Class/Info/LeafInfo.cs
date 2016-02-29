using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for LeafInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class LeafInfo    
{    
    private decimal _leafId;    
    private decimal _chequeBookId;    
    private string _chequeStatus;    
    private bool _isPrinted;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal LeafId    
    {    
        get { return _leafId; }    
        set { _leafId = value; }    
    }    
    public decimal ChequeBookId    
    {    
        get { return _chequeBookId; }    
        set { _chequeBookId = value; }    
    }    
    public string ChequeStatus    
    {    
        get { return _chequeStatus; }    
        set { _chequeStatus = value; }    
    }    
    public bool IsPrinted    
    {    
        get { return _isPrinted; }    
        set { _isPrinted = value; }    
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
