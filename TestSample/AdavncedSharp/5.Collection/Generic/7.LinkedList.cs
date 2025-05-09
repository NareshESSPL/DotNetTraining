using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp.Collection
{
    public class TestLinkedList
    {
        //Stores elements in a First-In-First-Out (FIFO) manner.
        public void Test()
        {// Create a new LinkedList of strings
            LinkedList<int> l = new LinkedList<int>();

            // Add elements to the LinkedList

            // Adds at the end
            l.AddLast(10);
            // Adds at the beginning
            l.AddFirst(20);
            // Adds at the end
            l.AddLast(30);
            // Adds at the end
            l.AddLast(40);

            // Display the elements in the LinkedList
            Console.WriteLine("Elements in the LinkedList:");
            foreach (var i in l)
            {
                Console.WriteLine(i);
            }
        }
    }
}
