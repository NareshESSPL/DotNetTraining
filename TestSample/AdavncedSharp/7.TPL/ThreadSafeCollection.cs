using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    public class ThreadSafeCollection
    {
        public void Test()
        {

            ConcurrentDictionary<int, string> dict = new ConcurrentDictionary<int, string>();
            dict.TryAdd(1, "Alice");
            dict.TryAdd(2, "Bob");
            Console.WriteLine(dict[1]); // Output: Alice


            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            if (queue.TryDequeue(out int result))
            {
                Console.WriteLine(result); // Output: 10
            }


            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(100);
            stack.Push(200);

            if (stack.TryPop(out int result2))
            {
                Console.WriteLine(result2); // Output: 200



                //An unordered thread-safe collection.
                ConcurrentBag<int> bag = new ConcurrentBag<int>();
                bag.Add(5);
                bag.Add(10);

                if (bag.TryTake(out int result3))
                {
                    Console.WriteLine(result3); // Output: 10 or 5 (order is not guaranteed)
                }
            }

            //Provides bounding and blocking functionality.
            //Useful for producer - consumer patterns.
            BlockingCollection<int> collection = new BlockingCollection<int>(5);
            collection.Add(1);
            collection.Add(2);
            Console.WriteLine(collection.Take()); // Output: 1

        }
    }
}
