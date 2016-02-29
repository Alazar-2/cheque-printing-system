using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for ChequeLayoutInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class ChequeLayoutInfo    
{    
    private decimal _layoutId;    
    private decimal _dateFormatId;    
    private string _layoutName;    
    private string _imageLocation;
    private string _dateSpacing;
    private bool _payeeLineTwo;
    private bool _amountInWordsTwo;     
    
    public decimal LayoutId    
    {    
        get { return _layoutId; }    
        set { _layoutId = value; }    
    }    
    public decimal DateFormatId    
    {    
        get { return _dateFormatId; }    
        set { _dateFormatId = value; }    
    }    
    public string LayoutName    
    {    
        get { return _layoutName; }    
        set { _layoutName = value; }    
    }    
    public string ImageLocation    
    {    
        get { return _imageLocation; }    
        set { _imageLocation = value; }    
    }    
    public string DateSpacing    
    {    
        get { return _dateSpacing; }
        set { _dateSpacing = value; }    
    }
    public bool PayeeLineTwo
    {
        get { return _payeeLineTwo; }
        set { _payeeLineTwo = value; }
    }
    public bool AmountInWordsTwo
    {
        get { return _amountInWordsTwo; }
        set { _amountInWordsTwo = value; }
    }    
    
}    
}
