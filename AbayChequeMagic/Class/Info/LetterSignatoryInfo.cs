using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for LetterSignatoryInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class LetterSignatoryInfo    
{
    private decimal _letterSignatoryId;    
    private string _signatoryDesignation;    
    private string _letterSignatoryName;    
    private byte[] _letterSignatoryStamp;    
    private bool _printLetterSignatory;    
    private string _extraOne;    
    private string _extraTwo;

    public decimal LetterSignatoryId
    {
        get { return _letterSignatoryId; }
        set { _letterSignatoryId = value; }
    }    
    public string SignatoryDesignation    
    {    
        get { return _signatoryDesignation; }    
        set { _signatoryDesignation = value; }    
    }    
    public string LetterSignatoryName    
    {    
        get { return _letterSignatoryName; }    
        set { _letterSignatoryName = value; }    
    }    
    public byte[] LetterSignatoryStamp    
    {    
        get { return _letterSignatoryStamp; }    
        set { _letterSignatoryStamp = value; }    
    }    
    public bool PrintLetterSignatory    
    {    
        get { return _printLetterSignatory; }    
        set { _printLetterSignatory = value; }    
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
