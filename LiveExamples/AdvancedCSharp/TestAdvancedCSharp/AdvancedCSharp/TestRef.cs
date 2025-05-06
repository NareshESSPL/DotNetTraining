using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    public class Student
    {
        public string StudentName { get; set; }

        public int StudentId { get; set; }

    }

    public class TestRef
    {
        public void Test()
        {
            Student s = new Student();
            s.StudentName = "naresh";
            Console.WriteLine(s.StudentName);
            Print(s);
            Console.WriteLine(s.StudentName);
        }

        private void Print(Student s)
        {
            Console.WriteLine(s.StudentName);

            s.StudentName = "Ayush";

            Console.WriteLine(s.StudentName);
        }
    }
}
