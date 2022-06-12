 using System;

namespace EmployeePayRoll
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            repo.GetAllEmployees();
        }
    }
}
