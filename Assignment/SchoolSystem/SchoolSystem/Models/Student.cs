using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Roll Number is required")]
        public string RollNo { get; set; }

        public string Address { get; set; }
    }
}
