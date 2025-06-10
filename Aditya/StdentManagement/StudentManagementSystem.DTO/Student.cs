using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTO
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }

}
