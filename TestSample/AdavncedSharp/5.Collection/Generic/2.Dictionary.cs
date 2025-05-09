using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp.Collection
{
    public class TestDictionary
    {
        public void Test()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            // Adding key-value pairs
            dict.Add(1, "Welcome");
            dict.Add(2, "to");
            dict.Add(3, "GeeksforGeeks");

            // Using ContainsKey() to check if the key exists
            if (dict.ContainsKey(1))
                Console.WriteLine("Key is found...!!");
            else
                Console.WriteLine("Key is not found...!!");

            // Using ContainsValue() to check if the value exists
            if (dict.ContainsValue("to"))
                Console.WriteLine("Value is found...!!");
            else
                Console.WriteLine("Value is not found...!!");

            if(dict.TryGetValue(4, out string value))
                Console.WriteLine("Value found with key 4");
            else
                Console.WriteLine("No value found with key 4");

            if(dict.TryAdd(4, "test"))
                Console.WriteLine("Value adde with key 4");
            else
                Console.WriteLine("No value found with key 4");

            //Each item in dictionary is of type KeyValuePair<T1, T2>
            foreach (KeyValuePair<int, string> kvp in dict)
            {
                Console.WriteLine(kvp.Key.ToString() + ": " + kvp.Value.ToString());
            }

            dict.Clear();

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
