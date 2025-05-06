using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    /// <summary>
    /// It adds two objects
    /// </summary>
    public class Adder
    {
        public void Add<T>(T obj1, T obj2)
        {
            if (typeof(int) == obj1.GetType() && typeof(int) == obj2.GetType())
            {
                int i1 = Convert.ToInt32(obj1);
                int i2 = Convert.ToInt32(obj2);

                Console.WriteLine(i1 + i2);
            }

            else if (typeof(string) == obj1.GetType() && typeof(string) == obj2.GetType())
            {
                string i1 = Convert.ToString(obj1);
                string i2 = Convert.ToString(obj2);

                Console.WriteLine(i1 + i2);
            }
        }
        public void Substract<T>(T obj1, T obj2)
        {
            if (typeof(int) == obj1.GetType() && typeof(int) == obj2.GetType())
            {
                int i1 = Convert.ToInt32(obj1);
                int i2 = Convert.ToInt32(obj2);

                Console.WriteLine(i1 - i2);
            }

            else if (typeof(string) == obj1.GetType() && typeof(string) == obj2.GetType())
            {
                string i1 = Convert.ToString(obj1);
                string i2 = Convert.ToString(obj2);

                Console.WriteLine("String is not supported");
            }
        }

    }

    public class TestAdd
    {
        public void Test()
        {
            Adder adder = new();
            int obj1 = 1;
            int obj2 = 2;
            adder.Add<int>(obj1, obj2);
            adder.Substract<int>(obj1, obj2);
        }
    }
}
