using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp.Collection
{
    public class TestStack
    {
        //Stores elements in a Last-In-First-Out (LIFO) manner.
        public void Test()
        {
            Stack<string> books = new Stack<string>();
            books.Push("Book A");
            books.Push("Book B");
            Console.WriteLine(books.Pop()); // Outputs "Book B"
        }
    }
}
