namespace Classes
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }

        // Virtual Method
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee: {Name}, ID: {Id}");
        }

        // Abstract Method
        public abstract double CalculateSalary();
    }

    public class PermanentEmployee : Employee
    {
        public double MonthlySalary { get; set; }

        // Override virtual method
        public override void DisplayDetails()
        {
            Console.WriteLine($"Permanent Employee: {Name}, ID: {Id}");
        }

        // Implement abstract method
        public override double CalculateSalary()
        {
            return MonthlySalary;
        }
    }
    public class ContractEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        // Override virtual method
        public override void DisplayDetails()
        {
            Console.WriteLine($"Contract Employee: {Name}, ID: {Id}");
        }

        // Implement abstract method
        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }
    public class ReportGenerator
    {
        public void GenerateReport(Employee emp)
        {
            Console.WriteLine($"Generating report for {emp.Name}");
        }

        public void GenerateReport(Employee emp, string reportType)
        {
            Console.WriteLine($"Generating {reportType} report for {emp.Name}");
        }

        public void GenerateReport(List<Employee> employees)
        {
            Console.WriteLine($"Generating summary report for {employees.Count} employees.");
        }
    }


}
