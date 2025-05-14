using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceCSharp.Delegate_Method;

namespace AdvanceCSharp
{
    public class Delegate_Method
    {
        public delegate void testDel();

        public void Print()
        {
            Console.WriteLine("Printing");
        }


        public void AttachMethod()
        {
            testDel obj = new testDel(Print);
        }

        public void Test(testDel obj)
        {
            obj();
        }

    }

}

