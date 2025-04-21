using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    //This is for operator
    public class Operator
    {
        public void TestIfElse()
        {
            var var1 = 3;
            if (var1 < 2)
            {
                var temp = 1;
                var temp2 = 3;
                Console.WriteLine(temp + temp2);
                Console.WriteLine("var1 < 2");
            }

            //if only a single line of logic than use without braces
            if (var1 < 2)
                Console.WriteLine("var1 < 2");

            if (var1 < 2)
                Console.WriteLine("var1 < 2");
            else
                Console.WriteLine("var1 > 2");
        }

        public void TestSwitch()
        {
            var input = 1;
            switch (input)
            {
                case 1:
                    Console.WriteLine("v1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                default:
                    Console.WriteLine("3");
                    break;
            }
        }

        public void TestTernaryOperator()
        {
            var x = 1;

            //condition? assign when true : assign when false
            string output = x == 1? "One" : "Other"; 
        }
    }
}
