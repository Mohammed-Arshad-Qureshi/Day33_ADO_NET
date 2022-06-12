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
                    Console.WriteLine("Connection Established Successfully !!");
                }
            }
        }
    }
}
