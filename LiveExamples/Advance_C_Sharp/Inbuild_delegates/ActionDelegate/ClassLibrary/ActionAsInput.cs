using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //public delegate T1 Func<T1, T2, T3>(T2 obj2, T3 obj3);
    //public  class Func
    //{
    //    public void test()
    //    {
    //        Func<string> func1 = delegate () { return "hello"; };
    //    }
    //}
    public class ActiondelgateWithgenerics
    {

        public void TestAction()
        {
            Action<string, int> printing = (string input1, int input2) => Console.WriteLine(input2);
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
    }
    //public string ReturnSTR()
    //    {
    //        return "hello";
    //    }
}
