using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class ObjectCopy
    {
        public int x;
        public void Test()
        {
        }
    }

    public class ObjectCopy2 : ObjectCopy
    {
        public int x;
        public void Test()
        {
        }
    }

    public class TestObjectCopy
    {
        public void Test()
        {
            ObjectCopy obj1 = new ObjectCopy();
            obj1.x = 1;

            Console.WriteLine(obj1.x);

            ObjectCopy obj2 = new ObjectCopy();
            obj2 = obj1;

            Console.WriteLine(obj2.x);

            obj1.x = 2;
            Console.WriteLine(obj2.x);



        }
    }
}
