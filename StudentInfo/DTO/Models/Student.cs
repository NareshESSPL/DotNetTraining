using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;

namespace DTO.Models
{
    public class Student
    {

        [Display(Name = "Registration ID"), Required(ErrorMessage = "Enter valid registration ID")]
        public int StudentRegistrationId { get; set; } 

        [Display(Name = "Enter Student Name"), Required(ErrorMessage = "Enter valid Student Name !!!")]
        public string StudentName { get; set; } = "";

        [Range(15,30,ErrorMessage = "Age must be between 15 and 30")]
        public int StudentAge { get; set; }

        public string StudentBirthday { get; set; } = "";

        public int StudentGender { get; set; }

        // public IEnumerable<SelectListItem> GenderOptions { get; set; }
        [EmailAddress]
        public string StudentEmailId { get; set; } = "";

        [Required(AllowEmptyStrings = false)]
        public string FileName { get; set; } = "";



        public byte[]? IDImageAsByteArray { get; set; }

        [Required(AllowEmptyStrings = false)]
        public IFormFile IDImage { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string IDFileName { get; set; } = "";



        [Required(AllowEmptyStrings = false)]
        public IFormFile EmployeeImage { get; set; }

        public byte[]? EmployeeImageAsByteArray { get; set; }


        //public string FilterAttribute { get; set; } = "";
        //public List<SelectListItem> FilterList { get; set; }



    }
}
