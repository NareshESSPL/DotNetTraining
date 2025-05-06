using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    // Define a generic delegate
    public delegate T GenericDelegate<T>(T input);

    public class GenericDelegateExample
    {
        // Method matching the delegate signature
        public static int Square(int number)
        {
            return number * number;
        }

        public static string RepeatString(string input)
        {
            return input + input;
        }

        public void Test()
        {
            // Using GenericDelegate with an integer
            GenericDelegate<int> intDelegate = Square;
            int result = intDelegate(5); // Calls Square method
            Console.WriteLine($"Square of 5 is: {result}");

            // Using GenericDelegate with a string
            GenericDelegate<string> stringDelegate = RepeatString;
            string textResult = stringDelegate("Hello ");
            Console.WriteLine($"Repeated string is: {textResult}");
        }
    }
}
