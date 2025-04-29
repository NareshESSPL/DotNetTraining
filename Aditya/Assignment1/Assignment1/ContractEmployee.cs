using System.Reflection;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeManagementSystem
{
    public class Contract_Employee : Employee
    {
        Abs_Contract_Employee contract_emp = new Abs_Contract_Employee();

        public override void EmployeeDetails()
        {
            Console.WriteLine("Contract_Employee Name - " + Name);
            Console.WriteLine("Contract Employee_ID - " + EmplyeeID);
            Console.WriteLine("Contract_Employee Age - " + age);
            Console.WriteLine("Contract_Employee Gender - " + Gender);
            Console.WriteLine("Contrcat_Employee Work Experience " + YearOfExperience + " years");
            Console.WriteLine("Contract_Employee Salary = " + contract_emp.CalculateSalary());
        }
    }
}