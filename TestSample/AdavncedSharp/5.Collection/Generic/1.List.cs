using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp.Collection
{
    //https://www.geeksforgeeks.org/c-sharp-list-class/
    public class TestList
    {
        public void Test()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            
            numbers.Add(6);
            Console.WriteLine(string.Join(", ", numbers));

            var temp = new List<int>() { 7, 9, 9, 10 };

            numbers.AddRange(temp);

            //Inserts an element into the List<T> at the specified index.
            numbers.Insert(3, 9);

            numbers.InsertRange(3, temp);

            numbers.Sort();

            numbers.Reverse();

            if (numbers.Contains(6))
                Console.WriteLine("List contains 6");

            if(numbers.Exists(i => i < 10))
                Console.WriteLine("List contains number less than 10");

            //return the first occurance
            var miniNumbers = numbers.Find(i => i < 10);

            var miniNumbers3 = numbers.FindLast(i => i < 10);

            //return all item that matches the criteria
            var miniNumbers2 = numbers.FindAll(i => i < 10);

            //Searches for an element that matches the conditions defined
            //by a specified predicate, and returns the zero-based index
            //of the first occurrence within the List<T> or a portion of it.
            //This method returns -1 if an item that matches the conditions
            //is not found.
            var index = numbers.FindIndex(i => i == 3);

            var index2 = numbers.FindLastIndex(i => i == 3);

            var count = numbers.Count();

            //Remove at specified index
            numbers.RemoveAt(2);

            //Clear List
            numbers.Clear();

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
