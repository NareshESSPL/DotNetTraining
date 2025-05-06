using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    //public delegate void Action<T1, T2>();
    public class ActionExample
    {
        public void Test()
        {
            Action print = () => Console.WriteLine("Print lambda");
            print += PrintToFile;
            print += delegate () { Console.WriteLine("print anonymous"); };
            
            print(); // Output: Hello, World!
        }

        public void PrintToFile()
        {

        }
    }
}
