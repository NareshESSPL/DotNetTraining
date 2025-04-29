using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class Test
    {
        public void testing ()
        {
            string empType = "ContractEmployee";
            HumanResource humanResource = new HumanResource("ContractEmployee");
            double salary = humanResource.calculateFinalSalary();
            double salaryWithPfa = humanResource.calculateFinalSalary(500);
            Console.WriteLine("the salary of " + empType + " is :" + salary);
            Console.WriteLine("the salary with pfa " + empType + " is:" + salaryWithPfa);

            empType = "PermanentEmployee";
            humanResource = new HumanResource("PermanentEmployee");
            double salary1 = humanResource.calculateFinalSalary();
            double salaryWithPfa1 = humanResource.calculateFinalSalary(500);
            Console.WriteLine("the salary of " + empType + "is :" + salary1);
            Console.WriteLine("the salary with pfa " + empType + "is:" + salaryWithPfa1);
        }
    }
}
