using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Entity;

namespace TestEFCore.Entity
{
    public class Student
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public IEnumerable<StudentTeacher> StudentTeachers { get; set; }

    }

    public class Teacher
    {
        public int TeacherID { get; set; }

        public string TeacherName { get; set; }

        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public IEnumerable<StudentTeacher> StudentTeachers { get; set; }
    }

    public class StudentTeacher
    {
        public int StudentTeacherID { get; set; }

        public int StudentID { get; set; }

        public string TeacherID { get; set; }

        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}
