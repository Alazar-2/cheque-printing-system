using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for AuthorizedSignatoryInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class AuthorizedSignatoryInfo    
{
    private decimal _authorizedSignatoryId;    
    private string _signatoryDesignation;    
    private string _signatureName;    
    private byte[] _signatureStamp;    
    private string _extraOne;    
    private string _extraTwo;

    public decimal AuthorizedSignatoryId
    {
        get { return _authorizedSignatoryId; }
        set { _authorizedSignatoryId = value; }
    }    
    public string SignatoryDesignation    
    {    
        get { return _signatoryDesignation; }    
        set { _signatoryDesignation = value; }    
    }    
    public string SignatureName    
    {    
        get { return _signatureName; }    
        set { _signatureName = value; }    
    }    
    public byte[] SignatureStamp    
    {    
        get { return _signatureStamp; }    
        set { _signatureStamp = value; }    
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
