using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
{
    public class ObjectCopy
    {
        public int x;
    }
    public class TestObejectCopy
    {
        public void Test()
        {
            ObjectCopy OBJ1 = new ObjectCopy();
            OBJ1.x = 1;
            Console.WriteLine(OBJ1.x);

            ObjectCopy obj2 = new ObjectCopy();
            obj2 = OBJ1;
            Console.WriteLine(obj2.x);

            OBJ1.x = 2;
            Console.WriteLine(obj2.x);
        }
    }
}
