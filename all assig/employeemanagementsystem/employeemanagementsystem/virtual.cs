using System;

public class Employeess
{
    public string Name { get; set; }

    public virtual void CalculateSalary()
    {
        Console.WriteLine("Calculating general salary for employee...");
    }
}

public class PermanentEmployees : Employee
{
    public override void CalculateSalary()
    {
        Console.WriteLine("Calculating salary for Permanent Employee with benefits...");
    }
}

public class ContractEmployees : Employee
{
    public override void CalculateSalary()
    {
        Console.WriteLine("Calculating salary for Contract Employee based on hours...");
    }
}

 

