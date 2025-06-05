using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class HumanResource
    {
        public employee emptype;

        public HumanResource(string Emptype)
        {
            if (Emptype=="ContractEmployee")
            {
                emptype = new contractEmp();
            }
            else
            {
                emptype = new permanentEmp();
            }
        }

        public double calculateFinalSalary()
        {
            int noOfDays = emptype.CalnoOfDays(emptype.totalDays);
            double salary = emptype.calculateSalary(noOfDays);
            return noOfDays * salary;
        }

        public double calculateFinalSalary(double pfa)
        {
            int noOfDays = emptype.CalnoOfDays(emptype.totalDays);
            double salary = emptype.calculateSalary(noOfDays);
            return noOfDays * salary * pfa;
        }
    }
}
