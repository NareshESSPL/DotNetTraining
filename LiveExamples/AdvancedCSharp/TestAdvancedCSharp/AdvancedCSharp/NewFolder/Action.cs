using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

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

        //public delegate void Action<T>(T input);



        public void TesAction()
        {
            Action<string, int> printing = (string input, int input2) => Console.WriteLine(input);
        }

        public void ActionAsInput<T>(Action<T> action, T input)
        {
            action(input);
        }

        public void TestActionAsInput()
        {
            Action<int> action = (int input) => Console.WriteLine(input);

            ActionAsInput<int>(action, 1);

            ActionAsInput<int>((int input) => Console.WriteLine(input), 1);
        }

        //public void TestAction()
        //{
        //    Action<string> printing = (string input) => Console.WriteLine(input);
        //}
    }
}
