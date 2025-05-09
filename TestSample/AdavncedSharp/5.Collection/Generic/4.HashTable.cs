using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp.Collection
{
    public class TestHashTable
    {
        /*
        Stores data as key-value pairs.

        Keys must be unique and cannot be null.

        Values can be null or duplicate.

        Provides fast lookups using hash codes.

        Implements the IDictionary interface. 
        */
        public void Test()
        {
            Hashtable hashtable = new Hashtable();

            // Adding key-value pairs
            hashtable.Add(1, "One");
            hashtable.Add(2, "Two");
            hashtable.Add(3, 5.0D);
            hashtable.Add(3, new Student());

            // Accessing values
            Console.WriteLine($"Value for key 2: {hashtable[2]}");

            // Checking if a key exists
            if (hashtable.ContainsKey(3))
            {
                Console.WriteLine("Key 3 exists in the Hashtable.");
            }

            // Iterating through the Hashtable
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

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
