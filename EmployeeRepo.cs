using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace EmployeePayrollADO.NET_Day26
{
    public class EmployeeRepo
    {
        //UC1: Connecting to the already existing databse
        public static string connectionString = @"Server=DESKTOP-C457C73\SQLEXPRESS; Database=payroll_service; User Id=prajval;Password=gonfreecs";
        SqlConnection connection = new SqlConnection(connectionString);
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
    }
}
