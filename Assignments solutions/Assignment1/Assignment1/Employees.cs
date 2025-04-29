namespace EmployeeManagementSystem
{
    public class Employee
    {
        public string Name { get; set; }
        public int EmplyeeID { get; set; }

        public string department { get; set; }
        public char Gender { get; set; }
        public int age { get; set; }
        public int YearOfExperience { get; set; }

        public virtual void EmployeeDetails() { }
    }

}