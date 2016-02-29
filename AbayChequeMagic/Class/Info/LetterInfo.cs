using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for LetterInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class LetterInfo    
{    
    private decimal _letterId;    
    private string _description;    
    private string _letterType;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal LetterId    
    {    
        get { return _letterId; }    
        set { _letterId = value; }    
    }    
    public string Description    
    {    
        get { return _description; }    
        set { _description = value; }    
    }    
    public string LetterType    
    {    
        get { return _letterType; }    
        set { _letterType = value; }    
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
