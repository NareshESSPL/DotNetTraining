using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    /// <summary>
    /// this key word is used to call one constructor from another in the same class
    /// </summary>
    public class Employee
    {
        public int EmployeeID { get; }
        public string Name { get; }
        public string Department { get; }
        public double Salary { get; }

        // Default constructor
        public Employee() : this(0, "Unknown", "Not Assigned", 0.0) { }

        // Constructor with Employee ID
        public Employee(int employeeID) : this(employeeID, "Unknown", "Not Assigned", 0.0) { }

        // Constructor with Employee ID and Name
        public Employee(int employeeID, string name) : this(employeeID, name, "Not Assigned", 0.0) { }

        // Constructor with all parameters
        public Employee(int employeeID, string name, string department, double salary)
        {
            EmployeeID = employeeID;
            Name = name;
            Department = department;
            Salary = salary;
        }
    }


    /// <summary>
    /// this key word is used to call one constructor from child class comnstructor in base class
    /// </summary>
    public class ContractEmployee : Employee
    {
        public ContractEmployee(int employeeID, string name):base(employeeID, name) 
        {
        }
    }

}
