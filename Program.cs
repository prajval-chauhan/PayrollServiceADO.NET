using EmployeePayrollServicesADO.NET_Day26;
using System;

namespace EmployeePayrollADO.NET_Day26
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo call = new EmployeeRepo();
            EmployeeModel model = new EmployeeModel();
            model.empID = 1;
            model.grade = "A1";
            Console.WriteLine("Welcome to the payroll service");
            //call.CheckConnection();
            //call.GetAllEmployee();
            //call.UpdatingEmployeeRecords();
            call.UpdatingDetailsUsingStoredProcedure(model);
        }
    }
}
