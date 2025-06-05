using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public  abstract class employee
    {
        public int Eid { get; set; }
        public string   EName { get; set; }

        public int totalDays { get; set; } 

        public double defaultSalary { get; set; } = 20000;

        public  int CalnoOfDays(int totalDays)
        {
            int count = 0;
            for(int i = 1; i <=totalDays ; i++)
            {
                if (i % 7 != 0)
                {
                    count++;
                }

            }
            return count;                                                                                                       `1  
        }

        public abstract double calculateSalary(int noOfdaysAttendance);
       
    }
}
