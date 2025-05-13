
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignments.Assignment1
    {
        public abstract class Employee
        {
            public string Name { get; set; }
            public int Id { get; set; }

            // Virtual method
            public virtual void ShowDetails()
            {
                Console.WriteLine($"Employee ID: {Id}, Name: {Name}");
            }

            // Abstract method
            public abstract double CalculateSalary();

            // Overloaded methods
            public void GenerateReport()
            {
                Console.WriteLine("General employee report.");
            }

            public void GenerateReport(string department)
            {
                Console.WriteLine($"Report for Department: {department}");
            }

            public void GenerateReport(int employeeId)
            {
                Console.WriteLine($"Report for Employee ID: {employeeId}");
            }
        }
    }


