using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass
{
    /// <summary>
    /// It adds two objects
    /// </summary>
    public class Adder<T> where T : struct
    {
        public T1? Add<T1, T2, T3, T4>(T2 obj1, T2 obj2)
        {
            if (typeof(int) == obj1.GetType() && typeof(int) == obj2.GetType())
            {
                int i1 = Convert.ToInt32(obj1);
                int i2 = Convert.ToInt32(obj2);

                var value = i1 + i2;

                return (T1)Convert.ChangeType(value, typeof(T1));
            }

            else if (typeof(string) == obj1.GetType() && typeof(string) == obj2.GetType())
            {
                string i1 = Convert.ToString(obj1);
                string i2 = Convert.ToString(obj2);

                var value = i1 + i2;

                return (T1)Convert.ChangeType(value, typeof(T1));
            }

            return default;
        }
        //public void Substract(T obj1, T obj2)
        //{
        //    if (typeof(int) == obj1.GetType() && typeof(int) == obj2.GetType())
        //    {
        //        int i1 = Convert.ToInt32(obj1);
        //        int i2 = Convert.ToInt32(obj2);

        //        Console.WriteLine(i1 - i2);
        //    }

        //    else if (typeof(string) == obj1.GetType() && typeof(string) == obj2.GetType())
        //    {
        //        string i1 = Convert.ToString(obj1);
        //        string i2 = Convert.ToString(obj2);

        //        Console.WriteLine("String is not supported");
        //    }
        //}

    }

    public class TestAdd
    {
        public void Test()
        {
            Adder<int> adder = new Adder<int>();
            //Adder<int> adder = new();
            //int obj1 = 1;
            //int obj2 = 2;
            //adder.Add(obj1, obj2);
            //adder.Substract(obj1, obj2);
        }
    }
}
