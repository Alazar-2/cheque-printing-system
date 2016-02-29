using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for ExpenseInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class ExpenseInfo    
{    
    private decimal _expenseId;    
    private string _expenseName;    
    private string _extraOne;    
    private string _extraTwo;    
    
    public decimal ExpenseId    
    {    
        get { return _expenseId; }    
        set { _expenseId = value; }    
    }    
    public string ExpenseName    
    {    
        get { return _expenseName; }    
        set { _expenseName = value; }    
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
