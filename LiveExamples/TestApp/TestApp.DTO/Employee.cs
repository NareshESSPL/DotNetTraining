using System.ComponentModel.DataAnnotations;

namespace TestApp.DTO
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "FullName"), Required(ErrorMessage ="Please enter a valid name")]
        public string Name { get; set; }

        [Range(18, 60, ErrorMessage ="Age must be between 18 to 65")]
        public int Age { get; set; }

        public int Gender { get; set; }
    }
}
