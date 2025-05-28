using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Students
    {
        public int  StudentId { get; set; }

        [Display(Name = "FullName"), Required(ErrorMessage = "Please enter a valid name")]
        public string StudentName { get; set; }

        [Display(Name = "Email"), Required(ErrorMessage = "Please enter a valid Email")]
        public string StudentEmail { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Please enter age")]
        public int  StudentAge { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
        public DateTime AddmissionDate { get; set; }

        [Display(Name = "Date of Birth (IST Format: YYYY-MM-DD)")]
        [Required(ErrorMessage = "Please enter a valid Date of Birth in IST format (YYYY-MM-DD)")]
        public DateOnly DOB {  get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please select gender")]
        public string Gender { get; set; }

    }
}
