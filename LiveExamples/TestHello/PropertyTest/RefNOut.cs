using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTest
{
    public class RefNOut
    {
        public bool IsOdd(int input, out string message)
        {
            //if(input % 2 == 0) return true;
            var isSuceess = input % 2 == 0;
            message = isSuceess ? "This is even" : "This is odd";

            return isSuceess;
        }


        public bool IsPrime(int input, ref string message)
        {
            //if(input % 2 == 0) return true;
            var isSuceess = input % 2 == 0;
            message = isSuceess ? "This is even" : "This is odd";

            return isSuceess;
        }

        public void TestIsOdd()
        {
            string message;
            var isSucess = IsOdd(3, out message);


            isSucess = IsOdd(3, out string message3);

            string message2 = "There is a message";
            isSucess = IsPrime(3, ref message2);

            if(int.TryParse("", out int y))
                Console.WriteLine(y);
        }
    }
}
