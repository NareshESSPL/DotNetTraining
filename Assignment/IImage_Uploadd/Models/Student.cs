using System.ComponentModel.DataAnnotations;

namespace IImage_Uploadd.Models
{
    public class Student
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DOB { get; set; }

        public string Email { get; set; }
        public string ImagePath { get; set; }
    }
}
