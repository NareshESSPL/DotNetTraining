using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DTO
{
    public class Employees
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Full name"), Required(ErrorMessage = "plese enter a valid Name")]

        public  string ? EmployeeName { get; set; }

        public int EmployeeAge { get; set; }

        [Display(Name = "Gender"), Required(ErrorMessage = "plese enter a gender")]

        public string ? EmployeeGender { get; set; }
    }
}
