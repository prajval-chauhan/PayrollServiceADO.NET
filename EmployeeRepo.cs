using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using EmployeePayrollServicesADO.NET_Day26;

namespace EmployeePayrollADO.NET_Day26
{
    public class EmployeeRepo
    {
        
        public static string connectionString = @"Server=DESKTOP-C457C73\SQLEXPRESS; Database=payroll_service; User Id=prajval;Password=gonfreecs";
        SqlConnection connection = new SqlConnection(connectionString);
        /// <summary>
        /// UC1: Connecting to the already existing databse        
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void CheckConnection()
        {
            try
            {
                using(this.connection)
                {
                    this.connection.Open();
                    this.connection.Close();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        /// <summary>
        /// UC2: Getting all the records from the database
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeemodel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"SELECT * FROM employee_details;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeemodel.empID = dr.GetInt32(0);
                            employeemodel.name = dr.GetString(1);
                            employeemodel.departmentID = dr.GetInt32(2);
                            employeemodel.grade = dr.GetString(3);
                            employeemodel.CompanyName = dr.GetString(4);
                            Console.WriteLine("{0},{1},{2},{3},{4}", employeemodel.empID, employeemodel.name, employeemodel.departmentID, employeemodel.grade, employeemodel.CompanyName);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
