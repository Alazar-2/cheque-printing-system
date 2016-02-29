using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AbayChequeMagic
{
    class AutorisedImageInfo
    {
        private decimal _authorizedSignatoryId;
        private string _signatoryDesignation;
        private string _signatureName;
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
