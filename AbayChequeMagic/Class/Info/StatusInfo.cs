using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for StatusInfo    
//</summary>    
namespace AbayChequeMagic    
{    
    // Edited by Ansar. Signatory stamp added.
class StatusInfo    
{    
    private decimal _statusId;    
    private decimal _leafId;    
    private bool _forCompany;    
    private bool _signatoryName;    
    private bool _accountNumber;    
    private bool _bearerStrike;    
    private bool _accountPayee;    
    private bool _nonNegotiable;    
    private bool _payableAtPar;    
    private bool _notAbove;    
    private bool _payeeNameSuffix;    
    private bool _amountSuffix;    
    private bool _amountInWordsSuffix;    
    private bool _allowPostDatedCheque;    
    private bool _allowPreDatedCheque;    
    private bool _allowBlankAmountCheque;    
    private bool _allowBlankPayeeCheque;    
    private bool _payeeAccountDetails;    
    private bool _amountPrefix;    
    private bool _payeeLineTwo;
    private bool _amountInWordsTwo;    
    private string _extraOne;    
    private string _extraTwo;
    private bool _signatoryStamp;
    
    public decimal StatusId    
    {    
        get { return _statusId; }    
        set { _statusId = value; }    
    }    
    public decimal LeafId    
    {    
        get { return _leafId; }    
        set { _leafId = value; }    
    }    
    public bool ForCompany    
    {    
        get { return _forCompany; }    
        set { _forCompany = value; }    
    }    
    public bool SignatoryName    
    {    
        get { return _signatoryName; }    
        set { _signatoryName = value; }    
    }    
    public bool AccountNumber    
    {    
        get { return _accountNumber; }    
        set { _accountNumber = value; }    
    }    
    public bool BearerStrike    
    {    
        get { return _bearerStrike; }    
        set { _bearerStrike = value; }    
    }    
    public bool AccountPayee    
    {    
        get { return _accountPayee; }    
        set { _accountPayee = value; }    
    }    
    public bool NonNegotiable    
    {    
        get { return _nonNegotiable; }    
        set { _nonNegotiable = value; }    
    }    
    public bool PayableAtPar    
    {    
        get { return _payableAtPar; }    
        set { _payableAtPar = value; }    
    }    
    public bool NotAbove    
    {    
        get { return _notAbove; }    
        set { _notAbove = value; }    
    }    
    public bool PayeeNameSuffix    
    {    
        get { return _payeeNameSuffix; }    
        set { _payeeNameSuffix = value; }    
    }    
    public bool AmountSuffix    
    {    
        get { return _amountSuffix; }    
        set { _amountSuffix = value; }    
    }    
    public bool AmountInWordsSuffix    
    {    
        get { return _amountInWordsSuffix; }    
        set { _amountInWordsSuffix = value; }    
    }    
    public bool AllowPostDatedCheque    
    {    
        get { return _allowPostDatedCheque; }    
        set { _allowPostDatedCheque = value; }    
    }    
    public bool AllowPreDatedCheque    
    {    
        get { return _allowPreDatedCheque; }    
        set { _allowPreDatedCheque = value; }    
    }    
    public bool AllowBlankAmountCheque    
    {    
        get { return _allowBlankAmountCheque; }    
        set { _allowBlankAmountCheque = value; }    
    }    
    public bool AllowBlankPayeeCheque    
    {    
        get { return _allowBlankPayeeCheque; }    
        set { _allowBlankPayeeCheque = value; }    
    }    
    public bool PayeeAccountDetails    
    {    
        get { return _payeeAccountDetails; }    
        set { _payeeAccountDetails = value; }    
    }    
    public bool AmountPrefix    
    {    
        get { return _amountPrefix; }    
        set { _amountPrefix = value; }    
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
    public bool SignatoryStamp
    {
        get { return _signatoryStamp; }
        set { _signatoryStamp = value; }
    } 
    
}    
}
