using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    public class TestFuncDelegate
    {
        public void Test()
        {
            //Delegate follow FIFO, so here the last lambda will be returned
            Func<int, int> square = num => num * num;

            square += num => num + num;
            
            Console.WriteLine(square(5)); // Output
        }
    }
}
