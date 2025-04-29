using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class ReportGenerator : Employee
    {    
        Employee obj = new PermanentEmployee();
        Employee obj2 = new Contract_Employee();
        public ReportGenerator(Employee obj,Employee obj2) { 
            this.obj = obj;
            this.obj2 = obj2;
        }
        public void GenerateReport()
        {   

            Console.WriteLine("Generating Basic Employee Report......");

        }
        public void GenerateReport(String EmplyeeType)
        {
            switch (EmplyeeType)
            {
                case "Permanent":
                    Console.WriteLine($"generating report for {EmplyeeType} Employees.......");
                    obj.EmployeeDetails();
                    break;
                case "Contract":
                    Console.WriteLine($"generating report for {EmplyeeType} Employees........");
                    obj2.EmployeeDetails();
                    break;
                default:
                    Console.WriteLine("Not a valid type");
                    break;
            }
        }
        public void GenerateReport(string EmplyeeType,string department)
        {
            switch (EmplyeeType)
            {
                case "Permanent":
                    switch (obj.department) {
                        case "IT":
                            Console.WriteLine($"generating report for {EmplyeeType} Employees with {obj.department} department.......");
                            obj.EmployeeDetails();
                            Console.WriteLine($"Permanent_Employee department - {obj.department}");
                            break;
                        case "HR":
                            Console.WriteLine($"generating report for {EmplyeeType} Employees with {obj.department} department.......");
                            obj.EmployeeDetails();
                            Console.WriteLine($"Permanent_Employee department - {obj.department}");
                            break;
                        default: Console.WriteLine("Not a valid department");
                            break;
                    }
                    break;
                case "Contract":
                    switch (obj2.department)
                    {
                        case "IT":
                            Console.WriteLine($"generating report for {EmplyeeType} Employees with {obj2.department} department.......");
                            obj2.EmployeeDetails();
                            Console.WriteLine($"Permanent_Employee department - {obj2.department}");
                            break;
                        case "HR":
                            Console.WriteLine($"generating report for {EmplyeeType} Employees with {obj2.department} department.......");
                            obj2.EmployeeDetails();
                            Console.WriteLine($"Permanent_Employee department - {obj2.department}");
                            break;
                        default:
                            Console.WriteLine("Not a valid department");
                            break;
                    }
                    break;
                default: Console.WriteLine("Not a valid Employee Type");
                    break ;

            }
        }


    }
}

