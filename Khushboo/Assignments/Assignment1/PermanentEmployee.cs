using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignments.Assignment1
{
    public class PermanentEmployee : Employee
    {
        public double BasicPay { get; set; }

        public override void ShowDetails()
        {
            Console.WriteLine($"[Permanent] ID: {Id}, Name: {Name}, Basic Pay: {BasicPay}");
        }

        public override double CalculateSalary()
        {
            return BasicPay + 5000; // Adding fixed allowance
        }
    }
}

