using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    public class TestPredicate
    {
        public void Test()
        {
            Predicate<int> isEven = num => num % 2 == 0;
            Console.WriteLine(isEven(4)); // Output: True
            Console.WriteLine(isEven(7)); // Output: False


            List<int> numbers = new List<int> { 5, 8, 12, 17, 21 };

            Predicate<int> isGreaterThan10 = num => num > 10;

            int result = numbers.Find(isGreaterThan10);
            Console.WriteLine(result); // Output: 12 (First number > 10)
        }
    }
}
