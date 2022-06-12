using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRoll
{
    class EmployeeRepo
    {
        public static string ConnectionString = "Server=ARSHAD-LAP; Initial Catalog=PayRole_Service; Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionString);
        public void GetAllEmployees()
        {
            EmployeeModel employeeModel = new EmployeeModel();

           
            using (this.connection)
            {
                string query = @"Select * from Employee_PayRoll_table";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                this.connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        employeeModel.EmployeeId = dr.GetInt32(0);
                        employeeModel.EmployeeName = dr.GetString(1);
                        employeeModel.Phone_Number = Convert.ToInt64(dr[2] is DBNull ? 0 : dr[2]);
                        employeeModel.Address = Convert.ToString(dr[3]) is DBNull ? string.Empty : dr[3].ToString();
                        employeeModel.Department = dr.GetString(4);
                        employeeModel.Gender = Convert.ToString(dr[5]) is DBNull ? string.Empty : dr[5].ToString();
                        employeeModel.Basic_Pay = dr.GetDouble(6);
                        employeeModel.Deductions = dr.GetDouble(7);
                        employeeModel.Taxable_Pay = dr.GetDouble(8);
                        employeeModel.Tax = dr.GetDouble(9);
                        employeeModel.Net_Pay = dr.GetDouble(10);
                        employeeModel.StartDate = dr.GetDateTime(11);
                        employeeModel.City = dr.GetString(12);
                        employeeModel.Country = dr.GetString(13);

                        Console.WriteLine("EmoloyeeId      :  " + employeeModel.EmployeeId);
                        Console.WriteLine("EmoloyeeName    :  " + employeeModel.EmployeeName);
                        Console.WriteLine("Phone_Number    :  " + employeeModel.Phone_Number);
                        Console.WriteLine("Address         :  " + employeeModel.Address);
                        Console.WriteLine("Department      :  " + employeeModel.Department);
                        Console.WriteLine("Gender          :  " + employeeModel.Gender);
                        Console.WriteLine("Basic_Pay       :  " + employeeModel.Basic_Pay);
                        Console.WriteLine("Deductions      :  " + employeeModel.Deductions);
                        Console.WriteLine("Taxable_Pay     :  " + employeeModel.Taxable_Pay);
                        Console.WriteLine("Tax             :  " + employeeModel.Tax);
                        Console.WriteLine("Net_Pay         :  " + employeeModel.Net_Pay);
                        Console.WriteLine("StartDate       :  " + employeeModel.StartDate);
                        Console.WriteLine("City            :  " + employeeModel.City);
                        Console.WriteLine("Country         :  " + employeeModel.Country + "\n\n");
                    }
                }
            }
        }
    }
}
