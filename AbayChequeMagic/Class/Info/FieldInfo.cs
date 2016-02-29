using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for FieldInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class FieldInfo    
{    
    private decimal _fieldId;    
    private string _fieldName;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal FieldId    
    {    
        get { return _fieldId; }    
        set { _fieldId = value; }    
    }    
    public string FieldName    
    {    
        get { return _fieldName; }    
        set { _fieldName = value; }    
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
