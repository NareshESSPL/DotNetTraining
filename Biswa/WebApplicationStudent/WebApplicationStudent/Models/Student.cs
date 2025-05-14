namespace WebApplicationStudent.Models
{
    public class Student
    {
        public int StudentID { get; set; }     // Matches primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
