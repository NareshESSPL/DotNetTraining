using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_c_.Generics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Advance_c_.Generics
    {
        public class Adder3<T> where T: struct
        {
            public void Add(T obj1, T obj2)
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
            public void Substract(T obj1, T obj2)
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

                    Console.WriteLine("String ids not supported");
                }
            }
        }
        public class Test2
        {
            public void Test()
            {
                //Adder3 adder = new();
                //int obj1 = 4;
                //int obj2 = 2;
                //adder.Add<int>(obj1, obj2);
                //adder.Substract<int>(obj1,obj2);

                Adder3<int> adder = new();
                int obj1 = 4;
                int obj2 = 2;
                adder.Add(obj1, obj2);
                adder.Substract(obj1, obj2);
            }
        }
    }

}
