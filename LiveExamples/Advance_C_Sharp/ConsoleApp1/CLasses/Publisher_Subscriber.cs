using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCSharp
{
        public class DelegateDemo
        {
            public delegate void TestDeligate();

            public void print()
            {
                Console.WriteLine("Printing");

            }

            public void Test()
            {
                TestDeligate test = new TestDeligate(print);

            }

            public void Test(TestDeligate td)
            {
                td();
            }

        }
    


}
