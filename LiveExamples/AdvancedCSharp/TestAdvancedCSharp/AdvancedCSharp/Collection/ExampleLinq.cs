
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.Collection
{
    public class Student
    {
        public int StudentID { get; set; }
        public int GradeID { get; set; }
        public string StudentName { get; set; }
    }

    public class Grade
    {
        public int GradeID { get; set; }
        public string GradeName { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

    }


    public class ExampleLinq
    {
        List<Student> Students = new List<Student>();
        List<Grade> Grades = new List<Grade>();
        public ExampleLinq()
        {
            Students = new List<Student>();
            {
                new Student { StudentID = 1, GradeID = 1, StudentName = "Naresh" },
              new Student { StudentID = 2, GradeID = 1, StudentName = "Mahesh" }

            };


            Grades = new List<Grade>()
            {
              new Grade { GradeID = 1, GradeName = "A", Students = Students}

            };
        }

        public void Test()
        {
            var temp = from s in Students
                    join g in Grades
                    on s.GradeID equals g.GradeID
                    select new
                    {
                        StudentID = s.StudentID,
                        StudentName = s.StudentName,
                        GradeName = g.GradeName
                    };

            var result = Students.Join(
                Grades,
                s => s.GradeID,
                g => g.GradeID,
                (s, g) => new
                {
                    StudentID = s.StudentID,
                    StudentName = s.StudentName,
                    GradeName = g.GradeName
                }).ToList();


            foreach (var item in temp)
                Console.WriteLine(item.StudentID)
        }
    }
}
