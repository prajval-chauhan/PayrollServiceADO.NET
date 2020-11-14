using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollServicesADO.NET_Day26
{
    public class EmployeeModel
    {
        public int empID { get; set; }
        public string name { get; set; }
        //public string PhoneNo { get; set; }
        public string officeAddress { get; set; }
        public string departmentName { get; set; }
        public int departmentID { get; set; }
        public string grade { get; set; }
        public string gender { get; set; }
        public double basicPay { get; set; }
        public double taxablePay { get; set; }
        //public double Deductions { get; set; }
        public double incomeTax { get; set; }
        public double netPay { get; set; }
        //public DateTime StartDate { get; set; }
        public string CompanyName { get; set; }
        //public string Country { get; set; }
    }
}
