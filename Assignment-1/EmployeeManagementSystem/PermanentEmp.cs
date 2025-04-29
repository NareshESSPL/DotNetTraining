using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
     public class PermanentEmployee : Employee
    {   
        Abs_Permanent_Employee  Permanent_Employee = new Abs_Permanent_Employee();
       
        public override void EmployeeDetails()
        {
            Console.WriteLine("Permanent_Employee Name - " + Name);
            Console.WriteLine("Permanent Employee_ID - "+ EmplyeeID);
            Console.WriteLine("Permanent_Employee Age - "+ age);
            Console.WriteLine("Permanent_Employee Gender - "+ Gender);
            Console.WriteLine("Permanent_Employee Work Experience "+ YearOfExperience + " years");
            Console.WriteLine("Permanent_Employee Salary = "+ Permanent_Employee.CalculateSalary());
        }
    }
}
