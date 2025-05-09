using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp.Collection
{
    public class TestHashset
    {
        public void Test()
        {
            // Create a HashSet 
            HashSet<int> hs = new HashSet<int>();

            // Add elements to the HashSet
            hs.Add(10);
            hs.Add(20);
            hs.Add(30);
            hs.Add(10);

            HashSet<int> s = new HashSet<int> { 1, 2, 3 };

            //remove item
            s.Remove(1);

            HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 5 };
            HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

            // Union of two sets
            set1.UnionWith(set2);
            Console.WriteLine("After Union: "
                              + string.Join(", ", set1));

            // Intersection of two sets
            set1.IntersectWith(new HashSet<int> { 3, 5 });
            Console.WriteLine("After Intersection: "
                              + string.Join(", ", set1));

            // Difference of sets
            set1.ExceptWith(new HashSet<int> { 5 });
            Console.WriteLine("After Difference: "
                              + string.Join(", ", set1));

            // Display elements in the HashSet
            Console.WriteLine("Elements in the HashSet: ");
            foreach (int number in hs)
                Console.WriteLine(number);

        }

        /*
         * List<T>.GetEnumerator Method is used to 
         * returns an enumerator that iterates through the List<T>.
        */
        public void TestEnumerator()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            List<int>.Enumerator em = numbers.GetEnumerator();

            while (em.MoveNext())
            {
                int val = em.Current;
                Console.WriteLine(val);
            }
        }
    }
}
