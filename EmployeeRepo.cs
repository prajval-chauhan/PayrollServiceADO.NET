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
                            employeemodel.gender = dr.GetString(5);
                            Console.WriteLine("empID: {0},\tname: {1},\tdepartmentID: {2},\tSalary grade: {3},\tCompany: {4},\tgender: {5}", 
                                employeemodel.empID, employeemodel.name, employeemodel.departmentID, employeemodel.grade, employeemodel.CompanyName, employeemodel.gender);
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
        /// <summary>
        /// UC3: Updatings the employee records without using stored procedure
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void UpdatingEmployeeRecords()
        {
            EmployeeModel employeemodel = new EmployeeModel();
            try
            {
                using (this.connection)
                {
                    string query = @"UPDATE employee_details set grade = 'A1' where empId = 1;UPDATE employee_details set grade = 'A2' where empId = 2;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    this.connection.Close();
                    GetAllEmployee();
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
        public bool UpdatingDetailsUsingStoredProcedure(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateEmployeeSalaryDetails", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empID", model.empID);
                    cmd.Parameters.AddWithValue("@grade", model.grade);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    GetAllEmployee();
                    if (result != 0)
                        return true;
                    return false;
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
