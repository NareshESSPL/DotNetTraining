using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class BitwiseOperator
    {
        public void TestBitwiseOperator()
        {
            // Binary representation: 1010
            int x = 10;

            // Binary representation: 0010
            int y = 2;

            // Bitwise AND 
            Console.WriteLine(x & y);

            // Bitwise OR 
            Console.WriteLine(x | y);

            // Bitwise XOR 
            Console.WriteLine(x ^ y);

            // Bitwise NOT 
            Console.WriteLine(~x);

            // Shifting bit by one on the left
            Console.WriteLine(x << 1);

            // Shifting bit by one on the right
            Console.WriteLine(x >> 1);
        }
    }
}
