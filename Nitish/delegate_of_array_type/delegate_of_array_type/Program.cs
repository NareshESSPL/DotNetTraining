using System;
namespace delegate_of_array_type
{

    class Program
    {
        // Generic delegate with constraint
        delegate T[] SortDelegate<T>(T[] input) where T : IComparable<T>;

        // Sort method using Array.Sort
        static T[] DefaultSort<T>(T[] input) where T : IComparable<T>
        {
            T[] arr = (T[])input.Clone();
            Array.Sort(arr);
            return arr;
        }

        // Generic sort runner
        static T[] SortArray<T>(T[] array, SortDelegate<T> sorter) where T : IComparable<T>
        {
            return sorter(array);
        }

        static void Main()
        {
            int[] numbers = { 5, 2, 8, 1 };
            string[] words = { "banana", "apple", "cherry" };

            int[] sortedNumbers = SortArray(numbers, DefaultSort);
            string[] sortedWords = SortArray(words, DefaultSort);

            Console.WriteLine("Sorted Numbers: " + string.Join(", ", sortedNumbers));
            Console.WriteLine("Sorted Words: " + string.Join(", ", sortedWords));
        }
    }
}
