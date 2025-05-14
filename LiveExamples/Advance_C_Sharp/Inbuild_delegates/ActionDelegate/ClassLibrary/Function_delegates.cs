using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public  class Function_delegates
    {

        public void FuncAsInput<T>(Func<T> func)
        {
            var data = func();
            Console.WriteLine(data);
        }
        public void TestFuncASInput()
        {
            Func<double> func = () => 2.00;
            FuncAsInput(func);
            FuncAsInput(() => 2.00);
        }

        public void FuncASInput2<T1, T2>(Func<T1, T2> func, T1 input)
        {
            T2 data = func(input);
            Console.WriteLine(data);
        }

        public void TestFuncASInput2()
        {
            Func<int, double> func = (x) => x * 2.5;

            FuncASInput2(func, 4);

            FuncASInput2((int x) => x + 3.14, 2); 
        }
    }
}
