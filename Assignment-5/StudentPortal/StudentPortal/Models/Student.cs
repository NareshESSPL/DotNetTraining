namespace StudentPortal.Models
{
    public class Student
    {
        public int StudentID { get; set; }              // Primary key, auto-incremented
        public string FirstName { get; set; }           // Required
        public string LastName { get; set; }            // Required
        public DateTime? DateOfBirth { get; set; }      // Nullable
        public char? Gender { get; set; }               // Nullable char ('M' or 'F')
        public string Email { get; set; }               // Unique
        public string PhoneNumber { get; set; }         // Optional
        public DateTime? EnrollmentDate { get; set; }   // Default to current date if null

    }
}
