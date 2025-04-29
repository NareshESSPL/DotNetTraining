using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class Abs_Permanent_Employee : Abstract_Employee
    {
        public override decimal CalculateSalary()
        {
            return 35000m;
        }
    }
}