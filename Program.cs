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
            model.grade = "A3";
            model.name = "Naman";
            model.departmentID = 333;
            model.gender = "M";
            model.CompanyName = "XYZ";
            model.empID = 5;
            model.start_date = Convert.ToDateTime("2020/11/20");
            Console.WriteLine("Welcome to the payroll service");
            //call.CheckConnection();
            //call.GetAllEmployee();
            //call.UpdatingEmployeeRecords();
            //call.UpdatingDetailsUsingStoredProcedure(model);
            //call.RetrievingEmployeesInACertainDateRange();
            //call.PerformMathematicalOperations();
            call.AddEmployee(model);
        }
    }
}
