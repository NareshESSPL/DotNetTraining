using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_c_.Generics
{
    public class Adder
    {
        public void Add(Object obj1, Object obj2)
        {
            if (typeof(int) == obj1.GetType() && typeof(int) == obj2.GetType())
            {
                int i1 = Convert.ToInt32(obj1);
                int i2 = Convert.ToInt32(obj2);
                Console.WriteLine(i1 + i2);
            }
            else if (typeof(string) == obj1.GetType() && obj2.GetType() == typeof(string))
            {
                string s1 = Convert.ToString(obj1);
                string s2 = Convert.ToString(obj2);

                Console.WriteLine(s1 + s2);
            }
        }
    }
    public class Test
    {
        public void testing()
        {
            Adder adder   = new Adder();
            Object obj1= new Object();
            Object obj2 = new Object();
            adder.Add(obj1, obj2);
        }
    }
}
