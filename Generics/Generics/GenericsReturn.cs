using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_c_.Generics
{
    public class Adder4
    {
        public T1? Add<T1,T2>(T2 obj1, T2 obj2)
        {
            if (typeof(int) == obj1.GetType() && typeof(int) == obj2.GetType())
            {
                int i1 = Convert.ToInt32(obj1);
                int i2 = Convert.ToInt32(obj2);
                var value = i1 + i2;
                return (T1)Convert.ChangeType(value, typeof(T1));
            }
            else if (typeof(string) == obj1.GetType() && obj2.GetType() == typeof(string))
            {
                string s1 = Convert.ToString(obj1);
                string s2 = Convert.ToString(obj2);

                var value = s1 + s2;
                return (T1)Convert.ChangeType(value,typeof(T1));
            }
            return default;
        }

    }

    public class Test4
    {
        public void Test()
        {
            Adder4 adder = new Adder4();
            int obj1 = 1;
            int obj2 = 2;

            decimal res = adder.Add<decimal, int>(obj1, obj2);

            Console.WriteLine(res);
        }
    }
}
