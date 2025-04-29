namespace Assignment1
{
    internal class Program
    {
        public abstract class Employee
        {
            public string Name { get; set; }
            public int Id { get; set; }

            public Employee(string name, int id)
            {
                Name = name;
                Id = id;
            }

            
            public virtual void DisplayInfo()
            {
                Console.WriteLine($"Employee ID: {Id}, Name: {Name}");
            }

            
            public abstract decimal CalculateSalary();
        }

        
        public class PermanentEmployee : Employee
        {
            public decimal BasicSalary { get; set; }

            public PermanentEmployee(string name, int id, decimal basicSalary)
                : base(name, id)
            {
                BasicSalary = basicSalary;
            }

            
            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine("Employee Type: Permanent");
            }

            
            public override decimal CalculateSalary()
            {
                return BasicSalary + 2000; 
            }
        }

        
        public class ContractEmployee : Employee
        {
            public int HoursWorked { get; set; }
            public decimal HourlyRate { get; set; }

            public ContractEmployee(string name, int id, int hours, decimal rate)
                : base(name, id)
            {
                HoursWorked = hours;
                HourlyRate = rate;
            }

            
            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine("Employee Type: Contract");
            }

            
            public override decimal CalculateSalary()
            {
                return HoursWorked * HourlyRate;
            }
        }

        
        public class ReportGenerator
        {
            public void GenerateReport(Employee employee)
            {
                Console.WriteLine($"Report for {employee.Name}");
            }

            public void GenerateReport(Employee employee, string format)
            {
                Console.WriteLine($"Report for {employee.Name} in {format} format");
            }

            public void GenerateReport(List<Employee> employees)
            {
                Console.WriteLine("Generating reports for all employees...");
                foreach (var emp in employees)
                {
                    GenerateReport(emp);
                }
            }
        }
    }
}
