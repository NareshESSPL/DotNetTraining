using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator
{
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators
    public class ArithmaticOperator
    {
        public void TestAritmaticOperator()
        {
            //Postfix increment operator
            int i = 3;
            Console.WriteLine(i);   // output: 3
            Console.WriteLine(i++); // output: 3
            Console.WriteLine(i);   // output: 4

            //Prefix increment operator
            double a = 1.5;
            Console.WriteLine(a);   // output: 1.5
            Console.WriteLine(++a); // output: 2.5
            Console.WriteLine(a);   // output: 2.5

            //Postfix decrement operator
            int j = 3;
            Console.WriteLine(j);   // output: 3
            Console.WriteLine(j--); // output: 3
            Console.WriteLine(j);   // output: 2

            //Prefix decrement operator
            double b = 1.5;
            Console.WriteLine(b);   // output: 1.5
            Console.WriteLine(--b); // output: 0.5
            Console.WriteLine(b);   // output: 0.5

            //Unary plus and minus operators
            //computes the numeric negation of its operand.
            Console.WriteLine(+4);     // output: 4

            Console.WriteLine(-4);     // output: -4
            Console.WriteLine(-(-4));  // output: 4

            uint c = 5;
            var d = -a;
            Console.WriteLine(c);            // output: -5
            Console.WriteLine(d.GetType());  // output: System.Int64

            Console.WriteLine(-double.NaN);  // output: NaN

            //Multiplication operator
            Console.WriteLine(5 * 2);         // output: 10
            Console.WriteLine(0.5 * 2.5);     // output: 1.25
            Console.WriteLine(0.1m * 23.4m);  // output: 2.34

            //Division operator
            Console.WriteLine(13 / 5);    // output: 2
            Console.WriteLine(-13 / 5);   // output: -2
            Console.WriteLine(13 / -5);   // output: -2
            Console.WriteLine(-13 / -5);  // output: 2

            //To obtain the quotient of the two operands as a floating-point number, use the float, double, or decimal type:
            Console.WriteLine(13 / 5.0);       // output: 2.6

            int e = 13;
            int f = 5;
            Console.WriteLine((double)e / f);  // output: 2.6



        }
    }
}
