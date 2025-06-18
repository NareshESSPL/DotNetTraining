using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class NullableType
    {
        public void TestNullableType()
        {
            //Default value is null
            float? input;
            int? nullableInt = null; // Nullable integer
            double? nullableDouble = 3.14; // Nullable double with a value


            //Check has value
            if (nullableInt.HasValue)
            {
                //Get value
                Console.WriteLine($"Value: {nullableInt.Value}");
            }
            else
            {
                Console.WriteLine("No value.");
            }

            //Null-Coalescing Operator (??):
            int result = nullableInt ?? 8; // If nullableInt is null, result is 8

            //Null-Conditional Operator (?.):
            //if nullableInt has value then get the value otherwise if the value is null
            //for entire expression
            int? length = nullableInt?.ToString()?.Length;
        }
    }
}
