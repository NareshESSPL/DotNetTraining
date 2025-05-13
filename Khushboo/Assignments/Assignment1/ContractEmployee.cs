
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Assignments.Assignment1
{
    public class ContractEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public override void ShowDetails()
        {
            Console.WriteLine($"[Contract] ID: {Id}, Name: {Name}, Rate: {HourlyRate}, Hours: {HoursWorked}");
        }

        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }
}

