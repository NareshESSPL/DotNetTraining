using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class contractEmp : employee
    {
        public contractEmp()
        {
            totalDays = 20;
        }
        public override double calculateSalary(int noOfdaysAttendance)
        {
            double salary = defaultSalary * noOfdaysAttendance - 5000;
            return salary;
        }
    }
    
}
