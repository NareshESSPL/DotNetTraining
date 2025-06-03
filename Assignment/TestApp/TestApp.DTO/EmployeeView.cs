using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DTO
{
    public class EmployeeView
    {
        public Employee EmployeeSingle;  
        
        public List<Employee> EmployeeList;
        public EmployeeView() 
        {
            EmployeeList = new List<Employee>();
        }
    }
}
