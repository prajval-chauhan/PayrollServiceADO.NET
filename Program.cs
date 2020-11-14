using System;

namespace EmployeePayrollADO.NET_Day26
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo call = new EmployeeRepo();
            Console.WriteLine("Welcome to the payroll service");
            //call.CheckConnection();
            //call.GetAllEmployee();
            call.UpdatingEmployeeRecords();
        }
    }
}
