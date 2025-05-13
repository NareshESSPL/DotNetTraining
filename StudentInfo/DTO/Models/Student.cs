using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models
{
    public class Student
    {

        [Display(Name="Registration ID"), Required(ErrorMessage="Enter valid registration ID")]
         public  int StudentRegistrationId { get; set; }

        [Display(Name="Enter Student Name"),Required(ErrorMessage ="Enter valid Student Name !!!")]
        public  string StudentName { get; set; }

        [Range(15,30,ErrorMessage = "Age must be between 15 and 30")]
        public int StudentAge { get; set; }

        public string StudentBirthday { get; set; }

        public int StudentGender { get; set; }

        public string StudentEmailId { get; set; }






    }
}
