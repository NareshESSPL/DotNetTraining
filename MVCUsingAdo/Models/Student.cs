using System.ComponentModel.DataAnnotations;

namespace MVCUsingAdo.Models
{
    public class Student
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(10,50,ErrorMessage ="age must be between 10 to 50")]
        public int? age { get; set; }
        [Required]
        [Range(0,100,ErrorMessage ="marks must be between 0 to 100")]
        public int marks { get; set; }
    }
}
