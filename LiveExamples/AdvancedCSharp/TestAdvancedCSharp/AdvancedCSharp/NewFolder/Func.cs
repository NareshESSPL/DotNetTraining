using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.NewFolder
{
    //public delegate T1 Func<T1, T2, T3>(T2 obj2, T3 obj3);
    public class Func
    {
        public void Test()
        {
            Func<string> func = delegate () { return "hello"; };


            Func<string> func2 = () =>  "hello";


            Func<string> func3 = ReturnStr;
        }

        public string ReturnStr()
        {
            return "hello";
        }

        public void FuncAsInput<T>(Func<T> func)
        {
           var data = func();

            Console.WriteLine(data);
        }

        public void TestFuncAsInput()
        {
            Func<double> func = () => 2.0D;

            FuncAsInput(func);

            FuncAsInput(func);
        }


    }
}
