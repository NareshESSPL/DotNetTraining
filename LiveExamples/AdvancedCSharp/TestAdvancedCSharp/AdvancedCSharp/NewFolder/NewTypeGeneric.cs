using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.NewFolder
{
    public class StudentDotNet
    {
        public string StudentName { get; }
        public int StudentId { get; }

        public StudentDotNet(string studentName, int studentId)
        {
            StudentName = studentName;
            StudentId = studentId;
        }
    }

    public class DBOps<T> where T : new()
    {
        public void Testing()
        {
            T obj = new T();
        }
    }


    public class Testsing
    {
        public void TestGeneric()
        {
            DBOps<Student> obj = new DBOps<Student>();

        }
    }
}
