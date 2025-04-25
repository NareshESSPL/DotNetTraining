using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class TestDestructor
    {
        public TestDestructor() { }

        ~TestDestructor()
        {
            Console.WriteLine("Destroy me!!");
        }
    }

    public class Testing
    {
        public void Test()
        {
            TestDestructor obj = new TestDestructor();

            obj = null;
        }
    }
}
