using System;
using System.Collections.Generic;
using System.Text;

namespace AbayChequeMagic
{
    public class CurrencyInfo
    {
        private decimal _currencyId;
        private string _currencyName;
        private string _fractionalPart;

        public decimal currencyId
        {
            get
            {
                return _currencyId;
            }
            set
            {
                _currencyId = value;
            }       
        }
        public string currencyName
        {
            get
            {
                return _currencyName;
            }
            set
            {
                _currencyName = value;
            }
        }
        public string fractionalPart
        {
            get
            {
                return _fractionalPart;
            }
            set
            {
                _fractionalPart = value;
            }
        }
    }
}
