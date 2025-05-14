using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Generics//<T> where T : struct
    {
        //generic at class level
        //public  T1? Add<T1,T2>(T2 obj1, T2 obj2)
        //{
        //    if (typeof(int) == obj1.GetType() && typeof(int) == obj2.GetType())
        //    {
        //        int i1 = Convert.ToInt32(obj1);
        //        int i2 = Convert.ToInt32(obj2);
        //        //Console.WriteLine(i1 - i2);
        //        var value =  i1+i2;

        //        return (T1) Convert.ChangeType(value, typeof(T1));

        //    }
        //    else if (typeof(string) == obj1.GetType() && typeof(string) == obj2.GetType())
        //    {
        //        string s1 = Convert.ToString(obj1);
        //        string s2 = Convert.ToString(obj2);
        //        Console.WriteLine("Method not support by string data type.");
        //    }
        //}

    }
//public class Adder
//{
//    public T1? Add<T1, T2>(T2 obj1, T2 obj2)
//    {
//        if (typeof(int) == obj1.GetType() && typeof(int) == obj2.GetType())
//        {
//            return (T1)Convert.ChangeType(Convert.ToInt32(obj1) + Convert.ToInt32(obj2), typeof(T1));
//        }
//        return default;

//    }
//}
}
