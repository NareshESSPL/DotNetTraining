using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    namespace ClassLibrary
    {
        public class ActionDelegateGeneric
        {
            public void Test<T>(T value)
            {
                Action<T> print = (val) => Console.WriteLine("Lambda: " + val);
                print += PrintToFile;
                print += delegate (T val) { Console.WriteLine("Anonymous: " + val); };

                print(value);
            }

            public void PrintToFile<T>(T val)
            {
                Console.WriteLine("ToFile: " + val);
            }
        }
    }


