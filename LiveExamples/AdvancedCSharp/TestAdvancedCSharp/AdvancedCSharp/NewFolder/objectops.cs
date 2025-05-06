using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.NewFolder
{
    /// <summary>
    /// It adds two objects
    /// </summary>
    public class Adder
    {
        public void Add(object obj1, object obj2)
        {
            if (typeof(int) == obj1.GetType() && typeof(int) == obj2.GetType())
            {
                int i1 = (int)obj1;
                int i2 = (int)obj2;

                Console.WriteLine(i1 + i2);
            }

            else if (typeof(string) == obj1.GetType() && typeof(string) == obj2.GetType())
            {
                string i1 = (string)obj1;
                string i2 = (string)obj2;

                Console.WriteLine(i1 + i2);
            }
        }
    }

    public class TestAdd
    {
        public void Test()
        {
            Adder adder = new();
            object obj1 = 1;
            object obj2 = "2";
            adder.Add(obj1, obj2);
        }
    }
}
