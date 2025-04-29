using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestAdvanceCSharp
{
    abstract class Employee
    {
        public string Name { get; set; }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("Employee Name: " + Name);
        }

        public abstract double CalculateSalary();
    }

    class PermanentEmployee : Employee
    {
        public double BasicSalary { get; set; }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Type: Permanent");
        }

        public override double CalculateSalary()
        {
            return BasicSalary + (0.1 * BasicSalary); 
        }
    }

    class ContractEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Type: Contract");
        }

        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }

    class ReportGenerator
    {
        public void GenerateReport(Employee emp)
        {
            Console.WriteLine("Generating report for: " + emp.Name);
        }

        public void GenerateReport(Employee emp, string format)
        {
            Console.WriteLine($"Generating {format} report for: " + emp.Name);
        }
    }
}
