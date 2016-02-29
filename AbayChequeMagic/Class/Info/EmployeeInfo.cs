using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace AbayChequeMagic
{
    class EmployeeInfo
    {
        private decimal _employeeId;
        private string _employeeCode;
        private string _employeeName;
        private string _designation;
        private string _contactNumber;

        public decimal EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }
        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }

        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

    }
}
