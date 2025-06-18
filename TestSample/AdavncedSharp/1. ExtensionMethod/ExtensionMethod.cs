using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
namespace AdavncedCSharp
{
    /*
     * Extension methods are defined as static methods but are called by using instance method
     * syntax. Their first parameter specifies which type the method operates on. 
     * The parameter follows the this modifier. Extension methods are only in scope 
     * when you explicitly import the namespace into your source code with a using directive.
    */

    #region example 1
    public static class MyExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

    public class TestExtensionMethod1
    {
        public void Test()
        {
            string s = "Hello Extension Methods";
            int i = s.WordCount();
        }
    }

    #endregion

    #region example 2

    public class BaseEntity
    {
        public int Id { get; set; }
    }

    public class Student : BaseEntity
    {
        public string Name { get; set; }
    }

    public static class EntityComparer
    {
        //Generic extension method
        public static bool AreSame<T>(this T firstEntity, T secondEntity) where T : BaseEntity
        {
            return firstEntity.Id == secondEntity.Id;
        }


        //Non-generic extension methods
        public static bool IsEqual(this Student firstEntity, Student secondEntity)
        {
            return firstEntity.Id == secondEntity.Id && firstEntity.Name == secondEntity.Name;
        }
    }

    public class TestExtensionMethod
    {
        public void Test()
        {
            var student1 = new Student { Id = 1, Name = "Ryan" };
            var student2 = new Student { Id = 2, Name = "Jack" };

            if (student1.AreSame<Student>(student2))
                Console.WriteLine("Student1 and Student2 are same");
            else
                Console.WriteLine("Student1 and Student2 are different");

            if (student1.IsEqual(student2))
                Console.WriteLine("Student1 and Student2 has equal data");
            else
                Console.WriteLine("Student1 and Student2 has different data");

        }
    }

    #endregion
}
