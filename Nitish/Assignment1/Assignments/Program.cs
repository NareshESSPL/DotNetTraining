using Classes;

namespace Assignments
{
    class Program
    {
        static void Main()
        {
            Employee emp1 = new PermanentEmployee { Name = "Alice", Id = 101, MonthlySalary = 50000 };
            Employee emp2 = new ContractEmployee { Name = "Bob", Id = 102, HourlyRate = 200, HoursWorked = 100 };

            emp1.DisplayDetails(); // Virtual method
            Console.WriteLine($"Salary: {emp1.CalculateSalary()}"); // Abstract method

            emp2.DisplayDetails();
            Console.WriteLine($"Salary: {emp2.CalculateSalary()}");

            var report = new ReportGenerator();
            report.GenerateReport(emp1); // Overloaded method
            report.GenerateReport(emp2, "Detailed");
            report.GenerateReport(new List<Employee> { emp1, emp2 });
        }
    }

}
