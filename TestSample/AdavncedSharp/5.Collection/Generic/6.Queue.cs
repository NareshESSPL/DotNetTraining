using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp.Collection
{
    public class TestQueue
    {
        //Stores elements in a First-In-First-Out (FIFO) manner.
        public void Test()
        {
            Queue<string> tasks = new Queue<string>();
            tasks.Enqueue("Task 1");
            tasks.Enqueue("Task 2");
            Console.WriteLine(tasks.Dequeue()); // Outputs "Task 1"
        }
    }
}
