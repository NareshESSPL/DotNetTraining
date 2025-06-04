using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TestApp.DTO
{
    public class Employee
    {
        public int Id { get; set; } = 0;

        [Display(Name = "FullName"), Required(ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }

        [Range(18, 60, ErrorMessage = "Age must be between 18 to 65")]
        public int Age { get; set; }

        public int Gender { get; set; }

        public string Description { get; set; }

        public int Rank { get; set; }

        public string Grade { get; set; }

        public List<int> SelectedBenefits { get; set; }
               
        public string FileName { get; set; }

        public IFormFile EmployeeImage { get; set; }

        public byte[] IDImageAsByteArray { get; set; }
        public string IDImageFileName { get; set; }

        public IFormFile IDImage { get; set; }
    }
}
