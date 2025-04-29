using EmployeeManagementSystem;

namespace EMSTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee per = new Permanent_Employee() { Name = "om", age = 12, YearOfExperience = 2, EmplyeeID = 199, Gender = 'M', department = "ECE" };
            Employee cont = new Contract_Employee() { Name = "ram", age = 78, YearOfExperience = 1, EmplyeeID = 930, Gender = 'M', department = "ITI" };
            ReportGenerator reportGenerator = new ReportGenerator(peremp, contemp);
            reportGenerator.GenerateReport();
            reportGenerator.GenerateReport("Permanent");
            reportGenerator.GenerateReport("Contract", cont.department);


        }
    }
}

