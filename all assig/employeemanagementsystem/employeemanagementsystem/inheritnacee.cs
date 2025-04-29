using System;
 

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }

    public void DisplayEmployee()
    {
        Console.WriteLine($"ID: {EmployeeId}, Name: {Name}");
    }
    public virtual void CalculateSalary()
    {
        
    }
}

public class PermanentEmployee : Employee
{
    public decimal BasicSalary { get; set; }
}

public class ContractEmployee : Employee
{
    public decimal HourlyRate { get; set; }
}

class Programs
{
    static void Main()
    {
        PermanentEmployee pe = new PermanentEmployee { EmployeeId = 1, Name = "Alice", BasicSalary = 60000 };
        ContractEmployee ce = new ContractEmployee { EmployeeId = 2, Name = "Bob", HourlyRate = 400 };

        pe.DisplayEmployee();
        Console.WriteLine($"Basic Salary: {pe.BasicSalary}");

        ce.DisplayEmployee();
        Console.WriteLine($"Hourly Rate: {ce.HourlyRate}");
    }
}

