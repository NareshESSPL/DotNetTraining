using System;

public class Employees
{
    private int _employeeId;
    private string _name;
    private decimal _salary;

    public void SetEmployeeDetails(int id, string name, decimal salary)
    {
        _employeeId = id;
        _name = name;
        _salary = salary;
    }

    public void GetEmployeeDetails()
    {
        Console.WriteLine($"ID: {_employeeId}, Name: {_name}, Salary: {_salary}");
    }
}

 

