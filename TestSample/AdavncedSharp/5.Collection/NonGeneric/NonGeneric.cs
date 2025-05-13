using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp.Collection
{
    public class NonGeneric
    {
        public void Test()
        {
            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add("Hello");
            list.Add(3.14);
            Console.WriteLine(string.Join(", ", list));


            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "One");
            hashtable.Add(2, "Two");
            Console.WriteLine($"Value for key 2: {hashtable[2]}");

            SortedList sortedList = new SortedList();
            sortedList.Add(3, "Three");
            sortedList.Add(1, 1);
            sortedList.Add(2, "Two");

            Stack stack = new Stack();
            stack.Push("First");
            stack.Push("Second");
            Console.WriteLine(stack.Pop()); // Outputs "Second"

            Queue queue = new Queue();
            queue.Enqueue("Task 1");
            queue.Enqueue("Task 2");
            Console.WriteLine(queue.Dequeue()); // Outputs "Task 1"

            BitArray bits = new BitArray(new bool[] { true, false, true });
            foreach (bool bit in bits)
                Console.WriteLine(bit);
        }
    }
}
