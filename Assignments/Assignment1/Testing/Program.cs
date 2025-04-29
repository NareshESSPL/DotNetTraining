using EmployeeManagementSystem;

namespace EMSTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee peremp = new Permanent_Employee() { Name = "jayadev", age = 22, YearOfExperience = 2, EmplyeeID = 101, Gender = 'M', department = "HR" };
            Employee contemp = new Contract_Employee() { Name = "Soumya", age = 22, YearOfExperience = 1, EmplyeeID = 230, Gender = 'M', department = "IT" };
            ReportGenerator reportGenerator = new ReportGenerator(peremp, contemp);
            reportGenerator.GenerateReport();
            reportGenerator.GenerateReport("Permanent");
            reportGenerator.GenerateReport("Contract", contemp.department);


        }
    }
}

