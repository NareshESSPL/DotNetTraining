using AdavncedCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    /*
       If you are using new() constraint then T must be a class 
       with parameterless constructor. 
    
       The benefit is you can create a object T e.g. T obj = new T()
    */
    public class DBOps<T> where T : new()
    {
        public void Testing()
        {
            T obj = new T();
        }
    }

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

    public class Testsing
    {
        public void TestGeneric()
        {
            DBOps<Student> obj = new DBOps<Student>();

        }
    }
}
