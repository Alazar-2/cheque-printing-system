using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for DimensionInfo    
//</summary>    
namespace AbayChequeMagic    
{    
class DimensionInfo    
{    
    private decimal _dimensionId;    
    private decimal _layoutId;    
    private decimal _fieldId;    
    private float _xAxis;    
    private float _yAxis;    
    private float _width;    
    private float _height;    
    //private string _extraOne;    
    //private string _extraTwo;    
    
    public decimal DimensionId    
    {    
        get { return _dimensionId; }    
        set { _dimensionId = value; }    
    }    
    public decimal LayoutId    
    {    
        get { return _layoutId; }    
        set { _layoutId = value; }    
    }    
    public decimal FieldId    
    {    
        get { return _fieldId; }    
        set { _fieldId = value; }    
    }    
    public float XAxis    
    {    
        get { return _xAxis; }    
        set { _xAxis = value; }    
    }    
    public float YAxis    
    {    
        get { return _yAxis; }    
        set { _yAxis = value; }    
    }    
    public float Width    
    {    
        get { return _width; }    
        set { _width = value; }    
    }    
    public float Height    
    {    
        get { return _height; }    
        set { _height = value; }    
    }    
    //public string ExtraOne    
    //{    
    //    get { return _extraOne; }    
    //    set { _extraOne = value; }    
    //}    
    //public string ExtraTwo    
    //{    
    //    get { return _extraTwo; }    
    //    set { _extraTwo = value; }    
    //}    
    
}    
}
