using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{

    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Age { get; set; }

        [Display(Name = "EmailAddress"), Required(ErrorMessage = "plese enter a valid Email")]
        public String  Email { get; set; }

        // public String ? Email { get; set; }


        public String  Password { get; set; }

        public String SelectedGender { get; set; } = "1";
    }
}